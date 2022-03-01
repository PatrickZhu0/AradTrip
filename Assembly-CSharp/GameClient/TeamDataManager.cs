using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200130E RID: 4878
	internal class TeamDataManager : DataManager<TeamDataManager>
	{
		// Token: 0x17001B7C RID: 7036
		// (get) Token: 0x0600BD3D RID: 48445 RVA: 0x002C438B File Offset: 0x002C278B
		public TeamSearchInfo SearchInfo
		{
			get
			{
				return this.m_searchInfo;
			}
		}

		// Token: 0x17001B7D RID: 7037
		// (get) Token: 0x0600BD3E RID: 48446 RVA: 0x002C4393 File Offset: 0x002C2793
		public TeamCreateInfo CreateInfo
		{
			get
			{
				return this.m_createInfo;
			}
		}

		// Token: 0x17001B7E RID: 7038
		// (get) Token: 0x0600BD3F RID: 48447 RVA: 0x002C439B File Offset: 0x002C279B
		public TeamChangeInfo ChangeInfo
		{
			get
			{
				return this.m_changeInfo;
			}
		}

		// Token: 0x17001B7F RID: 7039
		// (get) Token: 0x0600BD40 RID: 48448 RVA: 0x002C43A3 File Offset: 0x002C27A3
		// (set) Token: 0x0600BD41 RID: 48449 RVA: 0x002C43AB File Offset: 0x002C27AB
		public ushort PageTeamCount { get; private set; }

		// Token: 0x17001B80 RID: 7040
		// (get) Token: 0x0600BD42 RID: 48450 RVA: 0x002C43B4 File Offset: 0x002C27B4
		// (set) Token: 0x0600BD43 RID: 48451 RVA: 0x002C43BC File Offset: 0x002C27BC
		public ushort CurrentTeamIndex { get; private set; }

		// Token: 0x17001B81 RID: 7041
		// (get) Token: 0x0600BD44 RID: 48452 RVA: 0x002C43C5 File Offset: 0x002C27C5
		// (set) Token: 0x0600BD45 RID: 48453 RVA: 0x002C43CD File Offset: 0x002C27CD
		public ushort MaxTeamCount { get; private set; }

		// Token: 0x17001B82 RID: 7042
		// (get) Token: 0x0600BD46 RID: 48454 RVA: 0x002C43D6 File Offset: 0x002C27D6
		// (set) Token: 0x0600BD47 RID: 48455 RVA: 0x002C43DE File Offset: 0x002C27DE
		public uint TeamDungeonID
		{
			get
			{
				return this.mTeamDungeonID;
			}
			set
			{
				this.mTeamDungeonID = value;
			}
		}

		// Token: 0x17001B83 RID: 7043
		// (get) Token: 0x0600BD49 RID: 48457 RVA: 0x002C43F0 File Offset: 0x002C27F0
		// (set) Token: 0x0600BD48 RID: 48456 RVA: 0x002C43E7 File Offset: 0x002C27E7
		public bool NotPopUpTeamList { get; set; }

		// Token: 0x17001B84 RID: 7044
		// (get) Token: 0x0600BD4B RID: 48459 RVA: 0x002C4401 File Offset: 0x002C2801
		// (set) Token: 0x0600BD4A RID: 48458 RVA: 0x002C43F8 File Offset: 0x002C27F8
		public int CreateTeamDungeonID { get; set; }

		// Token: 0x0600BD4C RID: 48460 RVA: 0x002C440C File Offset: 0x002C280C
		public bool IsDuoLuoTeamDungeonID(int iTeamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iTeamDungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
			return tableItem2 != null && (tableItem2.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem2.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL);
		}

		// Token: 0x0600BD4D RID: 48461 RVA: 0x002C4478 File Offset: 0x002C2878
		public int GetTargetTeamDungeonID(int iID, int iHard)
		{
			List<int> list = new List<int>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			dictionary.Clear();
			list = Utility.GetTeamDungeonMenuFliterList(ref dictionary);
			if (iID == 1)
			{
				return 1;
			}
			if (list.Contains(iID))
			{
				return 0;
			}
			if (iHard == -1)
			{
				return 0;
			}
			int result = iID;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty) == null)
				{
					if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
					{
						result = iID;
					}
				}
				else
				{
					foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
					{
						List<int> value = keyValuePair.Value;
						if (value != null && value.Contains(iID))
						{
							for (int i = 0; i < value.Count; i++)
							{
								TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(value[i], string.Empty, string.Empty);
								if (tableItem2 != null)
								{
									DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
									if (tableItem3 != null)
									{
										if (tableItem3.Hard == (DungeonTable.eHard)iHard)
										{
											result = value[i];
											break;
										}
									}
								}
							}
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600BD4E RID: 48462 RVA: 0x002C460C File Offset: 0x002C2A0C
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.TeamDataManager;
		}

		// Token: 0x0600BD4F RID: 48463 RVA: 0x002C4610 File Offset: 0x002C2A10
		public override void Initialize()
		{
			this.nTeamGuildDungeonID = this.GetTeamGuildDungeonID();
			this.Clear();
			NetProcess.AddMsgHandler(601601U, new Action<MsgDATA>(this._OnNetSyncMyTeamInfo));
		}

		// Token: 0x0600BD50 RID: 48464 RVA: 0x002C463C File Offset: 0x002C2A3C
		public override void Clear()
		{
			this.TeamDungeonID = 0U;
			this._ClearTeamData();
			this._UnBindNetMsg();
			NetProcess.RemoveMsgHandler(601601U, new Action<MsgDATA>(this._OnNetSyncMyTeamInfo));
			TeamDataManager.AutomaticBackIsStart = false;
			this.AutoMaticBackEndTime = 60U;
			this.AutoMaticBackTimer = 0f;
			this.AutonMaticBackRemainTime = 0;
			TeamDataManager.iAutoMaticBackRemainTime = 0;
			this.bStateChanged = false;
			TeamDataManager.bIsRefreshTime = false;
		}

		// Token: 0x0600BD51 RID: 48465 RVA: 0x002C46A8 File Offset: 0x002C2AA8
		public void CreateTeam(uint teamDungeonID)
		{
			WorldCreateTeam worldCreateTeam = new WorldCreateTeam();
			worldCreateTeam.target = teamDungeonID;
			this.TeamDungeonID = teamDungeonID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldCreateTeam>(ServerType.GATE_SERVER, worldCreateTeam);
		}

		// Token: 0x0600BD52 RID: 48466 RVA: 0x002C46D8 File Offset: 0x002C2AD8
		public void ChangeTeamInfo(TeamOptionOperType OperType, int param1)
		{
			WorldSetTeamOption worldSetTeamOption = new WorldSetTeamOption();
			worldSetTeamOption.type = (byte)OperType;
			worldSetTeamOption.param1 = (uint)param1;
			worldSetTeamOption.str = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSetTeamOption>(ServerType.GATE_SERVER, worldSetTeamOption);
		}

		// Token: 0x0600BD53 RID: 48467 RVA: 0x002C4714 File Offset: 0x002C2B14
		public void SendSceneSaveOptionsReq(SaveOptionMask saveOptionMask, bool bSet)
		{
			SceneSaveOptionsReq sceneSaveOptionsReq = new SceneSaveOptionsReq();
			uint num = DataManager<PlayerBaseData>.GetInstance().gameOptions;
			if (bSet)
			{
				num |= (uint)saveOptionMask;
			}
			else
			{
				num &= (uint)(~(uint)saveOptionMask);
			}
			sceneSaveOptionsReq.options = num;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneSaveOptionsReq>(ServerType.GATE_SERVER, sceneSaveOptionsReq);
		}

		// Token: 0x0600BD54 RID: 48468 RVA: 0x002C475C File Offset: 0x002C2B5C
		public void JoinTeam(ulong teamLeaderID)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("跨服公会战场景下无法加入队伍", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 2;
			sceneRequest.target = teamLeaderID;
			sceneRequest.param = 0U;
			sceneRequest.targetName = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldJoinTeamRes>(delegate(WorldJoinTeamRes msgRet)
			{
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatTeamJoin, null, null, null, null);
					if (msgRet.inTeam == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("队长已收到你的组队请求，请等待处理", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
			}, true, 15f, null);
		}

		// Token: 0x0600BD55 RID: 48469 RVA: 0x002C4830 File Offset: 0x002C2C30
		public bool HasPassward(ulong teamLeaderID)
		{
			Team team = this.m_teamList.Find((Team data) => data.leaderInfo.id == teamLeaderID);
			if (team != null)
			{
			}
			return false;
		}

		// Token: 0x0600BD56 RID: 48470 RVA: 0x002C486C File Offset: 0x002C2C6C
		public void QuitTeam(ulong id)
		{
			if (this.HasTeam())
			{
				WorldLeaveTeamReq worldLeaveTeamReq = new WorldLeaveTeamReq();
				worldLeaveTeamReq.id = id;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldLeaveTeamReq>(ServerType.GATE_SERVER, worldLeaveTeamReq);
			}
		}

		// Token: 0x0600BD57 RID: 48471 RVA: 0x002C48A0 File Offset: 0x002C2CA0
		public void KickTeamMember(ulong id)
		{
			if (this.IsTeamLeader())
			{
				WorldLeaveTeamReq worldLeaveTeamReq = new WorldLeaveTeamReq();
				worldLeaveTeamReq.id = id;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldLeaveTeamReq>(ServerType.GATE_SERVER, worldLeaveTeamReq);
			}
		}

		// Token: 0x0600BD58 RID: 48472 RVA: 0x002C48D4 File Offset: 0x002C2CD4
		public void ChangeTeamLeader(ulong id)
		{
			if (this.IsTeamLeader())
			{
				WorldTransferTeammaster worldTransferTeammaster = new WorldTransferTeammaster();
				worldTransferTeammaster.id = id;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldTransferTeammaster>(ServerType.GATE_SERVER, worldTransferTeammaster);
			}
		}

		// Token: 0x0600BD59 RID: 48473 RVA: 0x002C4908 File Offset: 0x002C2D08
		public void ChangeTeamPosState(byte pos, byte opened)
		{
			if (this.IsTeamLeader())
			{
				WorldTeamChangePosStatusReq worldTeamChangePosStatusReq = new WorldTeamChangePosStatusReq();
				worldTeamChangePosStatusReq.pos = pos;
				worldTeamChangePosStatusReq.open = opened;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldTeamChangePosStatusReq>(ServerType.GATE_SERVER, worldTeamChangePosStatusReq);
			}
		}

		// Token: 0x0600BD5A RID: 48474 RVA: 0x002C4944 File Offset: 0x002C2D44
		public void ChangeMainPlayerAssitState()
		{
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (teamMemberByMemberID != null)
			{
				WorldChangeAssistModeReq worldChangeAssistModeReq = new WorldChangeAssistModeReq();
				worldChangeAssistModeReq.isAssist = ((!teamMemberByMemberID.isAssist) ? 1 : 0);
				NetManager.Instance().SendCommand<WorldChangeAssistModeReq>(ServerType.GATE_SERVER, worldChangeAssistModeReq);
			}
		}

		// Token: 0x0600BD5B RID: 48475 RVA: 0x002C4994 File Offset: 0x002C2D94
		public void ChangePrepareState()
		{
			if (!this.IsTeamLeader())
			{
				WorldTeamReadyReq worldTeamReadyReq = new WorldTeamReadyReq();
				worldTeamReadyReq.ready = ((!this.GetTeamMemberByMemberID(DataManager<PlayerBaseData>.GetInstance().RoleID).isPrepared) ? 1 : 0);
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldTeamReadyReq>(ServerType.GATE_SERVER, worldTeamReadyReq);
			}
		}

		// Token: 0x0600BD5C RID: 48476 RVA: 0x002C49E9 File Offset: 0x002C2DE9
		public List<Team> GetTeamList()
		{
			return this.m_teamList;
		}

		// Token: 0x0600BD5D RID: 48477 RVA: 0x002C49F1 File Offset: 0x002C2DF1
		public List<Team> GetTeamListForTeamMainUI()
		{
			return this.m_teamListForTeamMainUI;
		}

		// Token: 0x0600BD5E RID: 48478 RVA: 0x002C49F9 File Offset: 0x002C2DF9
		public List<NewTeamInviteList> GetInviteTeamList()
		{
			return this.m_InviteTeamList;
		}

		// Token: 0x0600BD5F RID: 48479 RVA: 0x002C4A01 File Offset: 0x002C2E01
		public Team GetMyTeam()
		{
			return this.m_myTeam;
		}

		// Token: 0x0600BD60 RID: 48480 RVA: 0x002C4A09 File Offset: 0x002C2E09
		public bool HasTeam()
		{
			return this.m_myTeam != null;
		}

		// Token: 0x0600BD61 RID: 48481 RVA: 0x002C4A17 File Offset: 0x002C2E17
		public bool IsTeamLeader()
		{
			return this.IsTeamLeaderByRoleID(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x0600BD62 RID: 48482 RVA: 0x002C4A29 File Offset: 0x002C2E29
		public bool IsTeamLeaderByRoleID(ulong roleId)
		{
			return this.m_myTeam != null && this.m_myTeam.leaderInfo.id == roleId;
		}

		// Token: 0x0600BD63 RID: 48483 RVA: 0x002C4A4C File Offset: 0x002C2E4C
		public bool HasNewRequester()
		{
			return this.bHasNewRequester;
		}

		// Token: 0x0600BD64 RID: 48484 RVA: 0x002C4A54 File Offset: 0x002C2E54
		public void ClearNewRequesterMark()
		{
			this.bHasNewRequester = false;
		}

		// Token: 0x0600BD65 RID: 48485 RVA: 0x002C4A60 File Offset: 0x002C2E60
		public bool IsTeammateFriend(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID != null)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(teamMemberByMemberID.id);
					return relationByRoleID != null && relationByRoleID.IsFriend();
				}
			}
			return false;
		}

		// Token: 0x0600BD66 RID: 48486 RVA: 0x002C4AAC File Offset: 0x002C2EAC
		public bool IsTeammateMaster(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID != null)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(teamMemberByMemberID.id);
					return relationByRoleID != null && relationByRoleID.IsMater();
				}
			}
			return false;
		}

		// Token: 0x0600BD67 RID: 48487 RVA: 0x002C4AF8 File Offset: 0x002C2EF8
		public bool IsTeammateDisciple(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID != null)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(teamMemberByMemberID.id);
					return relationByRoleID != null && relationByRoleID.IsDisciple();
				}
			}
			return false;
		}

		// Token: 0x0600BD68 RID: 48488 RVA: 0x002C4B44 File Offset: 0x002C2F44
		public bool IsTeammateGuild(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(DataManager<PlayerBaseData>.GetInstance().RoleID);
				TeamMember teamMemberByMemberID2 = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID2 != null && teamMemberByMemberID != null)
				{
					return teamMemberByMemberID.guildid == teamMemberByMemberID2.guildid && teamMemberByMemberID.guildid != 0UL;
				}
			}
			return false;
		}

		// Token: 0x0600BD69 RID: 48489 RVA: 0x002C4BA8 File Offset: 0x002C2FA8
		public bool IsTeammateHelpFight(ulong memberID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>((int)this.TeamDungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DungeonTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.SubType != DungeonTable.eSubType.S_TEAM_BOSS)
				{
					return false;
				}
			}
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
			return teamMemberByMemberID != null && teamMemberByMemberID.isAssist;
		}

		// Token: 0x0600BD6A RID: 48490 RVA: 0x002C4C20 File Offset: 0x002C3020
		public bool IsTeammateMainPlayer(ulong memberID)
		{
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
			return teamMemberByMemberID != null && teamMemberByMemberID.id == DataManager<PlayerBaseData>.GetInstance().RoleID;
		}

		// Token: 0x0600BD6B RID: 48491 RVA: 0x002C4C50 File Offset: 0x002C3050
		public eTeammateFlag GetTeammateFlag(ulong memberID)
		{
			eTeammateFlag eTeammateFlag = eTeammateFlag.None;
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
			if (teamMemberByMemberID != null)
			{
				if (this.IsTeammateGuild(memberID))
				{
					eTeammateFlag |= eTeammateFlag.Guild;
				}
				if (this.IsTeammateHelpFight(memberID))
				{
					eTeammateFlag |= eTeammateFlag.HelpFight;
				}
				if (this.IsTeammateFriend(memberID))
				{
					eTeammateFlag |= eTeammateFlag.Friend;
				}
				if (this.IsTeammateMaster(memberID))
				{
					eTeammateFlag |= eTeammateFlag.Master;
				}
				if (this.IsTeammateDisciple(memberID))
				{
					eTeammateFlag |= eTeammateFlag.Disciple;
				}
			}
			return eTeammateFlag;
		}

		// Token: 0x0600BD6C RID: 48492 RVA: 0x002C4CC0 File Offset: 0x002C30C0
		public TeamMember GetNewTeamMember()
		{
			if (this.m_myTeam != null)
			{
				for (int i = 0; i < this.m_myTeam.members.Length; i++)
				{
					if (this.m_myTeam.members[i].id <= 0UL)
					{
						return this.m_myTeam.members[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600BD6D RID: 48493 RVA: 0x002C4D20 File Offset: 0x002C3120
		public TeamMember GetTeamMemberByMemberID(ulong id)
		{
			if (this.m_myTeam != null)
			{
				for (int i = 0; i < this.m_myTeam.members.Length; i++)
				{
					if (this.m_myTeam.members[i].id == id)
					{
						return this.m_myTeam.members[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600BD6E RID: 48494 RVA: 0x002C4D80 File Offset: 0x002C3180
		public int GetMemberNum()
		{
			if (this.m_myTeam != null)
			{
				int num = 0;
				for (int i = 0; i < this.m_myTeam.members.Length; i++)
				{
					if (this.m_myTeam.members[i].id != 0UL)
					{
						num++;
					}
				}
				return num;
			}
			return 0;
		}

		// Token: 0x0600BD6F RID: 48495 RVA: 0x002C4DD8 File Offset: 0x002C31D8
		public void RequestSearchTeam(uint teamDungeonID)
		{
			TeamSearchInfo searchInfo = DataManager<TeamDataManager>.GetInstance().SearchInfo;
			searchInfo.Reset();
			this.TeamDungeonID = teamDungeonID;
			DataManager<TeamDataManager>.GetInstance().RequestTeamList(0);
		}

		// Token: 0x0600BD70 RID: 48496 RVA: 0x002C4E08 File Offset: 0x002C3208
		public void RequestSearchTeam(uint teamDungeonID, List<int> IDs)
		{
			TeamSearchInfo searchInfo = DataManager<TeamDataManager>.GetInstance().SearchInfo;
			searchInfo.Reset();
			this.TeamDungeonID = teamDungeonID;
			if (IDs == null || IDs.Count == 0)
			{
				DataManager<TeamDataManager>.GetInstance().RequestTeamList(0);
				return;
			}
			WorldQueryTeamList worldQueryTeamList = new WorldQueryTeamList();
			worldQueryTeamList.teamId = (ushort)this.m_searchInfo.teamID;
			uint[] array = new uint[IDs.Count];
			for (int i = 0; i < IDs.Count; i++)
			{
				array[i] = (uint)IDs[i];
			}
			worldQueryTeamList.targetList = array;
			worldQueryTeamList.startPos = 0;
			worldQueryTeamList.num = (byte)this.PageTeamCount;
			worldQueryTeamList.targetId = this.TeamDungeonID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQueryTeamList>(ServerType.GATE_SERVER, worldQueryTeamList);
		}

		// Token: 0x0600BD71 RID: 48497 RVA: 0x002C4EC8 File Offset: 0x002C32C8
		public void RequestTeamListForTeamMainUI(ushort startIndex, uint TeamDungeonID)
		{
			WorldQueryTeamList worldQueryTeamList = new WorldQueryTeamList();
			worldQueryTeamList.teamId = 0;
			worldQueryTeamList.targetList = this.m_searchInfo.GetTargetTeamList(TeamDungeonID);
			worldQueryTeamList.startPos = startIndex;
			worldQueryTeamList.num = (byte)this.PageTeamCount;
			worldQueryTeamList.targetId = TeamDungeonID;
			worldQueryTeamList.param = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQueryTeamList>(ServerType.GATE_SERVER, worldQueryTeamList);
		}

		// Token: 0x0600BD72 RID: 48498 RVA: 0x002C4F28 File Offset: 0x002C3328
		public void RequestTeamList(ushort startIndex)
		{
			WorldQueryTeamList worldQueryTeamList = new WorldQueryTeamList();
			worldQueryTeamList.teamId = (ushort)this.m_searchInfo.teamID;
			worldQueryTeamList.targetList = this.m_searchInfo.GetTargetTeamList(this.TeamDungeonID);
			worldQueryTeamList.startPos = startIndex;
			worldQueryTeamList.num = (byte)this.PageTeamCount;
			worldQueryTeamList.targetId = this.TeamDungeonID;
			if (this.TeamDungeonID == 1U)
			{
				worldQueryTeamList.targetId = 0U;
			}
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQueryTeamList>(ServerType.GATE_SERVER, worldQueryTeamList);
		}

		// Token: 0x0600BD73 RID: 48499 RVA: 0x002C4FA8 File Offset: 0x002C33A8
		private void _onWorldQueryTeamListRet(MsgDATA data)
		{
			WorldQueryTeamListRet worldQueryTeamListRet = new WorldQueryTeamListRet();
			worldQueryTeamListRet.decode(data.bytes);
			if (this.GetMyTeam() != null)
			{
				return;
			}
			if (worldQueryTeamListRet.param == 1)
			{
				this.m_teamListForTeamMainUI.Clear();
				for (int i = 0; i < worldQueryTeamListRet.teamList.Length; i++)
				{
					TeamBaseInfo teamBaseInfo = worldQueryTeamListRet.teamList[i];
					Team team = new Team();
					team.teamID = teamBaseInfo.teamId;
					team.teamDungeonID = teamBaseInfo.target;
					team.leaderInfo = teamBaseInfo.masterInfo;
					team.maxMemberCount = teamBaseInfo.maxMemberNum;
					team.currentMemberCount = teamBaseInfo.memberNum;
					this.m_teamListForTeamMainUI.Add(team);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamListRequestSuccessForTeamMainUI, null, null, null, null);
			}
			else
			{
				this.m_teamList.Clear();
				this.TeamDungeonID = worldQueryTeamListRet.targetId;
				if (this.TeamDungeonID == 0U)
				{
					this.TeamDungeonID = 1U;
				}
				for (int j = 0; j < worldQueryTeamListRet.teamList.Length; j++)
				{
					TeamBaseInfo teamBaseInfo2 = worldQueryTeamListRet.teamList[j];
					Team team2 = new Team();
					team2.teamID = teamBaseInfo2.teamId;
					team2.teamDungeonID = teamBaseInfo2.target;
					team2.leaderInfo = teamBaseInfo2.masterInfo;
					team2.maxMemberCount = teamBaseInfo2.maxMemberNum;
					team2.currentMemberCount = teamBaseInfo2.memberNum;
					this.m_teamList.Add(team2);
				}
				this.m_teamList.Sort(delegate(Team a, Team b)
				{
					if (a == null || b == null)
					{
						return 0;
					}
					if (a.leaderInfo == null || b.leaderInfo == null)
					{
						return 0;
					}
					if (a.leaderInfo.playerLabelInfo == null || b.leaderInfo.playerLabelInfo == null)
					{
						return 0;
					}
					RelationData relationData = null;
					bool flag = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(a.leaderInfo.id, ref relationData);
					bool flag2 = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(b.leaderInfo.id, ref relationData);
					bool value = DataManager<GuildDataManager>.GetInstance().IsSameGuild(a.leaderInfo.playerLabelInfo.guildId);
					bool flag3 = DataManager<GuildDataManager>.GetInstance().IsSameGuild(b.leaderInfo.playerLabelInfo.guildId);
					if (a.leaderInfo.playerLabelInfo.returnStatus != b.leaderInfo.playerLabelInfo.returnStatus)
					{
						return (int)(b.leaderInfo.playerLabelInfo.returnStatus - a.leaderInfo.playerLabelInfo.returnStatus);
					}
					if (flag != flag2)
					{
						return flag2.CompareTo(flag);
					}
					return flag3.CompareTo(value);
				});
				this.MaxTeamCount = worldQueryTeamListRet.maxNum;
				this.CurrentTeamIndex = worldQueryTeamListRet.pos;
				for (int k = 0; k < this.m_teamList.Count; k++)
				{
					this.m_teamList[k].Debug();
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamListRequestSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BD74 RID: 48500 RVA: 0x002C51A4 File Offset: 0x002C35A4
		private void _onWorldTeamInviteClearNotifyRet(MsgDATA data)
		{
			WorldTeamInviteClearNotify worldTeamInviteClearNotify = new WorldTeamInviteClearNotify();
			worldTeamInviteClearNotify.decode(data.bytes);
			for (int i = 0; i < this.m_InviteTeamList.Count; i++)
			{
				if ((ulong)this.m_InviteTeamList[i].baseinfo.teamId == (ulong)((long)worldTeamInviteClearNotify.teamId))
				{
					this.m_InviteTeamList.RemoveAt(i);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
					break;
				}
			}
		}

		// Token: 0x0600BD75 RID: 48501 RVA: 0x002C5228 File Offset: 0x002C3628
		private void _onWorldTeamInviteSyncAttrRet(MsgDATA data)
		{
			WorldTeamInviteSyncAttr worldTeamInviteSyncAttr = new WorldTeamInviteSyncAttr();
			worldTeamInviteSyncAttr.decode(data.bytes);
			for (int i = 0; i < this.m_InviteTeamList.Count; i++)
			{
				if ((ulong)this.m_InviteTeamList[i].baseinfo.teamId == (ulong)((long)worldTeamInviteSyncAttr.teamId))
				{
					this.m_InviteTeamList[i].baseinfo.target = (uint)worldTeamInviteSyncAttr.target;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
					break;
				}
			}
		}

		// Token: 0x0600BD76 RID: 48502 RVA: 0x002C52BC File Offset: 0x002C36BC
		private void _onWorldNotifyTeamKick(MsgDATA data)
		{
			WorldNotifyTeamKick worldNotifyTeamKick = new WorldNotifyTeamKick();
			worldNotifyTeamKick.decode(data.bytes);
			if (worldNotifyTeamKick.endTime != 0UL)
			{
				TeamDataManager.StartServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				this.AutoMaticBackEndTime = (uint)(worldNotifyTeamKick.endTime / 1000UL);
				this.AutonMaticBackRemainTime = (int)(this.AutoMaticBackEndTime - TeamDataManager.StartServerTime);
				TeamDataManager.iAutoMaticBackRemainTime = this.AutonMaticBackRemainTime;
			}
			else
			{
				TeamDataManager.AutomaticBackIsStart = false;
			}
			if (this.AutonMaticBackRemainTime <= 60)
			{
				TeamDataManager.AutomaticBackIsStart = (worldNotifyTeamKick.endTime != 0UL);
				this.UpdateStateChanged();
			}
		}

		// Token: 0x0600BD77 RID: 48503 RVA: 0x002C5358 File Offset: 0x002C3758
		private void UpdateStateChanged()
		{
			if (this.bStateChanged != TeamDataManager.AutomaticBackIsStart)
			{
				this.bStateChanged = TeamDataManager.AutomaticBackIsStart;
				this.AutoMaticBackTimer = 0f;
				if (TeamDataManager.AutomaticBackIsStart)
				{
					TeamDataManager.iAutoMaticBackRemainTime = this.AutonMaticBackRemainTime;
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamTimeChanged, 0, null, null, null);
				}
			}
		}

		// Token: 0x0600BD78 RID: 48504 RVA: 0x002C53C0 File Offset: 0x002C37C0
		public List<TeamChapter> GetChapterList()
		{
			if (this.m_arrChapters.Count <= 0)
			{
				TeamChapter teamChapter = new TeamChapter();
				teamChapter.id = 0U;
				teamChapter.isOpened = true;
				teamChapter.name = TR.Value("team_chapter_nolimit");
				teamChapter.dataPath = string.Empty;
				this.m_arrChapters.Add(teamChapter);
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CitySceneTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					CitySceneTable citySceneTable = keyValuePair.Value as CitySceneTable;
					if (citySceneTable.SceneType == CitySceneTable.eSceneType.DUNGEON_ENTRY)
					{
						TeamChapter teamChapter2 = new TeamChapter();
						teamChapter2.id = (uint)citySceneTable.ID;
						teamChapter2.isOpened = true;
						teamChapter2.name = citySceneTable.Name;
						teamChapter2.dataPath = citySceneTable.ChapterData[0];
						this.m_arrChapters.Add(teamChapter2);
					}
				}
			}
			return this.m_arrChapters;
		}

		// Token: 0x0600BD79 RID: 48505 RVA: 0x002C54B0 File Offset: 0x002C38B0
		public List<TeamDungeon> GetDungeonList(uint chapterID)
		{
			TeamChapter teamChapter = this.m_arrChapters.Find((TeamChapter data) => data.id == chapterID);
			if (teamChapter != null)
			{
				if (teamChapter.dungeons.Count <= 0)
				{
					TeamDungeon teamDungeon = new TeamDungeon();
					teamDungeon.id = 0U;
					teamDungeon.isOpened = true;
					teamDungeon.maxHardType = 3;
					teamDungeon.name = TR.Value("team_dungeon_nolimit");
					teamChapter.dungeons.Add(teamDungeon);
					DChapterData dchapterData = Singleton<AssetLoader>.instance.LoadRes(teamChapter.dataPath, true, 0U).obj as DChapterData;
					if (dchapterData != null)
					{
						for (int i = 0; i < dchapterData.chapterList.Length; i++)
						{
							uint dungeonID = (uint)dchapterData.chapterList[i].dungeonID;
							DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>((int)dungeonID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								TeamDungeon teamDungeon2 = new TeamDungeon();
								teamDungeon2.id = dungeonID;
								bool isOpened;
								int num;
								if (DataManager<BattleDataManager>.GetInstance().ChapterInfo.IsOpen((int)dungeonID, out isOpened, out num))
								{
									teamDungeon2.isOpened = isOpened;
									teamDungeon2.maxHardType = (byte)num;
								}
								else
								{
									teamDungeon2.isOpened = false;
									teamDungeon2.maxHardType = 0;
								}
								teamDungeon2.name = tableItem.Name;
								teamChapter.dungeons.Add(teamDungeon2);
							}
						}
					}
				}
				return teamChapter.dungeons;
			}
			return null;
		}

		// Token: 0x0600BD7A RID: 48506 RVA: 0x002C561C File Offset: 0x002C3A1C
		public string GetTeamChapterName(uint chapterID)
		{
			List<TeamChapter> chapterList = this.GetChapterList();
			if (chapterList != null && chapterList.Count > 0)
			{
				TeamChapter teamChapter = chapterList.Find((TeamChapter data) => data.id == chapterID);
				if (teamChapter != null)
				{
					return teamChapter.name;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600BD7B RID: 48507 RVA: 0x002C5674 File Offset: 0x002C3A74
		public string GetTeamDungeonName(uint chapterID, uint dungeonID)
		{
			if (chapterID == 0U)
			{
				return TR.Value("team_dungeon_nolimit");
			}
			List<TeamDungeon> dungeonList = this.GetDungeonList(chapterID);
			if (dungeonList != null && dungeonList.Count > 0)
			{
				TeamDungeon teamDungeon = dungeonList.Find((TeamDungeon data) => data.id == dungeonID);
				if (teamDungeon != null)
				{
					return teamDungeon.name;
				}
			}
			return string.Empty;
		}

		// Token: 0x0600BD7C RID: 48508 RVA: 0x002C56E0 File Offset: 0x002C3AE0
		public static string GetTeamDungeonName(uint teamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)teamDungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.Name;
			}
			return string.Empty;
		}

		// Token: 0x0600BD7D RID: 48509 RVA: 0x002C5718 File Offset: 0x002C3B18
		public static int GetTeamDungeonIDByDungeonID(int dungeonID)
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<TeamDungeonTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
					if (teamDungeonTable != null)
					{
						if (teamDungeonTable.DungeonID == dungeonID)
						{
							return teamDungeonTable.ID;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600BD7E RID: 48510 RVA: 0x002C5784 File Offset: 0x002C3B84
		private uint GetTeamGuildDungeonID()
		{
			List<int> list = new List<int>();
			Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
			if (list == null || dictionary == null)
			{
				return 0U;
			}
			dictionary.Clear();
			list = Utility.GetTeamDungeonMenuFliterList(ref dictionary);
			for (int i = 0; i < list.Count; i++)
			{
				if (dictionary.ContainsKey(list[i]))
				{
					List<int> list2 = dictionary[list[i]];
					for (int j = 0; j < list2.Count; j++)
					{
						TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list2[j], string.Empty, string.Empty);
						if (tableItem != null)
						{
							DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.SubType == DungeonTable.eSubType.S_GUILD_DUNGEON)
								{
									return (uint)list[i];
								}
							}
						}
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600BD7F RID: 48511 RVA: 0x002C5878 File Offset: 0x002C3C78
		public string GeDungeontHardName(byte hard)
		{
			if (hard == 255)
			{
				return TR.Value("team_target_diff_all");
			}
			switch (hard)
			{
			case 0:
				return TR.Value("team_target_diff_normal");
			case 1:
				return TR.Value("team_target_diff_risk");
			case 2:
				return TR.Value("team_target_diff_warrior");
			case 3:
				return TR.Value("team_target_diff_king");
			default:
				return string.Empty;
			}
		}

		// Token: 0x0600BD80 RID: 48512 RVA: 0x002C58EC File Offset: 0x002C3CEC
		private void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(601627U, new Action<MsgDATA>(this._OnNetSyncCreateTeamSuccess));
				NetProcess.AddMsgHandler(601602U, new Action<MsgDATA>(this._OnNetSyncAddTeamMember));
				NetProcess.AddMsgHandler(601604U, new Action<MsgDATA>(this._OnTeamMemberLeave));
				NetProcess.AddMsgHandler(601609U, new Action<MsgDATA>(this._OnTeamLeaderChanged));
				NetProcess.AddMsgHandler(601631U, new Action<MsgDATA>(this._OnNetSyncTeamPosState));
				NetProcess.AddMsgHandler(601605U, new Action<MsgDATA>(this._OnNetSyncMemberState));
				NetProcess.AddMsgHandler(601626U, new Action<MsgDATA>(this._OnNetSyncChangeTeamInfo));
				NetProcess.AddMsgHandler(601646U, new Action<MsgDATA>(this._OnRequestResultNotify));
				NetProcess.AddMsgHandler(500803U, new Action<MsgDATA>(this._OnNetSyncChat));
				NetProcess.AddMsgHandler(601642U, new Action<MsgDATA>(this._OnNetSyncTeamEnterDungeonVoteNotify));
				NetProcess.AddMsgHandler(601644U, new Action<MsgDATA>(this._OnNetSyncTeamInviteRes));
				NetProcess.AddMsgHandler(601645U, new Action<MsgDATA>(this._OnNetSyncTeamInviteNotify));
				NetProcess.AddMsgHandler(601637U, new Action<MsgDATA>(this._OnNotifyNewRequester));
				NetProcess.AddMsgHandler(601647U, new Action<MsgDATA>(this._OnNotifyVoteChoice));
				NetProcess.AddMsgHandler(501605U, new Action<MsgDATA>(this._OnTeamMatchStartRes));
				NetProcess.AddMsgHandler(601651U, new Action<MsgDATA>(this._OnTeamMatchCancelRes));
				NetProcess.AddMsgHandler(601648U, new Action<MsgDATA>(this._OnTeamMatchResultNotify));
				NetProcess.AddMsgHandler(601654U, new Action<MsgDATA>(this._onWorldSyncTeamMemberProperty));
				NetProcess.AddMsgHandler(601636U, new Action<MsgDATA>(this._onWorldSyncTeammemberAvatar));
				NetProcess.AddMsgHandler(601624U, new Action<MsgDATA>(this._onWorldQueryTeamListRet));
				NetProcess.AddMsgHandler(601656U, new Action<MsgDATA>(this._onWorldTeamInviteClearNotifyRet));
				NetProcess.AddMsgHandler(601657U, new Action<MsgDATA>(this._onWorldTeamInviteSyncAttrRet));
				NetProcess.AddMsgHandler(601660U, new Action<MsgDATA>(this._onWorldNotifyTeamKick));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600BD81 RID: 48513 RVA: 0x002C5B08 File Offset: 0x002C3F08
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(601627U, new Action<MsgDATA>(this._OnNetSyncCreateTeamSuccess));
			NetProcess.RemoveMsgHandler(601602U, new Action<MsgDATA>(this._OnNetSyncAddTeamMember));
			NetProcess.RemoveMsgHandler(601604U, new Action<MsgDATA>(this._OnTeamMemberLeave));
			NetProcess.RemoveMsgHandler(601609U, new Action<MsgDATA>(this._OnTeamLeaderChanged));
			NetProcess.RemoveMsgHandler(601631U, new Action<MsgDATA>(this._OnNetSyncTeamPosState));
			NetProcess.RemoveMsgHandler(601605U, new Action<MsgDATA>(this._OnNetSyncMemberState));
			NetProcess.RemoveMsgHandler(601626U, new Action<MsgDATA>(this._OnNetSyncChangeTeamInfo));
			NetProcess.RemoveMsgHandler(601646U, new Action<MsgDATA>(this._OnRequestResultNotify));
			NetProcess.RemoveMsgHandler(500803U, new Action<MsgDATA>(this._OnNetSyncChat));
			NetProcess.RemoveMsgHandler(601642U, new Action<MsgDATA>(this._OnNetSyncTeamEnterDungeonVoteNotify));
			NetProcess.RemoveMsgHandler(601644U, new Action<MsgDATA>(this._OnNetSyncTeamInviteRes));
			NetProcess.RemoveMsgHandler(601645U, new Action<MsgDATA>(this._OnNetSyncTeamInviteNotify));
			NetProcess.RemoveMsgHandler(601637U, new Action<MsgDATA>(this._OnNotifyNewRequester));
			NetProcess.RemoveMsgHandler(601647U, new Action<MsgDATA>(this._OnNotifyVoteChoice));
			NetProcess.RemoveMsgHandler(501605U, new Action<MsgDATA>(this._OnTeamMatchStartRes));
			NetProcess.RemoveMsgHandler(601651U, new Action<MsgDATA>(this._OnTeamMatchCancelRes));
			NetProcess.RemoveMsgHandler(601648U, new Action<MsgDATA>(this._OnTeamMatchResultNotify));
			NetProcess.RemoveMsgHandler(601654U, new Action<MsgDATA>(this._onWorldSyncTeamMemberProperty));
			NetProcess.RemoveMsgHandler(601636U, new Action<MsgDATA>(this._onWorldSyncTeammemberAvatar));
			NetProcess.RemoveMsgHandler(601624U, new Action<MsgDATA>(this._onWorldQueryTeamListRet));
			NetProcess.RemoveMsgHandler(601656U, new Action<MsgDATA>(this._onWorldTeamInviteClearNotifyRet));
			NetProcess.RemoveMsgHandler(601657U, new Action<MsgDATA>(this._onWorldTeamInviteSyncAttrRet));
			NetProcess.RemoveMsgHandler(601660U, new Action<MsgDATA>(this._onWorldNotifyTeamKick));
			this.m_bNetBind = false;
		}

		// Token: 0x0600BD82 RID: 48514 RVA: 0x002C5D18 File Offset: 0x002C4118
		private void _OnNetSyncMyTeamInfo(MsgDATA msg)
		{
			this._BindNetMsg();
			WorldSyncTeamInfo worldSyncTeamInfo = new WorldSyncTeamInfo();
			worldSyncTeamInfo.decode(msg.bytes);
			if (worldSyncTeamInfo.id <= 0)
			{
				return;
			}
			this.m_myTeam = new Team();
			this.m_myTeam.teamID = (uint)worldSyncTeamInfo.id;
			this.m_myTeam.leaderInfo = new TeammemberBaseInfo();
			this.m_myTeam.leaderInfo.id = worldSyncTeamInfo.master;
			this.m_myTeam.autoAgree = (uint)worldSyncTeamInfo.autoAgree;
			this.TeamDungeonID = worldSyncTeamInfo.target;
			this.bAutoAgree = false;
			this.IsAutoReturnFormHell = ((worldSyncTeamInfo.options & 1U) == 1U);
			for (int i = 0; i < this.m_myTeam.members.Length; i++)
			{
				TeamMember teamMember = new TeamMember();
				teamMember.ClearPlayerInfo();
				this.m_myTeam.members[i] = teamMember;
			}
			if (worldSyncTeamInfo.members.Length > this.m_myTeam.members.Length)
			{
				string str = string.Format("队伍成员数量<{0}>超过设计的数量<{1}>,检查服务端数据，队伍id{2}, 队伍目标id{3} 队伍成员:\n", new object[]
				{
					worldSyncTeamInfo.members.Length,
					this.m_myTeam.members.Length - 1,
					worldSyncTeamInfo.id,
					worldSyncTeamInfo.target
				});
				for (int j = 0; j < worldSyncTeamInfo.members.Length; j++)
				{
					TeammemberInfo teammemberInfo = worldSyncTeamInfo.members[j];
					if (teammemberInfo != null)
					{
						str += string.Format("id:{0}, 名字{1}\n", teammemberInfo.id, teammemberInfo.name);
					}
					else
					{
						str += string.Format("下标为{0}的数组成员为空", j);
					}
				}
			}
			int num = 0;
			for (int k = 0; k < worldSyncTeamInfo.members.Length; k++)
			{
				if (worldSyncTeamInfo.members[k].id > 0UL)
				{
					if (k < this.m_myTeam.members.Length)
					{
						this._ParseMemberData(worldSyncTeamInfo.members[k], this.m_myTeam.members[num]);
						num++;
					}
				}
			}
			this._UpdateMemberCountInfo();
			this._DebugTeamData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateGameOptions, null, null, null, null);
		}

		// Token: 0x0600BD83 RID: 48515 RVA: 0x002C5F6C File Offset: 0x002C436C
		private void _OnNetSyncChangeTeamInfo(MsgDATA msg)
		{
			if (this.m_myTeam != null)
			{
				WorldSyncTeamOption worldSyncTeamOption = new WorldSyncTeamOption();
				worldSyncTeamOption.decode(msg.bytes);
				if (worldSyncTeamOption.type == 0)
				{
					this.TeamDungeonID = worldSyncTeamOption.param1;
				}
				else if (worldSyncTeamOption.type == 1)
				{
					this.m_myTeam.autoAgree = worldSyncTeamOption.param1;
				}
				else if (worldSyncTeamOption.type == 2)
				{
					this.IsAutoReturnFormHell = (worldSyncTeamOption.param1 == 1U);
				}
				this._DebugTeamData();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamInfoUpdateSuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BD84 RID: 48516 RVA: 0x002C6008 File Offset: 0x002C4408
		private void _onWorldSyncTeammemberAvatar(MsgDATA msg)
		{
			WorldSyncTeammemberAvatar worldSyncTeammemberAvatar = new WorldSyncTeammemberAvatar();
			worldSyncTeammemberAvatar.decode(msg.bytes);
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(worldSyncTeammemberAvatar.memberId);
			if (teamMemberByMemberID != null)
			{
				teamMemberByMemberID.avatarInfo = worldSyncTeammemberAvatar.avatar;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamMemberStateChanged, null, null, null, null);
			}
		}

		// Token: 0x0600BD85 RID: 48517 RVA: 0x002C605C File Offset: 0x002C445C
		private void _onWorldSyncTeamMemberProperty(MsgDATA msg)
		{
			WorldSyncTeamMemberProperty worldSyncTeamMemberProperty = new WorldSyncTeamMemberProperty();
			worldSyncTeamMemberProperty.decode(msg.bytes);
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(worldSyncTeamMemberProperty.memberId);
			if (teamMemberByMemberID != null)
			{
				switch (worldSyncTeamMemberProperty.type)
				{
				case 0:
					teamMemberByMemberID.level = (ushort)worldSyncTeamMemberProperty.value;
					break;
				case 1:
					teamMemberByMemberID.guildid = worldSyncTeamMemberProperty.value;
					break;
				case 2:
					teamMemberByMemberID.dungeonLeftCount = (int)worldSyncTeamMemberProperty.value;
					break;
				case 3:
					teamMemberByMemberID.occu = (byte)worldSyncTeamMemberProperty.value;
					break;
				case 4:
					this._updateTeammateStatus(teamMemberByMemberID, (byte)worldSyncTeamMemberProperty.value);
					break;
				case 5:
					teamMemberByMemberID.viplevel = (ushort)worldSyncTeamMemberProperty.value;
					break;
				case 6:
					teamMemberByMemberID.resistMagicValue = (uint)worldSyncTeamMemberProperty.value;
					break;
				case 7:
					teamMemberByMemberID.playerLabelInfo = worldSyncTeamMemberProperty.playerLabelInfo;
					break;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamMemberStateChanged, null, null, null, null);
			}
		}

		// Token: 0x0600BD86 RID: 48518 RVA: 0x002C6164 File Offset: 0x002C4564
		private void _OnRequestResultNotify(MsgDATA msg)
		{
			WorldTeamRequestResultNotify worldTeamRequestResultNotify = new WorldTeamRequestResultNotify();
			worldTeamRequestResultNotify.decode(msg.bytes);
			if (worldTeamRequestResultNotify.agree == 1)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamJoinSuccess, null, null, null, null);
				SystemNotifyManager.SystemNotify(9205, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatTeamJoin, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateGameOptions, null, null, null, null);
			}
		}

		// Token: 0x0600BD87 RID: 48519 RVA: 0x002C61DC File Offset: 0x002C45DC
		private void _OnNetSyncTeamEnterDungeonVoteNotify(MsgDATA msg)
		{
			WorldTeamRaceVoteNotify worldTeamRaceVoteNotify = new WorldTeamRaceVoteNotify();
			worldTeamRaceVoteNotify.decode(msg.bytes);
			if (Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>((int)worldTeamRaceVoteNotify.dungeonId, string.Empty, string.Empty) == null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("组队队长发起进入副本ID错误", null, string.Empty, false);
			}
			Singleton<DeviceVibrateManager>.GetInstance().TriggerDeviceVibrateByType(VibrateSwitchType.Team);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamVoteEnterDungeonFrame>(FrameLayer.HorseLamp, (int)worldTeamRaceVoteNotify.dungeonId, string.Empty);
		}

		// Token: 0x0600BD88 RID: 48520 RVA: 0x002C6254 File Offset: 0x002C4654
		private void _OnNetSyncTeamInviteRes(MsgDATA msg)
		{
			WorldTeamInviteRes worldTeamInviteRes = new WorldTeamInviteRes();
			worldTeamInviteRes.decode(msg.bytes);
			if (worldTeamInviteRes.result != 0U)
			{
				if (worldTeamInviteRes.result != 1300033U)
				{
					SystemNotifyManager.SystemNotify((int)worldTeamInviteRes.result, string.Empty);
				}
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("邀请组队已发送", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600BD89 RID: 48521 RVA: 0x002C62AC File Offset: 0x002C46AC
		private void _OnNetSyncTeamInviteNotify(MsgDATA msg)
		{
			WorldTeamInviteNotify worldTeamInviteNotify = new WorldTeamInviteNotify();
			worldTeamInviteNotify.decode(msg.bytes);
			if (this.HasTeam())
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)worldTeamInviteNotify.info.target, string.Empty, string.Empty) == null)
			{
				return;
			}
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < this.m_InviteTeamList.Count; i++)
			{
				if (this.m_InviteTeamList[i].baseinfo.masterInfo.id == worldTeamInviteNotify.info.masterInfo.id)
				{
					if (this.m_InviteTeamList[i].baseinfo.target != worldTeamInviteNotify.info.target)
					{
						flag2 = true;
					}
					this.m_InviteTeamList[i].baseinfo = worldTeamInviteNotify.info;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				NewTeamInviteList newTeamInviteList = new NewTeamInviteList();
				newTeamInviteList.baseinfo = worldTeamInviteNotify.info;
				newTeamInviteList.fTimeCount = 0f;
				this.m_InviteTeamList.Add(newTeamInviteList);
				flag2 = true;
			}
			if (flag2)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600BD8A RID: 48522 RVA: 0x002C63EC File Offset: 0x002C47EC
		private void _OnNotifyNewRequester(MsgDATA msg)
		{
			WorldTeamNotifyNewRequester stream = new WorldTeamNotifyNewRequester();
			stream.decode(msg.bytes);
			this.bHasNewRequester = true;
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.TeamNewRequester);
			DataManager<NewMessageNoticeManager>.GetInstance().AddNewMessageNoticeWhenNoExist("TeamNewRequest", null, delegate(NewMessageNoticeData data)
			{
				if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<TeamListFrame>(null))
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
				}
				DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.TeamNewRequester);
				DataManager<NewMessageNoticeManager>.GetInstance().RemoveNewMessageNotice(data);
			});
		}

		// Token: 0x0600BD8B RID: 48523 RVA: 0x002C6450 File Offset: 0x002C4850
		private void _OnNotifyVoteChoice(MsgDATA msg)
		{
			WorldTeamVoteChoiceNotify worldTeamVoteChoiceNotify = new WorldTeamVoteChoiceNotify();
			worldTeamVoteChoiceNotify.decode(msg.bytes);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamVoteEnterDungeonFrame>(null))
			{
				TeamVoteEnterDungeonFrame teamVoteEnterDungeonFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamVoteEnterDungeonFrame)) as TeamVoteEnterDungeonFrame;
				teamVoteEnterDungeonFrame.UpdateMemVoteState(worldTeamVoteChoiceNotify);
			}
		}

		// Token: 0x0600BD8C RID: 48524 RVA: 0x002C64A0 File Offset: 0x002C48A0
		private void _OnTeamMatchStartRes(MsgDATA msg)
		{
			SceneTeamMatchStartRes sceneTeamMatchStartRes = new SceneTeamMatchStartRes();
			sceneTeamMatchStartRes.decode(msg.bytes);
			if (sceneTeamMatchStartRes.result == 0U)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamMatchStartSuccess, null, null, null, null);
				return;
			}
			if (sceneTeamMatchStartRes.result == 1301001U)
			{
				return;
			}
			SystemNotifyManager.SystemNotify((int)sceneTeamMatchStartRes.result, string.Empty);
			if (sceneTeamMatchStartRes.result != 1301003U)
			{
				return;
			}
		}

		// Token: 0x0600BD8D RID: 48525 RVA: 0x002C6510 File Offset: 0x002C4910
		private void _OnTeamMatchCancelRes(MsgDATA msg)
		{
			WorldTeamMatchCancelRes worldTeamMatchCancelRes = new WorldTeamMatchCancelRes();
			worldTeamMatchCancelRes.decode(msg.bytes);
			if (worldTeamMatchCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldTeamMatchCancelRes.result, string.Empty);
				if (worldTeamMatchCancelRes.result != 1301004U)
				{
					return;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamMatchCancelSuccess, null, null, null, null);
		}

		// Token: 0x0600BD8E RID: 48526 RVA: 0x002C6570 File Offset: 0x002C4970
		private void _OnTeamMatchResultNotify(MsgDATA msg)
		{
			WorldTeamMatchResultNotify worldTeamMatchResultNotify = new WorldTeamMatchResultNotify();
			worldTeamMatchResultNotify.decode(msg.bytes);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamMatchPlayersFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMatchPlayersFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMatchPlayersFrame>(FrameLayer.Middle, worldTeamMatchResultNotify, string.Empty);
		}

		// Token: 0x0600BD8F RID: 48527 RVA: 0x002C65C0 File Offset: 0x002C49C0
		private void _OnNetSyncCreateTeamSuccess(MsgDATA msg)
		{
			WorldCreateTeamRes worldCreateTeamRes = new WorldCreateTeamRes();
			worldCreateTeamRes.decode(msg.bytes);
			if (worldCreateTeamRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldCreateTeamRes.result, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamCreateSuccess, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatTeamJoin, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateGameOptions, null, null, null, null);
			}
		}

		// Token: 0x0600BD90 RID: 48528 RVA: 0x002C6638 File Offset: 0x002C4A38
		private void _OnNetSyncAddTeamMember(MsgDATA msg)
		{
			WorldNotifyNewTeamMember worldNotifyNewTeamMember = new WorldNotifyNewTeamMember();
			worldNotifyNewTeamMember.decode(msg.bytes);
			TeamMember newTeamMember = this.GetNewTeamMember();
			this._ParseMemberData(worldNotifyNewTeamMember.info, newTeamMember);
			this._DebugMemberData(newTeamMember);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamAddMemberSuccess, null, null, null, null);
		}

		// Token: 0x0600BD91 RID: 48529 RVA: 0x002C6688 File Offset: 0x002C4A88
		private void _OnTeamMemberLeave(MsgDATA msg)
		{
			WorldNotifyMemberLeave worldNotifyMemberLeave = new WorldNotifyMemberLeave();
			worldNotifyMemberLeave.decode(msg.bytes);
			if (worldNotifyMemberLeave.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this._ClearTeamData();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatTeamLeave, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateGameOptions, null, null, null, null);
			}
			else
			{
				List<TeamMember> list = new List<TeamMember>();
				for (int i = 0; i < this.m_myTeam.members.Length; i++)
				{
					if (this.m_myTeam.members[i].id != worldNotifyMemberLeave.id)
					{
						TeamMember teamMember = new TeamMember();
						this._ParseMemberData(this.m_myTeam.members[i], teamMember);
						list.Add(teamMember);
					}
				}
				for (int j = 0; j < this.m_myTeam.members.Length; j++)
				{
					this.m_myTeam.members[j].ClearPlayerInfo();
				}
				for (int k = 0; k < list.Count; k++)
				{
					this.m_myTeam.members[k] = list[k];
					this._ParseMemberData(list[k], this.m_myTeam.members[k]);
				}
			}
			this._DebugTeamData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamRemoveMemberSuccess, null, null, null, null);
		}

		// Token: 0x0600BD92 RID: 48530 RVA: 0x002C67EC File Offset: 0x002C4BEC
		private void _OnNetSyncTeamPosState(MsgDATA msg)
		{
			WorldTeamChangePosStatusSync stream = new WorldTeamChangePosStatusSync();
			stream.decode(msg.bytes);
			this._UpdateMemberCountInfo();
			this._DebugTeamData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamPosStateChanged, null, null, null, null);
		}

		// Token: 0x0600BD93 RID: 48531 RVA: 0x002C682C File Offset: 0x002C4C2C
		private void _OnNetSyncMemberState(MsgDATA msg)
		{
			WorldSyncTeamMemberStatus worldSyncTeamMemberStatus = new WorldSyncTeamMemberStatus();
			worldSyncTeamMemberStatus.decode(msg.bytes);
			TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(worldSyncTeamMemberStatus.id);
			if (teamMemberByMemberID != null)
			{
				this._updateTeammateStatus(teamMemberByMemberID, worldSyncTeamMemberStatus.statusMask);
			}
			this._DebugMemberData(teamMemberByMemberID);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamMemberStateChanged, null, null, null, null);
		}

		// Token: 0x0600BD94 RID: 48532 RVA: 0x002C6888 File Offset: 0x002C4C88
		private void _OnNetSyncChat(MsgDATA msg)
		{
			SceneSyncChat sceneSyncChat = new SceneSyncChat();
			sceneSyncChat.decode(msg.bytes);
			if (sceneSyncChat.channel == 7)
			{
				if (sceneSyncChat.objid != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					int num = (int)sceneSyncChat.receiverId;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNotifyChat, sceneSyncChat.objid, num, null, null);
				}
			}
			else if (sceneSyncChat.channel == 2)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNotifyChatMsg, sceneSyncChat.objid, sceneSyncChat.word, null, null);
			}
		}

		// Token: 0x17001B85 RID: 7045
		// (get) Token: 0x0600BD95 RID: 48533 RVA: 0x002C6925 File Offset: 0x002C4D25
		// (set) Token: 0x0600BD96 RID: 48534 RVA: 0x002C692D File Offset: 0x002C4D2D
		public int DiffHard { get; set; }

		// Token: 0x17001B86 RID: 7046
		// (get) Token: 0x0600BD97 RID: 48535 RVA: 0x002C6936 File Offset: 0x002C4D36
		// (set) Token: 0x0600BD98 RID: 48536 RVA: 0x002C693E File Offset: 0x002C4D3E
		public bool IsAutoAgree
		{
			get
			{
				return this.bAutoAgree;
			}
			set
			{
				this.bAutoAgree = value;
			}
		}

		// Token: 0x17001B87 RID: 7047
		// (get) Token: 0x0600BD99 RID: 48537 RVA: 0x002C6947 File Offset: 0x002C4D47
		// (set) Token: 0x0600BD9A RID: 48538 RVA: 0x002C694F File Offset: 0x002C4D4F
		public bool IsAutoReturnFormHell { get; private set; }

		// Token: 0x17001B88 RID: 7048
		// (get) Token: 0x0600BD9B RID: 48539 RVA: 0x002C6958 File Offset: 0x002C4D58
		public bool IsNotCostFatigueInEliteDungeon
		{
			get
			{
				if (this.GetMemberNum() == 0)
				{
					return false;
				}
				uint gameOptions = DataManager<PlayerBaseData>.GetInstance().gameOptions;
				return (gameOptions & 1U) == 1U;
			}
		}

		// Token: 0x0600BD9C RID: 48540 RVA: 0x002C6983 File Offset: 0x002C4D83
		public Dictionary<string, DiffInfo> GetDiffInfo()
		{
			return this.secteamDungeons;
		}

		// Token: 0x0600BD9D RID: 48541 RVA: 0x002C698C File Offset: 0x002C4D8C
		private void _ClearTeamData()
		{
			this.m_teamList.Clear();
			this.m_InviteTeamList.Clear();
			this.PageTeamCount = 40;
			this.CurrentTeamIndex = 0;
			this.MaxTeamCount = 0;
			this.m_myTeam = null;
			this.m_searchInfo = new TeamSearchInfo();
			this.m_createInfo = new TeamCreateInfo();
			this.m_changeInfo = new TeamChangeInfo();
			this.m_arrChapters.Clear();
			this.InviteTeamID = 0;
			this.bHasNewRequester = false;
			this.bAutoAgree = false;
			this.IsAutoReturnFormHell = false;
			this.DiffHard = -1;
			this.secteamDungeons.Clear();
		}

		// Token: 0x0600BD9E RID: 48542 RVA: 0x002C6A28 File Offset: 0x002C4E28
		private void _OnTeamLeaderChanged(MsgDATA msg)
		{
			WorldSyncTeammaster worldSyncTeammaster = new WorldSyncTeammaster();
			worldSyncTeammaster.decode(msg.bytes);
			if (this.m_myTeam != null)
			{
				this.m_myTeam.leaderInfo.id = worldSyncTeammaster.master;
				this._DebugTeamData();
				for (int i = 0; i < this.m_myTeam.members.Length; i++)
				{
					if (this.m_myTeam.members[i].id == worldSyncTeammaster.master)
					{
						this.m_myTeam.leaderInfo.name = this.m_myTeam.members[i].name;
						this.m_myTeam.leaderInfo.level = this.m_myTeam.members[i].level;
						this.m_myTeam.leaderInfo.occu = this.m_myTeam.members[i].occu;
						break;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamChangeLeaderSuccess, null, null, null, null);
				if (worldSyncTeammaster.master != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.bHasNewRequester = false;
				}
			}
		}

		// Token: 0x0600BD9F RID: 48543 RVA: 0x002C6B43 File Offset: 0x002C4F43
		private bool _isStatusMaskValid(byte statusMask, TeamMemberStatusMask mask)
		{
			return (statusMask & (byte)mask) != 0;
		}

		// Token: 0x0600BDA0 RID: 48544 RVA: 0x002C6B4F File Offset: 0x002C4F4F
		private void _updateTeammateStatus(TeamMember member, byte status)
		{
			member.isOnline = this._isStatusMaskValid(status, TeamMemberStatusMask.Online);
			member.isPrepared = this._isStatusMaskValid(status, TeamMemberStatusMask.Ready);
			member.isAssist = this._isStatusMaskValid(status, TeamMemberStatusMask.Assist);
			member.isBuzy = this._isStatusMaskValid(status, TeamMemberStatusMask.Racing);
		}

		// Token: 0x0600BDA1 RID: 48545 RVA: 0x002C6B8C File Offset: 0x002C4F8C
		private void _ParseMemberData(TeammemberInfo source, TeamMember target)
		{
			if (target != null && source != null)
			{
				target.id = source.id;
				target.name = source.name;
				target.occu = source.occu;
				target.level = source.level;
				target.avatarInfo = source.avatar;
				target.guildid = source.guildId;
				target.viplevel = (ushort)source.vipLevel;
				target.resistMagicValue = source.resistMagic;
				target.playerLabelInfo = source.playerLabelInfo;
				this._updateTeammateStatus(target, source.statusMask);
			}
		}

		// Token: 0x0600BDA2 RID: 48546 RVA: 0x002C6C20 File Offset: 0x002C5020
		private void _ParseMemberData(TeamMember source, TeamMember target)
		{
			if (target != null && source != null)
			{
				target.id = source.id;
				target.name = source.name;
				target.occu = source.occu;
				target.level = source.level;
				target.viplevel = source.viplevel;
				target.guildid = source.guildid;
				target.isOnline = source.isOnline;
				target.isPrepared = source.isPrepared;
				target.isAssist = source.isAssist;
				target.avatarInfo = source.avatarInfo;
				target.resistMagicValue = source.resistMagicValue;
				target.playerLabelInfo = source.playerLabelInfo;
			}
		}

		// Token: 0x0600BDA3 RID: 48547 RVA: 0x002C6CCC File Offset: 0x002C50CC
		private void _UpdateMemberCountInfo()
		{
			this.m_myTeam.maxMemberCount = 0;
			this.m_myTeam.currentMemberCount = 0;
			for (int i = 0; i < this.m_myTeam.members.Length; i++)
			{
				TeamMember teamMember = this.m_myTeam.members[i];
				Team myTeam = this.m_myTeam;
				myTeam.maxMemberCount += 1;
				if (teamMember.id > 0UL)
				{
					Team myTeam2 = this.m_myTeam;
					myTeam2.currentMemberCount += 1;
				}
			}
		}

		// Token: 0x0600BDA4 RID: 48548 RVA: 0x002C6D54 File Offset: 0x002C5154
		public void TeamInviteOtherPlayer(ulong RoleId)
		{
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 1;
			sceneRequest.target = RoleId;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
		}

		// Token: 0x0600BDA5 RID: 48549 RVA: 0x002C6D96 File Offset: 0x002C5196
		public void JoinOtherPlayerTeam(ulong roleID)
		{
			this.JoinTeam(roleID);
		}

		// Token: 0x0600BDA6 RID: 48550 RVA: 0x002C6D9F File Offset: 0x002C519F
		private void _DebugTeamData()
		{
			if (this.m_myTeam != null)
			{
				this.m_myTeam.Debug();
			}
		}

		// Token: 0x0600BDA7 RID: 48551 RVA: 0x002C6DBC File Offset: 0x002C51BC
		private void _DebugMemberData(TeamMember data)
		{
			if (data != null)
			{
				data.Debug();
			}
		}

		// Token: 0x0600BDA8 RID: 48552 RVA: 0x002C6DCF File Offset: 0x002C51CF
		private void _OnInitMyTeamInfo(MsgDATA msg)
		{
			if (msg != null)
			{
				this._OnNetSyncMyTeamInfo(msg);
			}
		}

		// Token: 0x0600BDA9 RID: 48553 RVA: 0x002C6DE0 File Offset: 0x002C51E0
		public void OnUpdate(float timeElapsed)
		{
			for (int i = 0; i < this.m_InviteTeamList.Count; i++)
			{
				if (this.m_InviteTeamList[i].fTimeCount > 30f)
				{
					this.m_InviteTeamList.RemoveAt(i);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamNewInviteNoticeUpdate, null, null, null, null);
					i--;
				}
				else
				{
					this.m_InviteTeamList[i].fTimeCount += timeElapsed;
				}
			}
			if (TeamDataManager.AutomaticBackIsStart)
			{
				if (this.GetMyTeam() == null)
				{
					TeamDataManager.AutomaticBackIsStart = false;
					this.UpdateStateChanged();
					return;
				}
				this.AutoMaticBackTimer += timeElapsed;
				if (this.AutoMaticBackTimer >= 0.2f)
				{
					this.AutoMaticBackTimer = 0f;
					TeamDataManager.StartServerTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				}
				TeamDataManager.iAutoMaticBackRemainTime = (int)(this.AutoMaticBackEndTime - TeamDataManager.StartServerTime);
				this.SystemNotify(TeamDataManager.iAutoMaticBackRemainTime);
			}
		}

		// Token: 0x0600BDAA RID: 48554 RVA: 0x002C6EE0 File Offset: 0x002C52E0
		public void SystemNotify(int time)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null || myTeam.members == null || myTeam.leaderInfo == null)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamTimeChanged, time, null, null, null);
			if (time <= 0)
			{
				string msgContent = string.Empty;
				if (myTeam.leaderInfo.id != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					msgContent = TR.Value("teamdissolve_member_tip");
				}
				else
				{
					msgContent = TR.Value("teamdissolve_leader_tip");
				}
				SystemNotifyManager.SysNotifyTextAnimation(msgContent, CommonTipsDesc.eShowMode.SI_UNIQUE);
				TeamDataManager.AutomaticBackIsStart = false;
				this.UpdateStateChanged();
				return;
			}
			for (int i = 0; i < TeamDataManager.AutoMaticBackTimes.Length; i++)
			{
				if (TeamDataManager.AutoMaticBackTimes[i] == time)
				{
					string msgContent2 = string.Empty;
					if (myTeam.leaderInfo.id != DataManager<PlayerBaseData>.GetInstance().RoleID)
					{
						msgContent2 = TR.Value("teamdissolve_member_time_tip", time);
					}
					else
					{
						msgContent2 = TR.Value("teamdissolve_leader_time_tip", time);
					}
					SystemNotifyManager.SysNotifyTextAnimation(msgContent2, CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
			}
		}

		// Token: 0x04006A83 RID: 27267
		private List<TeamChapter> m_arrChapters = new List<TeamChapter>();

		// Token: 0x04006A84 RID: 27268
		private List<Team> m_teamList = new List<Team>();

		// Token: 0x04006A85 RID: 27269
		private List<Team> m_teamListForTeamMainUI = new List<Team>();

		// Token: 0x04006A86 RID: 27270
		private List<NewTeamInviteList> m_InviteTeamList = new List<NewTeamInviteList>();

		// Token: 0x04006A87 RID: 27271
		private TeamSearchInfo m_searchInfo = new TeamSearchInfo();

		// Token: 0x04006A88 RID: 27272
		private TeamCreateInfo m_createInfo = new TeamCreateInfo();

		// Token: 0x04006A89 RID: 27273
		private TeamChangeInfo m_changeInfo = new TeamChangeInfo();

		// Token: 0x04006A8A RID: 27274
		private Team m_myTeam;

		// Token: 0x04006A8B RID: 27275
		private int InviteTeamID;

		// Token: 0x04006A8C RID: 27276
		private bool bHasNewRequester;

		// Token: 0x04006A8D RID: 27277
		private bool bAutoAgree;

		// Token: 0x04006A8E RID: 27278
		private bool m_bNetBind;

		// Token: 0x04006A8F RID: 27279
		public const int nDuoLuoDungeonID = 6502000;

		// Token: 0x04006A90 RID: 27280
		public static bool AutomaticBackIsStart = false;

		// Token: 0x04006A91 RID: 27281
		public static bool bIsRefreshTime = false;

		// Token: 0x04006A92 RID: 27282
		public static uint StartServerTime = 0U;

		// Token: 0x04006A93 RID: 27283
		public static int iAutoMaticBackRemainTime = 0;

		// Token: 0x04006A94 RID: 27284
		public static int[] AutoMaticBackTimes = new int[]
		{
			60,
			45,
			30,
			15,
			10,
			5
		};

		// Token: 0x04006A95 RID: 27285
		private uint AutoMaticBackEndTime = 60U;

		// Token: 0x04006A96 RID: 27286
		private float AutoMaticBackTimer;

		// Token: 0x04006A97 RID: 27287
		private int AutonMaticBackRemainTime;

		// Token: 0x04006A98 RID: 27288
		private bool bStateChanged;

		// Token: 0x04006A9C RID: 27292
		public uint nTeamGuildDungeonID;

		// Token: 0x04006A9D RID: 27293
		private uint mTeamDungeonID;

		// Token: 0x04006AA2 RID: 27298
		private Dictionary<string, DiffInfo> secteamDungeons = new Dictionary<string, DiffInfo>();
	}
}
