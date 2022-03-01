using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C1E RID: 7198
	internal class TeamTargetSelect : ClientFrame
	{
		// Token: 0x17001DBB RID: 7611
		// (get) Token: 0x06011A7C RID: 72316 RVA: 0x0052AC58 File Offset: 0x00529058
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

		// Token: 0x06011A7D RID: 72317 RVA: 0x0052AC7A File Offset: 0x0052907A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamTargetSelect";
		}

		// Token: 0x06011A7E RID: 72318 RVA: 0x0052AC81 File Offset: 0x00529081
		public static void OnOpenLinkFrame(string argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06011A7F RID: 72319 RVA: 0x0052AC98 File Offset: 0x00529098
		protected override void _OnOpenFrame()
		{
			this.locks = new List<GameObject>();
			this.locks.Add(Utility.FindChild(this.togType2.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType3.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType4.gameObject, "lock"));
			this.locks.Add(Utility.FindChild(this.togType5.gameObject, "lock"));
			int teamDungeonID;
			if (this.userData != null)
			{
				teamDungeonID = (int)this.userData;
				DataManager<TeamDataManager>.GetInstance().TeamDungeonID = (uint)teamDungeonID;
			}
			else
			{
				teamDungeonID = this.CurTeamDungeonTableID;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				clientSystemTown.MainPlayer.CommandStopMove();
			}
			this._updateState();
			this._loadFirstMenuList();
			this.BindUIEvent();
			this.OnChooseFirstMenu(TeamUtility.GetMenuTeamDungeonID(teamDungeonID), true);
			this.OnChooseSecondMenu(teamDungeonID, true, null);
			this.iCurDungeonID = DataManager<TeamDataManager>.GetInstance().TeamDungeonID;
			List<Toggle> list = new List<Toggle>();
			list.Add(this.togType2);
			list.Add(this.togType3);
			list.Add(this.togType4);
			list.Add(this.togType5);
			int curTeamDungeonTableID = this.CurTeamDungeonTableID;
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(curTeamDungeonTableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (curTeamDungeonTableID == 1 || tableItem.Type == TeamDungeonTable.eType.CityMonster)
				{
					UIGray uigray = this.btnOK.gameObject.SafeAddComponent(false);
					if (null != uigray)
					{
						uigray.enabled = false;
					}
					this.btnOK.interactable = true;
					this.iTargetID = (uint)curTeamDungeonTableID;
					this._updateAutoSelect(curTeamDungeonTableID);
				}
				else
				{
					UIGray uigray2 = this.btnOK.gameObject.SafeAddComponent(false);
					if (null != uigray2)
					{
						uigray2.enabled = true;
					}
					this.btnOK.interactable = false;
					this.iTargetID = (uint)curTeamDungeonTableID;
					this.togType2.isOn = false;
					this.togType3.isOn = false;
					this.togType4.isOn = false;
					this.togType5.isOn = false;
					TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(curTeamDungeonTableID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							DiffInfo diffInfo = new DiffInfo();
							this.secteamDungeons.TryGetValue(tableItem3.Name, out diffInfo);
							if (diffInfo != null)
							{
								if (diffInfo.secteamDungeonID.Contains(curTeamDungeonTableID))
								{
									this._updateAutoSelect(diffInfo.secteamDungeonID[0]);
								}
								int hard = (int)tableItem3.Hard;
								if (hard < list.Count)
								{
									list[hard].isOn = true;
								}
							}
						}
					}
				}
			}
			if (this.CurTeamDungeonTableID == 1)
			{
				this.none.CustomActive(true);
				this.txtTips.CustomActive(false);
				this.btns.CustomActive(false);
			}
		}

		// Token: 0x06011A80 RID: 72320 RVA: 0x0052AFD2 File Offset: 0x005293D2
		private void _updateState()
		{
			this.mState = ((!DataManager<TeamDataManager>.GetInstance().HasTeam()) ? TeamTargetSelect.eTeamFrameState.onList : TeamTargetSelect.eTeamFrameState.onTeam);
		}

		// Token: 0x06011A81 RID: 72321 RVA: 0x0052AFF0 File Offset: 0x005293F0
		protected override void _OnCloseFrame()
		{
			this.Clear();
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamListViewFrame>(null, false);
		}

		// Token: 0x06011A82 RID: 72322 RVA: 0x0052B004 File Offset: 0x00529404
		private new void Clear()
		{
			this.mCurrentFilterIndex = 0;
			this._clearAllCacheNode();
			this.FliterFirstMenuList.Clear();
			this.FliterSecondMenuDict.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x06011A83 RID: 72323 RVA: 0x0052B02F File Offset: 0x0052942F
		private void BindUIEvent()
		{
		}

		// Token: 0x06011A84 RID: 72324 RVA: 0x0052B031 File Offset: 0x00529431
		private void UnBindUIEvent()
		{
		}

		// Token: 0x06011A85 RID: 72325 RVA: 0x0052B033 File Offset: 0x00529433
		private void OnCloseBtnClicked()
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("正在匹配,无法退出", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.CloseFrame<TeamTargetSelect>(this, false);
		}

		// Token: 0x06011A86 RID: 72326 RVA: 0x0052B05C File Offset: 0x0052945C
		private void _updateTeamDungeonNodeByFilter(TeamTargetSelect.TeamDungeonNode node)
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

		// Token: 0x06011A87 RID: 72327 RVA: 0x0052B160 File Offset: 0x00529560
		private TeamTargetSelect.TeamDungeonNode _getParentTeamDungeonNodeByID(int id)
		{
			TeamTargetSelect.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(id);
			if (teamDungeonNode != null && teamDungeonNode.table != null)
			{
				return this._getTeamDungeonNodeByID(teamDungeonNode.table.MenuID);
			}
			return null;
		}

		// Token: 0x06011A88 RID: 72328 RVA: 0x0052B19C File Offset: 0x0052959C
		private TeamTargetSelect.TeamDungeonNode _getTeamDungeonNodeByID(int id)
		{
			TeamTargetSelect.TeamDungeonNode result = null;
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

		// Token: 0x06011A89 RID: 72329 RVA: 0x0052B1FC File Offset: 0x005295FC
		private void OnChooseFirstMenu(int teamDungeonID, bool value)
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (value)
			{
				if (this.btns != null)
				{
					this.btns.CustomActive(false);
				}
				if (this.txtTips != null)
				{
					this.txtTips.CustomActive(true);
				}
				this._createSecondMenuToggleList(teamDungeonID);
				this._sendSwitchTeamDungeonID(teamDungeonID);
				this.iCurDungeonID = (uint)teamDungeonID;
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					bool flag = false;
					int num = 0;
					List<int> list = new List<int>();
					bool flag2 = this.FliterSecondMenuDict.TryGetValue(teamDungeonID, out list);
					if (flag2)
					{
						for (int i = 0; i < list.Count; i++)
						{
							TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list[i], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (tableItem2.Type == TeamDungeonTable.eType.CityMonster)
								{
									flag = true;
									num = list[i];
									break;
								}
							}
						}
					}
					if (teamDungeonID == 1 || flag)
					{
						this.none.CustomActive(true);
						this.txtTips.CustomActive(false);
						this.btns.CustomActive(false);
					}
					else
					{
						this.none.CustomActive(false);
						this.txtTips.CustomActive(true);
						this.btns.CustomActive(false);
					}
					if (teamDungeonID == 1 || flag)
					{
						UIGray uigray = this.btnOK.gameObject.SafeAddComponent(false);
						if (null != uigray)
						{
							uigray.enabled = false;
						}
						this.btnOK.interactable = true;
						this.iTargetID = (uint)teamDungeonID;
						if (flag)
						{
							this.iTargetID = (uint)num;
						}
					}
					else
					{
						UIGray uigray2 = this.btnOK.gameObject.SafeAddComponent(false);
						if (null != uigray2)
						{
							uigray2.enabled = true;
						}
						this.btnOK.interactable = false;
						this.iTargetID = 0U;
					}
				}
			}
		}

		// Token: 0x06011A8A RID: 72330 RVA: 0x0052B407 File Offset: 0x00529807
		private void _sendSwitchTeamDungeonID(int teamDungeonID)
		{
		}

		// Token: 0x06011A8B RID: 72331 RVA: 0x0052B40C File Offset: 0x0052980C
		private void OnChooseSecondMenu(int teamDungeonID, bool value, List<int> dungeonIDs = null)
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (value)
			{
				if (this.btns != null)
				{
					this.btns.CustomActive(true);
				}
				if (this.txtTips != null)
				{
					this.txtTips.CustomActive(false);
				}
				if (teamDungeonID == 1)
				{
					if (this.btns != null)
					{
						this.btns.CustomActive(false);
					}
					if (this.txtTips != null)
					{
						this.txtTips.CustomActive(true);
					}
					this.iTargetID = (uint)teamDungeonID;
				}
				TeamTargetSelect.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamDungeonID);
				if (teamDungeonNode != null)
				{
					this._sendSwitchTeamDungeonID(teamDungeonID);
				}
				this.iCurDungeonID = (uint)teamDungeonID;
				if (this.iCurDungeonID == 1U)
				{
					UIGray uigray = this.btnOK.gameObject.SafeAddComponent(false);
					if (null != uigray)
					{
						uigray.enabled = true;
					}
					this.btnOK.interactable = false;
				}
				this.UpdateAllTypeLockState(teamDungeonID);
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (teamDungeonID == 1 || tableItem.Type == TeamDungeonTable.eType.CityMonster)
					{
						this.none.CustomActive(true);
						this.txtTips.CustomActive(false);
						this.btns.CustomActive(false);
					}
					else
					{
						this.none.CustomActive(false);
						this.txtTips.CustomActive(false);
						this.btns.CustomActive(true);
					}
					if (teamDungeonID == 1 || tableItem.Type == TeamDungeonTable.eType.CityMonster)
					{
						UIGray uigray2 = this.btnOK.gameObject.SafeAddComponent(false);
						if (null != uigray2)
						{
							uigray2.enabled = false;
						}
						this.btnOK.interactable = true;
						this.iTargetID = (uint)teamDungeonID;
					}
					else
					{
						UIGray uigray3 = this.btnOK.gameObject.SafeAddComponent(false);
						if (null != uigray3)
						{
							uigray3.enabled = false;
						}
						this.btnOK.interactable = true;
						this.iTargetID = 0U;
						this.togType2.isOn = true;
						this.togType3.isOn = false;
						this.togType4.isOn = false;
						this.togType5.isOn = false;
						TeamDungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							DungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem2.DungeonID, string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								DiffInfo diffInfo = new DiffInfo();
								this.secteamDungeons.TryGetValue(tableItem3.Name, out diffInfo);
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
												if (tableItem5.Hard == DungeonTable.eHard.NORMAL)
												{
													this.iTargetID = (uint)diffInfo.secteamDungeonID[i];
													break;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06011A8C RID: 72332 RVA: 0x0052B766 File Offset: 0x00529B66
		private void _onTeamInfoUpdateSuccess(UIEvent ui)
		{
		}

		// Token: 0x06011A8D RID: 72333 RVA: 0x0052B768 File Offset: 0x00529B68
		private void UpdateAllTypeLockState(int teamDungeonID)
		{
			List<Toggle> list = new List<Toggle>();
			list.Add(this.togType2);
			list.Add(this.togType3);
			list.Add(this.togType4);
			list.Add(this.togType5);
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			for (int i = 0; i < this.locks.Count; i++)
			{
				GameObject gameObject = this.locks[i];
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				Toggle toggle = list[j];
				if (toggle != null)
				{
					toggle.CustomActive(true);
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
				if (DataManager<TeamDataManager>.GetInstance().IsDuoLuoTeamDungeonID(teamDungeonID))
				{
					flag = true;
				}
				else if (DungeonUtility.IsWeekHellEntryDungeon(tableItem.DungeonID))
				{
					flag2 = true;
				}
				flag3 = DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(tableItem.DungeonID);
				flag4 = TeamUtility.IsEliteDungeonID(tableItem.DungeonID);
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
						for (int k = 0; k < diffInfo.secteamDungeonID.Count; k++)
						{
							TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(diffInfo.secteamDungeonID[k], string.Empty, string.Empty);
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
			for (int l = (int)(eHard + 1); l < this.locks.Count; l++)
			{
				GameObject gameObject2 = this.locks[l];
				if (gameObject2 != null)
				{
					gameObject2.CustomActive(true);
				}
			}
			for (int m = 0; m < list.Count; m++)
			{
				Toggle toggle2 = list[m];
				if (toggle2 != null)
				{
					toggle2.interactable = true;
				}
			}
			for (int n = (int)(eHard + 1); n < list.Count; n++)
			{
				Toggle toggle3 = list[n];
				if (toggle3 != null)
				{
					toggle3.interactable = false;
				}
			}
			if (flag || flag2 || flag3 || flag4)
			{
				for (int num = 0; num < this.locks.Count; num++)
				{
					GameObject gameObject3 = this.locks[num];
					if (gameObject3 != null)
					{
						gameObject3.CustomActive(false);
					}
				}
				for (int num2 = 0; num2 < list.Count; num2++)
				{
					Toggle toggle4 = list[num2];
					if (toggle4 != null)
					{
						toggle4.CustomActive(false);
					}
				}
				this.togType2.CustomActive(true);
				this.togType2.SafeSetToggleOnState(true);
			}
			if (flag || flag2)
			{
				this.normalDiffText.SafeSetText("王者");
			}
			else
			{
				this.normalDiffText.SafeSetText("普通");
			}
		}

		// Token: 0x06011A8E RID: 72334 RVA: 0x0052BB4C File Offset: 0x00529F4C
		private void _tryLoadRightFrame()
		{
		}

		// Token: 0x06011A8F RID: 72335 RVA: 0x0052BB50 File Offset: 0x00529F50
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

		// Token: 0x06011A90 RID: 72336 RVA: 0x0052BBC0 File Offset: 0x00529FC0
		private void _clearAllCacheNode()
		{
			for (int i = 0; i < this.mAllNodes.Count; i++)
			{
				if (this.mAllNodes[i].table.Type == TeamDungeonTable.eType.DUNGEON && this.mAllNodes[i] != null && this.mAllNodes[i].bind != null)
				{
					this.mAllNodes[i].bind.ClearAllCacheBinds();
					this.mAllNodes[i].bind = null;
				}
			}
			for (int j = 0; j < this.mAllNodes.Count; j++)
			{
				if (this.mAllNodes[j].table.Type != TeamDungeonTable.eType.DUNGEON && this.mAllNodes[j] != null && this.mAllNodes[j].bind != null)
				{
					this.mAllNodes[j].bind.ClearAllCacheBinds();
					this.mAllNodes[j].bind = null;
				}
			}
			this.mBind.ClearCacheBinds("UIFlatten/Prefabs/Team/TeamMenuGroup");
			this.mAllNodes.Clear();
		}

		// Token: 0x06011A91 RID: 72337 RVA: 0x0052BD00 File Offset: 0x0052A100
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

		// Token: 0x06011A92 RID: 72338 RVA: 0x0052BD60 File Offset: 0x0052A160
		private void _selectNodeByID(int teamDungeonID, bool isOn)
		{
			TeamTargetSelect.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamDungeonID);
			if (teamDungeonNode != null)
			{
				Toggle com = teamDungeonNode.bind.GetCom<Toggle>("ongroup");
				com.isOn = isOn;
			}
		}

		// Token: 0x06011A93 RID: 72339 RVA: 0x0052BD93 File Offset: 0x0052A193
		private bool _isFirstMenuOn(int menuTeamDungeonID)
		{
			return TeamUtility.GetMenuTeamDungeonID(this.CurTeamDungeonTableID) == menuTeamDungeonID;
		}

		// Token: 0x06011A94 RID: 72340 RVA: 0x0052BDA4 File Offset: 0x0052A1A4
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
						TeamTargetSelect.TeamDungeonNode teamDungeonNode = new TeamTargetSelect.TeamDungeonNode();
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

		// Token: 0x06011A95 RID: 72341 RVA: 0x0052BF0C File Offset: 0x0052A30C
		private void _createSecondMenuToggleList(int teamMenuDungeonID)
		{
			TeamTargetSelect.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamMenuDungeonID);
			if (teamDungeonNode != null && !TeamUtility.IsNormalTeamDungeonID(teamMenuDungeonID) && this.FliterSecondMenuDict.ContainsKey(teamDungeonNode.id))
			{
				ComSwitchNode com = teamDungeonNode.bind.GetCom<ComSwitchNode>("switchNode");
				GameObject gameObject = teamDungeonNode.bind.GetGameObject("content");
				List<int> list = this.FliterSecondMenuDict[teamDungeonNode.id];
				List<int> list2 = new List<int>();
				for (int i = 0; i < list.Count; i++)
				{
					list2.Add(list[i]);
				}
				this.secteamDungeons.Clear();
				for (int j = 0; j < list2.Count; j++)
				{
					TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(list2[j], string.Empty, string.Empty);
					if (tableItem != null)
					{
						DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							DiffInfo diffInfo2 = new DiffInfo();
							this.secteamDungeons.TryGetValue(tableItem2.Name, out diffInfo2);
							if (diffInfo2 == null)
							{
								diffInfo2 = new DiffInfo();
								diffInfo2.secteamDungeonID.Add(list2[j]);
								diffInfo2.dungeonName = tableItem2.Name;
								diffInfo2.iMinLv = tableItem.RecoLevel;
								diffInfo2.iMaxLv = tableItem.RecoLevel;
								this.secteamDungeons.Add(tableItem2.Name, diffInfo2);
							}
							else
							{
								diffInfo2.secteamDungeonID.Add(list2[j]);
								if (diffInfo2.iMaxLv < tableItem.RecoLevel)
								{
									diffInfo2.iMaxLv = tableItem.RecoLevel;
								}
								list2.RemoveAt(j);
								j--;
							}
						}
					}
				}
				com.ClearSubItem();
				for (int k = 0; k < list2.Count; k++)
				{
					int secteamDungeonID = list2[k];
					TeamTargetSelect.TeamDungeonNode teamDungeonNode2 = this._getTeamDungeonNodeByID(secteamDungeonID);
					if (teamDungeonNode2 == null)
					{
						TeamDungeonTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(secteamDungeonID, string.Empty, string.Empty);
						if (tableItem3 != null)
						{
							TeamTargetSelect.TeamDungeonNode teamDungeonNode3 = new TeamTargetSelect.TeamDungeonNode();
							teamDungeonNode3.id = secteamDungeonID;
							teamDungeonNode3.table = tableItem3;
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
							com2.isOn = (this.CurTeamDungeonTableID == secteamDungeonID);
							com2.onValueChanged.AddListener(delegate(bool svalue)
							{
								this.OnChooseSecondMenu(secteamDungeonID, svalue, null);
							});
							DungeonTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(teamDungeonNode2.table.DungeonID, string.Empty, string.Empty);
							if (tableItem4 != null)
							{
								DiffInfo diffInfo = new DiffInfo();
								this.secteamDungeons.TryGetValue(tableItem4.Name, out diffInfo);
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

		// Token: 0x06011A96 RID: 72342 RVA: 0x0052C37B File Offset: 0x0052A77B
		private void OnCreateTeamSuccess(UIEvent uiEvent)
		{
			this._updateState();
			this._tryLoadRightFrame();
			this._updateAutoSelect(this.CurTeamDungeonTableID);
			this._sendSwitchTeamDungeonID(this.CurTeamDungeonTableID);
		}

		// Token: 0x06011A97 RID: 72343 RVA: 0x0052C3A4 File Offset: 0x0052A7A4
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

		// Token: 0x06011A98 RID: 72344 RVA: 0x0052C48C File Offset: 0x0052A88C
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

		// Token: 0x06011A99 RID: 72345 RVA: 0x0052C4DC File Offset: 0x0052A8DC
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

		// Token: 0x06011A9A RID: 72346 RVA: 0x0052C64C File Offset: 0x0052AA4C
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
			this.btns = this.mBind.GetGameObject("btns");
			this.txtTips = this.mBind.GetCom<Text>("txtTips");
			this.none = this.mBind.GetGameObject("none");
			this.btnOK = this.mBind.GetCom<Button>("btnOK");
			if (this.btnOK != null)
			{
				this.btnOK.onClick.RemoveAllListeners();
				this.btnOK.onClick.AddListener(delegate()
				{
					if (DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
					{
						int num = (int)this.iTargetID;
						TeamDungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<TeamDungeonTable>(num, string.Empty, string.Empty);
						if (tableItem != null && (tableItem.Type == TeamDungeonTable.eType.DUNGEON || tableItem.Type == TeamDungeonTable.eType.CityMonster || num == 1))
						{
							DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.Target, num);
						}
					}
					this.frameMgr.CloseFrame<TeamTargetSelect>(this, false);
				});
			}
			this.normalDiffText = this.mBind.GetCom<Text>("normalDiffText");
		}

		// Token: 0x06011A9B RID: 72347 RVA: 0x0052C920 File Offset: 0x0052AD20
		private void DiffTypeChange(bool val, int hard)
		{
			if (hard == -1)
			{
				return;
			}
			if (val)
			{
				this.iTargetID = 0U;
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.iCurDungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.DungeonID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						DiffInfo diffInfo = new DiffInfo();
						this.secteamDungeons.TryGetValue(tableItem2.Name, out diffInfo);
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
										if (tableItem4.Hard == (DungeonTable.eHard)hard)
										{
											this.iTargetID = (uint)diffInfo.secteamDungeonID[i];
											break;
										}
									}
								}
							}
						}
					}
				}
				if (this.btnOK != null)
				{
					UIGray uigray = this.btnOK.gameObject.SafeAddComponent(false);
					if (null != uigray)
					{
						uigray.enabled = (this.iTargetID == 0U);
					}
					this.btnOK.interactable = (this.iTargetID > 0U);
					if (this.iTargetID == 0U)
					{
						TeamDungeonTable tableItem5 = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)this.iCurDungeonID, string.Empty, string.Empty);
						if (tableItem5 != null && tableItem5.Type == TeamDungeonTable.eType.CityMonster && hard == 0)
						{
							this.iTargetID = this.iCurDungeonID;
							if (null != uigray)
							{
								uigray.enabled = false;
							}
							this.btnOK.interactable = true;
						}
					}
				}
			}
		}

		// Token: 0x06011A9C RID: 72348 RVA: 0x0052CB10 File Offset: 0x0052AF10
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
			this.btnOK = null;
			this.txtTips = null;
			this.none = null;
			this.btns = null;
			this.normalDiffText = null;
		}

		// Token: 0x06011A9D RID: 72349 RVA: 0x0052CC08 File Offset: 0x0052B008
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

		// Token: 0x06011A9E RID: 72350 RVA: 0x0052CC6A File Offset: 0x0052B06A
		private void _onOnCloseButtonClick()
		{
			this.OnCloseBtnClicked();
		}

		// Token: 0x0400B7F0 RID: 47088
		private TeamTargetSelect.eTeamFrameState mState;

		// Token: 0x0400B7F1 RID: 47089
		private const string kMenuPath = "UIFlatten/Prefabs/Team/TeamMenuGroup";

		// Token: 0x0400B7F2 RID: 47090
		private int mCurrentFilterIndex;

		// Token: 0x0400B7F3 RID: 47091
		private bool bStartMatch;

		// Token: 0x0400B7F4 RID: 47092
		private List<int> FliterFirstMenuList = new List<int>();

		// Token: 0x0400B7F5 RID: 47093
		private Dictionary<int, List<int>> FliterSecondMenuDict = new Dictionary<int, List<int>>();

		// Token: 0x0400B7F6 RID: 47094
		private List<TeamTargetSelect.TeamDungeonNode> mAllNodes = new List<TeamTargetSelect.TeamDungeonNode>();

		// Token: 0x0400B7F7 RID: 47095
		public List<GameObject> locks;

		// Token: 0x0400B7F8 RID: 47096
		private DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x0400B7F9 RID: 47097
		private Dictionary<string, DiffInfo> secteamDungeons = new Dictionary<string, DiffInfo>();

		// Token: 0x0400B7FA RID: 47098
		private ToggleGroup mSecondGroup;

		// Token: 0x0400B7FB RID: 47099
		private Dropdown mOnDiffSelect;

		// Token: 0x0400B7FC RID: 47100
		private ScrollRect mDungeonScrollList;

		// Token: 0x0400B7FD RID: 47101
		private GameObject mTargetRoot;

		// Token: 0x0400B7FE RID: 47102
		private ToggleGroup mFirstMenutogglegroup;

		// Token: 0x0400B7FF RID: 47103
		private Button mOnClose;

		// Token: 0x0400B800 RID: 47104
		private GameObject mRightRoot;

		// Token: 0x0400B801 RID: 47105
		private Toggle togType1;

		// Token: 0x0400B802 RID: 47106
		private Toggle togType2;

		// Token: 0x0400B803 RID: 47107
		private Toggle togType3;

		// Token: 0x0400B804 RID: 47108
		private Toggle togType4;

		// Token: 0x0400B805 RID: 47109
		private Toggle togType5;

		// Token: 0x0400B806 RID: 47110
		private GameObject btns;

		// Token: 0x0400B807 RID: 47111
		private Text txtTips;

		// Token: 0x0400B808 RID: 47112
		private Button btnOK;

		// Token: 0x0400B809 RID: 47113
		private GameObject none;

		// Token: 0x0400B80A RID: 47114
		private Text normalDiffText;

		// Token: 0x0400B80B RID: 47115
		private uint iCurDungeonID;

		// Token: 0x0400B80C RID: 47116
		private uint iTargetID;

		// Token: 0x02001C1F RID: 7199
		public enum eTeamFrameState
		{
			// Token: 0x0400B80E RID: 47118
			onNone,
			// Token: 0x0400B80F RID: 47119
			onList,
			// Token: 0x0400B810 RID: 47120
			onTeam
		}

		// Token: 0x02001C20 RID: 7200
		private class TeamDungeonNode
		{
			// Token: 0x0400B811 RID: 47121
			public int id;

			// Token: 0x0400B812 RID: 47122
			public TeamDungeonTable table;

			// Token: 0x0400B813 RID: 47123
			public ComCommonBind bind;
		}
	}
}
