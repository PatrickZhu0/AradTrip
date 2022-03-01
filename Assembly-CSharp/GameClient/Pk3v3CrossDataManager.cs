using System;
using System.Collections.Generic;
using LitJson;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020012C2 RID: 4802
	public class Pk3v3CrossDataManager : DataManager<Pk3v3CrossDataManager>
	{
		// Token: 0x17001B5A RID: 7002
		// (get) Token: 0x0600B99E RID: 47518 RVA: 0x002AA907 File Offset: 0x002A8D07
		// (set) Token: 0x0600B99F RID: 47519 RVA: 0x002AA90F File Offset: 0x002A8D0F
		public bool isNotify
		{
			get
			{
				return this.m_bNotify;
			}
			set
			{
				this.m_bNotify = value;
			}
		}

		// Token: 0x17001B5B RID: 7003
		// (get) Token: 0x0600B9A1 RID: 47521 RVA: 0x002AA921 File Offset: 0x002A8D21
		// (set) Token: 0x0600B9A0 RID: 47520 RVA: 0x002AA918 File Offset: 0x002A8D18
		public int SimpleInviteLastTime
		{
			get
			{
				return this.simpleInviteLastTime;
			}
			set
			{
				this.simpleInviteLastTime = value;
			}
		}

		// Token: 0x17001B5C RID: 7004
		// (get) Token: 0x0600B9A2 RID: 47522 RVA: 0x002AA929 File Offset: 0x002A8D29
		// (set) Token: 0x0600B9A3 RID: 47523 RVA: 0x002AA931 File Offset: 0x002A8D31
		public Dictionary<RoomType, Pk3v3RoomSettingData> RoomSettingData
		{
			get
			{
				return this.roomSettingData;
			}
			set
			{
				if (this.roomSettingData != value)
				{
					this.roomSettingData = value;
				}
			}
		}

		// Token: 0x0600B9A4 RID: 47524 RVA: 0x002AA946 File Offset: 0x002A8D46
		public List<Pk3v3CrossDataManager.ScoreListItem> GetScoreList()
		{
			return this.m_arrScoreList;
		}

		// Token: 0x17001B5D RID: 7005
		// (get) Token: 0x0600B9A6 RID: 47526 RVA: 0x002AA957 File Offset: 0x002A8D57
		// (set) Token: 0x0600B9A5 RID: 47525 RVA: 0x002AA94E File Offset: 0x002A8D4E
		public Pk3v3CrossDataManager.My3v3PkInfo PkInfo
		{
			get
			{
				if (this.m_pkInfo == null)
				{
					this.m_pkInfo = new Pk3v3CrossDataManager.My3v3PkInfo();
				}
				return this.m_pkInfo;
			}
			set
			{
				this.m_pkInfo = value;
			}
		}

		// Token: 0x0600B9A7 RID: 47527 RVA: 0x002AA975 File Offset: 0x002A8D75
		public Pk3v3CrossDataManager.ScoreListItem GetMyRankInfo()
		{
			return this.m_myRankInfo;
		}

		// Token: 0x0600B9A8 RID: 47528 RVA: 0x002AA97D File Offset: 0x002A8D7D
		public bool HasTeam()
		{
			return this.m_myTeam != null;
		}

		// Token: 0x0600B9A9 RID: 47529 RVA: 0x002AA98B File Offset: 0x002A8D8B
		public Pk3v3CrossDataManager.Team GetMyTeam()
		{
			return this.m_myTeam;
		}

		// Token: 0x0600B9AA RID: 47530 RVA: 0x002AA994 File Offset: 0x002A8D94
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

		// Token: 0x0600B9AB RID: 47531 RVA: 0x002AA9EC File Offset: 0x002A8DEC
		public Pk3v3CrossDataManager.TeamMember GetTeamMemberByMemberID(ulong id)
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

		// Token: 0x0600B9AC RID: 47532 RVA: 0x002AAA4C File Offset: 0x002A8E4C
		public bool IsTeammateFriend(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				Pk3v3CrossDataManager.TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID != null)
				{
					RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(teamMemberByMemberID.id);
					return relationByRoleID != null && relationByRoleID.IsFriend();
				}
			}
			return false;
		}

		// Token: 0x0600B9AD RID: 47533 RVA: 0x002AAA98 File Offset: 0x002A8E98
		public bool IsTeammateGuild(ulong memberID)
		{
			if (!this.IsTeammateMainPlayer(memberID))
			{
				Pk3v3CrossDataManager.TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(DataManager<PlayerBaseData>.GetInstance().RoleID);
				Pk3v3CrossDataManager.TeamMember teamMemberByMemberID2 = this.GetTeamMemberByMemberID(memberID);
				if (teamMemberByMemberID2 != null && teamMemberByMemberID != null)
				{
					return teamMemberByMemberID.guildid == teamMemberByMemberID2.guildid && teamMemberByMemberID.guildid != 0UL;
				}
			}
			return false;
		}

		// Token: 0x0600B9AE RID: 47534 RVA: 0x002AAAFC File Offset: 0x002A8EFC
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
			Pk3v3CrossDataManager.TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
			return teamMemberByMemberID != null && teamMemberByMemberID.isAssist;
		}

		// Token: 0x0600B9AF RID: 47535 RVA: 0x002AAB74 File Offset: 0x002A8F74
		public bool IsTeammateMainPlayer(ulong memberID)
		{
			Pk3v3CrossDataManager.TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
			return teamMemberByMemberID != null && teamMemberByMemberID.id == DataManager<PlayerBaseData>.GetInstance().RoleID;
		}

		// Token: 0x17001B5E RID: 7006
		// (get) Token: 0x0600B9B0 RID: 47536 RVA: 0x002AABA4 File Offset: 0x002A8FA4
		// (set) Token: 0x0600B9B1 RID: 47537 RVA: 0x002AABAC File Offset: 0x002A8FAC
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

		// Token: 0x0600B9B2 RID: 47538 RVA: 0x002AABB8 File Offset: 0x002A8FB8
		public eTeammateFlag GetTeammateFlag(ulong memberID)
		{
			eTeammateFlag eTeammateFlag = eTeammateFlag.None;
			Pk3v3CrossDataManager.TeamMember teamMemberByMemberID = this.GetTeamMemberByMemberID(memberID);
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
			}
			return eTeammateFlag;
		}

		// Token: 0x0600B9B3 RID: 47539 RVA: 0x002AAC06 File Offset: 0x002A9006
		public bool IsTeamLeaderByRoleID(ulong roleId)
		{
			return this.m_myTeam != null && this.m_myTeam.leaderInfo.id == roleId;
		}

		// Token: 0x0600B9B4 RID: 47540 RVA: 0x002AAC29 File Offset: 0x002A9029
		public bool IsTeamLeader()
		{
			return this.IsTeamLeaderByRoleID(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x0600B9B5 RID: 47541 RVA: 0x002AAC3B File Offset: 0x002A903B
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600B9B6 RID: 47542 RVA: 0x002AAC40 File Offset: 0x002A9040
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(314, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.fChangePosLastTime = (float)tableItem.Value;
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0600B9B7 RID: 47543 RVA: 0x002AACD4 File Offset: 0x002A90D4
		public override void Clear()
		{
			this.m_arrScoreList = null;
			this.m_pkInfo = null;
			this.bMatching = false;
			this.bOpenNotifyFrame = false;
			this.NotifyCount = 0;
			this.scoreWarStatus = ScoreWarStatus.SWS_INVALID;
			this.scoreWarStateEndTime = 0U;
			this.ClearRoomInfo();
			if (this.roomSettingData != null)
			{
				foreach (KeyValuePair<RoomType, Pk3v3RoomSettingData> keyValuePair in this.roomSettingData)
				{
					Pk3v3RoomSettingData value = keyValuePair.Value;
					if (value != null)
					{
						value.DefaultInit();
					}
				}
			}
			this.fChangePosLastTime = 0f;
			this.fAddUpTime = 0f;
			this.fChangePosLocationTime = 0f;
			this._UnBindNetMsg();
			this.iInt = 0;
			this.m_bNotify = false;
			this.SimpleInviteLastTime = -1;
			this.m_myRankInfo = new Pk3v3CrossDataManager.ScoreListItem();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0600B9B8 RID: 47544 RVA: 0x002AADCC File Offset: 0x002A91CC
		private void InitRoomSettingData()
		{
			if (this.roomSettingData == null)
			{
				this.roomSettingData = new Dictionary<RoomType, Pk3v3RoomSettingData>();
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_FREE, out pk3v3RoomSettingData))
			{
				pk3v3RoomSettingData = new Pk3v3RoomSettingData();
				pk3v3RoomSettingData.DefaultInit();
				this.roomSettingData.Add(RoomType.ROOM_TYPE_THREE_FREE, pk3v3RoomSettingData);
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData2 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_MATCH, out pk3v3RoomSettingData2))
			{
				pk3v3RoomSettingData2 = new Pk3v3RoomSettingData();
				pk3v3RoomSettingData2.DefaultInit();
				this.roomSettingData.Add(RoomType.ROOM_TYPE_THREE_MATCH, pk3v3RoomSettingData2);
			}
			this.SetLocalSave();
		}

		// Token: 0x0600B9B9 RID: 47545 RVA: 0x002AAE54 File Offset: 0x002A9254
		private void SetLocalSave()
		{
			Pk3v3RoomSettingData pk3v3RoomSettingData = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_FREE, out pk3v3RoomSettingData))
			{
				return;
			}
			Pk3v3RoomSettingData pk3v3RoomSettingData2 = null;
			if (!this.roomSettingData.TryGetValue(RoomType.ROOM_TYPE_THREE_MATCH, out pk3v3RoomSettingData2))
			{
				return;
			}
			string pk3v3LocalDataKey = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "bSetMinLv");
			string pk3v3LocalDataKey2 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "bSetMinRankLv");
			string pk3v3LocalDataKey3 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "MinLv");
			string pk3v3LocalDataKey4 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_FREE, "MinRankLv");
			string pk3v3LocalDataKey5 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "bSetMinLv");
			string pk3v3LocalDataKey6 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "bSetMinRankLv");
			string pk3v3LocalDataKey7 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "MinLv");
			string pk3v3LocalDataKey8 = this.GetPk3v3LocalDataKey(RoomType.ROOM_TYPE_THREE_MATCH, "MinRankLv");
			string text = PlayerLocalSetting.GetValue(pk3v3LocalDataKey) as string;
			string text2 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey2) as string;
			string text3 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey3) as string;
			string text4 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey4) as string;
			string text5 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey5) as string;
			string text6 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey6) as string;
			string text7 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey7) as string;
			string text8 = PlayerLocalSetting.GetValue(pk3v3LocalDataKey8) as string;
			if (text == null || text == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey, pk3v3RoomSettingData.bSetMinLv.ToString());
			}
			else if (text == "True")
			{
				pk3v3RoomSettingData.bSetMinLv = true;
			}
			else
			{
				pk3v3RoomSettingData.bSetMinLv = false;
			}
			if (text2 == null || text2 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey2, pk3v3RoomSettingData.bSetMinRankLv.ToString());
			}
			else if (text2 == "True")
			{
				pk3v3RoomSettingData.bSetMinRankLv = true;
			}
			else
			{
				pk3v3RoomSettingData.bSetMinRankLv = false;
			}
			if (text3 == null || text3 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey3, pk3v3RoomSettingData.MinLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
				int minLv = 0;
				if (int.TryParse(text3, out minLv))
				{
					pk3v3RoomSettingData.MinLv = minLv;
				}
			}
			if (text4 == null || text4 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey4, pk3v3RoomSettingData.MinRankLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
				int minRankLv = 0;
				if (int.TryParse(text4, out minRankLv))
				{
					pk3v3RoomSettingData.MinRankLv = minRankLv;
				}
			}
			if (text5 == null || text5 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey5, pk3v3RoomSettingData2.bSetMinLv.ToString());
			}
			else if (text5 == "True")
			{
				pk3v3RoomSettingData2.bSetMinLv = true;
			}
			else
			{
				pk3v3RoomSettingData2.bSetMinLv = false;
			}
			if (text6 == null || text6 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey6, pk3v3RoomSettingData2.bSetMinRankLv.ToString());
			}
			else if (text6 == "True")
			{
				pk3v3RoomSettingData2.bSetMinRankLv = true;
			}
			else
			{
				pk3v3RoomSettingData2.bSetMinRankLv = false;
			}
			if (text7 == null || text7 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey7, pk3v3RoomSettingData2.MinLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData2.MinLv = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
				int minLv2 = 0;
				if (int.TryParse(text7, out minLv2))
				{
					pk3v3RoomSettingData2.MinLv = minLv2;
				}
			}
			if (text8 == null || text8 == string.Empty)
			{
				PlayerLocalSetting.SetValue(pk3v3LocalDataKey8, pk3v3RoomSettingData2.MinRankLv.ToString());
			}
			else
			{
				pk3v3RoomSettingData2.MinRankLv = DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
				int minRankLv2 = 0;
				if (int.TryParse(text8, out minRankLv2))
				{
					pk3v3RoomSettingData2.MinRankLv = minRankLv2;
				}
			}
			PlayerLocalSetting.SaveConfig();
		}

		// Token: 0x0600B9BA RID: 47546 RVA: 0x002AB240 File Offset: 0x002A9640
		public override void Update(float a_fTime)
		{
			if (this.isNotify || this.SimpleInviteLastTime > 0)
			{
				this.fAddUpTime += a_fTime;
				if (this.fAddUpTime > 1f)
				{
					if (this.SimpleInviteLastTime > 0)
					{
						this.SimpleInviteLastTime--;
					}
					if (this.isNotify)
					{
						this.fChangePosLocationTime -= 1f;
						this.iInt = (int)this.fChangePosLocationTime;
					}
					this.fAddUpTime = 0f;
				}
			}
		}

		// Token: 0x0600B9BB RID: 47547 RVA: 0x002AB2D1 File Offset: 0x002A96D1
		public void SetCountDownTime(float fTime)
		{
			if (fTime > 0f)
			{
				this.fChangePosLocationTime = fTime;
				this.iInt = (int)fTime;
				this.m_bNotify = true;
			}
		}

		// Token: 0x0600B9BC RID: 47548 RVA: 0x002AB2F4 File Offset: 0x002A96F4
		public void ClearRoomInfo()
		{
			if (Pk3v3CrossDataManager.roomInfo != null)
			{
				Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.id = 0U;
				Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.isPassword = 0;
				Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.ownerId = 0UL;
				Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.roomStatus = 0;
				Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.roomType = 0;
				for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
				{
					Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId = 0UL;
					Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].group = 0;
					Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].index = 0;
					Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerOccu = 0;
				}
			}
			this.InviteRoomList.Clear();
			this.bHasPassword = false;
			this.PassWord = string.Empty;
			this.m_myTeam = null;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
		}

		// Token: 0x0600B9BD RID: 47549 RVA: 0x002AB3FC File Offset: 0x002A97FC
		public bool CheckPk3v3CrossScence()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B9BE RID: 47550 RVA: 0x002AB450 File Offset: 0x002A9850
		public void _BindNetMsg()
		{
			if (!this.m_bNetBind)
			{
				NetProcess.AddMsgHandler(607801U, new Action<MsgDATA>(this._OnWorldSyncReLoginRoomInfo));
				NetProcess.AddMsgHandler(607814U, new Action<MsgDATA>(this._OnWorldUpdateRoomRes));
				NetProcess.AddMsgHandler(607802U, new Action<MsgDATA>(this._OnSyncRoomSimpleInfo));
				NetProcess.AddMsgHandler(607809U, new Action<MsgDATA>(this._OnSyncRoomPasswordInfo));
				NetProcess.AddMsgHandler(607803U, new Action<MsgDATA>(this._OnSyncRoomSlotInfo));
				NetProcess.AddMsgHandler(607816U, new Action<MsgDATA>(this._OnJoinRoomRes));
				NetProcess.AddMsgHandler(607824U, new Action<MsgDATA>(this._OnInviteJoinRoomRes));
				NetProcess.AddMsgHandler(607804U, new Action<MsgDATA>(this._OnSyncInviteInfo));
				NetProcess.AddMsgHandler(607828U, new Action<MsgDATA>(this._OnRoomInviteReply));
				NetProcess.AddMsgHandler(607805U, new Action<MsgDATA>(this._OnSyncKickOutInfo));
				NetProcess.AddMsgHandler(607820U, new Action<MsgDATA>(this._OnKickOutRoomRes));
				NetProcess.AddMsgHandler(607826U, new Action<MsgDATA>(this._OnChangeRoomOwnerRes));
				NetProcess.AddMsgHandler(607830U, new Action<MsgDATA>(this._OnRoomCloseSlotRes));
				NetProcess.AddMsgHandler(607836U, new Action<MsgDATA>(this._OnRoomBeginGameRes));
				NetProcess.AddMsgHandler(607838U, new Action<MsgDATA>(this._OnRoomBattleCancelRes));
				NetProcess.AddMsgHandler(607840U, new Action<MsgDATA>(this._OnVoteReadyRes));
				NetProcess.AddMsgHandler(607842U, new Action<MsgDATA>(this._OnRoomSendInviteLinkRes));
				NetProcess.AddMsgHandler(607832U, new Action<MsgDATA>(this._OnRoomSwapSlotRes));
				NetProcess.AddMsgHandler(607807U, new Action<MsgDATA>(this._OnSyncRoomSwapSlotInfo));
				NetProcess.AddMsgHandler(607834U, new Action<MsgDATA>(this._OnRoomResponseSwapSlotRes));
				NetProcess.AddMsgHandler(607808U, new Action<MsgDATA>(this._OnSyncRoomSwapResultInfo));
				NetProcess.AddMsgHandler(602602U, new Action<MsgDATA>(this._OnRankListRes));
				NetProcess.AddMsgHandler(508101U, new Action<MsgDATA>(this.OnWorldSyncScoreWarInfo));
				NetProcess.AddMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
				NetProcess.AddMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
				NetProcess.AddMsgHandler(607818U, new Action<MsgDATA>(this._OnQuitRoomRes));
				this.m_bNetBind = true;
			}
		}

		// Token: 0x0600B9BF RID: 47551 RVA: 0x002AB6AC File Offset: 0x002A9AAC
		public void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(607801U, new Action<MsgDATA>(this._OnWorldSyncReLoginRoomInfo));
			NetProcess.RemoveMsgHandler(607814U, new Action<MsgDATA>(this._OnWorldUpdateRoomRes));
			NetProcess.RemoveMsgHandler(607802U, new Action<MsgDATA>(this._OnSyncRoomSimpleInfo));
			NetProcess.RemoveMsgHandler(607809U, new Action<MsgDATA>(this._OnSyncRoomPasswordInfo));
			NetProcess.RemoveMsgHandler(607803U, new Action<MsgDATA>(this._OnSyncRoomSlotInfo));
			NetProcess.RemoveMsgHandler(607816U, new Action<MsgDATA>(this._OnJoinRoomRes));
			NetProcess.RemoveMsgHandler(607824U, new Action<MsgDATA>(this._OnInviteJoinRoomRes));
			NetProcess.RemoveMsgHandler(607804U, new Action<MsgDATA>(this._OnSyncInviteInfo));
			NetProcess.RemoveMsgHandler(607828U, new Action<MsgDATA>(this._OnRoomInviteReply));
			NetProcess.RemoveMsgHandler(607805U, new Action<MsgDATA>(this._OnSyncKickOutInfo));
			NetProcess.RemoveMsgHandler(607820U, new Action<MsgDATA>(this._OnKickOutRoomRes));
			NetProcess.RemoveMsgHandler(607826U, new Action<MsgDATA>(this._OnChangeRoomOwnerRes));
			NetProcess.RemoveMsgHandler(607830U, new Action<MsgDATA>(this._OnRoomCloseSlotRes));
			NetProcess.RemoveMsgHandler(607836U, new Action<MsgDATA>(this._OnRoomBeginGameRes));
			NetProcess.RemoveMsgHandler(607838U, new Action<MsgDATA>(this._OnRoomBattleCancelRes));
			NetProcess.RemoveMsgHandler(607840U, new Action<MsgDATA>(this._OnVoteReadyRes));
			NetProcess.RemoveMsgHandler(607842U, new Action<MsgDATA>(this._OnRoomSendInviteLinkRes));
			NetProcess.RemoveMsgHandler(607832U, new Action<MsgDATA>(this._OnRoomSwapSlotRes));
			NetProcess.RemoveMsgHandler(607807U, new Action<MsgDATA>(this._OnSyncRoomSwapSlotInfo));
			NetProcess.RemoveMsgHandler(607834U, new Action<MsgDATA>(this._OnRoomResponseSwapSlotRes));
			NetProcess.RemoveMsgHandler(607808U, new Action<MsgDATA>(this._OnSyncRoomSwapResultInfo));
			NetProcess.RemoveMsgHandler(602602U, new Action<MsgDATA>(this._OnRankListRes));
			NetProcess.RemoveMsgHandler(508101U, new Action<MsgDATA>(this.OnWorldSyncScoreWarInfo));
			NetProcess.RemoveMsgHandler(606702U, new Action<MsgDATA>(this._onStartBattle));
			NetProcess.RemoveMsgHandler(606703U, new Action<MsgDATA>(this._onCancelBattle));
			this.m_bNetBind = false;
		}

		// Token: 0x0600B9C0 RID: 47552 RVA: 0x002AB8E6 File Offset: 0x002A9CE6
		public bool IsMathcing()
		{
			return this.bMatching;
		}

		// Token: 0x0600B9C1 RID: 47553 RVA: 0x002AB8F0 File Offset: 0x002A9CF0
		private void _onStartBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			WorldMatchStartRes worldMatchStartRes = new WorldMatchStartRes();
			worldMatchStartRes.decode(a_msgData.bytes);
			if (worldMatchStartRes == null)
			{
				return;
			}
			if (worldMatchStartRes.result != 0U)
			{
				if (worldMatchStartRes.result != 3302003U)
				{
					SystemNotifyManager.SystemNotify((int)worldMatchStartRes.result, string.Empty);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchFailed, null, null, null, null);
				return;
			}
			this.bMatching = true;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatchRes, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatch, null, null, null, null);
		}

		// Token: 0x0600B9C2 RID: 47554 RVA: 0x002AB990 File Offset: 0x002A9D90
		private void _onCancelBattle(MsgDATA a_msgData)
		{
			if (a_msgData == null)
			{
				return;
			}
			WorldMatchCancelRes worldMatchCancelRes = new WorldMatchCancelRes();
			worldMatchCancelRes.decode(a_msgData.bytes);
			if (worldMatchCancelRes == null)
			{
				return;
			}
			if (worldMatchCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldMatchCancelRes.result, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
				return;
			}
			this.bMatching = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatchRes, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatch, null, null, null, null);
		}

		// Token: 0x0600B9C3 RID: 47555 RVA: 0x002ABA1C File Offset: 0x002A9E1C
		private void _OnWorldSyncReLoginRoomInfo(MsgDATA msg)
		{
			WorldSyncRoomInfo worldSyncRoomInfo = new WorldSyncRoomInfo();
			worldSyncRoomInfo.decode(msg.bytes);
			Pk3v3CrossDataManager.roomInfo = worldSyncRoomInfo.info;
			if (Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.id <= 0U)
			{
				Logger.LogError("3v3房间掉线重连后,玩家初始化数据时,服务器同步的房间id有问题");
			}
			bool flag = true;
			for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId != 0UL)
				{
					flag = false;
				}
			}
			this.GetTeamDataFromRoomData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
			if (flag)
			{
				Logger.LogError("3v3房间掉线重连后,玩家初始化数据时,服务器同步的玩家列表有问题，全是空数据");
			}
		}

		// Token: 0x0600B9C4 RID: 47556 RVA: 0x002ABAC8 File Offset: 0x002A9EC8
		private void _ParseMemberData(Pk3v3CrossDataManager.TeamMember source, Pk3v3CrossDataManager.TeamMember target)
		{
			if (target != null && source != null)
			{
				target.id = source.id;
				target.name = source.name;
				target.occu = source.occu;
				target.level = source.level;
				target.viplevel = source.viplevel;
				target.guildid = source.guildid;
				target.playerSeasonLevel = source.playerSeasonLevel;
				target.isOnline = source.isOnline;
				target.isPrepared = source.isPrepared;
				target.isAssist = source.isAssist;
				target.avatarInfo = source.avatarInfo;
			}
		}

		// Token: 0x0600B9C5 RID: 47557 RVA: 0x002ABB68 File Offset: 0x002A9F68
		private void _UpdateMemberCountInfo()
		{
			this.m_myTeam.maxMemberCount = 0;
			this.m_myTeam.currentMemberCount = 0;
			for (int i = 0; i < this.m_myTeam.members.Length; i++)
			{
				Pk3v3CrossDataManager.TeamMember teamMember = this.m_myTeam.members[i];
				Pk3v3CrossDataManager.Team myTeam = this.m_myTeam;
				myTeam.maxMemberCount += 1;
				if (teamMember.id > 0UL)
				{
					Pk3v3CrossDataManager.Team myTeam2 = this.m_myTeam;
					myTeam2.currentMemberCount += 1;
				}
			}
		}

		// Token: 0x0600B9C6 RID: 47558 RVA: 0x002ABBEE File Offset: 0x002A9FEE
		private void _DebugTeamData()
		{
			if (this.m_myTeam == null)
			{
			}
		}

		// Token: 0x0600B9C7 RID: 47559 RVA: 0x002ABC00 File Offset: 0x002AA000
		private void _OnWorldUpdateRoomRes(MsgDATA msg)
		{
			WorldUpdateRoomRes worldUpdateRoomRes = new WorldUpdateRoomRes();
			worldUpdateRoomRes.decode(msg.bytes);
			if (worldUpdateRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldUpdateRoomRes.result, string.Empty);
				return;
			}
			Pk3v3CrossDataManager.roomInfo = worldUpdateRoomRes.info;
			if (Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.roomType != 3)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomInfoUpdate, null, null, null, null);
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossTeamListFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamListFrame>(null, false);
					}
					this.GetTeamDataFromRoomData();
					this._DebugTeamData();
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossMyTeamFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
				}
			}
		}

		// Token: 0x0600B9C8 RID: 47560 RVA: 0x002ABD04 File Offset: 0x002AA104
		private void _OnSyncRoomSimpleInfo(MsgDATA msg)
		{
			WorldSyncRoomSimpleInfo worldSyncRoomSimpleInfo = new WorldSyncRoomSimpleInfo();
			worldSyncRoomSimpleInfo.decode(msg.bytes);
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnSyncRoomSimpleInfo]");
			}
			if (worldSyncRoomSimpleInfo.info.roomType != 3)
			{
				return;
			}
			if (Pk3v3CrossDataManager.roomInfo != null && Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.ownerId != worldSyncRoomSimpleInfo.info.ownerId)
			{
				string text = string.Empty;
				for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
				{
					if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId == worldSyncRoomSimpleInfo.info.ownerId)
					{
						text = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerName;
						break;
					}
				}
				SystemNotifyManager.SystemNotify(9220, new object[]
				{
					text
				});
			}
			Pk3v3CrossDataManager.roomInfo.roomSimpleInfo = worldSyncRoomSimpleInfo.info;
			if (worldSyncRoomSimpleInfo.info.roomStatus == 1)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatch, null, null, null, null);
			}
			else if (worldSyncRoomSimpleInfo.info.roomStatus == 2)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3VoteEnterPkFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3VoteEnterPkFrame>(null, false);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3VoteEnterBattle, null, null, null, null);
				bool flag = true;
				int num = 0;
				ulong num2 = 0UL;
				for (int j = 0; j < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; j++)
				{
					if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerId > 0UL)
					{
						num++;
						num2 = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerId;
					}
				}
				if (num == 1 && num2 == Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.ownerId)
				{
					flag = false;
				}
				if (flag)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3VoteEnterPkFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			else if (worldSyncRoomSimpleInfo.info.roomStatus == 3)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3VoteEnterPkFrame>(null, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatch, null, null, null, null);
			}
			this.GetTeamDataFromRoomData();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSimpleInfoUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
		}

		// Token: 0x0600B9C9 RID: 47561 RVA: 0x002ABF68 File Offset: 0x002AA368
		private void _OnSyncRoomPasswordInfo(MsgDATA msg)
		{
			WorldSyncRoomPasswordInfo worldSyncRoomPasswordInfo = new WorldSyncRoomPasswordInfo();
			worldSyncRoomPasswordInfo.decode(msg.bytes);
			this.bHasPassword = (worldSyncRoomPasswordInfo.password != string.Empty);
			this.PassWord = worldSyncRoomPasswordInfo.password;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Set3v3RoomPassword, null, null, null, null);
		}

		// Token: 0x0600B9CA RID: 47562 RVA: 0x002ABFBC File Offset: 0x002AA3BC
		private void GetTeamDataFromRoomData()
		{
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				return;
			}
			if (Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.id <= 0U)
			{
				return;
			}
			this.m_myTeam = new Pk3v3CrossDataManager.Team();
			this.m_myTeam.teamID = Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.id;
			this.m_myTeam.leaderInfo = new TeammemberBaseInfo();
			this.m_myTeam.leaderInfo.id = Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.ownerId;
			this.m_myTeam.autoAgree = 1U;
			for (int i = 0; i < this.m_myTeam.members.Length; i++)
			{
				Pk3v3CrossDataManager.TeamMember teamMember = new Pk3v3CrossDataManager.TeamMember();
				teamMember.ClearPlayerInfo();
				this.m_myTeam.members[i] = teamMember;
			}
			int num = 0;
			for (int j = 0; j < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; j++)
			{
				if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerId > 0UL)
				{
					this._ParseMemberData(new Pk3v3CrossDataManager.TeamMember
					{
						id = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerId,
						name = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerName,
						occu = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerOccu,
						avatarInfo = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].avatar,
						level = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerLevel,
						playerSeasonLevel = Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerSeasonLevel,
						viplevel = (ushort)Pk3v3CrossDataManager.roomInfo.roomSlotInfos[j].playerVipLevel
					}, this.m_myTeam.members[num]);
					num++;
				}
			}
			int num2 = -1;
			for (int k = 0; k < this.m_myTeam.members.Length; k++)
			{
				Pk3v3CrossDataManager.TeamMember teamMember2 = this.m_myTeam.members[k];
				if (teamMember2.id == this.m_myTeam.leaderInfo.id)
				{
					num2 = k;
					break;
				}
			}
			if (num2 != -1 && num2 != 0)
			{
				this.Swap<Pk3v3CrossDataManager.TeamMember>(ref this.m_myTeam.members[0], ref this.m_myTeam.members[num2]);
			}
			this._UpdateMemberCountInfo();
		}

		// Token: 0x0600B9CB RID: 47563 RVA: 0x002AC220 File Offset: 0x002AA620
		private void Swap<T>(ref T x, ref T y)
		{
			T t = x;
			x = y;
			y = t;
		}

		// Token: 0x0600B9CC RID: 47564 RVA: 0x002AC248 File Offset: 0x002AA648
		private void _OnSyncRoomSlotInfo(MsgDATA msg)
		{
			WorldSyncRoomSlotInfo worldSyncRoomSlotInfo = new WorldSyncRoomSlotInfo();
			worldSyncRoomSlotInfo.decode(msg.bytes);
			if (Pk3v3CrossDataManager.roomInfo != null)
			{
				if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos != null)
				{
					for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
					{
						if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].group == worldSyncRoomSlotInfo.slotInfo.group)
						{
							if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].index == worldSyncRoomSlotInfo.slotInfo.index)
							{
								if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId > 0UL && worldSyncRoomSlotInfo.slotInfo.playerId <= 0UL)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3PlayerLeave, worldSyncRoomSlotInfo.slotInfo.group, worldSyncRoomSlotInfo.slotInfo.index, null, null);
								}
								if (worldSyncRoomSlotInfo.slotInfo.playerId > 0UL && worldSyncRoomSlotInfo.slotInfo.playerId != Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3ChangePosition, worldSyncRoomSlotInfo.slotInfo.playerId, worldSyncRoomSlotInfo.slotInfo.group, null, null);
								}
								Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i] = worldSyncRoomSlotInfo.slotInfo;
								this.GetTeamDataFromRoomData();
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
								if (worldSyncRoomSlotInfo.slotInfo.status == 4)
								{
									SystemNotifyManager.SysNotifyFloatingEffect(string.Format("玩家{0}已断开连接", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
								}
								if (worldSyncRoomSlotInfo.slotInfo.readyStatus == 2 || worldSyncRoomSlotInfo.slotInfo.readyStatus == 3)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RefuseBeginMatch, null, null, null, null);
									if (worldSyncRoomSlotInfo.slotInfo.readyStatus == 2)
									{
										SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_room_beginfight_refuse", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
									}
									else
									{
										SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("pk_room_beginfight_timeout", worldSyncRoomSlotInfo.slotInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
									}
								}
								break;
							}
						}
					}
				}
				else
				{
					Logger.LogError("roomInfo.roomSlotInfos is null in [_OnSyncRoomSlotInfo]");
				}
			}
			else
			{
				Logger.LogError("roomInfo is null in [_OnSyncRoomSlotInfo]");
			}
		}

		// Token: 0x0600B9CD RID: 47565 RVA: 0x002AC4BC File Offset: 0x002AA8BC
		private void _OnQuitRoomRes(MsgDATA msg)
		{
			WorldQuitRoomRes worldQuitRoomRes = new WorldQuitRoomRes();
			worldQuitRoomRes.decode(msg.bytes);
			if (worldQuitRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldQuitRoomRes.result, string.Empty);
			}
			DataManager<Pk3v3CrossDataManager>.GetInstance().ClearRoomInfo();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSimpleInfoUpdate, null, null, null, null);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossMyTeamFrame>(null, false);
		}

		// Token: 0x0600B9CE RID: 47566 RVA: 0x002AC520 File Offset: 0x002AA920
		private void _OnJoinRoomRes(MsgDATA msg)
		{
			WorldJoinRoomRes worldJoinRoomRes = new WorldJoinRoomRes();
			worldJoinRoomRes.decode(msg.bytes);
			if (worldJoinRoomRes.info != null && worldJoinRoomRes.info.roomSimpleInfo != null && worldJoinRoomRes.info.roomSimpleInfo.roomType != 3)
			{
				return;
			}
			if (worldJoinRoomRes.result != 0U)
			{
				if (worldJoinRoomRes.result == 3401020U)
				{
					SystemNotifyManager.SystemNotify(9217, new UnityAction(this.AcceptCreateAmuseRoom));
				}
				else if (worldJoinRoomRes.result == 3401026U)
				{
					SystemNotifyManager.SystemNotify(9218, new UnityAction(this.AcceptCreateMatchRoom));
				}
				else if (worldJoinRoomRes.result == 3401025U)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RefreshRoomList, null, null, null, null);
					SystemNotifyManager.SysNotifyFloatingEffect("该房间已设置密码", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (worldJoinRoomRes.info != null && worldJoinRoomRes.info.roomSimpleInfo != null && worldJoinRoomRes.info.roomSimpleInfo.roomType == 3)
				{
					SystemNotifyManager.SystemNotify((int)worldJoinRoomRes.result, string.Empty);
				}
				return;
			}
			if (worldJoinRoomRes.info.roomSimpleInfo.roomType != 3)
			{
				return;
			}
			Pk3v3CrossDataManager.roomInfo = worldJoinRoomRes.info;
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnJoinRoomRes]");
				return;
			}
			this.GetTeamDataFromRoomData();
			this._DebugTeamData();
			if (!this.CheckPk3v3CrossScence())
			{
				this.SwitchToPk3v3CrossScene();
			}
			else if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossMyTeamFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossTeamListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamListFrame>(null, false);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSimpleInfoUpdate, null, null, null, null);
		}

		// Token: 0x0600B9CF RID: 47567 RVA: 0x002AC708 File Offset: 0x002AAB08
		private void _OnInviteJoinRoomRes(MsgDATA msg)
		{
			WorldInviteJoinRoomRes worldInviteJoinRoomRes = new WorldInviteJoinRoomRes();
			worldInviteJoinRoomRes.decode(msg.bytes);
			if (worldInviteJoinRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldInviteJoinRoomRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B9D0 RID: 47568 RVA: 0x002AC744 File Offset: 0x002AAB44
		private void _OnSyncInviteInfo(MsgDATA msg)
		{
			WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = new WorldSyncRoomInviteInfo();
			worldSyncRoomInviteInfo.decode(msg.bytes);
			if (worldSyncRoomInviteInfo.roomType != 3)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.InviteRoomList.Count; i++)
			{
				if (this.InviteRoomList[i].inviterId == worldSyncRoomInviteInfo.inviterId)
				{
					this.InviteRoomList[i] = worldSyncRoomInviteInfo;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				this.InviteRoomList.Insert(0, worldSyncRoomInviteInfo);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
		}

		// Token: 0x0600B9D1 RID: 47569 RVA: 0x002AC7F0 File Offset: 0x002AABF0
		private void _OnRoomInviteReply(MsgDATA msg)
		{
			WorldBeInviteRoomRes worldBeInviteRoomRes = new WorldBeInviteRoomRes();
			worldBeInviteRoomRes.decode(msg.bytes);
			if (worldBeInviteRoomRes.result != 0U && worldBeInviteRoomRes.result != 3403007U)
			{
				SystemNotifyManager.SystemNotify((int)worldBeInviteRoomRes.result, string.Empty);
				return;
			}
			if (worldBeInviteRoomRes.result == 3403007U)
			{
				return;
			}
			if (worldBeInviteRoomRes.roomInfo.roomSimpleInfo.roomType != 3)
			{
				return;
			}
			Pk3v3CrossDataManager.roomInfo = worldBeInviteRoomRes.roomInfo;
			this.GetTeamDataFromRoomData();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossTeamListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossTeamListFrame>(null, false);
			}
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [_OnJoinRoomRes]");
				return;
			}
			if (worldBeInviteRoomRes.result != 3403007U)
			{
				if (!this.CheckPk3v3CrossScence())
				{
					this.SwitchToPk3v3CrossScene();
				}
				else if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossMyTeamFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMyTeamFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CrossUpdateMyTeamFrame, null, null, null, null);
		}

		// Token: 0x0600B9D2 RID: 47570 RVA: 0x002AC900 File Offset: 0x002AAD00
		private void _OnSyncKickOutInfo(MsgDATA msg)
		{
			WorldSyncRoomKickOutInfo worldSyncRoomKickOutInfo = new WorldSyncRoomKickOutInfo();
			worldSyncRoomKickOutInfo.decode(msg.bytes);
			this.ClearRoomInfo();
			SystemNotifyManager.SysNotifyMsgBoxOK(string.Format("你被玩家{0}踢出了队伍", worldSyncRoomKickOutInfo.kickPlayerName), new UnityAction(this.OnClickOkAcceptBeKickedOut), string.Empty, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3KickOut, null, null, null, null);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossMyTeamFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CrossMyTeamFrame>(null, false);
			}
		}

		// Token: 0x0600B9D3 RID: 47571 RVA: 0x002AC97C File Offset: 0x002AAD7C
		private void _OnKickOutRoomRes(MsgDATA msg)
		{
			WorldKickOutRoomRes worldKickOutRoomRes = new WorldKickOutRoomRes();
			worldKickOutRoomRes.decode(msg.bytes);
			if (worldKickOutRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldKickOutRoomRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B9D4 RID: 47572 RVA: 0x002AC9B8 File Offset: 0x002AADB8
		private void _OnChangeRoomOwnerRes(MsgDATA msg)
		{
			WorldChangeRoomOwnerRes worldChangeRoomOwnerRes = new WorldChangeRoomOwnerRes();
			worldChangeRoomOwnerRes.decode(msg.bytes);
			if (worldChangeRoomOwnerRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldChangeRoomOwnerRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B9D5 RID: 47573 RVA: 0x002AC9F4 File Offset: 0x002AADF4
		private void _OnRoomCloseSlotRes(MsgDATA msg)
		{
			WorldRoomCloseSlotRes worldRoomCloseSlotRes = new WorldRoomCloseSlotRes();
			worldRoomCloseSlotRes.decode(msg.bytes);
			if (worldRoomCloseSlotRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomCloseSlotRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B9D6 RID: 47574 RVA: 0x002ACA30 File Offset: 0x002AAE30
		private void _OnRoomBeginGameRes(MsgDATA msg)
		{
			WorldRoomBattleStartRes worldRoomBattleStartRes = new WorldRoomBattleStartRes();
			worldRoomBattleStartRes.decode(msg.bytes);
			if (worldRoomBattleStartRes.result != 0U && worldRoomBattleStartRes.result != 3600003U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleStartRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3BeginMatchRes, null, null, null, null);
		}

		// Token: 0x0600B9D7 RID: 47575 RVA: 0x002ACA90 File Offset: 0x002AAE90
		private void _OnRoomBattleCancelRes(MsgDATA msg)
		{
			WorldRoomBattleCancelRes worldRoomBattleCancelRes = new WorldRoomBattleCancelRes();
			worldRoomBattleCancelRes.decode(msg.bytes);
			if (worldRoomBattleCancelRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleCancelRes.result, string.Empty);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatchRes, null, null, null, null);
		}

		// Token: 0x0600B9D8 RID: 47576 RVA: 0x002ACAE0 File Offset: 0x002AAEE0
		private void _OnVoteReadyRes(MsgDATA msg)
		{
			WorldRoomBattleReadyRes worldRoomBattleReadyRes = new WorldRoomBattleReadyRes();
			worldRoomBattleReadyRes.decode(msg.bytes);
			if (worldRoomBattleReadyRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomBattleReadyRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600B9D9 RID: 47577 RVA: 0x002ACB1C File Offset: 0x002AAF1C
		private void _OnRoomSendInviteLinkRes(MsgDATA msg)
		{
			WorldRoomSendInviteLinkRes worldRoomSendInviteLinkRes = new WorldRoomSendInviteLinkRes();
			worldRoomSendInviteLinkRes.decode(msg.bytes);
			if (worldRoomSendInviteLinkRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomSendInviteLinkRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect("消息已发送...", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B9DA RID: 47578 RVA: 0x002ACB64 File Offset: 0x002AAF64
		private void _OnRoomSwapSlotRes(MsgDATA msg)
		{
			WorldRoomSwapSlotRes worldRoomSwapSlotRes = new WorldRoomSwapSlotRes();
			worldRoomSwapSlotRes.decode(msg.bytes);
			if (worldRoomSwapSlotRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomSwapSlotRes.result, string.Empty);
				return;
			}
			if (worldRoomSwapSlotRes.playerId > 0UL)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("交换位置请求已发送,请等待...", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B9DB RID: 47579 RVA: 0x002ACBB8 File Offset: 0x002AAFB8
		private void _OnSyncRoomSwapSlotInfo(MsgDATA msg)
		{
			WorldSyncRoomSwapSlotInfo worldSyncRoomSwapSlotInfo = new WorldSyncRoomSwapSlotInfo();
			worldSyncRoomSwapSlotInfo.decode(msg.bytes);
			this.SwapSlotInfo = worldSyncRoomSwapSlotInfo;
			object[] args = new object[]
			{
				worldSyncRoomSwapSlotInfo.playerName
			};
			SystemNotifyManager.SystemNotify(9215, new UnityAction(this.SwapPosOK), new UnityAction(this.SwapPosCancel), this.fChangePosLastTime, args);
		}

		// Token: 0x0600B9DC RID: 47580 RVA: 0x002ACC18 File Offset: 0x002AB018
		private void _OnRoomResponseSwapSlotRes(MsgDATA msg)
		{
			WorldRoomResponseSwapSlotRes stream = new WorldRoomResponseSwapSlotRes();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600B9DD RID: 47581 RVA: 0x002ACC38 File Offset: 0x002AB038
		private void _OnRankListRes(MsgDATA msg)
		{
			WorldSortListRet stream = new WorldSortListRet();
			stream.decode(msg.bytes);
			int num = 0;
			BaseSortList baseSortList = SortListDecoder.Decode(msg.bytes, ref num, msg.bytes.Length, false);
			if (baseSortList == null)
			{
				Logger.LogError("arrRecods decode fail");
				return;
			}
			if (baseSortList.type != SortListType.SORTLIST_SCORE_WAR)
			{
				return;
			}
			if (this.m_arrScoreList == null)
			{
				this.m_arrScoreList = new List<Pk3v3CrossDataManager.ScoreListItem>();
				if (this.m_arrScoreList == null)
				{
					Logger.LogErrorFormat("new List<ScoreListItem>() error!!!", new object[0]);
					return;
				}
			}
			this.m_arrScoreList.Clear();
			for (int i = 0; i < baseSortList.entries.Count; i++)
			{
				ScoreWarSortListEntry scoreWarSortListEntry = baseSortList.entries[i] as ScoreWarSortListEntry;
				if (scoreWarSortListEntry == null)
				{
					Logger.LogErrorFormat("arrRecods.entries[{0}] error!!!", new object[]
					{
						i
					});
				}
				else
				{
					Pk3v3CrossDataManager.ScoreListItem scoreListItem = new Pk3v3CrossDataManager.ScoreListItem();
					if (scoreListItem == null)
					{
						Logger.LogErrorFormat("new ScoreListItem() error!!!", new object[0]);
					}
					else
					{
						scoreListItem.nPlayerID = scoreWarSortListEntry.id;
						scoreListItem.nPlayerScore = (ulong)scoreWarSortListEntry.score;
						scoreListItem.strPlayerName = scoreWarSortListEntry.name;
						scoreListItem.strServerName = scoreWarSortListEntry.serverName;
						scoreListItem.nRank = scoreWarSortListEntry.ranking;
						this.m_arrScoreList.Add(scoreListItem);
					}
				}
			}
			if (baseSortList.selfEntry == null)
			{
				Logger.LogErrorFormat("arrRecods.selfEntry is null!!!", new object[0]);
			}
			else
			{
				ScoreWarSortListEntry scoreWarSortListEntry2 = baseSortList.selfEntry as ScoreWarSortListEntry;
				if (scoreWarSortListEntry2 != null)
				{
					if (this.m_myRankInfo != null)
					{
						this.m_myRankInfo.nPlayerID = scoreWarSortListEntry2.id;
						this.m_myRankInfo.nPlayerScore = (ulong)scoreWarSortListEntry2.score;
						this.m_myRankInfo.strPlayerName = scoreWarSortListEntry2.name;
						this.m_myRankInfo.strServerName = scoreWarSortListEntry2.serverName;
						this.m_myRankInfo.nRank = scoreWarSortListEntry2.ranking;
					}
				}
				else
				{
					Logger.LogErrorFormat("arrRecods.selfEntry as ScoreWarSortListEntry error!!!", new object[0]);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdatePk3v3CrossRankScoreList, null, null, null, null);
		}

		// Token: 0x0600B9DE RID: 47582 RVA: 0x002ACE58 File Offset: 0x002AB258
		private void _OnSyncRoomSwapResultInfo(MsgDATA msg)
		{
			WorldSyncRoomSwapResultInfo worldSyncRoomSwapResultInfo = new WorldSyncRoomSwapResultInfo();
			worldSyncRoomSwapResultInfo.decode(msg.bytes);
			if (worldSyncRoomSwapResultInfo.result == 2)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}拒绝了你交换位置的请求", worldSyncRoomSwapResultInfo.playerName), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else if (worldSyncRoomSwapResultInfo.result == 4)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("交换位置请求取消", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CommonMsgBoxOKCancel>(null, false);
			}
		}

		// Token: 0x0600B9DF RID: 47583 RVA: 0x002ACEC4 File Offset: 0x002AB2C4
		private void OnClickOkAcceptBeKickedOut()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.Pk3v3)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3KickOut, null, null, null, null);
		}

		// Token: 0x0600B9E0 RID: 47584 RVA: 0x002ACF2A File Offset: 0x002AB32A
		private void SwapPosOK()
		{
			this.SendAgreeChangePosReq(true);
		}

		// Token: 0x0600B9E1 RID: 47585 RVA: 0x002ACF33 File Offset: 0x002AB333
		private void SwapPosCancel()
		{
			this.SendAgreeChangePosReq(false);
		}

		// Token: 0x0600B9E2 RID: 47586 RVA: 0x002ACF3C File Offset: 0x002AB33C
		private void AcceptCreateAmuseRoom()
		{
			this.SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_FREE);
		}

		// Token: 0x0600B9E3 RID: 47587 RVA: 0x002ACF45 File Offset: 0x002AB345
		private void AcceptCreateMatchRoom()
		{
			this.SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_SCORE_WAR);
		}

		// Token: 0x0600B9E4 RID: 47588 RVA: 0x002ACF50 File Offset: 0x002AB350
		public void SendCreateRoomReq(RoomType roomtype)
		{
			Pk3v3RoomSettingData pk3v3RoomSettingData = new Pk3v3RoomSettingData();
			pk3v3RoomSettingData.DefaultInit();
			WorldUpdateRoomReq worldUpdateRoomReq = new WorldUpdateRoomReq();
			worldUpdateRoomReq.roomId = 0U;
			worldUpdateRoomReq.roomType = (byte)roomtype;
			worldUpdateRoomReq.name = TR.Value("pkcross_create_room_name", DataManager<PlayerBaseData>.GetInstance().Name);
			worldUpdateRoomReq.password = this.PassWord;
			worldUpdateRoomReq.limitPlayerLevel = (ushort)pk3v3RoomSettingData.MinLv;
			worldUpdateRoomReq.limitPlayerSeasonLevel = (uint)pk3v3RoomSettingData.MinRankLv;
			if (pk3v3RoomSettingData.bSetMinLv)
			{
				worldUpdateRoomReq.isLimitPlayerLevel = 1;
			}
			else
			{
				worldUpdateRoomReq.isLimitPlayerLevel = 0;
			}
			if (pk3v3RoomSettingData.bSetMinRankLv)
			{
				worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
			}
			else
			{
				worldUpdateRoomReq.isLimitPlayerSeasonLevel = 0;
			}
			worldUpdateRoomReq.isLimitPlayerLevel = 1;
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
			worldUpdateRoomReq.limitPlayerLevel = 40;
			worldUpdateRoomReq.limitPlayerSeasonLevel = (uint)DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRoomReq>(ServerType.GATE_SERVER, worldUpdateRoomReq);
		}

		// Token: 0x0600B9E5 RID: 47589 RVA: 0x002AD030 File Offset: 0x002AB430
		public static void SendJoinRoomReq(uint roomid, RoomType roomtype = RoomType.ROOM_TYPE_INVALID, string password = "", uint createTime = 0U)
		{
			WorldJoinRoomReq worldJoinRoomReq = new WorldJoinRoomReq();
			worldJoinRoomReq.roomId = roomid;
			if (roomtype != RoomType.ROOM_TYPE_INVALID)
			{
				worldJoinRoomReq.roomType = (byte)roomtype;
			}
			worldJoinRoomReq.password = password;
			worldJoinRoomReq.createTime = createTime;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldJoinRoomReq>(ServerType.GATE_SERVER, worldJoinRoomReq);
		}

		// Token: 0x0600B9E6 RID: 47590 RVA: 0x002AD078 File Offset: 0x002AB478
		public void Pk3v3RoomInviteOtherPlayer(ulong RoleId)
		{
			WorldInviteJoinRoomReq worldInviteJoinRoomReq = new WorldInviteJoinRoomReq();
			worldInviteJoinRoomReq.playerId = RoleId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldInviteJoinRoomReq>(ServerType.GATE_SERVER, worldInviteJoinRoomReq);
		}

		// Token: 0x0600B9E7 RID: 47591 RVA: 0x002AD0A4 File Offset: 0x002AB4A4
		public void SendPk3v3ChangePosReq(uint roomId, RoomSlotInfo TargetSlotInfo)
		{
			WorldRoomSwapSlotReq worldRoomSwapSlotReq = new WorldRoomSwapSlotReq();
			worldRoomSwapSlotReq.roomId = roomId;
			worldRoomSwapSlotReq.slotGroup = TargetSlotInfo.group;
			worldRoomSwapSlotReq.index = TargetSlotInfo.index;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomSwapSlotReq>(ServerType.GATE_SERVER, worldRoomSwapSlotReq);
		}

		// Token: 0x0600B9E8 RID: 47592 RVA: 0x002AD0E8 File Offset: 0x002AB4E8
		public void SendClosePosReq(byte group, byte index)
		{
			WorldRoomCloseSlotReq worldRoomCloseSlotReq = new WorldRoomCloseSlotReq();
			worldRoomCloseSlotReq.slotGroup = group;
			worldRoomCloseSlotReq.index = index;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomCloseSlotReq>(ServerType.GATE_SERVER, worldRoomCloseSlotReq);
		}

		// Token: 0x0600B9E9 RID: 47593 RVA: 0x002AD118 File Offset: 0x002AB518
		private void SendAgreeChangePosReq(bool bAgree)
		{
			WorldRoomResponseSwapSlotReq worldRoomResponseSwapSlotReq = new WorldRoomResponseSwapSlotReq();
			if (bAgree)
			{
				worldRoomResponseSwapSlotReq.isAccept = 1;
			}
			else
			{
				worldRoomResponseSwapSlotReq.isAccept = 0;
			}
			worldRoomResponseSwapSlotReq.slotGroup = this.SwapSlotInfo.slotGroup;
			worldRoomResponseSwapSlotReq.slotIndex = this.SwapSlotInfo.slotIndex;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomResponseSwapSlotReq>(ServerType.GATE_SERVER, worldRoomResponseSwapSlotReq);
		}

		// Token: 0x0600B9EA RID: 47594 RVA: 0x002AD178 File Offset: 0x002AB578
		public void SwitchToPk3v3CrossScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkWaitingRoom>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(true);
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = clientSystemTown.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = 5007,
				targetDoorID = 0
			}, false));
		}

		// Token: 0x0600B9EB RID: 47595 RVA: 0x002AD239 File Offset: 0x002AB639
		public RoomInfo GetRoomInfo()
		{
			return Pk3v3CrossDataManager.roomInfo;
		}

		// Token: 0x0600B9EC RID: 47596 RVA: 0x002AD240 File Offset: 0x002AB640
		public List<WorldSyncRoomInviteInfo> GetInviteRoomList()
		{
			List<WorldSyncRoomInviteInfo> list = new List<WorldSyncRoomInviteInfo>();
			if (list == null)
			{
				return null;
			}
			if (this.InviteRoomList == null)
			{
				return list;
			}
			list.AddRange(this.InviteRoomList);
			return list;
		}

		// Token: 0x0600B9ED RID: 47597 RVA: 0x002AD278 File Offset: 0x002AB678
		public void RemoveInviteInfo(int index)
		{
			if (this.InviteRoomList == null)
			{
				return;
			}
			if (index < 0 || index >= this.InviteRoomList.Count)
			{
				return;
			}
			WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = this.InviteRoomList[index];
			this.InviteRoomList.RemoveAt(index);
			if (worldSyncRoomInviteInfo != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
			}
		}

		// Token: 0x0600B9EE RID: 47598 RVA: 0x002AD2E8 File Offset: 0x002AB6E8
		public void RemoveInviteInfo(WorldSyncRoomInviteInfo info)
		{
			if (this.InviteRoomList == null || info == null)
			{
				return;
			}
			this.RemoveInviteInfo(this.InviteRoomList.FindIndex((WorldSyncRoomInviteInfo temp) => temp.inviterId == info.inviterId));
		}

		// Token: 0x0600B9EF RID: 47599 RVA: 0x002AD338 File Offset: 0x002AB738
		public void ClearAllInviteInfo()
		{
			if (this.InviteRoomList == null)
			{
				return;
			}
			if (this.InviteRoomList.Count > 0)
			{
				WorldSyncRoomInviteInfo worldSyncRoomInviteInfo = this.InviteRoomList[0];
				this.InviteRoomList.Clear();
				if (worldSyncRoomInviteInfo != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, worldSyncRoomInviteInfo.roomType, null, null, null);
				}
			}
		}

		// Token: 0x0600B9F0 RID: 47600 RVA: 0x002AD3A0 File Offset: 0x002AB7A0
		public static bool HasInPk3v3Room()
		{
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				return false;
			}
			if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos == null)
			{
				return false;
			}
			for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B9F1 RID: 47601 RVA: 0x002AD40C File Offset: 0x002AB80C
		public bool CheckIsInMyRoom(ulong uId)
		{
			if (Pk3v3CrossDataManager.roomInfo == null || Pk3v3CrossDataManager.roomInfo.roomSlotInfos == null)
			{
				return false;
			}
			for (int i = 0; i < Pk3v3CrossDataManager.roomInfo.roomSlotInfos.Length; i++)
			{
				if (Pk3v3CrossDataManager.roomInfo.roomSlotInfos[i].playerId == uId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B9F2 RID: 47602 RVA: 0x002AD46B File Offset: 0x002AB86B
		public bool CheckRoomIsMatching()
		{
			if (Pk3v3CrossDataManager.roomInfo == null)
			{
				return false;
			}
			if (Pk3v3CrossDataManager.roomInfo.roomSimpleInfo.roomStatus == 3)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("队伍正在匹配中,无法进行操作", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return true;
			}
			return false;
		}

		// Token: 0x0600B9F3 RID: 47603 RVA: 0x002AD4A0 File Offset: 0x002AB8A0
		private static void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B9F4 RID: 47604 RVA: 0x002AD4C4 File Offset: 0x002AB8C4
		public static void AcceptJoinPk3v3RoomLink(string param)
		{
			string[] array = param.Split(new char[]
			{
				'|'
			});
			if (array == null || array.Length != 2)
			{
				return;
			}
			int iRoomid = 0;
			long lStamp = 0L;
			if (!int.TryParse(array[0], out iRoomid) || !long.TryParse(array[1], out lStamp))
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE && PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
			{
				SystemNotifyManager.SystemNotify(9307, string.Empty);
				return;
			}
			if (iRoomid <= 0)
			{
				return;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			if (tableItem2 != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem2.Value)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(string.Format("该活动需要达到{0}级后才能加入", tableItem2.Value), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel("进入积分赛场景会退出当前所在队伍，是否确认进入？", delegate()
				{
					DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
					Pk3v3CrossDataManager.SendJoinRoomReq((uint)iRoomid, RoomType.ROOM_TYPE_THREE_SCORE_WAR, string.Empty, (uint)lStamp);
				}, null, 0f, false);
				return;
			}
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Pk3v3CrossDataManager.SendJoinRoomReq((uint)iRoomid, RoomType.ROOM_TYPE_THREE_SCORE_WAR, string.Empty, (uint)lStamp);
		}

		// Token: 0x0600B9F5 RID: 47605 RVA: 0x002AD6AE File Offset: 0x002ABAAE
		public string GetRoomState(RoomStatus roomstatus)
		{
			if (roomstatus == RoomStatus.ROOM_STATUS_BATTLE || roomstatus == RoomStatus.ROOM_STATUS_MATCH || roomstatus == RoomStatus.ROOM_STATUS_READY)
			{
				return "<color=#f0cd0dff>决斗中</color>";
			}
			if (roomstatus == RoomStatus.ROOM_STATUS_OPEN)
			{
				return "<color=#ffffffff>未开始</color>";
			}
			return "异常";
		}

		// Token: 0x0600B9F6 RID: 47606 RVA: 0x002AD6DD File Offset: 0x002ABADD
		public string GetRoomType(RoomType roomtype)
		{
			if (roomtype == RoomType.ROOM_TYPE_THREE_FREE)
			{
				return "娱乐";
			}
			if (roomtype == RoomType.ROOM_TYPE_THREE_MATCH)
			{
				return "段位";
			}
			return "异常";
		}

		// Token: 0x0600B9F7 RID: 47607 RVA: 0x002AD700 File Offset: 0x002ABB00
		public int GetRankLvByIndex(int iIndex)
		{
			if (iIndex == 0)
			{
				return DataManager<SeasonDataManager>.GetInstance().GetMinRankID();
			}
			if (iIndex == 1)
			{
				return 24501;
			}
			if (iIndex == 2)
			{
				return 34501;
			}
			if (iIndex == 3)
			{
				return 44501;
			}
			if (iIndex == 4)
			{
				return 54501;
			}
			return DataManager<SeasonDataManager>.GetInstance().GetMaxRankID();
		}

		// Token: 0x0600B9F8 RID: 47608 RVA: 0x002AD75C File Offset: 0x002ABB5C
		public int RandPassWord()
		{
			return Random.Range(1000, 9999);
		}

		// Token: 0x0600B9F9 RID: 47609 RVA: 0x002AD76D File Offset: 0x002ABB6D
		public string GetPk3v3LocalDataKey(RoomType roomType, string key)
		{
			return string.Format("{0}_3v3_{1}_{2}", DataManager<PlayerBaseData>.GetInstance().RoleID, roomType, key);
		}

		// Token: 0x17001B5F RID: 7007
		// (get) Token: 0x0600B9FB RID: 47611 RVA: 0x002AD798 File Offset: 0x002ABB98
		// (set) Token: 0x0600B9FA RID: 47610 RVA: 0x002AD78F File Offset: 0x002ABB8F
		public int NotifyCount { get; set; }

		// Token: 0x17001B60 RID: 7008
		// (get) Token: 0x0600B9FD RID: 47613 RVA: 0x002AD7A9 File Offset: 0x002ABBA9
		// (set) Token: 0x0600B9FC RID: 47612 RVA: 0x002AD7A0 File Offset: 0x002ABBA0
		public bool IsOpenNotifyFrame
		{
			get
			{
				return this.bOpenNotifyFrame;
			}
			set
			{
				this.bOpenNotifyFrame = value;
			}
		}

		// Token: 0x0600B9FE RID: 47614 RVA: 0x002AD7B1 File Offset: 0x002ABBB1
		public ScoreWarStatus Get3v3CrossWarStatus()
		{
			return this.scoreWarStatus;
		}

		// Token: 0x0600B9FF RID: 47615 RVA: 0x002AD7B9 File Offset: 0x002ABBB9
		public uint Get3v3CrossWarStatusEndTime()
		{
			return this.scoreWarStateEndTime;
		}

		// Token: 0x0600BA00 RID: 47616 RVA: 0x002AD7C1 File Offset: 0x002ABBC1
		public override void OnApplicationStart()
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive(this.m_kSavePath, out this.jsonText);
			if (this.jsonText == null)
			{
				FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, string.Empty);
				this.jsonText = string.Empty;
				return;
			}
		}

		// Token: 0x0600BA01 RID: 47617 RVA: 0x002AD800 File Offset: 0x002ABC00
		public bool IsIDOpened(ulong id)
		{
			if (string.IsNullOrEmpty(this.jsonText))
			{
				return false;
			}
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return false;
			}
			string text = id.ToString();
			return jsonData.ContainsKey(text) && jsonData[text].IsBoolean && (bool)jsonData[text];
		}

		// Token: 0x0600BA02 RID: 47618 RVA: 0x002AD870 File Offset: 0x002ABC70
		public void ClearIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = false;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600BA03 RID: 47619 RVA: 0x002AD900 File Offset: 0x002ABD00
		public void SetIDOpened(ulong id)
		{
			JsonData jsonData = JsonMapper.ToObject(this.jsonText);
			if (jsonData == null)
			{
				return;
			}
			jsonData[id.ToString()] = true;
			try
			{
				this.jsonText = jsonData.ToJson();
				if (!string.IsNullOrEmpty(this.jsonText))
				{
					FileArchiveAccessor.SaveFileInPersistentFileArchive(this.m_kSavePath, this.jsonText);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600BA04 RID: 47620 RVA: 0x002AD990 File Offset: 0x002ABD90
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int value = tableItem.Value;
				if (value > 0 && iPreLv < value && iCurLv >= value)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3CrossButton, (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus(), null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
				}
			}
		}

		// Token: 0x0600BA05 RID: 47621 RVA: 0x002ADA10 File Offset: 0x002ABE10
		private void OnWorldSyncScoreWarInfo(MsgDATA msg)
		{
			SceneSyncScoreWarInfo sceneSyncScoreWarInfo = new SceneSyncScoreWarInfo();
			sceneSyncScoreWarInfo.decode(msg.bytes);
			this.scoreWarStatus = (ScoreWarStatus)sceneSyncScoreWarInfo.status;
			this.scoreWarStateEndTime = sceneSyncScoreWarInfo.statusEndTime;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.Value)
			{
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityDungeonUpdate, null, null, null, null);
			bool flag = sceneSyncScoreWarInfo.status >= 1 && sceneSyncScoreWarInfo.status < 3;
			if (flag)
			{
				this.NotifyCount++;
			}
			else
			{
				this.NotifyCount = 0;
				this.bOpenNotifyFrame = false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && this.NotifyCount > 0 && !this.bOpenNotifyFrame && !this.IsIDOpened((ulong)ClientApplication.playerinfo.accid))
			{
				this.bOpenNotifyFrame = true;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossOpenNotifyFrame>(FrameLayer.Middle, null, string.Empty);
				this.SetIDOpened((ulong)ClientApplication.playerinfo.accid);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3CrossButton, sceneSyncScoreWarInfo.status, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSimpleInfoUpdate, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
			if (this.scoreWarStatus == ScoreWarStatus.SWS_BATTLE && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMatchStartNotifyFrame>(FrameLayer.Middle, null, string.Empty);
			}
			if (this.scoreWarStatus >= ScoreWarStatus.SWS_WAIT_END)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatchRes, null, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3CancelMatch, null, null, null, null);
			}
			if (this.scoreWarStatus == ScoreWarStatus.SWS_INVALID || this.scoreWarStatus == ScoreWarStatus.SWS_WAIT_END || this.scoreWarStatus == ScoreWarStatus.ROOM_TYPE_MAX)
			{
				this.bOpenNotifyFrame = false;
				this.NotifyCount = 0;
				this.ClearIDOpened((ulong)ClientApplication.playerinfo.accid);
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<JoinPK3v3CrossFrame>(null, false);
			}
		}

		// Token: 0x0400686C RID: 26732
		public static uint MAX_PK_COUNT = 5U;

		// Token: 0x0400686D RID: 26733
		private bool m_bNetBind;

		// Token: 0x0400686E RID: 26734
		private Dictionary<RoomType, Pk3v3RoomSettingData> roomSettingData = new Dictionary<RoomType, Pk3v3RoomSettingData>();

		// Token: 0x0400686F RID: 26735
		public bool bHasPassword;

		// Token: 0x04006870 RID: 26736
		public string PassWord = string.Empty;

		// Token: 0x04006871 RID: 26737
		private WorldSyncRoomSwapSlotInfo SwapSlotInfo = new WorldSyncRoomSwapSlotInfo();

		// Token: 0x04006872 RID: 26738
		private float fChangePosLastTime;

		// Token: 0x04006873 RID: 26739
		private float fAddUpTime;

		// Token: 0x04006874 RID: 26740
		private float fChangePosLocationTime;

		// Token: 0x04006875 RID: 26741
		public int iInt;

		// Token: 0x04006876 RID: 26742
		private bool m_bNotify;

		// Token: 0x04006877 RID: 26743
		private int simpleInviteLastTime = -1;

		// Token: 0x04006878 RID: 26744
		private static RoomInfo roomInfo = new RoomInfo();

		// Token: 0x04006879 RID: 26745
		private List<WorldSyncRoomInviteInfo> InviteRoomList = new List<WorldSyncRoomInviteInfo>();

		// Token: 0x0400687A RID: 26746
		private Pk3v3CrossDataManager.Team m_myTeam;

		// Token: 0x0400687B RID: 26747
		private List<Pk3v3CrossDataManager.ScoreListItem> m_arrScoreList;

		// Token: 0x0400687C RID: 26748
		private Pk3v3CrossDataManager.My3v3PkInfo m_pkInfo = new Pk3v3CrossDataManager.My3v3PkInfo();

		// Token: 0x0400687D RID: 26749
		public Pk3v3CrossDataManager.ScoreListItem m_myRankInfo = new Pk3v3CrossDataManager.ScoreListItem();

		// Token: 0x0400687E RID: 26750
		private uint mTeamDungeonID;

		// Token: 0x0400687F RID: 26751
		public bool bMatching;

		// Token: 0x04006880 RID: 26752
		private bool bOpenNotifyFrame;

		// Token: 0x04006882 RID: 26754
		private ScoreWarStatus scoreWarStatus;

		// Token: 0x04006883 RID: 26755
		private uint scoreWarStateEndTime;

		// Token: 0x04006884 RID: 26756
		private string m_kSavePath = "3v3CrossOpen.json";

		// Token: 0x04006885 RID: 26757
		private string jsonText;

		// Token: 0x020012C3 RID: 4803
		public class TeamMember
		{
			// Token: 0x0600BA08 RID: 47624 RVA: 0x002ADC54 File Offset: 0x002AC054
			public void ClearPlayerInfo()
			{
				this.id = 0UL;
				this.guildid = 0UL;
				this.name = string.Empty;
				this.level = 0;
				this.viplevel = 0;
				this.dungeonLeftCount = 0;
				this.occu = 0;
				this.isOnline = false;
				this.isPrepared = false;
				this.isAssist = false;
				this.isBuzy = false;
				this.avatarInfo = null;
			}

			// Token: 0x0600BA09 RID: 47625 RVA: 0x002ADCBB File Offset: 0x002AC0BB
			public void Debug()
			{
			}

			// Token: 0x04006886 RID: 26758
			public ulong id;

			// Token: 0x04006887 RID: 26759
			public ulong guildid;

			// Token: 0x04006888 RID: 26760
			public string name;

			// Token: 0x04006889 RID: 26761
			public ushort level;

			// Token: 0x0400688A RID: 26762
			public uint playerSeasonLevel;

			// Token: 0x0400688B RID: 26763
			public ushort viplevel;

			// Token: 0x0400688C RID: 26764
			public byte occu;

			// Token: 0x0400688D RID: 26765
			public bool isOnline;

			// Token: 0x0400688E RID: 26766
			public bool isPrepared;

			// Token: 0x0400688F RID: 26767
			public bool isBuzy;

			// Token: 0x04006890 RID: 26768
			public bool isAssist;

			// Token: 0x04006891 RID: 26769
			public int dungeonLeftCount;

			// Token: 0x04006892 RID: 26770
			public PlayerAvatar avatarInfo;
		}

		// Token: 0x020012C4 RID: 4804
		public class Team
		{
			// Token: 0x0600BA0B RID: 47627 RVA: 0x002ADCD4 File Offset: 0x002AC0D4
			public void Debug()
			{
				for (int i = 0; i < this.members.Length; i++)
				{
					Pk3v3CrossDataManager.TeamMember teamMember = this.members[i];
					if (teamMember != null)
					{
						teamMember.Debug();
					}
				}
			}

			// Token: 0x04006893 RID: 26771
			public uint teamID;

			// Token: 0x04006894 RID: 26772
			public TeammemberBaseInfo leaderInfo;

			// Token: 0x04006895 RID: 26773
			public byte currentMemberCount;

			// Token: 0x04006896 RID: 26774
			public byte maxMemberCount;

			// Token: 0x04006897 RID: 26775
			public uint autoAgree;

			// Token: 0x04006898 RID: 26776
			public uint teamDungeonID;

			// Token: 0x04006899 RID: 26777
			public Pk3v3CrossDataManager.TeamMember[] members = new Pk3v3CrossDataManager.TeamMember[3];
		}

		// Token: 0x020012C5 RID: 4805
		public class ScoreListItem
		{
			// Token: 0x0400689A RID: 26778
			public ulong nPlayerID;

			// Token: 0x0400689B RID: 26779
			public string strPlayerName;

			// Token: 0x0400689C RID: 26780
			public ulong nPlayerScore;

			// Token: 0x0400689D RID: 26781
			public string strServerName;

			// Token: 0x0400689E RID: 26782
			public ushort nRank;
		}

		// Token: 0x020012C6 RID: 4806
		public class My3v3PkInfo
		{
			// Token: 0x0400689F RID: 26783
			public int nCurPkCount = (int)Pk3v3CrossDataManager.MAX_PK_COUNT;

			// Token: 0x040068A0 RID: 26784
			public uint nScore;

			// Token: 0x040068A1 RID: 26785
			public byte nWinCount;

			// Token: 0x040068A2 RID: 26786
			public List<uint> arrAwardIDs = new List<uint>();
		}
	}
}
