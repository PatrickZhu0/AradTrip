using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019BA RID: 6586
	public class Pk3v3CrossTeamListFrame : ClientFrame
	{
		// Token: 0x06010163 RID: 65891 RVA: 0x00478BDC File Offset: 0x00476FDC
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3Cross/Pk3v3CrossTeamList";
		}

		// Token: 0x06010164 RID: 65892 RVA: 0x00478BE3 File Offset: 0x00476FE3
		protected override void _OnOpenFrame()
		{
			this.InitData();
			this.SendNormalRoomListReq();
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x06010165 RID: 65893 RVA: 0x00478BFD File Offset: 0x00476FFD
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x06010166 RID: 65894 RVA: 0x00478C0B File Offset: 0x0047700B
		private void ClearData()
		{
			this.TimeIntrval = 0f;
			this.IsFliterRequest = false;
			this.roomList = null;
			this.CurPage = 0;
			this.MaxPage = 0;
		}

		// Token: 0x06010167 RID: 65895 RVA: 0x00478C34 File Offset: 0x00477034
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnInviteRoomListUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RefreshRoomList, new ClientEventSystem.UIEventHandler(this.OnRefreshRoomList));
		}

		// Token: 0x06010168 RID: 65896 RVA: 0x00478C6C File Offset: 0x0047706C
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnInviteRoomListUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RefreshRoomList, new ClientEventSystem.UIEventHandler(this.OnRefreshRoomList));
		}

		// Token: 0x06010169 RID: 65897 RVA: 0x00478CA4 File Offset: 0x004770A4
		private void OnInviteRoomListUpdate(UIEvent iEvent)
		{
			this.UpdateInviteList();
		}

		// Token: 0x0601016A RID: 65898 RVA: 0x00478CAC File Offset: 0x004770AC
		private void OnRefreshRoomList(UIEvent iEvent)
		{
			this.SendRoomListReq();
		}

		// Token: 0x0601016B RID: 65899 RVA: 0x00478CB4 File Offset: 0x004770B4
		private void SendCancelOnePersonMatchGameReq()
		{
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0601016C RID: 65900 RVA: 0x00478CD8 File Offset: 0x004770D8
		private void SwitchSceneToTown()
		{
			PkWaitingRoomData pkWaitingRoomData = new PkWaitingRoomData();
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town from Pk3v3WaitingRoom");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = pkWaitingRoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = pkWaitingRoomData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<Pk3v3CrossTeamListFrame>(this, false);
		}

		// Token: 0x0601016D RID: 65901 RVA: 0x00478D58 File Offset: 0x00477158
		private void SendQuitRoomReq()
		{
			WorldQuitRoomReq cmd = new WorldQuitRoomReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQuitRoomReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0601016E RID: 65902 RVA: 0x00478D7C File Offset: 0x0047717C
		private void OnJoinRoom(int iIndex)
		{
			if (this.roomList == null || this.roomList.rooms == null)
			{
				return;
			}
			if (iIndex < 0 || iIndex >= this.roomList.rooms.Length)
			{
				return;
			}
			if (this.roomList.rooms[iIndex].playerSize >= this.roomList.rooms[iIndex].playerMaxSize)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("房间人数已满", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.roomList.rooms[iIndex].isLimitPlayerLevel > 0 && this.roomList.rooms[iIndex].limitPlayerLevel > DataManager<PlayerBaseData>.GetInstance().Level)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.roomList.rooms[iIndex].isLimitPlayerSeasonLevel > 0 && (ulong)this.roomList.rooms[iIndex].limitPlayerSeasonLevel > (ulong)((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("段位不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.roomList.rooms[iIndex].roomStatus != 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("目标已进入比赛", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.roomList.rooms[iIndex].isPassword > 0)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CheckPasswordFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3CheckPasswordFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CheckPasswordFrame>(FrameLayer.Middle, this.roomList.rooms[iIndex], string.Empty);
				return;
			}
			uint id = this.roomList.rooms[iIndex].id;
			Pk3v3CrossDataManager.My3v3PkInfo pkInfo = DataManager<Pk3v3CrossDataManager>.GetInstance().PkInfo;
			if (pkInfo != null && (long)pkInfo.nCurPkCount >= (long)((ulong)Pk3v3CrossDataManager.MAX_PK_COUNT))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("挑战次数已达上限，操作失败", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.frameMgr.IsFrameOpen<PkSeekWaiting>(null) || DataManager<Pk3v3CrossDataManager>.GetInstance().CheckRoomIsMatching())
			{
				SystemNotifyManager.SysNotifyFloatingEffect("匹配中无法进行该操作，请取消后再试", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			Pk3v3CrossDataManager.SendJoinRoomReq(this.roomList.rooms[iIndex].id, RoomType.ROOM_TYPE_THREE_SCORE_WAR, string.Empty, 0U);
		}

		// Token: 0x0601016F RID: 65903 RVA: 0x00478F8A File Offset: 0x0047738A
		private void InitInterface()
		{
			this.InitRoomScrollListBind();
			this.UpdateInviteList();
		}

		// Token: 0x06010170 RID: 65904 RVA: 0x00478F98 File Offset: 0x00477398
		private void InitData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(320, string.Empty, string.Empty);
			if (tableItem != null)
			{
			}
		}

		// Token: 0x06010171 RID: 65905 RVA: 0x00478FC8 File Offset: 0x004773C8
		private void InitRoomScrollListBind()
		{
			this.mUIListScript.Initialize();
			this.mUIListScript.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this.UpdateRoomScrollListBind(item);
				}
			};
			this.mUIListScript.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Button com = component.GetCom<Button>("join");
				com.onClick.RemoveAllListeners();
			};
		}

		// Token: 0x06010172 RID: 65906 RVA: 0x00479020 File Offset: 0x00477420
		private void UpdateRoomScrollListBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.roomList.rooms.Length)
			{
				return;
			}
			RoomSimpleInfo roomSimpleInfo = this.roomList.rooms[item.m_index];
			Text com = component.GetCom<Text>("id");
			Text com2 = component.GetCom<Text>("RoomName");
			Text com3 = component.GetCom<Text>("state");
			Text com4 = component.GetCom<Text>("rank");
			Text com5 = component.GetCom<Text>("lv");
			Text com6 = component.GetCom<Text>("roomtype");
			Text com7 = component.GetCom<Text>("num");
			Button com8 = component.GetCom<Button>("join");
			UIGray com9 = component.GetCom<UIGray>("JoinUIGray");
			Image com10 = component.GetCom<Image>("Lock");
			Image com11 = component.GetCom<Image>("headIcon");
			Image com12 = component.GetCom<Image>("seasonLV");
			Text com13 = component.GetCom<Text>("seasonText");
			Image com14 = component.GetCom<Image>("MainSeasonLV");
			Image com15 = component.GetCom<Image>("SubSeasonLV");
			com.text = roomSimpleInfo.id.ToString();
			com10.gameObject.CustomActive(roomSimpleInfo.isPassword > 0);
			com2.text = roomSimpleInfo.name;
			com3.text = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomState((RoomStatus)roomSimpleInfo.roomStatus);
			if (roomSimpleInfo.isLimitPlayerSeasonLevel == 0)
			{
				com4.text = "无";
			}
			else if ((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel >= (long)((ulong)roomSimpleInfo.limitPlayerSeasonLevel))
			{
				com4.text = string.Format("<color=#ffffffff>{0}</color>", DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName((int)roomSimpleInfo.limitPlayerSeasonLevel));
			}
			else
			{
				com4.text = string.Format("<color=#f0cd0dff>{0}</color>", DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName((int)roomSimpleInfo.limitPlayerSeasonLevel));
			}
			if (roomSimpleInfo.isLimitPlayerLevel == 0)
			{
				com5.text = "无";
			}
			else if (DataManager<PlayerBaseData>.GetInstance().Level >= roomSimpleInfo.limitPlayerLevel)
			{
				com5.text = string.Format("<color=#ffffffff>{0}</color>", roomSimpleInfo.limitPlayerLevel);
			}
			else
			{
				com5.text = string.Format("<color=#f0cd0dff>{0}</color>", roomSimpleInfo.limitPlayerLevel);
			}
			com6.text = DataManager<Pk3v3CrossDataManager>.GetInstance().GetRoomType((RoomType)roomSimpleInfo.roomType);
			if (roomSimpleInfo.playerSize < roomSimpleInfo.playerMaxSize)
			{
				com7.text = string.Format("<color=#ffffffff>{0}/{1}</color>", roomSimpleInfo.playerSize, roomSimpleInfo.playerMaxSize);
			}
			else
			{
				com7.text = string.Format("<color=#f0cd0dff>{0}/{1}</color>", roomSimpleInfo.playerSize, roomSimpleInfo.playerMaxSize);
			}
			if (com9 != null)
			{
				if (roomSimpleInfo.roomStatus == 4 || roomSimpleInfo.roomStatus == 3 || roomSimpleInfo.roomStatus == 2 || roomSimpleInfo.playerSize >= roomSimpleInfo.playerMaxSize || (roomSimpleInfo.isLimitPlayerLevel != 0 && roomSimpleInfo.limitPlayerLevel > DataManager<PlayerBaseData>.GetInstance().Level) || (roomSimpleInfo.isLimitPlayerSeasonLevel != 0 && (ulong)roomSimpleInfo.limitPlayerSeasonLevel > (ulong)((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel)))
				{
					com9.enabled = true;
					com8.interactable = false;
				}
				else
				{
					com9.enabled = false;
					com8.interactable = true;
				}
			}
			int ownerOccu = (int)roomSimpleInfo.ownerOccu;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(ownerOccu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					ETCImageLoader.LoadSprite(ref com11, tableItem2.IconPath, true);
				}
			}
			int ownerSeasonLevel = (int)roomSimpleInfo.ownerSeasonLevel;
			string mainSeasonLevelSmallIcon = DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(ownerSeasonLevel);
			ETCImageLoader.LoadSprite(ref com12, mainSeasonLevelSmallIcon, true);
			int ownerSeasonLevel2 = (int)roomSimpleInfo.ownerSeasonLevel;
			ETCImageLoader.LoadSprite(ref com14, DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon(ownerSeasonLevel2), true);
			ETCImageLoader.LoadSprite(ref com15, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon(ownerSeasonLevel2), true);
			com13.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)roomSimpleInfo.ownerSeasonLevel, true);
			com8.onClick.RemoveAllListeners();
			int iIndex = item.m_index;
			com8.onClick.AddListener(delegate()
			{
				this.OnJoinRoom(iIndex);
			});
		}

		// Token: 0x06010173 RID: 65907 RVA: 0x0047949A File Offset: 0x0047789A
		private void RefreshPetItemListCount()
		{
			this.mUIListScript.SetElementAmount(this.roomList.rooms.Length);
		}

		// Token: 0x06010174 RID: 65908 RVA: 0x004794B4 File Offset: 0x004778B4
		private void UpdateInviteList()
		{
			List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList();
			this.mInviteImg.gameObject.CustomActive(inviteRoomList.Count > 0);
			this.mIniteNum.gameObject.CustomActive(inviteRoomList.Count > 0);
			this.mIniteNum.text = inviteRoomList.Count.ToString();
		}

		// Token: 0x06010175 RID: 65909 RVA: 0x00479520 File Offset: 0x00477920
		private void UpdatePage()
		{
			UIGray component = this.mBtLeft.GetComponent<UIGray>();
			UIGray component2 = this.mBtRight.GetComponent<UIGray>();
			component.enabled = false;
			component2.enabled = false;
			if (this.MaxPage <= 1)
			{
				component.enabled = true;
				component2.enabled = true;
			}
			else if (this.CurPage >= this.MaxPage - 1)
			{
				component2.enabled = true;
			}
			else if (this.CurPage <= 0)
			{
				component.enabled = true;
			}
			this.mShowPage.text = string.Format("{0}/{1}", this.CurPage + 1, this.MaxPage);
		}

		// Token: 0x06010176 RID: 65910 RVA: 0x004795D1 File Offset: 0x004779D1
		private void SendRoomListReq()
		{
			if (this.CurPage < 0)
			{
				this.CurPage = 0;
			}
			if (!this.IsFliterRequest)
			{
				this.SendNormalRoomListReq();
			}
			else
			{
				this.SendFliterRoomListReq();
			}
		}

		// Token: 0x06010177 RID: 65911 RVA: 0x00479602 File Offset: 0x00477A02
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06010178 RID: 65912 RVA: 0x00479605 File Offset: 0x00477A05
		protected override void _OnUpdate(float timeElapsed)
		{
			this.TimeIntrval += timeElapsed;
			if (this.TimeIntrval >= 5f)
			{
				this.TimeIntrval = 0f;
				this.SendRoomListReq();
			}
		}

		// Token: 0x06010179 RID: 65913 RVA: 0x00479638 File Offset: 0x00477A38
		[MessageHandle(607812U, false, 0)]
		private void OnRoomListRes(MsgDATA msg)
		{
			WorldRoomListRes worldRoomListRes = new WorldRoomListRes();
			worldRoomListRes.decode(msg.bytes);
			if (worldRoomListRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldRoomListRes.result, string.Empty);
				return;
			}
			this.roomList = worldRoomListRes.roomList;
			this.MaxPage = (int)(worldRoomListRes.roomList.total / (uint)this.RoomNumPerPage);
			if ((ulong)worldRoomListRes.roomList.total % (ulong)((long)this.RoomNumPerPage) != 0UL)
			{
				this.MaxPage++;
			}
			if (this.CurPage > this.MaxPage - 1)
			{
				this.CurPage = this.MaxPage - 1;
			}
			if (this.CurPage < 0)
			{
				this.CurPage = -1;
			}
			this.RefreshPetItemListCount();
			this.UpdatePage();
		}

		// Token: 0x0601017A RID: 65914 RVA: 0x00479700 File Offset: 0x00477B00
		private void SendNormalRoomListReq()
		{
			WorldRoomListReq worldRoomListReq = new WorldRoomListReq();
			worldRoomListReq.roomType = 3;
			worldRoomListReq.count = (uint)this.RoomNumPerPage;
			worldRoomListReq.startIndex = (uint)(this.CurPage * this.RoomNumPerPage);
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomListReq>(ServerType.GATE_SERVER, worldRoomListReq);
		}

		// Token: 0x0601017B RID: 65915 RVA: 0x00479748 File Offset: 0x00477B48
		private void SendFliterRoomListReq()
		{
			WorldRoomListReq worldRoomListReq = new WorldRoomListReq();
			worldRoomListReq.roomType = 3;
			worldRoomListReq.count = (uint)this.RoomNumPerPage;
			worldRoomListReq.startIndex = 0U;
			worldRoomListReq.limitPlayerLevel = DataManager<PlayerBaseData>.GetInstance().Level;
			worldRoomListReq.limitPlayerSeasonLevel = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel;
			worldRoomListReq.roomStatus = 1;
			worldRoomListReq.isPassword = 0;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomListReq>(ServerType.GATE_SERVER, worldRoomListReq);
		}

		// Token: 0x0601017C RID: 65916 RVA: 0x004797B4 File Offset: 0x00477BB4
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mUIListScript = this.mBind.GetCom<ComUIListScript>("UIListScript");
			this.mBtInviteInfo = this.mBind.GetCom<Button>("btInviteInfo");
			this.mBtInviteInfo.onClick.AddListener(new UnityAction(this._onBtInviteInfoButtonClick));
			this.mBtCreateRoom = this.mBind.GetCom<Button>("btCreateRoom");
			this.mBtCreateRoom.onClick.AddListener(new UnityAction(this._onBtCreateRoomButtonClick));
			this.mBtAmusementRoom = this.mBind.GetCom<Button>("btAmusementRoom");
			this.mBtAmusementRoom.onClick.AddListener(new UnityAction(this._onBtAmusementRoomButtonClick));
			this.mBtRankRoom = this.mBind.GetCom<Button>("btRankRoom");
			this.mBtRankRoom.onClick.AddListener(new UnityAction(this._onBtRankRoomButtonClick));
			this.mBtLeft = this.mBind.GetCom<Button>("btLeft");
			this.mBtLeft.onClick.AddListener(new UnityAction(this._onBtLeftButtonClick));
			this.mBtRight = this.mBind.GetCom<Button>("btRight");
			this.mBtRight.onClick.AddListener(new UnityAction(this._onBtRightButtonClick));
			this.mShowPage = this.mBind.GetCom<Text>("ShowPage");
			this.mConditionFliter = this.mBind.GetCom<Toggle>("ConditionFliter");
			this.mConditionFliter.onValueChanged.AddListener(new UnityAction<bool>(this._onConditionFliterToggleValueChange));
			this.mInviteImg = this.mBind.GetCom<Image>("InviteImg");
			this.mIniteNum = this.mBind.GetCom<Text>("IniteNum");
		}

		// Token: 0x0601017D RID: 65917 RVA: 0x004799AC File Offset: 0x00477DAC
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mUIListScript = null;
			this.mBtInviteInfo.onClick.RemoveListener(new UnityAction(this._onBtInviteInfoButtonClick));
			this.mBtInviteInfo = null;
			this.mBtCreateRoom.onClick.RemoveListener(new UnityAction(this._onBtCreateRoomButtonClick));
			this.mBtCreateRoom = null;
			this.mBtAmusementRoom.onClick.RemoveListener(new UnityAction(this._onBtAmusementRoomButtonClick));
			this.mBtAmusementRoom = null;
			this.mBtRankRoom.onClick.RemoveListener(new UnityAction(this._onBtRankRoomButtonClick));
			this.mBtRankRoom = null;
			this.mBtLeft.onClick.RemoveListener(new UnityAction(this._onBtLeftButtonClick));
			this.mBtLeft = null;
			this.mBtRight.onClick.RemoveListener(new UnityAction(this._onBtRightButtonClick));
			this.mBtRight = null;
			this.mShowPage = null;
			this.mConditionFliter.onValueChanged.RemoveListener(new UnityAction<bool>(this._onConditionFliterToggleValueChange));
			this.mConditionFliter = null;
			this.mInviteImg = null;
			this.mIniteNum = null;
		}

		// Token: 0x0601017E RID: 65918 RVA: 0x00479AED File Offset: 0x00477EED
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3CrossTeamListFrame>(this, false);
		}

		// Token: 0x0601017F RID: 65919 RVA: 0x00479AFC File Offset: 0x00477EFC
		private void _onBtInviteInfoButtonClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamBeInvitedListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, "Pk3v3Cross");
		}

		// Token: 0x06010180 RID: 65920 RVA: 0x00479B18 File Offset: 0x00477F18
		private void _onBtCreateRoomButtonClick()
		{
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
			DataManager<Pk3v3CrossDataManager>.GetInstance().SendCreateRoomReq(RoomType.ROOM_TYPE_THREE_SCORE_WAR);
		}

		// Token: 0x06010181 RID: 65921 RVA: 0x00479B7E File Offset: 0x00477F7E
		private void _onBtAmusementRoomButtonClick()
		{
			Pk3v3CrossDataManager.SendJoinRoomReq(0U, RoomType.ROOM_TYPE_THREE_FREE, string.Empty, 0U);
		}

		// Token: 0x06010182 RID: 65922 RVA: 0x00479B90 File Offset: 0x00477F90
		private void _onBtRankRoomButtonClick()
		{
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
			Pk3v3CrossDataManager.SendJoinRoomReq(0U, RoomType.ROOM_TYPE_THREE_SCORE_WAR, string.Empty, 0U);
		}

		// Token: 0x06010183 RID: 65923 RVA: 0x00479BF8 File Offset: 0x00477FF8
		private void _onBtLeftButtonClick()
		{
			if (this.CurPage <= 0)
			{
				return;
			}
			this.CurPage--;
			this.SendRoomListReq();
			this.UpdatePage();
		}

		// Token: 0x06010184 RID: 65924 RVA: 0x00479C21 File Offset: 0x00478021
		private void _onBtRightButtonClick()
		{
			if (this.CurPage >= this.MaxPage - 1)
			{
				return;
			}
			this.CurPage++;
			this.SendRoomListReq();
			this.UpdatePage();
		}

		// Token: 0x06010185 RID: 65925 RVA: 0x00479C51 File Offset: 0x00478051
		private void _onConditionFliterToggleValueChange(bool changed)
		{
			this.IsFliterRequest = changed;
			this.SendRoomListReq();
		}

		// Token: 0x0400A25F RID: 41567
		private int RoomNumPerPage = 10;

		// Token: 0x0400A260 RID: 41568
		private const float RequestTimeIntrval = 5f;

		// Token: 0x0400A261 RID: 41569
		private float TimeIntrval;

		// Token: 0x0400A262 RID: 41570
		private bool IsFliterRequest;

		// Token: 0x0400A263 RID: 41571
		private RoomListInfo roomList = new RoomListInfo();

		// Token: 0x0400A264 RID: 41572
		private int CurPage;

		// Token: 0x0400A265 RID: 41573
		private int MaxPage;

		// Token: 0x0400A266 RID: 41574
		private Button mBtClose;

		// Token: 0x0400A267 RID: 41575
		private ComUIListScript mUIListScript;

		// Token: 0x0400A268 RID: 41576
		private Button mBtInviteInfo;

		// Token: 0x0400A269 RID: 41577
		private Button mBtCreateRoom;

		// Token: 0x0400A26A RID: 41578
		private Button mBtAmusementRoom;

		// Token: 0x0400A26B RID: 41579
		private Button mBtRankRoom;

		// Token: 0x0400A26C RID: 41580
		private Button mBtLeft;

		// Token: 0x0400A26D RID: 41581
		private Button mBtRight;

		// Token: 0x0400A26E RID: 41582
		private Text mShowPage;

		// Token: 0x0400A26F RID: 41583
		private Toggle mConditionFliter;

		// Token: 0x0400A270 RID: 41584
		private Image mInviteImg;

		// Token: 0x0400A271 RID: 41585
		private Text mIniteNum;
	}
}
