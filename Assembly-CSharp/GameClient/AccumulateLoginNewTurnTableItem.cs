using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001803 RID: 6147
	public class AccumulateLoginNewTurnTableItem : ActivityItemBase
	{
		// Token: 0x0600F254 RID: 62036 RVA: 0x004159AC File Offset: 0x00413DAC
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

		// Token: 0x0600F255 RID: 62037 RVA: 0x00415A74 File Offset: 0x00413E74
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this._OnMyItemClick));
			}
			this.InitItem();
			this.mData = data;
			this.UpdateLoginDesc();
			NetProcess.AddMsgHandler(501007U, new Action<MsgDATA>(this.OnSceneDrawPrizeRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F256 RID: 62038 RVA: 0x00415B0C File Offset: 0x00413F0C
		private void InitItem()
		{
			if (this.rewardPoolTableList == null)
			{
				this.rewardPoolTableList = new List<RewardPoolTable>();
			}
			this.rewardPoolTableList.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<RewardPoolTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				RewardPoolTable rewardPoolTable = keyValuePair.Value as RewardPoolTable;
				if (rewardPoolTable.DrawPrizeTableID == this.iTableId)
				{
					this.rewardPoolTableList.Add(rewardPoolTable);
				}
			}
			for (int i = 0; i < this.rewardPoolTableList.Count; i++)
			{
				RewardPoolTable rewardPoolTable2 = this.rewardPoolTableList[i];
				if (rewardPoolTable2 != null)
				{
					if (i <= this.mPositionList.Count)
					{
						GameObject parent = this.mPositionList[i];
						CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(parent);
						if (commonNewItem != null)
						{
							commonNewItem.InitItem(rewardPoolTable2.ItemID, rewardPoolTable2.ItemNum);
						}
					}
				}
			}
		}

		// Token: 0x0600F257 RID: 62039 RVA: 0x00415C18 File Offset: 0x00414018
		private void UpdateLoginDesc()
		{
			if (this.mDayDesc != null)
			{
				this.mDayDesc.text = string.Format(this.sDesc, this.mData.DoneNum, this.mData.TotalNum);
			}
		}

		// Token: 0x0600F258 RID: 62040 RVA: 0x00415C6C File Offset: 0x0041406C
		private void _OnMyItemClick()
		{
			this._OnItemClick();
			this.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F259 RID: 62041 RVA: 0x00415C80 File Offset: 0x00414080
		private void OnSceneDrawPrizeRes(MsgDATA msg)
		{
			SceneDrawPrizeRes sceneDrawPrizeRes = new SceneDrawPrizeRes();
			sceneDrawPrizeRes.decode(msg.bytes);
			if (sceneDrawPrizeRes.retCode == 0U)
			{
				int num = -1;
				RewardPoolTable rewardPoolTable = null;
				for (int i = 0; i < this.rewardPoolTableList.Count; i++)
				{
					RewardPoolTable rewardPoolTable2 = this.rewardPoolTableList[i];
					if ((long)rewardPoolTable2.ID == (long)((ulong)sceneDrawPrizeRes.rewardId))
					{
						rewardPoolTable = rewardPoolTable2;
						num = i;
						break;
					}
				}
				if (num != -1 && this.mLuckyRoller != null)
				{
					this.mLuckyRoller.RotateUp(this.iRewardAllCount, this.iRewardAllCount - num, true, delegate
					{
						if (rewardPoolTable != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(rewardPoolTable.ItemID, 100, 0);
							if (itemData != null)
							{
								itemData.Count = rewardPoolTable.ItemNum;
							}
							SystemNotifyManager.SysNotifyGetNewItemEffect(itemData, false, string.Empty);
						}
					});
				}
			}
		}

		// Token: 0x0600F25A RID: 62042 RVA: 0x00415D49 File Offset: 0x00414149
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F25B RID: 62043 RVA: 0x00415D80 File Offset: 0x00414180
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

		// Token: 0x0600F25C RID: 62044 RVA: 0x00415E30 File Offset: 0x00414230
		public sealed override void Dispose()
		{
			if (this.rewardPoolTableList != null)
			{
				this.rewardPoolTableList.Clear();
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this._OnMyItemClick));
			}
			this.mIsLeftMinus0 = false;
			NetProcess.RemoveMsgHandler(501007U, new Action<MsgDATA>(this.OnSceneDrawPrizeRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x040094DF RID: 38111
		[SerializeField]
		private List<GameObject> mPositionList = new List<GameObject>();

		// Token: 0x040094E0 RID: 38112
		[SerializeField]
		private Text mDayDesc;

		// Token: 0x040094E1 RID: 38113
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x040094E2 RID: 38114
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x040094E3 RID: 38115
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x040094E4 RID: 38116
		[SerializeField]
		private TheLuckyRoller mLuckyRoller;

		// Token: 0x040094E5 RID: 38117
		[SerializeField]
		private string sDesc = "累计{0}/{1}天";

		// Token: 0x040094E6 RID: 38118
		[SerializeField]
		private int iTableId = 10007;

		// Token: 0x040094E7 RID: 38119
		[SerializeField]
		private int iRewardAllCount = 8;

		// Token: 0x040094E8 RID: 38120
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x040094E9 RID: 38121
		private bool mIsLeftMinus0;

		// Token: 0x040094EA RID: 38122
		private List<RewardPoolTable> rewardPoolTableList = new List<RewardPoolTable>();
	}
}
