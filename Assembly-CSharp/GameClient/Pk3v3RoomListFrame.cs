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
	// Token: 0x020019AA RID: 6570
	public class Pk3v3RoomListFrame : ClientFrame
	{
		// Token: 0x0601004F RID: 65615 RVA: 0x004711C7 File Offset: 0x0046F5C7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3RoomListFrame";
		}

		// Token: 0x06010050 RID: 65616 RVA: 0x004711CE File Offset: 0x0046F5CE
		protected override void _OnOpenFrame()
		{
			this.InitData();
			this.SendNormalRoomListReq();
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x06010051 RID: 65617 RVA: 0x004711E8 File Offset: 0x0046F5E8
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x06010052 RID: 65618 RVA: 0x004711F6 File Offset: 0x0046F5F6
		private void ClearData()
		{
			this.TimeIntrval = 0f;
			this.IsFliterRequest = false;
			this.roomList = null;
			this.CurPage = 0;
			this.MaxPage = 0;
		}

		// Token: 0x06010053 RID: 65619 RVA: 0x0047121F File Offset: 0x0046F61F
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnInviteRoomListUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RefreshRoomList, new ClientEventSystem.UIEventHandler(this.OnRefreshRoomList));
		}

		// Token: 0x06010054 RID: 65620 RVA: 0x00471257 File Offset: 0x0046F657
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnInviteRoomListUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RefreshRoomList, new ClientEventSystem.UIEventHandler(this.OnRefreshRoomList));
		}

		// Token: 0x06010055 RID: 65621 RVA: 0x0047128F File Offset: 0x0046F68F
		private void OnInviteRoomListUpdate(UIEvent iEvent)
		{
			this.UpdateInviteList();
		}

		// Token: 0x06010056 RID: 65622 RVA: 0x00471297 File Offset: 0x0046F697
		private void OnRefreshRoomList(UIEvent iEvent)
		{
			this.SendRoomListReq();
		}

		// Token: 0x06010057 RID: 65623 RVA: 0x004712A0 File Offset: 0x0046F6A0
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
			if (this.roomList.rooms[iIndex].limitPlayerLevel > DataManager<PlayerBaseData>.GetInstance().Level)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("等级不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if ((ulong)this.roomList.rooms[iIndex].limitPlayerSeasonLevel > (ulong)((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel))
			{
				SystemNotifyManager.SysNotifyFloatingEffect("段位不足", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this.roomList.rooms[iIndex].roomStatus != 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect("该房间已进入比赛", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
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
			Pk3v3DataManager.SendJoinRoomReq(this.roomList.rooms[iIndex].id, (RoomType)this.roomList.rooms[iIndex].roomType, string.Empty, 0U);
		}

		// Token: 0x06010058 RID: 65624 RVA: 0x0047141F File Offset: 0x0046F81F
		private void InitInterface()
		{
			this.InitRoomScrollListBind();
			this.UpdateInviteList();
		}

		// Token: 0x06010059 RID: 65625 RVA: 0x00471430 File Offset: 0x0046F830
		private void InitData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(320, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.RoomNumPerPage = tableItem.Value;
			}
		}

		// Token: 0x0601005A RID: 65626 RVA: 0x0047146C File Offset: 0x0046F86C
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

		// Token: 0x0601005B RID: 65627 RVA: 0x004714C4 File Offset: 0x0046F8C4
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
			com.text = roomSimpleInfo.id.ToString();
			com10.gameObject.CustomActive(roomSimpleInfo.isPassword > 0);
			com2.text = roomSimpleInfo.name;
			com3.text = DataManager<Pk3v3DataManager>.GetInstance().GetRoomState((RoomStatus)roomSimpleInfo.roomStatus);
			if ((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel >= (long)((ulong)roomSimpleInfo.limitPlayerSeasonLevel))
			{
				com4.text = string.Format("<color=#ffffffff>{0}</color>", DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName((int)roomSimpleInfo.limitPlayerSeasonLevel));
			}
			else
			{
				com4.text = string.Format("<color=#f0cd0dff>{0}</color>", DataManager<SeasonDataManager>.GetInstance().GetSimpleRankName((int)roomSimpleInfo.limitPlayerSeasonLevel));
			}
			if (DataManager<PlayerBaseData>.GetInstance().Level >= roomSimpleInfo.limitPlayerLevel)
			{
				com5.text = string.Format("<color=#ffffffff>{0}</color>", roomSimpleInfo.limitPlayerLevel);
			}
			else
			{
				com5.text = string.Format("<color=#f0cd0dff>{0}</color>", roomSimpleInfo.limitPlayerLevel);
			}
			com6.text = DataManager<Pk3v3DataManager>.GetInstance().GetRoomType((RoomType)roomSimpleInfo.roomType);
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
				if (roomSimpleInfo.roomStatus == 4 || roomSimpleInfo.playerSize >= roomSimpleInfo.playerMaxSize || roomSimpleInfo.limitPlayerLevel > DataManager<PlayerBaseData>.GetInstance().Level || (ulong)roomSimpleInfo.limitPlayerSeasonLevel > (ulong)((long)DataManager<SeasonDataManager>.GetInstance().seasonLevel))
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
			com8.onClick.RemoveAllListeners();
			int iIndex = item.m_index;
			com8.onClick.AddListener(delegate()
			{
				this.OnJoinRoom(iIndex);
			});
		}

		// Token: 0x0601005C RID: 65628 RVA: 0x004717D1 File Offset: 0x0046FBD1
		private void RefreshPetItemListCount()
		{
			this.mUIListScript.SetElementAmount(this.roomList.rooms.Length);
		}

		// Token: 0x0601005D RID: 65629 RVA: 0x004717EC File Offset: 0x0046FBEC
		private void UpdateInviteList()
		{
			List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
			this.mInviteImg.gameObject.CustomActive(inviteRoomList.Count > 0);
			this.mIniteNum.gameObject.CustomActive(inviteRoomList.Count > 0);
			this.mIniteNum.text = inviteRoomList.Count.ToString();
		}

		// Token: 0x0601005E RID: 65630 RVA: 0x00471858 File Offset: 0x0046FC58
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

		// Token: 0x0601005F RID: 65631 RVA: 0x00471909 File Offset: 0x0046FD09
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

		// Token: 0x06010060 RID: 65632 RVA: 0x0047193A File Offset: 0x0046FD3A
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06010061 RID: 65633 RVA: 0x0047193D File Offset: 0x0046FD3D
		protected override void _OnUpdate(float timeElapsed)
		{
			this.TimeIntrval += timeElapsed;
			if (this.TimeIntrval >= 5f)
			{
				this.TimeIntrval = 0f;
				this.SendRoomListReq();
			}
		}

		// Token: 0x06010062 RID: 65634 RVA: 0x00471970 File Offset: 0x0046FD70
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

		// Token: 0x06010063 RID: 65635 RVA: 0x00471A38 File Offset: 0x0046FE38
		private void SendNormalRoomListReq()
		{
			WorldRoomListReq worldRoomListReq = new WorldRoomListReq();
			worldRoomListReq.count = (uint)this.RoomNumPerPage;
			worldRoomListReq.startIndex = (uint)(this.CurPage * this.RoomNumPerPage);
			worldRoomListReq.roomType = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomListReq>(ServerType.GATE_SERVER, worldRoomListReq);
		}

		// Token: 0x06010064 RID: 65636 RVA: 0x00471A80 File Offset: 0x0046FE80
		private void SendFliterRoomListReq()
		{
			WorldRoomListReq worldRoomListReq = new WorldRoomListReq();
			worldRoomListReq.count = (uint)this.RoomNumPerPage;
			worldRoomListReq.startIndex = 0U;
			worldRoomListReq.roomType = 1;
			worldRoomListReq.limitPlayerLevel = DataManager<PlayerBaseData>.GetInstance().Level;
			worldRoomListReq.limitPlayerSeasonLevel = (uint)DataManager<SeasonDataManager>.GetInstance().seasonLevel;
			worldRoomListReq.roomStatus = 1;
			worldRoomListReq.isPassword = 0;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomListReq>(ServerType.GATE_SERVER, worldRoomListReq);
		}

		// Token: 0x06010065 RID: 65637 RVA: 0x00471AEC File Offset: 0x0046FEEC
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

		// Token: 0x06010066 RID: 65638 RVA: 0x00471CE4 File Offset: 0x004700E4
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

		// Token: 0x06010067 RID: 65639 RVA: 0x00471E25 File Offset: 0x00470225
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<Pk3v3RoomListFrame>(this, false);
		}

		// Token: 0x06010068 RID: 65640 RVA: 0x00471E34 File Offset: 0x00470234
		private void _onBtInviteInfoButtonClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamBeInvitedListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
		}

		// Token: 0x06010069 RID: 65641 RVA: 0x00471E4D File Offset: 0x0047024D
		private void _onBtCreateRoomButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3TypeChooseFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3TypeChooseFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0601006A RID: 65642 RVA: 0x00471E72 File Offset: 0x00470272
		private void _onBtAmusementRoomButtonClick()
		{
			Pk3v3DataManager.SendJoinRoomReq(0U, RoomType.ROOM_TYPE_THREE_FREE, string.Empty, 0U);
		}

		// Token: 0x0601006B RID: 65643 RVA: 0x00471E81 File Offset: 0x00470281
		private void _onBtRankRoomButtonClick()
		{
			if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_3v3_TUMBLE))
			{
				SystemNotifyManager.SystemNotify(5, string.Empty);
				return;
			}
			Pk3v3DataManager.SendJoinRoomReq(0U, RoomType.ROOM_TYPE_MELEE, string.Empty, 0U);
		}

		// Token: 0x0601006C RID: 65644 RVA: 0x00471EAD File Offset: 0x004702AD
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

		// Token: 0x0601006D RID: 65645 RVA: 0x00471ED6 File Offset: 0x004702D6
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

		// Token: 0x0601006E RID: 65646 RVA: 0x00471F06 File Offset: 0x00470306
		private void _onConditionFliterToggleValueChange(bool changed)
		{
			this.IsFliterRequest = changed;
			this.SendRoomListReq();
		}

		// Token: 0x0400A1A8 RID: 41384
		private int RoomNumPerPage = 10;

		// Token: 0x0400A1A9 RID: 41385
		private const float RequestTimeIntrval = 5f;

		// Token: 0x0400A1AA RID: 41386
		private float TimeIntrval;

		// Token: 0x0400A1AB RID: 41387
		private bool IsFliterRequest;

		// Token: 0x0400A1AC RID: 41388
		private RoomListInfo roomList = new RoomListInfo();

		// Token: 0x0400A1AD RID: 41389
		private int CurPage;

		// Token: 0x0400A1AE RID: 41390
		private int MaxPage;

		// Token: 0x0400A1AF RID: 41391
		private Button mBtClose;

		// Token: 0x0400A1B0 RID: 41392
		private ComUIListScript mUIListScript;

		// Token: 0x0400A1B1 RID: 41393
		private Button mBtInviteInfo;

		// Token: 0x0400A1B2 RID: 41394
		private Button mBtCreateRoom;

		// Token: 0x0400A1B3 RID: 41395
		private Button mBtAmusementRoom;

		// Token: 0x0400A1B4 RID: 41396
		private Button mBtRankRoom;

		// Token: 0x0400A1B5 RID: 41397
		private Button mBtLeft;

		// Token: 0x0400A1B6 RID: 41398
		private Button mBtRight;

		// Token: 0x0400A1B7 RID: 41399
		private Text mShowPage;

		// Token: 0x0400A1B8 RID: 41400
		private Toggle mConditionFliter;

		// Token: 0x0400A1B9 RID: 41401
		private Image mInviteImg;

		// Token: 0x0400A1BA RID: 41402
		private Text mIniteNum;
	}
}
