using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C11 RID: 7185
	internal class TeamMainFrame : ClientFrame
	{
		// Token: 0x060119A7 RID: 72103 RVA: 0x0052496E File Offset: 0x00522D6E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamMain";
		}

		// Token: 0x060119A8 RID: 72104 RVA: 0x00524975 File Offset: 0x00522D75
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			this.requestListObj = new object();
		}

		// Token: 0x060119A9 RID: 72105 RVA: 0x0052498E File Offset: 0x00522D8E
		protected override void _OnCloseFrame()
		{
			this.Clear();
			InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
			this.requestListObj = null;
		}

		// Token: 0x060119AA RID: 72106 RVA: 0x005249A8 File Offset: 0x00522DA8
		private new void Clear()
		{
			this.TeamDatas.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x060119AB RID: 72107 RVA: 0x005249BC File Offset: 0x00522DBC
		protected override void _bindExUI()
		{
			this.btGuildDungeonTeamList = this.mBind.GetCom<Toggle>("btGuildDungeonTeamList");
			this.btGuildDungeonTeamList.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					this.myTeamPlayers.CustomActive(false);
					this.guildDungeonTeams.CustomActive(true);
					this._RequestGuildDungeonTeamList();
					InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
					InvokeMethod.InvokeInterval(this.requestListObj, 0f, 5f, float.MaxValue, null, new UnityAction(this._RequestGuildDungeonTeamList), null);
				}
			});
			this.btTeamList = this.mBind.GetCom<Toggle>("btTeamList");
			this.btTeamList.SafeAddOnValueChangedListener(delegate(bool value)
			{
				if (value)
				{
					this._OnClickTeamList();
				}
			});
			this.myTeamPlayers = this.mBind.GetGameObject("myTeamPlayers");
			this.guildDungeonTeams = this.mBind.GetGameObject("guildDungeonTeams");
			this.teamListParent = this.mBind.GetGameObject("teamListParent");
			this.teamItemTemplate = this.mBind.GetGameObject("teamItemTemplate");
		}

		// Token: 0x060119AC RID: 72108 RVA: 0x00524A7B File Offset: 0x00522E7B
		protected override void _unbindExUI()
		{
			this.btGuildDungeonTeamList = null;
			this.btTeamList = null;
			this.myTeamPlayers = null;
			this.guildDungeonTeams = null;
			this.teamListParent = null;
			this.teamItemTemplate = null;
		}

		// Token: 0x060119AD RID: 72109 RVA: 0x00524AA8 File Offset: 0x00522EA8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamChangeLeaderSuccess, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMemberStateChanged, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamListRequestSuccessForTeamMainUI, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
		}

		// Token: 0x060119AE RID: 72110 RVA: 0x00524B3C File Offset: 0x00522F3C
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamAddMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnAddMemberSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamChangeLeaderSuccess, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMemberStateChanged, new ClientEventSystem.UIEventHandler(this.OnChangeLeaderSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamListRequestSuccessForTeamMainUI, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
		}

		// Token: 0x060119AF RID: 72111 RVA: 0x00524BD0 File Offset: 0x00522FD0
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060119B0 RID: 72112 RVA: 0x00524BD3 File Offset: 0x00522FD3
		protected override void _OnUpdate(float timeElapsed)
		{
			this.btTeamList.CustomActive(Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildArenaFrame>(null));
			this.btGuildDungeonTeamList.CustomActive(Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildArenaFrame>(null));
		}

		// Token: 0x060119B1 RID: 72113 RVA: 0x00524C01 File Offset: 0x00523001
		private void _RequestGuildDungeonTeamList()
		{
			DataManager<TeamDataManager>.GetInstance().RequestTeamListForTeamMainUI(0, DataManager<TeamDataManager>.GetInstance().nTeamGuildDungeonID);
		}

		// Token: 0x060119B2 RID: 72114 RVA: 0x00524C18 File Offset: 0x00523018
		private void _UpdateGuildDungeonTeamList()
		{
			if (this.guildDungeonTeams == null)
			{
				return;
			}
			if (!this.guildDungeonTeams.activeInHierarchy)
			{
				return;
			}
			if (this.teamListParent != null && this.teamItemTemplate != null)
			{
				List<Team> teamListForTeamMainUI = DataManager<TeamDataManager>.GetInstance().GetTeamListForTeamMainUI();
				int num = 0;
				for (int i = 0; i < this.teamListParent.transform.childCount; i++)
				{
					GameObject gameObject = this.teamListParent.transform.GetChild(i).gameObject;
					Object.Destroy(gameObject);
				}
				int num2 = 0;
				while (num2 < teamListForTeamMainUI.Count && num < 10)
				{
					Team team = teamListForTeamMainUI[num2];
					if (team != null)
					{
						if (team.currentMemberCount < team.maxMemberCount)
						{
							GameObject gameObject2 = Object.Instantiate<GameObject>(this.teamItemTemplate.gameObject);
							Utility.AttachTo(gameObject2, this.teamListParent, false);
							gameObject2.CustomActive(true);
							ComCommonBind component = gameObject2.GetComponent<ComCommonBind>();
							if (component != null)
							{
								StaticUtility.SafeSetText(component, "leader", team.leaderInfo.name);
								StaticUtility.SafeSetText(component, "count", string.Format("{0}/{1}", team.currentMemberCount, team.maxMemberCount));
								StaticUtility.SafeSetText(component, "target", TeamDataManager.GetTeamDungeonName(team.teamDungeonID));
								ulong iTeamID = teamListForTeamMainUI[num2].leaderInfo.id;
								StaticUtility.SafeSetBtnCallBack(component, "join", delegate
								{
									this.OnClickJoinTeam(iTeamID);
								});
							}
							num++;
						}
					}
					num2++;
				}
			}
		}

		// Token: 0x060119B3 RID: 72115 RVA: 0x00524DE8 File Offset: 0x005231E8
		private void OnClickJoinTeam(ulong iTeamID)
		{
			int num = -1;
			List<Team> teamListForTeamMainUI = DataManager<TeamDataManager>.GetInstance().GetTeamListForTeamMainUI();
			for (int i = 0; i < teamListForTeamMainUI.Count; i++)
			{
				if (iTeamID == teamListForTeamMainUI[i].leaderInfo.id)
				{
					num = i;
					break;
				}
			}
			if (num < 0 || teamListForTeamMainUI == null || num >= teamListForTeamMainUI.Count)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_already_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num2 = -1;
			Team team = teamListForTeamMainUI[num];
			if (!Utility.CheckTeamCondition((int)team.teamDungeonID, ref num2))
			{
				if (num2 != -1)
				{
					SystemNotifyManager.SystemNotify(num2, string.Empty);
				}
				return;
			}
			if (teamListForTeamMainUI[num].currentMemberCount >= teamListForTeamMainUI[num].maxMemberCount)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("队伍人数已满", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDataManager>.GetInstance().JoinTeam(teamListForTeamMainUI[num].leaderInfo.id);
		}

		// Token: 0x060119B4 RID: 72116 RVA: 0x00524EE8 File Offset: 0x005232E8
		[UIEventHandle("myTeamPlayers/btQuit")]
		private void OnQuit()
		{
			DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList = true;
			DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
		}

		// Token: 0x060119B5 RID: 72117 RVA: 0x00524F0C File Offset: 0x0052330C
		[UIEventHandle("myTeamPlayers/Player{0}/Icon", typeof(Button), typeof(UnityAction<int>), 1, 3)]
		private void OnClickMember(int iIndex)
		{
			if (iIndex < 0)
			{
				return;
			}
			if (this.TeamDatas == null || this.TeamDatas.Count <= 0 || iIndex >= this.TeamDatas.Count)
			{
				return;
			}
			if (this.TeamDatas[iIndex].id == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			TeamMenuData teamMenuData = new TeamMenuData();
			teamMenuData.index = (byte)iIndex;
			teamMenuData.memberID = this.TeamDatas[iIndex].id;
			teamMenuData.name = this.TeamDatas[iIndex].name;
			teamMenuData.occu = this.TeamDatas[iIndex].occu;
			teamMenuData.level = this.TeamDatas[iIndex].level;
			teamMenuData.Pos = default(Vector3);
			if (this.frameMgr.IsFrameOpen<TeamMemberMenuFrame>(null))
			{
				this.frameMgr.CloseFrame<TeamMemberMenuFrame>(null, false);
			}
			this.frameMgr.OpenFrame<TeamMemberMenuFrame>(FrameLayer.Middle, teamMenuData, string.Empty);
		}

		// Token: 0x060119B6 RID: 72118 RVA: 0x0052501A File Offset: 0x0052341A
		[UIEventHandle("myTeamPlayers/Player{0}/btOpenTeamMy", typeof(Button), typeof(UnityAction<int>), 1, 3)]
		private void OnOpenTeamMy(int iIndex)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060119B7 RID: 72119 RVA: 0x0052502E File Offset: 0x0052342E
		private void _OnClickTeamList()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
			this.myTeamPlayers.CustomActive(true);
			this.guildDungeonTeams.CustomActive(false);
			InvokeMethod.RmoveInvokeIntervalCall(this.requestListObj);
		}

		// Token: 0x060119B8 RID: 72120 RVA: 0x00525065 File Offset: 0x00523465
		private void InitInterface()
		{
			this.UpdateInterface();
		}

		// Token: 0x060119B9 RID: 72121 RVA: 0x00525070 File Offset: 0x00523470
		private void UpdateInterface()
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			this.TeamDatas.Clear();
			int num = 0;
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				if (myTeam.members[i].id > 0UL)
				{
					TeamMember item = new TeamMember();
					item = myTeam.members[i];
					this.TeamDatas.Add(item);
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)myTeam.members[i].occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref this.Icons[num], tableItem2.IconPath, true);
						}
					}
					this.MemberNames[num].text = myTeam.members[i].name;
					RelationData relationData = null;
					DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(myTeam.members[i].id, ref relationData);
					if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
					{
						this.MemberNames[num].text = relationData.remark;
					}
					this.Levels[num].text = string.Format("Lv.{0}", myTeam.members[i].level);
					if (myTeam.leaderInfo.id == myTeam.members[i].id)
					{
						this.LeaderMarks[num].gameObject.SetActive(true);
					}
					else
					{
						this.LeaderMarks[num].gameObject.SetActive(false);
					}
					this.Players[num].gameObject.SetActive(true);
					num++;
				}
			}
			for (int j = num; j < 3; j++)
			{
				this.Players[j].gameObject.SetActive(false);
			}
		}

		// Token: 0x060119BA RID: 72122 RVA: 0x00525277 File Offset: 0x00523677
		private void OnAddMemberSuccess(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x060119BB RID: 72123 RVA: 0x0052527F File Offset: 0x0052367F
		private void OnChangeLeaderSuccess(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x060119BC RID: 72124 RVA: 0x00525287 File Offset: 0x00523687
		private void OnSetNoteNameSuccess(UIEvent iEvent)
		{
			this.UpdateInterface();
		}

		// Token: 0x060119BD RID: 72125 RVA: 0x0052528F File Offset: 0x0052368F
		private void OnTeamListRequestSuccess(UIEvent uiEvent)
		{
			this._UpdateGuildDungeonTeamList();
		}

		// Token: 0x0400B752 RID: 46930
		private const int MemberNum = 3;

		// Token: 0x0400B753 RID: 46931
		private List<TeamMember> TeamDatas = new List<TeamMember>();

		// Token: 0x0400B754 RID: 46932
		private const int maxListCount = 10;

		// Token: 0x0400B755 RID: 46933
		private object requestListObj;

		// Token: 0x0400B756 RID: 46934
		private const float fRequestInterval = 5f;

		// Token: 0x0400B757 RID: 46935
		private Toggle btGuildDungeonTeamList;

		// Token: 0x0400B758 RID: 46936
		private Toggle btTeamList;

		// Token: 0x0400B759 RID: 46937
		private GameObject myTeamPlayers;

		// Token: 0x0400B75A RID: 46938
		private GameObject guildDungeonTeams;

		// Token: 0x0400B75B RID: 46939
		private GameObject teamListParent;

		// Token: 0x0400B75C RID: 46940
		private GameObject teamItemTemplate;

		// Token: 0x0400B75D RID: 46941
		[UIControl("myTeamPlayers/Player{0}", typeof(Image), 1)]
		protected Image[] Players = new Image[3];

		// Token: 0x0400B75E RID: 46942
		[UIControl("myTeamPlayers/Player{0}/Icon", typeof(Image), 1)]
		protected Image[] Icons = new Image[3];

		// Token: 0x0400B75F RID: 46943
		[UIControl("myTeamPlayers/Player{0}/Name", typeof(Text), 1)]
		protected Text[] MemberNames = new Text[3];

		// Token: 0x0400B760 RID: 46944
		[UIControl("myTeamPlayers/Player{0}/Level", typeof(Text), 1)]
		protected Text[] Levels = new Text[3];

		// Token: 0x0400B761 RID: 46945
		[UIControl("myTeamPlayers/Player{0}/LeaderMark", typeof(Image), 1)]
		protected Image[] LeaderMarks = new Image[3];

		// Token: 0x0400B762 RID: 46946
		[UIControl("myTeamPlayers/Player{0}/HP/Text", typeof(Text), 1)]
		protected Text[] HPTexts = new Text[3];

		// Token: 0x0400B763 RID: 46947
		[UIControl("myTeamPlayers/Player{0}/MP/Text", typeof(Text), 1)]
		protected Text[] MPTexts = new Text[3];

		// Token: 0x0400B764 RID: 46948
		[UIControl("myTeamPlayers/btQuit", null, 0)]
		protected Button btQuit;
	}
}
