using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C04 RID: 7172
	internal class TeamBeInvitedListFrame : ClientFrame
	{
		// Token: 0x06011922 RID: 71970 RVA: 0x0051E044 File Offset: 0x0051C444
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamBeInvitedListFrame";
		}

		// Token: 0x06011923 RID: 71971 RVA: 0x0051E04B File Offset: 0x0051C44B
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.inviteType = (InviteType)this.userData;
			}
			this.InitMainTabUIList();
			this.InitInterface();
			this.BindUIEvent();
			this.UpdateMainTabList();
		}

		// Token: 0x06011924 RID: 71972 RVA: 0x0051E081 File Offset: 0x0051C481
		protected override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
			this.UnInitMainTabUIList();
		}

		// Token: 0x06011925 RID: 71973 RVA: 0x0051E098 File Offset: 0x0051C498
		private void InitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				this.mMainTabs.Initialize();
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011926 RID: 71974 RVA: 0x0051E110 File Offset: 0x0051C510
		private void UnInitMainTabUIList()
		{
			if (this.mMainTabs != null)
			{
				ComUIListScript comUIListScript = this.mMainTabs;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mMainTabs;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x06011927 RID: 71975 RVA: 0x0051E17C File Offset: 0x0051C57C
		private TeamInvitedTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TeamInvitedTabItem>();
		}

		// Token: 0x06011928 RID: 71976 RVA: 0x0051E184 File Offset: 0x0051C584
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TeamInvitedTabItem teamInvitedTabItem = item.gameObjectBindScript as TeamInvitedTabItem;
			if (teamInvitedTabItem != null && item.m_index >= 0 && item.m_index < this.mMainTabDataList.Count)
			{
				InvitedTabData invitedTabData = this.mMainTabDataList[item.m_index];
				if (this.invitedTabType != InvitedTabType.ITT_None)
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), invitedTabData.mInvitedTabType == this.invitedTabType);
				}
				else
				{
					teamInvitedTabItem.InitTab(invitedTabData, new OnInvitedTabClick(this.OnInvitedTabClick), item.m_index == 0);
				}
			}
		}

		// Token: 0x06011929 RID: 71977 RVA: 0x0051E22A File Offset: 0x0051C62A
		private void OnInvitedTabClick(InvitedTabData invitedTabData)
		{
			if (invitedTabData == null)
			{
				return;
			}
			this.invitedTabType = invitedTabData.mInvitedTabType;
			this.UpdateEleObjList();
		}

		// Token: 0x0601192A RID: 71978 RVA: 0x0051E248 File Offset: 0x0051C648
		private void ClearData()
		{
			this.inviteType = InviteType.None;
			for (int i = 0; i < this.EleObjList.Count; i++)
			{
				if (!(this.EleObjList[i] == null))
				{
					ComCommonBind component = this.EleObjList[i].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						GameObject gameObject = component.GetGameObject("BtReject");
						gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
						GameObject gameObject2 = component.GetGameObject("BtAgree");
						gameObject2.GetComponent<Button>().onClick.RemoveAllListeners();
					}
				}
			}
			this.EleObjList.Clear();
			this.invitedTabType = InvitedTabType.ITT_None;
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
		}

		// Token: 0x0601192B RID: 71979 RVA: 0x0051E317 File Offset: 0x0051C717
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
		}

		// Token: 0x0601192C RID: 71980 RVA: 0x0051E334 File Offset: 0x0051C734
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnNewInviteNoticeUpdate));
		}

		// Token: 0x0601192D RID: 71981 RVA: 0x0051E351 File Offset: 0x0051C751
		private void OnNewInviteNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateMainTabList();
			this.UpdateEleObjList();
		}

		// Token: 0x0601192E RID: 71982 RVA: 0x0051E360 File Offset: 0x0051C760
		private void OnReject(int index)
		{
			NetManager netManager = NetManager.Instance();
			byte b = 0;
			if (this.invitedTabType == InvitedTabType.ITT_DuelTeam)
			{
				List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
				inviteRoomList.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
				if (index < 0 || index > inviteRoomList.Count)
				{
					return;
				}
				netManager.SendCommand<WorldBeInviteRoomReq>(ServerType.GATE_SERVER, new WorldBeInviteRoomReq
				{
					roomId = inviteRoomList[index].roomId,
					invitePlayerId = inviteRoomList[index].inviterId,
					isAccept = 0,
					slotGroup = inviteRoomList[index].slotGroup
				});
				b = inviteRoomList[index].roomType;
				DataManager<Pk3v3DataManager>.GetInstance().RemoveInviteInfo(inviteRoomList[index]);
				DataManager<Pk3v3CrossDataManager>.GetInstance().RemoveInviteInfo(inviteRoomList[index]);
				inviteRoomList.RemoveAt(index);
				if (inviteRoomList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			else
			{
				List<SceneSyncRequest> friendsPlayInviteList = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
				if (index < 0 || index > friendsPlayInviteList.Count)
				{
					return;
				}
				DataManager<RelationDataManager>.GetInstance().ReplyRequest(friendsPlayInviteList[index], 0);
				friendsPlayInviteList.RemoveAt(index);
				if (friendsPlayInviteList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			this.UpdateEleObjList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, b, null, null, null);
			List<WorldSyncRoomInviteInfo> inviteRoomList2 = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
			inviteRoomList2.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
			List<SceneSyncRequest> friendsPlayInviteList2 = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
			if (inviteRoomList2.Count <= 0 && friendsPlayInviteList2.Count <= 0)
			{
				this.frameMgr.CloseFrame<TeamBeInvitedListFrame>(this, false);
			}
		}

		// Token: 0x0601192F RID: 71983 RVA: 0x0051E508 File Offset: 0x0051C908
		private void OnAgree(int index)
		{
			if (PkWaitingRoom.bBeginSeekPlayer)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			byte roomType = 0;
			NetManager netMgr = NetManager.Instance();
			if (this.invitedTabType == InvitedTabType.ITT_DuelTeam)
			{
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
				List<WorldSyncRoomInviteInfo> InviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
				InviteRoomList.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
				if (index < 0 || index > InviteRoomList.Count)
				{
					return;
				}
				if (Pk3v3DataManager.HasInPk3v3Room() || Pk3v3CrossDataManager.HasInPk3v3Room())
				{
					SystemNotifyManager.SystemNotify(3401008, string.Empty);
					return;
				}
				if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.BUDO)
				{
					SystemNotifyManager.SystemNotify(9307, string.Empty);
					return;
				}
				if (InviteRoomList[index].roomType == 3 && Pk3v3DataManager.HasInPk3v3Room())
				{
					return;
				}
				if (InviteRoomList[index].roomType != 3 && DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
				{
					return;
				}
				if (InviteRoomList[index].roomType == 3)
				{
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
							WorldBeInviteRoomReq worldBeInviteRoomReq2 = new WorldBeInviteRoomReq();
							worldBeInviteRoomReq2.roomId = InviteRoomList[index].roomId;
							worldBeInviteRoomReq2.invitePlayerId = InviteRoomList[index].inviterId;
							worldBeInviteRoomReq2.isAccept = 1;
							worldBeInviteRoomReq2.slotGroup = InviteRoomList[index].slotGroup;
							netMgr.SendCommand<WorldBeInviteRoomReq>(ServerType.GATE_SERVER, worldBeInviteRoomReq2);
							roomType = InviteRoomList[index].roomType;
							DataManager<Pk3v3DataManager>.GetInstance().RemoveInviteInfo(InviteRoomList[index]);
							DataManager<Pk3v3CrossDataManager>.GetInstance().RemoveInviteInfo(InviteRoomList[index]);
							InviteRoomList.RemoveAt(index);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, roomType, null, null, null);
							this.frameMgr.CloseFrame<TeamBeInvitedListFrame>(this, false);
						}, null, 0f, false);
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
				}
				WorldBeInviteRoomReq worldBeInviteRoomReq = new WorldBeInviteRoomReq();
				worldBeInviteRoomReq.roomId = InviteRoomList[index].roomId;
				worldBeInviteRoomReq.invitePlayerId = InviteRoomList[index].inviterId;
				worldBeInviteRoomReq.isAccept = 1;
				worldBeInviteRoomReq.slotGroup = InviteRoomList[index].slotGroup;
				netMgr.SendCommand<WorldBeInviteRoomReq>(ServerType.GATE_SERVER, worldBeInviteRoomReq);
				roomType = InviteRoomList[index].roomType;
				DataManager<Pk3v3DataManager>.GetInstance().RemoveInviteInfo(InviteRoomList[index]);
				DataManager<Pk3v3CrossDataManager>.GetInstance().RemoveInviteInfo(InviteRoomList[index]);
				InviteRoomList.RemoveAt(index);
				if (InviteRoomList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			else
			{
				List<SceneSyncRequest> friendsPlayInviteList = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
				if (index < 0 || index > friendsPlayInviteList.Count)
				{
					return;
				}
				DataManager<RelationDataManager>.GetInstance().ReplyRequest(friendsPlayInviteList[index], 1);
				friendsPlayInviteList.RemoveAt(index);
				if (friendsPlayInviteList.Count <= 0)
				{
					this.invitedTabType = InvitedTabType.ITT_None;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, roomType, null, null, null);
			this.frameMgr.CloseFrame<TeamBeInvitedListFrame>(this, false);
		}

		// Token: 0x06011930 RID: 71984 RVA: 0x0051E8F5 File Offset: 0x0051CCF5
		private void InitInterface()
		{
			if (this.inviteType == InviteType.Pk3v3Invite)
			{
				this.mTitle.text = "决斗邀请列表";
			}
		}

		// Token: 0x06011931 RID: 71985 RVA: 0x0051E914 File Offset: 0x0051CD14
		private void UpdateMainTabList()
		{
			if (this.mMainTabDataList != null)
			{
				this.mMainTabDataList.Clear();
			}
			for (int i = 0; i < 5; i++)
			{
				if (i == 1)
				{
					int num = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList().Count;
					num += DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList().Count;
					if (num > 0)
					{
						InvitedTabData invitedTabData = new InvitedTabData();
						invitedTabData.mInvitedTabType = InvitedTabType.ITT_DuelTeam;
						invitedTabData.mTabName = "组队决斗";
						this.mMainTabDataList.Add(invitedTabData);
					}
				}
				if (i == 2)
				{
					int num = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList.Count;
					if (num > 0)
					{
						InvitedTabData invitedTabData2 = new InvitedTabData();
						invitedTabData2.mInvitedTabType = InvitedTabType.ITT_FriendsPlay;
						invitedTabData2.mTabName = "好友切磋";
						this.mMainTabDataList.Add(invitedTabData2);
					}
				}
			}
			this.mMainTabs.SetElementAmount(this.mMainTabDataList.Count);
		}

		// Token: 0x06011932 RID: 71986 RVA: 0x0051E9F8 File Offset: 0x0051CDF8
		private void UpdateEleObjList()
		{
			int num;
			if (this.invitedTabType == InvitedTabType.ITT_DuelTeam)
			{
				num = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList().Count;
				num += DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList().Count;
			}
			else
			{
				num = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList.Count;
			}
			if (num > this.EleObjList.Count)
			{
				int num2 = num - this.EleObjList.Count;
				for (int i = 0; i < num2; i++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.BeInvitedListElePath, true, 0U);
					if (!(gameObject == null))
					{
						gameObject.transform.SetParent(this.mEleRoot.transform, false);
						this.EleObjList.Add(gameObject);
					}
				}
			}
			for (int j = 0; j < this.EleObjList.Count; j++)
			{
				if (j < num)
				{
					ComCommonBind component = this.EleObjList[j].GetComponent<ComCommonBind>();
					if (component == null)
					{
						this.EleObjList[j].SetActive(false);
					}
					else
					{
						GameObject gameObject2 = component.GetGameObject("Icon");
						GameObject gameObject3 = component.GetGameObject("Name");
						GameObject gameObject4 = component.GetGameObject("Level");
						GameObject gameObject5 = component.GetGameObject("Target");
						GameObject gameObject6 = component.GetGameObject("BtReject");
						GameObject gameObject7 = component.GetGameObject("BtAgree");
						Text component2 = gameObject3.GetComponent<Text>();
						int id;
						if (this.invitedTabType == InvitedTabType.ITT_DuelTeam)
						{
							List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
							inviteRoomList.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
							component2.text = string.Format("{0}  ({1}/{2})", inviteRoomList[j].inviterName, inviteRoomList[j].playerSize, inviteRoomList[j].playerMaxSize);
							RelationData relationData = null;
							DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(inviteRoomList[j].inviterId, ref relationData);
							if (relationData != null && relationData.remark != null && relationData.remark != string.Empty)
							{
								component2.text = string.Format("{0}  ({1}/{2})", relationData.remark, inviteRoomList[j].playerSize, inviteRoomList[j].playerMaxSize);
							}
							gameObject4.GetComponent<Text>().text = string.Format("Lv.{0}", inviteRoomList[j].inviterLevel);
							id = (int)inviteRoomList[j].inviterOccu;
							gameObject5.GetComponent<Text>().text = string.Format("邀请你进入{0}号房间", inviteRoomList[j].roomId);
							if (inviteRoomList[j].roomType == 3)
							{
								gameObject5.GetComponent<Text>().text = "邀请你进入积分赛队伍";
							}
						}
						else
						{
							List<SceneSyncRequest> friendsPlayInviteList = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
							component2.text = friendsPlayInviteList[j].requesterName;
							RelationData relationData2 = null;
							DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(friendsPlayInviteList[j].requester, ref relationData2);
							if (relationData2 != null && relationData2.remark != null && relationData2.remark != string.Empty)
							{
								component2.text = relationData2.remark;
							}
							gameObject4.GetComponent<Text>().text = string.Format("Lv.{0}", friendsPlayInviteList[j].requesterLevel);
							id = (int)friendsPlayInviteList[j].requesterOccu;
							gameObject5.GetComponent<Text>().text = "邀请你进行好友切磋";
						}
						JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								Image component3 = gameObject2.GetComponent<Image>();
								ETCImageLoader.LoadSprite(ref component3, tableItem2.IconPath, true);
							}
						}
						Button component4 = gameObject6.GetComponent<Button>();
						component4.onClick.RemoveAllListeners();
						int index = j;
						component4.onClick.AddListener(delegate()
						{
							this.OnReject(index);
						});
						Button component5 = gameObject7.GetComponent<Button>();
						component5.onClick.RemoveAllListeners();
						int iIndex = j;
						component5.onClick.AddListener(delegate()
						{
							this.OnAgree(iIndex);
						});
						this.EleObjList[j].SetActive(true);
					}
				}
				else
				{
					this.EleObjList[j].SetActive(false);
				}
			}
		}

		// Token: 0x06011933 RID: 71987 RVA: 0x0051EEC8 File Offset: 0x0051D2C8
		protected override void _bindExUI()
		{
			this.mBtRejectAll = this.mBind.GetCom<Button>("BtRejectAll");
			this.mBtRejectAll.onClick.AddListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mEleRoot = this.mBind.GetGameObject("EleRoot");
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mTitle = this.mBind.GetCom<Text>("Title");
			this.mMainTabs = this.mBind.GetCom<ComUIListScript>("MainTabs");
		}

		// Token: 0x06011934 RID: 71988 RVA: 0x0051EF7C File Offset: 0x0051D37C
		protected override void _unbindExUI()
		{
			this.mBtRejectAll.onClick.RemoveListener(new UnityAction(this._onBtRejectAllButtonClick));
			this.mBtRejectAll = null;
			this.mEleRoot = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mTitle = null;
			this.mMainTabs = null;
		}

		// Token: 0x06011935 RID: 71989 RVA: 0x0051EFE4 File Offset: 0x0051D3E4
		private void _onBtRejectAllButtonClick()
		{
			NetManager netManager = NetManager.Instance();
			byte b = 0;
			if (this.invitedTabType == InvitedTabType.ITT_DuelTeam)
			{
				b = 1;
				List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
				inviteRoomList.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
				for (int i = 0; i < inviteRoomList.Count; i++)
				{
					netManager.SendCommand<WorldBeInviteRoomReq>(ServerType.GATE_SERVER, new WorldBeInviteRoomReq
					{
						roomId = inviteRoomList[i].roomId,
						invitePlayerId = inviteRoomList[i].inviterId,
						isAccept = 0,
						slotGroup = inviteRoomList[i].slotGroup
					});
				}
				inviteRoomList.Clear();
				DataManager<Pk3v3DataManager>.GetInstance().ClearAllInviteInfo();
				DataManager<Pk3v3CrossDataManager>.GetInstance().ClearAllInviteInfo();
			}
			else
			{
				List<SceneSyncRequest> friendsPlayInviteList = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
				for (int j = 0; j < friendsPlayInviteList.Count; j++)
				{
					DataManager<RelationDataManager>.GetInstance().ReplyRequest(friendsPlayInviteList[j], 0);
				}
				friendsPlayInviteList.Clear();
			}
			this.invitedTabType = InvitedTabType.ITT_None;
			this.UpdateEleObjList();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.Pk3v3InviteRoomListUpdate, b, null, null, null);
			List<WorldSyncRoomInviteInfo> inviteRoomList2 = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
			inviteRoomList2.AddRange(DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList());
			List<SceneSyncRequest> friendsPlayInviteList2 = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
			if (inviteRoomList2.Count <= 0 && friendsPlayInviteList2.Count <= 0)
			{
				this.frameMgr.CloseFrame<TeamBeInvitedListFrame>(this, false);
			}
		}

		// Token: 0x06011936 RID: 71990 RVA: 0x0051F162 File Offset: 0x0051D562
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<TeamBeInvitedListFrame>(this, false);
		}

		// Token: 0x0400B6D8 RID: 46808
		private string BeInvitedListElePath = "UIFlatten/Prefabs/Team/TeamBeInvitedEle";

		// Token: 0x0400B6D9 RID: 46809
		private InviteType inviteType;

		// Token: 0x0400B6DA RID: 46810
		private List<GameObject> EleObjList = new List<GameObject>();

		// Token: 0x0400B6DB RID: 46811
		private InvitedTabType invitedTabType;

		// Token: 0x0400B6DC RID: 46812
		private List<InvitedTabData> mMainTabDataList = new List<InvitedTabData>();

		// Token: 0x0400B6DD RID: 46813
		private Button mBtRejectAll;

		// Token: 0x0400B6DE RID: 46814
		private GameObject mEleRoot;

		// Token: 0x0400B6DF RID: 46815
		private Button mBtClose;

		// Token: 0x0400B6E0 RID: 46816
		private Text mTitle;

		// Token: 0x0400B6E1 RID: 46817
		private ComUIListScript mMainTabs;
	}
}
