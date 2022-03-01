using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001814 RID: 6164
	public class AnniversaryLoginActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F2CE RID: 62158 RVA: 0x00418D30 File Offset: 0x00417130
		public void Init(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (data.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(data.StartTime), this._TransTimeStampToStr(data.EndTime)));
			this.mRuleTxt.SafeSetText(data.RuleDesc);
			this.mData = data;
			this.mOnItemClick = onItemClick;
			this.mRewardBtn.SafeAddOnClickListener(new UnityAction(this._OnRewardBtnClick));
			this.mId = (int)data.TaskDatas[0].DataId;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			for (int i = 0; i < this.mData.TaskDatas.Count; i++)
			{
				for (int j = 0; j < this.mData.TaskDatas[i].AwardDataList.Count; j++)
				{
					int id = (int)this.mData.TaskDatas[i].AwardDataList[j].id;
					if (!this.mRequestedGiftPackIds.Contains(id))
					{
						this.mRequestedGiftPackIds.Add(id);
					}
					DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(id);
				}
			}
		}

		// Token: 0x0600F2CF RID: 62159 RVA: 0x00418E7F File Offset: 0x0041727F
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.UpdateMyDate(data, false);
		}

		// Token: 0x0600F2D0 RID: 62160 RVA: 0x00418E8C File Offset: 0x0041728C
		private void UpdateMyDate(ILimitTimeActivityModel data, bool isInit = true)
		{
			ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = data.TaskDatas[0];
			if (limitTimeActivityTaskDataModel != null)
			{
				bool flag = false;
				if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_FINISHED)
				{
					this.mRewardBtn.CustomActive(true);
					this.mHaveRewardGo.CustomActive(false);
					flag = false;
				}
				else if (limitTimeActivityTaskDataModel.State == OpActTaskState.OATS_OVER)
				{
					this.mRewardBtn.CustomActive(false);
					this.mHaveRewardGo.CustomActive(true);
					flag = true;
				}
				if (isInit)
				{
					for (int i = 0; i < this.mGiftPackItemData.Count; i++)
					{
						GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(data.ItemPath, true, 0U);
						if (gameObject == null)
						{
							return;
						}
						AnniversaryLoginActivityItem component = gameObject.GetComponent<AnniversaryLoginActivityItem>();
						if (component == null)
						{
							return;
						}
						component.Init(flag, this.mGiftPackItemData[i]);
						gameObject.transform.SetParent(this.mItemRoot, false);
						gameObject.transform.localScale = Vector3.one;
					}
				}
				else if (flag)
				{
					for (int j = 0; j < this.mItemRoot.childCount; j++)
					{
						AnniversaryLoginActivityItem component2 = this.mItemRoot.GetChild(j).GetComponent<AnniversaryLoginActivityItem>();
						if (component2 != null)
						{
							component2.ShowHaveReceivedState();
						}
					}
				}
			}
		}

		// Token: 0x0600F2D1 RID: 62161 RVA: 0x00418FE0 File Offset: 0x004173E0
		public void Close()
		{
			this.mRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnRewardBtnClick));
			this.mRewardBtn = null;
			this.mOnItemClick = null;
			this.mRequestedGiftPackIds.Clear();
			this.mGiftPackItemData.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F2D2 RID: 62162 RVA: 0x0041904E File Offset: 0x0041744E
		public void Show()
		{
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600F2D3 RID: 62163 RVA: 0x0041905C File Offset: 0x0041745C
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F2D4 RID: 62164 RVA: 0x0041906A File Offset: 0x0041746A
		public void Dispose()
		{
		}

		// Token: 0x0600F2D5 RID: 62165 RVA: 0x0041906C File Offset: 0x0041746C
		private void _OnRewardBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("AnniversaryLogin_Content"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("AnniversaryLogin_Cancel"),
				RightButtonText = TR.Value("AnniversaryLogin_OK"),
				OnRightButtonClickCallBack = new Action(this.OnOkBtnClick)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600F2D6 RID: 62166 RVA: 0x004190D0 File Offset: 0x004174D0
		private void OnOkBtnClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
		}

		// Token: 0x0600F2D7 RID: 62167 RVA: 0x004190F4 File Offset: 0x004174F4
		private void _OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (!this.mRequestedGiftPackIds.Contains((int)giftPackSyncInfo.id))
			{
				return;
			}
			if (giftPackSyncInfo != null)
			{
				for (int i = 0; i < giftPackSyncInfo.gifts.Length; i++)
				{
					if (GiftPackDataManager.GetGiftDataFromNet(giftPackSyncInfo.gifts[i]).ItemID > 0 && !this.mGiftPackItemData.Contains(giftPackSyncInfo.gifts[i]))
					{
						this.mGiftPackItemData.Add(giftPackSyncInfo.gifts[i]);
					}
				}
			}
			this.UpdateMyDate(this.mData, true);
		}

		// Token: 0x0600F2D8 RID: 62168 RVA: 0x004191B4 File Offset: 0x004175B4
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x0400953C RID: 38204
		[SerializeField]
		private Button mRewardBtn;

		// Token: 0x0400953D RID: 38205
		[SerializeField]
		private GameObject mHaveRewardGo;

		// Token: 0x0400953E RID: 38206
		[SerializeField]
		private Transform mItemRoot;

		// Token: 0x0400953F RID: 38207
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009540 RID: 38208
		[SerializeField]
		private Text mRuleTxt;

		// Token: 0x04009541 RID: 38209
		private int mId;

		// Token: 0x04009542 RID: 38210
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009543 RID: 38211
		private ILimitTimeActivityModel mData;

		// Token: 0x04009544 RID: 38212
		protected readonly Dictionary<uint, IActivityCommonItem> mItems = new Dictionary<uint, IActivityCommonItem>();

		// Token: 0x04009545 RID: 38213
		private readonly List<int> mRequestedGiftPackIds = new List<int>();

		// Token: 0x04009546 RID: 38214
		private List<AnniversaryLoginActivityItem> itemList = new List<AnniversaryLoginActivityItem>();

		// Token: 0x04009547 RID: 38215
		private List<GiftSyncInfo> mGiftPackItemData = new List<GiftSyncInfo>();

		// Token: 0x04009548 RID: 38216
		private bool mStateIsChanged;
	}
}
