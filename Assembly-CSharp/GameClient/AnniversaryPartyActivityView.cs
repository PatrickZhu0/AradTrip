using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Parser;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001816 RID: 6166
	public class AnniversaryPartyActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F2E7 RID: 62183 RVA: 0x00419A3C File Offset: 0x00417E3C
		public void Init(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (data.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(data.StartTime), this._TransTimeStampToStr(data.EndTime)));
			this.mRuleDesTxt.SafeSetText(data.RuleDesc.Replace('|', '\n'));
			this.mGoBtn.SafeAddOnClickListener(new UnityAction(this._OnGoBtnClick));
			this.mPreviewBtn.SafeAddOnClickListener(new UnityAction(this._OnPreviewBtnClick));
			this._InitItems(data);
		}

		// Token: 0x0600F2E8 RID: 62184 RVA: 0x00419ADB File Offset: 0x00417EDB
		public void UpdateData(ILimitTimeActivityModel data)
		{
		}

		// Token: 0x0600F2E9 RID: 62185 RVA: 0x00419ADD File Offset: 0x00417EDD
		public void Show()
		{
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600F2EA RID: 62186 RVA: 0x00419AEC File Offset: 0x00417EEC
		public void Close()
		{
			this.Dispose();
			this.mPreviewItemId = 0;
			this.mGoBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGoBtnClick));
			this.mPreviewBtn.SafeRemoveOnClickListener(new UnityAction(this._OnPreviewBtnClick));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2EB RID: 62187 RVA: 0x00419B3F File Offset: 0x00417F3F
		public void Dispose()
		{
		}

		// Token: 0x0600F2EC RID: 62188 RVA: 0x00419B41 File Offset: 0x00417F41
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F2ED RID: 62189 RVA: 0x00419B50 File Offset: 0x00417F50
		private void _InitItems(ILimitTimeActivityModel model)
		{
			if (model.ParamArray != null)
			{
				this.mLeftDropList.Clear();
				this.mRightDropList.Clear();
				for (int i = 0; i < model.ParamArray.Length - 1; i++)
				{
					int item = (int)model.ParamArray[i];
					if (i < this.mSplitNum)
					{
						this.mLeftDropList.Add(item);
					}
					else
					{
						this.mRightDropList.Add(item);
					}
					if (this.mLeftDrop != null)
					{
						this.mLeftDrop.SetDropList(this.mLeftDropList, 0);
					}
					if (this.mRightDrop != null)
					{
						this.mRightDrop.SetDropList(this.mRightDropList, 0);
					}
				}
				int num = (int)model.ParamArray[model.ParamArray.Length - 1];
				this.mPreviewItemId = num;
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mPreviewItemId, 100, 0);
				ComItem comItem = ComItemManager.Create(this.mPreviewTrans.gameObject);
				if (itemData != null && comItem != null)
				{
					comItem.GetComponent<RectTransform>().sizeDelta = this.mPreviewItemSize;
					ComItem comItem2 = comItem;
					ItemData item2 = itemData;
					if (AnniversaryPartyActivityView.<>f__mg$cache0 == null)
					{
						AnniversaryPartyActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item2, AnniversaryPartyActivityView.<>f__mg$cache0);
				}
			}
		}

		// Token: 0x0600F2EE RID: 62190 RVA: 0x00419C95 File Offset: 0x00418095
		private void _OnGoBtnClick()
		{
			NpcParser.OnClickLinkByNpcId(2095);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
		}

		// Token: 0x0600F2EF RID: 62191 RVA: 0x00419CAD File Offset: 0x004180AD
		private void _OnPreviewBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, this.mPreviewItemId, string.Empty);
		}

		// Token: 0x0600F2F0 RID: 62192 RVA: 0x00419CCC File Offset: 0x004180CC
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x04009558 RID: 38232
		[SerializeField]
		private Button mGoBtn;

		// Token: 0x04009559 RID: 38233
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x0400955A RID: 38234
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x0400955B RID: 38235
		[SerializeField]
		private int mSplitNum = 2;

		// Token: 0x0400955C RID: 38236
		[SerializeField]
		private ComChapterInfoDrop mLeftDrop;

		// Token: 0x0400955D RID: 38237
		[SerializeField]
		private ComChapterInfoDrop mRightDrop;

		// Token: 0x0400955E RID: 38238
		[SerializeField]
		private Transform mPreviewTrans;

		// Token: 0x0400955F RID: 38239
		[SerializeField]
		private Vector2 mPreviewItemSize = new Vector2(60f, 60f);

		// Token: 0x04009560 RID: 38240
		[SerializeField]
		private Button mPreviewBtn;

		// Token: 0x04009561 RID: 38241
		private int mPreviewItemId;

		// Token: 0x04009562 RID: 38242
		private List<int> mLeftDropList = new List<int>();

		// Token: 0x04009563 RID: 38243
		private List<int> mRightDropList = new List<int>();

		// Token: 0x04009564 RID: 38244
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
