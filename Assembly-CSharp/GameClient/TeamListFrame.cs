using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C0D RID: 7181
	internal class TeamListFrame : ClientFrame
	{
		// Token: 0x17001DB8 RID: 7608
		// (get) Token: 0x0601195E RID: 72030 RVA: 0x00520E88 File Offset: 0x0051F288
		private int CurTeamDungeonTableID
		{
			get
			{
				int num = (int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID;
				if (num <= 0)
				{
					num = 1;
				}
				return num;
			}
		}

		// Token: 0x0601195F RID: 72031 RVA: 0x00520EAA File Offset: 0x0051F2AA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamList";
		}

		// Token: 0x06011960 RID: 72032 RVA: 0x00520EB1 File Offset: 0x0051F2B1
		public static void OnOpenLinkFrame(string argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06011961 RID: 72033 RVA: 0x00520EC8 File Offset: 0x0051F2C8
		protected override void _OnOpenFrame()
		{
			DataManager<TeamDataManager>.GetInstance().NotPopUpTeamList = false;
			if (DataManager<TeamDataManager>.GetInstance().HasTeam() && !DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				this.frameMgr.CloseFrame<TeamListFrame>(this, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMyFrame>(FrameLayer.Middle, null, string.Empty);
				return;
			}
			this.locks = new List<GameObject>();
			this.locks.Add(Utility.FindChild(this.togType2.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType3.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType4.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType5.gameObject, "lock"));
			this._updateState();
			int num = 1;
			if (this.userData != null)
			{
				this.FliterSecondMenuDict.Clear();
				this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
				GuildDataManager.FliterTeamDungeonID(ref this.FliterFirstMenuList, ref this.FliterSecondMenuDict);
				num = (int)this.userData;
				string b = string.Empty;
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(num, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						b = tableItem2.Name;
					}
				}
				foreach (KeyValuePair<int, List<int>> keyValuePair in this.FliterSecondMenuDict)
				{
					List<int> value = keyValuePair.Value;
					if (value != null && value.Contains(num))
					{
						for (int i = 0; i < value.Count; i++)
						{
							TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(value[i], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								DungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem3.DungeonID, string.Empty, string.Empty);
								if (tableItem4 != null && tableItem4.Name == b)
								{
									num = value[i];
									break;
								}
							}
						}
						break;
					}
				}
				if (this.mState == eTeamFrameState.onList)
				{
					DataManager<TeamDataManager>.GetInstance().TeamDungeonID = (uint)num;
				}
				else if (this.mState == eTeamFrameState.onTeam)
				{
					DataManager<TeamDataManager>.GetInstance().TeamDungeonID = (uint)((int)this.userData);
				}
			}
			else
			{
				num = this.CurTeamDungeonTableID;
				if (GuildDataManager.IsInGuildAreanScence() || GuildDataManager.IsGuildDungeonMapScence())
				{
					num = this.GetGuildTeamDungeonID();
				}
				this.FliterSecondMenuDict.Clear();
				this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
				GuildDataManager.FliterTeamDungeonID(ref this.FliterFirstMenuList, ref this.FliterSecondMenuDict);
				string b2 = string.Empty;
				TeamDungeonTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(num, string.Empty, string.Empty);
				if (tableItem5 != null)
				{
					DungeonTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem5.DungeonID, string.Empty, string.Empty);
					if (tableItem6 != null)
					{
						b2 = tableItem6.Name;
					}
				}
				foreach (KeyValuePair<int, List<int>> keyValuePair2 in this.FliterSecondMenuDict)
				{
					List<int> value2 = keyValuePair2.Value;
					if (value2 != null && value2.Contains(num))
					{
						for (int j = 0; j < value2.Count; j++)
						{
							TeamDungeonTable tableItem7 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(value2[j], string.Empty, string.Empty);
							if (tableItem7 != null)
							{
								DungeonTable tableItem8 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem7.DungeonID, string.Empty, string.Empty);
								if (tableItem8 != null && tableItem8.Name == b2)
								{
									num = value2[j];
									break;
								}
							}
						}
						break;
					}
				}
				if (this.mState == eTeamFrameState.onList)
				{
					DataManager<TeamDataManager>.GetInstance().TeamDungeonID = (uint)num;
				}
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				clientSystemTown.MainPlayer.CommandStopMove();
			}
			this._updateState();
			this._loadFirstMenuList();
			this.BindUIEvent();
			this.OnChooseFirstMenu(TeamUtility.GetMenuTeamDungeonID(num), true);
			this.OnChooseSecondMenu(num, true, null);
			if (this.mState == eTeamFrameState.onList)
			{
				this._updateAutoSelect(this.CurTeamDungeonTableID);
			}
			if (this.userData != null)
			{
				int num2 = (int)this.userData;
				TeamDungeonTable tableItem9 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(num2, string.Empty, string.Empty);
				if (tableItem9 != null)
				{
					DungeonTable tableItem10 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem9.DungeonID, string.Empty, string.Empty);
					if (tableItem10 != null)
					{
						int num3 = (int)tableItem10.Hard;
						if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID(num2) || DungeonUtility.IsWeekHellTeamDungeon(num2))
						{
							num3 = 3;
						}
						List<Toggle> list = new List<Toggle>();
						list.Add(this.togType2);
						list.Add(this.togType3);
						list.Add(this.togType4);
						list.Add(this.togType5);
						if (num3 < list.Count)
						{
							list[num3].isOn = true;
						}
						this.UpdateToggleTextColor(this.togType1);
						this.UpdateToggleTextColor(this.togType2);
						this.UpdateToggleTextColor(this.togType3);
						this.UpdateToggleTextColor(this.togType4);
						this.UpdateToggleTextColor(this.togType5);
					}
				}
			}
			if (this.mState == eTeamFrameState.onTeam)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamListFrame>(null, false);
			}
		}

		// Token: 0x06011962 RID: 72034 RVA: 0x005214BC File Offset: 0x0051F8BC
		private int GetGuildTeamDungeonID()
		{
			this.FliterSecondMenuDict.Clear();
			this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
			GuildDataManager.FliterTeamDungeonID(ref this.FliterFirstMenuList, ref this.FliterSecondMenuDict);
			if (this.FliterFirstMenuList.Count > 0)
			{
				return this.FliterFirstMenuList[0];
			}
			return 0;
		}

		// Token: 0x06011963 RID: 72035 RVA: 0x00521515 File Offset: 0x0051F915
		private void _updateState()
		{
			this.mState = ((!DataManager<TeamDataManager>.GetInstance().HasTeam()) ? eTeamFrameState.onList : eTeamFrameState.onTeam);
		}

		// Token: 0x06011964 RID: 72036 RVA: 0x00521533 File Offset: 0x0051F933
		protected override void _OnCloseFrame()
		{
			this.Clear();
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamListViewFrame>(null, false);
		}

		// Token: 0x06011965 RID: 72037 RVA: 0x00521547 File Offset: 0x0051F947
		private new void Clear()
		{
			this.mCurrentFilterIndex = 0;
			this._clearAllCacheNode();
			this.FliterFirstMenuList.Clear();
			this.FliterSecondMenuDict.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x06011966 RID: 72038 RVA: 0x00521574 File Offset: 0x0051F974
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamInfoUpdateSuccess, new ClientEventSystem.UIEventHandler(this._onTeamInfoUpdateSuccess));
		}

		// Token: 0x06011967 RID: 72039 RVA: 0x005215F0 File Offset: 0x0051F9F0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamCreateSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamRemoveMemberSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamJoinSuccess, new ClientEventSystem.UIEventHandler(this.OnCreateTeamSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamInfoUpdateSuccess, new ClientEventSystem.UIEventHandler(this._onTeamInfoUpdateSuccess));
		}

		// Token: 0x06011968 RID: 72040 RVA: 0x00521669 File Offset: 0x0051FA69
		private void OnCloseBtnClicked()
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("正在匹配,无法退出", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.CloseFrame<TeamListFrame>(this, false);
		}

		// Token: 0x06011969 RID: 72041 RVA: 0x00521690 File Offset: 0x0051FA90
		private void _updateTeamDungeonNodeByFilter(TeamListFrame.TeamDungeonNode node)
		{
			if (node != null && node.table != null && null != node.bind)
			{
				if (this.mCurrentFilterIndex == 0)
				{
					node.bind.gameObject.SetActive(true);
				}
				else if (node.table.ShowIndependent == 1)
				{
					node.bind.gameObject.SetActive(true);
				}
				else if (node.table.Type == TeamDungeonTable.eType.DUNGEON)
				{
					int num = 4 - this.mCurrentFilterIndex;
					this.mDungeonID.dungeonID = node.table.DungeonID;
					bool flag = num == this.mDungeonID.diffID;
					node.bind.gameObject.SetActive(flag);
					if (flag && node.id == this.CurTeamDungeonTableID)
					{
						Toggle com = node.bind.GetCom<Toggle>("ongroup");
						if (null != com)
						{
							com.isOn = true;
						}
					}
				}
			}
		}

		// Token: 0x0601196A RID: 72042 RVA: 0x00521794 File Offset: 0x0051FB94
		private TeamListFrame.TeamDungeonNode _getParentTeamDungeonNodeByID(int id)
		{
			TeamListFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(id);
			if (teamDungeonNode != null && teamDungeonNode.table != null)
			{
				return this._getTeamDungeonNodeByID(teamDungeonNode.table.MenuID);
			}
			return null;
		}

		// Token: 0x0601196B RID: 72043 RVA: 0x005217D0 File Offset: 0x0051FBD0
		private TeamListFrame.TeamDungeonNode _getTeamDungeonNodeByID(int id)
		{
			TeamListFrame.TeamDungeonNode result = null;
			if (this.mAllNodes != null)
			{
				for (int i = 0; i < this.mAllNodes.Count; i++)
				{
					if (this.mAllNodes[i].id == id)
					{
						result = this.mAllNodes[i];
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0601196C RID: 72044 RVA: 0x00521830 File Offset: 0x0051FC30
		private void OnChooseFirstMenu(int teamDungeonID, bool value)
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (value)
			{
				DataManager<TeamDataManager>.GetInstance().DiffHard = -1;
				this._createSecondMenuToggleList(teamDungeonID);
				this._sendSwitchTeamDungeonID(teamDungeonID, null);
				DungeonTable.eHard eHard = DungeonTable.eHard.NORMAL;
				this.UpdateAllTypeLockState(teamDungeonID, ref eHard);
				this.togType1.CustomActive(true);
				this.togType1.isOn = true;
				this.togType2.isOn = false;
				this.togType3.isOn = false;
				this.togType4.isOn = false;
				this.togType5.isOn = false;
				this.UpdateToggleTextColor(this.togType1);
				this.UpdateToggleTextColor(this.togType2);
				this.UpdateToggleTextColor(this.togType3);
				this.UpdateToggleTextColor(this.togType4);
				this.UpdateToggleTextColor(this.togType5);
				if (teamDungeonID == this.GetGuildTeamDungeonID())
				{
					this.togType1.CustomActive(true);
					this.togType2.CustomActive(true);
					this.togType3.CustomActive(false);
					this.togType4.CustomActive(false);
					this.togType5.CustomActive(false);
				}
				else
				{
					this.togType1.CustomActive(true);
					this.togType2.CustomActive(true);
					this.togType3.CustomActive(true);
					this.togType4.CustomActive(true);
					this.togType5.CustomActive(true);
				}
			}
		}

		// Token: 0x0601196D RID: 72045 RVA: 0x00521990 File Offset: 0x0051FD90
		private void _sendSwitchTeamDungeonID(int teamDungeonID, List<int> IDs = null)
		{
			this._updateState();
			eTeamFrameState eTeamFrameState = this.mState;
			if (eTeamFrameState != eTeamFrameState.onList)
			{
				if (eTeamFrameState == eTeamFrameState.onTeam)
				{
					if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
					{
						TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
						if (tableItem == null || tableItem.Type == TeamDungeonTable.eType.DUNGEON || tableItem.Type == TeamDungeonTable.eType.CityMonster)
						{
						}
					}
				}
			}
			else
			{
				DataManager<TeamDataManager>.GetInstance().RequestSearchTeam((uint)teamDungeonID, IDs);
			}
		}

		// Token: 0x0601196E RID: 72046 RVA: 0x00521A18 File Offset: 0x0051FE18
		private void UpdateToggleTextColor(Toggle toggle)
		{
			if (toggle != null)
			{
				ComChangeColor component = toggle.GetComponent<ComChangeColor>();
				if (component != null)
				{
					component.SetColor(toggle.isOn);
				}
			}
		}

		// Token: 0x0601196F RID: 72047 RVA: 0x00521A50 File Offset: 0x0051FE50
		private void OnChooseSecondMenu(int teamDungeonID, bool value, List<int> dungeonIDs = null)
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (value && teamDungeonID != 1)
			{
				TeamListFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamDungeonID);
				if (teamDungeonNode != null && teamDungeonNode.table.Type == TeamDungeonTable.eType.MENU)
				{
					return;
				}
			}
			this.togType1.CustomActive(true);
			this.togType2.CustomActive(true);
			this.togType3.CustomActive(true);
			this.togType4.CustomActive(true);
			this.togType5.CustomActive(true);
			if (value)
			{
				this.togType1.isOn = true;
				this.togType2.isOn = false;
				this.togType3.isOn = false;
				this.togType4.isOn = false;
				this.togType5.isOn = false;
				TeamListFrame.TeamDungeonNode teamDungeonNode2 = this._getTeamDungeonNodeByID(teamDungeonID);
				if (teamDungeonNode2 == null)
				{
					return;
				}
				if (teamDungeonNode2.table == null)
				{
					return;
				}
				this._sendSwitchTeamDungeonID(teamDungeonID, dungeonIDs);
				DungeonTable.eHard eHard = DungeonTable.eHard.NORMAL;
				this.UpdateAllTypeLockState(teamDungeonID, ref eHard);
				List<Toggle> list = new List<Toggle>();
				if (list == null)
				{
					return;
				}
				list.Add(this.togType2);
				list.Add(this.togType3);
				list.Add(this.togType4);
				list.Add(this.togType5);
				if (teamDungeonID != 1)
				{
					int num = (int)eHard;
					for (int i = 0; i < list.Count; i++)
					{
						if (i == num)
						{
							list[i].isOn = true;
						}
						else
						{
							list[i].isOn = false;
						}
					}
				}
				this.UpdateToggleTextColor(this.togType1);
				this.UpdateToggleTextColor(this.togType2);
				this.UpdateToggleTextColor(this.togType3);
				this.UpdateToggleTextColor(this.togType4);
				this.UpdateToggleTextColor(this.togType5);
				if (teamDungeonID == 1)
				{
					this.togType1.CustomActive(true);
					this.togType1.isOn = true;
					this.togType2.isOn = false;
					this.togType3.isOn = false;
					this.togType4.isOn = false;
					this.togType5.isOn = false;
					this.UpdateToggleTextColor(this.togType1);
					this.UpdateToggleTextColor(this.togType2);
					this.UpdateToggleTextColor(this.togType3);
					this.UpdateToggleTextColor(this.togType4);
					this.UpdateToggleTextColor(this.togType5);
					DataManager<TeamDataManager>.GetInstance().DiffHard = -1;
				}
				else
				{
					this.togType1.CustomActive(false);
				}
				for (int j = 0; j < list.Count; j++)
				{
					Toggle toggle = list[j];
					if (toggle != null)
					{
						toggle.CustomActive(true);
					}
				}
				bool flag = teamDungeonNode2.table.MenuID == this.GetGuildTeamDungeonID();
				bool flag2 = TeamUtility.IsEliteDungeonID(teamDungeonNode2.table.DungeonID);
				if (flag || flag2)
				{
					for (int k = 0; k < list.Count; k++)
					{
						Toggle toggle2 = list[k];
						if (!(toggle2 == null))
						{
							if (k == 0)
							{
								toggle2.CustomActive(true);
							}
							else
							{
								toggle2.CustomActive(false);
							}
						}
					}
					if (list.Count > 0)
					{
						list[0].SafeSetToggleOnState(true);
					}
				}
				else if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID(teamDungeonID) || DungeonUtility.IsWeekHellTeamDungeon(teamDungeonID))
				{
					for (int l = 0; l < list.Count; l++)
					{
						if (l == list.Count - 1)
						{
							list[l].CustomActive(true);
						}
						else if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID(teamDungeonID) || DungeonUtility.IsWeekHellTeamDungeon(teamDungeonID))
						{
							list[l].CustomActive(false);
						}
						else
						{
							list[l].CustomActive(true);
						}
					}
				}
			}
		}

		// Token: 0x06011970 RID: 72048 RVA: 0x00521E37 File Offset: 0x00520237
		private void _onTeamInfoUpdateSuccess(UIEvent ui)
		{
		}

		// Token: 0x06011971 RID: 72049 RVA: 0x00521E3C File Offset: 0x0052023C
		private void _tryLoadRightFrame()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamListViewFrame>(null, false);
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamMyFrame>(null, false);
			eTeamFrameState eTeamFrameState = this.mState;
			if (eTeamFrameState != eTeamFrameState.onList)
			{
				if (eTeamFrameState == eTeamFrameState.onTeam)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMyFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.instance.OpenFrame(typeof(TeamListViewFrame), this.mRightRoot, null, string.Empty, FrameLayer.Invalid);
			}
		}

		// Token: 0x06011972 RID: 72050 RVA: 0x00521EBC File Offset: 0x005202BC
		private void _updateAutoSelect(int teamDungeonID)
		{
			switch (TeamUtility.GetTeamDungeonType(teamDungeonID))
			{
			case TeamUtility.eType.NoTarget:
			case TeamUtility.eType.Menu:
				this._selectNodeByID(teamDungeonID, true);
				break;
			case TeamUtility.eType.Dungeon:
				this._selectNodeByID(TeamUtility.GetMenuTeamDungeonID(teamDungeonID), true);
				this._selectNodeByID(teamDungeonID, true);
				break;
			case TeamUtility.eType.AttackCityMonster:
				this._selectNodeByID(TeamUtility.GetMenuTeamDungeonID(teamDungeonID), true);
				this._selectNodeByID(teamDungeonID, true);
				break;
			}
		}

		// Token: 0x06011973 RID: 72051 RVA: 0x00521F2C File Offset: 0x0052032C
		private void _clearAllCacheNode()
		{
			for (int i = 0; i < this.mAllNodes.Count; i++)
			{
				if (this.mAllNodes[i].table.Type == TeamDungeonTable.eType.DUNGEON && this.mAllNodes[i] != null)
				{
					this.mAllNodes[i].bind.ClearAllCacheBinds();
					this.mAllNodes[i].bind = null;
				}
			}
			for (int j = 0; j < this.mAllNodes.Count; j++)
			{
				if (this.mAllNodes[j].table.Type != TeamDungeonTable.eType.DUNGEON && this.mAllNodes[j] != null)
				{
					this.mAllNodes[j].bind.ClearAllCacheBinds();
					this.mAllNodes[j].bind = null;
				}
			}
			this.mBind.ClearCacheBinds("UIFlatten/Prefabs/Team/TeamMenuGroup");
			this.mAllNodes.Clear();
		}

		// Token: 0x06011974 RID: 72052 RVA: 0x00522034 File Offset: 0x00520434
		private void _loadFirstMenuList()
		{
			this._clearAllCacheNode();
			this.FliterSecondMenuDict.Clear();
			this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
			GuildDataManager.FliterTeamDungeonID(ref this.FliterFirstMenuList, ref this.FliterSecondMenuDict);
			this._createFirstMenuToggleList();
			this._createSecondMenuToggleList(TeamUtility.GetMenuTeamDungeonID(this.CurTeamDungeonTableID));
			this._tryLoadRightFrame();
		}

		// Token: 0x06011975 RID: 72053 RVA: 0x00522094 File Offset: 0x00520494
		private void UpdateAllTypeLockState(int teamDungeonID, ref DungeonTable.eHard eMaxHard)
		{
			for (int i = 0; i < this.locks.Count; i++)
			{
				GameObject gameObject = this.locks[i];
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
				}
			}
			if (teamDungeonID == 1)
			{
				return;
			}
			if (this.FliterFirstMenuList.Contains(teamDungeonID))
			{
				return;
			}
			DungeonTable.eHard eHard = DungeonTable.eHard.NORMAL;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					if (tableItem.Type == TeamDungeonTable.eType.CityMonster)
					{
						eHard = DungeonTable.eHard.NORMAL;
					}
				}
				else
				{
					DiffInfo diffInfo = new DiffInfo();
					this.secteamDungeons.TryGetValue(tableItem2.Name, out diffInfo);
					if (diffInfo != null)
					{
						for (int j = 0; j < diffInfo.secteamDungeonID.Count; j++)
						{
							TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(diffInfo.secteamDungeonID[j], string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								DungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem3.DungeonID, string.Empty, string.Empty);
								if (tableItem4 != null)
								{
									if (tableItem4.Hard > eHard)
									{
										eHard = tableItem4.Hard;
									}
								}
							}
						}
					}
				}
			}
			if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID(teamDungeonID) || DungeonUtility.IsWeekHellTeamDungeon(teamDungeonID))
			{
				eHard = DungeonTable.eHard.KING;
			}
			for (int k = (int)(eHard + 1); k < this.locks.Count; k++)
			{
				GameObject gameObject2 = this.locks[k];
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(true);
				}
			}
			eMaxHard = eHard;
		}

		// Token: 0x06011976 RID: 72054 RVA: 0x00522270 File Offset: 0x00520670
		private void _selectNodeByID(int teamDungeonID, bool isOn)
		{
			TeamListFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(this.CurTeamDungeonTableID);
			if (teamDungeonNode != null)
			{
				Toggle com = teamDungeonNode.bind.GetCom<Toggle>("ongroup");
				com.isOn = isOn;
			}
		}

		// Token: 0x06011977 RID: 72055 RVA: 0x005222A8 File Offset: 0x005206A8
		private bool _isFirstMenuOn(int menuTeamDungeonID)
		{
			return TeamUtility.GetMenuTeamDungeonID(this.CurTeamDungeonTableID) == menuTeamDungeonID;
		}

		// Token: 0x06011978 RID: 72056 RVA: 0x005222B8 File Offset: 0x005206B8
		private void _createFirstMenuToggleList()
		{
			for (int i = 0; i < this.FliterFirstMenuList.Count; i++)
			{
				int teamDungeonID = this.FliterFirstMenuList[i];
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ComCommonBind comCommonBind = this.mBind.LoadExtraBind("UIFlatten/Prefabs/Team/TeamMenuGroup");
					if (null != comCommonBind)
					{
						TeamListFrame.TeamDungeonNode teamDungeonNode = new TeamListFrame.TeamDungeonNode();
						teamDungeonNode.bind = comCommonBind;
						teamDungeonNode.id = teamDungeonID;
						teamDungeonNode.table = tableItem;
						this.mAllNodes.Add(teamDungeonNode);
						Utility.AttachTo(comCommonBind.gameObject, this.mTargetRoot, false);
						Toggle com = comCommonBind.GetCom<Toggle>("ongroup");
						Text com2 = comCommonBind.GetCom<Text>("desc");
						ComSwitchNode com3 = comCommonBind.GetCom<ComSwitchNode>("switchNode");
						com3.Reset();
						com2.text = tableItem.Name;
						com.group = this.mFirstMenutogglegroup;
						com.isOn = this._isFirstMenuOn(teamDungeonID);
						if (teamDungeonID == 1)
						{
							com2.text = "全部挑战";
						}
						if (tableItem.ShowIndependent == 1)
						{
							com.onValueChanged.AddListener(delegate(bool value)
							{
								this.OnChooseSecondMenu(teamDungeonID, value, null);
							});
						}
						else
						{
							com.onValueChanged.AddListener(delegate(bool value)
							{
								this.OnChooseFirstMenu(teamDungeonID, value);
							});
						}
					}
				}
			}
		}

		// Token: 0x06011979 RID: 72057 RVA: 0x00522438 File Offset: 0x00520838
		private void _createSecondMenuToggleList(int teamMenuDungeonID)
		{
			TeamListFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamMenuDungeonID);
			if (teamDungeonNode != null && !TeamUtility.IsNormalTeamDungeonID(teamMenuDungeonID) && this.FliterSecondMenuDict.ContainsKey(teamDungeonNode.id))
			{
				ComSwitchNode com = teamDungeonNode.bind.GetCom<ComSwitchNode>("switchNode");
				GameObject gameObject = teamDungeonNode.bind.GetGameObject("content");
				List<int> list = this.FliterSecondMenuDict[teamDungeonNode.id];
				Dictionary<int, List<int>> teamDungeonSecondMenuDict = Singleton<TableManager>.GetInstance().GetTeamDungeonSecondMenuDict();
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				foreach (KeyValuePair<int, List<int>> keyValuePair in teamDungeonSecondMenuDict)
				{
					List<int> value = keyValuePair.Value;
					for (int i = 0; i < value.Count; i++)
					{
						TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(value[i], string.Empty, string.Empty);
						if (tableItem != null)
						{
							DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (!DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(tableItem.DungeonID) || !DataManager<GuildDataManager>.GetInstance().HasSelfGuild() || DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffType() == GuildDataManager.GetDungeonTypeByDungeonID(tableItem.DungeonID))
								{
									int num = 0;
									if (!dictionary.TryGetValue(tableItem2.Name, out num))
									{
										dictionary.Add(tableItem2.Name, tableItem.RecoLevel);
									}
									else if (tableItem.RecoLevel > num)
									{
										dictionary[tableItem2.Name] = tableItem.RecoLevel;
									}
								}
							}
						}
					}
				}
				List<int> list2 = new List<int>();
				for (int j = 0; j < list.Count; j++)
				{
					list2.Add(list[j]);
				}
				this.secteamDungeons.Clear();
				for (int k = 0; k < list2.Count; k++)
				{
					TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list2[k], string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						DungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem3.DungeonID, string.Empty, string.Empty);
						if (tableItem4 != null)
						{
							DiffInfo diffInfo2 = new DiffInfo();
							this.secteamDungeons.TryGetValue(tableItem4.Name, out diffInfo2);
							if (diffInfo2 == null)
							{
								diffInfo2 = new DiffInfo();
								diffInfo2.secteamDungeonID.Add(list2[k]);
								diffInfo2.dungeonName = tableItem4.Name;
								diffInfo2.iMinLv = tableItem3.RecoLevel;
								diffInfo2.iMaxLv = tableItem3.RecoLevel;
								this.secteamDungeons.Add(tableItem4.Name, diffInfo2);
								diffInfo2.iMaxLv = dictionary[tableItem4.Name];
							}
							else
							{
								diffInfo2.secteamDungeonID.Add(list2[k]);
								if (diffInfo2.iMaxLv < tableItem3.RecoLevel)
								{
								}
								list2.RemoveAt(k);
								k--;
							}
						}
					}
				}
				this.secondMenuID2TargetIDs.Clear();
				this.targetID2secondMenuID.Clear();
				foreach (KeyValuePair<string, DiffInfo> keyValuePair2 in this.secteamDungeons)
				{
					DiffInfo value2 = keyValuePair2.Value;
					if (value2.secteamDungeonID.Count > 0)
					{
						int num2 = value2.secteamDungeonID[0];
						List<int> value3 = new List<int>();
						value3 = value2.secteamDungeonID;
						this.secondMenuID2TargetIDs.Add(num2, value3);
						for (int l = 0; l < value2.secteamDungeonID.Count; l++)
						{
							this.targetID2secondMenuID.Add(value2.secteamDungeonID[l], num2);
						}
					}
				}
				com.ClearSubItem();
				for (int m = 0; m < list2.Count; m++)
				{
					int secteamDungeonID = list2[m];
					TeamListFrame.TeamDungeonNode teamDungeonNode2 = this._getTeamDungeonNodeByID(secteamDungeonID);
					if (teamDungeonNode2 == null)
					{
						TeamDungeonTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(secteamDungeonID, string.Empty, string.Empty);
						if (tableItem5 != null)
						{
							TeamListFrame.TeamDungeonNode teamDungeonNode3 = new TeamListFrame.TeamDungeonNode();
							teamDungeonNode3.id = secteamDungeonID;
							teamDungeonNode3.table = tableItem5;
							this.mAllNodes.Add(teamDungeonNode3);
							teamDungeonNode2 = teamDungeonNode3;
						}
					}
					if (teamDungeonNode2 != null)
					{
						ComCommonBind comCommonBind = com.AddOneSubItem();
						if (null != comCommonBind)
						{
							Toggle com2 = comCommonBind.GetCom<Toggle>("ongroup");
							Text com3 = comCommonBind.GetCom<Text>("name");
							Text com4 = comCommonBind.GetCom<Text>("reclevel");
							com3.text = teamDungeonNode2.table.Name;
							com4.text = string.Format("推荐等级:{0}级", teamDungeonNode2.table.RecoLevel);
							com2.group = this.mSecondGroup;
							com2.onValueChanged.AddListener(delegate(bool svalue)
							{
								this.OnChooseSecondMenu(secteamDungeonID, svalue, null);
							});
							DungeonTable tableItem6 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(teamDungeonNode2.table.DungeonID, string.Empty, string.Empty);
							if (tableItem6 != null)
							{
								DiffInfo diffInfo = new DiffInfo();
								this.secteamDungeons.TryGetValue(tableItem6.Name, out diffInfo);
								if (diffInfo != null)
								{
									com3.text = diffInfo.dungeonName;
									com4.text = string.Format("推荐等级:{0}-{1}级", diffInfo.iMinLv, diffInfo.iMaxLv);
									if (diffInfo.iMaxLv == diffInfo.iMinLv)
									{
										com4.text = string.Format("推荐等级:{0}级", diffInfo.iMinLv);
									}
									com2.onValueChanged.RemoveAllListeners();
									com2.onValueChanged.AddListener(delegate(bool svalue)
									{
										this.OnChooseSecondMenu(secteamDungeonID, svalue, diffInfo.secteamDungeonID);
									});
								}
							}
							teamDungeonNode2.bind = comCommonBind;
							this._updateTeamDungeonNodeByFilter(teamDungeonNode2);
						}
					}
				}
			}
		}

		// Token: 0x0601197A RID: 72058 RVA: 0x00522B04 File Offset: 0x00520F04
		private void OnCreateTeamSuccess(UIEvent uiEvent)
		{
			this._updateState();
			this._tryLoadRightFrame();
			this._updateAutoSelect(this.CurTeamDungeonTableID);
			this._sendSwitchTeamDungeonID(this.CurTeamDungeonTableID, null);
			this.frameMgr.CloseFrame<TeamListFrame>(this, false);
		}

		// Token: 0x0601197B RID: 72059 RVA: 0x00522B38 File Offset: 0x00520F38
		private void CalScrollViewPos(Toggle MenuToggle)
		{
			GameObject gameObject = MenuToggle.transform.parent.gameObject;
			GameObject gameObject2 = gameObject.transform.parent.gameObject;
			GameObject gameObject3 = gameObject2.transform.parent.gameObject;
			float y = gameObject3.GetComponent<RectTransform>().localPosition.y;
			float y2 = this.mTargetRoot.GetComponent<RectTransform>().offsetMax.y;
			float y3 = this.mTargetRoot.GetComponent<RectTransform>().offsetMin.y;
			float num = Math.Abs(y3 - y2);
			if (num != 0f)
			{
				float num2 = 1f - y / num;
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				this.mDungeonScrollList.GetComponent<ScrollRect>().verticalNormalizedPosition = num2;
			}
		}

		// Token: 0x0601197C RID: 72060 RVA: 0x00522C20 File Offset: 0x00521020
		private void _printVec3(string tag, Vector3 pos)
		{
			Debug.LogErrorFormat("{0}:{1},{2},{3}", new object[]
			{
				tag,
				pos.x,
				pos.y,
				pos.z
			});
		}

		// Token: 0x0601197D RID: 72061 RVA: 0x00522C70 File Offset: 0x00521070
		private void _calScrollView(RectTransform obj)
		{
			float height = this.mDungeonScrollList.viewport.rect.height;
			float y = this.mDungeonScrollList.content.sizeDelta.y;
			float num = y - height;
			Debug.LogErrorFormat("full : {0}, viewHeight {1}, height {2}", new object[]
			{
				num,
				height,
				y
			});
			this._printVec3("content", this.mDungeonScrollList.content.position);
			this._printVec3("obj", obj.position);
			if (num > 0f)
			{
				float y2 = this.mDungeonScrollList.content.position.y;
				float num2 = obj.position.y + obj.sizeDelta.y / 2f;
				float num3 = num2 - y2;
				Debug.LogErrorFormat("posTop : {0}, posItemTop {1}, delta {2}", new object[]
				{
					y2,
					num2,
					num3
				});
				if (num3 <= 0f)
				{
					this.mDungeonScrollList.verticalNormalizedPosition = 0f;
				}
				else if (num3 > num)
				{
					this.mDungeonScrollList.verticalNormalizedPosition = 1f;
				}
				else
				{
					this.mDungeonScrollList.verticalNormalizedPosition = num3 / num;
				}
			}
		}

		// Token: 0x0601197E RID: 72062 RVA: 0x00522DE0 File Offset: 0x005211E0
		protected override void _bindExUI()
		{
			this.mSecondGroup = this.mBind.GetCom<ToggleGroup>("secondGroup");
			this.mOnDiffSelect = this.mBind.GetCom<Dropdown>("onDiffSelect");
			this.mOnDiffSelect.onValueChanged.AddListener(new UnityAction<int>(this._onOnDiffSelectDropdownValueChange));
			this.mDungeonScrollList = this.mBind.GetCom<ScrollRect>("dungeonScrollList");
			this.mTargetRoot = this.mBind.GetGameObject("TargetRoot");
			this.mFirstMenutogglegroup = this.mBind.GetCom<ToggleGroup>("firstMenutogglegroup");
			this.mOnClose = this.mBind.GetCom<Button>("onClose");
			this.mOnClose.onClick.AddListener(new UnityAction(this._onOnCloseButtonClick));
			this.mRightRoot = this.mBind.GetGameObject("RightRoot");
			this.togType1 = this.mBind.GetCom<Toggle>("Type1");
			this.togType2 = this.mBind.GetCom<Toggle>("Type2");
			this.togType3 = this.mBind.GetCom<Toggle>("Type3");
			this.togType4 = this.mBind.GetCom<Toggle>("Type4");
			this.togType5 = this.mBind.GetCom<Toggle>("Type5");
			this.togType1.onValueChanged.RemoveAllListeners();
			this.togType1.onValueChanged.AddListener(delegate(bool var)
			{
				this.DiffTypeChange(var, -1);
			});
			this.togType2.onValueChanged.RemoveAllListeners();
			this.togType2.onValueChanged.AddListener(delegate(bool var)
			{
				this.DiffTypeChange(var, 0);
			});
			this.togType3.onValueChanged.RemoveAllListeners();
			this.togType3.onValueChanged.AddListener(delegate(bool var)
			{
				this.DiffTypeChange(var, 1);
			});
			this.togType4.onValueChanged.RemoveAllListeners();
			this.togType4.onValueChanged.AddListener(delegate(bool var)
			{
				this.DiffTypeChange(var, 2);
			});
			this.togType5.onValueChanged.RemoveAllListeners();
			this.togType5.onValueChanged.AddListener(delegate(bool var)
			{
				this.DiffTypeChange(var, 3);
			});
		}

		// Token: 0x0601197F RID: 72063 RVA: 0x00523009 File Offset: 0x00521409
		private void DiffTypeChange(bool val, int hard)
		{
			if (val)
			{
				DataManager<TeamDataManager>.GetInstance().DiffHard = hard;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TeamListUpdateByHard, null, null, null, null);
			}
		}

		// Token: 0x06011980 RID: 72064 RVA: 0x00523030 File Offset: 0x00521430
		protected override void _unbindExUI()
		{
			this.mSecondGroup = null;
			this.mOnDiffSelect.onValueChanged.RemoveListener(new UnityAction<int>(this._onOnDiffSelectDropdownValueChange));
			this.mOnDiffSelect = null;
			this.mDungeonScrollList = null;
			this.mTargetRoot = null;
			this.mFirstMenutogglegroup = null;
			this.mOnClose.onClick.RemoveListener(new UnityAction(this._onOnCloseButtonClick));
			this.mOnClose = null;
			this.mRightRoot = null;
			this.mOnClose = this.mBind.GetCom<Button>("onClose");
			this.mOnClose.onClick.AddListener(new UnityAction(this._onOnCloseButtonClick));
			this.mOnClose = null;
			this.togType1 = null;
			this.togType2 = null;
			this.togType3 = null;
			this.togType4 = null;
			this.togType5 = null;
		}

		// Token: 0x06011981 RID: 72065 RVA: 0x00523104 File Offset: 0x00521504
		private void _onOnDiffSelectDropdownValueChange(int index)
		{
			this.mCurrentFilterIndex = index;
			for (int i = 0; i < this.mAllNodes.Count; i++)
			{
				this._updateTeamDungeonNodeByFilter(this.mAllNodes[i]);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(this.mDungeonScrollList.content);
			this.mDungeonScrollList.verticalNormalizedPosition = 1f;
		}

		// Token: 0x06011982 RID: 72066 RVA: 0x00523166 File Offset: 0x00521566
		private void _onOnCloseButtonClick()
		{
			this.OnCloseBtnClicked();
		}

		// Token: 0x0400B71B RID: 46875
		private eTeamFrameState mState;

		// Token: 0x0400B71C RID: 46876
		private const string kMenuPath = "UIFlatten/Prefabs/Team/TeamMenuGroup";

		// Token: 0x0400B71D RID: 46877
		private int mCurrentFilterIndex;

		// Token: 0x0400B71E RID: 46878
		private bool bStartMatch;

		// Token: 0x0400B71F RID: 46879
		private List<int> FliterFirstMenuList = new List<int>();

		// Token: 0x0400B720 RID: 46880
		private Dictionary<int, List<int>> FliterSecondMenuDict = new Dictionary<int, List<int>>();

		// Token: 0x0400B721 RID: 46881
		private List<TeamListFrame.TeamDungeonNode> mAllNodes = new List<TeamListFrame.TeamDungeonNode>();

		// Token: 0x0400B722 RID: 46882
		public List<GameObject> locks;

		// Token: 0x0400B723 RID: 46883
		private DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x0400B724 RID: 46884
		public Dictionary<string, DiffInfo> secteamDungeons = DataManager<TeamDataManager>.GetInstance().GetDiffInfo();

		// Token: 0x0400B725 RID: 46885
		public Dictionary<int, List<int>> secondMenuID2TargetIDs = new Dictionary<int, List<int>>();

		// Token: 0x0400B726 RID: 46886
		public Dictionary<int, int> targetID2secondMenuID = new Dictionary<int, int>();

		// Token: 0x0400B727 RID: 46887
		private ToggleGroup mSecondGroup;

		// Token: 0x0400B728 RID: 46888
		private Dropdown mOnDiffSelect;

		// Token: 0x0400B729 RID: 46889
		private ScrollRect mDungeonScrollList;

		// Token: 0x0400B72A RID: 46890
		private GameObject mTargetRoot;

		// Token: 0x0400B72B RID: 46891
		private ToggleGroup mFirstMenutogglegroup;

		// Token: 0x0400B72C RID: 46892
		private Button mOnClose;

		// Token: 0x0400B72D RID: 46893
		private GameObject mRightRoot;

		// Token: 0x0400B72E RID: 46894
		private Toggle togType1;

		// Token: 0x0400B72F RID: 46895
		private Toggle togType2;

		// Token: 0x0400B730 RID: 46896
		private Toggle togType3;

		// Token: 0x0400B731 RID: 46897
		private Toggle togType4;

		// Token: 0x0400B732 RID: 46898
		private Toggle togType5;

		// Token: 0x02001C0E RID: 7182
		private class TeamDungeonNode
		{
			// Token: 0x0400B733 RID: 46899
			public int id;

			// Token: 0x0400B734 RID: 46900
			public TeamDungeonTable table;

			// Token: 0x0400B735 RID: 46901
			public ComCommonBind bind;
		}
	}
}
