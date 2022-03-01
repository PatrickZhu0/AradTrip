using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018EB RID: 6379
	public class DailyRewardItem : ActivityItemBase
	{
		// Token: 0x0600F8DF RID: 63711 RVA: 0x0043CC78 File Offset: 0x0043B078
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				Logger.LogError("data is null");
				return;
			}
			this.mData = data;
			this.mTextDescription.text = data.Desc;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftPackInfoResp));
			if (this.mButtonTakeReward == null)
			{
				Logger.LogError("按钮为空了，检查预制体DailyRewardItem");
			}
			this.mAccountNumTxt.CustomActive(false);
			this.UpdateData(data);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this._InitItems(data.AwardDataList);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnSendMsg));
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			base.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F8E0 RID: 63712 RVA: 0x0043CD50 File Offset: 0x0043B150
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data.State != OpActTaskState.OATS_FINISHED)
			{
				if (this.mButtonTakeReward != null)
				{
					this.mButtonTakeReward.gameObject.CustomActive(false);
				}
				this.mHasTakenReward.CustomActive(true);
			}
			else
			{
				if (this.mButtonTakeReward != null)
				{
					this.mButtonTakeReward.gameObject.CustomActive(true);
				}
				this.mHasTakenReward.CustomActive(false);
			}
		}

		// Token: 0x0600F8E1 RID: 63713 RVA: 0x0043CDCC File Offset: 0x0043B1CC
		public override void Dispose()
		{
			base.Dispose();
			this.mGiftDataList.Clear();
			for (int i = this.mComItems.Count - 1; i >= 0; i--)
			{
				ComItemManager.Destroy(this.mComItems[i]);
			}
			this.mComItems.Clear();
			this.mGiftId = 0U;
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnSendMsg));
			this.mOnItemClick = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftPackInfoResp));
			base.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F8E2 RID: 63714 RVA: 0x0043CE90 File Offset: 0x0043B290
		private void _OnGetGiftPackInfoResp(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (giftPackSyncInfo.id == this.mGiftId)
			{
				this.mGiftDataList.Clear();
				this._InitAwardItemDetails(giftPackSyncInfo.gifts);
			}
		}

		// Token: 0x0600F8E3 RID: 63715 RVA: 0x0043CEF0 File Offset: 0x0043B2F0
		private void _InitItems(List<OpTaskReward> awards)
		{
			if (awards == null || awards.Count == 0)
			{
				return;
			}
			for (int i = 0; i < awards.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)awards[i].id, 100, 0);
					itemData.Count = (int)awards[i].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (DailyRewardItem.<>f__mg$cache0 == null)
					{
						DailyRewardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, DailyRewardItem.<>f__mg$cache0);
					this.mComItems.Add(comItem);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
				}
			}
			this.mGiftId = awards[0].id;
			DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem((int)awards[0].id);
		}

		// Token: 0x0600F8E4 RID: 63716 RVA: 0x0043CFD8 File Offset: 0x0043B3D8
		private void _OnItemVisible(ComUIListElementScript item)
		{
			IDailyRewardGiftItem component = item.GetComponent<IDailyRewardGiftItem>();
			if (component == null)
			{
				Logger.LogError("在预制体上找不到组件: IDailyRewardGiftItem");
				return;
			}
			if (item.m_index < this.mGiftDataList.Count && item.m_index >= 0)
			{
				component.Init(this.mGiftDataList[item.m_index]);
			}
		}

		// Token: 0x0600F8E5 RID: 63717 RVA: 0x0043D038 File Offset: 0x0043B438
		private void _InitAwardItemDetails(GiftSyncInfo[] gifts)
		{
			if (gifts == null || gifts.Length == 0)
			{
				return;
			}
			this.mRewardDetailListScript.InitialLizeWithExternalElement(this.mGiftPrefabPath);
			this.mRewardDetailListScript.onItemVisiable = new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisible);
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			int index = 0;
			int num = -1;
			int num2 = -1;
			for (int i = 0; i < gifts.Length; i++)
			{
				int num3 = Mathf.Min((int)gifts[i].validLevels[0], (int)gifts[i].validLevels[1]);
				int num4 = Mathf.Max((int)gifts[i].validLevels[0], (int)gifts[i].validLevels[1]);
				if (num2 < num3)
				{
					num2 = num3;
					num++;
					this.mGiftDataList.Add(new List<DailyRewardDetailData>());
				}
				this.mGiftDataList[num].Add(new DailyRewardDetailData(gifts[i]));
				if (level >= num3 && level <= num4)
				{
					index = num;
				}
			}
			this.mRewardDetailListScript.SetElementAmount(num + 1);
			this.mRewardDetailListScript.MoveElementInScrollArea(index, true);
		}

		// Token: 0x0600F8E6 RID: 63718 RVA: 0x0043D145 File Offset: 0x0043B545
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState();
			}
		}

		// Token: 0x0600F8E7 RID: 63719 RVA: 0x0043D173 File Offset: 0x0043B573
		private void _OnSendMsg()
		{
			if (this.mData != null)
			{
				base.OnRequsetAccountData(this.mData);
			}
		}

		// Token: 0x0600F8E8 RID: 63720 RVA: 0x0043D18C File Offset: 0x0043B58C
		private void ShowHaveUsedNumState()
		{
			if (this.mData != null)
			{
				int accountDailySubmitLimit = this.mData.AccountDailySubmitLimit;
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				if (accountDailySubmitLimit > 0)
				{
					num = accountDailySubmitLimit;
				}
				if (accountTotalSubmitLimit > 0)
				{
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					int num2 = num - activityConunter;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (this.mAccountNumTxt != null)
					{
						this.mAccountNumTxt.CustomActive(true);
						this.mAccountNumTxt.text = string.Format(TR.Value("limitactivity_dailyreward_tip", num2, num), new object[0]);
					}
					if (num2 <= 0)
					{
						this.mButtonTakeReward.CustomActive(false);
						this.mHasTakenReward.CustomActive(true);
					}
				}
				else
				{
					this.mAccountNumTxt.CustomActive(false);
				}
			}
		}

		// Token: 0x04009A57 RID: 39511
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A58 RID: 39512
		[SerializeField]
		private Image mImageBg;

		// Token: 0x04009A59 RID: 39513
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009A5A RID: 39514
		[SerializeField]
		private RectTransform mRewardDetailRoot;

		// Token: 0x04009A5B RID: 39515
		[SerializeField]
		private ComUIListScript mRewardDetailListScript;

		// Token: 0x04009A5C RID: 39516
		[SerializeField]
		private string mGiftPrefabPath;

		// Token: 0x04009A5D RID: 39517
		[SerializeField]
		private Vector2 mComItemSize;

		// Token: 0x04009A5E RID: 39518
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009A5F RID: 39519
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009A60 RID: 39520
		[SerializeField]
		private Text mAccountNumTxt;

		// Token: 0x04009A61 RID: 39521
		private uint mGiftId;

		// Token: 0x04009A62 RID: 39522
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009A63 RID: 39523
		private List<List<DailyRewardDetailData>> mGiftDataList = new List<List<DailyRewardDetailData>>();

		// Token: 0x04009A64 RID: 39524
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009A65 RID: 39525
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
