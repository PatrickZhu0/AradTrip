using System;
using System.Collections;
using System.Collections.Generic;
using ActivityLimitTime;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019BE RID: 6590
	internal class Pk3v3CrossTeamMyFrame : ClientFrame
	{
		// Token: 0x060101AC RID: 65964 RVA: 0x0047A5A2 File Offset: 0x004789A2
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossTeamMy";
		}

		// Token: 0x060101AD RID: 65965 RVA: 0x0047A5AC File Offset: 0x004789AC
		private void _InitDropDown()
		{
			if (null != this.m_dropDown)
			{
				ChatType[] eChatTypes = new ChatType[]
				{
					ChatType.CT_ACOMMPANY,
					ChatType.CT_GUILD,
					ChatType.CT_NORMAL
				};
				string[] content = new string[]
				{
					"组队频道",
					"公会频道",
					"附近频道"
				};
				this.m_dropDown.BindItems(content, eChatTypes, new UnityAction<ChatType>(this._OnDropDownValueChanged));
			}
		}

		// Token: 0x060101AE RID: 65966 RVA: 0x0047A614 File Offset: 0x00478A14
		private void _UnInitDropDown()
		{
			if (null != this.m_dropDown)
			{
			}
		}

		// Token: 0x060101AF RID: 65967 RVA: 0x0047A628 File Offset: 0x00478A28
		private void _OnDropDownValueChanged(ChatType eChatType)
		{
			string value = this._GetLeaderInviteWords(true);
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			switch (eChatType)
			{
			case ChatType.CT_WORLD:
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else
				{
					int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
					if (freeWorldChatLeftTimes <= 0 && !DataManager<ChatManager>.GetInstance().CheckWorldActivityValueEnough())
					{
						SystemNotifyManager.SystemNotify(7006, delegate()
						{
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.VIP, string.Empty);
						});
					}
					else if (!ChatManager.world_chat_try_enter_cool_down())
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_interval"), ChatManager.world_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					}
					else
					{
						WorldRoomSendInviteLinkReq worldRoomSendInviteLinkReq = new WorldRoomSendInviteLinkReq();
						worldRoomSendInviteLinkReq.roomId = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo().roomSimpleInfo.id;
						worldRoomSendInviteLinkReq.channel = 3;
						NetManager netManager = NetManager.Instance();
						netManager.SendCommand<WorldRoomSendInviteLinkReq>(ServerType.GATE_SERVER, worldRoomSendInviteLinkReq);
					}
				}
				break;
			}
			case ChatType.CT_NORMAL:
			{
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(173, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_normal_talk_need_level"), tableItem2.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (!ChatManager.arround_chat_try_enter_cool_down())
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_normal_talk_need_interval"), ChatManager.arround_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else
				{
					WorldRoomSendInviteLinkReq worldRoomSendInviteLinkReq2 = new WorldRoomSendInviteLinkReq();
					worldRoomSendInviteLinkReq2.roomId = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo().roomSimpleInfo.id;
					worldRoomSendInviteLinkReq2.channel = 1;
					NetManager netManager2 = NetManager.Instance();
					netManager2.SendCommand<WorldRoomSendInviteLinkReq>(ServerType.GATE_SERVER, worldRoomSendInviteLinkReq2);
				}
				break;
			}
			case ChatType.CT_GUILD:
				if (DataManager<PlayerBaseData>.GetInstance().eGuildDuty == EGuildDuty.Invalid)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chat_guild_talk_need_guild"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else
				{
					WorldRoomSendInviteLinkReq worldRoomSendInviteLinkReq3 = new WorldRoomSendInviteLinkReq();
					worldRoomSendInviteLinkReq3.roomId = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo().roomSimpleInfo.id;
					worldRoomSendInviteLinkReq3.channel = 5;
					NetManager netManager3 = NetManager.Instance();
					netManager3.SendCommand<WorldRoomSendInviteLinkReq>(ServerType.GATE_SERVER, worldRoomSendInviteLinkReq3);
				}
				break;
			case ChatType.CT_ACOMMPANY:
			{
				SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(174, string.Empty, string.Empty);
				if (tableItem3 != null && tableItem3.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_team_talk_need_level"), tableItem3.Value), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else if (!ChatManager.accompany_chat_try_enter_cool_down())
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_accompany_talk_need_interval"), ChatManager.accompany_cool_time), CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				else
				{
					WorldRoomSendInviteLinkReq worldRoomSendInviteLinkReq4 = new WorldRoomSendInviteLinkReq();
					worldRoomSendInviteLinkReq4.roomId = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo().roomSimpleInfo.id;
					worldRoomSendInviteLinkReq4.channel = 9;
					NetManager netManager4 = NetManager.Instance();
					netManager4.SendCommand<WorldRoomSendInviteLinkReq>(ServerType.GATE_SERVER, worldRoomSendInviteLinkReq4);
				}
				break;
			}
			}
		}

		// Token: 0x060101B0 RID: 65968 RVA: 0x0047A9D4 File Offset: 0x00478DD4
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.mIsSendMessage = false;
			if (Global.Settings.IsTestTeam())
			{
				BeUtility.SendGM("!!additem id=200000002 num=1000");
				BeUtility.SendGM("!!additem id=600000006 num=1000");
				BeUtility.SendGM("!!addfatigue num=150");
				Global.Settings.forceUseAutoFight = true;
			}
		}

		// Token: 0x060101B1 RID: 65969 RVA: 0x0047AA26 File Offset: 0x00478E26
		protected override void _OnCloseFrame()
		{
			this.Clear();
		}

		// Token: 0x060101B2 RID: 65970 RVA: 0x0047AA30 File Offset: 0x00478E30
		private new void Clear()
		{
			this.bStartMatch = false;
			this.fAddUpTime = 0f;
			this.mIsSendMessage = false;
			for (int i = 0; i < this.MemberInfoUIs.Length; i++)
			{
				this.MemberInfoUIs[i].AddMemberMark.onClick.RemoveAllListeners();
				this.MemberInfoUIs[i].showMenu.onClick.RemoveAllListeners();
			}
			this.MemberInfoUIs = new Pk3v3CrossTeamMyFrame.MemberUI[3];
			this.UnBindUIEvent();
			this._UnInitDropDown();
			this.UnInitVoiceChatModule();
		}

		// Token: 0x060101B3 RID: 65971 RVA: 0x0047AABC File Offset: 0x00478EBC
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
		}

		// Token: 0x060101B4 RID: 65972 RVA: 0x0047AB50 File Offset: 0x00478F50
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
		}

		// Token: 0x060101B5 RID: 65973 RVA: 0x0047ABE4 File Offset: 0x00478FE4
		private void OnPk3v3RoomSlotInfoUpdate(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
			this.UpdateBeginButton();
		}

		// Token: 0x060101B6 RID: 65974 RVA: 0x0047ABF4 File Offset: 0x00478FF4
		private void _updateTeamChatMsg(UIEvent ui)
		{
			ulong num = (ulong)ui.Param1;
			string message = (string)ui.Param2;
			for (int i = 0; i < this.MemberInfoUIs.Length; i++)
			{
				if (this.MemberInfoUIs[i].memberID == num)
				{
					ComTeamChatMessage com = this.MemberInfoUIs[i].bind.GetCom<ComTeamChatMessage>("chatMessage");
					com.SetMessage(message);
					break;
				}
			}
		}

		// Token: 0x060101B7 RID: 65975 RVA: 0x0047AC69 File Offset: 0x00479069
		private void OnClickClose()
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("正在匹配,无法退出", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.CloseFrame<Pk3v3CrossTeamMyFrame>(this, false);
		}

		// Token: 0x060101B8 RID: 65976 RVA: 0x0047AC90 File Offset: 0x00479090
		private void OnExitTeamBtnClicked()
		{
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			WorldQuitRoomReq cmd = new WorldQuitRoomReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQuitRoomReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060101B9 RID: 65977 RVA: 0x0047ACD0 File Offset: 0x004790D0
		private string _GetLeaderInviteWords(bool bNotify)
		{
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return string.Empty;
			}
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				string str = string.Format(TR.Value("LeaderInvite"), "3v3积分争霸赛");
				str += "{T ";
				str += myTeam.leaderInfo.id.ToString();
				return str + "}";
			}
			if (bNotify)
			{
				SystemNotifyManager.SysNotifyTextAnimation("只有队长才能发送组队邀请公告!", CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			return string.Empty;
		}

		// Token: 0x060101BA RID: 65978 RVA: 0x0047AD68 File Offset: 0x00479168
		private void OnLeaderInvite()
		{
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				string text = string.Format(TR.Value("LeaderInvite"), "3v3积分争霸赛");
				text += "{T ";
				text += myTeam.leaderInfo.id.ToString();
				text += "}";
				ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty) as ChatFrame;
				chatFrame.SetTab(ChatType.CT_ACOMMPANY);
				chatFrame.SetTalkContent(text);
			}
		}

		// Token: 0x060101BB RID: 65979 RVA: 0x0047AE08 File Offset: 0x00479208
		private void _onTeamChat()
		{
			ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty) as ChatFrame;
			chatFrame.SetTab(ChatType.CT_TEAM);
		}

		// Token: 0x060101BC RID: 65980 RVA: 0x0047AE33 File Offset: 0x00479233
		private void OnAutoAgreeClicked(bool value)
		{
		}

		// Token: 0x060101BD RID: 65981 RVA: 0x0047AE38 File Offset: 0x00479238
		private void OnRequestListClicked()
		{
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			WorldTeamRequesterListReq cmd = new WorldTeamRequesterListReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamRequesterListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060101BE RID: 65982 RVA: 0x0047AE6C File Offset: 0x0047926C
		private void OnClickAddMemberMark(int index)
		{
			if (index < 0)
			{
				return;
			}
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			if (scoreWarStatus != ScoreWarStatus.SWS_PREPARE && scoreWarStatus != ScoreWarStatus.SWS_BATTLE)
			{
				return;
			}
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamInvitePlayerListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamInvitePlayerListFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamInvitePlayerListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
		}

		// Token: 0x060101BF RID: 65983 RVA: 0x0047AF2C File Offset: 0x0047932C
		private void OnClickshowMenu(int index)
		{
			if (index < 0)
			{
				return;
			}
			if (this.MemberInfoUIs[index].memberID <= 0UL || this.MemberInfoUIs[index].memberID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			Pk3v3CrossDataManager.TeamMember teamMember = null;
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				if (myTeam.members[i].id == this.MemberInfoUIs[index].memberID)
				{
					teamMember = myTeam.members[i];
					break;
				}
			}
			if (teamMember == null)
			{
				return;
			}
			TeamMenuData teamMenuData = new TeamMenuData();
			teamMenuData.index = (byte)index;
			teamMenuData.memberID = teamMember.id;
			teamMenuData.name = teamMember.name;
			teamMenuData.occu = teamMember.occu;
			teamMenuData.level = teamMember.level;
			teamMenuData.Pos = this.MemberInfoUIs[index].modelRoot.GetComponent<RectTransform>().position;
			if (this.frameMgr.IsFrameOpen<TeamMemberMenuFrame>(null))
			{
				this.frameMgr.CloseFrame<TeamMemberMenuFrame>(null, false);
			}
			this.frameMgr.OpenFrame<TeamMemberMenuFrame>(this.frame, teamMenuData, string.Empty);
		}

		// Token: 0x060101C0 RID: 65984 RVA: 0x0047B064 File Offset: 0x00479464
		private void OnMatchDugeon()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			if (!this.bStartMatch)
			{
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMemberNum() == 3)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("队伍人数已满无法匹配", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (this.CurTeamDungeonTableID == 1U)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("请选择一个目标副本", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (!Utility.CheckTeamEnterDungeonCondition((int)this.CurTeamDungeonTableID))
				{
					return;
				}
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				netManager.SendCommand<SceneTeamMatchStartReq>(ServerType.GATE_SERVER, new SceneTeamMatchStartReq
				{
					dungeonId = (uint)tableItem.DungeonID
				});
			}
			else
			{
				WorldTeamMatchCancelReq cmd = new WorldTeamMatchCancelReq();
				netManager.SendCommand<WorldTeamMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x060101C1 RID: 65985 RVA: 0x0047B13E File Offset: 0x0047953E
		private void _onChangeAssisStatus()
		{
		}

		// Token: 0x060101C2 RID: 65986 RVA: 0x0047B140 File Offset: 0x00479540
		private void OnEnterDungeon()
		{
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			if (this.CurTeamDungeonTableID == 1U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("请选择一个目标副本", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (!Utility.CheckTeamEnterDungeonCondition((int)this.CurTeamDungeonTableID))
			{
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._teamStart((uint)tableItem.DungeonID));
		}

		// Token: 0x060101C3 RID: 65987 RVA: 0x0047B1D4 File Offset: 0x004795D4
		protected IEnumerator _teamStart(uint dungeonID)
		{
			if (!this.mIsSendMessage)
			{
				MessageEvents msg = new MessageEvents();
				SceneDungeonStartReq req = new SceneDungeonStartReq();
				SceneDungeonStartRes res = new SceneDungeonStartRes();
				req.dungeonId = dungeonID;
				this.mIsSendMessage = true;
				yield return MessageUtility.Wait<SceneDungeonStartReq, SceneDungeonStartRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f);
				if (res.result == 0U)
				{
				}
				this.mIsSendMessage = false;
			}
			yield break;
		}

		// Token: 0x060101C4 RID: 65988 RVA: 0x0047B1F6 File Offset: 0x004795F6
		private void InitInterface()
		{
			this.InitMemberInfoUI();
			this.UpdateTeamInfo();
			this.UpdateMemberInfo();
			this._InitDropDown();
			this.BindUIEvent();
			this.UpdateBeginButton();
			this.InitVoiceChatModule();
		}

		// Token: 0x060101C5 RID: 65989 RVA: 0x0047B224 File Offset: 0x00479624
		private void InitMemberInfoUI()
		{
			string prefabPath = this.mBind.GetPrefabPath("memberunit");
			this.mBind.ClearCacheBinds(prefabPath);
			for (int i = 0; i < 3; i++)
			{
				ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
				if (null != comCommonBind)
				{
					Utility.AttachTo(comCommonBind.gameObject, this.mMembersRoot, false);
					Text com = comCommonBind.GetCom<Text>("level");
					Text com2 = comCommonBind.GetCom<Text>("job");
					Text com3 = comCommonBind.GetCom<Text>("name");
					Image com4 = comCommonBind.GetCom<Image>("leaderMark");
					Button com5 = comCommonBind.GetCom<Button>("addMemberMask");
					Button com6 = comCommonBind.GetCom<Button>("showMenu");
					GameObject gameObject = comCommonBind.GetGameObject("modelRoot");
					GeAvatarRendererEx com7 = comCommonBind.GetCom<GeAvatarRendererEx>("avatarRenderer");
					GameObject gameObject2 = comCommonBind.GetGameObject("content");
					GameObject gameObject3 = comCommonBind.GetGameObject("friendstatus");
					GameObject gameObject4 = comCommonBind.GetGameObject("guildstatus");
					GameObject gameObject5 = comCommonBind.GetGameObject("helpfightstatus");
					Text com8 = comCommonBind.GetCom<Text>("viplevel");
					GameObject gameObject6 = comCommonBind.GetGameObject("vipRoot");
					GameObject gameObject7 = comCommonBind.GetGameObject("buzystatus");
					GameObject gameObject8 = comCommonBind.GetGameObject("normalstatus");
					GameObject gameObject9 = comCommonBind.GetGameObject("FatigueCombustionRoot");
					Text com9 = comCommonBind.GetCom<Text>("seasonLv");
					Pk3v3CrossTeamMyFrame.MemberUI memberUI = new Pk3v3CrossTeamMyFrame.MemberUI();
					memberUI.memberID = 0UL;
					memberUI.bind = comCommonBind;
					memberUI.contentRoot = gameObject2;
					memberUI.Level = com;
					memberUI.Job = com2;
					memberUI.memberName = com3;
					memberUI.leaderMark = com4;
					memberUI.AddMemberMark = com5;
					memberUI.showMenu = com6;
					memberUI.modelRoot = gameObject;
					memberUI.avatarRenderer = com7;
					memberUI.mFatigueCombustionRoot = gameObject9;
					memberUI.seasonLv = com9;
					this.MemberInfoUIs[i] = memberUI;
				}
			}
		}

		// Token: 0x060101C6 RID: 65990 RVA: 0x0047B3F8 File Offset: 0x004797F8
		private void UpdateTeamInfo()
		{
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			uint num = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatusEndTime();
			this.mTargetDengeonName.text = string.Empty;
		}

		// Token: 0x060101C7 RID: 65991 RVA: 0x0047B440 File Offset: 0x00479840
		private void _updateMemberFlagInfo()
		{
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			int num = 0;
			while (num < myTeam.members.Length && num < 3)
			{
				Pk3v3CrossDataManager.TeamMember teamMember = myTeam.members[num];
				if (teamMember.id > 0UL)
				{
					Pk3v3CrossTeamMyFrame.MemberUI memberUI = null;
					for (int i = 0; i < this.MemberInfoUIs.Length; i++)
					{
						if (this.MemberInfoUIs[i].memberID == teamMember.id)
						{
							memberUI = this.MemberInfoUIs[i];
							break;
						}
					}
					if (memberUI != null)
					{
						eTeammateFlag teammateFlag = DataManager<Pk3v3CrossDataManager>.GetInstance().GetTeammateFlag(teamMember.id);
						memberUI.SetFlag(teammateFlag);
					}
				}
				num++;
			}
		}

		// Token: 0x060101C8 RID: 65992 RVA: 0x0047B504 File Offset: 0x00479904
		private void UpdateMemberInfo()
		{
			Pk3v3CrossDataManager.Team myTeam = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < myTeam.members.Length && num2 < 3)
			{
				Pk3v3CrossDataManager.TeamMember teamMember = myTeam.members[num2];
				if (teamMember != null && teamMember.id > 0UL)
				{
					if (num < this.MemberInfoUIs.Length)
					{
						Pk3v3CrossTeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
						if (memberUI != null)
						{
							memberUI.memberID = teamMember.id;
							memberUI.contentRoot.SetActive(true);
							memberUI.Level.text = string.Format("Lv.{0}", teamMember.level);
							memberUI.memberName.text = teamMember.name;
							memberUI.leaderMark.gameObject.SetActive(teamMember.id == myTeam.leaderInfo.id);
							memberUI.seasonLv.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)teamMember.playerSeasonLevel, true);
							memberUI.SetBuzy(teamMember.isBuzy);
							memberUI.SetVipLevel((int)teamMember.viplevel);
							JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>((int)teamMember.occu, string.Empty, string.Empty);
							if (tableItem == null)
							{
								Logger.LogErrorFormat("can not find JobTable with id:{0}", new object[]
								{
									teamMember.occu
								});
							}
							else
							{
								memberUI.Job.text = tableItem.Name;
								ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
								if (tableItem2 == null)
								{
									Logger.LogErrorFormat("can not find ResTable with id:{0}", new object[]
									{
										tableItem.Mode
									});
								}
								else
								{
									memberUI.avatarRenderer.LoadAvatar(tableItem2.ModelPath, this.ModelLayers[num]);
									this._FixLightDir();
									DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(memberUI.avatarRenderer, teamMember.avatarInfo.equipItemIds, (int)teamMember.occu, (int)teamMember.avatarInfo.weaponStrengthen, null, false, teamMember.avatarInfo.isShoWeapon, false);
									memberUI.avatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
								}
							}
							if (teamMember.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								this.mOnHelpFightStatus.isOn = teamMember.isAssist;
							}
							num++;
						}
					}
				}
				num2++;
			}
			for (int i = num; i < 3; i++)
			{
				Pk3v3CrossTeamMyFrame.MemberUI memberUI2 = this.MemberInfoUIs[i];
				memberUI2.memberID = 0UL;
				memberUI2.contentRoot.SetActive(false);
			}
			for (int j = 0; j < 3; j++)
			{
				Pk3v3CrossTeamMyFrame.MemberUI memberUI3 = this.MemberInfoUIs[j];
				int iIdx = j;
				memberUI3.AddMemberMark.onClick.RemoveAllListeners();
				memberUI3.AddMemberMark.onClick.AddListener(delegate()
				{
					this.OnClickAddMemberMark(iIdx);
				});
				memberUI3.AddMemberMark.gameObject.SetActive(memberUI3.memberID <= 0UL);
				int iIdx2 = j;
				memberUI3.showMenu.onClick.RemoveAllListeners();
				if (memberUI3.memberID > 0UL && memberUI3.memberID != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					memberUI3.showMenu.onClick.AddListener(delegate()
					{
						this.OnClickshowMenu(iIdx2);
					});
				}
			}
			this._updateMemberFlagInfo();
		}

		// Token: 0x060101C9 RID: 65993 RVA: 0x0047B898 File Offset: 0x00479C98
		private void UpdateBuyNum(TeamDungeonTable data)
		{
			this._updateMemberFlagInfo();
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(data.DungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				this.mBtBuyNum.gameObject.SetActive(false);
				this.mHelpFightRoot.SetActive(false);
				return;
			}
			if (tableItem.SubType == DungeonTable.eSubType.S_TEAM_BOSS)
			{
				this.mBtBuyNum.gameObject.SetActive(true);
				this.mHelpFightRoot.SetActive(true);
			}
			else
			{
				this.mBtBuyNum.gameObject.SetActive(false);
				this.mHelpFightRoot.SetActive(false);
			}
		}

		// Token: 0x060101CA RID: 65994 RVA: 0x0047B936 File Offset: 0x00479D36
		private void OnAddMemberSuccess(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x060101CB RID: 65995 RVA: 0x0047B93E File Offset: 0x00479D3E
		private void OnRemoveMemberSuccess(UIEvent iEvent)
		{
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
			{
				this.frameMgr.CloseFrame<Pk3v3CrossTeamMyFrame>(this, false);
			}
			else
			{
				this.UpdateMemberInfo();
			}
		}

		// Token: 0x060101CC RID: 65996 RVA: 0x0047B967 File Offset: 0x00479D67
		private void OnChangeLeaderSuccess(UIEvent iEvent)
		{
			this.UpdateTeamInfo();
			this.UpdateMemberInfo();
		}

		// Token: 0x060101CD RID: 65997 RVA: 0x0047B975 File Offset: 0x00479D75
		private void OnTeamInfoChangeSuccess(UIEvent iEvent)
		{
			this.UpdateTeamInfo();
		}

		// Token: 0x060101CE RID: 65998 RVA: 0x0047B97D File Offset: 0x00479D7D
		private void OnTeamPosStateChanged(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x060101CF RID: 65999 RVA: 0x0047B985 File Offset: 0x00479D85
		private void OnMemberStateChanged(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x060101D0 RID: 66000 RVA: 0x0047B990 File Offset: 0x00479D90
		private void OnRedPointChanged(UIEvent iEvent)
		{
			ERedPoint eredPoint = (ERedPoint)iEvent.Param1;
			if (eredPoint == ERedPoint.TeamNewRequester)
			{
				this.mNewRequestRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.TeamNewRequester));
			}
		}

		// Token: 0x060101D1 RID: 66001 RVA: 0x0047B9D4 File Offset: 0x00479DD4
		private void OnTeamMatchStartSuccess(UIEvent uiEvent)
		{
			this.fAddUpTime = 0f;
			this.bStartMatch = true;
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			TeamMatchWaitingData teamMatchWaitingData = new TeamMatchWaitingData();
			if (tableItem.MatchType == TeamDungeonTable.eMatchType.QUICK_MATCH)
			{
				teamMatchWaitingData.matchState = MatchState.TeamMatch;
			}
			else
			{
				teamMatchWaitingData.matchState = MatchState.TeamJoin;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMatchWaitingFrame>(FrameLayer.Middle, teamMatchWaitingData, string.Empty);
		}

		// Token: 0x17001D29 RID: 7465
		// (get) Token: 0x060101D2 RID: 66002 RVA: 0x0047BA5D File Offset: 0x00479E5D
		private uint CurTeamDungeonTableID
		{
			get
			{
				return DataManager<Pk3v3CrossDataManager>.GetInstance().TeamDungeonID;
			}
		}

		// Token: 0x060101D3 RID: 66003 RVA: 0x0047BA6C File Offset: 0x00479E6C
		private void OnTeamMatchCancelSuccess(UIEvent uiEvent)
		{
			this.bStartMatch = false;
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.MatchType == TeamDungeonTable.eMatchType.QUICK_MATCH)
			{
				this.mMatchText.text = "快速匹配";
			}
			else
			{
				this.mMatchText.text = "快速组队";
			}
		}

		// Token: 0x060101D4 RID: 66004 RVA: 0x0047BAE4 File Offset: 0x00479EE4
		[MessageHandle(601639U, false, 0)]
		private void OnTeamRequestersListRes(MsgDATA msg)
		{
			WorldTeamRequesterListRes worldTeamRequesterListRes = new WorldTeamRequesterListRes();
			worldTeamRequesterListRes.decode(msg.bytes);
			List<TeammemberBaseInfo> list = new List<TeammemberBaseInfo>();
			for (int i = 0; i < worldTeamRequesterListRes.requesters.Length; i++)
			{
				list.Add(worldTeamRequesterListRes.requesters[i]);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamRequesterListFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x060101D5 RID: 66005 RVA: 0x0047BB44 File Offset: 0x00479F44
		private void _FixLightDir()
		{
			while (Global.Settings.avatarLightDir.x > 360f)
			{
				GlobalSetting settings = Global.Settings;
				settings.avatarLightDir.x = settings.avatarLightDir.x - 360f;
			}
			while (Global.Settings.avatarLightDir.x < 0f)
			{
				GlobalSetting settings2 = Global.Settings;
				settings2.avatarLightDir.x = settings2.avatarLightDir.x + 360f;
			}
			while (Global.Settings.avatarLightDir.y > 360f)
			{
				GlobalSetting settings3 = Global.Settings;
				settings3.avatarLightDir.y = settings3.avatarLightDir.y - 360f;
			}
			while (Global.Settings.avatarLightDir.y < 0f)
			{
				GlobalSetting settings4 = Global.Settings;
				settings4.avatarLightDir.y = settings4.avatarLightDir.y + 360f;
			}
			while (Global.Settings.avatarLightDir.z > 360f)
			{
				GlobalSetting settings5 = Global.Settings;
				settings5.avatarLightDir.z = settings5.avatarLightDir.z - 360f;
			}
			while (Global.Settings.avatarLightDir.z < 0f)
			{
				GlobalSetting settings6 = Global.Settings;
				settings6.avatarLightDir.z = settings6.avatarLightDir.z + 360f;
			}
		}

		// Token: 0x060101D6 RID: 66006 RVA: 0x0047BCA7 File Offset: 0x0047A0A7
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060101D7 RID: 66007 RVA: 0x0047BCAC File Offset: 0x0047A0AC
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.bStartMatch)
			{
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyTeam() == null)
				{
					return;
				}
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				this.fAddUpTime += timeElapsed;
				int num = (int)this.fAddUpTime;
				if (tableItem.MatchType == TeamDungeonTable.eMatchType.QUICK_MATCH)
				{
					this.mMatchText.text = string.Format("匹配中({0}秒)", num);
				}
				else
				{
					this.mMatchText.text = string.Format("组队中({0}秒)", num);
				}
			}
		}

		// Token: 0x060101D8 RID: 66008 RVA: 0x0047BD54 File Offset: 0x0047A154
		private void InitVoiceChatModule()
		{
		}

		// Token: 0x060101D9 RID: 66009 RVA: 0x0047BD56 File Offset: 0x0047A156
		private void UnInitVoiceChatModule()
		{
		}

		// Token: 0x060101DA RID: 66010 RVA: 0x0047BD58 File Offset: 0x0047A158
		private void SetVoiceInputBtnShow(bool isShow)
		{
			if (this.mTeamVoiceBtnGo)
			{
				this.mTeamVoiceBtnGo.CustomActive(isShow);
			}
			if (this.mTeamVoiceBtn)
			{
				this.mTeamVoiceBtn.gameObject.CustomActive(isShow);
			}
		}

		// Token: 0x060101DB RID: 66011 RVA: 0x0047BD98 File Offset: 0x0047A198
		protected override void _bindExUI()
		{
			this.mMembersRoot = this.mBind.GetGameObject("MembersRoot");
			this.mTargetDengeonName = this.mBind.GetCom<Text>("TargetDengeonName");
			this.mFuncs = this.mBind.GetGameObject("Funcs");
			this.mBtAutoAgree = this.mBind.GetCom<Toggle>("btAutoAgree");
			this.mBtAutoAgree.onValueChanged.AddListener(new UnityAction<bool>(this._onBtAutoAgreeToggleValueChange));
			this.mNewRequestRedPoint = this.mBind.GetCom<Image>("NewRequestRedPoint");
			this.mMatchText = this.mBind.GetCom<Text>("MatchText");
			this.mBtBuyNum = this.mBind.GetCom<ComCommonBind>("btBuyNum");
			this.mLeaderInviteText = this.mBind.GetCom<Text>("LeaderInviteText");
			this.mOnExit = this.mBind.GetCom<Button>("onExit");
			this.mOnExit.onClick.AddListener(new UnityAction(this._onOnExitButtonClick));
			this.mOnInvite = this.mBind.GetCom<Button>("onInvite");
			this.mOnInvite.onClick.AddListener(new UnityAction(this._onOnInviteButtonClick));
			this.mOnReqestList = this.mBind.GetCom<Button>("onReqestList");
			this.mOnReqestList.onClick.AddListener(new UnityAction(this._onOnReqestListButtonClick));
			this.mOnMatch = this.mBind.GetCom<Button>("onMatch");
			this.mOnMatch.onClick.AddListener(new UnityAction(this._onOnMatchButtonClick));
			this.mOnEnterDungeon = this.mBind.GetCom<Button>("onEnterDungeon");
			this.mOnEnterDungeon.onClick.AddListener(new UnityAction(this._onOnEnterDungeonButtonClick));
			this.mOnHelpFightStatus = this.mBind.GetCom<Toggle>("onHelpFightStatus");
			this.mOnHelpFightStatus.onValueChanged.AddListener(new UnityAction<bool>(this._onOnHelpFightStatusToggleValueChange));
			this.mOnHelpFight = this.mBind.GetCom<Button>("onHelpFight");
			this.mOnHelpFight.onClick.AddListener(new UnityAction(this._onOnHelpFightButtonClick));
			this.mOnTeamTalk = this.mBind.GetCom<Button>("onTeamTalk");
			this.mOnTeamTalk.onClick.AddListener(new UnityAction(this._onOnTeamTalkButtonClick));
			this.mHelpFightRoot = this.mBind.GetGameObject("helpFightRoot");
			this.mTeamVoiceBtn = this.mBind.GetCom<VoiceInputBtn>("teamVoiceBtn");
			this.mTeamVoiceBtnGo = this.mBind.GetGameObject("teamVoiceBtnGo");
			this.mBtStartImage = this.mBind.GetCom<Image>("btStartImage");
			this.mBtMatchText = this.mBind.GetCom<Text>("btMatchText");
			this.goBattleTimeState = this.mBind.GetGameObject("goBattleTimeState");
			this.mOnEnterDungeonGray = this.mBind.GetCom<UIGray>("btEnterDungeonGray");
			for (int i = 0; i < 6; i++)
			{
				Text com = this.mBind.GetCom<Text>(string.Format("txtTime{0}", i));
				if (com != null)
				{
					this.arrNumbers.Add(com);
				}
			}
		}

		// Token: 0x060101DC RID: 66012 RVA: 0x0047C0E4 File Offset: 0x0047A4E4
		protected override void _unbindExUI()
		{
			this.mMembersRoot = null;
			this.mTargetDengeonName = null;
			this.mFuncs = null;
			this.mBtAutoAgree.onValueChanged.RemoveListener(new UnityAction<bool>(this._onBtAutoAgreeToggleValueChange));
			this.mBtAutoAgree = null;
			this.mNewRequestRedPoint = null;
			this.mMatchText = null;
			this.mBtBuyNum = null;
			this.mLeaderInviteText = null;
			this.mOnExit.onClick.RemoveListener(new UnityAction(this._onOnExitButtonClick));
			this.mOnExit = null;
			this.mOnInvite.onClick.RemoveListener(new UnityAction(this._onOnInviteButtonClick));
			this.mOnInvite = null;
			this.mOnReqestList.onClick.RemoveListener(new UnityAction(this._onOnReqestListButtonClick));
			this.mOnReqestList = null;
			this.mOnMatch.onClick.RemoveListener(new UnityAction(this._onOnMatchButtonClick));
			this.mOnMatch = null;
			this.mOnEnterDungeon.onClick.RemoveListener(new UnityAction(this._onOnEnterDungeonButtonClick));
			this.mOnEnterDungeon = null;
			this.mOnHelpFightStatus.onValueChanged.RemoveListener(new UnityAction<bool>(this._onOnHelpFightStatusToggleValueChange));
			this.mOnHelpFightStatus = null;
			this.mOnHelpFight.onClick.RemoveListener(new UnityAction(this._onOnHelpFightButtonClick));
			this.mOnHelpFight = null;
			this.mOnTeamTalk.onClick.RemoveListener(new UnityAction(this._onOnTeamTalkButtonClick));
			this.mOnTeamTalk = null;
			this.mHelpFightRoot = null;
			this.mTeamVoiceBtn = null;
			this.mTeamVoiceBtnGo = null;
			this.mBtStartImage = null;
			this.mBtMatchText = null;
			this.goBattleTimeState = null;
			this.arrNumbers.Clear();
			this.mOnEnterDungeonGray = null;
		}

		// Token: 0x060101DD RID: 66013 RVA: 0x0047C299 File Offset: 0x0047A699
		private void _onBtAutoAgreeToggleValueChange(bool changed)
		{
			this.OnAutoAgreeClicked(changed);
		}

		// Token: 0x060101DE RID: 66014 RVA: 0x0047C2A2 File Offset: 0x0047A6A2
		private void _onOnCloseButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x060101DF RID: 66015 RVA: 0x0047C2AA File Offset: 0x0047A6AA
		private void _onOnExitButtonClick()
		{
			this.OnExitTeamBtnClicked();
		}

		// Token: 0x060101E0 RID: 66016 RVA: 0x0047C2B2 File Offset: 0x0047A6B2
		private void _onOnInviteButtonClick()
		{
			this.OnLeaderInvite();
		}

		// Token: 0x060101E1 RID: 66017 RVA: 0x0047C2BA File Offset: 0x0047A6BA
		private void _onOnReqestListButtonClick()
		{
			this.OnRequestListClicked();
		}

		// Token: 0x060101E2 RID: 66018 RVA: 0x0047C2C2 File Offset: 0x0047A6C2
		private void _onOnMatchButtonClick()
		{
			this.OnMatchDugeon();
		}

		// Token: 0x060101E3 RID: 66019 RVA: 0x0047C2CA File Offset: 0x0047A6CA
		private void _onOnEnterDungeonButtonClick()
		{
			this._onBtBeginButtonClick();
		}

		// Token: 0x060101E4 RID: 66020 RVA: 0x0047C2D4 File Offset: 0x0047A6D4
		private void OnBeginMatch(UIEvent iEvent)
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.Pk3v3Cross;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
			if (roomInfo.roomSimpleInfo.roomType == 3)
			{
				this.ShowCancelText(roomInfo);
			}
			this.UpdateBeginButton();
		}

		// Token: 0x060101E5 RID: 66021 RVA: 0x0047C330 File Offset: 0x0047A730
		private void OnBeginMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x060101E6 RID: 66022 RVA: 0x0047C33C File Offset: 0x0047A73C
		private void OnCancelMatch(UIEvent iEvent)
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			if (roomInfo.roomSimpleInfo.roomType == 3)
			{
				this.ShowBeginText(roomInfo);
			}
			this.UpdateBeginButton();
		}

		// Token: 0x060101E7 RID: 66023 RVA: 0x0047C388 File Offset: 0x0047A788
		private void UpdateBeginButton()
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			ScoreWarStatus scoreWarStatus = DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus();
			this.mOnEnterDungeonGray.SetEnable(false);
			this.mOnEnterDungeon.interactable = true;
			if (scoreWarStatus != ScoreWarStatus.SWS_BATTLE || (roomInfo != null && roomInfo.roomSimpleInfo.id > 0U && roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID))
			{
				this.mOnEnterDungeonGray.SetEnable(true);
				this.mOnEnterDungeon.interactable = false;
			}
			this.mOnEnterDungeon.CustomActive(true);
			if (roomInfo != null && roomInfo.roomSimpleInfo.id > 0U && roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.mOnEnterDungeon.CustomActive(false);
			}
			if (roomInfo != null && roomInfo.roomSimpleInfo.roomStatus == 3)
			{
				this.mBtMatchText.text = "取消匹配";
			}
			else
			{
				this.mBtMatchText.text = "开始匹配";
			}
			if (scoreWarStatus == ScoreWarStatus.SWS_PREPARE || scoreWarStatus == ScoreWarStatus.SWS_BATTLE)
			{
				this.m_dropDown.m_button.interactable = true;
				if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
				{
					this.m_dropDown.m_button.interactable = false;
				}
			}
			else
			{
				this.m_dropDown.m_button.interactable = false;
			}
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && pkInfo.nCurPkCount >= 5)
			{
				this.mOnEnterDungeonGray.SetEnable(true);
				this.mOnEnterDungeon.interactable = false;
			}
		}

		// Token: 0x060101E8 RID: 66024 RVA: 0x0047C522 File Offset: 0x0047A922
		private void OnCancelMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x060101E9 RID: 66025 RVA: 0x0047C52B File Offset: 0x0047A92B
		private void ShowBeginText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1)
			{
				this.mBtMatchText.text = "开始决斗";
			}
			else
			{
				this.mBtMatchText.text = "开始匹配";
			}
		}

		// Token: 0x060101EA RID: 66026 RVA: 0x0047C563 File Offset: 0x0047A963
		private void ShowCancelText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1)
			{
				this.mBtMatchText.text = "取消决斗";
			}
			else
			{
				this.mBtMatchText.text = "取消匹配";
			}
		}

		// Token: 0x060101EB RID: 66027 RVA: 0x0047C59C File Offset: 0x0047A99C
		private void _onBtBeginButtonClick()
		{
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null || roomInfo.roomSlotInfos == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo.roomStatus == 1)
			{
				if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你不是房主,无法开始游戏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
				{
					if (roomInfo.roomSlotInfos[i].playerId > 0UL && roomInfo.roomSlotInfos[i].status == 4)
					{
						SystemNotifyManager.SystemNotify(9216, string.Empty);
						return;
					}
				}
			}
			if (roomInfo.roomSimpleInfo.roomStatus == 2)
			{
				return;
			}
			if (this.bMatchLock)
			{
				return;
			}
			this.bMatchLock = true;
			if (roomInfo.roomSimpleInfo.roomStatus == 1)
			{
				this.SendBeginGameReq();
			}
			else if (roomInfo.roomSimpleInfo.roomStatus == 3)
			{
				this.SendCancelGameReq();
			}
			else
			{
				Logger.LogErrorFormat("Pk3v3 begin state is error, roomstate = {0}", new object[]
				{
					roomInfo.roomSimpleInfo.roomStatus
				});
			}
		}

		// Token: 0x060101EC RID: 66028 RVA: 0x0047C6D0 File Offset: 0x0047AAD0
		private void SendBeginGameReq()
		{
			WorldRoomBattleStartReq cmd = new WorldRoomBattleStartReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleStartReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060101ED RID: 66029 RVA: 0x0047C6F4 File Offset: 0x0047AAF4
		private void SendCancelGameReq()
		{
			WorldRoomBattleCancelReq cmd = new WorldRoomBattleCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060101EE RID: 66030 RVA: 0x0047C716 File Offset: 0x0047AB16
		private void _onOnHelpFightStatusToggleValueChange(bool changed)
		{
		}

		// Token: 0x060101EF RID: 66031 RVA: 0x0047C718 File Offset: 0x0047AB18
		private void _onOnHelpFightButtonClick()
		{
			this._onChangeAssisStatus();
		}

		// Token: 0x060101F0 RID: 66032 RVA: 0x0047C720 File Offset: 0x0047AB20
		private void _onOnTeamTalkButtonClick()
		{
			this._onTeamChat();
		}

		// Token: 0x060101F1 RID: 66033 RVA: 0x0047C728 File Offset: 0x0047AB28
		private void GetLeftTime(uint nEndTime, uint nNowTime, ref int nLeftDay, ref int nLeftHour, ref int nLeftMin, ref int nLeftSec)
		{
			nLeftDay = 0;
			nLeftHour = 0;
			nLeftMin = 0;
			nLeftSec = 0;
			if (nEndTime <= nNowTime)
			{
				return;
			}
			uint num = nEndTime - nNowTime;
			uint num2 = num / 86400U;
			num -= num2 * 24U * 60U * 60U;
			uint num3 = num / 3600U;
			num -= num3 * 60U * 60U;
			uint num4 = num / 60U;
			num -= num4 * 60U;
			uint num5 = num;
			nLeftDay = (int)num2;
			nLeftHour = (int)num3;
			nLeftMin = (int)num4;
			nLeftSec = (int)num5;
		}

		// Token: 0x0400A283 RID: 41603
		private int[] ModelLayers = new int[]
		{
			15,
			16,
			17
		};

		// Token: 0x0400A284 RID: 41604
		private bool mBisFlag;

		// Token: 0x0400A285 RID: 41605
		private ActivityLimitTimeData data;

		// Token: 0x0400A286 RID: 41606
		private ActivityLimitTimeDetailData mData;

		// Token: 0x0400A287 RID: 41607
		private bool mFatigueCombustionTimeIsOpen;

		// Token: 0x0400A288 RID: 41608
		private Text mTime;

		// Token: 0x0400A289 RID: 41609
		private int mFatigueCombustionTime = -1;

		// Token: 0x0400A28A RID: 41610
		private const int TeamMemberNum = 3;

		// Token: 0x0400A28B RID: 41611
		private bool bStartMatch;

		// Token: 0x0400A28C RID: 41612
		private float fAddUpTime;

		// Token: 0x0400A28D RID: 41613
		private Pk3v3CrossTeamMyFrame.MemberUI[] MemberInfoUIs = new Pk3v3CrossTeamMyFrame.MemberUI[3];

		// Token: 0x0400A28E RID: 41614
		[UIControl("root/ChannelSelect", typeof(MyDropDown), 0)]
		private MyDropDown m_dropDown;

		// Token: 0x0400A28F RID: 41615
		[UIObject("root/ChannelSelect")]
		private GameObject m_goLeader;

		// Token: 0x0400A290 RID: 41616
		private bool mIsSendMessage;

		// Token: 0x0400A291 RID: 41617
		private VoiceChatModule voiceChatModule;

		// Token: 0x0400A292 RID: 41618
		private GameObject mMembersRoot;

		// Token: 0x0400A293 RID: 41619
		private Text mTargetDengeonName;

		// Token: 0x0400A294 RID: 41620
		private GameObject mFuncs;

		// Token: 0x0400A295 RID: 41621
		private Toggle mBtAutoAgree;

		// Token: 0x0400A296 RID: 41622
		private Image mNewRequestRedPoint;

		// Token: 0x0400A297 RID: 41623
		private Text mMatchText;

		// Token: 0x0400A298 RID: 41624
		private ComCommonBind mBtBuyNum;

		// Token: 0x0400A299 RID: 41625
		private Text mLeaderInviteText;

		// Token: 0x0400A29A RID: 41626
		private Button mOnExit;

		// Token: 0x0400A29B RID: 41627
		private Button mOnInvite;

		// Token: 0x0400A29C RID: 41628
		private Button mOnReqestList;

		// Token: 0x0400A29D RID: 41629
		private Button mOnMatch;

		// Token: 0x0400A29E RID: 41630
		private Button mOnEnterDungeon;

		// Token: 0x0400A29F RID: 41631
		private Toggle mOnHelpFightStatus;

		// Token: 0x0400A2A0 RID: 41632
		private Button mOnHelpFight;

		// Token: 0x0400A2A1 RID: 41633
		private Button mOnTeamTalk;

		// Token: 0x0400A2A2 RID: 41634
		private GameObject mHelpFightRoot;

		// Token: 0x0400A2A3 RID: 41635
		private VoiceInputBtn mTeamVoiceBtn;

		// Token: 0x0400A2A4 RID: 41636
		private GameObject mTeamVoiceBtnGo;

		// Token: 0x0400A2A5 RID: 41637
		private Text mBtMatchText;

		// Token: 0x0400A2A6 RID: 41638
		private UIGray mOnEnterDungeonGray;

		// Token: 0x0400A2A7 RID: 41639
		private GameObject goBattleTimeState;

		// Token: 0x0400A2A8 RID: 41640
		private List<Text> arrNumbers = new List<Text>();

		// Token: 0x0400A2A9 RID: 41641
		private bool bMatchLock;

		// Token: 0x0400A2AA RID: 41642
		private string StartBtnRedPath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_06";

		// Token: 0x0400A2AB RID: 41643
		private string StartBtnBluePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Lanse_01";

		// Token: 0x0400A2AC RID: 41644
		private const int MaxPlayerNum = 3;

		// Token: 0x0400A2AD RID: 41645
		private Image mBtStartImage;

		// Token: 0x020019BF RID: 6591
		public class MemberUI
		{
			// Token: 0x060101F4 RID: 66036 RVA: 0x0047C7B8 File Offset: 0x0047ABB8
			public void SetBuzy(bool isBuzy)
			{
				if (null == this.bind)
				{
					return;
				}
				GameObject gameObject = this.bind.GetGameObject("buzystatus");
				GameObject gameObject2 = this.bind.GetGameObject("normalstatus");
				gameObject.SetActive(isBuzy);
				gameObject2.SetActive(!isBuzy);
			}

			// Token: 0x060101F5 RID: 66037 RVA: 0x0047C80C File Offset: 0x0047AC0C
			public void SetFlag(eTeammateFlag relation)
			{
				if (null == this.bind)
				{
					return;
				}
				GameObject gameObject = this.bind.GetGameObject("friendstatus");
				GameObject gameObject2 = this.bind.GetGameObject("guildstatus");
				GameObject gameObject3 = this.bind.GetGameObject("helpfightstatus");
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
				if ((relation & eTeammateFlag.Friend) != eTeammateFlag.None)
				{
					gameObject.SetActive(true);
				}
				if ((relation & eTeammateFlag.Guild) != eTeammateFlag.None)
				{
					gameObject2.SetActive(true);
				}
				if ((relation & eTeammateFlag.HelpFight) != eTeammateFlag.None)
				{
					gameObject3.SetActive(true);
				}
			}

			// Token: 0x060101F6 RID: 66038 RVA: 0x0047C8A0 File Offset: 0x0047ACA0
			public void SetVipLevel(int level)
			{
				if (null == this.bind)
				{
					return;
				}
				Text com = this.bind.GetCom<Text>("viplevel");
				GameObject gameObject = this.bind.GetGameObject("vipRoot");
				gameObject.SetActive(level > 0);
				com.text = level.ToString();
			}

			// Token: 0x0400A2AF RID: 41647
			public ulong memberID;

			// Token: 0x0400A2B0 RID: 41648
			public ComCommonBind bind;

			// Token: 0x0400A2B1 RID: 41649
			public GameObject contentRoot;

			// Token: 0x0400A2B2 RID: 41650
			public Text Level;

			// Token: 0x0400A2B3 RID: 41651
			public Text Job;

			// Token: 0x0400A2B4 RID: 41652
			public Image leaderMark;

			// Token: 0x0400A2B5 RID: 41653
			public Text memberName;

			// Token: 0x0400A2B6 RID: 41654
			public Button AddMemberMark;

			// Token: 0x0400A2B7 RID: 41655
			public Button showMenu;

			// Token: 0x0400A2B8 RID: 41656
			public GameObject modelRoot;

			// Token: 0x0400A2B9 RID: 41657
			public GeAvatarRendererEx avatarRenderer;

			// Token: 0x0400A2BA RID: 41658
			public GameObject mFatigueCombustionRoot;

			// Token: 0x0400A2BB RID: 41659
			public Text seasonLv;
		}
	}
}
