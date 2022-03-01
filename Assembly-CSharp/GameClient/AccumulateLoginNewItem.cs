using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001802 RID: 6146
	public class AccumulateLoginNewItem : ActivityItemBase
	{
		// Token: 0x0600F24C RID: 62028 RVA: 0x00415504 File Offset: 0x00413904
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList.Count == 1)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				if (opTaskReward != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					if (itemData != null)
					{
						itemData.Count = (int)opTaskReward.num;
						if (this.mItemBackground != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
						}
						if (this.mItemIcon != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
						}
						if (opTaskReward.num > 1U)
						{
							if (this.mItemCount != null)
							{
								this.mItemCount.text = opTaskReward.num.ToString();
							}
						}
						else if (this.mItemCount != null)
						{
							this.mItemCount.text = string.Empty;
						}
						if (this.mItemIconBtn != null)
						{
							this.mItemIconBtn.SafeRemoveAllListener();
							this.mItemIconBtn.SafeAddOnClickListener(delegate
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
							});
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
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this._OnMyItemClick));
			}
			this.mData = data;
			this.UpdateLoginDesc();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F24D RID: 62029 RVA: 0x0041571C File Offset: 0x00413B1C
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mReceiveGrayItemGo.CustomActive(false);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mNotReachItemGo.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mReceiveGrayItemGo.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mReceiveGrayItemGo.CustomActive(true);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
			}
		}

		// Token: 0x0600F24E RID: 62030 RVA: 0x004157E4 File Offset: 0x00413BE4
		private void UpdateLoginDesc()
		{
			if (this.mDayDesc != null)
			{
				this.mDayDesc.text = string.Format(this.sDesc, this.mData.DoneNum, this.mData.TotalNum);
			}
		}

		// Token: 0x0600F24F RID: 62031 RVA: 0x00415838 File Offset: 0x00413C38
		private void _OnMyItemClick()
		{
			this._OnItemClick();
			this.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F250 RID: 62032 RVA: 0x0041584C File Offset: 0x00413C4C
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F251 RID: 62033 RVA: 0x00415880 File Offset: 0x00413C80
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
					this.mReceiveGrayItemGo.CustomActive(true);
					this.mNotReachItemGo.CustomActive(false);
					this.mReceiveBtn.CustomActive(false);
					this.mIsLeftMinus0 = true;
				}
			}
		}

		// Token: 0x0600F252 RID: 62034 RVA: 0x0041592D File Offset: 0x00413D2D
		public sealed override void Dispose()
		{
			this.mIsLeftMinus0 = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x040094D3 RID: 38099
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x040094D4 RID: 38100
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x040094D5 RID: 38101
		[SerializeField]
		private Text mItemCount;

		// Token: 0x040094D6 RID: 38102
		[SerializeField]
		private Text mDayDesc;

		// Token: 0x040094D7 RID: 38103
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x040094D8 RID: 38104
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x040094D9 RID: 38105
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x040094DA RID: 38106
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x040094DB RID: 38107
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x040094DC RID: 38108
		[SerializeField]
		private string sDesc = "累计{0}/{1}天";

		// Token: 0x040094DD RID: 38109
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x040094DE RID: 38110
		private bool mIsLeftMinus0;
	}
}
