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
	// Token: 0x02001C0F RID: 7183
	internal class TeamListViewFrame : ClientFrame
	{
		// Token: 0x17001DB9 RID: 7609
		// (get) Token: 0x0601198A RID: 72074 RVA: 0x0052325B File Offset: 0x0052165B
		private int CurTeamDungeonTableID
		{
			get
			{
				return (int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID;
			}
		}

		// Token: 0x0601198B RID: 72075 RVA: 0x00523267 File Offset: 0x00521667
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamListView";
		}

		// Token: 0x0601198C RID: 72076 RVA: 0x0052326E File Offset: 0x0052166E
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.mRefreshTime = 10f;
			this.FliterSecondMenuDict.Clear();
			this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
		}

		// Token: 0x0601198D RID: 72077 RVA: 0x0052329D File Offset: 0x0052169D
		protected override void _OnCloseFrame()
		{
			this.Clear();
		}

		// Token: 0x0601198E RID: 72078 RVA: 0x005232A5 File Offset: 0x005216A5
		private new void Clear()
		{
			this.mRefreshTime = 10f;
			this.bStartMatch = false;
			this.fAddUpTime = 0f;
			this.TeamListUI.Clear();
			this.TeamListObj.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x0601198F RID: 72079 RVA: 0x005232E0 File Offset: 0x005216E0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamListRequestSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchStartSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchCancelSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamListUpdateByHard, new ClientEventSystem.UIEventHandler(this.OnUdpateTeamListByHard));
		}

		// Token: 0x06011990 RID: 72080 RVA: 0x0052335C File Offset: 0x0052175C
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamListRequestSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamListRequestSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMatchStartSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchStartSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this.OnTeamMatchCancelSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamListUpdateByHard, new ClientEventSystem.UIEventHandler(this.OnUdpateTeamListByHard));
		}

		// Token: 0x06011991 RID: 72081 RVA: 0x005233D8 File Offset: 0x005217D8
		private void OnClickJoinTeam(ulong iTeamID)
		{
			int num = -1;
			List<Team> teamList = DataManager<TeamDataManager>.GetInstance().GetTeamList();
			for (int i = 0; i < teamList.Count; i++)
			{
				if (iTeamID == teamList[i].leaderInfo.id)
				{
					num = i;
					break;
				}
			}
			if (num < 0 || teamList == null || num >= teamList.Count)
			{
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_already_has_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			int num2 = -1;
			DungeonID dungeonID = new DungeonID((int)teamList[num].leaderInfo.id);
			if (!Utility.CheckJoinTeamCondition((ulong)((long)dungeonID.dungeonIDWithOutDiff), ref num2))
			{
				if (num2 != -1)
				{
					SystemNotifyManager.SystemNotify(num2, string.Empty);
				}
				return;
			}
			if (teamList[num].currentMemberCount >= teamList[num].maxMemberCount)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("队伍人数已满", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDataManager>.GetInstance().JoinTeam(teamList[num].leaderInfo.id);
		}

		// Token: 0x06011992 RID: 72082 RVA: 0x005234EC File Offset: 0x005218EC
		private void OnMatch()
		{
			NetManager netManager = NetManager.Instance();
			if (!this.bStartMatch)
			{
				TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
				if (tableItem == null || tableItem.Type == TeamDungeonTable.eType.MENU || this.CurTeamDungeonTableID == 1)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("请选择一个关卡目标", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				SceneTeamMatchStartReq sceneTeamMatchStartReq = new SceneTeamMatchStartReq();
				sceneTeamMatchStartReq.dungeonId = (uint)tableItem.DungeonID;
				TeamListFrame teamListFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamListFrame)) as TeamListFrame;
				if (teamListFrame == null)
				{
					return;
				}
				int diffHard = DataManager<TeamDataManager>.GetInstance().DiffHard;
				if (diffHard == -1)
				{
					return;
				}
				if (diffHard >= teamListFrame.locks.Count)
				{
					return;
				}
				if (teamListFrame.locks[diffHard].activeInHierarchy)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("关卡未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				Dictionary<string, DiffInfo> secteamDungeons = teamListFrame.secteamDungeons;
				int id = this.CurTeamDungeonTableID;
				TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
					if (tableItem3 == null)
					{
						if (tableItem2.Type == TeamDungeonTable.eType.CityMonster)
						{
							id = this.CurTeamDungeonTableID;
							if (diffHard != 0)
							{
								return;
							}
						}
					}
					else
					{
						DiffInfo diffInfo = new DiffInfo();
						secteamDungeons.TryGetValue(tableItem3.Name, out diffInfo);
						if (diffInfo != null)
						{
							for (int i = 0; i < diffInfo.secteamDungeonID.Count; i++)
							{
								TeamDungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(diffInfo.secteamDungeonID[i], string.Empty, string.Empty);
								if (tableItem4 != null)
								{
									DungeonTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem4.DungeonID, string.Empty, string.Empty);
									if (tableItem5 != null)
									{
										if (tableItem5.Hard == (DungeonTable.eHard)diffHard)
										{
											id = diffInfo.secteamDungeonID[i];
											break;
										}
									}
								}
							}
						}
					}
				}
				TeamDungeonTable tableItem6 = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(id, string.Empty, string.Empty);
				if (tableItem6 != null)
				{
					sceneTeamMatchStartReq.dungeonId = (uint)tableItem6.DungeonID;
				}
				netManager.SendCommand<SceneTeamMatchStartReq>(ServerType.GATE_SERVER, sceneTeamMatchStartReq);
			}
			else
			{
				WorldTeamMatchCancelReq cmd = new WorldTeamMatchCancelReq();
				netManager.SendCommand<WorldTeamMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x06011993 RID: 72083 RVA: 0x0052375C File Offset: 0x00521B5C
		private void OnCreateTeam()
		{
			TeamCreateInfo createInfo = DataManager<TeamDataManager>.GetInstance().CreateInfo;
			createInfo.Debug();
			createInfo.Reset();
			TeamListFrame teamListFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamListFrame)) as TeamListFrame;
			if (teamListFrame == null)
			{
				return;
			}
			int diffHard = DataManager<TeamDataManager>.GetInstance().DiffHard;
			if (diffHard == -1)
			{
				if (DataManager<TeamDataManager>.GetInstance().TeamDungeonID == 1U)
				{
					DataManager<TeamDataManager>.GetInstance().CreateTeam((uint)this.CurTeamDungeonTableID);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect("请选择挑战难度", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				return;
			}
			if (diffHard >= teamListFrame.locks.Count)
			{
				return;
			}
			if (teamListFrame.locks[diffHard].activeInHierarchy)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("关卡未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Dictionary<string, DiffInfo> secteamDungeons = teamListFrame.secteamDungeons;
			int teamDungeonID = this.CurTeamDungeonTableID;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
					{
						teamDungeonID = this.CurTeamDungeonTableID;
					}
				}
				else
				{
					DiffInfo diffInfo = new DiffInfo();
					secteamDungeons.TryGetValue(tableItem2.Name, out diffInfo);
					if (diffInfo != null)
					{
						for (int i = 0; i < diffInfo.secteamDungeonID.Count; i++)
						{
							TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(diffInfo.secteamDungeonID[i], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								DungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem3.DungeonID, string.Empty, string.Empty);
								if (tableItem4 != null)
								{
									if (tableItem4.Hard == (DungeonTable.eHard)diffHard)
									{
										teamDungeonID = diffInfo.secteamDungeonID[i];
										break;
									}
								}
							}
						}
					}
				}
			}
			DataManager<TeamDataManager>.GetInstance().CreateTeam((uint)teamDungeonID);
		}

		// Token: 0x06011994 RID: 72084 RVA: 0x0052395C File Offset: 0x00521D5C
		private void InitInterface()
		{
			this.mTargetDengeonName.text = string.Empty;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mTargetDengeonName.text = tableItem.Name;
				this.UpdateTargetDungeonInfo(tableItem.DungeonID);
			}
			this.BindUIEvent();
		}

		// Token: 0x06011995 RID: 72085 RVA: 0x005239C0 File Offset: 0x00521DC0
		private void UpdateTeamListPrefab()
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem != null && !this.bStartMatch)
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
			if (tableItem != null)
			{
				this.mTargetDengeonName.text = tableItem.Name;
				this.UpdateTargetDungeonInfo(tableItem.DungeonID);
			}
			List<Team> teamList = DataManager<TeamDataManager>.GetInstance().GetTeamList();
			if (teamList.Count > 0)
			{
				this.mTeamListDesc.gameObject.SetActive(false);
			}
			else
			{
				this.mTeamListDesc.gameObject.SetActive(true);
			}
			if (teamList.Count > this.TeamListObj.Count)
			{
				int count = this.TeamListObj.Count;
				int num = teamList.Count - this.TeamListObj.Count;
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Team/TeamListEle", true, 0U);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.mTeamListRoot, false);
						this.TeamListObj.Add(gameObject);
						TeamListViewFrame.TeamUI teamUI = new TeamListViewFrame.TeamUI();
						Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>();
						for (int j = 0; j < componentsInChildren.Length; j++)
						{
							if (componentsInChildren[j].name == "Icon")
							{
								teamUI.teamIcon = componentsInChildren[j];
							}
							else if (componentsInChildren[j].name == "Num1")
							{
								teamUI.Num1 = componentsInChildren[j];
							}
							else if (componentsInChildren[j].name == "Num2")
							{
								teamUI.Num2 = componentsInChildren[j];
							}
							else if (componentsInChildren[j].name == "Num3")
							{
								teamUI.Num3 = componentsInChildren[j];
							}
						}
						Text[] componentsInChildren2 = gameObject.GetComponentsInChildren<Text>();
						for (int k = 0; k < componentsInChildren2.Length; k++)
						{
							if (componentsInChildren2[k].name == "Name")
							{
								teamUI.teamName = componentsInChildren2[k];
							}
							else if (componentsInChildren2[k].name == "MemberNum")
							{
								teamUI.memberNum = componentsInChildren2[k];
							}
							else if (componentsInChildren2[k].name == "TargetName")
							{
								teamUI.targetName = componentsInChildren2[k];
							}
						}
						teamUI.join = gameObject.GetComponentInChildren<Button>();
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component != null)
						{
							teamUI.returnPlayer = component.GetGameObject("returnPlayer");
							teamUI.myFriend = component.GetGameObject("myFriend");
							teamUI.myGuild = component.GetGameObject("myGuild");
						}
						this.TeamListUI.Add(teamUI);
					}
				}
			}
			for (int l = 0; l < this.TeamListObj.Count; l++)
			{
				this.TeamListObj[l].SetActive(false);
			}
			int num2 = 0;
			int num3 = 0;
			while (num3 < teamList.Count && num2 < this.TeamListObj.Count)
			{
				TeamDungeonTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>((int)teamList[num3].teamDungeonID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
					if (tableItem3 != null || tableItem2.Type == TeamDungeonTable.eType.CityMonster)
					{
						int diffHard = DataManager<TeamDataManager>.GetInstance().DiffHard;
						if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID((int)teamList[num3].teamDungeonID) || DungeonUtility.IsWeekHellEntryDungeon(tableItem2.DungeonID))
						{
							if (DataManager<TeamDataManager>.GetInstance().DiffHard != -1 && DataManager<TeamDataManager>.GetInstance().DiffHard != 3)
							{
								goto IL_83F;
							}
						}
						else if (diffHard != -1 && tableItem3 != null && tableItem3.Hard != (DungeonTable.eHard)diffHard)
						{
							goto IL_83F;
						}
						JobTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)teamList[num3].leaderInfo.occu, string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							ResTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem4.Mode, string.Empty, string.Empty);
							if (tableItem5 != null)
							{
								ETCImageLoader.LoadSprite(ref this.TeamListUI[num2].teamIcon, tableItem5.IconPath, true);
							}
						}
						this.TeamListUI[num2].teamName.text = teamList[num3].leaderInfo.name;
						this.TeamListUI[num2].memberNum.text = teamList[num3].currentMemberCount.ToString();
						TeamDungeonTable tableItem6 = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>((int)teamList[num3].teamDungeonID, string.Empty, string.Empty);
						if (tableItem6 != null)
						{
							this.TeamListUI[num2].targetName.text = tableItem6.Name;
						}
						if ((int)teamList[num3].currentMemberCount >= this.TeamListUI[num2].GetNumImageCount())
						{
							string text = string.Format("队伍成员数量<{0}>超过设计的数量<{1}>,检查服务端数据，队伍id{2}, 队伍地下城id{3}, 最大成员数{4}. 队伍成员:\n", new object[]
							{
								teamList[num3].currentMemberCount,
								this.TeamListUI[num2].GetNumImageCount(),
								teamList[num3].teamID,
								teamList[num3].teamDungeonID,
								teamList[num3].maxMemberCount
							});
							for (int m = 0; m < teamList[num3].members.Length; m++)
							{
								TeamMember teamMember = teamList[num3].members[m];
								if (teamMember != null)
								{
									text += string.Format("id:{0}, 名字{1}\n", teamMember.id, teamMember.name);
								}
								else
								{
									text += string.Format("下标为{0}的数组成员为空", m);
								}
							}
							Logger.LogError(text);
						}
						this.TeamListUI[num2].SetNumImage((int)teamList[num3].currentMemberCount);
						ulong iTeamID = teamList[num3].leaderInfo.id;
						this.TeamListUI[num2].join.onClick.RemoveAllListeners();
						this.TeamListUI[num2].join.onClick.AddListener(delegate()
						{
							this.OnClickJoinTeam(iTeamID);
						});
						this.TeamListObj[num2].SetActive(true);
						this.TeamListUI[num2].returnPlayer.CustomActive(false);
						this.TeamListUI[num2].myFriend.CustomActive(false);
						this.TeamListUI[num2].myGuild.CustomActive(false);
						RelationData relationData = null;
						bool flag = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(teamList[num3].leaderInfo.id, ref relationData);
						bool flag2 = DataManager<GuildDataManager>.GetInstance().IsSameGuild(teamList[num3].leaderInfo.playerLabelInfo.guildId);
						if (teamList[num3].leaderInfo.playerLabelInfo.returnStatus == 1)
						{
							this.TeamListUI[num2].returnPlayer.CustomActive(true);
						}
						else if (flag)
						{
							this.TeamListUI[num2].myFriend.CustomActive(true);
						}
						else if (flag2)
						{
							this.TeamListUI[num2].myGuild.CustomActive(true);
						}
						num2++;
					}
				}
				IL_83F:
				num3++;
			}
			if (num2 > 0)
			{
				this.mTeamListDesc.gameObject.SetActive(false);
			}
			else
			{
				this.mTeamListDesc.gameObject.SetActive(true);
			}
		}

		// Token: 0x06011996 RID: 72086 RVA: 0x00524260 File Offset: 0x00522660
		private void OnTeamListRequestSuccess(UIEvent uiEvent)
		{
			this.UpdateTeamListPrefab();
		}

		// Token: 0x06011997 RID: 72087 RVA: 0x00524268 File Offset: 0x00522668
		private void OnUdpateTeamListByHard(UIEvent uiEvent)
		{
			this.UpdateTeamListPrefab();
		}

		// Token: 0x06011998 RID: 72088 RVA: 0x00524270 File Offset: 0x00522670
		private void OnTeamMatchStartSuccess(UIEvent uiEvent)
		{
			this.fAddUpTime = 0f;
			this.bStartMatch = true;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
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
			teamMatchWaitingData.TeamDungeonTableID = this.CurTeamDungeonTableID;
			TeamListFrame teamListFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamListFrame)) as TeamListFrame;
			if (teamListFrame == null)
			{
				return;
			}
			int diffHard = DataManager<TeamDataManager>.GetInstance().DiffHard;
			if (diffHard == -1)
			{
				return;
			}
			if (diffHard >= teamListFrame.locks.Count)
			{
				return;
			}
			Dictionary<string, DiffInfo> secteamDungeons = teamListFrame.secteamDungeons;
			int teamDungeonTableID = this.CurTeamDungeonTableID;
			TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
				if (tableItem3 == null)
				{
					if (tableItem2.Type == TeamDungeonTable.eType.CityMonster)
					{
						teamDungeonTableID = this.CurTeamDungeonTableID;
						if (diffHard != 0)
						{
							return;
						}
					}
				}
				else
				{
					DiffInfo diffInfo = new DiffInfo();
					secteamDungeons.TryGetValue(tableItem3.Name, out diffInfo);
					if (diffInfo != null)
					{
						for (int i = 0; i < diffInfo.secteamDungeonID.Count; i++)
						{
							TeamDungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(diffInfo.secteamDungeonID[i], string.Empty, string.Empty);
							if (tableItem4 != null)
							{
								DungeonTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem4.DungeonID, string.Empty, string.Empty);
								if (tableItem5 != null)
								{
									if (tableItem5.Hard == (DungeonTable.eHard)diffHard)
									{
										teamDungeonTableID = diffInfo.secteamDungeonID[i];
										break;
									}
								}
							}
						}
					}
				}
			}
			teamMatchWaitingData.TeamDungeonTableID = teamDungeonTableID;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMatchWaitingFrame>(FrameLayer.Middle, teamMatchWaitingData, string.Empty);
		}

		// Token: 0x06011999 RID: 72089 RVA: 0x00524480 File Offset: 0x00522880
		private void OnTeamMatchCancelSuccess(UIEvent uiEvent)
		{
			this.bStartMatch = false;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
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

		// Token: 0x0601199A RID: 72090 RVA: 0x005244E6 File Offset: 0x005228E6
		private void OnJoinTeamRequestSuccess(UIEvent uiEvent)
		{
		}

		// Token: 0x0601199B RID: 72091 RVA: 0x005244E8 File Offset: 0x005228E8
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0601199C RID: 72092 RVA: 0x005244EC File Offset: 0x005228EC
		private void _updateRefresh(float delta)
		{
			if (this.mRefreshTime > 0f)
			{
				this.mRefreshTime -= delta;
			}
			else
			{
				this.mRefreshTime = 10f;
				TeamListFrame teamListFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamListFrame)) as TeamListFrame;
				if (teamListFrame == null)
				{
					return;
				}
				Dictionary<int, List<int>> secondMenuID2TargetIDs = teamListFrame.secondMenuID2TargetIDs;
				if (secondMenuID2TargetIDs != null && secondMenuID2TargetIDs.ContainsKey(this.CurTeamDungeonTableID))
				{
					DataManager<TeamDataManager>.GetInstance().RequestSearchTeam((uint)this.CurTeamDungeonTableID, secondMenuID2TargetIDs[this.CurTeamDungeonTableID]);
				}
				else
				{
					DataManager<TeamDataManager>.GetInstance().RequestSearchTeam((uint)this.CurTeamDungeonTableID);
				}
			}
		}

		// Token: 0x0601199D RID: 72093 RVA: 0x00524598 File Offset: 0x00522998
		protected override void _OnUpdate(float timeElapsed)
		{
			this._updateRefresh(timeElapsed);
			if (this.bStartMatch)
			{
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(this.CurTeamDungeonTableID, string.Empty, string.Empty);
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

		// Token: 0x0601199E RID: 72094 RVA: 0x00524638 File Offset: 0x00522A38
		protected override void _bindExUI()
		{
			this.mTargetDengeonName = this.mBind.GetCom<Text>("TargetDengeonName");
			this.mTargetDungeonResistMagicRoot = this.mBind.GetGameObject("TargetDengeonResistMagicValueRoot");
			this.mTargetDengeonResistMagicValue = this.mBind.GetCom<Text>("TargetDengeonResistMagicValue");
			this.mTeamListRoot = this.mBind.GetGameObject("TeamListRoot");
			this.mTeamListDesc = this.mBind.GetCom<Text>("TeamListDesc");
			this.mMatchText = this.mBind.GetCom<Text>("MatchText");
			this.mOnMatch = this.mBind.GetCom<Button>("onMatch");
			this.mOnMatch.onClick.AddListener(new UnityAction(this._onOnMatchButtonClick));
			this.mOnCreateTeam = this.mBind.GetCom<Button>("onCreateTeam");
			this.mOnCreateTeam.onClick.AddListener(new UnityAction(this._onOnCreateTeamButtonClick));
		}

		// Token: 0x0601199F RID: 72095 RVA: 0x00524730 File Offset: 0x00522B30
		protected override void _unbindExUI()
		{
			this.mTargetDengeonName = null;
			this.mTargetDungeonResistMagicRoot = null;
			this.mTargetDengeonResistMagicValue = null;
			this.mTeamListRoot = null;
			this.mTeamListDesc = null;
			this.mMatchText = null;
			this.mOnMatch.onClick.RemoveListener(new UnityAction(this._onOnMatchButtonClick));
			this.mOnMatch = null;
			this.mOnCreateTeam.onClick.RemoveListener(new UnityAction(this._onOnCreateTeamButtonClick));
			this.mOnCreateTeam = null;
		}

		// Token: 0x060119A0 RID: 72096 RVA: 0x005247AD File Offset: 0x00522BAD
		private void _onOnMatchButtonClick()
		{
			this.OnMatch();
		}

		// Token: 0x060119A1 RID: 72097 RVA: 0x005247B5 File Offset: 0x00522BB5
		private void _onOnCreateTeamButtonClick()
		{
			this.OnCreateTeam();
		}

		// Token: 0x060119A2 RID: 72098 RVA: 0x005247C0 File Offset: 0x00522BC0
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

		// Token: 0x0400B736 RID: 46902
		private bool bStartMatch;

		// Token: 0x0400B737 RID: 46903
		private float fAddUpTime;

		// Token: 0x0400B738 RID: 46904
		private List<int> FliterFirstMenuList = new List<int>();

		// Token: 0x0400B739 RID: 46905
		private Dictionary<int, List<int>> FliterSecondMenuDict = new Dictionary<int, List<int>>();

		// Token: 0x0400B73A RID: 46906
		private List<TeamListViewFrame.TeamUI> TeamListUI = new List<TeamListViewFrame.TeamUI>();

		// Token: 0x0400B73B RID: 46907
		private List<GameObject> TeamListObj = new List<GameObject>();

		// Token: 0x0400B73C RID: 46908
		private const float kRefreshGap = 10f;

		// Token: 0x0400B73D RID: 46909
		private float mRefreshTime;

		// Token: 0x0400B73E RID: 46910
		private Text mTargetDengeonName;

		// Token: 0x0400B73F RID: 46911
		private GameObject mTargetDungeonResistMagicRoot;

		// Token: 0x0400B740 RID: 46912
		private Text mTargetDengeonResistMagicValue;

		// Token: 0x0400B741 RID: 46913
		private GameObject mTeamListRoot;

		// Token: 0x0400B742 RID: 46914
		private Text mTeamListDesc;

		// Token: 0x0400B743 RID: 46915
		private Text mMatchText;

		// Token: 0x0400B744 RID: 46916
		private Button mOnMatch;

		// Token: 0x0400B745 RID: 46917
		private Button mOnCreateTeam;

		// Token: 0x02001C10 RID: 7184
		private class TeamUI
		{
			// Token: 0x060119A4 RID: 72100 RVA: 0x00524854 File Offset: 0x00522C54
			public void SetNumImage(int iNum)
			{
				if (iNum >= this.mSetNumFlag.GetLength(0) || iNum < 0)
				{
					return;
				}
				this.Num1.gameObject.SetActive(this.mSetNumFlag[iNum, 0]);
				this.Num2.gameObject.SetActive(this.mSetNumFlag[iNum, 1]);
				this.Num3.gameObject.SetActive(this.mSetNumFlag[iNum, 2]);
			}

			// Token: 0x060119A5 RID: 72101 RVA: 0x005248D2 File Offset: 0x00522CD2
			public int GetNumImageCount()
			{
				return this.mSetNumFlag.GetLength(0);
			}

			// Token: 0x0400B746 RID: 46918
			public Image teamIcon;

			// Token: 0x0400B747 RID: 46919
			public Text teamName;

			// Token: 0x0400B748 RID: 46920
			public Text memberNum;

			// Token: 0x0400B749 RID: 46921
			public Text targetName;

			// Token: 0x0400B74A RID: 46922
			public Image Num1;

			// Token: 0x0400B74B RID: 46923
			public Image Num2;

			// Token: 0x0400B74C RID: 46924
			public Image Num3;

			// Token: 0x0400B74D RID: 46925
			public Button join;

			// Token: 0x0400B74E RID: 46926
			public GameObject returnPlayer;

			// Token: 0x0400B74F RID: 46927
			public GameObject myFriend;

			// Token: 0x0400B750 RID: 46928
			public GameObject myGuild;

			// Token: 0x0400B751 RID: 46929
			private bool[,] mSetNumFlag = new bool[,]
			{
				{
					false,
					false,
					false
				},
				{
					true,
					false,
					false
				},
				{
					true,
					true,
					false
				},
				{
					true,
					true,
					true
				}
			};
		}
	}
}
