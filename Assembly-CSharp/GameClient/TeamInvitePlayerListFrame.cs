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
	// Token: 0x02001C07 RID: 7175
	internal class TeamInvitePlayerListFrame : ClientFrame
	{
		// Token: 0x06011938 RID: 71992 RVA: 0x0051F37C File Offset: 0x0051D77C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamInvitePlayerList";
		}

		// Token: 0x06011939 RID: 71993 RVA: 0x0051F384 File Offset: 0x0051D784
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.invitetype = (InviteType)this.userData;
			}
			this.InitInterface();
			this.BindUIEvent();
			this.canInvate = true;
			this.bIsIn3v3Cross = this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null);
			if (this.invitetype == InviteType.TeamInvite && !DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				this.mBtInviteAll.CustomActive(false);
				this.togFriend.SafeSetToggleOnState(true);
				this.togNearby.CustomActive(false);
			}
		}

		// Token: 0x0601193A RID: 71994 RVA: 0x0051F411 File Offset: 0x0051D811
		protected override void _OnCloseFrame()
		{
			this.bIsIn3v3Cross = false;
			this.Clear();
			this.UnBindUIEvent();
		}

		// Token: 0x0601193B RID: 71995 RVA: 0x0051F428 File Offset: 0x0051D828
		private new void Clear()
		{
			this.CurTabIndex = 0;
			for (int i = 0; i < this.PlayersUIInfo.Count; i++)
			{
				this.PlayersUIInfo[i].Invite.onClick.RemoveAllListeners();
			}
			this.PlayersUIInfo.Clear();
			this.PlayersObjList.Clear();
			this.NearList.Clear();
			this.FriendsList.Clear();
			this.GuildMemberList.Clear();
			this.canInvate = true;
			this.iNeedMinLv = 1;
		}

		// Token: 0x0601193C RID: 71996 RVA: 0x0051F4B8 File Offset: 0x0051D8B8
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildMembersUpdated, new ClientEventSystem.UIEventHandler(this.OnGuildMembersUpdated));
		}

		// Token: 0x0601193D RID: 71997 RVA: 0x0051F4D5 File Offset: 0x0051D8D5
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildMembersUpdated, new ClientEventSystem.UIEventHandler(this.OnGuildMembersUpdated));
		}

		// Token: 0x0601193E RID: 71998 RVA: 0x0051F4F2 File Offset: 0x0051D8F2
		[UIEventHandle("middle/Title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<TeamInvitePlayerListFrame>(this, false);
		}

		// Token: 0x0601193F RID: 71999 RVA: 0x0051F501 File Offset: 0x0051D901
		[UIEventHandle("middle/Tab/Func{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnSwitchLabel(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.CurTabIndex = iIndex;
			this.UpdateInterface();
		}

		// Token: 0x06011940 RID: 72000 RVA: 0x0051F520 File Offset: 0x0051D920
		private void OnClickInvite(int iIndex)
		{
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("当前状态无法进行该操作", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (iIndex < 0)
			{
				return;
			}
			ulong num = 0UL;
			int num2 = 1;
			if (this.CurTabIndex == 0)
			{
				if (iIndex >= this.NearList.Count || this.NearList[iIndex].IsInvite)
				{
					return;
				}
				num = this.NearList[iIndex].uid;
				num2 = (int)this.NearList[iIndex].level;
			}
			else if (this.CurTabIndex == 1)
			{
				if (iIndex >= this.FriendsList.Count || this.FriendsList[iIndex].IsInvite)
				{
					return;
				}
				num = this.FriendsList[iIndex].uid;
				num2 = (int)this.FriendsList[iIndex].level;
			}
			else if (this.CurTabIndex == 2)
			{
				if (iIndex >= this.GuildMemberList.Count || this.GuildMemberList[iIndex].IsInvite)
				{
					return;
				}
				if (iIndex >= this.NearList.Count)
				{
					return;
				}
				if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你尚未加入一个公会", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				num = this.GuildMemberList[iIndex].uid;
				num2 = (int)this.NearList[iIndex].level;
			}
			if (this.bIsIn3v3Cross)
			{
				if (this.invitetype == InviteType.Pk3v3Invite)
				{
					if (num2 < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("对方尚未解锁决斗场", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckIsInMyRoom(num))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("对方已经在你队伍中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					DataManager<Pk3v3CrossDataManager>.GetInstance().Pk3v3RoomInviteOtherPlayer(num);
				}
				else
				{
					if (num2 < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Team))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("对方尚未解锁组队功能", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (num2 < this.iNeedMinLv)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("对方等级无法进入当前组队副本", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (this.CheckIsInMyTeam(num))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("对方已经在你队伍中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(num);
				}
			}
			else if (this.invitetype == InviteType.Pk3v3Invite)
			{
				if (num2 < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("对方尚未解锁决斗场", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (DataManager<Pk3v3DataManager>.GetInstance().CheckIsInMyRoom(num))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("对方已经在你房间中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<Pk3v3DataManager>.GetInstance().Pk3v3RoomInviteOtherPlayer(num);
			}
			else
			{
				if (num2 < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Team))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("对方尚未解锁组队功能", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (num2 < this.iNeedMinLv)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("对方等级无法进入当前组队副本", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (this.CheckIsInMyTeam(num))
				{
					SystemNotifyManager.SysNotifyFloatingEffect("对方已经在你队伍中", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(num);
			}
			if (this.CurTabIndex == 0)
			{
				if (iIndex < this.NearList.Count)
				{
					this.NearList[iIndex].IsInvite = true;
				}
			}
			else if (this.CurTabIndex == 1)
			{
				if (iIndex < this.FriendsList.Count)
				{
					this.FriendsList[iIndex].IsInvite = true;
				}
			}
			else if (this.CurTabIndex == 2 && iIndex < this.GuildMemberList.Count)
			{
				this.GuildMemberList[iIndex].IsInvite = true;
			}
			this.UpdateInterface();
		}

		// Token: 0x06011941 RID: 72001 RVA: 0x0051F898 File Offset: 0x0051DC98
		private void InitInterface()
		{
			this.mBtInviteAll.gameObject.CustomActive(this.invitetype == InviteType.TeamInvite);
			this.m3v3Root.CustomActive(this.invitetype == InviteType.Pk3v3Invite);
			if (this.invitetype == InviteType.TeamInvite)
			{
				TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>((int)DataManager<TeamDataManager>.GetInstance().TeamDungeonID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				this.iNeedMinLv = tableItem.MinLevel;
			}
			for (int i = 0; i < this.FuncTab.Length; i++)
			{
				if (i == 0)
				{
					this.FuncTab[i].isOn = true;
				}
			}
			this.SendFindNearPlayersReq();
			this.InitFriendsData();
			if (DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				DataManager<GuildDataManager>.GetInstance().RequestGuildMembers();
			}
		}

		// Token: 0x06011942 RID: 72002 RVA: 0x0051F964 File Offset: 0x0051DD64
		private void UpdateInterface()
		{
			int num = 0;
			if (this.CurTabIndex == 0)
			{
				num = this.NearList.Count;
			}
			else if (this.CurTabIndex == 1)
			{
				num = this.FriendsList.Count;
			}
			else if (this.CurTabIndex == 2)
			{
				num = this.GuildMemberList.Count;
			}
			if (num > this.PlayersObjList.Count)
			{
				int count = this.PlayersObjList.Count;
				int num2 = num - this.PlayersObjList.Count;
				for (int i = 0; i < num2; i++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Team/TeamInviteEle", true, 0U);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.PlayersRoot, false);
						this.PlayersObjList.Add(gameObject);
						TeamInvitePlayerListFrame.PlayersUI playersUI = new TeamInvitePlayerListFrame.PlayersUI();
						Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>();
						for (int j = 0; j < componentsInChildren.Length; j++)
						{
							if (componentsInChildren[j].name == "Icon")
							{
								playersUI.Icon = componentsInChildren[j];
								break;
							}
						}
						Text[] componentsInChildren2 = gameObject.GetComponentsInChildren<Text>();
						for (int k = 0; k < componentsInChildren2.Length; k++)
						{
							if (componentsInChildren2[k].name == "Name")
							{
								playersUI.Name = componentsInChildren2[k];
							}
							else if (componentsInChildren2[k].name == "Job")
							{
								playersUI.Job = componentsInChildren2[k];
							}
							else if (componentsInChildren2[k].name == "Level")
							{
								playersUI.Level = componentsInChildren2[k];
							}
							else if (componentsInChildren2[k].name == "content")
							{
								playersUI.InviteText = componentsInChildren2[k];
							}
						}
						playersUI.Invite = gameObject.GetComponentInChildren<Button>();
						playersUI.Invite.gameObject.AddComponent<UIGray>();
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (component != null)
						{
							playersUI.returnPlayer = component.GetGameObject("returnPlayer");
							playersUI.myFriend = component.GetGameObject("myFriend");
							playersUI.myGuild = component.GetGameObject("myGuild");
						}
						this.PlayersUIInfo.Add(playersUI);
					}
				}
			}
			for (int l = 0; l < this.PlayersObjList.Count; l++)
			{
				if (l < num)
				{
					TeamInvitePlayerListFrame.PlayersUI playersUI2 = this.PlayersUIInfo[l];
					TeamInvitePlayerListFrame.PlayersData playersData = null;
					if (this.CurTabIndex == 0)
					{
						playersData = this.NearList[l];
					}
					else if (this.CurTabIndex == 1)
					{
						playersData = this.FriendsList[l];
					}
					else if (this.CurTabIndex == 2)
					{
						playersData = this.GuildMemberList[l];
					}
					if (playersData == null)
					{
						this.PlayersObjList[l].SetActive(false);
					}
					else
					{
						if (playersData.remark != null && playersData.remark != string.Empty)
						{
							playersUI2.Name.text = playersData.remark;
						}
						else
						{
							playersUI2.Name.text = playersData.name;
						}
						playersUI2.Level.text = string.Format("Lv.{0}", playersData.level);
						playersUI2.returnPlayer.CustomActive(false);
						playersUI2.myFriend.CustomActive(false);
						playersUI2.myGuild.CustomActive(false);
						RelationData relationData = null;
						bool flag = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(playersData.uid, ref relationData);
						bool flag2 = DataManager<GuildDataManager>.GetInstance().IsSameGuild(playersData.playerLabelInfo.guildId);
						if (this.CurTabIndex == 0)
						{
							if (playersData.playerLabelInfo.returnStatus == 1)
							{
								playersUI2.returnPlayer.CustomActive(true);
							}
							else if (flag)
							{
								playersUI2.myFriend.CustomActive(true);
							}
							else if (flag2)
							{
								playersUI2.myGuild.CustomActive(true);
							}
						}
						else if (this.CurTabIndex == 1)
						{
							if (playersData.playerLabelInfo.returnStatus == 1)
							{
								playersUI2.returnPlayer.CustomActive(true);
							}
							else if (flag2)
							{
								playersUI2.myGuild.CustomActive(true);
							}
						}
						else if (this.CurTabIndex == 2)
						{
							if (playersData.playerLabelInfo.returnStatus == 1)
							{
								playersUI2.returnPlayer.CustomActive(true);
							}
							else if (flag)
							{
								playersUI2.myFriend.CustomActive(true);
							}
						}
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)playersData.occu, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								ETCImageLoader.LoadSprite(ref playersUI2.Icon, tableItem2.IconPath, true);
							}
							playersUI2.Job.text = tableItem.Name;
						}
						int iIndex = l;
						playersUI2.Invite.onClick.RemoveAllListeners();
						playersUI2.Invite.onClick.AddListener(delegate()
						{
							this.OnClickInvite(iIndex);
						});
						if (playersData.IsInvite)
						{
							playersUI2.InviteText.text = "已邀请";
							playersUI2.Invite.gameObject.GetComponent<UIGray>().enabled = true;
							playersUI2.Invite.interactable = false;
						}
						else
						{
							playersUI2.InviteText.text = "邀请";
							playersUI2.Invite.gameObject.GetComponent<UIGray>().enabled = false;
							playersUI2.Invite.interactable = true;
						}
						this.PlayersObjList[l].SetActive(true);
					}
				}
				else
				{
					this.PlayersObjList[l].SetActive(false);
				}
			}
		}

		// Token: 0x06011943 RID: 72003 RVA: 0x0051FF9C File Offset: 0x0051E39C
		private int SortPlayersData(TeamInvitePlayerListFrame.PlayersData a, TeamInvitePlayerListFrame.PlayersData b)
		{
			if (a == null || b == null)
			{
				return 0;
			}
			if (a.playerLabelInfo == null || b.playerLabelInfo == null)
			{
				return 0;
			}
			RelationData relationData = null;
			bool flag = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(a.uid, ref relationData);
			bool flag2 = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(b.uid, ref relationData);
			bool value = DataManager<GuildDataManager>.GetInstance().IsSameGuild(a.playerLabelInfo.guildId);
			bool flag3 = DataManager<GuildDataManager>.GetInstance().IsSameGuild(b.playerLabelInfo.guildId);
			if (a.playerLabelInfo.returnStatus != b.playerLabelInfo.returnStatus)
			{
				return (int)(b.playerLabelInfo.returnStatus - a.playerLabelInfo.returnStatus);
			}
			if (flag != flag2)
			{
				return flag2.CompareTo(flag);
			}
			return flag3.CompareTo(value);
		}

		// Token: 0x06011944 RID: 72004 RVA: 0x00520070 File Offset: 0x0051E470
		private void InitFriendsData()
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
			List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
			List<RelationData> relation3 = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			relation.InsertRange(relation.Count, relation2);
			relation.InsertRange(relation.Count, relation3);
			for (int i = 0; i < relation.Count; i++)
			{
				if (relation[i].isOnline == 1)
				{
					TeamInvitePlayerListFrame.PlayersData playersData = new TeamInvitePlayerListFrame.PlayersData();
					playersData.uid = relation[i].uid;
					playersData.name = relation[i].name;
					playersData.occu = relation[i].occu;
					playersData.level = relation[i].level;
					playersData.remark = relation[i].remark;
					playersData.IsInvite = false;
					playersData.playerLabelInfo.awakenStatus = relation[i].playerLabelInfo.awakenStatus;
					playersData.playerLabelInfo.returnStatus = relation[i].playerLabelInfo.returnStatus;
					playersData.playerLabelInfo.returnStatus = relation[i].isRegress;
					this.FriendsList.Add(playersData);
				}
			}
			if (this.FriendsList != null)
			{
				this.FriendsList.Sort(new Comparison<TeamInvitePlayerListFrame.PlayersData>(this.SortPlayersData));
			}
		}

		// Token: 0x06011945 RID: 72005 RVA: 0x005201D4 File Offset: 0x0051E5D4
		private void SendFindNearPlayersReq()
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			if (this.invitetype == InviteType.TeamInvite)
			{
				worldRelationFindPlayersReq.type = 2;
			}
			else if (this.invitetype == InviteType.Pk3v3Invite)
			{
				worldRelationFindPlayersReq.type = 5;
			}
			worldRelationFindPlayersReq.name = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x06011946 RID: 72006 RVA: 0x0052022C File Offset: 0x0051E62C
		private void SendOnekeyInviteRoomReq(uint roomid, byte channel = 9)
		{
			WorldRoomSendInviteLinkReq worldRoomSendInviteLinkReq = new WorldRoomSendInviteLinkReq();
			worldRoomSendInviteLinkReq.roomId = roomid;
			worldRoomSendInviteLinkReq.channel = channel;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomSendInviteLinkReq>(ServerType.GATE_SERVER, worldRoomSendInviteLinkReq);
		}

		// Token: 0x06011947 RID: 72007 RVA: 0x0052025C File Offset: 0x0051E65C
		[MessageHandle(601710U, false, 0)]
		private void OnFindNearPlayersRes(MsgDATA msg)
		{
			WorldRelationFindPlayersRet worldRelationFindPlayersRet = new WorldRelationFindPlayersRet();
			worldRelationFindPlayersRet.decode(msg.bytes);
			if (worldRelationFindPlayersRet.type != 5 && worldRelationFindPlayersRet.type != 2)
			{
				return;
			}
			this.NearList.Clear();
			for (int i = 0; i < worldRelationFindPlayersRet.friendList.Length; i++)
			{
				TeamInvitePlayerListFrame.PlayersData playersData = new TeamInvitePlayerListFrame.PlayersData();
				playersData.uid = worldRelationFindPlayersRet.friendList[i].playerId;
				playersData.name = worldRelationFindPlayersRet.friendList[i].name;
				playersData.occu = worldRelationFindPlayersRet.friendList[i].occu;
				playersData.level = worldRelationFindPlayersRet.friendList[i].level;
				playersData.IsInvite = false;
				playersData.playerLabelInfo.awakenStatus = worldRelationFindPlayersRet.friendList[i].playerLabelInfo.awakenStatus;
				playersData.playerLabelInfo.returnStatus = worldRelationFindPlayersRet.friendList[i].playerLabelInfo.returnStatus;
				RelationData relationData = null;
				DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(worldRelationFindPlayersRet.friendList[i].playerId, ref relationData);
				if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
				{
					playersData.remark = relationData.remark;
				}
				this.NearList.Add(playersData);
			}
			if (this.NearList != null)
			{
				this.NearList.Sort(new Comparison<TeamInvitePlayerListFrame.PlayersData>(this.SortPlayersData));
			}
			this.UpdateInterface();
		}

		// Token: 0x06011948 RID: 72008 RVA: 0x005203D0 File Offset: 0x0051E7D0
		private void OnGuildMembersUpdated(UIEvent iEvent)
		{
			this.GuildMemberList.Clear();
			List<GuildMemberData> members = DataManager<GuildDataManager>.GetInstance().GetMembers();
			for (int i = 0; i < members.Count; i++)
			{
				TeamInvitePlayerListFrame.PlayersData playersData = new TeamInvitePlayerListFrame.PlayersData();
				if (members[i].uGUID != DataManager<PlayerBaseData>.GetInstance().RoleID && members[i].uOffLineTime == 0U)
				{
					playersData.uid = members[i].uGUID;
					playersData.name = members[i].strName;
					playersData.level = (ushort)members[i].nLevel;
					playersData.occu = (byte)members[i].nJobID;
					playersData.remark = members[i].remark;
					playersData.playerLabelInfo = members[i].playerLabelInfo;
					playersData.IsInvite = false;
					this.GuildMemberList.Add(playersData);
				}
			}
			if (this.GuildMemberList != null)
			{
				this.GuildMemberList.Sort(new Comparison<TeamInvitePlayerListFrame.PlayersData>(this.SortPlayersData));
			}
		}

		// Token: 0x06011949 RID: 72009 RVA: 0x005204E4 File Offset: 0x0051E8E4
		private bool CheckIsInMyTeam(ulong uId)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return false;
			}
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				if (myTeam.members[i].id == uId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601194A RID: 72010 RVA: 0x00520534 File Offset: 0x0051E934
		protected override void _bindExUI()
		{
			this.mBtInviteAll = this.mBind.GetCom<Button>("btInviteAll");
			this.mBtInviteAll.onClick.AddListener(new UnityAction(this._onBtInviteAllButtonClick));
			this.m3v3Root = this.mBind.GetGameObject("3v3Root");
			this.mOneKeyPropaganda = this.mBind.GetCom<Button>("OneKeyPropaganda");
			this.mOneKeyPropaganda.onClick.AddListener(new UnityAction(this._onOneKeyPropagandaButtonClick));
			this.mBt3v3InviteAll = this.mBind.GetCom<Button>("bt3v3InviteAll");
			this.mBt3v3InviteAll.onClick.AddListener(new UnityAction(this._onBt3v3InviteAllButtonClick));
			this.mInviteTime = this.mBind.GetCom<Text>("InviteTime");
			this.mInviteGray = this.mBind.GetCom<UIGray>("InviteGray");
			this.togNearby = this.mBind.GetCom<Toggle>("togNearby");
			this.togFriend = this.mBind.GetCom<Toggle>("togFriend");
			this.togGuild = this.mBind.GetCom<Toggle>("togGuild");
		}

		// Token: 0x0601194B RID: 72011 RVA: 0x0052065C File Offset: 0x0051EA5C
		protected override void _unbindExUI()
		{
			this.mBtInviteAll.onClick.RemoveListener(new UnityAction(this._onBtInviteAllButtonClick));
			this.mBtInviteAll = null;
			this.m3v3Root = null;
			this.mOneKeyPropaganda.onClick.RemoveListener(new UnityAction(this._onOneKeyPropagandaButtonClick));
			this.mOneKeyPropaganda = null;
			this.mBt3v3InviteAll.onClick.RemoveListener(new UnityAction(this._onBt3v3InviteAllButtonClick));
			this.mBt3v3InviteAll = null;
			this.mInviteTime = null;
			this.mInviteGray = null;
			this.togNearby = null;
			this.togFriend = null;
			this.togGuild = null;
		}

		// Token: 0x0601194C RID: 72012 RVA: 0x005206FC File Offset: 0x0051EAFC
		private void _onBtInviteAllButtonClick()
		{
			if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("你不是队长没有权限邀请", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			List<TeamInvitePlayerListFrame.PlayersData> list = null;
			if (this.CurTabIndex == 0)
			{
				list = this.NearList;
			}
			else if (this.CurTabIndex == 1)
			{
				list = this.FriendsList;
			}
			else if (this.CurTabIndex == 2)
			{
				if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你尚未加入一个公会", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				list = this.GuildMemberList;
			}
			if (list == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				if ((int)list[i].level < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Team))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}尚未解锁组队功能", list[i].name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					list[i].IsInvite = true;
				}
				else if ((int)list[i].level < this.iNeedMinLv)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}等级无法进入当前组队副本", list[i].name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					list[i].IsInvite = true;
				}
				else if (!list[i].IsInvite)
				{
					if (!this.CheckIsInMyTeam(list[i].uid))
					{
						DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(list[i].uid);
						flag = true;
						list[i].IsInvite = true;
					}
				}
			}
			if (flag)
			{
				this.UpdateInterface();
			}
		}

		// Token: 0x0601194D RID: 72013 RVA: 0x00520898 File Offset: 0x0051EC98
		private void _onOneKeyPropagandaButtonClick()
		{
			if (this.invitetype != InviteType.Pk3v3Invite)
			{
				return;
			}
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("当前状态无法进行该操作", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.bIsIn3v3Cross)
			{
				RoomInfo roomInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomInfo();
				if (roomInfo == null)
				{
					return;
				}
				this.SendOnekeyInviteRoomReq(roomInfo.roomSimpleInfo.id, 1);
				this.canInvate = true;
				DataManager<Pk3v3CrossDataManager>.GetInstance().SimpleInviteLastTime = 30;
			}
			else
			{
				RoomInfo roomInfo2 = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
				if (roomInfo2 == null)
				{
					return;
				}
				this.SendOnekeyInviteRoomReq(roomInfo2.roomSimpleInfo.id, 9);
				this.canInvate = true;
				DataManager<Pk3v3DataManager>.GetInstance().SimpleInviteLastTime = 30;
			}
		}

		// Token: 0x0601194E RID: 72014 RVA: 0x0052094F File Offset: 0x0051ED4F
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0601194F RID: 72015 RVA: 0x00520954 File Offset: 0x0051ED54
		protected override void _OnUpdate(float LastTime)
		{
			if (this.bIsIn3v3Cross)
			{
				if (this.canInvate)
				{
					this.curTimeUpdateTime = Time.time;
					if (this.curTimeUpdateTime - this.lastTimeUpdateTime >= 1f)
					{
						if (DataManager<Pk3v3CrossDataManager>.GetInstance().SimpleInviteLastTime > 0)
						{
							this.mInviteTime.text = string.Format("一键喊话{0}s", DataManager<Pk3v3CrossDataManager>.GetInstance().SimpleInviteLastTime);
							this.mInviteGray.enabled = true;
							this.mOneKeyPropaganda.interactable = false;
						}
						else
						{
							this.canInvate = false;
							this.mInviteTime.text = string.Format("一键喊话", DataManager<Pk3v3CrossDataManager>.GetInstance().SimpleInviteLastTime);
							this.mInviteGray.enabled = false;
							this.mOneKeyPropaganda.interactable = true;
						}
						this.lastTimeUpdateTime = this.curTimeUpdateTime;
					}
				}
			}
			else if (this.canInvate)
			{
				this.curTimeUpdateTime = Time.time;
				if (this.curTimeUpdateTime - this.lastTimeUpdateTime >= 1f)
				{
					if (DataManager<Pk3v3DataManager>.GetInstance().SimpleInviteLastTime > 0)
					{
						this.mInviteTime.text = string.Format("一键喊话{0}s", DataManager<Pk3v3DataManager>.GetInstance().SimpleInviteLastTime);
						this.mInviteGray.enabled = true;
						this.mOneKeyPropaganda.interactable = false;
					}
					else
					{
						this.canInvate = false;
						this.mInviteTime.text = string.Format("一键喊话", DataManager<Pk3v3DataManager>.GetInstance().SimpleInviteLastTime);
						this.mInviteGray.enabled = false;
						this.mOneKeyPropaganda.interactable = true;
					}
					this.lastTimeUpdateTime = this.curTimeUpdateTime;
				}
			}
		}

		// Token: 0x06011950 RID: 72016 RVA: 0x00520B0C File Offset: 0x0051EF0C
		private void _onBt3v3InviteAllButtonClick()
		{
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("当前状态无法进行该操作", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			List<TeamInvitePlayerListFrame.PlayersData> list = null;
			if (this.CurTabIndex == 0)
			{
				list = this.NearList;
			}
			else if (this.CurTabIndex == 1)
			{
				list = this.FriendsList;
			}
			else if (this.CurTabIndex == 2)
			{
				if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你尚未加入一个公会", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				list = this.GuildMemberList;
			}
			if (list == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				if ((int)list[i].level < Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(string.Format("{0}尚未解锁决斗场", list[i].name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					list[i].IsInvite = true;
				}
				else if (!list[i].IsInvite)
				{
					if (this.bIsIn3v3Cross)
					{
						if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckIsInMyRoom(list[i].uid))
						{
							goto IL_177;
						}
						DataManager<Pk3v3CrossDataManager>.GetInstance().Pk3v3RoomInviteOtherPlayer(list[i].uid);
						flag = true;
					}
					else
					{
						if (DataManager<Pk3v3DataManager>.GetInstance().CheckIsInMyRoom(list[i].uid))
						{
							goto IL_177;
						}
						DataManager<Pk3v3DataManager>.GetInstance().Pk3v3RoomInviteOtherPlayer(list[i].uid);
						flag = true;
					}
					list[i].IsInvite = true;
				}
				IL_177:;
			}
			if (flag)
			{
				this.UpdateInterface();
			}
		}

		// Token: 0x0400B6E9 RID: 46825
		private InviteType invitetype;

		// Token: 0x0400B6EA RID: 46826
		private static InviteUIType inviteUIType;

		// Token: 0x0400B6EB RID: 46827
		private const int TabNum = 3;

		// Token: 0x0400B6EC RID: 46828
		private int CurTabIndex;

		// Token: 0x0400B6ED RID: 46829
		private List<GameObject> PlayersObjList = new List<GameObject>();

		// Token: 0x0400B6EE RID: 46830
		private List<TeamInvitePlayerListFrame.PlayersUI> PlayersUIInfo = new List<TeamInvitePlayerListFrame.PlayersUI>();

		// Token: 0x0400B6EF RID: 46831
		private List<TeamInvitePlayerListFrame.PlayersData> NearList = new List<TeamInvitePlayerListFrame.PlayersData>();

		// Token: 0x0400B6F0 RID: 46832
		private List<TeamInvitePlayerListFrame.PlayersData> FriendsList = new List<TeamInvitePlayerListFrame.PlayersData>();

		// Token: 0x0400B6F1 RID: 46833
		private List<TeamInvitePlayerListFrame.PlayersData> GuildMemberList = new List<TeamInvitePlayerListFrame.PlayersData>();

		// Token: 0x0400B6F2 RID: 46834
		private bool bIsIn3v3Cross;

		// Token: 0x0400B6F3 RID: 46835
		private int iNeedMinLv = 1;

		// Token: 0x0400B6F4 RID: 46836
		private bool canInvate = true;

		// Token: 0x0400B6F5 RID: 46837
		private float curTimeUpdateTime;

		// Token: 0x0400B6F6 RID: 46838
		private float lastTimeUpdateTime;

		// Token: 0x0400B6F7 RID: 46839
		[UIControl("middle/Tab/Func{0}", typeof(Toggle), 1)]
		protected Toggle[] FuncTab = new Toggle[3];

		// Token: 0x0400B6F8 RID: 46840
		[UIObject("middle/Scroll View/Viewport/Content")]
		protected GameObject PlayersRoot;

		// Token: 0x0400B6F9 RID: 46841
		private Button mBtInviteAll;

		// Token: 0x0400B6FA RID: 46842
		private GameObject m3v3Root;

		// Token: 0x0400B6FB RID: 46843
		private Button mOneKeyPropaganda;

		// Token: 0x0400B6FC RID: 46844
		private Button mBt3v3InviteAll;

		// Token: 0x0400B6FD RID: 46845
		private Text mInviteTime;

		// Token: 0x0400B6FE RID: 46846
		private UIGray mInviteGray;

		// Token: 0x0400B6FF RID: 46847
		private Toggle togNearby;

		// Token: 0x0400B700 RID: 46848
		private Toggle togFriend;

		// Token: 0x0400B701 RID: 46849
		private Toggle togGuild;

		// Token: 0x02001C08 RID: 7176
		public class PlayersData
		{
			// Token: 0x0400B702 RID: 46850
			public ulong uid;

			// Token: 0x0400B703 RID: 46851
			public string name;

			// Token: 0x0400B704 RID: 46852
			public byte occu;

			// Token: 0x0400B705 RID: 46853
			public ushort level;

			// Token: 0x0400B706 RID: 46854
			public bool IsInvite;

			// Token: 0x0400B707 RID: 46855
			public string remark;

			// Token: 0x0400B708 RID: 46856
			public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();
		}

		// Token: 0x02001C09 RID: 7177
		private class PlayersUI
		{
			// Token: 0x0400B709 RID: 46857
			public Image Icon;

			// Token: 0x0400B70A RID: 46858
			public Text Name;

			// Token: 0x0400B70B RID: 46859
			public Text Level;

			// Token: 0x0400B70C RID: 46860
			public Text Job;

			// Token: 0x0400B70D RID: 46861
			public Button Invite;

			// Token: 0x0400B70E RID: 46862
			public Text InviteText;

			// Token: 0x0400B70F RID: 46863
			public GameObject returnPlayer;

			// Token: 0x0400B710 RID: 46864
			public GameObject myFriend;

			// Token: 0x0400B711 RID: 46865
			public GameObject myGuild;
		}
	}
}
