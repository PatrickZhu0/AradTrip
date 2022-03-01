using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014B8 RID: 5304
	public class ChallengeChapterEntryControl : MonoBehaviour
	{
		// Token: 0x0600CDA5 RID: 52645 RVA: 0x00329DCE File Offset: 0x003281CE
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CDA6 RID: 52646 RVA: 0x00329DD6 File Offset: 0x003281D6
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CDA7 RID: 52647 RVA: 0x00329DE4 File Offset: 0x003281E4
		private void BindEvents()
		{
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
				this.teamButton.onClick.AddListener(new UnityAction(this.OnTeamButtonClick));
			}
			if (this.startButton != null)
			{
				this.startButton.onClick.RemoveAllListeners();
				this.startButton.onClick.AddListener(new UnityAction(this.OnStartBtnClick));
			}
		}

		// Token: 0x0600CDA8 RID: 52648 RVA: 0x00329E6C File Offset: 0x0032826C
		private void UnBindEvents()
		{
			if (this.startButton != null)
			{
				this.startButton.onClick.RemoveAllListeners();
			}
			if (this.teamButton != null)
			{
				this.teamButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CDA9 RID: 52649 RVA: 0x00329EBB File Offset: 0x003282BB
		private void ClearData()
		{
			this._dungeonId = 0;
			this._dungeonTable = null;
			this._mDungeonID = null;
			this.mOnStartButtonClick = null;
		}

		// Token: 0x0600CDAA RID: 52650 RVA: 0x00329EDC File Offset: 0x003282DC
		public void UpdateEntryControl(int dungeonId, DungeonTable dungeonTable, int baseDungeonId = 0, UnityAction OnStartClick = null)
		{
			this._dungeonId = dungeonId;
			this._dungeonTable = dungeonTable;
			this._baseDungeonId = baseDungeonId;
			this.mOnStartButtonClick = OnStartClick;
			if (this._dungeonTable == null)
			{
				Logger.LogErrorFormat("ChallengeChapterEntryControl and dungeonTable is null dungeonId is {0}", new object[]
				{
					this._dungeonId
				});
				return;
			}
			this._mDungeonID = new DungeonID(this._dungeonId);
			if (this.commonHelpNewAssistant != null)
			{
				this.commonHelpNewAssistant.HelpId = DataManager<ChallengeDataManager>.GetInstance().ChallengeChapterHelpId;
			}
			this.UpdateEntryView();
		}

		// Token: 0x0600CDAB RID: 52651 RVA: 0x00329F70 File Offset: 0x00328370
		private void UpdateEntryView()
		{
			bool flag = ChallengeUtility.IsDungeonLock(this._dungeonId);
			if (this.startButtonGray != null)
			{
				this.startButtonGray.enabled = flag;
			}
			if (this.startButtonEffect != null)
			{
				this.startButtonEffect.gameObject.CustomActive(!flag);
			}
			if (this.teamButtonGray != null)
			{
				bool enabled = this.IsTeamButtonLocked();
				this.teamButtonGray.enabled = enabled;
			}
			if (this.teamButton != null)
			{
				this.teamButton.CustomActive(Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team));
			}
			int num = this._dungeonTable.CostFatiguePerArea * this._dungeonTable.MostCostStamina;
			bool flag2 = this._dungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY;
			if (this.powerCostValueText != null)
			{
				if (flag2)
				{
					this.powerCostValueText.text = string.Format(TR.Value("challenge_chapter_powerCost_more_than"), num);
				}
				else
				{
					this.powerCostValueText.text = string.Format(TR.Value("challenge_chapter_powerCost_interval"), num);
				}
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._dungeonTable.TicketID, string.Empty, string.Empty);
			if (this.ticketIcon != null && tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.ticketIcon, tableItem.Icon, true);
			}
			if (this.ticketCostValueText != null)
			{
				this.ticketCostValueText.text = this._dungeonTable.TicketNum.ToString();
				string arg = string.Empty;
				bool flag3 = false;
				int num2 = 0;
				if (this._dungeonTable.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || this._dungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY)
				{
					flag3 = DataManager<ActivityDataManager>.GetInstance().CheckIsBuyAbyssBlackGoldMember();
					if (flag3)
					{
						SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(707, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							num2 = this._dungeonTable.TicketNum - this._dungeonTable.TicketNum * tableItem2.Value / 100;
						}
					}
				}
				if (this._dungeonTable.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL)
				{
					if (flag3)
					{
						arg = string.Format("<color=#00FF56FF> -{0}</color>", num2);
					}
				}
				else if (this._dungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY)
				{
					int num3 = 0;
					if (DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.HellTicketMinus) && DataManager<ActivityDataManager>.GetInstance().IsLeftChallengeTimes(EAnniverBuffPrayType.HellTicketMinus, CounterKeys.DUNGEON_HELL_TIMES))
					{
						num3 = DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.HellTicketMinus);
					}
					if (this._mDungeonID.dungeonIDWithOutDiff == 857000)
					{
						if (flag3)
						{
							num2 += num3;
							arg = string.Format("<color=#00FF56FF> -{0}</color>", num2);
						}
						else if (num3 > 0)
						{
							arg = string.Format("<color=#00FF56FF> -{0}</color>", num3);
						}
					}
					else if (num3 > 0)
					{
						arg = string.Format("<color=#00FF56FF> -{0}</color>", num3);
					}
				}
				else if (this._dungeonTable.SubType == DungeonTable.eSubType.S_YUANGU && DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.YuanGUTicketMinus) && DataManager<ActivityDataManager>.GetInstance().IsLeftChallengeTimes(EAnniverBuffPrayType.HellTicketMinus, CounterKeys.DUNGEON_YUANGU_TIMES))
				{
					int anniverTaskValue = DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.YuanGUTicketMinus);
					arg = string.Format("<color=#00FF56FF> -{0}</color>", anniverTaskValue);
				}
				this.ticketCostValueText.text = string.Format("{0}{1}", this.ticketCostValueText.text, arg);
			}
			this.UpdateEntryRoot();
		}

		// Token: 0x0600CDAC RID: 52652 RVA: 0x0032A314 File Offset: 0x00328714
		private void UpdateEntryRoot()
		{
			if (DungeonUtility.IsWeekHellPreDungeon(this._dungeonId))
			{
				this.SetEntryRoot(false);
				if (this.startButtonRoot != null)
				{
					this.startButtonRoot.gameObject.CustomActive(true);
					if (this.specialStartPos != null)
					{
						this.startButtonRoot.transform.localPosition = this.specialStartPos.transform.localPosition;
					}
				}
				if (this.consumeRoot != null)
				{
					this.consumeRoot.gameObject.CustomActive(true);
					if (this.specialConsumePos != null)
					{
						this.consumeRoot.transform.localPosition = this.specialConsumePos.transform.localPosition;
					}
				}
				if (this.ticketConsumeRoot != null)
				{
					this.ticketConsumeRoot.gameObject.CustomActive(false);
				}
			}
			else
			{
				this.SetEntryRoot(true);
				if (this.startButtonRoot != null && this.commonStartPos != null)
				{
					this.startButtonRoot.transform.localPosition = this.commonStartPos.transform.localPosition;
				}
				if (this.consumeRoot != null && this.commonConsumePos != null)
				{
					this.consumeRoot.transform.localPosition = this.commonConsumePos.transform.localPosition;
				}
				if (DungeonUtility.IsLimitTimeFreeHellDungeon(this._dungeonId))
				{
					if (this.ticketConsumeRoot != null)
					{
						this.ticketConsumeRoot.gameObject.CustomActive(false);
					}
				}
				else if (this.ticketConsumeRoot != null)
				{
					this.ticketConsumeRoot.gameObject.CustomActive(true);
				}
			}
		}

		// Token: 0x0600CDAD RID: 52653 RVA: 0x0032A4EC File Offset: 0x003288EC
		private void SetEntryRoot(bool flag)
		{
			if (this.startButtonRoot != null)
			{
				this.startButtonRoot.gameObject.CustomActive(flag);
			}
			if (this.teamButtonRoot != null)
			{
				this.teamButtonRoot.gameObject.CustomActive(flag);
			}
			if (this.consumeRoot != null)
			{
				this.consumeRoot.gameObject.CustomActive(flag);
			}
		}

		// Token: 0x0600CDAE RID: 52654 RVA: 0x0032A560 File Offset: 0x00328960
		private void OnTeamButtonClick()
		{
			if (this._dungeonTable == null)
			{
				return;
			}
			if (!this.IsTeamButtonLocked())
			{
				Utility.OpenTeamFrame(this._dungeonId);
			}
			else if (!this.IsTeamBattleLevelLimit())
			{
				SystemNotifyManager.SystemNotify(3050, string.Empty);
			}
		}

		// Token: 0x0600CDAF RID: 52655 RVA: 0x0032A5B3 File Offset: 0x003289B3
		private void OnStartBtnClick()
		{
			if (this.mOnStartButtonClick != null)
			{
				this.mOnStartButtonClick.Invoke();
			}
		}

		// Token: 0x0600CDB0 RID: 52656 RVA: 0x0032A5CC File Offset: 0x003289CC
		public void OnStartButtonClick()
		{
			if (this._dungeonTable == null)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
				{
					SystemNotifyManager.SystemNotify(1105, string.Empty);
					return;
				}
				int iTeamDungeonTableID = 0;
				if (!Utility.CheckIsTeamDungeon(this._dungeonId, ref iTeamDungeonTableID))
				{
					SystemNotifyManager.SystemNotify(1106, string.Empty);
					return;
				}
				if (!Utility.CheckTeamEnterDungeonCondition(iTeamDungeonTableID))
				{
					return;
				}
			}
			string empty = string.Empty;
			bool flag = DungeonUtility.IsShowDungeonResistMagicValueTip(this._dungeonId, ref empty);
			if (flag)
			{
				ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(this._dungeonId);
				if (dungeonState != ComChapterDungeonUnit.eState.Locked)
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(empty, null, new UnityAction(this.MessageBoxOKCallBack), 0f, false, null);
					return;
				}
			}
			ChapterUtility.OpenComsumeFatigueAddFrame(this._dungeonId);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.ChallengeChapterStart());
		}

		// Token: 0x0600CDB1 RID: 52657 RVA: 0x0032A6B5 File Offset: 0x00328AB5
		private void MessageBoxOKCallBack()
		{
			ChapterUtility.OpenComsumeFatigueAddFrame(this._dungeonId);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this.ChallengeChapterStart());
		}

		// Token: 0x0600CDB2 RID: 52658 RVA: 0x0032A6D4 File Offset: 0x00328AD4
		protected IEnumerator ChallengeChapterStart()
		{
			if (!this._isSendingMessage)
			{
				if (!ChapterUtility.GetDungeonCanEnter(this._dungeonId, true, true, true))
				{
					yield break;
				}
				SceneDungeonStartReq req = new SceneDungeonStartReq
				{
					dungeonId = (uint)this._dungeonId
				};
				List<CostItemManager.CostInfo> costs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsCost(this._dungeonId);
				bool isEnough2Cost = DataManager<CostItemManager>.GetInstance().IsEnough2Cost(costs);
				int result = -1;
				DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(costs, delegate
				{
					result = 1;
				}, delegate
				{
					result = 0;
				}, "common_money_cost");
				while (isEnough2Cost && result == -1)
				{
					yield return null;
				}
				if (result != 1)
				{
					yield break;
				}
				req.buffDrugs = DataManager<ChapterBuffDrugManager>.GetInstance().GetAllMarkedBuffDrugsByDungeonID(this._dungeonId).ToArray();
				DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.DungeonID != this._dungeonId)
					{
						DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.Target, TeamDataManager.GetTeamDungeonIDByDungeonID(this._dungeonId));
					}
				}
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				this._isSendingMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, false, 5f);
				this._isSendingMessage = false;
			}
			yield break;
		}

		// Token: 0x0600CDB3 RID: 52659 RVA: 0x0032A6F0 File Offset: 0x00328AF0
		private bool IsTeamButtonLocked()
		{
			bool flag = ChallengeUtility.IsDungeonLock(this._dungeonId);
			return flag || (this._mDungeonID != null && this._mDungeonID.prestoryID > 0) || this.IsTeamBattleLevelLimit();
		}

		// Token: 0x0600CDB4 RID: 52660 RVA: 0x0032A73D File Offset: 0x00328B3D
		private bool IsTeamBattleLevelLimit()
		{
			return !Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team);
		}

		// Token: 0x040077FA RID: 30714
		private int _dungeonId;

		// Token: 0x040077FB RID: 30715
		private DungeonTable _dungeonTable;

		// Token: 0x040077FC RID: 30716
		private int _baseDungeonId;

		// Token: 0x040077FD RID: 30717
		private DungeonID _mDungeonID;

		// Token: 0x040077FE RID: 30718
		[Space(10f)]
		[Header("StartButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject startButtonRoot;

		// Token: 0x040077FF RID: 30719
		[SerializeField]
		private Button startButton;

		// Token: 0x04007800 RID: 30720
		[SerializeField]
		private UIGray startButtonGray;

		// Token: 0x04007801 RID: 30721
		[SerializeField]
		private GameObject startButtonEffect;

		// Token: 0x04007802 RID: 30722
		[Space(10f)]
		[Header("TeamButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject teamButtonRoot;

		// Token: 0x04007803 RID: 30723
		[SerializeField]
		private Button teamButton;

		// Token: 0x04007804 RID: 30724
		[SerializeField]
		private UIGray teamButtonGray;

		// Token: 0x04007805 RID: 30725
		[Space(10f)]
		[Header("ComsumeRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject consumeRoot;

		// Token: 0x04007806 RID: 30726
		[SerializeField]
		private Text powerCostValueText;

		// Token: 0x04007807 RID: 30727
		[SerializeField]
		private Image ticketIcon;

		// Token: 0x04007808 RID: 30728
		[SerializeField]
		private Text ticketCostValueText;

		// Token: 0x04007809 RID: 30729
		[SerializeField]
		private GameObject ticketConsumeRoot;

		// Token: 0x0400780A RID: 30730
		[Space(20f)]
		[Header("CommonButtonRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject commonStartPos;

		// Token: 0x0400780B RID: 30731
		[SerializeField]
		private GameObject specialStartPos;

		// Token: 0x0400780C RID: 30732
		[SerializeField]
		private GameObject commonConsumePos;

		// Token: 0x0400780D RID: 30733
		[SerializeField]
		private GameObject specialConsumePos;

		// Token: 0x0400780E RID: 30734
		[Space(20f)]
		[Header("CommonHelpButton")]
		[Space(10f)]
		[SerializeField]
		private CommonHelpNewAssistant commonHelpNewAssistant;

		// Token: 0x0400780F RID: 30735
		private UnityAction mOnStartButtonClick;

		// Token: 0x04007810 RID: 30736
		private bool _isSendingMessage;
	}
}
