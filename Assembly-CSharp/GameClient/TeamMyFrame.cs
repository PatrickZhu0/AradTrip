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
	// Token: 0x02001C1A RID: 7194
	internal class TeamMyFrame : ClientFrame
	{
		// Token: 0x06011A03 RID: 72195 RVA: 0x00526512 File Offset: 0x00524912
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMy";
		}

		// Token: 0x06011A04 RID: 72196 RVA: 0x0052651C File Offset: 0x0052491C
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
				if (GuildDataManager.IsGuildTeamDungeonID((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID))
				{
					eChatTypes = new ChatType[]
					{
						ChatType.CT_GUILD
					};
					content = new string[]
					{
						"公会频道"
					};
				}
				this.m_dropDown.BindItems(content, eChatTypes, new UnityAction<ChatType>(this._OnDropDownValueChanged));
			}
		}

		// Token: 0x06011A05 RID: 72197 RVA: 0x005265B2 File Offset: 0x005249B2
		private void _UnInitDropDown()
		{
			if (null != this.m_dropDown)
			{
			}
		}

		// Token: 0x06011A06 RID: 72198 RVA: 0x005265C8 File Offset: 0x005249C8
		private void _OnDropDownValueChanged(ChatType eChatType)
		{
			string text = this._GetLeaderInviteWords(true);
			if (string.IsNullOrEmpty(text))
			{
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
						SystemNotifyManager.SysNotifyTextAnimation("消息发送成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
						DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_WORLD, text, 0UL, 0);
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
					SystemNotifyManager.SysNotifyTextAnimation("消息发送成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_NORMAL, text, 0UL, 0);
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
					SystemNotifyManager.SysNotifyTextAnimation("消息发送成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_GUILD, text, 0UL, 0);
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
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_ACOMMPANY, text, 0UL, 0);
					SystemNotifyManager.SysNotifyTextAnimation("消息发送成功!", CommonTipsDesc.eShowMode.SI_IMMEDIATELY);
				}
				break;
			}
			}
		}

		// Token: 0x06011A07 RID: 72199 RVA: 0x0052689C File Offset: 0x00524C9C
		protected override void _OnOpenFrame()
		{
			this.bToggleInit = true;
			this.returnPlayerBufs = null;
			this.FliterSecondMenuDict.Clear();
			this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
			this.InitInterface();
			this.mIsSendMessage = false;
			if (Global.Settings.IsTestTeam())
			{
				BeUtility.SendGM("!!additem id=200000002 num=1000");
				BeUtility.SendGM("!!additem id=600000006 num=1000");
				BeUtility.SendGM("!!addfatigue num=150");
				Global.Settings.forceUseAutoFight = true;
				if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader() && DataManager<TeamDataManager>.GetInstance().GetMemberNum() >= 3)
				{
					Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(5000, delegate
					{
						this._onOnEnterDungeonButtonClick();
					}, 0, 0, false);
				}
			}
		}

		// Token: 0x06011A08 RID: 72200 RVA: 0x0052695B File Offset: 0x00524D5B
		protected override void _OnCloseFrame()
		{
			this.bToggleInit = false;
			this.returnPlayerBufs = null;
			this.Clear();
		}

		// Token: 0x06011A09 RID: 72201 RVA: 0x00526974 File Offset: 0x00524D74
		private new void Clear()
		{
			this.bStartMatch = false;
			this.fAddUpTime = 0f;
			this.mIsSendMessage = false;
			for (int i = 0; i < this.MemberInfoUIs.Length; i++)
			{
				TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[i];
				if (memberUI != null)
				{
					if (memberUI.AddMemberMark != null)
					{
						memberUI.AddMemberMark.onClick.RemoveAllListeners();
					}
					if (memberUI.showMenu != null)
					{
						memberUI.showMenu.onClick.RemoveAllListeners();
					}
				}
			}
			this.MemberInfoUIs = new TeamMyFrame.MemberUI[3];
			this.UnBindUIEvent();
			this._UnInitDropDown();
			this.UnInitVoiceChatModule();
		}

		// Token: 0x06011A0A RID: 72202 RVA: 0x00526A24 File Offset: 0x00524E24
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnRemoveMemberSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamChangeLeaderSuccess, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamInfoUpdateSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamInfoChangeSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamPosStateChanged, new ClientEventSystem.UIEventHandler(this.OnTeamPosStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMemberStateChanged, new ClientEventSystem.UIEventHandler(this.OnMemberStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this.OnMemberStateChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchStartSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchCancelSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamNotifyChatMsg, new ClientEventSystem.UIEventHandler(this._updateTeamChatMsg));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamTimeChanged, new ClientEventSystem.UIEventHandler(this.OnTeamTimeChanged));
		}

		// Token: 0x06011A0B RID: 72203 RVA: 0x00526BB8 File Offset: 0x00524FB8
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnRemoveMemberSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamChangeLeaderSuccess, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamInfoUpdateSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamInfoChangeSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamPosStateChanged, new ClientEventSystem.UIEventHandler(this.OnTeamPosStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMemberStateChanged, new ClientEventSystem.UIEventHandler(this.OnMemberStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this.OnMemberStateChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this.OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchStartSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchCancelSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamNotifyChatMsg, new ClientEventSystem.UIEventHandler(this._updateTeamChatMsg));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RemoveSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamTimeChanged, new ClientEventSystem.UIEventHandler(this.OnTeamTimeChanged));
		}

		// Token: 0x06011A0C RID: 72204 RVA: 0x00526D4C File Offset: 0x0052514C
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

		// Token: 0x06011A0D RID: 72205 RVA: 0x00526DC1 File Offset: 0x005251C1
		private void OnClickClose()
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_dungeon_is_matching"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.CloseFrame<TeamMyFrame>(this, false);
		}

		// Token: 0x06011A0E RID: 72206 RVA: 0x00526DED File Offset: 0x005251ED
		private void OnExitTeamBtnClicked()
		{
			DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x06011A0F RID: 72207 RVA: 0x00526E04 File Offset: 0x00525204
		private string _GetLeaderInviteWords(bool bNotify)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return string.Empty;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				string str = string.Format(TR.Value("LeaderInvite"), tableItem.Name);
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

		// Token: 0x06011A10 RID: 72208 RVA: 0x00526EC4 File Offset: 0x005252C4
		private void OnLeaderInvite()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				string text = string.Format(TR.Value("LeaderInvite"), tableItem.Name);
				text += "{T ";
				text += myTeam.leaderInfo.id.ToString();
				text += "}";
				ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty) as ChatFrame;
				chatFrame.SetTab(ChatType.CT_ACOMMPANY);
				chatFrame.SetTalkContent(text);
			}
		}

		// Token: 0x06011A11 RID: 72209 RVA: 0x00526F84 File Offset: 0x00525384
		private void _onTeamChat()
		{
			ChatFrame chatFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty) as ChatFrame;
			chatFrame.SetTab(ChatType.CT_TEAM);
		}

		// Token: 0x06011A12 RID: 72210 RVA: 0x00526FAF File Offset: 0x005253AF
		private void OnAutoAgreeClicked(bool value)
		{
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			if (!value)
			{
				DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.AutoAgree, 0);
			}
			else
			{
				DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.AutoAgree, 1);
			}
		}

		// Token: 0x06011A13 RID: 72211 RVA: 0x00526FE4 File Offset: 0x005253E4
		private void OnRequestListClicked()
		{
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			WorldTeamRequesterListReq cmd = new WorldTeamRequesterListReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamRequesterListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06011A14 RID: 72212 RVA: 0x00527018 File Offset: 0x00525418
		private void OnClickAddMemberMark(int index)
		{
			if (index < 0)
			{
				return;
			}
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader() && myTeam.autoAgree != 1U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_leader_forbid_team_member_to_invite"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamInvitePlayerListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamInvitePlayerListFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamInvitePlayerListFrame>(FrameLayer.Middle, InviteType.TeamInvite, string.Empty);
		}

		// Token: 0x06011A15 RID: 72213 RVA: 0x005270A0 File Offset: 0x005254A0
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
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			TeamMember teamMember = null;
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

		// Token: 0x06011A16 RID: 72214 RVA: 0x005271D8 File Offset: 0x005255D8
		private void OnMatchDugeon()
		{
			if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			if (!this.bStartMatch)
			{
				if (DataManager<TeamDataManager>.GetInstance().GetMemberNum() == 3)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_dungeon_team_number_overflow"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (this.CurTeamDungeonTableID == 1U)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_dungeon_select_one_duplication"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
				{
					netManager.SendCommand<SceneTeamMatchStartReq>(ServerType.GATE_SERVER, new SceneTeamMatchStartReq
					{
						dungeonId = (uint)tableItem.DungeonID
					});
				}
				else
				{
					if (!Utility.CheckTeamEnterDungeonCondition((int)this.CurTeamDungeonTableID))
					{
						return;
					}
					netManager.SendCommand<SceneTeamMatchStartReq>(ServerType.GATE_SERVER, new SceneTeamMatchStartReq
					{
						dungeonId = (uint)tableItem.DungeonID
					});
				}
			}
			else
			{
				WorldTeamMatchCancelReq cmd = new WorldTeamMatchCancelReq();
				netManager.SendCommand<WorldTeamMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x06011A17 RID: 72215 RVA: 0x005272EB File Offset: 0x005256EB
		private void _onChangeAssisStatus()
		{
			DataManager<TeamDataManager>.GetInstance().ChangeMainPlayerAssitState();
		}

		// Token: 0x06011A18 RID: 72216 RVA: 0x005272F8 File Offset: 0x005256F8
		private void OnEnterDungeon()
		{
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
			{
				return;
			}
			if (this.CurTeamDungeonTableID == 1U)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_dungeon_select_one_duplication"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
			{
				DataManager<AttackCityMonsterDataManager>.GetInstance().EnterFindPathProcessByTeamDuplication();
				return;
			}
			if (!Utility.CheckTeamEnterDungeonCondition((int)this.CurTeamDungeonTableID))
			{
				return;
			}
			if (DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(tableItem.DungeonID))
			{
				if (!Utility.CheckTeamEnterGuildDungeon())
				{
					return;
				}
				if (!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonOpen(tableItem.DungeonID))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonNotOpenNow"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			bool flag = this.IsShowEnterDuplicationTips(tableItem.DungeonID);
			if (flag)
			{
				return;
			}
			bool flag2 = DataManager<SkillDataManager>.GetInstance().IsShowSkillTreeFrameTipBySkillConfig(new Action(this.OnEnterGame));
			if (flag2)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._teamStart((uint)tableItem.DungeonID));
		}

		// Token: 0x06011A19 RID: 72217 RVA: 0x00527420 File Offset: 0x00525820
		private bool IsShowEnterDuplicationTips(int dungeonId)
		{
			string empty = string.Empty;
			bool flag = DungeonUtility.IsShowDungeonResistMagicValueTip(dungeonId, ref empty);
			if (flag)
			{
				SystemNotifyManager.SysNotifyMsgBoxCancelOk(empty, null, new UnityAction(this.OnEnterGame), 0f, false, null);
				return true;
			}
			return false;
		}

		// Token: 0x06011A1A RID: 72218 RVA: 0x00527464 File Offset: 0x00525864
		private void OnEnterGame()
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._teamStart((uint)tableItem.DungeonID));
		}

		// Token: 0x06011A1B RID: 72219 RVA: 0x005274AC File Offset: 0x005258AC
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
			else
			{
				Logger.LogErrorFormat("[组队] 等待组队进入副本网络消息中", new object[0]);
			}
			yield break;
		}

		// Token: 0x06011A1C RID: 72220 RVA: 0x005274CE File Offset: 0x005258CE
		private void InitInterface()
		{
			this.InitMemberInfoUI();
			this.UpdateTeamInfo();
			this.UpdateMemberInfo();
			this._InitDropDown();
			this.BindUIEvent();
			this.InitVoiceChatModule();
		}

		// Token: 0x06011A1D RID: 72221 RVA: 0x005274F4 File Offset: 0x005258F4
		private void UpdateReturnPlayerBufItems(ComCommonBind bind, PlayerLabelInfo playerLabelInfo)
		{
			if (bind == null || playerLabelInfo == null)
			{
				return;
			}
			GameObject gameObject = bind.GetGameObject("BuffContent");
			if (gameObject != null)
			{
				for (int i = 0; i < gameObject.GetComponentsInChildren<ComItem>().Length; i++)
				{
					Object.Destroy(gameObject.GetComponentsInChildren<ComItem>()[i].gameObject);
				}
			}
			List<int> list = new List<int>
			{
				11017000,
				11017001,
				11017002
			};
			if (playerLabelInfo.returnAnniversaryTitle != 0U)
			{
				list.Add(11017003);
			}
			if (list == null)
			{
				return;
			}
			for (int j = 0; j < list.Count; j++)
			{
				OpActivityTaskTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<OpActivityTaskTable>(list[j], string.Empty, string.Empty);
				if (tableItem != null)
				{
					string taskReward = tableItem.TaskReward;
					string[] array = taskReward.Split(new char[]
					{
						'_'
					});
					if (array.Length >= 2)
					{
						int tableId = int.Parse(array[0]);
						int count = int.Parse(array[1]);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
						if (itemData != null)
						{
							itemData.Count = count;
							ComItem com = bind.GetCom<ComItem>("Item");
							ComItem comItem = Object.Instantiate<ComItem>(com);
							if (comItem != null)
							{
								comItem.CustomActive(true);
								comItem.transform.SetParent(bind.GetGameObject("BuffContent").transform, false);
								comItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
								{
									DataManager<ItemTipManager>.GetInstance().CloseAll();
									DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
								});
							}
						}
					}
				}
			}
		}

		// Token: 0x06011A1E RID: 72222 RVA: 0x005276AC File Offset: 0x00525AAC
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
					GameObject gameObject = comCommonBind.GetGameObject("ResistMagicRoot");
					Text com4 = comCommonBind.GetCom<Text>("resistMagicValue");
					Image com5 = comCommonBind.GetCom<Image>("leaderMark");
					Button com6 = comCommonBind.GetCom<Button>("addMemberMask");
					Button com7 = comCommonBind.GetCom<Button>("showMenu");
					GameObject gameObject2 = comCommonBind.GetGameObject("modelRoot");
					GeAvatarRendererEx com8 = comCommonBind.GetCom<GeAvatarRendererEx>("avatarRenderer");
					GameObject gameObject3 = comCommonBind.GetGameObject("content");
					GameObject gameObject4 = comCommonBind.GetGameObject("friendstatus");
					GameObject gameObject5 = comCommonBind.GetGameObject("guildstatus");
					GameObject gameObject6 = comCommonBind.GetGameObject("helpfightstatus");
					Text com9 = comCommonBind.GetCom<Text>("viplevel");
					GameObject gameObject7 = comCommonBind.GetGameObject("vipRoot");
					GameObject gameObject8 = comCommonBind.GetGameObject("buzystatus");
					GameObject gameObject9 = comCommonBind.GetGameObject("normalstatus");
					GameObject gameObject10 = comCommonBind.GetGameObject("FatigueCombustionRoot");
					Button com10 = comCommonBind.GetCom<Button>("RewardPreview");
					Button com11 = comCommonBind.GetCom<Button>("Search");
					GameObject gameObject11 = comCommonBind.GetGameObject("CountDownRoot");
					Image com12 = comCommonBind.GetCom<Image>("Ten");
					Image com13 = comCommonBind.GetCom<Image>("Bits");
					TeamMyFrame.MemberUI memberUI = new TeamMyFrame.MemberUI();
					memberUI.memberID = 0UL;
					memberUI.bind = comCommonBind;
					memberUI.contentRoot = gameObject3;
					memberUI.Level = com;
					memberUI.Job = com2;
					memberUI.memberName = com3;
					memberUI.resistMagicRoot = gameObject;
					memberUI.resistMagicValue = com4;
					memberUI.leaderMark = com5;
					memberUI.AddMemberMark = com6;
					memberUI.showMenu = com7;
					memberUI.modelRoot = gameObject2;
					memberUI.avatarRenderer = com8;
					memberUI.mFatigueCombustionRoot = gameObject10;
					memberUI.rewardPreview = com10;
					memberUI.searchBtn = com11;
					memberUI.countDownRoot = gameObject11;
					memberUI.tenImg = com12;
					memberUI.bitsImg = com13;
					this.MemberInfoUIs[i] = memberUI;
				}
			}
		}

		// Token: 0x06011A1F RID: 72223 RVA: 0x00527904 File Offset: 0x00525D04
		private void UpdateTeamInfo()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mTargetDengeonName.text = tableItem.Name;
			this.UpdateTargetDungeonInfo(tableItem.DungeonID);
			this.UpdateMemberResistMagicInfoByTeamChanged();
			if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				this.mFuncs.SetActive(true);
				this.mOnInvite.gameObject.SetActive(false);
				this.m_goLeader.CustomActive(true);
				if (myTeam.autoAgree == 1U)
				{
					this.mBtAutoAgree.isOn = true;
				}
				else
				{
					this.mBtAutoAgree.isOn = false;
				}
				if (!this.bStartMatch)
				{
					if (tableItem.MatchType == TeamDungeonTable.eMatchType.QUICK_MATCH)
					{
						this.mMatchText.text = "快速匹配";
					}
					else
					{
						this.mMatchText.text = "快速组队";
					}
				}
				this.mNewRequestRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.TeamNewRequester));
			}
			else
			{
				this.mFuncs.SetActive(false);
				this.mOnInvite.gameObject.SetActive(false);
				this.m_goLeader.CustomActive(false);
			}
			if (this.togAutoAgreeEnter != null)
			{
				this.togAutoAgreeEnter.isOn = DataManager<TeamDataManager>.GetInstance().IsAutoAgree;
			}
			if (this.goAutoAgree != null)
			{
				this.goAutoAgree.CustomActive(DataManager<TeamDataManager>.GetInstance().IsTeamLeader());
			}
			if (this.goAutoAgreeEnter != null)
			{
				this.goAutoAgreeEnter.CustomActive(!DataManager<TeamDataManager>.GetInstance().IsTeamLeader());
			}
			if (this.btSelectTarget != null)
			{
				this.btSelectTarget.CustomActive(DataManager<TeamDataManager>.GetInstance().IsTeamLeader());
			}
			this.UpdateBuyNum(tableItem);
			this.UpdateAutoReturnFromHellUI();
			this.UpdateEliteNotCostFatigueUI();
		}

		// Token: 0x06011A20 RID: 72224 RVA: 0x00527B00 File Offset: 0x00525F00
		private void UpdateTargetDungeonInfo(int dungeonId)
		{
			if (this.mTargetDungeonResistMagicRoot == null)
			{
				return;
			}
			if (this.mTargetDengeonResistMagicValue == null)
			{
				return;
			}
			int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(dungeonId);
			if (dungeonResistMagicValueById <= 0)
			{
				this.mTargetDungeonResistMagicRoot.CustomActive(false);
			}
			else
			{
				this.mTargetDungeonResistMagicRoot.CustomActive(true);
				this.mTargetDengeonResistMagicValue.text = dungeonResistMagicValueById.ToString();
			}
		}

		// Token: 0x06011A21 RID: 72225 RVA: 0x00527B74 File Offset: 0x00525F74
		private void _updateMemberFlagInfo()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			int num = 0;
			while (num < myTeam.members.Length && num < 3)
			{
				TeamMember teamMember = myTeam.members[num];
				if (teamMember.id > 0UL)
				{
					TeamMyFrame.MemberUI memberUI = null;
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
						eTeammateFlag teammateFlag = DataManager<TeamDataManager>.GetInstance().GetTeammateFlag(teamMember.id);
						memberUI.SetFlag(teammateFlag);
					}
				}
				num++;
			}
		}

		// Token: 0x06011A22 RID: 72226 RVA: 0x00527C38 File Offset: 0x00526038
		private void UpdateMemberResistMagicInfoByTeamChanged()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < myTeam.members.Length && num2 < 3)
			{
				TeamMember teamMember = myTeam.members[num2];
				if (teamMember != null && teamMember.id > 0UL)
				{
					if (num < this.MemberInfoUIs.Length)
					{
						TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
						if (memberUI != null)
						{
							this.UpdatePlayerResistMagicValue(memberUI.resistMagicValue, teamMember.resistMagicValue, memberUI.resistMagicRoot);
							num++;
						}
					}
				}
				num2++;
			}
		}

		// Token: 0x06011A23 RID: 72227 RVA: 0x00527CE4 File Offset: 0x005260E4
		private void UpdateMemberInfo()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < myTeam.members.Length && num2 < 3)
			{
				TeamMember teamMember = myTeam.members[num2];
				if (teamMember != null && teamMember.id > 0UL)
				{
					if (num < this.MemberInfoUIs.Length)
					{
						TeamMyFrame.MemberUI ui = this.MemberInfoUIs[num];
						if (ui != null)
						{
							if (TeamDataManager.AutomaticBackIsStart)
							{
								if (myTeam.leaderInfo.id == teamMember.id)
								{
									ui.countDownRoot.CustomActive(true);
								}
							}
							else
							{
								ui.countDownRoot.CustomActive(false);
							}
							ui.memberID = teamMember.id;
							ui.contentRoot.SetActive(true);
							ui.Level.text = string.Format("Lv.{0}", teamMember.level);
							ui.memberName.text = teamMember.name;
							if (ui.memberID == DataManager<PlayerBaseData>.GetInstance().RoleID)
							{
								ui.memberName.color = new Color32(42, 232, 167, byte.MaxValue);
							}
							else
							{
								ui.memberName.color = new Color32(204, 221, 239, byte.MaxValue);
							}
							RelationData relationData = null;
							DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(teamMember.id, ref relationData);
							if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
							{
								ui.memberName.text = relationData.remark;
							}
							ui.leaderMark.gameObject.SetActive(teamMember.id == myTeam.leaderInfo.id);
							this.UpdatePlayerResistMagicValue(ui.resistMagicValue, teamMember.resistMagicValue, ui.resistMagicRoot);
							ui.SetBuzy(teamMember.isBuzy);
							ui.SetVipLevel((int)teamMember.viplevel);
							StaticUtility.SafeSetVisible<Button>(ui.bind, "returnPlayer", teamMember.playerLabelInfo.returnStatus == 1);
							PlayerLabelInfo playerLabelInfo = teamMember.playerLabelInfo;
							StaticUtility.SafeSetBtnCallBack(ui.bind, "returnPlayer", delegate
							{
								StaticUtility.SafeSetVisible(ui.bind, "returnPlayerBuffInfo", true);
								this.UpdateReturnPlayerBufItems(ui.bind, playerLabelInfo);
								this.returnPlayerBufs = ui.bind.GetGameObject("returnPlayerBuffInfo");
								if (this.returnPlayerBufs != null)
								{
									this.returnPlayerBufs.transform.SetParent(this.GetFrame().transform);
									this.returnPlayerBufs.transform.SetAsLastSibling();
								}
								this.returnPlayerBufsBk.CustomActive(true);
							});
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
								ui.Job.text = tableItem.Name;
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
									ui.avatarRenderer.LoadAvatar(tableItem2.ModelPath, this.ModelLayers[num]);
									this._FixLightDir();
									DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(ui.avatarRenderer, teamMember.avatarInfo.equipItemIds, (int)teamMember.occu, (int)teamMember.avatarInfo.weaponStrengthen, null, false, teamMember.avatarInfo.isShoWeapon, false);
									ui.avatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
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
				TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[i];
				memberUI.memberID = 0UL;
				memberUI.contentRoot.SetActive(false);
				StaticUtility.SafeSetVisible<Button>(memberUI.bind, "returnPlayer", false);
			}
			for (int j = 0; j < 3; j++)
			{
				TeamMyFrame.MemberUI memberUI2 = this.MemberInfoUIs[j];
				int iIdx = j;
				memberUI2.AddMemberMark.onClick.RemoveAllListeners();
				memberUI2.AddMemberMark.onClick.AddListener(delegate()
				{
					this.OnClickAddMemberMark(iIdx);
				});
				memberUI2.AddMemberMark.gameObject.SetActive(memberUI2.memberID <= 0UL);
				int iIdx2 = j;
				memberUI2.showMenu.onClick.RemoveAllListeners();
				if (memberUI2.memberID > 0UL && memberUI2.memberID != DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					memberUI2.showMenu.onClick.AddListener(delegate()
					{
						this.OnClickshowMenu(iIdx2);
					});
				}
				if (memberUI2.rewardPreview != null)
				{
					memberUI2.rewardPreview.onClick.RemoveAllListeners();
					memberUI2.rewardPreview.onClick.AddListener(new UnityAction(this.OpenTeamRewardPreviewFrame));
				}
				if (memberUI2.searchBtn != null)
				{
					memberUI2.searchBtn.onClick.RemoveAllListeners();
					memberUI2.searchBtn.onClick.AddListener(new UnityAction(this.OpenTeamRewardPreviewFrame));
				}
			}
			if (TeamDataManager.AutomaticBackIsStart)
			{
				this.UpdateCountDownInfo(TeamDataManager.iAutoMaticBackRemainTime);
			}
			this._updateMemberFlagInfo();
		}

		// Token: 0x06011A24 RID: 72228 RVA: 0x005282DD File Offset: 0x005266DD
		private void OpenTeamRewardPreviewFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamRewardPreviewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06011A25 RID: 72229 RVA: 0x005282F4 File Offset: 0x005266F4
		private void UpdatePlayerResistMagicValue(Text magicValueText, uint playerResistMagicValue, GameObject resistMagicRoot)
		{
			if (magicValueText == null)
			{
				return;
			}
			if (resistMagicRoot == null)
			{
				return;
			}
			resistMagicRoot.CustomActive(false);
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(tableItem.DungeonID);
			if (dungeonResistMagicValueById <= 0)
			{
				return;
			}
			resistMagicRoot.CustomActive(true);
			if ((long)dungeonResistMagicValueById <= (long)((ulong)playerResistMagicValue))
			{
				magicValueText.text = string.Format(TR.Value("resist_magic_value_normal"), playerResistMagicValue);
			}
			else
			{
				magicValueText.text = string.Format(TR.Value("resist_magic_value_less"), playerResistMagicValue);
			}
		}

		// Token: 0x06011A26 RID: 72230 RVA: 0x005283A4 File Offset: 0x005267A4
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

		// Token: 0x06011A27 RID: 72231 RVA: 0x00528442 File Offset: 0x00526842
		private void OnAddMemberSuccess(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x06011A28 RID: 72232 RVA: 0x0052844A File Offset: 0x0052684A
		private void OnSetNoteNameSuccess(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x06011A29 RID: 72233 RVA: 0x00528452 File Offset: 0x00526852
		private void OnRemoveMemberSuccess(UIEvent iEvent)
		{
			if (!DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				this.frameMgr.CloseFrame<TeamMyFrame>(this, false);
			}
			else
			{
				this.UpdateMemberInfo();
			}
		}

		// Token: 0x06011A2A RID: 72234 RVA: 0x0052847B File Offset: 0x0052687B
		private void OnChangeLeaderSuccess(UIEvent iEvent)
		{
			this.UpdateTeamInfo();
			this.UpdateMemberInfo();
		}

		// Token: 0x06011A2B RID: 72235 RVA: 0x00528489 File Offset: 0x00526889
		private void OnTeamInfoChangeSuccess(UIEvent iEvent)
		{
			this.UpdateTeamInfo();
		}

		// Token: 0x06011A2C RID: 72236 RVA: 0x00528491 File Offset: 0x00526891
		private void OnTeamPosStateChanged(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x06011A2D RID: 72237 RVA: 0x00528499 File Offset: 0x00526899
		private void OnMemberStateChanged(UIEvent iEvent)
		{
			this.UpdateMemberInfo();
		}

		// Token: 0x06011A2E RID: 72238 RVA: 0x005284A4 File Offset: 0x005268A4
		private void OnRedPointChanged(UIEvent iEvent)
		{
			ERedPoint eredPoint = (ERedPoint)iEvent.Param1;
			if (eredPoint == ERedPoint.TeamNewRequester)
			{
				this.mNewRequestRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.TeamNewRequester));
			}
		}

		// Token: 0x06011A2F RID: 72239 RVA: 0x005284E8 File Offset: 0x005268E8
		private void OnTeamMatchStartSuccess(UIEvent uiEvent)
		{
			this.fAddUpTime = 0f;
			this.bStartMatch = true;
			if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
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
			teamMatchWaitingData.TeamDungeonTableID = (int)this.CurTeamDungeonTableID;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMatchWaitingFrame>(FrameLayer.Middle, teamMatchWaitingData, string.Empty);
		}

		// Token: 0x17001DBA RID: 7610
		// (get) Token: 0x06011A30 RID: 72240 RVA: 0x0052857D File Offset: 0x0052697D
		private uint CurTeamDungeonTableID
		{
			get
			{
				return DataManager<TeamDataManager>.GetInstance().TeamDungeonID;
			}
		}

		// Token: 0x06011A31 RID: 72241 RVA: 0x0052858C File Offset: 0x0052698C
		private void OnTeamMatchCancelSuccess(UIEvent uiEvent)
		{
			this.bStartMatch = false;
			if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
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
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMatchWaitingFrame>(null, false);
		}

		// Token: 0x06011A32 RID: 72242 RVA: 0x00528610 File Offset: 0x00526A10
		private void OnTeamTimeChanged(UIEvent uiEvent)
		{
			int time = (int)uiEvent.Param1;
			this.UpdateCountDownInfo(time);
		}

		// Token: 0x06011A33 RID: 72243 RVA: 0x00528630 File Offset: 0x00526A30
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

		// Token: 0x06011A34 RID: 72244 RVA: 0x00528690 File Offset: 0x00526A90
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

		// Token: 0x06011A35 RID: 72245 RVA: 0x005287F3 File Offset: 0x00526BF3
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06011A36 RID: 72246 RVA: 0x005287F8 File Offset: 0x00526BF8
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.bStartMatch)
			{
				if (DataManager<TeamDataManager>.GetInstance().GetMyTeam() == null)
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

		// Token: 0x06011A37 RID: 72247 RVA: 0x005288A0 File Offset: 0x00526CA0
		private void UpdateCountDownInfo(int time)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			if (myTeam == null || myTeam.members == null || myTeam.leaderInfo == null)
			{
				return;
			}
			int num = 0;
			while (num < myTeam.members.Length && num < 3)
			{
				TeamMember teamMember = myTeam.members[num];
				if (teamMember != null && teamMember.id > 0UL)
				{
					if (num < this.MemberInfoUIs.Length)
					{
						TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
						if (memberUI != null)
						{
							if (teamMember.id != myTeam.leaderInfo.id)
							{
								memberUI.countDownRoot.CustomActive(false);
							}
							else
							{
								TeamDataManager.bIsRefreshTime = true;
								memberUI.countDownRoot.CustomActive(TeamDataManager.AutomaticBackIsStart);
								if (time >= 10)
								{
									memberUI.tenImg.CustomActive(true);
									memberUI.bitsImg.CustomActive(true);
									int num2 = time / 10;
									int num3 = time % 10;
									ETCImageLoader.LoadSprite(ref memberUI.tenImg, string.Format(this.teamNumberPath, num2), true);
									ETCImageLoader.LoadSprite(ref memberUI.bitsImg, string.Format(this.teamNumberPath, num3), true);
									memberUI.tenImg.SetNativeSize();
									memberUI.bitsImg.SetNativeSize();
								}
								else
								{
									memberUI.tenImg.CustomActive(false);
									memberUI.bitsImg.CustomActive(true);
									ETCImageLoader.LoadSprite(ref memberUI.bitsImg, string.Format(this.teamNumberPath, time), true);
									memberUI.bitsImg.SetNativeSize();
								}
							}
						}
					}
				}
				num++;
			}
		}

		// Token: 0x06011A38 RID: 72248 RVA: 0x00528A48 File Offset: 0x00526E48
		private void InitVoiceChatModule()
		{
			this.SetVoiceInputBtnShow(false);
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			this.SetVoiceInputBtnShow(true);
			this.voiceChatModule = Singleton<SDKVoiceManager>.GetInstance().VoiceChatModule;
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.BindRoot(this.mTeamVoiceBtnGo, VoiceInputType.ComtalkTeam, null);
			}
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 5, Utility.FindComponent<ComFunctionInterval>(this.mTeamVoiceBtnGo, "VoiceSend", true));
		}

		// Token: 0x06011A39 RID: 72249 RVA: 0x00528ABE File Offset: 0x00526EBE
		private void UnInitVoiceChatModule()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.UnBindRoot(VoiceInputType.ComtalkTeam, this.mTeamVoiceBtn);
			}
			Singleton<ComIntervalGroup>.GetInstance().UnRegister(this);
		}

		// Token: 0x06011A3A RID: 72250 RVA: 0x00528AF8 File Offset: 0x00526EF8
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

		// Token: 0x06011A3B RID: 72251 RVA: 0x00528B38 File Offset: 0x00526F38
		protected override void _bindExUI()
		{
			this.mMembersRoot = this.mBind.GetGameObject("MembersRoot");
			this.mTargetDengeonName = this.mBind.GetCom<Text>("TargetDengeonName");
			this.mTargetDungeonResistMagicRoot = this.mBind.GetGameObject("TargetDengeonResistMagicValueRoot");
			this.mTargetDengeonResistMagicValue = this.mBind.GetCom<Text>("TargetDengeonResistMagicValue");
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
			this.togAutoAgreeEnter = this.mBind.GetCom<Toggle>("togAutoAgreeEnter");
			if (this.togAutoAgreeEnter != null)
			{
				this.togAutoAgreeEnter.onValueChanged.RemoveAllListeners();
				this.togAutoAgreeEnter.onValueChanged.AddListener(delegate(bool bIsOn)
				{
					DataManager<TeamDataManager>.GetInstance().IsAutoAgree = bIsOn;
				});
			}
			this.goAutoAgree = this.mBind.GetGameObject("goAutoAgree");
			this.goAutoAgreeEnter = this.mBind.GetGameObject("goAutoAgreeEnter");
			this.mOnClose = this.mBind.GetCom<Button>("onClose");
			this.mOnClose.onClick.AddListener(new UnityAction(this._onOnCloseButtonClick));
			this.btSelectTarget = this.mBind.GetCom<Button>("btSelectTarget");
			if (this.btSelectTarget != null)
			{
				this.btSelectTarget.onClick.RemoveAllListeners();
				this.btSelectTarget.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamTargetSelect>(FrameLayer.Middle, null, string.Empty);
				});
			}
			this.returnPlayerBufsBk = this.mBind.GetCom<Button>("returnPlayerBufsBk");
			this.returnPlayerBufsBk.SafeAddOnClickListener(delegate
			{
				this.returnPlayerBufs.CustomActive(false);
				this.returnPlayerBufsBk.CustomActive(false);
			});
			this.togAutoReturn = this.mBind.GetCom<Toggle>("togAutoReturn");
			this.togAutoReturn.SafeAddOnValueChangedListener(delegate(bool value)
			{
				DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.HellAutoClose, (!value) ? 0 : 1);
				if (value)
				{
					Singleton<GameStatisticManager>.GetInstance().DoStartBreakThePitPillarAndReturnAutoMatically();
				}
			});
			this.goAutoReturn = this.mBind.GetGameObject("goAutoReturn");
			this.mNotCostFatigue = this.mBind.GetGameObject("NotCostFatigue");
			this.mBtNotCostFatigue = this.mBind.GetCom<Toggle>("btNotCostFatigue");
			this.mBtNotCostFatigue.SafeSetOnValueChangedListener(delegate(bool value)
			{
				if (this.bToggleInit)
				{
					this.bToggleInit = false;
					return;
				}
				if (value)
				{
					if (DataManager<TeamDataManager>.GetInstance().GetMemberNum() == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("elite_dungeon_can_not_set_toggle_state_with_one_player"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						this.mBtNotCostFatigue.SafeSetToggleOnState(false);
					}
					else
					{
						LoginToggleMsgBoxOKCancelFrame.TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType.NotCostFatigue, TR.Value("elite_dungeon_not_cost_fatigu_have_no_award"), delegate
						{
							DataManager<TeamDataManager>.GetInstance().SendSceneSaveOptionsReq(SaveOptionMask.SOM_NOT_COUSUME_EBERGY, true);
						}, delegate
						{
							this.mBtNotCostFatigue.SafeSetToggleOnState(false);
						}, string.Empty, string.Empty);
					}
				}
				else
				{
					DataManager<TeamDataManager>.GetInstance().SendSceneSaveOptionsReq(SaveOptionMask.SOM_NOT_COUSUME_EBERGY, false);
				}
			});
		}

		// Token: 0x06011A3C RID: 72252 RVA: 0x00528FFC File Offset: 0x005273FC
		protected override void _unbindExUI()
		{
			this.mMembersRoot = null;
			this.mTargetDengeonName = null;
			this.mTargetDungeonResistMagicRoot = null;
			this.mTargetDengeonResistMagicValue = null;
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
			this.togAutoAgreeEnter = null;
			this.goAutoAgree = null;
			this.goAutoAgreeEnter = null;
			this.btSelectTarget = null;
			this.returnPlayerBufsBk = null;
			this.togAutoReturn = null;
			this.goAutoReturn = null;
			this.mNotCostFatigue = null;
			this.mBtNotCostFatigue = null;
		}

		// Token: 0x06011A3D RID: 72253 RVA: 0x005291D8 File Offset: 0x005275D8
		private bool IsHellTeamDungeonID(int iTeamDungeonID)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(iTeamDungeonID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return false;
			}
			if (tableItem2.SubType != DungeonTable.eSubType.S_HELL_ENTRY)
			{
				return false;
			}
			int playerMaxLv = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			int[] array = new int[]
			{
				30,
				50,
				55,
				60,
				0
			};
			if (array == null)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (tableItem2.Level == array[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06011A3E RID: 72254 RVA: 0x00529288 File Offset: 0x00527688
		private void UpdateAutoReturnFromHellUI()
		{
			this.goAutoReturn.CustomActive(this.IsHellTeamDungeonID((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID));
			this.togAutoReturn.SafeSetToggleOnState(DataManager<TeamDataManager>.GetInstance().IsAutoReturnFormHell);
			if (this.togAutoReturn != null)
			{
				UIGray uigray = this.togAutoReturn.gameObject.SafeAddComponent(false);
				if (uigray != null)
				{
					uigray.SetEnable(false);
					uigray.SetEnable(!DataManager<TeamDataManager>.GetInstance().IsTeamLeader());
				}
				this.togAutoReturn.interactable = DataManager<TeamDataManager>.GetInstance().IsTeamLeader();
				this.togAutoReturn.image.raycastTarget = DataManager<TeamDataManager>.GetInstance().IsTeamLeader();
			}
		}

		// Token: 0x06011A3F RID: 72255 RVA: 0x00529340 File Offset: 0x00527740
		private void UpdateEliteNotCostFatigueUI()
		{
			this.mNotCostFatigue.CustomActive(TeamUtility.IsEliteTeamDungeonID((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID));
			this.mBtNotCostFatigue.SafeSetToggleOnState(DataManager<TeamDataManager>.GetInstance().IsNotCostFatigueInEliteDungeon);
			this.bToggleInit = false;
			this.mBtNotCostFatigue.SafeSetGray(DataManager<TeamDataManager>.GetInstance().GetMemberNum() == 0, false);
		}

		// Token: 0x06011A40 RID: 72256 RVA: 0x0052939C File Offset: 0x0052779C
		private void _onBtAutoAgreeToggleValueChange(bool changed)
		{
			this.OnAutoAgreeClicked(changed);
		}

		// Token: 0x06011A41 RID: 72257 RVA: 0x005293A5 File Offset: 0x005277A5
		private void _onOnCloseButtonClick()
		{
			this.OnClickClose();
		}

		// Token: 0x06011A42 RID: 72258 RVA: 0x005293AD File Offset: 0x005277AD
		private void _onOnExitButtonClick()
		{
			this.OnExitTeamBtnClicked();
		}

		// Token: 0x06011A43 RID: 72259 RVA: 0x005293B5 File Offset: 0x005277B5
		private void _onOnInviteButtonClick()
		{
			this.OnLeaderInvite();
		}

		// Token: 0x06011A44 RID: 72260 RVA: 0x005293BD File Offset: 0x005277BD
		private void _onOnReqestListButtonClick()
		{
			this.OnRequestListClicked();
		}

		// Token: 0x06011A45 RID: 72261 RVA: 0x005293C5 File Offset: 0x005277C5
		private void _onOnMatchButtonClick()
		{
			this.OnMatchDugeon();
		}

		// Token: 0x06011A46 RID: 72262 RVA: 0x005293CD File Offset: 0x005277CD
		private void _onOnEnterDungeonButtonClick()
		{
			this.OnEnterDungeon();
		}

		// Token: 0x06011A47 RID: 72263 RVA: 0x005293D5 File Offset: 0x005277D5
		private void _onOnHelpFightStatusToggleValueChange(bool changed)
		{
		}

		// Token: 0x06011A48 RID: 72264 RVA: 0x005293D7 File Offset: 0x005277D7
		private void _onOnHelpFightButtonClick()
		{
			this._onChangeAssisStatus();
		}

		// Token: 0x06011A49 RID: 72265 RVA: 0x005293DF File Offset: 0x005277DF
		private void _onOnTeamTalkButtonClick()
		{
			this._onTeamChat();
		}

		// Token: 0x06011A4A RID: 72266 RVA: 0x005293E8 File Offset: 0x005277E8
		private void _InitFatigueCombustionRoot()
		{
			int num = this._GetRoleIDIndex();
			if (num >= this.MemberInfoUIs.Length || num < 0)
			{
				Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
				if (myTeam == null)
				{
					Logger.LogErrorFormat("GetMyTeam is not exist!", new object[0]);
					return;
				}
				string text = string.Empty;
				int num2 = 0;
				while (num2 < myTeam.members.Length && num2 < 3)
				{
					TeamMember teamMember = myTeam.members[num2];
					text = text + teamMember.id.ToString() + ";";
					num2++;
				}
				Logger.LogErrorFormat("Can not find roleid {0} is not exist {1}!", new object[]
				{
					DataManager<PlayerBaseData>.GetInstance().RoleID,
					text
				});
				return;
			}
			else
			{
				TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
				if (memberUI == null)
				{
					return;
				}
				this._InitFatigueCombustionGameObject(memberUI.mFatigueCombustionRoot);
				return;
			}
		}

		// Token: 0x06011A4B RID: 72267 RVA: 0x005294C8 File Offset: 0x005278C8
		private void _InitFatigueCombustionGameObject(GameObject mFatigueCombustionRoot)
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.FindFatigueCombustionActivityIsOpen(ref this.mBisFlag, ref this.data);
			if (this.mBisFlag && this.data != null)
			{
				mFatigueCombustionRoot.CustomActive(true);
				this._InitFatigueCombustionInfo(mFatigueCombustionRoot, this.data);
			}
			else
			{
				mFatigueCombustionRoot.CustomActive(false);
			}
		}

		// Token: 0x06011A4C RID: 72268 RVA: 0x00529528 File Offset: 0x00527928
		private void _InitFatigueCombustionInfo(GameObject go, ActivityLimitTimeData activityData)
		{
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			uint activityId = activityData.DataId;
			Text com = component.GetCom<Text>("Time");
			Button com2 = component.GetCom<Button>("Open");
			Button com3 = component.GetCom<Button>("Stop");
			GameObject gameObject = component.GetGameObject("OrdinaryName");
			GameObject gameObject2 = component.GetGameObject("SeniorName");
			SetButtonGrayCD mCDGray = component.GetCom<SetButtonGrayCD>("CDGray");
			gameObject.CustomActive(false);
			gameObject2.CustomActive(false);
			for (int i = 0; i < activityData.activityDetailDataList.Count; i++)
			{
				if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Init && activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.UnFinish)
				{
					this.mData = activityData.activityDetailDataList[i];
					uint mTaskId = this.mData.DataId;
					string text = mTaskId.ToString();
					string s = text.Substring(text.Length - 1);
					int num = 0;
					if (int.TryParse(s, out num))
					{
						if (num == 1)
						{
							gameObject.CustomActive(true);
							gameObject2.CustomActive(false);
						}
						else
						{
							gameObject2.CustomActive(true);
							gameObject.CustomActive(false);
						}
					}
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					com3.onClick.RemoveAllListeners();
					com3.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					this._UpdateFatigueCombustionData(go, this.mData);
					if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Failed)
					{
						return;
					}
				}
			}
		}

		// Token: 0x06011A4D RID: 72269 RVA: 0x00529718 File Offset: 0x00527B18
		private void _UpdateFatigueCombustionData(GameObject go, ActivityLimitTimeDetailData activityData)
		{
			if (go == null || activityData == null)
			{
				return;
			}
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mTime = component.GetCom<Text>("Time");
			Button com = component.GetCom<Button>("Open");
			Button com2 = component.GetCom<Button>("Stop");
			com.CustomActive(false);
			com2.CustomActive(false);
			this.mFatigueCombustionTimeIsOpen = false;
			switch (activityData.ActivityDetailState)
			{
			case ActivityTaskState.Init:
			case ActivityTaskState.UnFinish:
				com.CustomActive(true);
				this.mTime.text = Function.GetLastsTimeStr((double)this.mData.DoneNum);
				break;
			case ActivityTaskState.Finished:
				com2.CustomActive(true);
				this.mFatigueCombustionTimeIsOpen = true;
				this.mFatigueCombustionTime = this.mData.DoneNum;
				break;
			case ActivityTaskState.Failed:
				this.mTime.text = Function.GetLastsTimeStr((double)this.mData.DoneNum);
				com.CustomActive(true);
				break;
			}
		}

		// Token: 0x06011A4E RID: 72270 RVA: 0x00529820 File Offset: 0x00527C20
		private void _SetFatigueCombustionTime()
		{
			if (this.mFatigueCombustionTimeIsOpen && this.mTime != null)
			{
				if (this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
				{
					this.mTime.text = Function.GetLastsTimeStr((double)(this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime()));
				}
				else
				{
					int num = this._GetRoleIDIndex();
					TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
					if (memberUI == null)
					{
						return;
					}
					memberUI.mFatigueCombustionRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x06011A4F RID: 72271 RVA: 0x005298AC File Offset: 0x00527CAC
		private void _OnTaskChange()
		{
			int num = this._GetRoleIDIndex();
			TeamMyFrame.MemberUI memberUI = this.MemberInfoUIs[num];
			if (memberUI == null)
			{
				return;
			}
			this._UpdateFatigueCombustionData(memberUI.mFatigueCombustionRoot, this.mData);
		}

		// Token: 0x06011A50 RID: 72272 RVA: 0x005298E4 File Offset: 0x00527CE4
		private int _GetRoleIDIndex()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return -1;
			}
			int num = 0;
			while (num < myTeam.members.Length && num < 3)
			{
				TeamMember teamMember = myTeam.members[num];
				if (teamMember != null && teamMember.id > 0UL)
				{
					if (num < this.MemberInfoUIs.Length)
					{
						if (teamMember.id == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							return num;
						}
					}
				}
				num++;
			}
			return -1;
		}

		// Token: 0x0400B795 RID: 46997
		private int[] ModelLayers = new int[]
		{
			15,
			16,
			17
		};

		// Token: 0x0400B796 RID: 46998
		private bool mBisFlag;

		// Token: 0x0400B797 RID: 46999
		private ActivityLimitTimeData data;

		// Token: 0x0400B798 RID: 47000
		private ActivityLimitTimeDetailData mData;

		// Token: 0x0400B799 RID: 47001
		private bool mFatigueCombustionTimeIsOpen;

		// Token: 0x0400B79A RID: 47002
		private Text mTime;

		// Token: 0x0400B79B RID: 47003
		private int mFatigueCombustionTime = -1;

		// Token: 0x0400B79C RID: 47004
		private const int returnPlayerBufCount = 3;

		// Token: 0x0400B79D RID: 47005
		private const int TeamMemberNum = 3;

		// Token: 0x0400B79E RID: 47006
		private bool bStartMatch;

		// Token: 0x0400B79F RID: 47007
		private float fAddUpTime;

		// Token: 0x0400B7A0 RID: 47008
		private TeamMyFrame.MemberUI[] MemberInfoUIs = new TeamMyFrame.MemberUI[3];

		// Token: 0x0400B7A1 RID: 47009
		private List<int> FliterFirstMenuList = new List<int>();

		// Token: 0x0400B7A2 RID: 47010
		private Dictionary<int, List<int>> FliterSecondMenuDict = new Dictionary<int, List<int>>();

		// Token: 0x0400B7A3 RID: 47011
		private bool bToggleInit;

		// Token: 0x0400B7A4 RID: 47012
		[UIControl("root/ChannelSelect", typeof(MyDropDown), 0)]
		private MyDropDown m_dropDown;

		// Token: 0x0400B7A5 RID: 47013
		[UIObject("root/ChannelSelect")]
		private GameObject m_goLeader;

		// Token: 0x0400B7A6 RID: 47014
		private bool mIsSendMessage;

		// Token: 0x0400B7A7 RID: 47015
		private string teamNumberPath = "UI/Image/Packed/p_UI_Team.png:UI_Team_Text_04_{0}";

		// Token: 0x0400B7A8 RID: 47016
		private VoiceChatModule voiceChatModule;

		// Token: 0x0400B7A9 RID: 47017
		private GameObject mMembersRoot;

		// Token: 0x0400B7AA RID: 47018
		private Text mTargetDengeonName;

		// Token: 0x0400B7AB RID: 47019
		private GameObject mTargetDungeonResistMagicRoot;

		// Token: 0x0400B7AC RID: 47020
		private Text mTargetDengeonResistMagicValue;

		// Token: 0x0400B7AD RID: 47021
		private GameObject mFuncs;

		// Token: 0x0400B7AE RID: 47022
		private Toggle mBtAutoAgree;

		// Token: 0x0400B7AF RID: 47023
		private Image mNewRequestRedPoint;

		// Token: 0x0400B7B0 RID: 47024
		private Text mMatchText;

		// Token: 0x0400B7B1 RID: 47025
		private ComCommonBind mBtBuyNum;

		// Token: 0x0400B7B2 RID: 47026
		private Text mLeaderInviteText;

		// Token: 0x0400B7B3 RID: 47027
		private Button mOnExit;

		// Token: 0x0400B7B4 RID: 47028
		private Button mOnInvite;

		// Token: 0x0400B7B5 RID: 47029
		private Button mOnReqestList;

		// Token: 0x0400B7B6 RID: 47030
		private Button mOnMatch;

		// Token: 0x0400B7B7 RID: 47031
		private Button mOnEnterDungeon;

		// Token: 0x0400B7B8 RID: 47032
		private Toggle mOnHelpFightStatus;

		// Token: 0x0400B7B9 RID: 47033
		private Button mOnHelpFight;

		// Token: 0x0400B7BA RID: 47034
		private Button mOnTeamTalk;

		// Token: 0x0400B7BB RID: 47035
		private GameObject mHelpFightRoot;

		// Token: 0x0400B7BC RID: 47036
		private VoiceInputBtn mTeamVoiceBtn;

		// Token: 0x0400B7BD RID: 47037
		private GameObject mTeamVoiceBtnGo;

		// Token: 0x0400B7BE RID: 47038
		private Toggle togAutoAgreeEnter;

		// Token: 0x0400B7BF RID: 47039
		private GameObject goAutoAgree;

		// Token: 0x0400B7C0 RID: 47040
		private GameObject goAutoAgreeEnter;

		// Token: 0x0400B7C1 RID: 47041
		private Button mOnClose;

		// Token: 0x0400B7C2 RID: 47042
		private Button btSelectTarget;

		// Token: 0x0400B7C3 RID: 47043
		private Button returnPlayerBufsBk;

		// Token: 0x0400B7C4 RID: 47044
		private GameObject returnPlayerBufs;

		// Token: 0x0400B7C5 RID: 47045
		private Toggle togAutoReturn;

		// Token: 0x0400B7C6 RID: 47046
		private GameObject goAutoReturn;

		// Token: 0x0400B7C7 RID: 47047
		private GameObject mNotCostFatigue;

		// Token: 0x0400B7C8 RID: 47048
		private Toggle mBtNotCostFatigue;

		// Token: 0x02001C1B RID: 7195
		public class MemberUI
		{
			// Token: 0x06011A5C RID: 72284 RVA: 0x00529AEC File Offset: 0x00527EEC
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

			// Token: 0x06011A5D RID: 72285 RVA: 0x00529B40 File Offset: 0x00527F40
			public void SetFlag(eTeammateFlag relation)
			{
				if (null == this.bind)
				{
					return;
				}
				GameObject gameObject = this.bind.GetGameObject("friendstatus");
				GameObject gameObject2 = this.bind.GetGameObject("guildstatus");
				GameObject gameObject3 = this.bind.GetGameObject("helpfightstatus");
				GameObject gameObject4 = this.bind.GetGameObject("masterstatus");
				GameObject gameObject5 = this.bind.GetGameObject("disciplestatus");
				gameObject.SetActive(false);
				gameObject2.SetActive(false);
				gameObject3.SetActive(false);
				gameObject4.SetActive(false);
				gameObject5.SetActive(false);
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
				if ((relation & eTeammateFlag.Master) != eTeammateFlag.None)
				{
					gameObject4.SetActive(true);
				}
				if ((relation & eTeammateFlag.Disciple) != eTeammateFlag.None)
				{
					gameObject5.SetActive(true);
				}
			}

			// Token: 0x06011A5E RID: 72286 RVA: 0x00529C28 File Offset: 0x00528028
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
				Image com2 = this.bind.GetCom<Image>("vipLevel2");
				Image com3 = this.bind.GetCom<Image>("vipLevel1");
				if (com3)
				{
					com3.gameObject.CustomActive(true);
				}
				if (com2)
				{
					com2.gameObject.CustomActive(level >= 10);
				}
				if (level < 10)
				{
					ETCImageLoader.LoadSprite(ref com3, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", level), true);
				}
				else
				{
					ETCImageLoader.LoadSprite(ref com2, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", level % 10), true);
					ETCImageLoader.LoadSprite(ref com3, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", level / 10), true);
				}
			}

			// Token: 0x0400B7CF RID: 47055
			public ulong memberID;

			// Token: 0x0400B7D0 RID: 47056
			public ComCommonBind bind;

			// Token: 0x0400B7D1 RID: 47057
			public GameObject contentRoot;

			// Token: 0x0400B7D2 RID: 47058
			public Text Level;

			// Token: 0x0400B7D3 RID: 47059
			public Text Job;

			// Token: 0x0400B7D4 RID: 47060
			public Image leaderMark;

			// Token: 0x0400B7D5 RID: 47061
			public Text memberName;

			// Token: 0x0400B7D6 RID: 47062
			public GameObject resistMagicRoot;

			// Token: 0x0400B7D7 RID: 47063
			public Text resistMagicValue;

			// Token: 0x0400B7D8 RID: 47064
			public Button AddMemberMark;

			// Token: 0x0400B7D9 RID: 47065
			public Button showMenu;

			// Token: 0x0400B7DA RID: 47066
			public GameObject modelRoot;

			// Token: 0x0400B7DB RID: 47067
			public GeAvatarRendererEx avatarRenderer;

			// Token: 0x0400B7DC RID: 47068
			public GameObject mFatigueCombustionRoot;

			// Token: 0x0400B7DD RID: 47069
			public Button rewardPreview;

			// Token: 0x0400B7DE RID: 47070
			public Button searchBtn;

			// Token: 0x0400B7DF RID: 47071
			public GameObject countDownRoot;

			// Token: 0x0400B7E0 RID: 47072
			public Image tenImg;

			// Token: 0x0400B7E1 RID: 47073
			public Image bitsImg;

			// Token: 0x0400B7E2 RID: 47074
			public const string ICON_VIP_RES_PATH_FORMAT = "UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}";

			// Token: 0x0400B7E3 RID: 47075
			private const string VIP_DES_ELEMENT_PATH = "UIFlatten/Prefabs/Vip/VipElement";
		}
	}
}
