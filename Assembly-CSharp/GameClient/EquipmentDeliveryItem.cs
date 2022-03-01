using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018ED RID: 6381
	public class EquipmentDeliveryItem : ActivityItemBase
	{
		// Token: 0x0600F8EF RID: 63727 RVA: 0x0043D3E8 File Offset: 0x0043B7E8
		private void Awake()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this.OnReceviBtnClick));
			}
		}

		// Token: 0x0600F8F0 RID: 63728 RVA: 0x0043D428 File Offset: 0x0043B828
		private void OnDestroy()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceviBtnClick));
			}
			base.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivtiyLimitTimeAccounterNumUpdate));
			this.mIsLeftMinus0 = false;
		}

		// Token: 0x0600F8F1 RID: 63729 RVA: 0x0043D47C File Offset: 0x0043B87C
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
			if (this.mGoNotReach != null)
			{
				this.mGoNotReach.CustomActive(false);
			}
			if (!this.mIsLeftMinus0)
			{
				switch (data.State)
				{
				case OpActTaskState.OATS_INIT:
				case OpActTaskState.OATS_UNFINISH:
					if (this.mGoNotReach != null)
					{
						this.mGoNotReach.CustomActive(true);
					}
					break;
				case OpActTaskState.OATS_FINISHED:
					if (this.mGoReceive != null)
					{
						this.mGoReceive.CustomActive(true);
					}
					break;
				case OpActTaskState.OATS_OVER:
					if (this.mGoHaveToReceive != null)
					{
						this.mGoHaveToReceive.CustomActive(true);
					}
					break;
				}
			}
			else if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(true);
			}
		}

		// Token: 0x0600F8F2 RID: 63730 RVA: 0x0043D5AC File Offset: 0x0043B9AC
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mDataModel = data;
			if (data.AwardDataList != null && data.AwardDataList.Count > 0)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (itemData != null)
				{
					if (this.mName != null)
					{
						this.mName.text = itemData.GetColorName(string.Empty, false);
					}
					if (this.mItemBackground != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
					}
					if (this.mItemIcon != null)
					{
						ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
					}
					if (this.mItemBtn != null)
					{
						this.mItemBtn.onClick.RemoveAllListeners();
						this.mItemBtn.onClick.AddListener(delegate()
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
						});
					}
					if (this.mItemCount != null)
					{
						if (opTaskReward.num > 1U)
						{
							this.mItemCount.CustomActive(true);
							this.mItemCount.text = opTaskReward.num.ToString();
						}
						else
						{
							this.mItemCount.CustomActive(false);
						}
					}
					if (this.mGoLimitTime != null)
					{
						int num;
						bool flag;
						itemData.GetTimeLeft(out num, out flag);
						if ((flag && num > 0) || itemData.IsTimeLimit)
						{
							this.mGoLimitTime.CustomActive(true);
						}
						else
						{
							this.mGoLimitTime.CustomActive(false);
						}
					}
				}
			}
			if (this.mLevelDesc != null)
			{
				this.mLevelDesc.text = string.Format("角色等级：{0}/{1}", DataManager<PlayerBaseData>.GetInstance().Level, data.TotalNum);
			}
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivtiyLimitTimeAccounterNumUpdate));
			base.OnRequsetAccountData(this.mDataModel);
		}

		// Token: 0x0600F8F3 RID: 63731 RVA: 0x0043D7E4 File Offset: 0x0043BBE4
		private void OnActivtiyLimitTimeAccounterNumUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null)
			{
				return;
			}
			if (this.mDataModel != null && this.mDataModel.DataId == (uint)uiEvent.Param1)
			{
				int num = 0;
				int num2 = 0;
				if (this.mDataModel.AccountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mDataModel.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = this.mDataModel.AccountTotalSubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					if (this.mGoReceive != null)
					{
						this.mGoReceive.CustomActive(false);
					}
					if (this.mGoHaveToReceive != null)
					{
						this.mGoHaveToReceive.CustomActive(true);
					}
					if (this.mGoNotReach != null)
					{
						this.mGoNotReach.CustomActive(false);
					}
					this.mIsLeftMinus0 = true;
					num3 = 0;
				}
				if (this.mLimitDesc != null)
				{
					this.mLimitDesc.text = string.Format("账号限领次数：{0}/{1}", num3, num);
				}
			}
		}

		// Token: 0x0600F8F4 RID: 63732 RVA: 0x0043D90A File Offset: 0x0043BD0A
		private void OnReceviBtnClick()
		{
			this._OnItemClick();
			base.OnRequsetAccountData(this.mDataModel);
		}

		// Token: 0x04009A6B RID: 39531
		[SerializeField]
		private Text mName;

		// Token: 0x04009A6C RID: 39532
		[SerializeField]
		private Text mLevelDesc;

		// Token: 0x04009A6D RID: 39533
		[SerializeField]
		private Text mLimitDesc;

		// Token: 0x04009A6E RID: 39534
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009A6F RID: 39535
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009A70 RID: 39536
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009A71 RID: 39537
		[SerializeField]
		private Button mItemBtn;

		// Token: 0x04009A72 RID: 39538
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009A73 RID: 39539
		[SerializeField]
		private GameObject mGoReceive;

		// Token: 0x04009A74 RID: 39540
		[SerializeField]
		private GameObject mGoHaveToReceive;

		// Token: 0x04009A75 RID: 39541
		[SerializeField]
		private GameObject mGoNotReach;

		// Token: 0x04009A76 RID: 39542
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x04009A77 RID: 39543
		private ILimitTimeActivityTaskDataModel mDataModel;

		// Token: 0x04009A78 RID: 39544
		private bool mIsLeftMinus0;
	}
}
