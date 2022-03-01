using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200189A RID: 6298
	public class LanternFestivalWorkView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F655 RID: 63061 RVA: 0x00428014 File Offset: 0x00426414
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
					if (this.mRequestedGiftPackIds == null)
					{
						this.mRequestedGiftPackIds = new List<int>();
					}
					if (!this.mRequestedGiftPackIds.Contains(id))
					{
						this.mRequestedGiftPackIds.Add(id);
					}
					DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(id);
				}
			}
		}

		// Token: 0x0600F656 RID: 63062 RVA: 0x00428179 File Offset: 0x00426579
		public void UpdateData(ILimitTimeActivityModel data)
		{
			this.UpdateMyDate(data, false);
		}

		// Token: 0x0600F657 RID: 63063 RVA: 0x00428184 File Offset: 0x00426584
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
					if (this.mGiftPackItemData == null)
					{
						this.mGiftPackItemData = new List<GiftSyncInfo>();
					}
					if (this.mItemRootList.Count == this.mGiftPackItemData.Count)
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
							gameObject.transform.SetParent(this.mItemRootList[i], false);
							gameObject.transform.localPosition = Vector3.zero;
							gameObject.transform.localScale = Vector3.one;
						}
					}
					else
					{
						Logger.LogErrorFormat(string.Format("Item位置的数量和服务器下发的item数量不一致 ,位置数量{0},item数量{1}", this.mItemRootList.Count, this.mGiftPackItemData.Count), new object[0]);
					}
				}
				else if (flag)
				{
					for (int j = 0; j < this.mItemRootList.Count; j++)
					{
						AnniversaryLoginActivityItem component2 = this.mItemRootList[j].GetComponent<AnniversaryLoginActivityItem>();
						if (component2 != null)
						{
							component2.ShowHaveReceivedState();
						}
					}
				}
			}
		}

		// Token: 0x0600F658 RID: 63064 RVA: 0x0042835C File Offset: 0x0042675C
		public void Close()
		{
			this.mRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnRewardBtnClick));
			if (this.mRewardBtn != null)
			{
				this.mRewardBtn = null;
			}
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick = null;
			}
			if (this.mRequestedGiftPackIds != null)
			{
				this.mRequestedGiftPackIds.Clear();
			}
			if (this.mGiftPackItemData != null)
			{
				this.mGiftPackItemData.Clear();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			if (base.gameObject != null)
			{
				Object.Destroy(base.gameObject);
			}
		}

		// Token: 0x0600F659 RID: 63065 RVA: 0x0042840D File Offset: 0x0042680D
		public void Show()
		{
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600F65A RID: 63066 RVA: 0x0042841B File Offset: 0x0042681B
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F65B RID: 63067 RVA: 0x00428429 File Offset: 0x00426829
		public void Dispose()
		{
		}

		// Token: 0x0600F65C RID: 63068 RVA: 0x0042842C File Offset: 0x0042682C
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

		// Token: 0x0600F65D RID: 63069 RVA: 0x00428490 File Offset: 0x00426890
		private void OnOkBtnClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
		}

		// Token: 0x0600F65E RID: 63070 RVA: 0x004284B4 File Offset: 0x004268B4
		private void _OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (this.mRequestedGiftPackIds == null)
			{
				this.mRequestedGiftPackIds = new List<int>();
			}
			if (!this.mRequestedGiftPackIds.Contains((int)giftPackSyncInfo.id))
			{
				return;
			}
			if (giftPackSyncInfo != null)
			{
				if (this.mGiftPackItemData == null)
				{
					this.mGiftPackItemData = new List<GiftSyncInfo>();
				}
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

		// Token: 0x0600F65F RID: 63071 RVA: 0x004285A0 File Offset: 0x004269A0
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x04009726 RID: 38694
		public Button mRewardBtn;

		// Token: 0x04009727 RID: 38695
		public GameObject mHaveRewardGo;

		// Token: 0x04009728 RID: 38696
		public List<Transform> mItemRootList;

		// Token: 0x04009729 RID: 38697
		public Text mTimeTxt;

		// Token: 0x0400972A RID: 38698
		public Text mRuleTxt;

		// Token: 0x0400972B RID: 38699
		private int mId;

		// Token: 0x0400972C RID: 38700
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x0400972D RID: 38701
		private ILimitTimeActivityModel mData;

		// Token: 0x0400972E RID: 38702
		private List<int> mRequestedGiftPackIds;

		// Token: 0x0400972F RID: 38703
		private List<GiftSyncInfo> mGiftPackItemData;
	}
}
