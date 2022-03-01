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
	// Token: 0x020019B5 RID: 6581
	internal class Pk3v3CrossMyTeamFrame : ClientFrame
	{
		// Token: 0x17001D28 RID: 7464
		// (get) Token: 0x0601011C RID: 65820 RVA: 0x00476CBC File Offset: 0x004750BC
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

		// Token: 0x0601011D RID: 65821 RVA: 0x00476CDE File Offset: 0x004750DE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossMyTeam";
		}

		// Token: 0x0601011E RID: 65822 RVA: 0x00476CE5 File Offset: 0x004750E5
		public static void OnOpenLinkFrame(string argv)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601011F RID: 65823 RVA: 0x00476CF9 File Offset: 0x004750F9
		private int GetLimitStartLv()
		{
			return Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_SCORE_WAR_LEVEL);
		}

		// Token: 0x06010120 RID: 65824 RVA: 0x00476D08 File Offset: 0x00475108
		protected override void _OnOpenFrame()
		{
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
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			Pk3v3CrossDataManager.ScoreListItem myRankInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetMyRankInfo();
			if (pkInfo != null && myRankInfo != null)
			{
				if (this.txtPkCount != null)
				{
					this.txtPkCount.text = string.Format("比赛次数:{0}/{1}", pkInfo.nCurPkCount, 5);
				}
				if (this.txtmyScore != null)
				{
					this.txtmyScore.text = string.Format("个人积分:{0}", pkInfo.nScore);
				}
				if (this.txtmyrRank != null)
				{
					this.txtmyrRank.text = string.Format("个人排名:{0}", myRankInfo.nRank);
				}
			}
			this.OnChooseFirstMenu(TeamUtility.GetMenuTeamDungeonID(teamDungeonID), true);
			this.OnChooseSecondMenu(teamDungeonID, true);
			this.OnPk3v3RoomInfoUpdate(null);
		}

		// Token: 0x06010121 RID: 65825 RVA: 0x00476E5A File Offset: 0x0047525A
		private void _updateState()
		{
			this.mState = ((!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam()) ? eTeamFrameState.onList : eTeamFrameState.onTeam);
		}

		// Token: 0x06010122 RID: 65826 RVA: 0x00476E78 File Offset: 0x00475278
		protected override void _OnCloseFrame()
		{
			this.Clear();
			Singleton<ClientSystemManager>.instance.CloseFrame<Pk3v3CrossTeamMyFrame>(null, false);
		}

		// Token: 0x06010123 RID: 65827 RVA: 0x00476E8C File Offset: 0x0047528C
		private new void Clear()
		{
			this.mCurrentFilterIndex = 0;
			this._clearAllCacheNode();
			this.FliterFirstMenuList.Clear();
			this.FliterSecondMenuDict.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x06010124 RID: 65828 RVA: 0x00476EB8 File Offset: 0x004752B8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
		}

		// Token: 0x06010125 RID: 65829 RVA: 0x00476F34 File Offset: 0x00475334
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
		}

		// Token: 0x06010126 RID: 65830 RVA: 0x00476FB0 File Offset: 0x004753B0
		private void UpdateDropListBtnState()
		{
			this.mOnDiffSelect.interactable = DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader();
			this.mOnLevelSelect.interactable = DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader();
			if (this.mOnDiffSelect.interactable && this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				this.mOnDiffSelect.interactable = false;
			}
			if (this.mOnLevelSelect.interactable && this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				this.mOnLevelSelect.interactable = false;
			}
		}

		// Token: 0x06010127 RID: 65831 RVA: 0x00477041 File Offset: 0x00475441
		private void OnBeginMatch(UIEvent iEvent)
		{
			this.UpdateDropListBtnState();
		}

		// Token: 0x06010128 RID: 65832 RVA: 0x00477049 File Offset: 0x00475449
		private void OnCancelMatch(UIEvent iEvent)
		{
			this.UpdateDropListBtnState();
		}

		// Token: 0x06010129 RID: 65833 RVA: 0x00477051 File Offset: 0x00475451
		private void OnPk3v3RoomInfoUpdate(UIEvent iEvent)
		{
			this.UpdateDropListBtnState();
			this.OnPk3v3RoomSimpleInfoUpdate(null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3RoomSlotInfoUpdate, null, null, null, null);
		}

		// Token: 0x0601012A RID: 65834 RVA: 0x00477074 File Offset: 0x00475474
		private void OnPk3v3RoomSimpleInfoUpdate(UIEvent iEvent)
		{
			this.UpdateDropListBtnState();
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			int num = this.mOnDiffSelect.value;
			for (int i = 0; i < this.seasonLvs.Length; i++)
			{
				int num2 = 0;
				int.TryParse(this.seasonLvs[i], out num2);
				if (roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel > 0 && roomInfo.roomSimpleInfo.limitPlayerSeasonLevel == (uint)DataManager<Pk3v3CrossDataManager>.GetInstance().GetRankLvByIndex(i))
				{
					num = i;
					break;
				}
			}
			if (this.mOnDiffSelect.value != num)
			{
				this.mOnDiffSelect.value = num;
			}
			num = this.mOnLevelSelect.value;
			for (int j = 0; j < this.limitLvs.Length; j++)
			{
				int num3 = 0;
				int.TryParse(this.limitLvs[j], out num3);
				if (roomInfo.roomSimpleInfo.isLimitPlayerLevel > 0 && (int)roomInfo.roomSimpleInfo.limitPlayerLevel == num3)
				{
					num = j;
					break;
				}
			}
			if (this.mOnLevelSelect.value != num)
			{
				this.mOnLevelSelect.value = num;
			}
		}

		// Token: 0x0601012B RID: 65835 RVA: 0x004771A5 File Offset: 0x004755A5
		private void OnCloseBtnClicked()
		{
			if (this.bStartMatch)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("正在匹配,无法退出", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this.frameMgr.CloseFrame<Pk3v3CrossMyTeamFrame>(this, false);
		}

		// Token: 0x0601012C RID: 65836 RVA: 0x004771CC File Offset: 0x004755CC
		private void _updateTeamDungeonNodeByFilter(Pk3v3CrossMyTeamFrame.TeamDungeonNode node)
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

		// Token: 0x0601012D RID: 65837 RVA: 0x004772D0 File Offset: 0x004756D0
		private Pk3v3CrossMyTeamFrame.TeamDungeonNode _getParentTeamDungeonNodeByID(int id)
		{
			Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(id);
			if (teamDungeonNode != null && teamDungeonNode.table != null)
			{
				return this._getTeamDungeonNodeByID(teamDungeonNode.table.MenuID);
			}
			return null;
		}

		// Token: 0x0601012E RID: 65838 RVA: 0x0047730C File Offset: 0x0047570C
		private Pk3v3CrossMyTeamFrame.TeamDungeonNode _getTeamDungeonNodeByID(int id)
		{
			Pk3v3CrossMyTeamFrame.TeamDungeonNode result = null;
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

		// Token: 0x0601012F RID: 65839 RVA: 0x0047736C File Offset: 0x0047576C
		private void OnChooseFirstMenu(int teamDungeonID, bool value)
		{
		}

		// Token: 0x06010130 RID: 65840 RVA: 0x00477370 File Offset: 0x00475770
		private void _sendSwitchTeamDungeonID(int teamDungeonID)
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
						if (tableItem != null && tableItem.Type == TeamDungeonTable.eType.DUNGEON)
						{
							DataManager<TeamDataManager>.GetInstance().ChangeTeamInfo(TeamOptionOperType.Target, teamDungeonID);
						}
					}
				}
			}
			else
			{
				DataManager<TeamDataManager>.GetInstance().RequestSearchTeam((uint)teamDungeonID);
			}
		}

		// Token: 0x06010131 RID: 65841 RVA: 0x004773F4 File Offset: 0x004757F4
		private void OnChooseSecondMenu(int teamDungeonID, bool value)
		{
		}

		// Token: 0x06010132 RID: 65842 RVA: 0x004773F6 File Offset: 0x004757F6
		private void _onTeamInfoUpdateSuccess(UIEvent ui)
		{
		}

		// Token: 0x06010133 RID: 65843 RVA: 0x004773F8 File Offset: 0x004757F8
		private void _tryLoadRightFrame()
		{
			eTeamFrameState eTeamFrameState = this.mState;
			if (eTeamFrameState != eTeamFrameState.onList)
			{
				if (eTeamFrameState == eTeamFrameState.onTeam)
				{
					Singleton<ClientSystemManager>.instance.OpenFrame(typeof(Pk3v3CrossTeamMyFrame), this.mRightRoot, null, string.Empty, FrameLayer.Invalid);
				}
			}
		}

		// Token: 0x06010134 RID: 65844 RVA: 0x0047744C File Offset: 0x0047584C
		private void _updateAutoSelect(int teamDungeonID)
		{
			TeamUtility.eType teamDungeonType = TeamUtility.GetTeamDungeonType(teamDungeonID);
			if (teamDungeonType != TeamUtility.eType.NoTarget && teamDungeonType != TeamUtility.eType.Menu)
			{
				if (teamDungeonType == TeamUtility.eType.Dungeon)
				{
					this._selectNodeByID(TeamUtility.GetMenuTeamDungeonID(teamDungeonID), true);
					this._selectNodeByID(teamDungeonID, true);
				}
			}
			else
			{
				this._selectNodeByID(teamDungeonID, true);
			}
		}

		// Token: 0x06010135 RID: 65845 RVA: 0x004774A0 File Offset: 0x004758A0
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

		// Token: 0x06010136 RID: 65846 RVA: 0x004775A8 File Offset: 0x004759A8
		private void _loadFirstMenuList()
		{
			this._clearAllCacheNode();
			this.FliterSecondMenuDict.Clear();
			this.FliterFirstMenuList = Utility.GetTeamDungeonMenuFliterList(ref this.FliterSecondMenuDict);
			this._tryLoadRightFrame();
		}

		// Token: 0x06010137 RID: 65847 RVA: 0x004775D4 File Offset: 0x004759D4
		private void _selectNodeByID(int teamDungeonID, bool isOn)
		{
			Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(this.CurTeamDungeonTableID);
			if (teamDungeonNode != null)
			{
				Toggle com = teamDungeonNode.bind.GetCom<Toggle>("ongroup");
				com.isOn = isOn;
			}
		}

		// Token: 0x06010138 RID: 65848 RVA: 0x0047760C File Offset: 0x00475A0C
		private bool _isFirstMenuOn(int menuTeamDungeonID)
		{
			return TeamUtility.GetMenuTeamDungeonID(this.CurTeamDungeonTableID) == menuTeamDungeonID;
		}

		// Token: 0x06010139 RID: 65849 RVA: 0x0047761C File Offset: 0x00475A1C
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
						Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode = new Pk3v3CrossMyTeamFrame.TeamDungeonNode();
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
								this.OnChooseSecondMenu(teamDungeonID, value);
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

		// Token: 0x0601013A RID: 65850 RVA: 0x00477784 File Offset: 0x00475B84
		private void _createSecondMenuToggleList(int teamMenuDungeonID)
		{
			Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode = this._getTeamDungeonNodeByID(teamMenuDungeonID);
			if (teamDungeonNode != null && !TeamUtility.IsNormalTeamDungeonID(teamMenuDungeonID) && this.FliterSecondMenuDict.ContainsKey(teamDungeonNode.id))
			{
				ComSwitchNode com = teamDungeonNode.bind.GetCom<ComSwitchNode>("switchNode");
				GameObject gameObject = teamDungeonNode.bind.GetGameObject("content");
				List<int> list = this.FliterSecondMenuDict[teamDungeonNode.id];
				com.ClearSubItem();
				for (int i = 0; i < list.Count; i++)
				{
					int secteamDungeonID = list[i];
					Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode2 = this._getTeamDungeonNodeByID(secteamDungeonID);
					if (teamDungeonNode2 == null)
					{
						TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(secteamDungeonID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							Pk3v3CrossMyTeamFrame.TeamDungeonNode teamDungeonNode3 = new Pk3v3CrossMyTeamFrame.TeamDungeonNode();
							teamDungeonNode3.id = secteamDungeonID;
							teamDungeonNode3.table = tableItem;
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
								this.OnChooseSecondMenu(secteamDungeonID, svalue);
							});
							teamDungeonNode2.bind = comCommonBind;
							this._updateTeamDungeonNodeByFilter(teamDungeonNode2);
						}
					}
				}
			}
		}

		// Token: 0x0601013B RID: 65851 RVA: 0x00477964 File Offset: 0x00475D64
		private void OnCreateTeamSuccess(UIEvent uiEvent)
		{
			this._updateState();
			this._tryLoadRightFrame();
			this._updateAutoSelect(this.CurTeamDungeonTableID);
			this._sendSwitchTeamDungeonID(this.CurTeamDungeonTableID);
		}

		// Token: 0x0601013C RID: 65852 RVA: 0x0047798C File Offset: 0x00475D8C
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

		// Token: 0x0601013D RID: 65853 RVA: 0x00477A73 File Offset: 0x00475E73
		private void _printVec3(string tag, Vector3 pos)
		{
		}

		// Token: 0x0601013E RID: 65854 RVA: 0x00477A78 File Offset: 0x00475E78
		private void _calScrollView(RectTransform obj)
		{
			float height = this.mDungeonScrollList.viewport.rect.height;
			float y = this.mDungeonScrollList.content.sizeDelta.y;
			float num = y - height;
			this._printVec3("content", this.mDungeonScrollList.content.position);
			this._printVec3("obj", obj.position);
			if (num > 0f)
			{
				float y2 = this.mDungeonScrollList.content.position.y;
				float num2 = obj.position.y + obj.sizeDelta.y / 2f;
				float num3 = num2 - y2;
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

		// Token: 0x0601013F RID: 65855 RVA: 0x00477B8C File Offset: 0x00475F8C
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
			this.mOnLevelSelect = this.mBind.GetCom<Dropdown>("onLevelSelect");
			this.mOnLevelSelect.onValueChanged.AddListener(new UnityAction<int>(this._onOnLevelSelectDropdownValueChange));
			this.mOnDiffSelect.options.Clear();
			for (int i = 0; i < this.seasonLvs.Length; i++)
			{
				this.mOnDiffSelect.options.Add(new Dropdown.OptionData(this.seasonLvs[i]));
			}
			string text = DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv.ToString();
			this.limitLvs = new string[]
			{
				"40",
				"45",
				"50",
				"55",
				text
			};
			List<string> list = new List<string>();
			if (list != null)
			{
				for (int j = this.GetLimitStartLv(); j <= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv; j += 5)
				{
					list.Add(j.ToString());
				}
				this.limitLvs = list.ToArray();
			}
			this.mOnLevelSelect.options.Clear();
			for (int k = 0; k < this.limitLvs.Length; k++)
			{
				this.mOnLevelSelect.options.Add(new Dropdown.OptionData(this.limitLvs[k]));
			}
		}

		// Token: 0x06010140 RID: 65856 RVA: 0x00477DC8 File Offset: 0x004761C8
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
			this.mOnLevelSelect.onValueChanged.RemoveListener(new UnityAction<int>(this._onOnLevelSelectDropdownValueChange));
			this.mOnLevelSelect = null;
		}

		// Token: 0x06010141 RID: 65857 RVA: 0x00477E64 File Offset: 0x00476264
		private void _onOnDiffSelectDropdownValueChange(int index)
		{
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null when save room setting data.");
				return;
			}
			if (index >= this.seasonLvs.Length)
			{
				return;
			}
			WorldUpdateRoomReq worldUpdateRoomReq = new WorldUpdateRoomReq();
			worldUpdateRoomReq.roomId = roomInfo.roomSimpleInfo.id;
			worldUpdateRoomReq.roomType = roomInfo.roomSimpleInfo.roomType;
			worldUpdateRoomReq.name = roomInfo.roomSimpleInfo.name;
			worldUpdateRoomReq.password = DataManager<Pk3v3CrossDataManager>.GetInstance().PassWord;
			worldUpdateRoomReq.isLimitPlayerLevel = roomInfo.roomSimpleInfo.isLimitPlayerLevel;
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = ((index <= 0) ? 0 : 1);
			worldUpdateRoomReq.limitPlayerLevel = roomInfo.roomSimpleInfo.limitPlayerLevel;
			worldUpdateRoomReq.limitPlayerSeasonLevel = (uint)DataManager<Pk3v3CrossDataManager>.GetInstance().GetRankLvByIndex(index);
			worldUpdateRoomReq.isLimitPlayerLevel = 1;
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRoomReq>(ServerType.GATE_SERVER, worldUpdateRoomReq);
		}

		// Token: 0x06010142 RID: 65858 RVA: 0x00477F5C File Offset: 0x0047635C
		private void _onOnLevelSelectDropdownValueChange(int index)
		{
			if (!DataManager<Pk3v3CrossDataManager>.GetInstance().IsTeamLeader())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null when save room setting data.");
				return;
			}
			if (index >= this.limitLvs.Length)
			{
				return;
			}
			WorldUpdateRoomReq worldUpdateRoomReq = new WorldUpdateRoomReq();
			worldUpdateRoomReq.roomId = roomInfo.roomSimpleInfo.id;
			worldUpdateRoomReq.roomType = roomInfo.roomSimpleInfo.roomType;
			worldUpdateRoomReq.name = roomInfo.roomSimpleInfo.name;
			worldUpdateRoomReq.password = DataManager<Pk3v3CrossDataManager>.GetInstance().PassWord;
			worldUpdateRoomReq.isLimitPlayerLevel = ((index <= 0) ? 0 : 1);
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = roomInfo.roomSimpleInfo.isLimitPlayerSeasonLevel;
			int num = 0;
			int.TryParse(this.limitLvs[index], out num);
			worldUpdateRoomReq.limitPlayerLevel = (ushort)num;
			worldUpdateRoomReq.limitPlayerSeasonLevel = roomInfo.roomSimpleInfo.limitPlayerSeasonLevel;
			worldUpdateRoomReq.isLimitPlayerLevel = 1;
			worldUpdateRoomReq.isLimitPlayerSeasonLevel = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRoomReq>(ServerType.GATE_SERVER, worldUpdateRoomReq);
		}

		// Token: 0x06010143 RID: 65859 RVA: 0x0047805B File Offset: 0x0047645B
		private void _onOnCloseButtonClick()
		{
			this.OnCloseBtnClicked();
		}

		// Token: 0x0400A239 RID: 41529
		private eTeamFrameState mState;

		// Token: 0x0400A23A RID: 41530
		private const string kMenuPath = "UIFlatten/Prefabs/Team/TeamMenuGroup";

		// Token: 0x0400A23B RID: 41531
		private int mCurrentFilterIndex;

		// Token: 0x0400A23C RID: 41532
		private bool bStartMatch;

		// Token: 0x0400A23D RID: 41533
		private List<int> FliterFirstMenuList = new List<int>();

		// Token: 0x0400A23E RID: 41534
		private Dictionary<int, List<int>> FliterSecondMenuDict = new Dictionary<int, List<int>>();

		// Token: 0x0400A23F RID: 41535
		[UIControl("TargetRoot/pkCount", null, 0)]
		private Text txtPkCount;

		// Token: 0x0400A240 RID: 41536
		[UIControl("TargetRoot/myScore", null, 0)]
		private Text txtmyScore;

		// Token: 0x0400A241 RID: 41537
		[UIControl("TargetRoot/myrRank", null, 0)]
		private Text txtmyrRank;

		// Token: 0x0400A242 RID: 41538
		private List<Pk3v3CrossMyTeamFrame.TeamDungeonNode> mAllNodes = new List<Pk3v3CrossMyTeamFrame.TeamDungeonNode>();

		// Token: 0x0400A243 RID: 41539
		private DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x0400A244 RID: 41540
		private ToggleGroup mSecondGroup;

		// Token: 0x0400A245 RID: 41541
		private Dropdown mOnDiffSelect;

		// Token: 0x0400A246 RID: 41542
		private ScrollRect mDungeonScrollList;

		// Token: 0x0400A247 RID: 41543
		private GameObject mTargetRoot;

		// Token: 0x0400A248 RID: 41544
		private ToggleGroup mFirstMenutogglegroup;

		// Token: 0x0400A249 RID: 41545
		private Button mOnClose;

		// Token: 0x0400A24A RID: 41546
		private GameObject mRightRoot;

		// Token: 0x0400A24B RID: 41547
		private Dropdown mOnLevelSelect;

		// Token: 0x0400A24C RID: 41548
		private string[] seasonLvs = new string[]
		{
			"青铜",
			"白银",
			"黄金",
			"铂金",
			"钻石",
			"王者"
		};

		// Token: 0x0400A24D RID: 41549
		private string[] limitLvs = new string[0];

		// Token: 0x020019B6 RID: 6582
		private class TeamDungeonNode
		{
			// Token: 0x0400A24E RID: 41550
			public int id;

			// Token: 0x0400A24F RID: 41551
			public TeamDungeonTable table;

			// Token: 0x0400A250 RID: 41552
			public ComCommonBind bind;
		}
	}
}
