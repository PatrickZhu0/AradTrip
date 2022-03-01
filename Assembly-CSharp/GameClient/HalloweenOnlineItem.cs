using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F6 RID: 6390
	public class HalloweenOnlineItem : ActivityItemBase
	{
		// Token: 0x0600F91C RID: 63772 RVA: 0x0043ED7C File Offset: 0x0043D17C
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
			case OpActTaskState.OATS_UNFINISH:
				this.mNotFinishedGo.CustomActive(true);
				this.mHasTakenGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
				break;
			case OpActTaskState.OATS_FINISHED:
				this.mNotFinishedGo.CustomActive(false);
				this.mHasTakenGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(true);
				break;
			case OpActTaskState.OATS_OVER:
				this.mNotFinishedGo.CustomActive(false);
				this.mHasTakenGo.CustomActive(true);
				this.mReceiveBtn.CustomActive(false);
				break;
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mTextProgress.SafeSetText(string.Format("{0}/{1}", data.DoneNum, data.TotalNum));
		}

		// Token: 0x0600F91D RID: 63773 RVA: 0x0043EE7C File Offset: 0x0043D27C
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mData = data;
			this.mPetPreviewBtn.CustomActive(false);
			if (data != null && data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mContent.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (HalloweenOnlineItem.<>f__mg$cache0 == null)
						{
							HalloweenOnlineItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, HalloweenOnlineItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
				if (data.AwardDataList.Count > 0)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[0].id, 100, 0);
					if (itemData2 != null)
					{
						this.mPetPreviewBtn.CustomActive(itemData2.SubType == 44);
					}
				}
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this._OnItemClick));
			}
			if (this.mPetPreviewBtn != null)
			{
				this.mPetPreviewBtn.onClick.RemoveAllListeners();
				this.mPetPreviewBtn.onClick.AddListener(new UnityAction(this.OnPetPreviewBtnClick));
			}
		}

		// Token: 0x0600F91E RID: 63774 RVA: 0x0043F03C File Offset: 0x0043D43C
		public sealed override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F91F RID: 63775 RVA: 0x0043F094 File Offset: 0x0043D494
		private void OnPetPreviewBtnClick()
		{
			if (this.mData.AwardDataList.Count > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.mData.AwardDataList[0].id, 100, 0);
				if (itemData != null)
				{
					PreViewItemData preViewItemData = new PreViewItemData();
					preViewItemData.itemId = itemData.TableID;
					PreViewDataModel preViewDataModel = new PreViewDataModel();
					preViewDataModel.preViewItemList.Add(preViewItemData);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
				}
			}
		}

		// Token: 0x04009AC2 RID: 39618
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009AC3 RID: 39619
		[SerializeField]
		private Button mPetPreviewBtn;

		// Token: 0x04009AC4 RID: 39620
		[SerializeField]
		private GameObject mHasTakenGo;

		// Token: 0x04009AC5 RID: 39621
		[SerializeField]
		private GameObject mNotFinishedGo;

		// Token: 0x04009AC6 RID: 39622
		[SerializeField]
		private GameObject mContent;

		// Token: 0x04009AC7 RID: 39623
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009AC8 RID: 39624
		[SerializeField]
		private Text mTextProgress;

		// Token: 0x04009AC9 RID: 39625
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009ACA RID: 39626
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009ACB RID: 39627
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009ACC RID: 39628
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009ACD RID: 39629
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009ACE RID: 39630
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
