using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F4 RID: 6388
	public class FeedbackGiftActivityNewItem : ActivityItemBase
	{
		// Token: 0x0600F913 RID: 63763 RVA: 0x0043E818 File Offset: 0x0043CC18
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mGoFinishBg.CustomActive(false);
			this.mGoFinishBtn.CustomActive(false);
			this.mGoOver.CustomActive(false);
			if (!this.mIsLeftMinus0)
			{
				OpActTaskState state = data.State;
				if (state != OpActTaskState.OATS_UNFINISH)
				{
					if (state != OpActTaskState.OATS_OVER)
					{
						if (state == OpActTaskState.OATS_FINISHED)
						{
							this.mGoFinishBg.CustomActive(true);
							this.mGoFinishBtn.CustomActive(true);
						}
					}
					else
					{
						this.mGoOver.CustomActive(true);
					}
				}
			}
			else
			{
				this.mGoOver.CustomActive(true);
			}
		}

		// Token: 0x0600F914 RID: 63764 RVA: 0x0043E8BC File Offset: 0x0043CCBC
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			if (this.mData.AwardDataList.Count > 0)
			{
				OpTaskReward opTaskReward = this.mData.AwardDataList[0];
				if (opTaskReward != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					if (itemData != null)
					{
						if (this.mBackground != null)
						{
							ETCImageLoader.LoadSprite(ref this.mBackground, itemData.GetQualityInfo().Background, true);
						}
						if (this.mItemIcon != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
						}
						if (this.mGoItemLimitTime != null)
						{
							int num;
							bool flag;
							itemData.GetTimeLeft(out num, out flag);
							if ((flag && num > 0) || itemData.IsTimeLimit)
							{
								this.mGoItemLimitTime.CustomActive(true);
							}
							else
							{
								this.mGoItemLimitTime.CustomActive(false);
							}
						}
						if (this.mItemBtn != null)
						{
							this.mItemBtn.onClick.RemoveAllListeners();
							this.mItemBtn.onClick.AddListener(delegate()
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
							});
						}
					}
					if (opTaskReward.num > 1U)
					{
						this.mItemCount.SafeSetText(opTaskReward.num.ToString());
					}
					else
					{
						this.mItemCount.SafeSetText(string.Empty);
					}
				}
			}
			this.mNumber.SafeSetText(this.mData.TotalNum.ToString());
			if (this.mFinshBtn != null)
			{
				this.mFinshBtn.onClick.RemoveAllListeners();
				this.mFinshBtn.onClick.AddListener(new UnityAction(this._OnMyItemClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F915 RID: 63765 RVA: 0x0043EADC File Offset: 0x0043CEDC
		public override void Dispose()
		{
			base.Dispose();
			if (this.mItemBtn != null)
			{
				this.mItemBtn.onClick.RemoveAllListeners();
			}
			if (this.mFinshBtn != null)
			{
				this.mFinshBtn.onClick.RemoveListener(new UnityAction(this._OnMyItemClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F916 RID: 63766 RVA: 0x0043EB58 File Offset: 0x0043CF58
		private void _OnMyItemClick()
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

		// Token: 0x0600F917 RID: 63767 RVA: 0x0043EBCC File Offset: 0x0043CFCC
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F918 RID: 63768 RVA: 0x0043EC00 File Offset: 0x0043D000
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
				if (num3 <= 0 && num > 0)
				{
					this.mGoOver.CustomActive(true);
					this.mGoFinishBtn.CustomActive(false);
					this.mGoFinishBg.CustomActive(false);
					this.mIsLeftMinus0 = true;
				}
			}
		}

		// Token: 0x04009AB3 RID: 39603
		[SerializeField]
		private Image mBackground;

		// Token: 0x04009AB4 RID: 39604
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009AB5 RID: 39605
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009AB6 RID: 39606
		[SerializeField]
		private Text mNumber;

		// Token: 0x04009AB7 RID: 39607
		[SerializeField]
		private Button mFinshBtn;

		// Token: 0x04009AB8 RID: 39608
		[SerializeField]
		private Button mItemBtn;

		// Token: 0x04009AB9 RID: 39609
		[SerializeField]
		private GameObject mGoFinishBg;

		// Token: 0x04009ABA RID: 39610
		[SerializeField]
		private GameObject mGoFinishBtn;

		// Token: 0x04009ABB RID: 39611
		[SerializeField]
		private GameObject mGoOver;

		// Token: 0x04009ABC RID: 39612
		[SerializeField]
		private GameObject mGoItemLimitTime;

		// Token: 0x04009ABD RID: 39613
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009ABE RID: 39614
		private bool mIsLeftMinus0;
	}
}
