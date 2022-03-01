using System;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E4 RID: 6372
	public class ConsumeRebateItem : ActivityItemBase
	{
		// Token: 0x0600F8B0 RID: 63664 RVA: 0x0043B360 File Offset: 0x00439760
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mTaskDes.SafeSetText(string.Format(TR.Value("TaskDes_Content"), data.Desc, ":"));
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					this._CreateItem(data.AwardDataList[i]);
				}
			}
			this.mData = data;
			this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			this.ShowHaveUsedNumState(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F8B1 RID: 63665 RVA: 0x0043B40C File Offset: 0x0043980C
		private void _OnMyItemClick()
		{
			int num = 0;
			int.TryParse(TR.Value("ConsumeRebateLimitPlayerGrade"), out num);
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= num)
			{
				this._OnItemClick();
				if (this.mData != null)
				{
					if (this.mData.AccountDailySubmitLimit > 0)
					{
						DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					}
					if (this.mData.AccountTotalSubmitLimit > 0)
					{
						DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					}
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("活动等级不匹配，需要等级{0},当前等级{1}", num, DataManager<PlayerBaseData>.GetInstance().Level), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600F8B2 RID: 63666 RVA: 0x0043B4D0 File Offset: 0x004398D0
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				switch (data.State)
				{
				case OpActTaskState.OATS_INIT:
				case OpActTaskState.OATS_UNFINISH:
					this.mUnFinishGo.CustomActive(true);
					this.mReceiveBtn.CustomActive(false);
					this.mHaveReceiveGo.CustomActive(false);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					this.mUnFinishGo.CustomActive(false);
					this.mHaveReceiveGo.CustomActive(false);
					break;
				case OpActTaskState.OATS_OVER:
					this.mHaveReceiveGo.CustomActive(true);
					this.mUnFinishGo.CustomActive(false);
					this.mReceiveBtn.CustomActive(false);
					break;
				}
			}
			else
			{
				this.mHaveReceiveGo.CustomActive(true);
				this.mUnFinishGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
			}
		}

		// Token: 0x0600F8B3 RID: 63667 RVA: 0x0043B5B6 File Offset: 0x004399B6
		public override void Dispose()
		{
			base.Dispose();
			this.mReceiveBtn.SafeRemoveOnClickListener(new UnityAction(this._OnMyItemClick));
		}

		// Token: 0x0600F8B4 RID: 63668 RVA: 0x0043B5D8 File Offset: 0x004399D8
		private void _CreateItem(OpTaskReward opTaskReward)
		{
			if (opTaskReward != null)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (comItem != null && itemData != null)
				{
					comItem.GetComponent<RectTransform>().sizeDelta = this.mComItemSize;
					itemData.Count = (int)opTaskReward.num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (ConsumeRebateItem.<>f__mg$cache0 == null)
					{
						ConsumeRebateItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, ConsumeRebateItem.<>f__mg$cache0);
				}
			}
		}

		// Token: 0x0600F8B5 RID: 63669 RVA: 0x0043B659 File Offset: 0x00439A59
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F8B6 RID: 63670 RVA: 0x0043B690 File Offset: 0x00439A90
		private void ShowHaveUsedNumState(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				int num = 0;
				int num2 = 0;
				if (data.AccountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = data.AccountDailySubmitLimit;
				}
				else if (data.AccountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = data.AccountTotalSubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0)
				{
					this.mHaveReceiveGo.CustomActive(true);
					this.mUnFinishGo.CustomActive(false);
					this.mReceiveBtn.CustomActive(false);
					this.mIsLeftMinus0 = true;
					num3 = 0;
				}
				this.mAccountLimitTxt.CustomActive(num > 0);
				this.mAccountLimitTxt.SafeSetText(string.Format(TR.Value("ConsumeRebate_AccountLimt_Content"), num3, num));
			}
		}

		// Token: 0x04009A20 RID: 39456
		[SerializeField]
		private Text mTaskDes;

		// Token: 0x04009A21 RID: 39457
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009A22 RID: 39458
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009A23 RID: 39459
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009A24 RID: 39460
		[SerializeField]
		private GameObject mUnFinishGo;

		// Token: 0x04009A25 RID: 39461
		[SerializeField]
		private GameObject mHaveReceiveGo;

		// Token: 0x04009A26 RID: 39462
		[SerializeField]
		private Text mAccountLimitTxt;

		// Token: 0x04009A27 RID: 39463
		private bool mIsLeftMinus0;

		// Token: 0x04009A28 RID: 39464
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009A29 RID: 39465
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
