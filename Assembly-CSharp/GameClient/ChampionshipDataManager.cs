using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001203 RID: 4611
	public class ChampionshipDataManager : DataManager<ChampionshipDataManager>
	{
		// Token: 0x0600B175 RID: 45429 RVA: 0x0027364B File Offset: 0x00271A4B
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600B176 RID: 45430 RVA: 0x00273653 File Offset: 0x00271A53
		public override void Clear()
		{
			this.UnBindNetEvents();
			this.ClearData();
		}

		// Token: 0x0600B177 RID: 45431 RVA: 0x00273664 File Offset: 0x00271A64
		private void ClearData()
		{
			this.ResetChampionStatusData();
			this.ResetDataByLeaveChampionship();
			this.IsAlreadyShowChampionScoreFightGroupFlag = false;
			this.ResetFightDetailRecordData();
			this.ResetTotalFightRaceAndTopPlayerDataModel();
			this._championshipGuessCostItemNameStr = string.Empty;
			this.ResetChampionshipGuessProjectData();
			this.ResetChampionshipGuessRecordDataModelList();
			this.ChampionshipBubbleShowScheduleStatus = 0U;
			this.IsShowGuessBetRedPoint = false;
			this.ResetGroupScoreRankDataModel();
			this._championshipCostPointTicketNumber = 0;
			this._championshipReliveTicketId = 0;
			this._championshipGuessBetMaxLimitNumber = 0U;
		}

		// Token: 0x0600B178 RID: 45432 RVA: 0x002736D0 File Offset: 0x00271AD0
		public void ResetDataByLeaveChampionship()
		{
			this.ResetTopScoreRankDataModel();
			this.SelfSeaFightResultDataModel = null;
			this.FightRaceGroupId = 0;
			this.ResetScoreFightRecordDataModel();
			this.KnockoutPlayerDataModelList.Clear();
			this.FightStartCountDownTimeStamp = 0U;
		}

		// Token: 0x0600B179 RID: 45433 RVA: 0x00273700 File Offset: 0x00271B00
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(509818U, new Action<MsgDATA>(this.OnReceiveSceneChampionStatusRes));
			NetProcess.AddMsgHandler(509820U, new Action<MsgDATA>(this.OnReceiveSceneChampionSelfStatusRes));
			NetProcess.AddMsgHandler(509828U, new Action<MsgDATA>(this.OnReceiveSceneChampionTotalStatusRes));
			NetProcess.AddMsgHandler(509803U, new Action<MsgDATA>(this.OnReceiveSceneChampionEnrollRes));
			NetProcess.AddMsgHandler(509822U, new Action<MsgDATA>(this.OnReceiveSceneChampionSelfBattleRecordRes));
			NetProcess.AddMsgHandler(509824U, new Action<MsgDATA>(this.OnReceiveSceneChampionGroupRankRes));
			NetProcess.AddMsgHandler(1209811U, new Action<MsgDATA>(this.OnReceiveUnionChampionScoreRankTopSync));
			NetProcess.AddMsgHandler(1209812U, new Action<MsgDATA>(this.OnReceiveUnionChampionGroupIdSync));
			NetProcess.AddMsgHandler(509830U, new Action<MsgDATA>(this.OnSendSceneChampionScoreFightRecordRes));
			NetProcess.AddMsgHandler(1209813U, new Action<MsgDATA>(this.OnReceiveUnionChampionKnockoutScore));
			NetProcess.AddMsgHandler(1209810U, new Action<MsgDATA>(this.OnReceiveChampionBattleCountDownSync));
			NetProcess.AddMsgHandler(509807U, new Action<MsgDATA>(this.OnReceiveSceneChampionReliveRes));
			NetProcess.AddMsgHandler(1209816U, new Action<MsgDATA>(this.OnReceiveUnionChampionNullTurnNotify));
			NetProcess.AddMsgHandler(509809U, new Action<MsgDATA>(this.OnReceiveSceneChampion16TableRes));
			NetProcess.AddMsgHandler(509833U, new Action<MsgDATA>(this.OnReceiveSceneChampionAllGroupRes));
			NetProcess.AddMsgHandler(509831U, new Action<MsgDATA>(this.OnReceiveSceneChampionGroupStatusSync));
			NetProcess.AddMsgHandler(509826U, new Action<MsgDATA>(this.OnReceiveSceneChampionFightDetailRecordRes));
			NetProcess.AddMsgHandler(509835U, new Action<MsgDATA>(this.OnReceiveChampionAllGuessProjectRes));
			NetProcess.AddMsgHandler(509812U, new Action<MsgDATA>(this.OnReceiveSceneChampionBetRes));
			NetProcess.AddMsgHandler(509840U, new Action<MsgDATA>(this.OnReceiveSceneChampionGambleAlreadyBetRes));
			NetProcess.AddMsgHandler(509837U, new Action<MsgDATA>(this.OnReceiveChampionGuessRecordRes));
			NetProcess.AddMsgHandler(509816U, new Action<MsgDATA>(this.OnReceiveSceneChampionObserveRes));
		}

		// Token: 0x0600B17A RID: 45434 RVA: 0x002738F4 File Offset: 0x00271CF4
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(509818U, new Action<MsgDATA>(this.OnReceiveSceneChampionStatusRes));
			NetProcess.RemoveMsgHandler(509820U, new Action<MsgDATA>(this.OnReceiveSceneChampionSelfStatusRes));
			NetProcess.RemoveMsgHandler(509828U, new Action<MsgDATA>(this.OnReceiveSceneChampionTotalStatusRes));
			NetProcess.RemoveMsgHandler(509803U, new Action<MsgDATA>(this.OnReceiveSceneChampionEnrollRes));
			NetProcess.RemoveMsgHandler(509822U, new Action<MsgDATA>(this.OnReceiveSceneChampionSelfBattleRecordRes));
			NetProcess.RemoveMsgHandler(509824U, new Action<MsgDATA>(this.OnReceiveSceneChampionGroupRankRes));
			NetProcess.RemoveMsgHandler(1209811U, new Action<MsgDATA>(this.OnReceiveUnionChampionScoreRankTopSync));
			NetProcess.RemoveMsgHandler(1209812U, new Action<MsgDATA>(this.OnReceiveUnionChampionGroupIdSync));
			NetProcess.RemoveMsgHandler(509830U, new Action<MsgDATA>(this.OnSendSceneChampionScoreFightRecordRes));
			NetProcess.RemoveMsgHandler(1209813U, new Action<MsgDATA>(this.OnReceiveUnionChampionKnockoutScore));
			NetProcess.RemoveMsgHandler(1209810U, new Action<MsgDATA>(this.OnReceiveChampionBattleCountDownSync));
			NetProcess.RemoveMsgHandler(509807U, new Action<MsgDATA>(this.OnReceiveSceneChampionReliveRes));
			NetProcess.RemoveMsgHandler(1209816U, new Action<MsgDATA>(this.OnReceiveUnionChampionNullTurnNotify));
			NetProcess.RemoveMsgHandler(509809U, new Action<MsgDATA>(this.OnReceiveSceneChampion16TableRes));
			NetProcess.RemoveMsgHandler(509831U, new Action<MsgDATA>(this.OnReceiveSceneChampionGroupStatusSync));
			NetProcess.RemoveMsgHandler(509833U, new Action<MsgDATA>(this.OnReceiveSceneChampionAllGroupRes));
			NetProcess.RemoveMsgHandler(509826U, new Action<MsgDATA>(this.OnReceiveSceneChampionFightDetailRecordRes));
			NetProcess.RemoveMsgHandler(509835U, new Action<MsgDATA>(this.OnReceiveChampionAllGuessProjectRes));
			NetProcess.RemoveMsgHandler(509812U, new Action<MsgDATA>(this.OnReceiveSceneChampionBetRes));
			NetProcess.RemoveMsgHandler(509840U, new Action<MsgDATA>(this.OnReceiveSceneChampionGambleAlreadyBetRes));
			NetProcess.RemoveMsgHandler(509837U, new Action<MsgDATA>(this.OnReceiveChampionGuessRecordRes));
			NetProcess.RemoveMsgHandler(509816U, new Action<MsgDATA>(this.OnReceiveSceneChampionObserveRes));
		}

		// Token: 0x0600B17B RID: 45435 RVA: 0x00273AE8 File Offset: 0x00271EE8
		public void OnSendSceneChampionStatusReq()
		{
			SceneChampionStatusReq cmd = new SceneChampionStatusReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionStatusReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B17C RID: 45436 RVA: 0x00273B18 File Offset: 0x00271F18
		private void OnReceiveSceneChampionStatusRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			int championshipScheduleId = this.ChampionshipScheduleId;
			SceneChampionStatusRes sceneChampionStatusRes = new SceneChampionStatusRes();
			sceneChampionStatusRes.decode(msgData.bytes);
			this.ChampionshipStatusInfo = sceneChampionStatusRes.status;
			this.UpdateSceneChampionStatusInfo();
			int championshipScheduleId2 = this.ChampionshipScheduleId;
			this.UpdateSceneChampionGuessRedPoint(championshipScheduleId, championshipScheduleId2);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipUpdateGuessBetRedPointMessage, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipStatusMessage, null, null, null, null);
		}

		// Token: 0x0600B17D RID: 45437 RVA: 0x00273B8C File Offset: 0x00271F8C
		public void OnSendSceneChampionSelfStatusReq()
		{
			SceneChampionSelfStatusReq cmd = new SceneChampionSelfStatusReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionSelfStatusReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B17E RID: 45438 RVA: 0x00273BBC File Offset: 0x00271FBC
		private void OnReceiveSceneChampionSelfStatusRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionSelfStatusRes sceneChampionSelfStatusRes = new SceneChampionSelfStatusRes();
			sceneChampionSelfStatusRes.decode(msgData.bytes);
			this._championshipSelfStatus = sceneChampionSelfStatusRes.status;
			this.UpdateSceneChampionStatusInfo();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipSelfStatusMessage, null, null, null, null);
		}

		// Token: 0x0600B17F RID: 45439 RVA: 0x00273C08 File Offset: 0x00272008
		public void OnSendSceneChampionTotalStatusReq()
		{
			SceneChampionTotalStatusReq cmd = new SceneChampionTotalStatusReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionTotalStatusReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B180 RID: 45440 RVA: 0x00273C38 File Offset: 0x00272038
		private void OnReceiveSceneChampionTotalStatusRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			int championshipScheduleId = this.ChampionshipScheduleId;
			this.ResetChampionStatusData();
			SceneChampionTotalStatusRes sceneChampionTotalStatusRes = new SceneChampionTotalStatusRes();
			sceneChampionTotalStatusRes.decode(msgData.bytes);
			this.ChampionshipStatusInfo = sceneChampionTotalStatusRes.status;
			this._championshipSelfStatus = sceneChampionTotalStatusRes.slefStatus;
			this.UpdateSceneChampionStatusInfo();
			this.AlreadySignUpPlayerGuid = sceneChampionTotalStatusRes.roleID;
			int championshipScheduleId2 = this.ChampionshipScheduleId;
			this.UpdateSceneChampionGuessRedPoint(championshipScheduleId, championshipScheduleId2);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipUpdateGuessBetRedPointMessage, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipStatusMessage, null, null, null, null);
		}

		// Token: 0x0600B181 RID: 45441 RVA: 0x00273CCC File Offset: 0x002720CC
		private void UpdateSceneChampionGuessRedPoint(int preScheduleId, int currentScheduleId)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(currentScheduleId, string.Empty, string.Empty) == null)
			{
				this.IsShowGuessBetRedPoint = false;
				return;
			}
			if (!ChampionshipUtility.IsChampionshipCanGuess())
			{
				this.IsShowGuessBetRedPoint = false;
				return;
			}
			if (!ChampionshipUtility.IsInChampionshipSchedulePreStatus())
			{
				this.IsShowGuessBetRedPoint = false;
				return;
			}
			if (preScheduleId == currentScheduleId)
			{
				return;
			}
			this.IsShowGuessBetRedPoint = true;
		}

		// Token: 0x0600B182 RID: 45442 RVA: 0x00273D30 File Offset: 0x00272130
		private void UpdateSceneChampionStatusInfo()
		{
			ChampionshipUtility.UpdateChampionshipStatus(this.ChampionshipStatusInfo, this._championshipSelfStatus, out this.ChampionshipScheduleId, out this.IsChampionshipScheduleOpenInTime, out this.IsChampionshipScheduleOpenToPlayer, out this.IsChampionshipScheduleAlreadySignUp, out this.IsChampionshipScheduleSelfAlreadyAdvance);
		}

		// Token: 0x0600B183 RID: 45443 RVA: 0x00273D64 File Offset: 0x00272164
		public void OnSendSceneChampionEnrollReq()
		{
			SceneChampionEnrollReq cmd = new SceneChampionEnrollReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionEnrollReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B184 RID: 45444 RVA: 0x00273D94 File Offset: 0x00272194
		private void OnReceiveSceneChampionEnrollRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionEnrollRes sceneChampionEnrollRes = new SceneChampionEnrollRes();
			sceneChampionEnrollRes.decode(msgData.bytes);
			if (sceneChampionEnrollRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneChampionEnrollRes.errorCode, string.Empty);
				return;
			}
			this.IsChampionshipScheduleAlreadySignUp = true;
			this.AlreadySignUpPlayerGuid = DataManager<PlayerBaseData>.GetInstance().RoleID;
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_SignUp_Succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipSignUpSucceedMessage, null, null, null, null);
		}

		// Token: 0x0600B185 RID: 45445 RVA: 0x00273E11 File Offset: 0x00272211
		private void ResetChampionStatusData()
		{
			this._championshipSelfStatus = 0U;
			this.ChampionshipStatusInfo = null;
			this.ChampionshipScheduleId = 0;
			this.IsChampionshipScheduleOpenInTime = false;
			this.IsChampionshipScheduleOpenToPlayer = false;
			this.IsChampionshipScheduleAlreadySignUp = false;
			this.IsChampionshipScheduleSelfAlreadyAdvance = false;
			this.AlreadySignUpPlayerGuid = 0UL;
		}

		// Token: 0x0600B186 RID: 45446 RVA: 0x00273E4C File Offset: 0x0027224C
		public void OnSendSceneChampionSelfBattleRecordReq()
		{
			SceneChampionSelfBattleRecordReq cmd = new SceneChampionSelfBattleRecordReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionSelfBattleRecordReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B187 RID: 45447 RVA: 0x00273E7C File Offset: 0x0027227C
		private void OnReceiveSceneChampionSelfBattleRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionSelfBattleRecordRes sceneChampionSelfBattleRecordRes = new SceneChampionSelfBattleRecordRes();
			sceneChampionSelfBattleRecordRes.decode(msgData.bytes);
			if (this.SelfSeaFightResultDataModel == null)
			{
				this.SelfSeaFightResultDataModel = new ChampionshipSelfSeaFightResultDataModel();
			}
			this.SelfSeaFightResultDataModel.WinNumber = (int)sceneChampionSelfBattleRecordRes.win;
			this.SelfSeaFightResultDataModel.LoseNumber = (int)sceneChampionSelfBattleRecordRes.lose;
			this.SelfSeaFightResultDataModel.ReliveStatus = (ChampionshipReliveStatus)sceneChampionSelfBattleRecordRes.relive;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipSelfSeaFightResultMessage, null, null, null, null);
		}

		// Token: 0x0600B188 RID: 45448 RVA: 0x00273F00 File Offset: 0x00272300
		public void OnSendSceneChampionGroupRankReq()
		{
			SceneChampionGroupRankReq cmd = new SceneChampionGroupRankReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionGroupRankReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B189 RID: 45449 RVA: 0x00273F30 File Offset: 0x00272330
		private void OnReceiveSceneChampionGroupRankRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGroupRankRes sceneChampionGroupRankRes = new SceneChampionGroupRankRes();
			sceneChampionGroupRankRes.decode(msgData.bytes);
			this.GroupScoreRankDataModelList.Clear();
			if (sceneChampionGroupRankRes.rankList != null)
			{
				List<RankRole> list = sceneChampionGroupRankRes.rankList.ToList<RankRole>();
				for (int i = 0; i < list.Count; i++)
				{
					RankRole rankRole = list[i];
					if (rankRole != null)
					{
						ChampionshipScoreRankDataModel scoreRankDataModel = ChampionshipUtility.GetScoreRankDataModel(rankRole);
						if (scoreRankDataModel != null)
						{
							this.GroupScoreRankDataModelList.Add(scoreRankDataModel);
							int count = this.GroupScoreRankDataModelList.Count;
							scoreRankDataModel.RankIndex = count;
							if (CommonUtility.IsSelfPlayerByPlayerGuid(scoreRankDataModel.PlayerGuid))
							{
								this.SelfScoreRankDataModel = scoreRankDataModel;
							}
						}
					}
				}
			}
			if (this.SelfScoreRankDataModel == null)
			{
				this.SelfScoreRankDataModel = ChampionshipUtility.GetSelfScoreRankDataModel();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipGroupScoreRankResMessage, null, null, null, null);
		}

		// Token: 0x0600B18A RID: 45450 RVA: 0x0027401C File Offset: 0x0027241C
		public void OnReceiveUnionChampionScoreRankTopSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionChampionScoreRankTopSync unionChampionScoreRankTopSync = new UnionChampionScoreRankTopSync();
			unionChampionScoreRankTopSync.decode(msgData.bytes);
			this.TopScoreRankDataModelList.Clear();
			List<RankRole> list = unionChampionScoreRankTopSync.rankList.ToList<RankRole>();
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					RankRole rankRole = list[i];
					if (rankRole != null)
					{
						ChampionshipScoreRankDataModel scoreRankDataModel = ChampionshipUtility.GetScoreRankDataModel(rankRole);
						if (scoreRankDataModel != null)
						{
							this.TopScoreRankDataModelList.Add(scoreRankDataModel);
							int count = this.TopScoreRankDataModelList.Count;
							scoreRankDataModel.RankIndex = count;
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipTopScoreRankSyncMessage, null, null, null, null);
		}

		// Token: 0x0600B18B RID: 45451 RVA: 0x002740E0 File Offset: 0x002724E0
		public void OnReceiveUnionChampionGroupIdSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionChampionGroupIDSync unionChampionGroupIDSync = new UnionChampionGroupIDSync();
			unionChampionGroupIDSync.decode(msgData.bytes);
			this.ChampionshipScoreFightGroupId = (int)unionChampionGroupIDSync.id;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipGroupIdSyncMessage, null, null, null, null);
		}

		// Token: 0x0600B18C RID: 45452 RVA: 0x00274128 File Offset: 0x00272528
		public void OnSendSceneChampionScoreFightRecordReq()
		{
			SceneChampionScoreBattleRecordsReq cmd = new SceneChampionScoreBattleRecordsReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionScoreBattleRecordsReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B18D RID: 45453 RVA: 0x00274158 File Offset: 0x00272558
		private void OnSendSceneChampionScoreFightRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionScoreBattleRecordsRes sceneChampionScoreBattleRecordsRes = new SceneChampionScoreBattleRecordsRes();
			sceneChampionScoreBattleRecordsRes.decode(msgData.bytes);
			List<ScoreBattleRecord> list = sceneChampionScoreBattleRecordsRes.recods.ToList<ScoreBattleRecord>();
			this.ScoreFightRecordDataModelList.Clear();
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					ScoreBattleRecord scoreBattleRecord = list[i];
					ChampionshipScoreFightRecordDataModel scoreFightRecordDataModel = ChampionshipUtility.GetScoreFightRecordDataModel(scoreBattleRecord);
					if (scoreFightRecordDataModel != null)
					{
						this.ScoreFightRecordDataModelList.Add(scoreFightRecordDataModel);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipScoreFightRecordMessage, null, null, null, null);
		}

		// Token: 0x0600B18E RID: 45454 RVA: 0x002741FC File Offset: 0x002725FC
		private void OnReceiveUnionChampionKnockoutScore(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionChampionKnockoutScore unionChampionKnockoutScore = new UnionChampionKnockoutScore();
			unionChampionKnockoutScore.decode(msgData.bytes);
			List<KnockoutPlayer> list = unionChampionKnockoutScore.roles.ToList<KnockoutPlayer>();
			this.KnockoutPlayerDataModelList.Clear();
			if (list != null && list.Count > 0)
			{
				for (int i = 0; i < list.Count; i++)
				{
					KnockoutPlayer knockoutPlayer = list[i];
					if (knockoutPlayer != null)
					{
						ChampionshipKnockoutPlayerDataModel championshipKnockoutPlayerDataModel = ChampionshipUtility.CreateKnockOutPlayerDataModel(knockoutPlayer);
						if (championshipKnockoutPlayerDataModel != null)
						{
							this.KnockoutPlayerDataModelList.Add(championshipKnockoutPlayerDataModel);
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipKnockoutScoreMessage, null, null, null, null);
		}

		// Token: 0x0600B18F RID: 45455 RVA: 0x002742AC File Offset: 0x002726AC
		private void OnReceiveChampionBattleCountDownSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionChampionBattleCountdownSync unionChampionBattleCountdownSync = new UnionChampionBattleCountdownSync();
			unionChampionBattleCountdownSync.decode(msgData.bytes);
			this.FightStartCountDownTimeStamp = unionChampionBattleCountdownSync.endTime;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipFightCountDownTimeStampMessage, null, null, null, null);
		}

		// Token: 0x0600B190 RID: 45456 RVA: 0x002742F4 File Offset: 0x002726F4
		public void OnSendSceneChampionReliveReq()
		{
			SceneChampionReliveReq cmd = new SceneChampionReliveReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionReliveReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B191 RID: 45457 RVA: 0x00274324 File Offset: 0x00272724
		private void OnReceiveSceneChampionReliveRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionReliveRes sceneChampionReliveRes = new SceneChampionReliveRes();
			sceneChampionReliveRes.decode(msgData.bytes);
			if (sceneChampionReliveRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneChampionReliveRes.errorCode, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Fight_Relive_Succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B192 RID: 45458 RVA: 0x00274378 File Offset: 0x00272778
		private void OnReceiveUnionChampionNullTurnNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			UnionChampionNullTrunNotify stream = new UnionChampionNullTrunNotify();
			stream.decode(msgData.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipNotEnterFightSceneMessage, null, null, null, null);
		}

		// Token: 0x0600B193 RID: 45459 RVA: 0x002743B1 File Offset: 0x002727B1
		private void ResetTopScoreRankDataModel()
		{
			this.TopScoreRankDataModelList.Clear();
		}

		// Token: 0x0600B194 RID: 45460 RVA: 0x002743BE File Offset: 0x002727BE
		public void ResetGroupScoreRankDataModel()
		{
			this.SelfScoreRankDataModel = null;
			this.GroupScoreRankDataModelList.Clear();
			this.IsShowChampionshipScoreScheduleId = 0;
		}

		// Token: 0x0600B195 RID: 45461 RVA: 0x002743D9 File Offset: 0x002727D9
		public void ResetScoreFightRecordDataModel()
		{
			this.ScoreFightRecordDataModelList.Clear();
		}

		// Token: 0x0600B196 RID: 45462 RVA: 0x002743E6 File Offset: 0x002727E6
		public void OnSendSceneChampionshipFightRaceData()
		{
			this.OnSendSceneChampion16TableReq();
			this.OnSendSceneChampionAllGroupReq();
		}

		// Token: 0x0600B197 RID: 45463 RVA: 0x002743F4 File Offset: 0x002727F4
		public void OnSendSceneChampion16TableReq()
		{
			SceneChampion16TableReq cmd = new SceneChampion16TableReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampion16TableReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B198 RID: 45464 RVA: 0x00274424 File Offset: 0x00272824
		private void OnReceiveSceneChampion16TableRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampion16TableRes sceneChampion16TableRes = new SceneChampion16TableRes();
			sceneChampion16TableRes.decode(msgData.bytes);
			if (sceneChampion16TableRes.playerVec == null || sceneChampion16TableRes.playerVec.Length <= 0)
			{
				return;
			}
			this.ResetTopPlayerDataModel();
			for (int i = 0; i < sceneChampion16TableRes.playerVec.Length; i++)
			{
				ChampionTop16Player championTop16Player = sceneChampion16TableRes.playerVec[i];
				if (championTop16Player != null)
				{
					ChampionshipTopPlayerDataModel top16PlayerDataModel = ChampionshipUtility.GetTop16PlayerDataModel(championTop16Player);
					if (top16PlayerDataModel != null)
					{
						this.TopPlayerDataModelDic[top16PlayerDataModel.PlayerGuid] = top16PlayerDataModel;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipTop16PlayerMessage, null, null, null, null);
		}

		// Token: 0x0600B199 RID: 45465 RVA: 0x002744D0 File Offset: 0x002728D0
		public void OnSendSceneChampionAllGroupReq()
		{
			SceneChampionAllGroupReq cmd = new SceneChampionAllGroupReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionAllGroupReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B19A RID: 45466 RVA: 0x00274500 File Offset: 0x00272900
		private void OnReceiveSceneChampionAllGroupRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionAllGroupRes sceneChampionAllGroupRes = new SceneChampionAllGroupRes();
			sceneChampionAllGroupRes.decode(msgData.bytes);
			this.ResetTotalFightRaceDataModel();
			if (sceneChampionAllGroupRes.groups != null && sceneChampionAllGroupRes.groups.Length > 0)
			{
				for (int i = 0; i < sceneChampionAllGroupRes.groups.Length; i++)
				{
					ChampionGroup championGroup = sceneChampionAllGroupRes.groups[i];
					if (championGroup != null)
					{
						int groupID = (int)championGroup.groupID;
						ChampionshipFightRaceDataModel championshipFightRaceDataModel = new ChampionshipFightRaceDataModel();
						ChampionshipUtility.UpdateChampionshipFightRaceDataModel(championshipFightRaceDataModel, championGroup);
						this.TotalFightRaceDataModelDictionary[groupID] = championshipFightRaceDataModel;
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipFightRaceAllGroupMessage, null, null, null, null);
		}

		// Token: 0x0600B19B RID: 45467 RVA: 0x002745AC File Offset: 0x002729AC
		private void OnReceiveSceneChampionGroupStatusSync(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGroupStatusSync sceneChampionGroupStatusSync = new SceneChampionGroupStatusSync();
			sceneChampionGroupStatusSync.decode(msgData.bytes);
			ChampionGroup group = sceneChampionGroupStatusSync.group;
			if (group == null)
			{
				return;
			}
			int groupID = (int)group.groupID;
			ChampionshipFightRaceDataModel championshipFightRaceDataModel = null;
			if (!this.TotalFightRaceDataModelDictionary.TryGetValue(groupID, out championshipFightRaceDataModel))
			{
				championshipFightRaceDataModel = new ChampionshipFightRaceDataModel();
			}
			ChampionshipUtility.UpdateChampionshipFightRaceDataModel(championshipFightRaceDataModel, group);
			this.TotalFightRaceDataModelDictionary[groupID] = championshipFightRaceDataModel;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipFightRaceSyncGroupMessage, groupID, null, null, null);
		}

		// Token: 0x0600B19C RID: 45468 RVA: 0x00274630 File Offset: 0x00272A30
		public void OnSendSceneChampionFightDetailRecordReq(int groupId)
		{
			SceneChampionGroupRecordReq sceneChampionGroupRecordReq = new SceneChampionGroupRecordReq();
			sceneChampionGroupRecordReq.groupID = (uint)groupId;
			this.FightRaceGroupId = groupId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionGroupRecordReq>(ServerType.GATE_SERVER, sceneChampionGroupRecordReq);
			}
		}

		// Token: 0x0600B19D RID: 45469 RVA: 0x0027466C File Offset: 0x00272A6C
		private void OnReceiveSceneChampionFightDetailRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGroupRecordRes sceneChampionGroupRecordRes = new SceneChampionGroupRecordRes();
			sceneChampionGroupRecordRes.decode(msgData.bytes);
			if (this.FightRaceGroupId != (int)sceneChampionGroupRecordRes.groupID)
			{
				return;
			}
			this.FightDetailRecordDataModelList.Clear();
			if (sceneChampionGroupRecordRes.records != null && sceneChampionGroupRecordRes.records.Length > 0)
			{
				for (int i = 0; i < sceneChampionGroupRecordRes.records.Length; i++)
				{
					ChampionBattleRecord championBattleRecord = sceneChampionGroupRecordRes.records[i];
					if (championBattleRecord == null)
					{
						return;
					}
					ChampionshipFightDetailRecordDataModel championshipFightDetailRecordDataModel = ChampionshipUtility.CreateFightDetailRecordDataModel(championBattleRecord);
					if (championshipFightDetailRecordDataModel == null)
					{
						return;
					}
					this.FightDetailRecordDataModelList.Add(championshipFightDetailRecordDataModel);
				}
			}
			int count = this.FightDetailRecordDataModelList.Count;
			for (int j = count + 1; j <= 5; j++)
			{
				ChampionshipFightDetailRecordDataModel item = ChampionshipUtility.CreateFightDetailRecordDataModelByIndex(j);
				this.FightDetailRecordDataModelList.Add(item);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipFightDetailRecordResMessage, null, null, null, null);
		}

		// Token: 0x0600B19E RID: 45470 RVA: 0x0027475C File Offset: 0x00272B5C
		public void ResetChampionshipFightDetailRecordDataModelList()
		{
			this.FightDetailRecordDataModelList.Clear();
			int count = this.FightDetailRecordDataModelList.Count;
			for (int i = count + 1; i <= 5; i++)
			{
				ChampionshipFightDetailRecordDataModel item = ChampionshipUtility.CreateFightDetailRecordDataModelByIndex(i);
				this.FightDetailRecordDataModelList.Add(item);
			}
		}

		// Token: 0x0600B19F RID: 45471 RVA: 0x002747A7 File Offset: 0x00272BA7
		public void ResetTotalFightRaceDataModel()
		{
			if (this.TotalFightRaceDataModelDictionary != null)
			{
				this.TotalFightRaceDataModelDictionary.Clear();
			}
		}

		// Token: 0x0600B1A0 RID: 45472 RVA: 0x002747BF File Offset: 0x00272BBF
		public void ResetTopPlayerDataModel()
		{
			if (this.TopPlayerDataModelDic != null)
			{
				this.TopPlayerDataModelDic.Clear();
			}
		}

		// Token: 0x0600B1A1 RID: 45473 RVA: 0x002747D7 File Offset: 0x00272BD7
		public void ResetTotalFightRaceAndTopPlayerDataModel()
		{
			this.ResetTotalFightRaceDataModel();
			this.ResetTopPlayerDataModel();
		}

		// Token: 0x0600B1A2 RID: 45474 RVA: 0x002747E5 File Offset: 0x00272BE5
		public void ResetFightDetailRecordData()
		{
			this.FightRaceGroupId = 0;
			this.FightDetailRecordDataModelList.Clear();
		}

		// Token: 0x0600B1A3 RID: 45475 RVA: 0x002747FC File Offset: 0x00272BFC
		public void OnSendSceneChampionObserveReq(ulong raceId)
		{
			if (raceId <= 0UL)
			{
				return;
			}
			SceneChampionObserveReq sceneChampionObserveReq = new SceneChampionObserveReq();
			sceneChampionObserveReq.raceID = raceId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionObserveReq>(ServerType.GATE_SERVER, sceneChampionObserveReq);
			}
		}

		// Token: 0x0600B1A4 RID: 45476 RVA: 0x0027483C File Offset: 0x00272C3C
		private void OnReceiveSceneChampionObserveRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionObserveRes sceneChampionObserveRes = new SceneChampionObserveRes();
			sceneChampionObserveRes.decode(msgData.bytes);
			ulong roleID = sceneChampionObserveRes.roleID;
			ulong raceID = sceneChampionObserveRes.raceID;
			SockAddr addr = sceneChampionObserveRes.addr;
			if (addr == null)
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager == null)
			{
				return;
			}
			bool flag = netManager.ConnectToRelayServer(addr.ip, addr.port, ClientApplication.playerinfo.accid, 4000U);
			if (flag)
			{
				RelaySvrObserveReq cmd = new RelaySvrObserveReq
				{
					accid = ClientApplication.playerinfo.accid,
					roleId = roleID,
					raceId = raceID,
					startFrame = 0U
				};
				netManager.SendCommand<RelaySvrObserveReq>(ServerType.RELAY_SERVER, cmd);
				if (Singleton<ReplayServer>.GetInstance() != null)
				{
					Singleton<ReplayServer>.GetInstance().LiveShowServerAddr = addr;
				}
			}
		}

		// Token: 0x0600B1A5 RID: 45477 RVA: 0x00274914 File Offset: 0x00272D14
		public void OnSendSceneChampionAllGuessProjectReq()
		{
			SceneChampionAllGambleInfoReq cmd = new SceneChampionAllGambleInfoReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionAllGambleInfoReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B1A6 RID: 45478 RVA: 0x00274944 File Offset: 0x00272D44
		private void OnReceiveChampionAllGuessProjectRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionAllGambleInfoRes sceneChampionAllGambleInfoRes = new SceneChampionAllGambleInfoRes();
			sceneChampionAllGambleInfoRes.decode(msgData.bytes);
			GambleInfo[] infos = sceneChampionAllGambleInfoRes.infos;
			if (infos == null || infos.Length <= 0)
			{
				return;
			}
			foreach (GambleInfo gambleInfo in infos)
			{
				if (gambleInfo != null)
				{
					uint id = gambleInfo.id;
					ChampionshipGuessProjectDataModel championshipGuessProjectDataModel = null;
					if (!this.GuessProjectDataModelDictionary.TryGetValue(id, out championshipGuessProjectDataModel))
					{
						championshipGuessProjectDataModel = ChampionshipUtility.CreateGuessProjectDataModelByGambleInfo(gambleInfo);
						this.GuessProjectDataModelDictionary[id] = championshipGuessProjectDataModel;
					}
					else if (championshipGuessProjectDataModel == null)
					{
						championshipGuessProjectDataModel = ChampionshipUtility.CreateGuessProjectDataModelByGambleInfo(gambleInfo);
						this.GuessProjectDataModelDictionary[id] = championshipGuessProjectDataModel;
					}
					else
					{
						ChampionshipUtility.UpdateGuessProjectDataModel(championshipGuessProjectDataModel, gambleInfo);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipGuessProjectResMessage, null, null, null, null);
		}

		// Token: 0x0600B1A7 RID: 45479 RVA: 0x00274A20 File Offset: 0x00272E20
		public void OnSendSceneChampionBetReq(uint betProjectId, ulong betOptionId, uint betValue)
		{
			SceneChampionGambleReq sceneChampionGambleReq = new SceneChampionGambleReq();
			sceneChampionGambleReq.id = betProjectId;
			sceneChampionGambleReq.option = betOptionId;
			sceneChampionGambleReq.coin = betValue;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionGambleReq>(ServerType.GATE_SERVER, sceneChampionGambleReq);
			}
		}

		// Token: 0x0600B1A8 RID: 45480 RVA: 0x00274A64 File Offset: 0x00272E64
		private void OnReceiveSceneChampionBetRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGambleRes sceneChampionGambleRes = new SceneChampionGambleRes();
			sceneChampionGambleRes.decode(msgData.bytes);
			if (sceneChampionGambleRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneChampionGambleRes.errorCode, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("Championship_Guess_Bet_Succeed_Label"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B1A9 RID: 45481 RVA: 0x00274AB8 File Offset: 0x00272EB8
		public void OnSendSceneChampionGambleAlreadyBetReq(uint betProjectId, ulong betOptionId)
		{
			SceneChampionGmableAlreadyBetReq sceneChampionGmableAlreadyBetReq = new SceneChampionGmableAlreadyBetReq();
			sceneChampionGmableAlreadyBetReq.id = betProjectId;
			sceneChampionGmableAlreadyBetReq.option = betOptionId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionGmableAlreadyBetReq>(ServerType.GATE_SERVER, sceneChampionGmableAlreadyBetReq);
			}
		}

		// Token: 0x0600B1AA RID: 45482 RVA: 0x00274AF4 File Offset: 0x00272EF4
		private void OnReceiveSceneChampionGambleAlreadyBetRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGmableAlreadyBetRes sceneChampionGmableAlreadyBetRes = new SceneChampionGmableAlreadyBetRes();
			sceneChampionGmableAlreadyBetRes.decode(msgData.bytes);
			uint id = sceneChampionGmableAlreadyBetRes.id;
			ulong option = sceneChampionGmableAlreadyBetRes.option;
			uint num = (uint)sceneChampionGmableAlreadyBetRes.num;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipAlreadyBetNumberMessage, id, option, num, null);
		}

		// Token: 0x0600B1AB RID: 45483 RVA: 0x00274B54 File Offset: 0x00272F54
		public void OnSendSceneChampionGuessRecordReq()
		{
			SceneChampionGambleRecordReq cmd = new SceneChampionGambleRecordReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneChampionGambleRecordReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600B1AC RID: 45484 RVA: 0x00274B84 File Offset: 0x00272F84
		private void OnReceiveChampionGuessRecordRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneChampionGambleRecordRes sceneChampionGambleRecordRes = new SceneChampionGambleRecordRes();
			sceneChampionGambleRecordRes.decode(msgData.bytes);
			GambleRecord[] records = sceneChampionGambleRecordRes.records;
			this.ResetChampionshipGuessRecordDataModelList();
			if (records != null && records.Length > 0)
			{
				foreach (GambleRecord gambleRecord in records)
				{
					ChampionshipGuessRecordDataModel championshipGuessRecordDataModel = ChampionshipUtility.CreateChampionshipGuessRecordDataModel(gambleRecord);
					if (championshipGuessRecordDataModel != null)
					{
						this.GuessRecordDataModelList.Add(championshipGuessRecordDataModel);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipGuessRecordMessage, null, null, null, null);
		}

		// Token: 0x0600B1AD RID: 45485 RVA: 0x00274C14 File Offset: 0x00273014
		public void ResetChampionshipGuessProjectData()
		{
			this.ResetChampionshipRequestGuessProjectDataInterval();
			this.GuessOptionNameDictionary.Clear();
			if (this.GuessProjectDataModelDictionary == null || this.GuessProjectDataModelDictionary.Count <= 0)
			{
				return;
			}
			foreach (KeyValuePair<uint, ChampionshipGuessProjectDataModel> keyValuePair in this.GuessProjectDataModelDictionary)
			{
				ChampionshipGuessProjectDataModel value = keyValuePair.Value;
				if (value != null)
				{
					if (value.GuessOptionDataModelDictionary != null)
					{
						value.GuessOptionDataModelDictionary.Clear();
					}
					if (value.GuessOptionIdList != null)
					{
						value.GuessOptionIdList.Clear();
					}
				}
			}
			this.GuessProjectDataModelDictionary.Clear();
		}

		// Token: 0x0600B1AE RID: 45486 RVA: 0x00274CB9 File Offset: 0x002730B9
		public void ResetChampionshipGuessRecordDataModelList()
		{
			this.GuessRecordDataModelList.Clear();
		}

		// Token: 0x0600B1AF RID: 45487 RVA: 0x00274CC6 File Offset: 0x002730C6
		public void ResetChampionshipRequestGuessProjectDataInterval()
		{
			this._requestBetDataInterval = -1f;
		}

		// Token: 0x0600B1B0 RID: 45488 RVA: 0x00274CD3 File Offset: 0x002730D3
		public void SetChampionshipRequestGuessProjectDataInterval()
		{
			this._requestBetDataInterval = 10f;
		}

		// Token: 0x0600B1B1 RID: 45489 RVA: 0x00274CE0 File Offset: 0x002730E0
		public override void Update(float time)
		{
			if (this._requestBetDataInterval < 0f)
			{
				return;
			}
			this._requestBetDataInterval -= time;
			if (this._requestBetDataInterval <= 0f)
			{
				bool flag = ChampionshipUtility.IsChampionshipGuessFrameOpen();
				if (flag)
				{
					this.OnSendSceneChampionAllGuessProjectReq();
					this.SetChampionshipRequestGuessProjectDataInterval();
				}
				else
				{
					this.ResetChampionshipRequestGuessProjectDataInterval();
				}
			}
		}

		// Token: 0x0600B1B2 RID: 45490 RVA: 0x00274D40 File Offset: 0x00273140
		public string GetChampionshipGuessCostItemNameStr()
		{
			if (!string.IsNullOrEmpty(this._championshipGuessCostItemNameStr))
			{
				return this._championshipGuessCostItemNameStr;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(330000271, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			this._championshipGuessCostItemNameStr = tableItem.Name;
			return this._championshipGuessCostItemNameStr;
		}

		// Token: 0x0600B1B3 RID: 45491 RVA: 0x00274D9C File Offset: 0x0027319C
		public int GetChampionshipReliveItemId()
		{
			if (this._championshipReliveTicketId == 0)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(696, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > 0)
				{
					this._championshipReliveTicketId = tableItem.Value;
				}
				else
				{
					this._championshipReliveTicketId = 330000272;
				}
			}
			return this._championshipReliveTicketId;
		}

		// Token: 0x0600B1B4 RID: 45492 RVA: 0x00274E04 File Offset: 0x00273204
		public int GetChampionshipReliveCostPointTicketNumber()
		{
			if (this._championshipCostPointTicketNumber == 0)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(697, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > 0)
				{
					this._championshipCostPointTicketNumber = tableItem.Value;
				}
				else
				{
					this._championshipCostPointTicketNumber = 50;
				}
			}
			return this._championshipCostPointTicketNumber;
		}

		// Token: 0x0600B1B5 RID: 45493 RVA: 0x00274E68 File Offset: 0x00273268
		public uint GetChampionshipGuessBetMaxLimitNumber()
		{
			if (this._championshipGuessBetMaxLimitNumber == 0U)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(698, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > 0)
				{
					this._championshipGuessBetMaxLimitNumber = (uint)tableItem.Value;
				}
				else
				{
					this._championshipGuessBetMaxLimitNumber = 1000U;
				}
			}
			return this._championshipGuessBetMaxLimitNumber;
		}

		// Token: 0x0400634B RID: 25419
		public const int ChampionshipFinalWinnerTitleId = 130193223;

		// Token: 0x0400634C RID: 25420
		public const int ChampionshipAvatarBaseLayerIndex = 25;

		// Token: 0x0400634D RID: 25421
		public const int ChampionshipShowLevelLimit = 30;

		// Token: 0x0400634E RID: 25422
		public const int ChampionshipSignUpLevelLimit = 60;

		// Token: 0x0400634F RID: 25423
		public const int ChampionshipGuessShopId = 37;

		// Token: 0x04006350 RID: 25424
		public const string WinFightScoreStr = "+3";

		// Token: 0x04006351 RID: 25425
		public const string FlatFightScoreStr = "+1";

		// Token: 0x04006352 RID: 25426
		public const string LoseFightScoreStr = "+0";

		// Token: 0x04006353 RID: 25427
		public const uint ChampionshipScoreFightPlayerGroupShowTime = 3U;

		// Token: 0x04006354 RID: 25428
		private int _championshipReliveTicketId;

		// Token: 0x04006355 RID: 25429
		public const SystemValueTable.eType3 ChampionshipReliveItemIdType3 = SystemValueTable.eType3.SVT_CHAMPION_RELIVE_ITEM_ID;

		// Token: 0x04006356 RID: 25430
		private const int ChampionshipReliveTicketId = 330000272;

		// Token: 0x04006357 RID: 25431
		private int _championshipCostPointTicketNumber;

		// Token: 0x04006358 RID: 25432
		public const SystemValueTable.eType3 ChampionshipRelivePointTicketNumberType3 = SystemValueTable.eType3.SVT_CHAMPION_RELIVE_DIANQUAN_NUM;

		// Token: 0x04006359 RID: 25433
		private const int ChampionshipCostPointTicketNumber = 50;

		// Token: 0x0400635A RID: 25434
		public const int ChampionshipCostPointTicketId = 600000002;

		// Token: 0x0400635B RID: 25435
		public const int ChampionshipGuessCostItemId = 330000271;

		// Token: 0x0400635C RID: 25436
		private string _championshipGuessCostItemNameStr = string.Empty;

		// Token: 0x0400635D RID: 25437
		public const int ChampionshipScoreScheduleTopFourPlayerWin = 4;

		// Token: 0x0400635E RID: 25438
		public const int ChampionshipScoreScheduleTopTwoPlayerWin = 2;

		// Token: 0x0400635F RID: 25439
		private const float ChampionshipRequestBetDataInterval = 10f;

		// Token: 0x04006360 RID: 25440
		public const uint ChampionshipFightRaceInterval = 360U;

		// Token: 0x04006361 RID: 25441
		public ChampionStatusInfo ChampionshipStatusInfo;

		// Token: 0x04006362 RID: 25442
		private uint _championshipSelfStatus;

		// Token: 0x04006363 RID: 25443
		public uint ChampionshipBubbleShowScheduleStatus;

		// Token: 0x04006364 RID: 25444
		public int ChampionshipScheduleId;

		// Token: 0x04006365 RID: 25445
		public bool IsChampionshipScheduleOpenInTime;

		// Token: 0x04006366 RID: 25446
		public bool IsChampionshipScheduleOpenToPlayer;

		// Token: 0x04006367 RID: 25447
		public bool IsChampionshipScheduleAlreadySignUp;

		// Token: 0x04006368 RID: 25448
		public ulong AlreadySignUpPlayerGuid;

		// Token: 0x04006369 RID: 25449
		public bool IsChampionshipScheduleSelfAlreadyAdvance;

		// Token: 0x0400636A RID: 25450
		public ChampionshipSelfSeaFightResultDataModel SelfSeaFightResultDataModel;

		// Token: 0x0400636B RID: 25451
		public int ChampionshipScoreFightGroupId;

		// Token: 0x0400636C RID: 25452
		public bool IsAlreadyShowChampionScoreFightGroupFlag;

		// Token: 0x0400636D RID: 25453
		public ChampionshipScoreRankDataModel SelfScoreRankDataModel;

		// Token: 0x0400636E RID: 25454
		public List<ChampionshipScoreRankDataModel> GroupScoreRankDataModelList = new List<ChampionshipScoreRankDataModel>();

		// Token: 0x0400636F RID: 25455
		public List<ChampionshipScoreRankDataModel> TopScoreRankDataModelList = new List<ChampionshipScoreRankDataModel>();

		// Token: 0x04006370 RID: 25456
		public int IsShowChampionshipScoreScheduleId;

		// Token: 0x04006371 RID: 25457
		public List<ChampionshipScoreFightRecordDataModel> ScoreFightRecordDataModelList = new List<ChampionshipScoreFightRecordDataModel>();

		// Token: 0x04006372 RID: 25458
		public List<ChampionshipKnockoutPlayerDataModel> KnockoutPlayerDataModelList = new List<ChampionshipKnockoutPlayerDataModel>();

		// Token: 0x04006373 RID: 25459
		public uint FightStartCountDownTimeStamp;

		// Token: 0x04006374 RID: 25460
		public Dictionary<ulong, ChampionshipTopPlayerDataModel> TopPlayerDataModelDic = new Dictionary<ulong, ChampionshipTopPlayerDataModel>();

		// Token: 0x04006375 RID: 25461
		public Dictionary<int, ChampionshipFightRaceDataModel> TotalFightRaceDataModelDictionary = new Dictionary<int, ChampionshipFightRaceDataModel>();

		// Token: 0x04006376 RID: 25462
		public const int FightDetailRecordTotalNumber = 5;

		// Token: 0x04006377 RID: 25463
		public int FightRaceGroupId;

		// Token: 0x04006378 RID: 25464
		public List<ChampionshipFightDetailRecordDataModel> FightDetailRecordDataModelList = new List<ChampionshipFightDetailRecordDataModel>();

		// Token: 0x04006379 RID: 25465
		public Dictionary<uint, ChampionshipGuessProjectDataModel> GuessProjectDataModelDictionary = new Dictionary<uint, ChampionshipGuessProjectDataModel>();

		// Token: 0x0400637A RID: 25466
		public List<ChampionshipGuessRecordDataModel> GuessRecordDataModelList = new List<ChampionshipGuessRecordDataModel>();

		// Token: 0x0400637B RID: 25467
		public Dictionary<ulong, string> GuessOptionNameDictionary = new Dictionary<ulong, string>();

		// Token: 0x0400637C RID: 25468
		public bool IsShowGuessBetRedPoint;

		// Token: 0x0400637D RID: 25469
		private uint _championshipGuessBetMaxLimitNumber;

		// Token: 0x0400637E RID: 25470
		public const SystemValueTable.eType3 ChampionshipGuessBetMaxLimitType3 = SystemValueTable.eType3.SVT_CHAMPION_RELIVE_BETLIMIT_NUM;

		// Token: 0x0400637F RID: 25471
		private const uint ChampionshipGuessBetMaxLimitNumber = 1000U;

		// Token: 0x04006380 RID: 25472
		private float _requestBetDataInterval = -1f;
	}
}
