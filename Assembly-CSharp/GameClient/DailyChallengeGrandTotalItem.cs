using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E5 RID: 6373
	public class DailyChallengeGrandTotalItem : ActivityItemBase
	{
		// Token: 0x0600F8B8 RID: 63672 RVA: 0x0043B788 File Offset: 0x00439B88
		private void Awake()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
			}
		}

		// Token: 0x0600F8B9 RID: 63673 RVA: 0x0043B7C8 File Offset: 0x00439BC8
		private void OnDestroy()
		{
			base.Dispose();
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
			}
			this.mIsLeftMinus0 = false;
			this.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivtiyLimitTimeAccounterNumUpdate));
		}

		// Token: 0x0600F8BA RID: 63674 RVA: 0x0043B824 File Offset: 0x00439C24
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

		// Token: 0x0600F8BB RID: 63675 RVA: 0x0043B954 File Offset: 0x00439D54
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mDataModel = data;
			if (this.mGrandTotalDesc != null)
			{
				this.mGrandTotalDesc.text = TR.Value("limitactivity_dailychallenge_grandtotalDesc", this.mDataModel.DoneNum, this.mDataModel.TotalNum);
			}
			if (this.mDataModel.AwardDataList != null)
			{
				for (int i = 0; i < this.mDataModel.AwardDataList.Count; i++)
				{
					OpTaskReward opTaskReward = this.mDataModel.AwardDataList[i];
					if (opTaskReward != null)
					{
						CommonNewItemDataModel dataModel = new CommonNewItemDataModel
						{
							ItemId = (int)opTaskReward.id,
							ItemCount = (int)opTaskReward.num
						};
						CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.mItemRoot);
						if (commonNewItem != null)
						{
							commonNewItem.InitItem(dataModel);
							commonNewItem.SetItemCountFontSize(26);
							commonNewItem.SetItemLevelFontSize(26);
							(commonNewItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						}
					}
				}
			}
			this.RegisterAccountData(new ClientEventSystem.UIEventHandler(this.OnActivtiyLimitTimeAccounterNumUpdate));
			this.OnRequsetAccountData(this.mDataModel);
		}

		// Token: 0x0600F8BC RID: 63676 RVA: 0x0043BA8C File Offset: 0x00439E8C
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
				}
			}
		}

		// Token: 0x0600F8BD RID: 63677 RVA: 0x0043BB80 File Offset: 0x00439F80
		private void OnReceiveBtnClick()
		{
			this._OnItemClick();
			this.OnRequsetAccountData(this.mDataModel);
		}

		// Token: 0x04009A2A RID: 39466
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009A2B RID: 39467
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009A2C RID: 39468
		[SerializeField]
		private GameObject mGoReceive;

		// Token: 0x04009A2D RID: 39469
		[SerializeField]
		private GameObject mGoHaveToReceive;

		// Token: 0x04009A2E RID: 39470
		[SerializeField]
		private GameObject mGoNotReach;

		// Token: 0x04009A2F RID: 39471
		[SerializeField]
		private Text mGrandTotalDesc;

		// Token: 0x04009A30 RID: 39472
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(70f, 70f);

		// Token: 0x04009A31 RID: 39473
		private ILimitTimeActivityTaskDataModel mDataModel;

		// Token: 0x04009A32 RID: 39474
		private bool mIsLeftMinus0;
	}
}
