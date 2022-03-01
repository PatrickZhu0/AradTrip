using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001509 RID: 5385
	public class ChampionshipMainCommonControl : MonoBehaviour
	{
		// Token: 0x0600D122 RID: 53538 RVA: 0x00339B1D File Offset: 0x00337F1D
		private void OnDestroy()
		{
			this.ResetCountDownTimeContent();
			this.ClearData();
		}

		// Token: 0x0600D123 RID: 53539 RVA: 0x00339B2B File Offset: 0x00337F2B
		private void OnEnable()
		{
			this.BindUiMessage();
		}

		// Token: 0x0600D124 RID: 53540 RVA: 0x00339B33 File Offset: 0x00337F33
		private void OnDisable()
		{
			this.UnBindUiMessage();
		}

		// Token: 0x0600D125 RID: 53541 RVA: 0x00339B3C File Offset: 0x00337F3C
		private void BindUiMessage()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupIdSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupIdSyncMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipFightCountDownTimeStampMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightCountDownTimeStampMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipKnockoutScoreMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipKnockoutScoreMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
		}

		// Token: 0x0600D126 RID: 53542 RVA: 0x00339BB8 File Offset: 0x00337FB8
		private void UnBindUiMessage()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipGroupIdSyncMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipGroupIdSyncMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipFightCountDownTimeStampMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipFightCountDownTimeStampMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipKnockoutScoreMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipKnockoutScoreMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipSelfSeaFightResultMessage));
		}

		// Token: 0x0600D127 RID: 53543 RVA: 0x00339C31 File Offset: 0x00338031
		private void ClearData()
		{
			this._scheduleTable = null;
			this._playerGroupView = null;
		}

		// Token: 0x0600D128 RID: 53544 RVA: 0x00339C41 File Offset: 0x00338041
		public void InitControl(ChampionshipScheduleTable scheduleTable)
		{
			if (scheduleTable == null)
			{
				return;
			}
			this._scheduleTable = scheduleTable;
			this.UpdateCountDownTimeContent();
		}

		// Token: 0x0600D129 RID: 53545 RVA: 0x00339C58 File Offset: 0x00338058
		public void UpdatePlayerGroupContent()
		{
			if (this.playerGroupRoot == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.playerGroupRoot, false);
			if (DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScoreFightGroupId <= 0)
			{
				return;
			}
			if (!ChampionshipUtility.IsInChampionshipScheduleScoreTime(this._scheduleTable))
			{
				return;
			}
			if (!DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime)
			{
				return;
			}
			if (DataManager<ChampionshipDataManager>.GetInstance().IsAlreadyShowChampionScoreFightGroupFlag)
			{
				return;
			}
			DataManager<ChampionshipDataManager>.GetInstance().IsAlreadyShowChampionScoreFightGroupFlag = true;
			CommonUtility.UpdateGameObjectVisible(this.playerGroupRoot, true);
			GameObject gameObject = CommonUtility.LoadGameObject(this.playerGroupRoot);
			if (gameObject != null)
			{
				ChampionshipMainPlayGroupView component = gameObject.GetComponent<ChampionshipMainPlayGroupView>();
				if (component != null)
				{
					component.InitPlayerGroupView();
				}
			}
		}

		// Token: 0x0600D12A RID: 53546 RVA: 0x00339D10 File Offset: 0x00338110
		public void UpdateCountDownTimeContent()
		{
			this.ResetCountDownTimeContent();
			CommonUtility.UpdateTextVisible(this.finishFightLabel, false);
			if (!DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime)
			{
				CommonUtility.UpdateGameObjectVisible(this.titleTipRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.titleTipRoot, true);
			if (ChampionshipUtility.IsInChampionshipEndShow())
			{
				this.ShowChampionshipScheduleFinishContent();
				return;
			}
			if (ChampionshipUtility.IsInChampionshipSchedulePrepareStatus())
			{
				CommonUtility.UpdateGameObjectVisible(this.countDownRoot, true);
				if (this.countDownTitleLabel != null)
				{
					this.countDownTitleLabel.text = TR.Value("Championship_Race_State_Prepare_Format");
				}
				if (this.countDownTimeController != null)
				{
					uint championshipScheduleEndTimeStamp = ChampionshipUtility.GetChampionshipScheduleEndTimeStamp();
					this.countDownTimeController.SetCountDownTimeController(championshipScheduleEndTimeStamp, null);
				}
			}
			else if (ChampionshipUtility.IsInChampionshipScheduleFightStatus())
			{
				if (DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleSelfAlreadyAdvance)
				{
					this.ShowChampionshipScheduleFinishContent();
					if (this._scheduleTable != null && this._scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.Sea_Select)
					{
						CommonUtility.UpdateTextVisible(this.finishFightLabel, true);
						if (this.finishFightLabel != null)
						{
							this.finishFightLabel.text = TR.Value("Championship_Main_Schedule_Advance_Label");
						}
					}
				}
				else
				{
					if (this._scheduleTable != null && this._scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.Sea_Select && ChampionshipUtility.IsChampionshipAlreadyFailedInSeaSelectSchedule())
					{
						CommonUtility.UpdateTextVisible(this.finishFightLabel, true);
						if (this.finishFightLabel != null)
						{
							this.finishFightLabel.text = TR.Value("Championship_Main_Schedule_Already_Failed");
						}
						return;
					}
					if (this._scheduleTable != null && this._scheduleTable.ScheduleType >= ChampionshipScheduleTable.eScheduleType.Eight_Select && ChampionshipUtility.IsFightKnockOutScheduleFinish())
					{
						this.ShowChampionshipScheduleFinishContent();
						return;
					}
					CommonUtility.UpdateGameObjectVisible(this.countDownRoot, true);
					string text = TR.Value("Championship_Race_State_Enter_Game_Soon");
					ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
					if (championshipStatusInfo != null && DataManager<ChampionshipDataManager>.GetInstance().FightStartCountDownTimeStamp >= championshipStatusInfo.endTime)
					{
						text = TR.Value("Championship_Race_State_Fight_Finish_Soon");
					}
					if (this.countDownTitleLabel != null)
					{
						this.countDownTitleLabel.text = text;
					}
					if (this.countDownTimeController != null)
					{
						uint fightStartCountDownTimeStamp = DataManager<ChampionshipDataManager>.GetInstance().FightStartCountDownTimeStamp;
						this.countDownTimeController.SetCountDownTimeController(fightStartCountDownTimeStamp, null);
					}
				}
			}
		}

		// Token: 0x0600D12B RID: 53547 RVA: 0x00339F53 File Offset: 0x00338353
		private void ResetCountDownTimeContent()
		{
			CommonUtility.UpdateGameObjectVisible(this.countDownRoot, false);
			if (this.countDownTimeController != null)
			{
				this.countDownTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x0600D12C RID: 53548 RVA: 0x00339F7D File Offset: 0x0033837D
		private void OnReceiveChampionshipFightCountDownTimeStampMessage(UIEvent uiEvent)
		{
			this.UpdateCountDownTimeContent();
		}

		// Token: 0x0600D12D RID: 53549 RVA: 0x00339F85 File Offset: 0x00338385
		private void OnReceiveChampionshipGroupIdSyncMessage(UIEvent uiEvent)
		{
			this.UpdatePlayerGroupContent();
		}

		// Token: 0x0600D12E RID: 53550 RVA: 0x00339F8D File Offset: 0x0033838D
		public void ResetTitleTipRoot()
		{
			CommonUtility.UpdateGameObjectVisible(this.titleTipRoot, false);
		}

		// Token: 0x0600D12F RID: 53551 RVA: 0x00339F9B File Offset: 0x0033839B
		private void OnReceiveChampionshipKnockoutScoreMessage(UIEvent uiEvent)
		{
			this.UpdateCountDownTimeContent();
		}

		// Token: 0x0600D130 RID: 53552 RVA: 0x00339FA3 File Offset: 0x003383A3
		private void OnReceiveChampionshipSelfSeaFightResultMessage(UIEvent uiEvent)
		{
			if (this._scheduleTable == null)
			{
				return;
			}
			if (this._scheduleTable.ScheduleType != ChampionshipScheduleTable.eScheduleType.Sea_Select)
			{
				return;
			}
			this.UpdateCountDownTimeContent();
		}

		// Token: 0x0600D131 RID: 53553 RVA: 0x00339FC9 File Offset: 0x003383C9
		private void ShowChampionshipScheduleFinishContent()
		{
			this.ResetCountDownTimeContent();
			CommonUtility.UpdateTextVisible(this.finishFightLabel, true);
			if (this.finishFightLabel != null)
			{
				this.finishFightLabel.text = TR.Value("Championship_Main_Schedule_Finish_Label");
			}
		}

		// Token: 0x04007A70 RID: 31344
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A71 RID: 31345
		private ChampionshipMainPlayGroupView _playerGroupView;

		// Token: 0x04007A72 RID: 31346
		[Space(10f)]
		[Header("CountDownTime")]
		[Space(10f)]
		[SerializeField]
		private GameObject titleTipRoot;

		// Token: 0x04007A73 RID: 31347
		[SerializeField]
		private GameObject countDownRoot;

		// Token: 0x04007A74 RID: 31348
		[SerializeField]
		private Text countDownTitleLabel;

		// Token: 0x04007A75 RID: 31349
		[SerializeField]
		private CountDownTimeController countDownTimeController;

		// Token: 0x04007A76 RID: 31350
		[SerializeField]
		private Text finishFightLabel;

		// Token: 0x04007A77 RID: 31351
		[Space(10f)]
		[Header("Group")]
		[Space(10f)]
		[SerializeField]
		private GameObject playerGroupRoot;
	}
}
