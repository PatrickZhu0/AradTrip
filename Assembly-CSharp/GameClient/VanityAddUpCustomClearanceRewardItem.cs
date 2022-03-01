using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001920 RID: 6432
	public class VanityAddUpCustomClearanceRewardItem : ActivityItemBase
	{
		// Token: 0x0600FA66 RID: 64102 RVA: 0x0044902C File Offset: 0x0044742C
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (this.isLeftMinusThan0)
			{
				if (data.State == OpActTaskState.OATS_UNFINISH || data.State == OpActTaskState.OATS_INIT)
				{
					this.mGoButton.CustomActive(true);
					this.mButtonTakeReward.CustomActive(false);
					this.mHasTakenReward.CustomActive(false);
				}
				else if (data.State == OpActTaskState.OATS_FINISHED)
				{
					this.mGoButton.CustomActive(false);
					this.mButtonTakeReward.CustomActive(true);
					this.mHasTakenReward.CustomActive(false);
				}
				else if (data.State == OpActTaskState.OATS_OVER)
				{
					this.mGoButton.CustomActive(false);
					this.mButtonTakeReward.CustomActive(false);
					this.mHasTakenReward.CustomActive(true);
				}
			}
			else
			{
				this.mGoButton.CustomActive(false);
				this.mButtonTakeReward.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
		}

		// Token: 0x0600FA67 RID: 64103 RVA: 0x00449114 File Offset: 0x00447514
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mTaskData = data;
			if (data.AwardDataList.Count <= 0)
			{
				Logger.LogError("data.AwardDataList 数组数量为0");
				return;
			}
			for (int i = 0; i < data.AwardDataList.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
					itemData.Count = (int)data.AwardDataList[i].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (VanityAddUpCustomClearanceRewardItem.<>f__mg$cache0 == null)
					{
						VanityAddUpCustomClearanceRewardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, VanityAddUpCustomClearanceRewardItem.<>f__mg$cache0);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					this.mComItems.Add(comItem);
				}
			}
			if (this.mTextDescription != null)
			{
				this.mTextDescription.SafeSetText(data.Desc);
			}
			if (this.mTatleNum != null)
			{
				this.mTatleNum.SafeSetText(data.TotalNum.ToString());
			}
			if (this.mOwnNum != null)
			{
				this.mOwnNum.SafeSetText(data.DoneNum.ToString());
			}
			if (this.mGoButton != null)
			{
				this.mGoButton.SafeAddOnClickListener(new UnityAction(this.OnGoBtnClick));
			}
			if (this.mButtonTakeReward != null)
			{
				this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
				this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnSendMsg));
			}
			if (data.AccountTotalSubmitLimit > 0)
			{
				this.mAccountNumGo.CustomActive(true);
			}
			else
			{
				this.mAccountNumGo.CustomActive(false);
			}
			this.mData = data;
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			base.OnRequsetAccountData(data);
		}

		// Token: 0x0600FA68 RID: 64104 RVA: 0x00449328 File Offset: 0x00447728
		public sealed override void Dispose()
		{
			base.Dispose();
			for (int i = this.mComItems.Count - 1; i >= 0; i--)
			{
				ComItemManager.Destroy(this.mComItems[i]);
			}
			this.mComItems.Clear();
			if (this.mButtonTakeReward != null)
			{
				this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
				this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnSendMsg));
			}
			if (this.mGoButton != null)
			{
				this.mGoButton.SafeRemoveOnClickListener(new UnityAction(this.OnGoBtnClick));
			}
			base.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.mTaskData = null;
		}

		// Token: 0x0600FA69 RID: 64105 RVA: 0x004493F8 File Offset: 0x004477F8
		private void OnGoBtnClick()
		{
			if (this.mTaskData != null)
			{
				if (this.mTaskData.ParamNums2.Count == 1)
				{
					if (this.mTaskData.ParamNums2[0] == 17U)
					{
						Utility.PathfindingYiJieMap();
					}
				}
				else if (this.mTaskData.ParamNums2.Count == 3 && this.mTaskData.ParamNums2[0] == 20U && this.mTaskData.ParamNums2[1] == 22U && this.mTaskData.ParamNums2[2] == 23U)
				{
					ChallengeUtility.OnOpenChallengeMapFrame(DungeonModelTable.eType.WeekHellModel, 0, 0);
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
					}
				}
			}
		}

		// Token: 0x0600FA6A RID: 64106 RVA: 0x004494CA File Offset: 0x004478CA
		private void _OnSendMsg()
		{
			if (this.mData != null)
			{
				base.OnRequsetAccountData(this.mData);
			}
		}

		// Token: 0x0600FA6B RID: 64107 RVA: 0x004494E4 File Offset: 0x004478E4
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				int accountDailySubmitLimit = this.mData.AccountDailySubmitLimit;
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				int num2 = 0;
				if (accountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = accountDailySubmitLimit;
				}
				if (accountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int num3 = num - num2;
					if (num3 <= 0)
					{
						this.isLeftMinusThan0 = false;
						this.mGoButton.CustomActive(false);
						this.mButtonTakeReward.CustomActive(false);
						this.mHasTakenReward.CustomActive(true);
						this.mProgressGo.CustomActive(false);
						this.mAccountNumGo.GetComponent<RectTransform>().anchoredPosition = this.mAccountGoPos;
						num3 = 0;
					}
					this.mCanNumTxt.SafeSetText(num3.ToString());
					this.mTotalNumTxt.SafeSetText(num.ToString());
				}
			}
		}

		// Token: 0x04009C58 RID: 40024
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009C59 RID: 40025
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009C5A RID: 40026
		[SerializeField]
		private Button mGoButton;

		// Token: 0x04009C5B RID: 40027
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009C5C RID: 40028
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009C5D RID: 40029
		[SerializeField]
		private Vector2 mComItemSize = default(Vector2);

		// Token: 0x04009C5E RID: 40030
		[SerializeField]
		private Text mOwnNum;

		// Token: 0x04009C5F RID: 40031
		[SerializeField]
		private Text mTatleNum;

		// Token: 0x04009C60 RID: 40032
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009C61 RID: 40033
		private ILimitTimeActivityTaskDataModel mTaskData;

		// Token: 0x04009C62 RID: 40034
		[SerializeField]
		private GameObject mProgressGo;

		// Token: 0x04009C63 RID: 40035
		[SerializeField]
		private GameObject mAccountNumGo;

		// Token: 0x04009C64 RID: 40036
		[SerializeField]
		private Text mCanNumTxt;

		// Token: 0x04009C65 RID: 40037
		[SerializeField]
		private Text mTotalNumTxt;

		// Token: 0x04009C66 RID: 40038
		[SerializeField]
		private Vector2 mAccountGoPos = default(Vector2);

		// Token: 0x04009C67 RID: 40039
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009C68 RID: 40040
		private bool isLeftMinusThan0 = true;

		// Token: 0x04009C69 RID: 40041
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
