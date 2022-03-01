using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019A9 RID: 6569
	public class Pk3v3PlayerMenuFrame : ClientFrame
	{
		// Token: 0x06010034 RID: 65588 RVA: 0x00470769 File Offset: 0x0046EB69
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3Menu";
		}

		// Token: 0x06010035 RID: 65589 RVA: 0x00470770 File Offset: 0x0046EB70
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.slotinfo = (RoomSlotInfo)this.userData;
			}
			this.InitInterface();
			this.BindUIEvent();
			if (DataManager<Pk3v3DataManager>.GetInstance().isNotify)
			{
				this.RefreshChangePosState();
			}
		}

		// Token: 0x06010036 RID: 65590 RVA: 0x004707AF File Offset: 0x0046EBAF
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x06010037 RID: 65591 RVA: 0x004707BD File Offset: 0x0046EBBD
		private void ClearData()
		{
			this.slotinfo = null;
		}

		// Token: 0x06010038 RID: 65592 RVA: 0x004707C6 File Offset: 0x0046EBC6
		protected override void _OnUpdate(float timeElapsed)
		{
			this.RefreshChangePosState();
		}

		// Token: 0x06010039 RID: 65593 RVA: 0x004707CE File Offset: 0x0046EBCE
		public override bool IsNeedUpdate()
		{
			return DataManager<Pk3v3DataManager>.GetInstance().isNotify;
		}

		// Token: 0x0601003A RID: 65594 RVA: 0x004707DC File Offset: 0x0046EBDC
		private void RefreshChangePosState()
		{
			this.mChangePosGray.enabled = true;
			this.mChangePos.interactable = false;
			int iInt = DataManager<Pk3v3DataManager>.GetInstance().iInt;
			this.mChangePosTimer.text = string.Format("{0}s", iInt);
			if ((double)iInt < 0.05)
			{
				this.mChangePosGray.enabled = false;
				this.mChangePosTimer.text = string.Empty;
				DataManager<Pk3v3DataManager>.GetInstance().isNotify = false;
				this.mChangePos.interactable = true;
			}
		}

		// Token: 0x0601003B RID: 65595 RVA: 0x0047086C File Offset: 0x0046EC6C
		public void SetPosition(Vector3 pos)
		{
			Vector3 position = default(Vector3);
			position = pos;
			position.y -= 60f;
			this.mContentRect.position = position;
		}

		// Token: 0x0601003C RID: 65596 RVA: 0x004708A2 File Offset: 0x0046ECA2
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3PlayerLeave, new ClientEventSystem.UIEventHandler(this.OnPlayerLeave));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
		}

		// Token: 0x0601003D RID: 65597 RVA: 0x004708DA File Offset: 0x0046ECDA
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3PlayerLeave, new ClientEventSystem.UIEventHandler(this.OnPlayerLeave));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
		}

		// Token: 0x0601003E RID: 65598 RVA: 0x00470914 File Offset: 0x0046ED14
		private void OnPlayerLeave(UIEvent iEvent)
		{
			byte b = (byte)iEvent.Param1;
			byte b2 = (byte)iEvent.Param2;
			if (this.slotinfo.group == b && this.slotinfo.index == b2)
			{
				this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
			}
		}

		// Token: 0x0601003F RID: 65599 RVA: 0x00470968 File Offset: 0x0046ED68
		private void OnPk3v3VoteEnterBattle(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x06010040 RID: 65600 RVA: 0x00470978 File Offset: 0x0046ED78
		private void InitInterface()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null from Pk3v3PlayerMenuFrame");
				return;
			}
			if (this.slotinfo == null)
			{
				Logger.LogError("pk3v3 slotinfo is null");
				return;
			}
			bool bActive = true;
			this.mChangePos.gameObject.CustomActive(bActive);
			this.mLookInfo.gameObject.CustomActive(this.slotinfo.playerId != 0UL);
			this.mAddFriend.gameObject.CustomActive(this.slotinfo.playerId != 0UL);
			this.mTransfer.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID && this.slotinfo.playerId != 0UL);
			this.mKickOutRoom.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID && this.slotinfo.playerId != 0UL);
			this.mClosePos.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			int num = 0;
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				BeTownPlayer townPlayer = clientSystemTown.GetTownPlayer(this.slotinfo.playerId);
				if (townPlayer != null)
				{
					num = townPlayer.GetPlayerZoneID();
				}
			}
			this.mLookInfo.gameObject.CustomActive(false);
			this.mAddFriend.gameObject.CustomActive(this.slotinfo.playerId != 0UL && num > 0 && num == DataManager<PlayerBaseData>.GetInstance().ZoneID);
		}

		// Token: 0x06010041 RID: 65601 RVA: 0x00470B38 File Offset: 0x0046EF38
		private void SendLookInfoReq()
		{
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.roleId = this.slotinfo.playerId;
			worldQueryPlayerReq.name = string.Empty;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_WATCH_PLAYER_INTO;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x06010042 RID: 65602 RVA: 0x00470B80 File Offset: 0x0046EF80
		private void SendAddFriendReq()
		{
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 3;
			sceneRequest.target = this.slotinfo.playerId;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
		}

		// Token: 0x06010043 RID: 65603 RVA: 0x00470BCC File Offset: 0x0046EFCC
		private void SendTransferPosReq()
		{
			WorldChangeRoomOwnerReq worldChangeRoomOwnerReq = new WorldChangeRoomOwnerReq();
			worldChangeRoomOwnerReq.playerId = this.slotinfo.playerId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldChangeRoomOwnerReq>(ServerType.GATE_SERVER, worldChangeRoomOwnerReq);
		}

		// Token: 0x06010044 RID: 65604 RVA: 0x00470C00 File Offset: 0x0046F000
		private void SendKickOutRoomReq()
		{
			WorldKickOutRoomReq worldKickOutRoomReq = new WorldKickOutRoomReq();
			worldKickOutRoomReq.playerId = this.slotinfo.playerId;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldKickOutRoomReq>(ServerType.GATE_SERVER, worldKickOutRoomReq);
		}

		// Token: 0x06010045 RID: 65605 RVA: 0x00470C34 File Offset: 0x0046F034
		protected override void _bindExUI()
		{
			this.mLookInfo = this.mBind.GetCom<Button>("LookInfo");
			this.mLookInfo.onClick.AddListener(new UnityAction(this._onLookInfoButtonClick));
			this.mChangePos = this.mBind.GetCom<Button>("ChangePos");
			this.mChangePos.onClick.AddListener(new UnityAction(this._onChangePosButtonClick));
			this.mAddFriend = this.mBind.GetCom<Button>("AddFriend");
			this.mAddFriend.onClick.AddListener(new UnityAction(this._onAddFriendButtonClick));
			this.mTransfer = this.mBind.GetCom<Button>("Transfer");
			this.mTransfer.onClick.AddListener(new UnityAction(this._onTransferButtonClick));
			this.mKickOutRoom = this.mBind.GetCom<Button>("KickOutRoom");
			this.mKickOutRoom.onClick.AddListener(new UnityAction(this._onKickOutRoomButtonClick));
			this.mClosePos = this.mBind.GetCom<Button>("ClosePos");
			this.mClosePos.onClick.AddListener(new UnityAction(this._onClosePosButtonClick));
			this.mContentRect = this.mBind.GetCom<RectTransform>("ContentRect");
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mChangePosTimer = this.mBind.GetCom<Text>("ChangePosTimer");
			this.mChangePosGray = this.mBind.GetCom<UIGray>("ChangePosGray");
		}

		// Token: 0x06010046 RID: 65606 RVA: 0x00470DE4 File Offset: 0x0046F1E4
		protected override void _unbindExUI()
		{
			this.mLookInfo.onClick.RemoveListener(new UnityAction(this._onLookInfoButtonClick));
			this.mLookInfo = null;
			this.mChangePos.onClick.RemoveListener(new UnityAction(this._onChangePosButtonClick));
			this.mChangePos = null;
			this.mAddFriend.onClick.RemoveListener(new UnityAction(this._onAddFriendButtonClick));
			this.mAddFriend = null;
			this.mTransfer.onClick.RemoveListener(new UnityAction(this._onTransferButtonClick));
			this.mTransfer = null;
			this.mKickOutRoom.onClick.RemoveListener(new UnityAction(this._onKickOutRoomButtonClick));
			this.mKickOutRoom = null;
			this.mClosePos.onClick.RemoveListener(new UnityAction(this._onClosePosButtonClick));
			this.mClosePos = null;
			this.mContentRect = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mChangePosTimer = null;
			this.mChangePosGray = null;
		}

		// Token: 0x06010047 RID: 65607 RVA: 0x00470EFB File Offset: 0x0046F2FB
		private void _onLookInfoButtonClick()
		{
			if (this.slotinfo.playerId == 0UL)
			{
				SystemNotifyManager.SystemNotify(3406004, string.Empty);
				return;
			}
			this.SendLookInfoReq();
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x06010048 RID: 65608 RVA: 0x00470F34 File Offset: 0x0046F334
		private void _onChangePosButtonClick()
		{
			if (this.slotinfo == null)
			{
				return;
			}
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			DataManager<Pk3v3DataManager>.GetInstance().SendPk3v3ChangePosReq(roomInfo.roomSimpleInfo.id, this.slotinfo);
			if (this.slotinfo.playerId > 0UL)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(315, string.Empty, string.Empty);
				if (tableItem != null)
				{
					float countDownTime = (float)tableItem.Value;
					DataManager<Pk3v3DataManager>.GetInstance().SetCountDownTime(countDownTime);
				}
			}
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x06010049 RID: 65609 RVA: 0x00470FDC File Offset: 0x0046F3DC
		private void _onAddFriendButtonClick()
		{
			if (this.slotinfo.playerId == 0UL)
			{
				SystemNotifyManager.SystemNotify(3406004, string.Empty);
				return;
			}
			this.SendAddFriendReq();
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x0601004A RID: 65610 RVA: 0x00471014 File Offset: 0x0046F414
		private void _onTransferButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			if (this.slotinfo.playerId == 0UL)
			{
				SystemNotifyManager.SystemNotify(3406004, string.Empty);
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
			{
				return;
			}
			this.SendTransferPosReq();
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x0601004B RID: 65611 RVA: 0x00471094 File Offset: 0x0046F494
		private void _onKickOutRoomButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			if (this.slotinfo.playerId == 0UL)
			{
				SystemNotifyManager.SystemNotify(3406004, string.Empty);
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
			{
				return;
			}
			this.SendKickOutRoomReq();
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x0601004C RID: 65612 RVA: 0x00471114 File Offset: 0x0046F514
		private void _onClosePosButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			if (this.slotinfo.playerId != 0UL)
			{
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
			{
				return;
			}
			DataManager<Pk3v3DataManager>.GetInstance().SendClosePosReq(this.slotinfo.group, this.slotinfo.index);
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x0601004D RID: 65613 RVA: 0x0047119D File Offset: 0x0046F59D
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3PlayerMenuFrame>(this, false);
		}

		// Token: 0x0400A19D RID: 41373
		private RoomSlotInfo slotinfo;

		// Token: 0x0400A19E RID: 41374
		private Button mLookInfo;

		// Token: 0x0400A19F RID: 41375
		private Button mChangePos;

		// Token: 0x0400A1A0 RID: 41376
		private Button mAddFriend;

		// Token: 0x0400A1A1 RID: 41377
		private Button mTransfer;

		// Token: 0x0400A1A2 RID: 41378
		private Button mKickOutRoom;

		// Token: 0x0400A1A3 RID: 41379
		private Button mClosePos;

		// Token: 0x0400A1A4 RID: 41380
		private RectTransform mContentRect;

		// Token: 0x0400A1A5 RID: 41381
		private Button mBtClose;

		// Token: 0x0400A1A6 RID: 41382
		private Text mChangePosTimer;

		// Token: 0x0400A1A7 RID: 41383
		private UIGray mChangePosGray;
	}
}
