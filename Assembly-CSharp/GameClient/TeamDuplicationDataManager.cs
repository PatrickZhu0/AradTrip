using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200130F RID: 4879
	public class TeamDuplicationDataManager : DataManager<TeamDuplicationDataManager>
	{
		// Token: 0x0600BDAE RID: 48558 RVA: 0x002C7254 File Offset: 0x002C5654
		public TeamDuplicationDataManager()
		{
			this.TeamDuplicationFightStageId = 0;
			this.TeamDuplicationFightFinishTime = 0U;
			this.TeamDuplicationCaptainFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			this.TeamDuplicationTeamFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			this.TeamDuplicationFightPointDataModelList = new List<TeamDuplicationFightPointDataModel>();
			this.TeamDuplicationFightStageRewardDataModelList = new List<TeamDuplicationFightStageRewardDataModel>();
			this.IsTeamDuplicationOwnerTeam = false;
			this.StartBattleVoteIntervalTime = 0;
			this.StartBattleVoteEndTime = 0;
			this.IsInStartBattleVotingTime = false;
			this.TeamInviteDataModelList = new List<TeamDuplicationTeamInviteDataModel>();
		}

		// Token: 0x17001B89 RID: 7049
		// (get) Token: 0x0600BDAF RID: 48559 RVA: 0x002C74A9 File Offset: 0x002C58A9
		// (set) Token: 0x0600BDB0 RID: 48560 RVA: 0x002C74B1 File Offset: 0x002C58B1
		public int StartBattleVoteIntervalTime { get; private set; }

		// Token: 0x17001B8A RID: 7050
		// (get) Token: 0x0600BDB1 RID: 48561 RVA: 0x002C74BA File Offset: 0x002C58BA
		// (set) Token: 0x0600BDB2 RID: 48562 RVA: 0x002C74C2 File Offset: 0x002C58C2
		public int StartBattleVoteEndTime { get; private set; }

		// Token: 0x17001B8B RID: 7051
		// (get) Token: 0x0600BDB3 RID: 48563 RVA: 0x002C74CB File Offset: 0x002C58CB
		// (set) Token: 0x0600BDB4 RID: 48564 RVA: 0x002C74D3 File Offset: 0x002C58D3
		public bool IsInStartBattleVotingTime { get; private set; }

		// Token: 0x17001B8C RID: 7052
		// (get) Token: 0x0600BDB5 RID: 48565 RVA: 0x002C74DC File Offset: 0x002C58DC
		// (set) Token: 0x0600BDB6 RID: 48566 RVA: 0x002C74E4 File Offset: 0x002C58E4
		public bool IsTeamDuplicationOwnerTeam { get; private set; }

		// Token: 0x17001B8D RID: 7053
		// (get) Token: 0x0600BDB7 RID: 48567 RVA: 0x002C74ED File Offset: 0x002C58ED
		// (set) Token: 0x0600BDB8 RID: 48568 RVA: 0x002C74F5 File Offset: 0x002C58F5
		public List<TeamDuplicationTeamInviteDataModel> TeamInviteDataModelList { get; private set; }

		// Token: 0x17001B8E RID: 7054
		// (get) Token: 0x0600BDB9 RID: 48569 RVA: 0x002C74FE File Offset: 0x002C58FE
		// (set) Token: 0x0600BDBA RID: 48570 RVA: 0x002C7506 File Offset: 0x002C5906
		public int TeamDuplicationFightStageId { get; private set; }

		// Token: 0x17001B8F RID: 7055
		// (get) Token: 0x0600BDBB RID: 48571 RVA: 0x002C750F File Offset: 0x002C590F
		// (set) Token: 0x0600BDBC RID: 48572 RVA: 0x002C7517 File Offset: 0x002C5917
		public uint TeamDuplicationFightFinishTime { get; private set; }

		// Token: 0x17001B90 RID: 7056
		// (get) Token: 0x0600BDBD RID: 48573 RVA: 0x002C7520 File Offset: 0x002C5920
		// (set) Token: 0x0600BDBE RID: 48574 RVA: 0x002C7528 File Offset: 0x002C5928
		public TeamDuplicationFightGoalDataModel TeamDuplicationCaptainFightGoalDataModel { get; private set; }

		// Token: 0x17001B91 RID: 7057
		// (get) Token: 0x0600BDBF RID: 48575 RVA: 0x002C7531 File Offset: 0x002C5931
		// (set) Token: 0x0600BDC0 RID: 48576 RVA: 0x002C7539 File Offset: 0x002C5939
		public TeamDuplicationFightGoalDataModel TeamDuplicationTeamFightGoalDataModel { get; private set; }

		// Token: 0x17001B92 RID: 7058
		// (get) Token: 0x0600BDC1 RID: 48577 RVA: 0x002C7542 File Offset: 0x002C5942
		// (set) Token: 0x0600BDC2 RID: 48578 RVA: 0x002C754A File Offset: 0x002C594A
		public List<TeamDuplicationFightPointDataModel> TeamDuplicationFightPointDataModelList { get; private set; }

		// Token: 0x17001B93 RID: 7059
		// (get) Token: 0x0600BDC3 RID: 48579 RVA: 0x002C7553 File Offset: 0x002C5953
		// (set) Token: 0x0600BDC4 RID: 48580 RVA: 0x002C755B File Offset: 0x002C595B
		public List<TeamDuplicationFightStageRewardDataModel> TeamDuplicationFightStageRewardDataModelList { get; private set; }

		// Token: 0x0600BDC5 RID: 48581 RVA: 0x002C7564 File Offset: 0x002C5964
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600BDC6 RID: 48582 RVA: 0x002C756C File Offset: 0x002C596C
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(1100059U, new Action<MsgDATA>(this.OnReceiveTeamCopyPlayerInfoNotify));
			NetProcess.AddMsgHandler(1100039U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamUpdate));
			NetProcess.AddMsgHandler(1100040U, new Action<MsgDATA>(this.OnReceiveTeamCopyReconnectNotify));
			NetProcess.AddMsgHandler(1100066U, new Action<MsgDATA>(this.OnReceiveTeamCopyPlayerExpireNotify));
			NetProcess.AddMsgHandler(1100004U, new Action<MsgDATA>(this.OnReceiveTeamCopyCreateTeamRes));
			NetProcess.AddMsgHandler(1100077U, new Action<MsgDATA>(this.OnReceiveTeamCopyModifyEquipScoreRes));
			NetProcess.AddMsgHandler(1100006U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamDataRes));
			NetProcess.AddMsgHandler(1100057U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamStatusNotify));
			NetProcess.AddMsgHandler(1100038U, new Action<MsgDATA>(this.OnReceiveTeamCopySquadNotify));
			NetProcess.AddMsgHandler(1100046U, new Action<MsgDATA>(this.OnReceiveTeamCopyKickRes));
			NetProcess.AddMsgHandler(1100048U, new Action<MsgDATA>(this.OnReceiveTeamCopyAppointmentRes));
			NetProcess.AddMsgHandler(1100042U, new Action<MsgDATA>(this.OnReceiveTeamCopyChangeSeatRes));
			NetProcess.AddMsgHandler(1100056U, new Action<MsgDATA>(this.OnReceiveTeamCopyAppointmentNotify));
			NetProcess.AddMsgHandler(1100008U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamListRes));
			NetProcess.AddMsgHandler(1100044U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamDetailRes));
			NetProcess.AddMsgHandler(1100010U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyRes));
			NetProcess.AddMsgHandler(1100058U, new Action<MsgDATA>(this.OnReceiveTeamCopyApplyNotify));
			NetProcess.AddMsgHandler(1100065U, new Action<MsgDATA>(this.OnReceiveTeamCopyApplyRefuseNotify));
			NetProcess.AddMsgHandler(1100049U, new Action<MsgDATA>(this.OnReceiveTeamCopyMemberNotify));
			NetProcess.AddMsgHandler(1100051U, new Action<MsgDATA>(this.OnReceiveTeamCopyAutoAgreeGoldRes));
			NetProcess.AddMsgHandler(1100024U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyListRes));
			NetProcess.AddMsgHandler(1100030U, new Action<MsgDATA>(this.OnReceiveTeamCopyFindTeamMateRes));
			NetProcess.AddMsgHandler(1100032U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteNotify));
			NetProcess.AddMsgHandler(1100053U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteListRes));
			NetProcess.AddMsgHandler(1100055U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteChoiceRes));
			NetProcess.AddMsgHandler(1100061U, new Action<MsgDATA>(this.OnReceiveTeamRecruitRes));
			NetProcess.AddMsgHandler(1100063U, new Action<MsgDATA>(this.OnReceiveTeamCopyLinkJoinRes));
			NetProcess.AddMsgHandler(1100026U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyReplyRes));
			NetProcess.AddMsgHandler(1100012U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamQuitRes));
			NetProcess.AddMsgHandler(1100014U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartBattleRes));
			NetProcess.AddMsgHandler(1100015U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartBattleNotify));
			NetProcess.AddMsgHandler(1100017U, new Action<MsgDATA>(this.OnReceiveTeamCopyVoteNotify));
			NetProcess.AddMsgHandler(1100018U, new Action<MsgDATA>(this.OnReceiveTeamCopyVoteFinish));
			NetProcess.AddMsgHandler(1100069U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndFlag));
			NetProcess.AddMsgHandler(1100071U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndRes));
			NetProcess.AddMsgHandler(1100072U, new Action<MsgDATA>(this.OnReceiveTeamCopyEndVoteNotify));
			NetProcess.AddMsgHandler(1100074U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndMemberVoteNotify));
			NetProcess.AddMsgHandler(1100075U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndVoteResultNotify));
			NetProcess.AddMsgHandler(1100019U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageNotify));
			NetProcess.AddMsgHandler(1100020U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldNotify));
			NetProcess.AddMsgHandler(1100064U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldStatusNotify));
			NetProcess.AddMsgHandler(1100067U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldUnlockRate));
			NetProcess.AddMsgHandler(1100021U, new Action<MsgDATA>(this.OnReceiveTeamCopyTargetNotify));
			NetProcess.AddMsgHandler(1100028U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartChallengeRes));
			NetProcess.AddMsgHandler(1100036U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageFlopRes));
			NetProcess.AddMsgHandler(1100022U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageEndNotify));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_TEAM_COPY, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
			NetProcess.AddMsgHandler(1100078U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridFieldNotify));
			NetProcess.AddMsgHandler(1100079U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMonsterNotify));
			NetProcess.AddMsgHandler(1100085U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMonsterData));
			NetProcess.AddMsgHandler(1100080U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridSquadNotify));
			NetProcess.AddMsgHandler(1100081U, new Action<MsgDATA>(this.OnReceiveTeamCopyOtherSquadData));
			NetProcess.AddMsgHandler(1100083U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMoveRes));
			NetProcess.AddMsgHandler(1100084U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridSquadBattleNotify));
			NetProcess.AddMsgHandler(1100086U, new Action<MsgDATA>(this.OnReceiveTeamCopyTwoTeamData));
		}

		// Token: 0x0600BDC7 RID: 48583 RVA: 0x002C7A38 File Offset: 0x002C5E38
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(1100059U, new Action<MsgDATA>(this.OnReceiveTeamCopyPlayerInfoNotify));
			NetProcess.RemoveMsgHandler(1100039U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamUpdate));
			NetProcess.RemoveMsgHandler(1100040U, new Action<MsgDATA>(this.OnReceiveTeamCopyReconnectNotify));
			NetProcess.RemoveMsgHandler(1100066U, new Action<MsgDATA>(this.OnReceiveTeamCopyPlayerExpireNotify));
			NetProcess.RemoveMsgHandler(1100004U, new Action<MsgDATA>(this.OnReceiveTeamCopyCreateTeamRes));
			NetProcess.RemoveMsgHandler(1100077U, new Action<MsgDATA>(this.OnReceiveTeamCopyModifyEquipScoreRes));
			NetProcess.RemoveMsgHandler(1100006U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamDataRes));
			NetProcess.RemoveMsgHandler(1100057U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamStatusNotify));
			NetProcess.RemoveMsgHandler(1100038U, new Action<MsgDATA>(this.OnReceiveTeamCopySquadNotify));
			NetProcess.RemoveMsgHandler(1100046U, new Action<MsgDATA>(this.OnReceiveTeamCopyKickRes));
			NetProcess.RemoveMsgHandler(1100048U, new Action<MsgDATA>(this.OnReceiveTeamCopyAppointmentRes));
			NetProcess.RemoveMsgHandler(1100042U, new Action<MsgDATA>(this.OnReceiveTeamCopyChangeSeatRes));
			NetProcess.RemoveMsgHandler(1100056U, new Action<MsgDATA>(this.OnReceiveTeamCopyAppointmentNotify));
			NetProcess.RemoveMsgHandler(1100008U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamListRes));
			NetProcess.RemoveMsgHandler(1100044U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamDetailRes));
			NetProcess.RemoveMsgHandler(1100010U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyRes));
			NetProcess.RemoveMsgHandler(1100058U, new Action<MsgDATA>(this.OnReceiveTeamCopyApplyNotify));
			NetProcess.RemoveMsgHandler(1100065U, new Action<MsgDATA>(this.OnReceiveTeamCopyApplyRefuseNotify));
			NetProcess.RemoveMsgHandler(1100024U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyListRes));
			NetProcess.RemoveMsgHandler(1100049U, new Action<MsgDATA>(this.OnReceiveTeamCopyMemberNotify));
			NetProcess.RemoveMsgHandler(1100051U, new Action<MsgDATA>(this.OnReceiveTeamCopyAutoAgreeGoldRes));
			NetProcess.RemoveMsgHandler(1100030U, new Action<MsgDATA>(this.OnReceiveTeamCopyFindTeamMateRes));
			NetProcess.RemoveMsgHandler(1100032U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteNotify));
			NetProcess.RemoveMsgHandler(1100053U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteListRes));
			NetProcess.RemoveMsgHandler(1100055U, new Action<MsgDATA>(this.OnReceiveTeamCopyInviteChoiceRes));
			NetProcess.RemoveMsgHandler(1100061U, new Action<MsgDATA>(this.OnReceiveTeamRecruitRes));
			NetProcess.RemoveMsgHandler(1100063U, new Action<MsgDATA>(this.OnReceiveTeamCopyLinkJoinRes));
			NetProcess.RemoveMsgHandler(1100026U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamApplyReplyRes));
			NetProcess.RemoveMsgHandler(1100012U, new Action<MsgDATA>(this.OnReceiveTeamCopyTeamQuitRes));
			NetProcess.RemoveMsgHandler(1100014U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartBattleRes));
			NetProcess.RemoveMsgHandler(1100015U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartBattleNotify));
			NetProcess.RemoveMsgHandler(1100017U, new Action<MsgDATA>(this.OnReceiveTeamCopyVoteNotify));
			NetProcess.RemoveMsgHandler(1100018U, new Action<MsgDATA>(this.OnReceiveTeamCopyVoteFinish));
			NetProcess.RemoveMsgHandler(1100069U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndFlag));
			NetProcess.RemoveMsgHandler(1100071U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndRes));
			NetProcess.RemoveMsgHandler(1100072U, new Action<MsgDATA>(this.OnReceiveTeamCopyEndVoteNotify));
			NetProcess.RemoveMsgHandler(1100074U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndMemberVoteNotify));
			NetProcess.RemoveMsgHandler(1100075U, new Action<MsgDATA>(this.OnReceiveTeamCopyForceEndVoteResultNotify));
			NetProcess.RemoveMsgHandler(1100019U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageNotify));
			NetProcess.RemoveMsgHandler(1100020U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldNotify));
			NetProcess.RemoveMsgHandler(1100021U, new Action<MsgDATA>(this.OnReceiveTeamCopyTargetNotify));
			NetProcess.RemoveMsgHandler(1100064U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldStatusNotify));
			NetProcess.RemoveMsgHandler(1100067U, new Action<MsgDATA>(this.OnReceiveTeamCopyFieldUnlockRate));
			NetProcess.RemoveMsgHandler(1100028U, new Action<MsgDATA>(this.OnReceiveTeamCopyStartChallengeRes));
			NetProcess.RemoveMsgHandler(1100036U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageFlopRes));
			NetProcess.RemoveMsgHandler(1100022U, new Action<MsgDATA>(this.OnReceiveTeamCopyStageEndNotify));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_TEAM_COPY, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
			NetProcess.RemoveMsgHandler(1100078U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridFieldNotify));
			NetProcess.RemoveMsgHandler(1100079U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMonsterNotify));
			NetProcess.RemoveMsgHandler(1100085U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMonsterData));
			NetProcess.RemoveMsgHandler(1100080U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridSquadNotify));
			NetProcess.RemoveMsgHandler(1100081U, new Action<MsgDATA>(this.OnReceiveTeamCopyOtherSquadData));
			NetProcess.RemoveMsgHandler(1100083U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridMoveRes));
			NetProcess.RemoveMsgHandler(1100084U, new Action<MsgDATA>(this.OnReceiveTeamCopyGridSquadBattleNotify));
			NetProcess.RemoveMsgHandler(1100086U, new Action<MsgDATA>(this.OnReceiveTeamCopyTwoTeamData));
		}

		// Token: 0x0600BDC8 RID: 48584 RVA: 0x002C7F04 File Offset: 0x002C6304
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
			this.IsAlreadyShowTicketIsNotEnoughTip = false;
			this.ResetPlayerInformationDataModel();
			this._costItemIdWithNormalLevel = 0;
			this._costItemNumberWithNormalLevel = 0;
			this._costItemIdWith65Level = 0;
			this._costItemNumberWith65Level = 0;
			this._monsterFieldId = 0;
			this._captainMoveCdTime = 0;
			this._passTimesWithNormalLevel = 0;
			this._equipScoreWithNormalLevel = 0;
			this._passTimesWith65Level = 0;
			this._equipScoreWith65Level = 0;
		}

		// Token: 0x0600BDC9 RID: 48585 RVA: 0x002C7F70 File Offset: 0x002C6370
		public void ClearData()
		{
			this.IsTeamDuplicationOwnerTeam = false;
			this.ResetTeamDataModel();
			this.IsAlreadyReceiveFinalReward = false;
			this.IsTeamDuplicationGoldOwner = false;
			this.ResetTeamListDataModelList();
			this.ResetTeamDuplicationFightPanelData();
			this.ResetTeamDuplicationGridMapDataModel();
			this.FightSettingConfigPlanModel = TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_INVALID;
			this.ResetTeamConfigDataModelList();
			this.ResetTeamRequesterDataModelList();
			this.ResetTeamRequestJoinInEndTimeDic();
			this.ResetTeamFriendDataModelList();
			this.ResetFightStageRewardDataModelList();
			this.ResetFightStartVoteData();
			this.ResetFightEndVoteData();
			this.TeamDuplicationFightEndVoteFlag = false;
			this.IsAlreadyShowPositionAdjustTip = false;
			this.ResetTeamDuplicationReconnectData();
			this.ResetTeamDuplicationTeamInviteDataModelList();
			this.IsTeamDuplicationOwnerNewInvite = false;
			this.IsTeamDuplicationOwnerNewRequester = false;
			this.TeamDuplicationEndStageId = 0;
			this.TeamDuplicationStagePassTypeWith65Level = TC2PassType.TC_2_PASS_TYPE_COMMON;
			this.IsNeedShowGameFailResult = false;
			this.TeamDuplicationPlayerExpireTimeDic.Clear();
			this.IsEnterTeamDuplicationBuildSceneFromTown = false;
			this.TeamDuplicationFightPointUnLockRateDictionary.Clear();
			this.BossPhase = 0;
			this.BossBloodRate = 0;
		}

		// Token: 0x0600BDCA RID: 48586 RVA: 0x002C8044 File Offset: 0x002C6444
		private void OnReceiveTeamCopyReconnectNotify(MsgDATA msgData)
		{
			TeamCopyReconnectNotify teamCopyReconnectNotify = new TeamCopyReconnectNotify();
			teamCopyReconnectNotify.decode(msgData.bytes);
			int sceneId = (int)teamCopyReconnectNotify.sceneId;
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(sceneId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationBuid && tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				return;
			}
			this.TeamDuplicationReconnectSceneId = sceneId;
			this.TeamDuplicationReconnectExpireTime = teamCopyReconnectNotify.expireTime;
		}

		// Token: 0x0600BDCB RID: 48587 RVA: 0x002C80B8 File Offset: 0x002C64B8
		private void OnReceiveTeamCopyPlayerExpireNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyPlayerExpireNotify teamCopyPlayerExpireNotify = new TeamCopyPlayerExpireNotify();
			teamCopyPlayerExpireNotify.decode(msgData.bytes);
			ulong playerId = teamCopyPlayerExpireNotify.playerId;
			ulong expireTime = teamCopyPlayerExpireNotify.expireTime;
			this.TeamDuplicationPlayerExpireTimeDic[playerId] = expireTime;
			TeamDuplicationUtility.UpdateTeamDuplicationPlayerExpireTimeByGuid(playerId, expireTime);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationPlayerExpireTimeMessage, playerId, expireTime, null, null);
		}

		// Token: 0x0600BDCC RID: 48588 RVA: 0x002C811D File Offset: 0x002C651D
		public void ResetTeamDuplicationReconnectData()
		{
			this.TeamDuplicationReconnectSceneId = 0;
			this.TeamDuplicationReconnectExpireTime = 0UL;
		}

		// Token: 0x0600BDCD RID: 48589 RVA: 0x002C8130 File Offset: 0x002C6530
		private void OnReceiveTeamCopyPlayerInfoNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyPlayerInfoNotify teamCopyPlayerInfoNotify = new TeamCopyPlayerInfoNotify();
			teamCopyPlayerInfoNotify.decode(msgData.bytes);
			if (this._playerInformationDataModel == null)
			{
				this._playerInformationDataModel = TeamDuplicationUtility.CreateTeamDuplicationPlayerInformationDataModel();
			}
			this._playerInformationDataModel.DayAlreadyFightNumber = (int)teamCopyPlayerInfoNotify.dayNum;
			this._playerInformationDataModel.DayTotalFightNumber = (int)teamCopyPlayerInfoNotify.dayTotalNum;
			this._playerInformationDataModel.WeekAlreadyFightNumber = (int)teamCopyPlayerInfoNotify.weekNum;
			this._playerInformationDataModel.WeekTotalFightNumber = (int)teamCopyPlayerInfoNotify.weekTotalNum;
			this._playerInformationDataModel.HardLevelAlreadyFightNumber = (int)teamCopyPlayerInfoNotify.diffWeekNum;
			this._playerInformationDataModel.HardLevelTotalFightNumber = (int)teamCopyPlayerInfoNotify.diffWeekTotalNum;
			this._playerInformationDataModel.CommonLevelPassNumber = (int)teamCopyPlayerInfoNotify.commonGradePassNum;
			this._playerInformationDataModel.UnLockCommonLevelTotalNumber = (int)teamCopyPlayerInfoNotify.unlockDiffGradeCommonNum;
			this._playerInformationDataModel.IsCanCreateGold = (teamCopyPlayerInfoNotify.isCreateGold == 1U);
			this._playerInformationDataModel.DayFreeQuitNumber = (int)teamCopyPlayerInfoNotify.dayFreeQuitNum;
			this._playerInformationDataModel.WeekFreeQuitNumber = (int)teamCopyPlayerInfoNotify.weekFreeQuitNum;
			this._playerInformationDataModel.TicketIsEnough = (teamCopyPlayerInfoNotify.ticketIsEnough == 1U);
			this._playerInformationDataModel.AlreadyOpenDifficultyList.Clear();
			for (int i = 0; i < teamCopyPlayerInfoNotify.yetOpenGradeList.Length; i++)
			{
				this._playerInformationDataModel.AlreadyOpenDifficultyList.Add(teamCopyPlayerInfoNotify.yetOpenGradeList[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationPlayerInformationNotify, null, null, null, null);
		}

		// Token: 0x0600BDCE RID: 48590 RVA: 0x002C829C File Offset: 0x002C669C
		public TeamDuplicationPlayerInformationDataModel GetPlayerInformationDataModel()
		{
			if (this._playerInformationDataModel == null)
			{
				this._playerInformationDataModel = TeamDuplicationUtility.CreateTeamDuplicationPlayerInformationDataModel();
			}
			return this._playerInformationDataModel;
		}

		// Token: 0x0600BDCF RID: 48591 RVA: 0x002C82BA File Offset: 0x002C66BA
		private void ResetPlayerInformationDataModel()
		{
			if (this._playerInformationDataModel != null && this._playerInformationDataModel.AlreadyOpenDifficultyList != null)
			{
				this._playerInformationDataModel.AlreadyOpenDifficultyList.Clear();
			}
			this._playerInformationDataModel = null;
		}

		// Token: 0x0600BDD0 RID: 48592 RVA: 0x002C82F0 File Offset: 0x002C66F0
		private void OnReceiveTeamCopyTeamUpdate(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamUpdate teamCopyTeamUpdate = new TeamCopyTeamUpdate();
			teamCopyTeamUpdate.decode(msgData.bytes);
			if (teamCopyTeamUpdate.opType == 1U)
			{
				this.ResetTeamDuplicationDataByQuitTeam();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationDismissMessage, null, null, null, null);
			}
			else
			{
				this.IsTeamDuplicationOwnerTeam = true;
			}
		}

		// Token: 0x0600BDD1 RID: 48593 RVA: 0x002C8348 File Offset: 0x002C6748
		public void OnSendTeamCopyCreateTeamReq(uint teamModel, uint equipmentScore, uint goldValueNumber, uint teamDifficultyType = 0U)
		{
			TeamCopyCreateTeamReq teamCopyCreateTeamReq = new TeamCopyCreateTeamReq();
			teamCopyCreateTeamReq.teamModel = teamModel;
			teamCopyCreateTeamReq.equipScore = equipmentScore;
			teamCopyCreateTeamReq.param = goldValueNumber;
			teamCopyCreateTeamReq.teamGrade = teamDifficultyType;
			if (teamDifficultyType == 0U)
			{
				teamCopyCreateTeamReq.teamGrade = 1U;
			}
			TeamCopyType teamTypeByTeamDuplicationScene = TeamDuplicationUtility.GetTeamTypeByTeamDuplicationScene();
			teamCopyCreateTeamReq.teamType = (uint)teamTypeByTeamDuplicationScene;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyCreateTeamReq>(ServerType.GATE_SERVER, teamCopyCreateTeamReq);
			}
		}

		// Token: 0x0600BDD2 RID: 48594 RVA: 0x002C83B0 File Offset: 0x002C67B0
		private void OnReceiveTeamCopyCreateTeamRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyCreateTeamRes teamCopyCreateTeamRes = new TeamCopyCreateTeamRes();
			teamCopyCreateTeamRes.decode(msgData.bytes);
			if (teamCopyCreateTeamRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyCreateTeamRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600BDD3 RID: 48595 RVA: 0x002C83F4 File Offset: 0x002C67F4
		public void OnSendTeamCopyModifyEquipScoreReq(int teamEquipScore)
		{
			TeamCopyModifyEquipScoreReq teamCopyModifyEquipScoreReq = new TeamCopyModifyEquipScoreReq();
			teamCopyModifyEquipScoreReq.equipScore = (uint)teamEquipScore;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyModifyEquipScoreReq>(ServerType.GATE_SERVER, teamCopyModifyEquipScoreReq);
			}
		}

		// Token: 0x0600BDD4 RID: 48596 RVA: 0x002C842C File Offset: 0x002C682C
		private void OnReceiveTeamCopyModifyEquipScoreRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyModifyEquipScoreRes teamCopyModifyEquipScoreRes = new TeamCopyModifyEquipScoreRes();
			teamCopyModifyEquipScoreRes.decode(msgData.bytes);
			if (teamCopyModifyEquipScoreRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyModifyEquipScoreRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600BDD5 RID: 48597 RVA: 0x002C8470 File Offset: 0x002C6870
		public void OnSendTeamCopyTeamDataReq(int teamId, int teamDuplicationSceneId = 0)
		{
			TeamCopyTeamDataReq teamCopyTeamDataReq = new TeamCopyTeamDataReq();
			teamCopyTeamDataReq.teamId = (uint)teamId;
			TeamCopyType teamType = TeamCopyType.TC_TYPE_ONE;
			bool flag = TeamDuplicationUtility.IsTeamDuplicationSceneIdWith65Level(teamDuplicationSceneId);
			if (flag)
			{
				teamType = TeamCopyType.TC_TYPE_TWO;
			}
			teamCopyTeamDataReq.teamType = (uint)teamType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamDataReq>(ServerType.GATE_SERVER, teamCopyTeamDataReq);
			}
		}

		// Token: 0x0600BDD6 RID: 48598 RVA: 0x002C84C0 File Offset: 0x002C68C0
		private void OnReceiveTeamCopyTeamDataRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamDataRes teamCopyTeamDataRes = new TeamCopyTeamDataRes();
			teamCopyTeamDataRes.decode(msgData.bytes);
			if (teamCopyTeamDataRes.teamId <= 0U)
			{
				this.ResetTeamDuplicationDataByQuitTeam();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, null, null, null, null);
				return;
			}
			this.IsTeamDuplicationOwnerTeam = true;
			if (this._teamDataModel != null && (this._teamDataModel.TeamId == 0 || (long)this._teamDataModel.TeamId != (long)((ulong)teamCopyTeamDataRes.teamId)))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationBuildTeamSuccessMessage, null, null, null, null);
			}
			this.ResetTeamDataModel();
			TeamDuplicationUtility.UpdateTeamDataModelByTeamCopyTeamDataRes(this._teamDataModel, teamCopyTeamDataRes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, null, null, null, null);
		}

		// Token: 0x0600BDD7 RID: 48599 RVA: 0x002C8580 File Offset: 0x002C6980
		private void OnReceiveTeamCopyTeamStatusNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamStatusNotify teamCopyTeamStatusNotify = new TeamCopyTeamStatusNotify();
			teamCopyTeamStatusNotify.decode(msgData.bytes);
			if (teamCopyTeamStatusNotify.teamId <= 0U)
			{
				return;
			}
			if (!this.IsTeamDuplicationOwnerTeam)
			{
				return;
			}
			if (this._teamDataModel == null || (long)this._teamDataModel.TeamId != (long)((ulong)teamCopyTeamStatusNotify.teamId))
			{
				return;
			}
			this._teamDataModel.TeamStatus = (TeamCopyTeamStatus)teamCopyTeamStatusNotify.teamStatus;
			if (this._teamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_FAILED)
			{
				this.IsNeedShowGameFailResult = true;
			}
			else
			{
				this.IsNeedShowGameFailResult = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamStatusNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BDD8 RID: 48600 RVA: 0x002C862C File Offset: 0x002C6A2C
		public void OnSendTeamDetailReq(int teamId)
		{
			TeamCopyTeamDetailReq teamCopyTeamDetailReq = new TeamCopyTeamDetailReq();
			teamCopyTeamDetailReq.teamId = (uint)teamId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamDetailReq>(ServerType.GATE_SERVER, teamCopyTeamDetailReq);
			}
		}

		// Token: 0x0600BDD9 RID: 48601 RVA: 0x002C8664 File Offset: 0x002C6A64
		private void OnReceiveTeamCopyTeamDetailRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamDetailRes teamCopyTeamDetailRes = new TeamCopyTeamDetailRes();
			teamCopyTeamDetailRes.decode(msgData.bytes);
			if (teamCopyTeamDetailRes.teamId <= 0U)
			{
				return;
			}
			this.ResetOtherTeamDataModel();
			TeamDuplicationUtility.UpdateTeamDataModelByTeamCopyTeamDetailRes(this.OtherTeamDataModel, teamCopyTeamDetailRes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamDetailDataMessage, (int)teamCopyTeamDetailRes.teamId, null, null, null);
		}

		// Token: 0x0600BDDA RID: 48602 RVA: 0x002C86C8 File Offset: 0x002C6AC8
		private void OnReceiveTeamCopySquadNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopySquadNotify teamCopySquadNotify = new TeamCopySquadNotify();
			teamCopySquadNotify.decode(msgData.bytes);
			if (!this.IsTeamDuplicationOwnerTeam)
			{
				return;
			}
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModelByCaptainId = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByCaptainId((int)teamCopySquadNotify.squadId);
			if (teamDuplicationCaptainDataModelByCaptainId == null)
			{
				return;
			}
			teamDuplicationCaptainDataModelByCaptainId.CaptainStatus = (int)teamCopySquadNotify.squadStatus;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationCaptainNotifyMessage, (int)teamCopySquadNotify.squadId, null, null, null);
		}

		// Token: 0x0600BDDB RID: 48603 RVA: 0x002C8738 File Offset: 0x002C6B38
		public void OnSendTeamCopyTeamQuitReq()
		{
			if (!this.IsTeamDuplicationOwnerTeam)
			{
				return;
			}
			TeamCopyTeamQuitReq cmd = new TeamCopyTeamQuitReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamQuitReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BDDC RID: 48604 RVA: 0x002C8774 File Offset: 0x002C6B74
		private void OnReceiveTeamCopyTeamQuitRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamQuitRes teamCopyTeamQuitRes = new TeamCopyTeamQuitRes();
			teamCopyTeamQuitRes.decode(msgData.bytes);
			if (teamCopyTeamQuitRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyTeamQuitRes.retCode, string.Empty);
				return;
			}
			this.ResetTeamDuplicationDataByQuitTeam();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, null, null, null, null);
		}

		// Token: 0x0600BDDD RID: 48605 RVA: 0x002C87CF File Offset: 0x002C6BCF
		public List<TeamDuplicationCaptainDataModel> GetTeamDuplicationCaptainDataModelList()
		{
			if (this._teamDataModel == null || this._teamDataModel.CaptainDataModelList == null)
			{
				return null;
			}
			return this._teamDataModel.CaptainDataModelList;
		}

		// Token: 0x0600BDDE RID: 48606 RVA: 0x002C87F9 File Offset: 0x002C6BF9
		public TeamDuplicationTeamDataModel GetTeamDuplicationTeamDataModel()
		{
			return this._teamDataModel;
		}

		// Token: 0x0600BDDF RID: 48607 RVA: 0x002C8804 File Offset: 0x002C6C04
		public void OnSendTeamCopyTeamListReq(int pageNumber, int teamDuplicationTeamModel = 0)
		{
			TeamCopyTeamListReq teamCopyTeamListReq = new TeamCopyTeamListReq();
			teamCopyTeamListReq.pageNum = (uint)pageNumber;
			teamCopyTeamListReq.teamModel = (uint)teamDuplicationTeamModel;
			TeamCopyType teamTypeByTeamDuplicationScene = TeamDuplicationUtility.GetTeamTypeByTeamDuplicationScene();
			teamCopyTeamListReq.teamType = (uint)teamTypeByTeamDuplicationScene;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamListReq>(ServerType.GATE_SERVER, teamCopyTeamListReq);
			}
		}

		// Token: 0x0600BDE0 RID: 48608 RVA: 0x002C8850 File Offset: 0x002C6C50
		private void OnReceiveTeamCopyTeamListRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamListRes teamCopyTeamListRes = new TeamCopyTeamListRes();
			teamCopyTeamListRes.decode(msgData.bytes);
			this.TeamListCurrentPage = (int)teamCopyTeamListRes.curPage;
			this.TeamListTotalPage = (int)teamCopyTeamListRes.totalPageNum;
			this._teamListDataModelList.Clear();
			if (teamCopyTeamListRes.teamList != null && teamCopyTeamListRes.teamList.Length > 0)
			{
				for (int i = 0; i < teamCopyTeamListRes.teamList.Length; i++)
				{
					TeamCopyTeamProperty teamCopyTeamProperty = teamCopyTeamListRes.teamList[i];
					if (teamCopyTeamProperty != null)
					{
						TeamDuplicationTeamListDataModel teamDuplicationTeamListDataModel = new TeamDuplicationTeamListDataModel();
						teamDuplicationTeamListDataModel.TeamId = teamCopyTeamProperty.teamId;
						teamDuplicationTeamListDataModel.TeamModel = (TeamCopyTeamModel)teamCopyTeamProperty.teamModel;
						teamDuplicationTeamListDataModel.TeamType = (TeamCopyType)teamCopyTeamProperty.teamType;
						teamDuplicationTeamListDataModel.GoldValue = (int)teamCopyTeamProperty.commission;
						teamDuplicationTeamListDataModel.TeamName = teamCopyTeamProperty.teamName;
						teamDuplicationTeamListDataModel.TeamHardLevel = teamCopyTeamProperty.teamGrade;
						teamDuplicationTeamListDataModel.TeamNumber = (int)teamCopyTeamProperty.memberNum;
						teamDuplicationTeamListDataModel.EquipmentScore = (int)teamCopyTeamProperty.equipScore;
						teamDuplicationTeamListDataModel.TroopStatus = (int)teamCopyTeamProperty.status;
						this._teamListDataModelList.Add(teamDuplicationTeamListDataModel);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamListRes, null, null, null, null);
		}

		// Token: 0x0600BDE1 RID: 48609 RVA: 0x002C896C File Offset: 0x002C6D6C
		private void OnReceiveTeamCopyMemberNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyMemberNotify teamCopyMemberNotify = new TeamCopyMemberNotify();
			teamCopyMemberNotify.decode(msgData.bytes);
			if (teamCopyMemberNotify.memberName == null)
			{
				return;
			}
			string msgContent = string.Format(TR.Value("team_duplication_leave_team"), teamCopyMemberNotify.memberName);
			if (teamCopyMemberNotify.flag == 0U)
			{
				msgContent = string.Format(TR.Value("team_duplication_join_in_team"), teamCopyMemberNotify.memberName);
			}
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BDE2 RID: 48610 RVA: 0x002C89E0 File Offset: 0x002C6DE0
		public void OnSendTeamCopyAutoAgreeGoldReq(bool isAutoAgree)
		{
			TeamCopyAutoAgreeGoldReq teamCopyAutoAgreeGoldReq = new TeamCopyAutoAgreeGoldReq();
			teamCopyAutoAgreeGoldReq.isAutoAgree = 0U;
			if (isAutoAgree)
			{
				teamCopyAutoAgreeGoldReq.isAutoAgree = 1U;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyAutoAgreeGoldReq>(ServerType.GATE_SERVER, teamCopyAutoAgreeGoldReq);
			}
		}

		// Token: 0x0600BDE3 RID: 48611 RVA: 0x002C8A24 File Offset: 0x002C6E24
		private void OnReceiveTeamCopyAutoAgreeGoldRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyAutoAgreeGoldRes teamCopyAutoAgreeGoldRes = new TeamCopyAutoAgreeGoldRes();
			teamCopyAutoAgreeGoldRes.decode(msgData.bytes);
			if (teamCopyAutoAgreeGoldRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyAutoAgreeGoldRes.retCode, string.Empty);
				return;
			}
			if (this._teamDataModel == null)
			{
				return;
			}
			this._teamDataModel.AutoAgreeGold = (teamCopyAutoAgreeGoldRes.isAutoAgree != 0U);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationAutoAgreeGoldMessage, null, null, null, null);
		}

		// Token: 0x0600BDE4 RID: 48612 RVA: 0x002C8A9C File Offset: 0x002C6E9C
		public void OnSendTeamCopyTeamApplyReq(int teamId)
		{
			TeamCopyTeamApplyReq teamCopyTeamApplyReq = new TeamCopyTeamApplyReq();
			teamCopyTeamApplyReq.teamId = (uint)teamId;
			teamCopyTeamApplyReq.isGold = 0U;
			if (this.IsTeamDuplicationGoldOwner)
			{
				teamCopyTeamApplyReq.isGold = 1U;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamApplyReq>(ServerType.GATE_SERVER, teamCopyTeamApplyReq);
			}
		}

		// Token: 0x0600BDE5 RID: 48613 RVA: 0x002C8AEC File Offset: 0x002C6EEC
		private void OnReceiveTeamCopyTeamApplyRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamApplyRes teamCopyTeamApplyRes = new TeamCopyTeamApplyRes();
			teamCopyTeamApplyRes.decode(msgData.bytes);
			if (teamCopyTeamApplyRes.retCode != 0U)
			{
				if (teamCopyTeamApplyRes.expireTime > 0UL)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_can_not_join_in_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					int teamId = (int)teamCopyTeamApplyRes.teamId;
					this.SetTeamRequestJoinInEndTime(teamId, (int)teamCopyTeamApplyRes.expireTime);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationJoinTeamInCdTimeMessage, teamId, null, null, null);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)teamCopyTeamApplyRes.retCode, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationRefreshTeamListMessage, null, null, null, null);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_request_team_join_in"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationRefreshTeamListMessage, null, null, null, null);
			}
		}

		// Token: 0x0600BDE6 RID: 48614 RVA: 0x002C8BBC File Offset: 0x002C6FBC
		private void OnReceiveTeamCopyApplyNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyApplyNotify teamCopyApplyNotify = new TeamCopyApplyNotify();
			teamCopyApplyNotify.decode(msgData.bytes);
			this.IsTeamDuplicationOwnerNewRequester = (teamCopyApplyNotify.IsHasApply == 1U);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, null, null, null, null);
		}

		// Token: 0x0600BDE7 RID: 48615 RVA: 0x002C8C10 File Offset: 0x002C7010
		private void OnReceiveTeamCopyApplyRefuseNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyApplyRefuseNotify teamCopyApplyRefuseNotify = new TeamCopyApplyRefuseNotify();
			teamCopyApplyRefuseNotify.decode(msgData.bytes);
			if (string.IsNullOrEmpty(teamCopyApplyRefuseNotify.chiefName))
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamLeaderRefuseJoinInMessage, teamCopyApplyRefuseNotify.chiefName, null, null, null);
		}

		// Token: 0x0600BDE8 RID: 48616 RVA: 0x002C8C60 File Offset: 0x002C7060
		public void OnSendTeamCopyTeamApplyListReq()
		{
			TeamCopyTeamApplyListReq cmd = new TeamCopyTeamApplyListReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamApplyListReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BDE9 RID: 48617 RVA: 0x002C8C90 File Offset: 0x002C7090
		private void OnReceiveTeamCopyTeamApplyListRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamApplyListRes teamCopyTeamApplyListRes = new TeamCopyTeamApplyListRes();
			teamCopyTeamApplyListRes.decode(msgData.bytes);
			this.ResetTeamRequesterDataModelList();
			if (teamCopyTeamApplyListRes.applyList != null && teamCopyTeamApplyListRes.applyList.Length > 0)
			{
				for (int i = 0; i < teamCopyTeamApplyListRes.applyList.Length; i++)
				{
					TeamCopyApplyProperty teamCopyApplyProperty = teamCopyTeamApplyListRes.applyList[i];
					if (teamCopyApplyProperty != null)
					{
						TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = new TeamDuplicationRequesterDataModel();
						TeamDuplicationUtility.UpdateTeamDuplicationRequesterDataModel(teamCopyApplyProperty, teamDuplicationRequesterDataModel);
						this._teamRequesterDataModelList.Add(teamDuplicationRequesterDataModel);
					}
				}
			}
			TeamDuplicationUtility.SortTeamDuplicationRequesterDataModelList(this._teamRequesterDataModelList);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationRequesterListMessage, null, null, null, null);
		}

		// Token: 0x0600BDEA RID: 48618 RVA: 0x002C8D34 File Offset: 0x002C7134
		public void OnSendTeamCopyTeamApplyReplyReq(bool isAgree, List<ulong> playerIdList)
		{
			TeamCopyTeamApplyReplyReq teamCopyTeamApplyReplyReq = new TeamCopyTeamApplyReplyReq();
			teamCopyTeamApplyReplyReq.isAgree = 0U;
			if (isAgree)
			{
				teamCopyTeamApplyReplyReq.isAgree = 1U;
			}
			if (playerIdList != null && playerIdList.Count > 0)
			{
				teamCopyTeamApplyReplyReq.playerIds = playerIdList.ToArray();
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyTeamApplyReplyReq>(ServerType.GATE_SERVER, teamCopyTeamApplyReplyReq);
			}
		}

		// Token: 0x0600BDEB RID: 48619 RVA: 0x002C8D94 File Offset: 0x002C7194
		private void OnReceiveTeamCopyTeamApplyReplyRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTeamApplyReplyRes teamCopyTeamApplyReplyRes = new TeamCopyTeamApplyReplyRes();
			teamCopyTeamApplyReplyRes.decode(msgData.bytes);
			if (teamCopyTeamApplyReplyRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyTeamApplyReplyRes.retCode, string.Empty);
			}
			if (teamCopyTeamApplyReplyRes.playerIds.Length == 0)
			{
				return;
			}
			for (int i = 0; i < teamCopyTeamApplyReplyRes.playerIds.Length; i++)
			{
				ulong num = teamCopyTeamApplyReplyRes.playerIds[i];
				if (this._teamRequesterDataModelList != null && this._teamRequesterDataModelList.Count > 0)
				{
					for (int j = 0; j < this._teamRequesterDataModelList.Count; j++)
					{
						TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = this._teamRequesterDataModelList[j];
						if (teamDuplicationRequesterDataModel != null)
						{
							if (teamDuplicationRequesterDataModel.PlayerGuid == num)
							{
								this._teamRequesterDataModelList.RemoveAt(j);
								break;
							}
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationRequesterListMessage, null, null, null, null);
		}

		// Token: 0x0600BDEC RID: 48620 RVA: 0x002C8E88 File Offset: 0x002C7288
		public List<TeamDuplicationRequesterDataModel> GetRequesterDataModelList()
		{
			return this._teamRequesterDataModelList;
		}

		// Token: 0x0600BDED RID: 48621 RVA: 0x002C8E90 File Offset: 0x002C7290
		public void ResetTeamRequesterDataModelList()
		{
			if (this._teamRequesterDataModelList != null)
			{
				this._teamRequesterDataModelList.Clear();
			}
		}

		// Token: 0x0600BDEE RID: 48622 RVA: 0x002C8EA8 File Offset: 0x002C72A8
		public void ResetTeamRequestJoinInEndTimeDic()
		{
			if (this._teamRequestJoinInEndTimeDic != null)
			{
				this._teamRequestJoinInEndTimeDic.Clear();
			}
		}

		// Token: 0x0600BDEF RID: 48623 RVA: 0x002C8EC0 File Offset: 0x002C72C0
		public int GetTeamRequestJoinInEndTime(int teamId)
		{
			int result = 0;
			if (this._teamRequestJoinInEndTimeDic == null)
			{
				return 0;
			}
			if (this._teamRequestJoinInEndTimeDic.ContainsKey(teamId))
			{
				result = this._teamRequestJoinInEndTimeDic[teamId];
			}
			return result;
		}

		// Token: 0x0600BDF0 RID: 48624 RVA: 0x002C8EFB File Offset: 0x002C72FB
		public void SetTeamRequestJoinInEndTime(int teamId, int joinInTime)
		{
			if (this._teamRequestJoinInEndTimeDic == null)
			{
				return;
			}
			this._teamRequestJoinInEndTimeDic[teamId] = joinInTime;
		}

		// Token: 0x0600BDF1 RID: 48625 RVA: 0x002C8F18 File Offset: 0x002C7318
		public void OnSendTeamCopyFindTeamMateReq()
		{
			TeamCopyFindTeamMateReq cmd = new TeamCopyFindTeamMateReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyFindTeamMateReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BDF2 RID: 48626 RVA: 0x002C8F48 File Offset: 0x002C7348
		private void OnReceiveTeamCopyFindTeamMateRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyFindTeamMateRes teamCopyFindTeamMateRes = new TeamCopyFindTeamMateRes();
			teamCopyFindTeamMateRes.decode(msgData.bytes);
			this.ResetTeamFriendDataModelList();
			if (teamCopyFindTeamMateRes.playerList != null && teamCopyFindTeamMateRes.playerList.Length > 0)
			{
				for (int i = 0; i < teamCopyFindTeamMateRes.playerList.Length; i++)
				{
					TeamCopyApplyProperty teamCopyApplyProperty = teamCopyFindTeamMateRes.playerList[i];
					if (teamCopyApplyProperty != null)
					{
						TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = new TeamDuplicationRequesterDataModel();
						TeamDuplicationUtility.UpdateTeamDuplicationRequesterDataModel(teamCopyApplyProperty, teamDuplicationRequesterDataModel);
						this._teamFriendDataModelList.Add(teamDuplicationRequesterDataModel);
					}
				}
			}
			TeamDuplicationUtility.SortTeamDuplicationRequesterDataModelList(this._teamFriendDataModelList);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamMateListMessage, null, null, null, null);
		}

		// Token: 0x0600BDF3 RID: 48627 RVA: 0x002C8FEC File Offset: 0x002C73EC
		public void OnSendTeamCopyInvitePlayer(List<ulong> invitePlayerIdList)
		{
			TeamCopyInvitePlayer teamCopyInvitePlayer = new TeamCopyInvitePlayer();
			if (invitePlayerIdList != null && invitePlayerIdList.Count > 0)
			{
				teamCopyInvitePlayer.inviteList = invitePlayerIdList.ToArray();
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyInvitePlayer>(ServerType.GATE_SERVER, teamCopyInvitePlayer);
			}
		}

		// Token: 0x0600BDF4 RID: 48628 RVA: 0x002C9038 File Offset: 0x002C7438
		private void ResetTeamFriendDataModelList()
		{
			if (this._teamFriendDataModelList != null)
			{
				this._teamFriendDataModelList.Clear();
			}
		}

		// Token: 0x0600BDF5 RID: 48629 RVA: 0x002C9050 File Offset: 0x002C7450
		public List<TeamDuplicationRequesterDataModel> GetTeamFriendDataModelList()
		{
			return this._teamFriendDataModelList;
		}

		// Token: 0x0600BDF6 RID: 48630 RVA: 0x002C9058 File Offset: 0x002C7458
		private void OnReceiveTeamCopyInviteNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyInviteNotify stream = new TeamCopyInviteNotify();
			stream.decode(msgData.bytes);
			this.IsTeamDuplicationOwnerNewInvite = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, null, null, null, null);
		}

		// Token: 0x0600BDF7 RID: 48631 RVA: 0x002C9098 File Offset: 0x002C7498
		public void OnSendTeamCopyInviteListReq()
		{
			TeamCopyInviteListReq cmd = new TeamCopyInviteListReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyInviteListReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BDF8 RID: 48632 RVA: 0x002C90C8 File Offset: 0x002C74C8
		private void OnReceiveTeamCopyInviteListRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyInviteListRes teamCopyInviteListRes = new TeamCopyInviteListRes();
			teamCopyInviteListRes.decode(msgData.bytes);
			this.TeamInviteDataModelList.Clear();
			if (teamCopyInviteListRes.inviteList != null && teamCopyInviteListRes.inviteList.Length > 0)
			{
				for (int i = 0; i < teamCopyInviteListRes.inviteList.Length; i++)
				{
					TCInviteInfo tcInviteInfo = teamCopyInviteListRes.inviteList[i];
					TeamDuplicationTeamInviteDataModel teamDuplicationTeamInviteDataModel = new TeamDuplicationTeamInviteDataModel();
					TeamDuplicationUtility.UpdateTeamDuplicationTeamInviteDataModel(tcInviteInfo, teamDuplicationTeamInviteDataModel);
					this.TeamInviteDataModelList.Add(teamDuplicationTeamInviteDataModel);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamInviteListMessage, null, null, null, null);
		}

		// Token: 0x0600BDF9 RID: 48633 RVA: 0x002C9160 File Offset: 0x002C7560
		public void OnSendTeamCopyInviteChoiceReq(bool isAgree, List<uint> teamIdList)
		{
			TeamCopyInviteChoiceReq teamCopyInviteChoiceReq = new TeamCopyInviteChoiceReq();
			teamCopyInviteChoiceReq.isAgree = 0U;
			if (isAgree)
			{
				teamCopyInviteChoiceReq.isAgree = 1U;
			}
			teamCopyInviteChoiceReq.teamId = teamIdList.ToArray();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyInviteChoiceReq>(ServerType.GATE_SERVER, teamCopyInviteChoiceReq);
			}
		}

		// Token: 0x0600BDFA RID: 48634 RVA: 0x002C91B0 File Offset: 0x002C75B0
		private void OnReceiveTeamCopyInviteChoiceRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyInviteChoiceRes teamCopyInviteChoiceRes = new TeamCopyInviteChoiceRes();
			teamCopyInviteChoiceRes.decode(msgData.bytes);
			if (teamCopyInviteChoiceRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyInviteChoiceRes.retCode, string.Empty);
				return;
			}
			if (teamCopyInviteChoiceRes.teamId != null && teamCopyInviteChoiceRes.teamId.Length > 0)
			{
				for (int i = 0; i < teamCopyInviteChoiceRes.teamId.Length; i++)
				{
					uint num = teamCopyInviteChoiceRes.teamId[i];
					if (this.TeamInviteDataModelList != null && this.TeamInviteDataModelList.Count > 0)
					{
						for (int j = 0; j < this.TeamInviteDataModelList.Count; j++)
						{
							TeamDuplicationTeamInviteDataModel teamDuplicationTeamInviteDataModel = this.TeamInviteDataModelList[j];
							if (teamDuplicationTeamInviteDataModel != null)
							{
								if (teamDuplicationTeamInviteDataModel.TeamId == num)
								{
									this.TeamInviteDataModelList.RemoveAt(j);
									break;
								}
							}
						}
					}
				}
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_build_team_refuse_invite"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationTeamInviteChoiceMessage, null, null, null, null);
			}
		}

		// Token: 0x0600BDFB RID: 48635 RVA: 0x002C92C4 File Offset: 0x002C76C4
		public void OnSendTeamRecruitReq()
		{
			TeamCopyRecruitReq cmd = new TeamCopyRecruitReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyRecruitReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BDFC RID: 48636 RVA: 0x002C92F4 File Offset: 0x002C76F4
		private void OnReceiveTeamRecruitRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyRecruitRes teamCopyRecruitRes = new TeamCopyRecruitRes();
			teamCopyRecruitRes.decode(msgData.bytes);
			if (teamCopyRecruitRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyRecruitRes.retCode, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_quick_chat_message_send"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BDFD RID: 48637 RVA: 0x002C9348 File Offset: 0x002C7748
		public void OnSendTeamCopyLinkJoinReq(int teamId)
		{
			TeamCopyLinkJoinReq teamCopyLinkJoinReq = new TeamCopyLinkJoinReq();
			teamCopyLinkJoinReq.teamId = (uint)teamId;
			teamCopyLinkJoinReq.isGold = 0U;
			if (this.IsTeamDuplicationGoldOwner)
			{
				teamCopyLinkJoinReq.isGold = 1U;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyLinkJoinReq>(ServerType.GATE_SERVER, teamCopyLinkJoinReq);
			}
		}

		// Token: 0x0600BDFE RID: 48638 RVA: 0x002C9398 File Offset: 0x002C7798
		private void OnReceiveTeamCopyLinkJoinRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyLinkJoinRes teamCopyLinkJoinRes = new TeamCopyLinkJoinRes();
			teamCopyLinkJoinRes.decode(msgData.bytes);
			if (teamCopyLinkJoinRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyLinkJoinRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600BDFF RID: 48639 RVA: 0x002C93DA File Offset: 0x002C77DA
		public void ResetTeamDuplicationTeamInviteDataModelList()
		{
			if (this.TeamInviteDataModelList != null)
			{
				this.TeamInviteDataModelList.Clear();
			}
		}

		// Token: 0x0600BE00 RID: 48640 RVA: 0x002C93F4 File Offset: 0x002C77F4
		public void OnReceiveTeamCopyAppointmentNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyAppointmentNotify teamCopyAppointmentNotify = new TeamCopyAppointmentNotify();
			teamCopyAppointmentNotify.decode(msgData.bytes);
			if (teamCopyAppointmentNotify.post == 8U)
			{
				string msgContent = string.Format(TR.Value("team_duplication_appoint_player_to_team_leader"), teamCopyAppointmentNotify.name);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (teamCopyAppointmentNotify.post == 4U)
			{
				string msgContent2 = string.Format(TR.Value("team_duplication_appoint_player_to_captain"), teamCopyAppointmentNotify.name);
				SystemNotifyManager.SysNotifyFloatingEffect(msgContent2, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600BE01 RID: 48641 RVA: 0x002C9474 File Offset: 0x002C7874
		public void OnSendTeamCopyKickReq(ulong playerId)
		{
			TeamCopyKickReq teamCopyKickReq = new TeamCopyKickReq();
			teamCopyKickReq.playerId = playerId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyKickReq>(ServerType.GATE_SERVER, teamCopyKickReq);
			}
		}

		// Token: 0x0600BE02 RID: 48642 RVA: 0x002C94AC File Offset: 0x002C78AC
		private void OnReceiveTeamCopyKickRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyKickRes teamCopyKickRes = new TeamCopyKickRes();
			teamCopyKickRes.decode(msgData.bytes);
			if (teamCopyKickRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyKickRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600BE03 RID: 48643 RVA: 0x002C94F0 File Offset: 0x002C78F0
		public void OnSendTeamCopyAppointmentReq(ulong playerId, int post)
		{
			TeamCopyAppointmentReq teamCopyAppointmentReq = new TeamCopyAppointmentReq();
			teamCopyAppointmentReq.playerId = playerId;
			teamCopyAppointmentReq.post = (uint)post;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyAppointmentReq>(ServerType.GATE_SERVER, teamCopyAppointmentReq);
			}
		}

		// Token: 0x0600BE04 RID: 48644 RVA: 0x002C952C File Offset: 0x002C792C
		private void OnReceiveTeamCopyAppointmentRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyAppointmentRes teamCopyAppointmentRes = new TeamCopyAppointmentRes();
			teamCopyAppointmentRes.decode(msgData.bytes);
			if (teamCopyAppointmentRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyAppointmentRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600BE05 RID: 48645 RVA: 0x002C9570 File Offset: 0x002C7970
		public void OnSendTeamCopyChangeSeatReq(int srcSeat, int destSeat)
		{
			TeamCopyChangeSeatReq teamCopyChangeSeatReq = new TeamCopyChangeSeatReq();
			teamCopyChangeSeatReq.srcSeat = (uint)srcSeat;
			teamCopyChangeSeatReq.destSeat = (uint)destSeat;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyChangeSeatReq>(ServerType.GATE_SERVER, teamCopyChangeSeatReq);
			}
		}

		// Token: 0x0600BE06 RID: 48646 RVA: 0x002C95AC File Offset: 0x002C79AC
		private void OnReceiveTeamCopyChangeSeatRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyChangeSeatRes teamCopyChangeSeatRes = new TeamCopyChangeSeatRes();
			teamCopyChangeSeatRes.decode(msgData.bytes);
			if (teamCopyChangeSeatRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyChangeSeatRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600BE07 RID: 48647 RVA: 0x002C95F0 File Offset: 0x002C79F0
		public void OnSendTeamCopyStartBattleReq(TeamCopyPlanModel teamCopyPlanModel, bool isIn65LevelTeamDuplication = false)
		{
			TeamCopyStartBattleReq teamCopyStartBattleReq = new TeamCopyStartBattleReq();
			if (!isIn65LevelTeamDuplication)
			{
				if (teamCopyPlanModel == TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_INVALID)
				{
					teamCopyStartBattleReq.planModel = 2U;
					TeamDuplicationUtility.SetTeamDuplicationDefaultCaptainDifficultySetting();
					if (this._teamConfigDataModelList != null && this._teamConfigDataModelList.Count > 0)
					{
						int count = this._teamConfigDataModelList.Count;
						teamCopyStartBattleReq.battlePlanList = new TeamCopyBattlePlan[count];
						for (int i = 0; i < count; i++)
						{
							TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = this._teamConfigDataModelList[i];
							if (teamDuplicationTeamDifficultyConfigDataModel != null)
							{
								TeamCopyBattlePlan teamCopyBattlePlan = new TeamCopyBattlePlan();
								teamCopyBattlePlan.difficulty = (uint)teamDuplicationTeamDifficultyConfigDataModel.Difficulty;
								teamCopyBattlePlan.squadId = (uint)teamDuplicationTeamDifficultyConfigDataModel.TeamId;
								teamCopyStartBattleReq.battlePlanList[i] = teamCopyBattlePlan;
							}
						}
					}
				}
				else
				{
					teamCopyStartBattleReq.planModel = (uint)teamCopyPlanModel;
					if (teamCopyPlanModel == TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_GUIDE && this._teamConfigDataModelList != null && this._teamConfigDataModelList.Count > 0)
					{
						int count2 = this._teamConfigDataModelList.Count;
						teamCopyStartBattleReq.battlePlanList = new TeamCopyBattlePlan[count2];
						for (int j = 0; j < count2; j++)
						{
							TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel2 = this._teamConfigDataModelList[j];
							if (teamDuplicationTeamDifficultyConfigDataModel2 != null)
							{
								TeamCopyBattlePlan teamCopyBattlePlan2 = new TeamCopyBattlePlan();
								teamCopyBattlePlan2.difficulty = (uint)teamDuplicationTeamDifficultyConfigDataModel2.Difficulty;
								teamCopyBattlePlan2.squadId = (uint)teamDuplicationTeamDifficultyConfigDataModel2.TeamId;
								teamCopyStartBattleReq.battlePlanList[j] = teamCopyBattlePlan2;
							}
						}
					}
				}
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyStartBattleReq>(ServerType.GATE_SERVER, teamCopyStartBattleReq);
			}
		}

		// Token: 0x0600BE08 RID: 48648 RVA: 0x002C976C File Offset: 0x002C7B6C
		private void OnReceiveTeamCopyStartBattleRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStartBattleRes teamCopyStartBattleRes = new TeamCopyStartBattleRes();
			teamCopyStartBattleRes.decode(msgData.bytes);
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>((int)teamCopyStartBattleRes.retCode, string.Empty, string.Empty);
			if (tableItem == null || string.IsNullOrEmpty(tableItem.Descs))
			{
				return;
			}
			string msgContent = string.Format(tableItem.Descs, teamCopyStartBattleRes.roleName);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BE09 RID: 48649 RVA: 0x002C97E0 File Offset: 0x002C7BE0
		private void OnReceiveTeamCopyStartBattleNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStartBattleNotify teamCopyStartBattleNotify = new TeamCopyStartBattleNotify();
			teamCopyStartBattleNotify.decode(msgData.bytes);
			this.ResetFightStartVoteData();
			this.StartBattleVoteIntervalTime = (int)teamCopyStartBattleNotify.voteDurationTime;
			this.StartBattleVoteEndTime = (int)teamCopyStartBattleNotify.voteEndTime;
			this.IsInStartBattleVotingTime = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationCloseRelationFrame, null, null, null, null);
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			TeamDuplicationUtility.OnOpenTeamDuplicationFightStartVoteFrame();
		}

		// Token: 0x0600BE0A RID: 48650 RVA: 0x002C9848 File Offset: 0x002C7C48
		public void OnSendTeamCopyStartBattleVote(bool isAgree)
		{
			TeamCopyStartBattleVote teamCopyStartBattleVote = new TeamCopyStartBattleVote();
			teamCopyStartBattleVote.vote = 1U;
			if (!isAgree)
			{
				teamCopyStartBattleVote.vote = 0U;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyStartBattleVote>(ServerType.GATE_SERVER, teamCopyStartBattleVote);
			}
		}

		// Token: 0x0600BE0B RID: 48651 RVA: 0x002C988C File Offset: 0x002C7C8C
		private void OnReceiveTeamCopyVoteNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyVoteNotify teamCopyVoteNotify = new TeamCopyVoteNotify();
			teamCopyVoteNotify.decode(msgData.bytes);
			if (teamCopyVoteNotify.vote == 0U)
			{
				TeamDuplicationPlayerDataModel playerDataModelByGuid = TeamDuplicationUtility.GetPlayerDataModelByGuid(teamCopyVoteNotify.roleId);
				if (playerDataModelByGuid != null && !string.IsNullOrEmpty(playerDataModelByGuid.Name))
				{
					string msgContent = string.Format(TR.Value("team_duplication_player_refuse_start_battle"), playerDataModelByGuid.Name);
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				this.ResetFightStartVoteData();
				TeamDuplicationUtility.OnCloseTeamDuplicationFightStartVoteFrame();
			}
			else
			{
				this.AddPlayerGuidToFightStartVoteAgreeList(teamCopyVoteNotify.roleId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStartVoteAgreeMessage, teamCopyVoteNotify.roleId, null, null, null);
			}
		}

		// Token: 0x0600BE0C RID: 48652 RVA: 0x002C9938 File Offset: 0x002C7D38
		private void OnReceiveTeamCopyVoteFinish(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyVoteFinish teamCopyVoteFinish = new TeamCopyVoteFinish();
			teamCopyVoteFinish.decode(msgData.bytes);
			this.ResetFightStartVoteData();
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStartVoteFrame();
			if (teamCopyVoteFinish.result == 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationInBattleMessage, null, null, null, null);
			}
			else
			{
				string text = string.Empty;
				if (teamCopyVoteFinish.notVotePlayer != null && teamCopyVoteFinish.notVotePlayer.Length > 0)
				{
					for (int i = 0; i < teamCopyVoteFinish.notVotePlayer.Length; i++)
					{
						string str = teamCopyVoteFinish.notVotePlayer[i];
						text = text + str + ".";
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_start_battle_by_player_refuse"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format(TR.Value("team_duplication_start_battle_by_player_not_enough"), text), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
		}

		// Token: 0x0600BE0D RID: 48653 RVA: 0x002C9A12 File Offset: 0x002C7E12
		public List<ulong> GetFightStartVoteAgreeList()
		{
			return this._fightStartVoteAgreeList;
		}

		// Token: 0x0600BE0E RID: 48654 RVA: 0x002C9A1C File Offset: 0x002C7E1C
		private void AddPlayerGuidToFightStartVoteAgreeList(ulong guid)
		{
			if (guid == 0UL)
			{
				return;
			}
			if (this._fightStartVoteAgreeList == null)
			{
				this._fightStartVoteAgreeList = new List<ulong>();
			}
			bool flag = false;
			for (int i = 0; i < this._fightStartVoteAgreeList.Count; i++)
			{
				if (this._fightStartVoteAgreeList[i] == guid)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this._fightStartVoteAgreeList.Add(guid);
			}
		}

		// Token: 0x0600BE0F RID: 48655 RVA: 0x002C9A91 File Offset: 0x002C7E91
		private void ResetFightStartVoteData()
		{
			if (this._fightStartVoteAgreeList != null)
			{
				this._fightStartVoteAgreeList.Clear();
			}
			this.StartBattleVoteEndTime = 0;
			this.StartBattleVoteIntervalTime = 0;
			this.FightVoteAgreeBySwitchFightScene = false;
			this.IsInStartBattleVotingTime = false;
		}

		// Token: 0x0600BE10 RID: 48656 RVA: 0x002C9AC8 File Offset: 0x002C7EC8
		private void OnReceiveTeamCopyForceEndFlag(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyForceEndFlag stream = new TeamCopyForceEndFlag();
			stream.decode(msgData.bytes);
			this.TeamDuplicationFightEndVoteFlag = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightEndVoteFlagMessage, null, null, null, null);
		}

		// Token: 0x0600BE11 RID: 48657 RVA: 0x002C9B08 File Offset: 0x002C7F08
		public void OnSendTeamCopyForceEndReq()
		{
			TeamCopyForceEndReq cmd = new TeamCopyForceEndReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyForceEndReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600BE12 RID: 48658 RVA: 0x002C9B38 File Offset: 0x002C7F38
		public void OnReceiveTeamCopyForceEndRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyForceEndRes teamCopyForceEndRes = new TeamCopyForceEndRes();
			teamCopyForceEndRes.decode(msgData.bytes);
			if (teamCopyForceEndRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyForceEndRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600BE13 RID: 48659 RVA: 0x002C9B7C File Offset: 0x002C7F7C
		public void OnReceiveTeamCopyEndVoteNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			this.ResetFightEndVoteData();
			TeamCopyForceEndVoteNotify teamCopyForceEndVoteNotify = new TeamCopyForceEndVoteNotify();
			teamCopyForceEndVoteNotify.decode(msgData.bytes);
			this.FightEndVoteIntervalTime = (int)teamCopyForceEndVoteNotify.voteDurationTime;
			this.FightEndVoteEndTime = (int)teamCopyForceEndVoteNotify.voteEndTime;
			if (!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam())
			{
				return;
			}
			if (!TeamDuplicationUtility.IsTeamDuplicationInFightScene())
			{
				return;
			}
			if (!TeamDuplicationUtility.IsTeamDuplicationInFightingStatus())
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationCloseRelationFrame, null, null, null, null);
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			TeamDuplicationUtility.OnOpenTeamDuplicationFightEndVoteFrame();
		}

		// Token: 0x0600BE14 RID: 48660 RVA: 0x002C9C00 File Offset: 0x002C8000
		public void OnSendTeamCopyForceEndVoteReq(bool isAgree)
		{
			TeamCopyForceEndVoteReq teamCopyForceEndVoteReq = new TeamCopyForceEndVoteReq();
			teamCopyForceEndVoteReq.vote = 1U;
			if (!isAgree)
			{
				teamCopyForceEndVoteReq.vote = 0U;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyForceEndVoteReq>(ServerType.GATE_SERVER, teamCopyForceEndVoteReq);
			}
		}

		// Token: 0x0600BE15 RID: 48661 RVA: 0x002C9C44 File Offset: 0x002C8044
		public void OnReceiveTeamCopyForceEndMemberVoteNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyForceEndMemberVote teamCopyForceEndMemberVote = new TeamCopyForceEndMemberVote();
			teamCopyForceEndMemberVote.decode(msgData.bytes);
			ulong roleId = teamCopyForceEndMemberVote.roleId;
			if (teamCopyForceEndMemberVote.vote == 0U)
			{
				this.AddPlayerGuidToFightEndVoteRefuseList(roleId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightEndVoteRefuseMessage, roleId, null, null, null);
			}
			else
			{
				this.AddPlayerGuidToFightEndVoteAgreeList(roleId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightEndVoteAgreeMessage, roleId, null, null, null);
			}
		}

		// Token: 0x0600BE16 RID: 48662 RVA: 0x002C9CC4 File Offset: 0x002C80C4
		public void OnReceiveTeamCopyForceEndVoteResultNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyForceEndVoteResult teamCopyForceEndVoteResult = new TeamCopyForceEndVoteResult();
			teamCopyForceEndVoteResult.decode(msgData.bytes);
			TeamDuplicationUtility.OnCloseTeamDuplicationFightEndVoteFrame();
			this.ResetFightEndVoteData();
			if (teamCopyForceEndVoteResult.result == 0U)
			{
				this.TeamDuplicationFightEndVoteFlag = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage, null, null, null, null);
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_end_vote_succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_end_vote_fail"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600BE17 RID: 48663 RVA: 0x002C9D44 File Offset: 0x002C8144
		private void AddPlayerGuidToFightEndVoteRefuseList(ulong guid)
		{
			if (guid == 0UL)
			{
				return;
			}
			if (this.FightEndVoteRefuseList == null)
			{
				this.FightEndVoteRefuseList = new List<ulong>();
			}
			bool flag = false;
			for (int i = 0; i < this.FightEndVoteRefuseList.Count; i++)
			{
				if (this.FightEndVoteRefuseList[i] == guid)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.FightEndVoteRefuseList.Add(guid);
			}
		}

		// Token: 0x0600BE18 RID: 48664 RVA: 0x002C9DBC File Offset: 0x002C81BC
		private void AddPlayerGuidToFightEndVoteAgreeList(ulong guid)
		{
			if (guid == 0UL)
			{
				return;
			}
			if (this.FightEndVoteAgreeList == null)
			{
				this.FightEndVoteAgreeList = new List<ulong>();
			}
			bool flag = false;
			for (int i = 0; i < this.FightEndVoteAgreeList.Count; i++)
			{
				if (this.FightEndVoteAgreeList[i] == guid)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.FightEndVoteAgreeList.Add(guid);
			}
		}

		// Token: 0x0600BE19 RID: 48665 RVA: 0x002C9E31 File Offset: 0x002C8231
		private void ResetFightEndVoteData()
		{
			if (this.FightEndVoteAgreeList != null)
			{
				this.FightEndVoteAgreeList.Clear();
			}
			if (this.FightEndVoteRefuseList != null)
			{
				this.FightEndVoteRefuseList.Clear();
			}
			this.FightEndVoteEndTime = 0;
			this.FightEndVoteIntervalTime = 0;
		}

		// Token: 0x0600BE1A RID: 48666 RVA: 0x002C9E70 File Offset: 0x002C8270
		private void OnReceiveTeamCopyStageNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStageNotify teamCopyStageNotify = new TeamCopyStageNotify();
			teamCopyStageNotify.decode(msgData.bytes);
			this.ResetTeamDuplicationFightPanelData();
			this.UpdateTeamDuplicationFightPanelData(teamCopyStageNotify);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStageNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BE1B RID: 48667 RVA: 0x002C9EB8 File Offset: 0x002C82B8
		private void UpdateTeamDuplicationFightPanelData(TeamCopyStageNotify teamCopyStageNotify)
		{
			if (teamCopyStageNotify == null)
			{
				return;
			}
			this.TeamDuplicationFightStageId = (int)teamCopyStageNotify.stageId;
			this.TeamDuplicationFightFinishTime = teamCopyStageNotify.gameOverTime;
			if (this.TeamDuplicationCaptainFightGoalDataModel == null)
			{
				this.TeamDuplicationCaptainFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			}
			TeamDuplicationUtility.UpdateTeamDuplicationFightGoalDataModel(this.TeamDuplicationCaptainFightGoalDataModel, teamCopyStageNotify.squadTarget);
			if (this.TeamDuplicationTeamFightGoalDataModel == null)
			{
				this.TeamDuplicationTeamFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			}
			TeamDuplicationUtility.UpdateTeamDuplicationFightGoalDataModel(this.TeamDuplicationTeamFightGoalDataModel, teamCopyStageNotify.teamTarget);
			if (this.TeamDuplicationFightPointDataModelList == null)
			{
				this.TeamDuplicationFightPointDataModelList = new List<TeamDuplicationFightPointDataModel>();
			}
			this.TeamDuplicationFightPointDataModelList.Clear();
			for (int i = 0; i < teamCopyStageNotify.feildList.Length; i++)
			{
				TeamCopyFeild teamCopyFeild = teamCopyStageNotify.feildList[i];
				if (teamCopyFeild != null)
				{
					TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = new TeamDuplicationFightPointDataModel();
					TeamDuplicationUtility.UpdateTeamDuplicationFightPointDataModel(teamDuplicationFightPointDataModel, teamCopyFeild);
					this.TeamDuplicationFightPointDataModelList.Add(teamDuplicationFightPointDataModel);
				}
			}
			this.UpdateFightPointEnergyAccumulationRelationDataModel();
		}

		// Token: 0x0600BE1C RID: 48668 RVA: 0x002C9F9C File Offset: 0x002C839C
		private void OnReceiveTeamCopyFieldNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyFieldNotify teamCopyFieldNotify = new TeamCopyFieldNotify();
			teamCopyFieldNotify.decode(msgData.bytes);
			if (teamCopyFieldNotify.feildList == null || teamCopyFieldNotify.feildList.Length <= 0)
			{
				return;
			}
			if (this.TeamDuplicationFightPointDataModelList == null)
			{
				this.TeamDuplicationFightPointDataModelList = new List<TeamDuplicationFightPointDataModel>();
			}
			for (int i = 0; i < teamCopyFieldNotify.feildList.Length; i++)
			{
				TeamCopyFeild teamCopyFeild = teamCopyFieldNotify.feildList[i];
				if (teamCopyFeild != null)
				{
					bool flag = false;
					for (int j = 0; j < this.TeamDuplicationFightPointDataModelList.Count; j++)
					{
						TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = this.TeamDuplicationFightPointDataModelList[j];
						if (teamDuplicationFightPointDataModel != null)
						{
							if (teamDuplicationFightPointDataModel.FightPointId == (int)teamCopyFeild.feildId)
							{
								flag = true;
								if (TeamDuplicationUtility.IsFightPointFinishUnlocking(teamDuplicationFightPointDataModel.FightPointStatusType, (TeamCopyFieldStatus)teamCopyFeild.state))
								{
									TeamDuplicationUtility.ShowUnLockFightPointNameTips((int)teamCopyFeild.feildId);
									this.ResetTeamDuplicationFightPointUnlockRateByFightPointId((int)teamCopyFeild.feildId);
								}
								TeamDuplicationUtility.UpdateTeamDuplicationFightPointDataModel(teamDuplicationFightPointDataModel, teamCopyFeild);
								break;
							}
						}
					}
					if (!flag)
					{
						TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel2 = new TeamDuplicationFightPointDataModel();
						TeamDuplicationUtility.UpdateTeamDuplicationFightPointDataModel(teamDuplicationFightPointDataModel2, teamCopyFeild);
						this.TeamDuplicationFightPointDataModelList.Add(teamDuplicationFightPointDataModel2);
						if (teamDuplicationFightPointDataModel2.FightPointStatusType != TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_UNLOCKING)
						{
							TeamDuplicationUtility.ShowUnLockFightPointNameTips((int)teamCopyFeild.feildId);
						}
					}
				}
			}
			this.UpdateFightPointEnergyAccumulationRelationDataModel();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightPointNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BE1D RID: 48669 RVA: 0x002CA100 File Offset: 0x002C8500
		private void UpdateFightPointEnergyAccumulationRelationDataModel()
		{
			TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = null;
			if (this.TeamDuplicationFightPointDataModelList != null && this.TeamDuplicationFightPointDataModelList.Count > 0)
			{
				for (int i = 0; i < this.TeamDuplicationFightPointDataModelList.Count; i++)
				{
					TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel2 = this.TeamDuplicationFightPointDataModelList[i];
					if (teamDuplicationFightPointDataModel2 != null)
					{
						if (teamDuplicationFightPointDataModel2.FightPointStatusType == TeamCopyFieldStatus.TEAM_COPY_FIELD_STATUS_ENERGY_REVIVE)
						{
							teamDuplicationFightPointDataModel = teamDuplicationFightPointDataModel2;
							break;
						}
					}
				}
			}
			if (teamDuplicationFightPointDataModel == null)
			{
				this.FightPointEnergyAccumulationRelationDataModel = null;
			}
			else if (this.FightPointEnergyAccumulationRelationDataModel == null)
			{
				this.FightPointEnergyAccumulationRelationDataModel = TeamDuplicationUtility.GetEnergyAccumulationFightPointDataModel();
				if (this.FightPointEnergyAccumulationRelationDataModel != null)
				{
					this.FightPointEnergyAccumulationRelationDataModel.IsBeginEnergyAccumulated = true;
					this.FightPointEnergyAccumulationRelationDataModel.EnergyAccumulationStartTime = teamDuplicationFightPointDataModel.FightPointEnergyAccumulationStartTime;
				}
			}
			else if (teamDuplicationFightPointDataModel.FightPointEnergyAccumulationStartTime != this.FightPointEnergyAccumulationRelationDataModel.EnergyAccumulationStartTime)
			{
				this.FightPointEnergyAccumulationRelationDataModel.EnergyAccumulationStartTime = teamDuplicationFightPointDataModel.FightPointEnergyAccumulationStartTime;
				this.FightPointEnergyAccumulationRelationDataModel.IsBeginEnergyAccumulated = true;
				this.FightPointEnergyAccumulationRelationDataModel.TimeUpdateInterval = 0f;
			}
		}

		// Token: 0x0600BE1E RID: 48670 RVA: 0x002CA210 File Offset: 0x002C8610
		private void OnReceiveTeamCopyFieldStatusNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyFieldStatusNotify teamCopyFieldStatusNotify = new TeamCopyFieldStatusNotify();
			teamCopyFieldStatusNotify.decode(msgData.bytes);
			if (teamCopyFieldStatusNotify.fieldId <= 0U)
			{
				return;
			}
			if (teamCopyFieldStatusNotify.fieldStatus != 3U)
			{
				return;
			}
			TeamCopyFieldTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyFieldTable>((int)teamCopyFieldStatusNotify.fieldId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string msgContent = string.Format(TR.Value("team_duplication_fight_point_finished"), tableItem.Name);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BE1F RID: 48671 RVA: 0x002CA290 File Offset: 0x002C8690
		private void OnReceiveTeamCopyTargetNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTargetNotify teamCopyTargetNotify = new TeamCopyTargetNotify();
			teamCopyTargetNotify.decode(msgData.bytes);
			if (this.TeamDuplicationCaptainFightGoalDataModel == null)
			{
				this.TeamDuplicationCaptainFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			}
			bool flag = this.TeamDuplicationCaptainFightGoalDataModel != null && (long)this.TeamDuplicationCaptainFightGoalDataModel.FightGoalId != (long)((ulong)teamCopyTargetNotify.squadTarget.targetId);
			TeamDuplicationUtility.UpdateTeamDuplicationFightGoalDataModel(this.TeamDuplicationCaptainFightGoalDataModel, teamCopyTargetNotify.squadTarget);
			if (flag)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightCaptainGoalChangeMessage, null, null, null, null);
			}
			if (this.TeamDuplicationTeamFightGoalDataModel == null)
			{
				this.TeamDuplicationTeamFightGoalDataModel = new TeamDuplicationFightGoalDataModel();
			}
			TeamDuplicationUtility.UpdateTeamDuplicationFightGoalDataModel(this.TeamDuplicationTeamFightGoalDataModel, teamCopyTargetNotify.teamTarget);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightGoalNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BE20 RID: 48672 RVA: 0x002CA35C File Offset: 0x002C875C
		private void OnReceiveTeamCopyFieldUnlockRate(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyFieldUnlockRate teamCopyFieldUnlockRate = new TeamCopyFieldUnlockRate();
			teamCopyFieldUnlockRate.decode(msgData.bytes);
			int fieldId = (int)teamCopyFieldUnlockRate.fieldId;
			int unlockRate = (int)teamCopyFieldUnlockRate.unlockRate;
			this.TeamDuplicationFightPointUnLockRateDictionary[fieldId] = unlockRate;
			this.BossPhase = (int)teamCopyFieldUnlockRate.bossPhase;
			this.BossBloodRate = (int)teamCopyFieldUnlockRate.bossBloodRate;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightPointUnlockRateMessage, fieldId, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightPointBossDataMessage, null, null, null, null);
		}

		// Token: 0x0600BE21 RID: 48673 RVA: 0x002CA3E0 File Offset: 0x002C87E0
		public void ResetTeamDuplicationFightPointUnlockRateByFightPointId(int fightPointId)
		{
			if (fightPointId <= 0)
			{
				return;
			}
			if (this.TeamDuplicationFightPointUnLockRateDictionary == null || this.TeamDuplicationFightPointUnLockRateDictionary.Count <= 0)
			{
				return;
			}
			if (!this.TeamDuplicationFightPointUnLockRateDictionary.ContainsKey(fightPointId))
			{
				return;
			}
			this.TeamDuplicationFightPointUnLockRateDictionary[fightPointId] = 0;
		}

		// Token: 0x0600BE22 RID: 48674 RVA: 0x002CA434 File Offset: 0x002C8834
		public int GetTeamDuplicationFightPointUnlockRateByFightPointId(int fightPointId)
		{
			if (fightPointId <= 0)
			{
				return 0;
			}
			if (this.TeamDuplicationFightPointUnLockRateDictionary == null || this.TeamDuplicationFightPointUnLockRateDictionary.Count <= 0)
			{
				return 0;
			}
			if (!this.TeamDuplicationFightPointUnLockRateDictionary.ContainsKey(fightPointId))
			{
				return 0;
			}
			return this.TeamDuplicationFightPointUnLockRateDictionary[fightPointId];
		}

		// Token: 0x0600BE23 RID: 48675 RVA: 0x002CA488 File Offset: 0x002C8888
		public int GetTeamDuplicationFightPointUnlockRateByPreFightPointId(int preFightPointId)
		{
			if (this.TeamDuplicationFightPointDataModelList == null || this.TeamDuplicationFightPointDataModelList.Count <= 0)
			{
				return 0;
			}
			for (int i = 0; i < this.TeamDuplicationFightPointDataModelList.Count; i++)
			{
				TeamDuplicationFightPointDataModel teamDuplicationFightPointDataModel = this.TeamDuplicationFightPointDataModelList[i];
				if (teamDuplicationFightPointDataModel != null)
				{
					if (teamDuplicationFightPointDataModel.FightPointId == preFightPointId)
					{
						int num = teamDuplicationFightPointDataModel.FightPointTotalFightNumber - teamDuplicationFightPointDataModel.FightPointLeftFightNumber;
						int result = 0;
						if (teamDuplicationFightPointDataModel.FightPointTotalFightNumber != 0)
						{
							result = num * (100 / teamDuplicationFightPointDataModel.FightPointTotalFightNumber);
						}
						return result;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600BE24 RID: 48676 RVA: 0x002CA524 File Offset: 0x002C8924
		private void ResetTeamDuplicationFightPanelData()
		{
			this.TeamDuplicationFightStageId = 0;
			this.TeamDuplicationFightFinishTime = 0U;
			if (this.TeamDuplicationFightPointDataModelList != null)
			{
				this.TeamDuplicationFightPointDataModelList.Clear();
			}
			if (this.TeamDuplicationCaptainFightGoalDataModel != null)
			{
				this.TeamDuplicationCaptainFightGoalDataModel.FightGoalId = 0;
				if (this.TeamDuplicationCaptainFightGoalDataModel.FightGoalDetailDataModelList != null)
				{
					this.TeamDuplicationCaptainFightGoalDataModel.FightGoalDetailDataModelList.Clear();
				}
			}
			if (this.TeamDuplicationTeamFightGoalDataModel != null)
			{
				this.TeamDuplicationTeamFightGoalDataModel.FightGoalId = 0;
				if (this.TeamDuplicationTeamFightGoalDataModel.FightGoalDetailDataModelList != null)
				{
					this.TeamDuplicationTeamFightGoalDataModel.FightGoalDetailDataModelList.Clear();
				}
			}
			this.FightPointEnergyAccumulationRelationDataModel = null;
		}

		// Token: 0x0600BE25 RID: 48677 RVA: 0x002CA5CC File Offset: 0x002C89CC
		public void OnSendTeamCopyStartChallengeReq(int fightPointId)
		{
			TeamCopyStartChallengeReq teamCopyStartChallengeReq = new TeamCopyStartChallengeReq();
			teamCopyStartChallengeReq.fieldId = (uint)fightPointId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyStartChallengeReq>(ServerType.GATE_SERVER, teamCopyStartChallengeReq);
			}
		}

		// Token: 0x0600BE26 RID: 48678 RVA: 0x002CA604 File Offset: 0x002C8A04
		private void OnReceiveTeamCopyStartChallengeRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStartChallengeRes teamCopyStartChallengeRes = new TeamCopyStartChallengeRes();
			teamCopyStartChallengeRes.decode(msgData.bytes);
			if (teamCopyStartChallengeRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyStartChallengeRes.retCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600BE27 RID: 48679 RVA: 0x002CA648 File Offset: 0x002C8A48
		private void OnReceiveTeamCopyStageEndNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStageEnd teamCopyStageEnd = new TeamCopyStageEnd();
			teamCopyStageEnd.decode(msgData.bytes);
			this.TeamDuplicationEndStageId = (int)teamCopyStageEnd.stageId;
			this.TeamDuplicationStagePassTypeWith65Level = (TC2PassType)teamCopyStageEnd.passType;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStageEndNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BE28 RID: 48680 RVA: 0x002CA69C File Offset: 0x002C8A9C
		public void OnSendTeamCopyTargetFlopReq(int stageId)
		{
			TeamCopyStageFlopReq teamCopyStageFlopReq = new TeamCopyStageFlopReq();
			teamCopyStageFlopReq.stageId = (uint)stageId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyStageFlopReq>(ServerType.GATE_SERVER, teamCopyStageFlopReq);
			}
		}

		// Token: 0x0600BE29 RID: 48681 RVA: 0x002CA6D4 File Offset: 0x002C8AD4
		private void OnReceiveTeamCopyStageFlopRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyStageFlopRes teamCopyStageFlopRes = new TeamCopyStageFlopRes();
			teamCopyStageFlopRes.decode(msgData.bytes);
			if (teamCopyStageFlopRes.flopList == null || teamCopyStageFlopRes.flopList.Length <= 0)
			{
				return;
			}
			int stageId = (int)teamCopyStageFlopRes.stageId;
			this.TeamDuplicationFightStageRewardDataModelList.Clear();
			for (int i = 0; i < teamCopyStageFlopRes.flopList.Length; i++)
			{
				TeamCopyFlop teamCopyFlop = teamCopyStageFlopRes.flopList[i];
				if (teamCopyFlop != null)
				{
					TeamDuplicationFightStageRewardDataModel teamDuplicationFightStageRewardDataModel = new TeamDuplicationFightStageRewardDataModel();
					TeamDuplicationUtility.UpdateFightStageRewardDataModel(teamCopyFlop, teamDuplicationFightStageRewardDataModel);
					this.TeamDuplicationFightStageRewardDataModelList.Add(teamDuplicationFightStageRewardDataModel);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, stageId, null, null, null);
		}

		// Token: 0x0600BE2A RID: 48682 RVA: 0x002CA787 File Offset: 0x002C8B87
		public void ResetFightStageRewardDataModelList()
		{
			if (this.TeamDuplicationFightStageRewardDataModelList != null)
			{
				this.TeamDuplicationFightStageRewardDataModelList.Clear();
			}
		}

		// Token: 0x0600BE2B RID: 48683 RVA: 0x002CA79F File Offset: 0x002C8B9F
		private void OnServerFuncSwitch(ServerSceneFuncSwitch funcSwitch)
		{
			if (funcSwitch.sType != ServiceType.SERVICE_TEAM_COPY)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationServerFuncSwitchChangeMessage, null, null, null, null);
		}

		// Token: 0x0600BE2C RID: 48684 RVA: 0x002CA7C5 File Offset: 0x002C8BC5
		public List<TeamDuplicationTeamDifficultyConfigDataModel> GetTeamConfigDataModelList()
		{
			return this._teamConfigDataModelList;
		}

		// Token: 0x0600BE2D RID: 48685 RVA: 0x002CA7D0 File Offset: 0x002C8BD0
		public void InitTeamConfigDataModelList()
		{
			if (this._teamConfigDataModelList == null)
			{
				return;
			}
			this._teamConfigDataModelList.Clear();
			for (int i = 0; i < this.TeamDuplicationCaptainNumber; i++)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = new TeamDuplicationTeamDifficultyConfigDataModel();
				teamDuplicationTeamDifficultyConfigDataModel.Difficulty = i + TeamCopyGrade.TEAM_COPY_GRADE_A;
				teamDuplicationTeamDifficultyConfigDataModel.TeamId = 0;
				this._teamConfigDataModelList.Add(teamDuplicationTeamDifficultyConfigDataModel);
			}
		}

		// Token: 0x0600BE2E RID: 48686 RVA: 0x002CA82D File Offset: 0x002C8C2D
		public bool IsTeamDuplicationTeamDifficultyConfigNotSet()
		{
			return this._teamConfigDataModelList == null || this._teamConfigDataModelList.Count <= 0;
		}

		// Token: 0x0600BE2F RID: 48687 RVA: 0x002CA850 File Offset: 0x002C8C50
		public void UpdateTeamConfigDataModelList(List<TeamDuplicationTeamDifficultyConfigDataModel> saveTeamConfigDataModelList)
		{
			if (saveTeamConfigDataModelList == null || this._teamConfigDataModelList == null || saveTeamConfigDataModelList.Count <= 0 || this._teamConfigDataModelList.Count <= 0)
			{
				return;
			}
			int count = saveTeamConfigDataModelList.Count;
			int count2 = this._teamConfigDataModelList.Count;
			int num = 0;
			while (num < count && num < count2)
			{
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel = saveTeamConfigDataModelList[num];
				TeamDuplicationTeamDifficultyConfigDataModel teamDuplicationTeamDifficultyConfigDataModel2 = this._teamConfigDataModelList[num];
				if (teamDuplicationTeamDifficultyConfigDataModel2 != null && teamDuplicationTeamDifficultyConfigDataModel != null)
				{
					teamDuplicationTeamDifficultyConfigDataModel2.Difficulty = teamDuplicationTeamDifficultyConfigDataModel.Difficulty;
					teamDuplicationTeamDifficultyConfigDataModel2.TeamId = teamDuplicationTeamDifficultyConfigDataModel.TeamId;
				}
				num++;
			}
		}

		// Token: 0x0600BE30 RID: 48688 RVA: 0x002CA8F5 File Offset: 0x002C8CF5
		public void ResetTeamConfigDataModelList()
		{
			if (this._teamConfigDataModelList != null && this._teamConfigDataModelList.Count > 0)
			{
				this._teamConfigDataModelList.Clear();
			}
		}

		// Token: 0x0600BE31 RID: 48689 RVA: 0x002CA91E File Offset: 0x002C8D1E
		public List<TeamDuplicationTeamListDataModel> GetTeamDuplicationTeamListDataModelList()
		{
			return this._teamListDataModelList;
		}

		// Token: 0x0600BE32 RID: 48690 RVA: 0x002CA928 File Offset: 0x002C8D28
		private void ResetTeamDuplicationDataByQuitTeam()
		{
			this.IsTeamDuplicationOwnerTeam = false;
			this.IsAlreadyReceiveFinalReward = false;
			this.ResetTeamDataModel();
			this.ResetTeamDuplicationFightPanelData();
			this.ResetTeamDuplicationGridMapDataModel();
			this.FightSettingConfigPlanModel = TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_INVALID;
			this.ResetTeamConfigDataModelList();
			this.ResetFightStartVoteData();
			this.ResetFightEndVoteData();
			this.TeamDuplicationFightEndVoteFlag = false;
			this.IsAlreadyShowPositionAdjustTip = false;
			this.ResetTeamDuplicationReconnectData();
			this.IsTeamDuplicationOwnerNewRequester = false;
			this.TeamDuplicationEndStageId = 0;
			this.TeamDuplicationStagePassTypeWith65Level = TC2PassType.TC_2_PASS_TYPE_COMMON;
			this.IsNeedShowGameFailResult = false;
			this.TeamDuplicationPlayerExpireTimeDic.Clear();
			this.TeamDuplicationFightPointUnLockRateDictionary.Clear();
			this.BossPhase = 0;
			this.BossBloodRate = 0;
		}

		// Token: 0x0600BE33 RID: 48691 RVA: 0x002CA9C4 File Offset: 0x002C8DC4
		public void ResetOtherTeamDataModel()
		{
			if (this.OtherTeamDataModel == null)
			{
				return;
			}
			this.OtherTeamDataModel.TeamId = 0;
			this.OtherTeamDataModel.TeamName = string.Empty;
			this.OtherTeamDataModel.TotalCommission = 0;
			this.OtherTeamDataModel.BonusCommission = 0;
			if (this.OtherTeamDataModel != null && this.OtherTeamDataModel.CaptainDataModelList != null)
			{
				for (int i = 0; i < this.OtherTeamDataModel.CaptainDataModelList.Count; i++)
				{
					TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = this.OtherTeamDataModel.CaptainDataModelList[i];
					if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null)
					{
						teamDuplicationCaptainDataModel.PlayerList.Clear();
					}
				}
				this.OtherTeamDataModel.CaptainDataModelList.Clear();
			}
		}

		// Token: 0x0600BE34 RID: 48692 RVA: 0x002CAA8C File Offset: 0x002C8E8C
		private void ResetTeamDataModel()
		{
			if (this._teamDataModel == null)
			{
				return;
			}
			this._teamDataModel.TeamId = 0;
			this._teamDataModel.TeamName = string.Empty;
			this._teamDataModel.TotalCommission = 0;
			this._teamDataModel.BonusCommission = 0;
			if (this._teamDataModel != null && this._teamDataModel.CaptainDataModelList != null)
			{
				for (int i = 0; i < this._teamDataModel.CaptainDataModelList.Count; i++)
				{
					TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = this._teamDataModel.CaptainDataModelList[i];
					if (teamDuplicationCaptainDataModel != null && teamDuplicationCaptainDataModel.PlayerList != null)
					{
						teamDuplicationCaptainDataModel.PlayerList.Clear();
					}
				}
				this._teamDataModel.CaptainDataModelList.Clear();
			}
			this._teamDataModel.VoiceTalkRoomId = string.Empty;
		}

		// Token: 0x0600BE35 RID: 48693 RVA: 0x002CAB63 File Offset: 0x002C8F63
		private void ResetTeamListDataModelList()
		{
			if (this._teamListDataModelList != null)
			{
				this._teamListDataModelList.Clear();
			}
		}

		// Token: 0x0600BE36 RID: 48694 RVA: 0x002CAB7B File Offset: 0x002C8F7B
		public override void Update(float time)
		{
			this.UpdateFightPointEnergyAccumulationStatus(time);
		}

		// Token: 0x0600BE37 RID: 48695 RVA: 0x002CAB84 File Offset: 0x002C8F84
		private void UpdateFightPointEnergyAccumulationStatus(float time)
		{
			if (this.FightPointEnergyAccumulationRelationDataModel == null || this.FightPointEnergyAccumulationRelationDataModel.EnergyAccumulationStartTime <= 0)
			{
				return;
			}
			if (!this.FightPointEnergyAccumulationRelationDataModel.IsBeginEnergyAccumulated)
			{
				return;
			}
			this.FightPointEnergyAccumulationRelationDataModel.TimeUpdateInterval += time;
			if (this.FightPointEnergyAccumulationRelationDataModel.TimeUpdateInterval >= 1f)
			{
				this.FightPointEnergyAccumulationRelationDataModel.TimeUpdateInterval = 0f;
				int num = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - (uint)this.FightPointEnergyAccumulationRelationDataModel.EnergyAccumulationStartTime);
				if (num > this.FightPointEnergyAccumulationRelationDataModel.FightPointEnergyAccumulation100 + 1)
				{
					this.FightPointEnergyAccumulationRelationDataModel.IsBeginEnergyAccumulated = false;
				}
				if (!TeamDuplicationUtility.IsInTeamDuplicationScene())
				{
					return;
				}
				if (num == this.FightPointEnergyAccumulationRelationDataModel.FightPointEnergyAccumulation30)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_point_energy_accumulation_thirty_percent"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (num == this.FightPointEnergyAccumulationRelationDataModel.FightPointEnergyAccumulation50)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_point_energy_accumulation_fifty_percent"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (num == this.FightPointEnergyAccumulationRelationDataModel.FightPointEnergyAccumulation80)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_point_energy_accumulation_eighty_percent"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (num == this.FightPointEnergyAccumulationRelationDataModel.FightPointEnergyAccumulation100)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_fight_point_energy_accumulation_one_hundred_percent"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightPointEnergyAccumulationTimeMessage, null, null, null, null);
			}
		}

		// Token: 0x0600BE38 RID: 48696 RVA: 0x002CACE4 File Offset: 0x002C90E4
		private void OnReceiveTeamCopyTwoTeamData(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyTwoTeamData teamCopyTwoTeamData = new TeamCopyTwoTeamData();
			teamCopyTwoTeamData.decode(msgData.bytes);
			this.TeamDuplicationFightFinishTime = teamCopyTwoTeamData.gameOverTime;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridCountDownTimeMessage, null, null, null, null);
		}

		// Token: 0x0600BE39 RID: 48697 RVA: 0x002CAD2C File Offset: 0x002C912C
		public TeamDuplicationGridObjectDataModel GetGridObjectDataModelByGridId(uint gridId)
		{
			if (this.GridFieldDataModelDictionary == null)
			{
				return null;
			}
			if (!this.GridFieldDataModelDictionary.ContainsKey(gridId))
			{
				return null;
			}
			return this.GridFieldDataModelDictionary[gridId];
		}

		// Token: 0x0600BE3A RID: 48698 RVA: 0x002CAD68 File Offset: 0x002C9168
		private void OnReceiveTeamCopyGridFieldNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridFieldNotify teamCopyGridFieldNotify = new TeamCopyGridFieldNotify();
			teamCopyGridFieldNotify.decode(msgData.bytes);
			if (this.GridFieldDataModelDictionary == null)
			{
				this.GridFieldDataModelDictionary = new Dictionary<uint, TeamDuplicationGridObjectDataModel>();
			}
			TCGridObjData[] fieldVec = teamCopyGridFieldNotify.fieldVec;
			if (fieldVec == null || fieldVec.Length <= 0)
			{
				return;
			}
			TeamDuplicationGridUpdateDataModel teamDuplicationGridUpdateDataModel = new TeamDuplicationGridUpdateDataModel();
			TeamDuplicationGridUpdateDataModel teamDuplicationGridUpdateDataModel2 = new TeamDuplicationGridUpdateDataModel();
			foreach (TCGridObjData tcgridObjData in fieldVec)
			{
				if (tcgridObjData != null)
				{
					uint gridId = tcgridObjData.gridId;
					TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = null;
					if (this.GridFieldDataModelDictionary.ContainsKey(gridId))
					{
						teamDuplicationGridObjectDataModel = this.GridFieldDataModelDictionary[gridId];
					}
					teamDuplicationGridUpdateDataModel.GridUpdateList.Add(gridId);
					if (teamDuplicationGridObjectDataModel == null)
					{
						teamDuplicationGridObjectDataModel = TeamDuplicationUtility.CreateGridObjectDataModel(tcgridObjData);
						this.GridFieldDataModelDictionary[gridId] = teamDuplicationGridObjectDataModel;
					}
					else
					{
						TCGridObjType gridType = (TCGridObjType)teamDuplicationGridObjectDataModel.GridType;
						TCGridFieldStatus gridStatus = (TCGridFieldStatus)teamDuplicationGridObjectDataModel.GridStatus;
						uint num = 0U;
						if (gridType == TCGridObjType.TC_GRID_OBJ_MAIN_CITY)
						{
							num = TeamDuplicationUtility.GetGridPropertyValue(teamDuplicationGridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_ODD_BLOOD);
						}
						TCGridFieldStatus gridStatus2 = (TCGridFieldStatus)tcgridObjData.gridStatus;
						TeamDuplicationUtility.UpdateGridObjectDataModel(teamDuplicationGridObjectDataModel, tcgridObjData);
						uint num2 = num;
						if (gridType == TCGridObjType.TC_GRID_OBJ_MAIN_CITY)
						{
							num2 = TeamDuplicationUtility.GetGridPropertyValue(teamDuplicationGridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_ODD_BLOOD);
						}
						if (gridType == TCGridObjType.TC_GRID_OBJ_MAIN_CITY && num2 < num)
						{
							bool flag = TeamDuplicationUtility.IsInFightSceneOf65LevelTeamDuplication();
							bool flag2 = CommonUtility.IsInBattleScene();
							if (flag || flag2)
							{
								TeamDuplicationUtility.ShowGridMainCityTipFrame(gridId, num2);
							}
							if (num2 == 0U)
							{
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridItemDestroyMessage, gridId, null, null, null);
							}
						}
						if (gridStatus2 != gridStatus && (gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS || gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD || gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_REVIVE))
						{
							bool flag3 = TeamDuplicationUtility.IsInFightSceneOf65LevelTeamDuplication();
							if (flag3)
							{
								bool isBattleDead = true;
								if (gridType == TCGridObjType.TC_GRID_OBJ_ALTAR || gridType == TCGridObjType.TC_GRID_OBJ_TERROR_ALTAR)
								{
									uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(teamDuplicationGridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_DEAD_REASON);
									TCGridObjDeadReason tcgridObjDeadReason = (TCGridObjDeadReason)gridPropertyValue;
									if (tcgridObjDeadReason != TCGridObjDeadReason.TC_OBJ_DEAD_REASON_SQUAD_DESTORY)
									{
										isBattleDead = false;
									}
								}
								bool isExistReviveGrid = false;
								if (gridType == TCGridObjType.TC_GRID_OBJ_MAKE_MONSTER)
								{
									isExistReviveGrid = TeamDuplicationUtility.IsExistGridInReviveStatus(gridId);
								}
								TeamDuplicationUtility.ShowGridDestroyTipFrame(gridId, gridType, gridStatus2, isBattleDead, isExistReviveGrid);
							}
						}
						if (gridStatus2 != gridStatus && (gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_RUINS || gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD || gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_REVIVE))
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridItemDestroyMessage, gridId, null, null, null);
						}
						if (gridStatus2 != gridStatus && gridStatus2 == TCGridFieldStatus.TC_GRID_FIELD_STATUS_DEAD && (gridType == TCGridObjType.TC_GRID_OBJ_ALTAR || gridType == TCGridObjType.TC_GRID_OBJ_TERROR_ALTAR || gridType == TCGridObjType.TC_GRID_OBJ_FIX_POINT))
						{
							teamDuplicationGridUpdateDataModel2.GridUpdateList.Add(gridId);
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridFieldNotifyMessage, teamDuplicationGridUpdateDataModel, null, null, null);
			if (teamDuplicationGridUpdateDataModel2.GridUpdateList != null && teamDuplicationGridUpdateDataModel2.GridUpdateList.Count > 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, null, null, teamDuplicationGridUpdateDataModel2, null);
			}
		}

		// Token: 0x0600BE3B RID: 48699 RVA: 0x002CB028 File Offset: 0x002C9428
		private void OnReceiveTeamCopyGridMonsterNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridMonsterNotify teamCopyGridMonsterNotify = new TeamCopyGridMonsterNotify();
			teamCopyGridMonsterNotify.decode(msgData.bytes);
			if (this.GridMonsterDataModelList == null)
			{
				this.GridMonsterDataModelList = new List<TeamDuplicationGridObjectDataModel>();
			}
			if (this.GridMonsterPathDictionary == null)
			{
				this.GridMonsterPathDictionary = new Dictionary<uint, List<uint>>();
			}
			TCMonsterPath[] monsterPathList = teamCopyGridMonsterNotify.monsterPathList;
			if (monsterPathList != null && monsterPathList.Length > 0)
			{
				foreach (TCMonsterPath tcmonsterPath in monsterPathList)
				{
					if (tcmonsterPath != null)
					{
						uint monsterObjId = tcmonsterPath.monsterObjId;
						uint[] pathVec = tcmonsterPath.pathVec;
						List<uint> list = null;
						if (this.GridMonsterPathDictionary.ContainsKey(monsterObjId))
						{
							list = this.GridMonsterPathDictionary[monsterObjId];
						}
						if (list == null)
						{
							list = new List<uint>();
						}
						list.Clear();
						list.AddRange(pathVec);
						this.GridMonsterPathDictionary[monsterObjId] = list;
					}
				}
			}
			TCGridObjData[] monsterVec = teamCopyGridMonsterNotify.monsterVec;
			if (monsterVec == null || monsterVec.Length <= 0)
			{
				return;
			}
			TeamDuplicationGridMonsterUpdateDataModel teamDuplicationGridMonsterUpdateDataModel = new TeamDuplicationGridMonsterUpdateDataModel();
			foreach (TCGridObjData tcgridObjData in monsterVec)
			{
				if (tcgridObjData != null)
				{
					uint gridId = tcgridObjData.gridId;
					uint gridObjId = tcgridObjData.gridObjId;
					bool flag = false;
					for (int k = 0; k < this.GridMonsterDataModelList.Count; k++)
					{
						TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = this.GridMonsterDataModelList[k];
						if (teamDuplicationGridObjectDataModel != null)
						{
							if (teamDuplicationGridObjectDataModel.GridObjectId == gridObjId)
							{
								uint gridId2 = teamDuplicationGridObjectDataModel.GridId;
								uint gridPropertyValue = TeamDuplicationUtility.GetGridPropertyValue(teamDuplicationGridObjectDataModel, TCGridPropretyType.TC_GRID_PRO_MONSTER_PRO_ID);
								List<uint> gridMonsterPathList = TeamDuplicationUtility.GetGridMonsterPathList(gridObjId);
								bool flag2 = TeamDuplicationUtility.IsMonsterNearByMainCityWithTwoGrid(gridMonsterPathList);
								flag = true;
								TeamDuplicationUtility.UpdateGridObjectDataModel(teamDuplicationGridObjectDataModel, tcgridObjData);
								teamDuplicationGridMonsterUpdateDataModel.MonsterUpdateDataModelList.Add(teamDuplicationGridObjectDataModel);
								if (gridId2 != 0U && gridId2 != gridId && flag2)
								{
									bool flag3 = TeamDuplicationUtility.IsInFightSceneOf65LevelTeamDuplication();
									bool flag4 = CommonUtility.IsInBattleScene();
									if (flag3 || flag4)
									{
										TeamDuplicationUtility.ShowGridMonsterNearByMainCityTipFrame((int)gridPropertyValue);
									}
								}
								if (gridId != gridId2)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, gridId, gridId2, null, null);
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, gridId, gridId2, null, null);
								}
								break;
							}
						}
					}
					if (!flag)
					{
						TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel2 = TeamDuplicationUtility.CreateGridObjectDataModel(tcgridObjData);
						if (teamDuplicationGridObjectDataModel2 != null)
						{
							this.GridMonsterDataModelList.Add(teamDuplicationGridObjectDataModel2);
							teamDuplicationGridMonsterUpdateDataModel.MonsterUpdateDataModelList.Add(teamDuplicationGridObjectDataModel2);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, gridId, null, null, null);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, gridId, null, null, null);
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridMonsterNotifyMessage, teamDuplicationGridMonsterUpdateDataModel, null, null, null);
		}

		// Token: 0x0600BE3C RID: 48700 RVA: 0x002CB308 File Offset: 0x002C9708
		private void OnReceiveTeamCopyGridMonsterData(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridMonsterDead teamCopyGridMonsterDead = new TeamCopyGridMonsterDead();
			teamCopyGridMonsterDead.decode(msgData.bytes);
			uint monsterObjId = teamCopyGridMonsterDead.monsterObjId;
			bool flag = teamCopyGridMonsterDead.isKill == 1U;
			if (this.GridMonsterPathDictionary != null && this.GridMonsterPathDictionary.ContainsKey(monsterObjId))
			{
				this.GridMonsterPathDictionary.Remove(monsterObjId);
			}
			if (this.GridMonsterDataModelList != null && this.GridMonsterDataModelList.Count > 0)
			{
				for (int i = 0; i < this.GridMonsterDataModelList.Count; i++)
				{
					TeamDuplicationGridObjectDataModel teamDuplicationGridObjectDataModel = this.GridMonsterDataModelList[i];
					if (teamDuplicationGridObjectDataModel != null)
					{
						if (teamDuplicationGridObjectDataModel.GridObjectId == monsterObjId)
						{
							uint gridId = teamDuplicationGridObjectDataModel.GridId;
							if (flag)
							{
								bool flag2 = TeamDuplicationUtility.IsInFightSceneOf65LevelTeamDuplication();
								if (flag2)
								{
									TeamDuplicationUtility.ShowGridMonsterDestroyTipFrame(teamDuplicationGridObjectDataModel);
								}
							}
							this.GridMonsterDataModelList.RemoveAt(i);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridMonsterDestroyMessage, monsterObjId, null, null, null);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, gridId, null, null, null);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, gridId, null, null, null);
							break;
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridMonsterRemoveMessage, monsterObjId, null, null, null);
		}

		// Token: 0x0600BE3D RID: 48701 RVA: 0x002CB460 File Offset: 0x002C9860
		private void OnReceiveTeamCopyGridSquadNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridSquadNotify teamCopyGridSquadNotify = new TeamCopyGridSquadNotify();
			teamCopyGridSquadNotify.decode(msgData.bytes);
			uint num = 0U;
			if (teamCopyGridSquadNotify.squadData != null)
			{
				num = teamCopyGridSquadNotify.squadData.gridId;
			}
			uint num2 = 0U;
			if (this.OwnerGridCaptainDataModel == null)
			{
				this.OwnerGridCaptainDataModel = new TeamDuplicationGridOwnerCaptainDataModel();
			}
			if (this.OwnerGridCaptainDataModel != null)
			{
				num2 = this.OwnerGridCaptainDataModel.GridId;
			}
			TeamDuplicationUtility.UpdateOwnerGridCaptainDataModel(this.OwnerGridCaptainDataModel, teamCopyGridSquadNotify);
			if (num != num2)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, num, num2, null, null);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridOwnerCaptainNotifyMessage, null, null, null, null);
		}

		// Token: 0x0600BE3E RID: 48702 RVA: 0x002CB514 File Offset: 0x002C9914
		private void OnReceiveTeamCopyOtherSquadData(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyOtherSquadData teamCopyOtherSquadData = new TeamCopyOtherSquadData();
			teamCopyOtherSquadData.decode(msgData.bytes);
			uint squadGridId = teamCopyOtherSquadData.squadGridId;
			uint squadMemberNum = teamCopyOtherSquadData.squadMemberNum;
			if (this.OtherGridCaptainDataModel == null)
			{
				this.OtherGridCaptainDataModel = new TeamDuplicationGridOtherCaptainDataModel();
			}
			uint num = 0U;
			uint num2 = 0U;
			if (this.OtherGridCaptainDataModel != null)
			{
				num = this.OtherGridCaptainDataModel.GridId;
				num2 = this.OtherGridCaptainDataModel.PlayerNumber;
			}
			TeamDuplicationUtility.UpdateOtherGridCaptainDataModel(this.OtherGridCaptainDataModel, teamCopyOtherSquadData);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridOtherCaptainNotifyMessage, null, null, null, null);
			if (num != squadGridId)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, squadGridId, num, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, squadGridId, num, null, null);
			}
			else if (num2 != squadMemberNum && (squadMemberNum == 0U || num2 == 0U))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMonsterNextGridUpdateMessage, squadGridId, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationNearByGridUpdateMessage, squadGridId, null, null, null);
			}
		}

		// Token: 0x0600BE3F RID: 48703 RVA: 0x002CB634 File Offset: 0x002C9A34
		public void OnSendTeamCopyGridMoveReq(uint targetGridId = 0U, uint targetMonsterId = 0U)
		{
			TeamCopyGridMoveReq teamCopyGridMoveReq = new TeamCopyGridMoveReq();
			teamCopyGridMoveReq.targetGridId = targetGridId;
			teamCopyGridMoveReq.targetObjId = targetMonsterId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<TeamCopyGridMoveReq>(ServerType.GATE_SERVER, teamCopyGridMoveReq);
			}
		}

		// Token: 0x0600BE40 RID: 48704 RVA: 0x002CB670 File Offset: 0x002C9A70
		private void OnReceiveTeamCopyGridMoveRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridMoveRes teamCopyGridMoveRes = new TeamCopyGridMoveRes();
			teamCopyGridMoveRes.decode(msgData.bytes);
			if (teamCopyGridMoveRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)teamCopyGridMoveRes.retCode, string.Empty);
				return;
			}
			if (this.OwnerGridCaptainDataModel == null)
			{
				this.OwnerGridCaptainDataModel = new TeamDuplicationGridOwnerCaptainDataModel();
			}
			this.OwnerGridCaptainDataModel.CaptainId = teamCopyGridMoveRes.squadId;
			this.OwnerGridCaptainDataModel.CaptainStatus = teamCopyGridMoveRes.squadStatus;
			this.OwnerGridCaptainDataModel.TargetGridId = teamCopyGridMoveRes.targetGridId;
			this.OwnerGridCaptainDataModel.TargetMonsterId = teamCopyGridMoveRes.targetObjId;
			this.OwnerGridCaptainDataModel.CaptainPathList.Clear();
			this.OwnerGridCaptainDataModel.CaptainPathList.AddRange(teamCopyGridMoveRes.pathList);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridMapCaptainMoveMessage, null, null, null, null);
		}

		// Token: 0x0600BE41 RID: 48705 RVA: 0x002CB748 File Offset: 0x002C9B48
		private void OnReceiveTeamCopyGridSquadBattleNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			TeamCopyGridSquadBattleNotify teamCopyGridSquadBattleNotify = new TeamCopyGridSquadBattleNotify();
			teamCopyGridSquadBattleNotify.decode(msgData.bytes);
			uint squadId = teamCopyGridSquadBattleNotify.squadId;
			if (squadId == 1U)
			{
				if (this.CaptainOneBattleDataModel == null)
				{
					this.CaptainOneBattleDataModel = new TeamDuplicationGridBattleDataModel();
				}
				TeamDuplicationUtility.UpdateGridBattleDataModel(this.CaptainOneBattleDataModel, teamCopyGridSquadBattleNotify);
			}
			else
			{
				if (this.CaptainTwoBattleDataModel == null)
				{
					this.CaptainTwoBattleDataModel = new TeamDuplicationGridBattleDataModel();
				}
				TeamDuplicationUtility.UpdateGridBattleDataModel(this.CaptainTwoBattleDataModel, teamCopyGridSquadBattleNotify);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridSquadBattleNotifyMessage, squadId, null, null, null);
		}

		// Token: 0x0600BE42 RID: 48706 RVA: 0x002CB7E0 File Offset: 0x002C9BE0
		public void ResetTeamDuplicationGridMapDataModel()
		{
			this.ResetGridFieldDataModelDic();
			this.ResetGridMonsterData();
			if (this.OwnerGridCaptainDataModel != null)
			{
				if (this.OwnerGridCaptainDataModel.CaptainPathList != null)
				{
					this.OwnerGridCaptainDataModel.CaptainPathList.Clear();
				}
				this.OwnerGridCaptainDataModel = null;
			}
			this.OtherGridCaptainDataModel = null;
			this.CaptainOneBattleDataModel = null;
			this.CaptainTwoBattleDataModel = null;
			this.ResetGridInsDataDictionary();
		}

		// Token: 0x0600BE43 RID: 48707 RVA: 0x002CB848 File Offset: 0x002C9C48
		private void ResetGridFieldDataModelDic()
		{
			if (this.GridFieldDataModelDictionary != null)
			{
				foreach (KeyValuePair<uint, TeamDuplicationGridObjectDataModel> keyValuePair in this.GridFieldDataModelDictionary)
				{
					TeamDuplicationGridObjectDataModel value = keyValuePair.Value;
					if (value != null && value.GridPropertyDataModelList != null)
					{
						value.GridPropertyDataModelList.Clear();
					}
				}
				this.GridFieldDataModelDictionary.Clear();
				this.GridFieldDataModelDictionary = null;
			}
		}

		// Token: 0x0600BE44 RID: 48708 RVA: 0x002CB8BC File Offset: 0x002C9CBC
		private void ResetGridMonsterData()
		{
			if (this.GridMonsterDataModelList != null)
			{
				this.GridMonsterDataModelList.Clear();
				this.GridMonsterDataModelList = null;
			}
			if (this.GridMonsterPathDictionary != null)
			{
				foreach (KeyValuePair<uint, List<uint>> keyValuePair in this.GridMonsterPathDictionary)
				{
					List<uint> value = keyValuePair.Value;
					if (value != null)
					{
						value.Clear();
					}
				}
				this.GridMonsterPathDictionary.Clear();
				this.GridMonsterPathDictionary = null;
			}
		}

		// Token: 0x0600BE45 RID: 48709 RVA: 0x002CB93C File Offset: 0x002C9D3C
		public int GetCostItemIdWithNormalLevel()
		{
			if (this._costItemIdWithNormalLevel > 0)
			{
				return this._costItemIdWithNormalLevel;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationCostItemIdWithNormalLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._costItemIdWithNormalLevel = tableItem.Value;
			}
			if (this._costItemIdWithNormalLevel == 0)
			{
				this._costItemIdWithNormalLevel = 330000204;
			}
			return this._costItemIdWithNormalLevel;
		}

		// Token: 0x0600BE46 RID: 48710 RVA: 0x002CB9A8 File Offset: 0x002C9DA8
		public int GetCostItemNumberWithNormalLevel()
		{
			if (this._costItemNumberWithNormalLevel > 0)
			{
				return this._costItemNumberWithNormalLevel;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationCostItemNumberWithNormalLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._costItemNumberWithNormalLevel = tableItem.Value;
			}
			if (this._costItemNumberWithNormalLevel == 0)
			{
				this._costItemNumberWithNormalLevel = 100;
			}
			return this._costItemNumberWithNormalLevel;
		}

		// Token: 0x0600BE47 RID: 48711 RVA: 0x002CBA10 File Offset: 0x002C9E10
		public int GetCostItemIdWith65Level()
		{
			if (this._costItemIdWith65Level > 0)
			{
				return this._costItemIdWith65Level;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationCostItemIdWith65Level, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._costItemIdWith65Level = tableItem.Value;
			}
			if (this._costItemIdWith65Level == 0)
			{
				this._costItemIdWith65Level = 330000204;
			}
			return this._costItemIdWith65Level;
		}

		// Token: 0x0600BE48 RID: 48712 RVA: 0x002CBA7C File Offset: 0x002C9E7C
		public int GetCostItemNumberWith65Level()
		{
			if (this._costItemNumberWith65Level > 0)
			{
				return this._costItemNumberWith65Level;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationCostItemNumberWith65Level, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._costItemNumberWith65Level = tableItem.Value;
			}
			if (this._costItemNumberWith65Level == 0)
			{
				this._costItemNumberWith65Level = 100;
			}
			return this._costItemNumberWith65Level;
		}

		// Token: 0x0600BE49 RID: 48713 RVA: 0x002CBAE4 File Offset: 0x002C9EE4
		public int GetMonsterFieldId()
		{
			if (this._monsterFieldId > 0)
			{
				return this._monsterFieldId;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationMonsterFieldId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._monsterFieldId = tableItem.Value;
			}
			if (this._monsterFieldId == 0)
			{
				this._monsterFieldId = 2005;
			}
			return this._monsterFieldId;
		}

		// Token: 0x0600BE4A RID: 48714 RVA: 0x002CBB50 File Offset: 0x002C9F50
		public int GetCaptainMoveCdTime()
		{
			if (this._captainMoveCdTime > 0)
			{
				return this._captainMoveCdTime;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationCaptainMoveCdTableId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._captainMoveCdTime = tableItem.Value;
			}
			if (this._captainMoveCdTime == 0)
			{
				this._captainMoveCdTime = 10;
			}
			return this._captainMoveCdTime;
		}

		// Token: 0x0600BE4B RID: 48715 RVA: 0x002CBBB8 File Offset: 0x002C9FB8
		public int GetPassTimesWithNormalLevel()
		{
			if (this._passTimesWithNormalLevel > 0)
			{
				return this._passTimesWithNormalLevel;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationPassTimesIdWithNormalLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._passTimesWithNormalLevel = tableItem.Value;
			}
			if (this._passTimesWithNormalLevel == 0)
			{
				this._passTimesWithNormalLevel = 10;
			}
			return this._passTimesWithNormalLevel;
		}

		// Token: 0x0600BE4C RID: 48716 RVA: 0x002CBC20 File Offset: 0x002CA020
		public int GetEquipScoreWithNormalLevel()
		{
			if (this._equipScoreWithNormalLevel > 0)
			{
				return this._equipScoreWithNormalLevel;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationEquipScoreIdWithNormalLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._equipScoreWithNormalLevel = tableItem.Value;
			}
			if (this._equipScoreWithNormalLevel == 0)
			{
				this._equipScoreWithNormalLevel = 3000;
			}
			return this._equipScoreWithNormalLevel;
		}

		// Token: 0x0600BE4D RID: 48717 RVA: 0x002CBC8C File Offset: 0x002CA08C
		public int GetPassTimesWith65Level()
		{
			if (this._passTimesWith65Level > 0)
			{
				return this._passTimesWith65Level;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationPassTimesIdWith65Level, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._passTimesWith65Level = tableItem.Value;
			}
			if (this._passTimesWith65Level == 0)
			{
				this._passTimesWith65Level = 10;
			}
			return this._passTimesWith65Level;
		}

		// Token: 0x0600BE4E RID: 48718 RVA: 0x002CBCF4 File Offset: 0x002CA0F4
		public int GetEquipScoreWith65Level()
		{
			if (this._equipScoreWith65Level > 0)
			{
				return this._equipScoreWith65Level;
			}
			TeamCopyValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamCopyValueTable>(this.TeamDuplicationEquipScoreIdWith65Level, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._equipScoreWith65Level = tableItem.Value;
			}
			if (this._equipScoreWith65Level == 0)
			{
				this._equipScoreWith65Level = 3000;
			}
			return this._equipScoreWith65Level;
		}

		// Token: 0x0600BE4F RID: 48719 RVA: 0x002CBD5D File Offset: 0x002CA15D
		public TileInsData GetGridInsDataByGridId(int gridId)
		{
			if (this._gridInsDataDictionary == null)
			{
				this.LoadGridInsDataDictionary();
			}
			if (this._gridInsDataDictionary != null && this._gridInsDataDictionary.ContainsKey(gridId))
			{
				return this._gridInsDataDictionary[gridId];
			}
			return null;
		}

		// Token: 0x0600BE50 RID: 48720 RVA: 0x002CBD9C File Offset: 0x002CA19C
		private void LoadGridInsDataDictionary()
		{
			string path = "Data/TileData/Map.asset";
			AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(path, typeof(TileMap), true, 0U);
			TileMap tileMap = null;
			if (assetInst != null)
			{
				tileMap = (assetInst.obj as TileMap);
			}
			if (tileMap == null)
			{
				return;
			}
			TileInsData[] insDatas = tileMap.InsDatas;
			if (insDatas == null || insDatas.Length <= 0)
			{
				return;
			}
			this.SetGridInsDataDictionary(insDatas);
		}

		// Token: 0x0600BE51 RID: 48721 RVA: 0x002CBE08 File Offset: 0x002CA208
		public void SetGridInsDataDictionary(TileInsData[] tileInsDataArray)
		{
			if (this._gridInsDataDictionary != null)
			{
				return;
			}
			if (tileInsDataArray == null || tileInsDataArray.Length <= 0)
			{
				return;
			}
			this._gridInsDataDictionary = new Dictionary<int, TileInsData>();
			foreach (TileInsData tileInsData in tileInsDataArray)
			{
				if (tileInsData != null)
				{
					int id = tileInsData.ID;
					this._gridInsDataDictionary[id] = tileInsData;
				}
			}
		}

		// Token: 0x0600BE52 RID: 48722 RVA: 0x002CBE73 File Offset: 0x002CA273
		private void ResetGridInsDataDictionary()
		{
			if (this._gridInsDataDictionary == null)
			{
				return;
			}
			this._gridInsDataDictionary.Clear();
			this._gridInsDataDictionary = null;
		}

		// Token: 0x04006AA5 RID: 27301
		public readonly int TeamDuplicationShopIdWithNormalLevel = 31;

		// Token: 0x04006AA6 RID: 27302
		public readonly int TeamDuplicationShopIdWith65Level = 40;

		// Token: 0x04006AA7 RID: 27303
		public readonly int TeamDuplicationBuildHelpIdWithNormalLevel = 10020;

		// Token: 0x04006AA8 RID: 27304
		public readonly int TeamDuplicationFightHelpIdWithNormalLevel = 10030;

		// Token: 0x04006AA9 RID: 27305
		public readonly int TeamDuplicationBuildHelpIdWith65Level = 10021;

		// Token: 0x04006AAA RID: 27306
		public readonly int TeamDuplicationFightHelpIdWith65Level = 10031;

		// Token: 0x04006AAB RID: 27307
		public const int TeamDuplicationAudioUrgentStateId = 5064;

		// Token: 0x04006AAC RID: 27308
		public const int TeamDuplicationAudioGameResultId = 5065;

		// Token: 0x04006AAD RID: 27309
		public readonly int GameResultShowTime = 4;

		// Token: 0x04006AAE RID: 27310
		public readonly int FightCountDownShowTime = 3;

		// Token: 0x04006AAF RID: 27311
		public readonly int FightCountDownTotalTime = 6;

		// Token: 0x04006AB0 RID: 27312
		public readonly int FightCountDownShowTimeWith65Level = 3;

		// Token: 0x04006AB1 RID: 27313
		public readonly int FightCountDownTotalTimeWith65Level = 6;

		// Token: 0x04006AB2 RID: 27314
		public readonly float TeamDuplicationStageBeginIntervalTime = 2f;

		// Token: 0x04006AB3 RID: 27315
		public readonly float TeamDuplicationStageEndIntervalTime = 4f;

		// Token: 0x04006AB4 RID: 27316
		public readonly int TeamDuplicationDungeonModelIdWithNormalLevel = 5;

		// Token: 0x04006AB5 RID: 27317
		public readonly int TeamDuplicationDungeonModelIdWith65Level = 6;

		// Token: 0x04006AB6 RID: 27318
		public readonly int TeamDuplicationBuildSceneIdWithNormalLevel = 6035;

		// Token: 0x04006AB7 RID: 27319
		public readonly int TeamDuplicationFightSceneIdWithNormalLevel = 6036;

		// Token: 0x04006AB8 RID: 27320
		public readonly int TeamDuplicationBuildSceneIdWith65Level = 6046;

		// Token: 0x04006AB9 RID: 27321
		public readonly int TeamDuplicationFightSceneIdWith65Level = 6047;

		// Token: 0x04006ABA RID: 27322
		public readonly int TeamDuplicationPlayerNumberInCaptain = 3;

		// Token: 0x04006ABB RID: 27323
		public readonly int TeamDuplicationCaptainNumber = 4;

		// Token: 0x04006ABC RID: 27324
		public readonly int TeamDuplicationTotalPlayerNumberInTeam = 12;

		// Token: 0x04006ABD RID: 27325
		public readonly int TeamDuplicationCaptainNumberWith65Level = 2;

		// Token: 0x04006ABE RID: 27326
		public readonly int TeamDuplicationTotalPlayerNumberInTeamWith65Level = 6;

		// Token: 0x04006ABF RID: 27327
		public TeamCopyPlanModel FightSettingConfigPlanModel;

		// Token: 0x04006AC0 RID: 27328
		private List<TeamDuplicationTeamDifficultyConfigDataModel> _teamConfigDataModelList = new List<TeamDuplicationTeamDifficultyConfigDataModel>();

		// Token: 0x04006AC1 RID: 27329
		public int TeamDuplicationReconnectSceneId;

		// Token: 0x04006AC2 RID: 27330
		public ulong TeamDuplicationReconnectExpireTime;

		// Token: 0x04006AC6 RID: 27334
		private List<ulong> _fightStartVoteAgreeList = new List<ulong>();

		// Token: 0x04006AC7 RID: 27335
		public bool FightVoteAgreeBySwitchFightScene;

		// Token: 0x04006AC8 RID: 27336
		public bool TeamDuplicationFightEndVoteFlag;

		// Token: 0x04006AC9 RID: 27337
		public int FightEndVoteIntervalTime;

		// Token: 0x04006ACA RID: 27338
		public int FightEndVoteEndTime;

		// Token: 0x04006ACB RID: 27339
		public List<ulong> FightEndVoteAgreeList = new List<ulong>();

		// Token: 0x04006ACC RID: 27340
		public List<ulong> FightEndVoteRefuseList = new List<ulong>();

		// Token: 0x04006ACD RID: 27341
		public bool IsTeamDuplicationGoldOwner;

		// Token: 0x04006ACE RID: 27342
		private TeamDuplicationPlayerInformationDataModel _playerInformationDataModel;

		// Token: 0x04006ACF RID: 27343
		public bool IsAlreadyShowPositionAdjustTip;

		// Token: 0x04006AD1 RID: 27345
		private TeamDuplicationTeamDataModel _teamDataModel = new TeamDuplicationTeamDataModel();

		// Token: 0x04006AD2 RID: 27346
		public TeamDuplicationTeamDataModel OtherTeamDataModel = new TeamDuplicationTeamDataModel();

		// Token: 0x04006AD3 RID: 27347
		private List<TeamDuplicationTeamListDataModel> _teamListDataModelList = new List<TeamDuplicationTeamListDataModel>();

		// Token: 0x04006AD4 RID: 27348
		public int TeamListCurrentPage = 1;

		// Token: 0x04006AD5 RID: 27349
		public int TeamListTotalPage = 1;

		// Token: 0x04006AD6 RID: 27350
		private Dictionary<int, int> _teamRequestJoinInEndTimeDic = new Dictionary<int, int>();

		// Token: 0x04006AD7 RID: 27351
		private List<TeamDuplicationRequesterDataModel> _teamRequesterDataModelList = new List<TeamDuplicationRequesterDataModel>();

		// Token: 0x04006AD8 RID: 27352
		private List<TeamDuplicationRequesterDataModel> _teamFriendDataModelList = new List<TeamDuplicationRequesterDataModel>();

		// Token: 0x04006AD9 RID: 27353
		public bool IsTeamDuplicationOwnerNewRequester;

		// Token: 0x04006ADA RID: 27354
		public bool IsTeamDuplicationOwnerNewInvite;

		// Token: 0x04006AE1 RID: 27361
		public readonly int TeamDuplicationFightStageRewardTime = 3;

		// Token: 0x04006AE2 RID: 27362
		public readonly uint TeamDuplicationFinalStageRewardTime = 10U;

		// Token: 0x04006AE4 RID: 27364
		public bool IsNeedShowGameFailResult;

		// Token: 0x04006AE5 RID: 27365
		public bool IsAlreadyReceiveFinalReward;

		// Token: 0x04006AE6 RID: 27366
		public int TeamDuplicationEndStageId;

		// Token: 0x04006AE7 RID: 27367
		public TC2PassType TeamDuplicationStagePassTypeWith65Level;

		// Token: 0x04006AE8 RID: 27368
		public const float TeamDuplicationRewardItemActionDuringTime = 0.5f;

		// Token: 0x04006AE9 RID: 27369
		public Dictionary<ulong, ulong> TeamDuplicationPlayerExpireTimeDic = new Dictionary<ulong, ulong>();

		// Token: 0x04006AEA RID: 27370
		public bool IsEnterTeamDuplicationBuildSceneFromTown;

		// Token: 0x04006AEB RID: 27371
		public bool IsAlreadyShowTicketIsNotEnoughTip;

		// Token: 0x04006AEC RID: 27372
		public Dictionary<int, int> TeamDuplicationFightPointUnLockRateDictionary = new Dictionary<int, int>();

		// Token: 0x04006AED RID: 27373
		public int BossPhase;

		// Token: 0x04006AEE RID: 27374
		public int BossBloodRate;

		// Token: 0x04006AEF RID: 27375
		public TeamDuplicationFightPointEnergyAccumulationDataModel FightPointEnergyAccumulationRelationDataModel;

		// Token: 0x04006AF0 RID: 27376
		public Dictionary<uint, TeamDuplicationGridObjectDataModel> GridFieldDataModelDictionary;

		// Token: 0x04006AF1 RID: 27377
		public List<TeamDuplicationGridObjectDataModel> GridMonsterDataModelList;

		// Token: 0x04006AF2 RID: 27378
		public Dictionary<uint, List<uint>> GridMonsterPathDictionary;

		// Token: 0x04006AF3 RID: 27379
		public TeamDuplicationGridOwnerCaptainDataModel OwnerGridCaptainDataModel;

		// Token: 0x04006AF4 RID: 27380
		public TeamDuplicationGridOtherCaptainDataModel OtherGridCaptainDataModel;

		// Token: 0x04006AF5 RID: 27381
		public TeamDuplicationGridBattleDataModel CaptainOneBattleDataModel;

		// Token: 0x04006AF6 RID: 27382
		public TeamDuplicationGridBattleDataModel CaptainTwoBattleDataModel;

		// Token: 0x04006AF7 RID: 27383
		private Dictionary<int, TileInsData> _gridInsDataDictionary;

		// Token: 0x04006AF8 RID: 27384
		public readonly float GridItemTipTimeInterval = 3f;

		// Token: 0x04006AF9 RID: 27385
		public readonly int TeamDuplicationCostItemIdWithNormalLevel = 17;

		// Token: 0x04006AFA RID: 27386
		public readonly int TeamDuplicationCostItemNumberWithNormalLevel = 18;

		// Token: 0x04006AFB RID: 27387
		public readonly int TeamDuplicationCostItemIdWith65Level = 204;

		// Token: 0x04006AFC RID: 27388
		public readonly int TeamDuplicationCostItemNumberWith65Level = 205;

		// Token: 0x04006AFD RID: 27389
		public readonly int TeamDuplicationMonsterFieldId = 217;

		// Token: 0x04006AFE RID: 27390
		public readonly int TeamDuplicationCaptainMoveCdTableId = 218;

		// Token: 0x04006AFF RID: 27391
		public readonly int TeamDuplicationPassTimesIdWithNormalLevel = 25;

		// Token: 0x04006B00 RID: 27392
		public readonly int TeamDuplicationEquipScoreIdWithNormalLevel = 26;

		// Token: 0x04006B01 RID: 27393
		public readonly int TeamDuplicationPassTimesIdWith65Level = 213;

		// Token: 0x04006B02 RID: 27394
		public readonly int TeamDuplicationEquipScoreIdWith65Level = 214;

		// Token: 0x04006B03 RID: 27395
		private int _costItemIdWithNormalLevel;

		// Token: 0x04006B04 RID: 27396
		private int _costItemNumberWithNormalLevel;

		// Token: 0x04006B05 RID: 27397
		private int _costItemIdWith65Level;

		// Token: 0x04006B06 RID: 27398
		private int _costItemNumberWith65Level;

		// Token: 0x04006B07 RID: 27399
		private int _monsterFieldId;

		// Token: 0x04006B08 RID: 27400
		private int _captainMoveCdTime;

		// Token: 0x04006B09 RID: 27401
		private int _passTimesWithNormalLevel;

		// Token: 0x04006B0A RID: 27402
		private int _equipScoreWithNormalLevel;

		// Token: 0x04006B0B RID: 27403
		private int _passTimesWith65Level;

		// Token: 0x04006B0C RID: 27404
		private int _equipScoreWith65Level;
	}
}
