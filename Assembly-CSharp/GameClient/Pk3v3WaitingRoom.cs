using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x020019AE RID: 6574
	public class Pk3v3WaitingRoom : ClientFrame
	{
		// Token: 0x060100AF RID: 65711 RVA: 0x00473F87 File Offset: 0x00472387
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3WaitingRoom";
		}

		// Token: 0x060100B0 RID: 65712 RVA: 0x00473F90 File Offset: 0x00472390
		protected override void _OnOpenFrame()
		{
			DataManager<Pk3v3CrossDataManager>.GetInstance()._UnBindNetMsg();
			if (this.userData != null)
			{
				this.RoomData = (this.userData as PkWaitingRoomData);
			}
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo != null)
			{
				if (roomInfo.roomSimpleInfo.roomType == 4)
				{
					this.LeftList = new GameObject[2];
					this.RightList = new GameObject[2];
				}
				else
				{
					this.LeftList = new GameObject[3];
					this.RightList = new GameObject[3];
				}
			}
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x060100B1 RID: 65713 RVA: 0x00474028 File Offset: 0x00472428
		protected override void _OnCloseFrame()
		{
			DataManager<Pk3v3CrossDataManager>.GetInstance()._BindNetMsg();
			this.ClearData();
			this.UnBindUIEvent();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3PlayerMenuFrame>(null, false);
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
		}

		// Token: 0x060100B2 RID: 65714 RVA: 0x00474088 File Offset: 0x00472488
		private void ClearData()
		{
			this.RoomData.Clear();
			this.SelfGroup = RoomSlotGroup.ROOM_SLOT_GROUP_INVALID;
			this.bSelfIsRoomOwner = false;
			this.bMatchLock = false;
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				this.LeftList[i] = null;
			}
			for (int j = 0; j < this.RightList.Length; j++)
			{
				this.RightList[j] = null;
			}
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			this.UnInitVoiceChat();
		}

		// Token: 0x060100B3 RID: 65715 RVA: 0x0047411C File Offset: 0x0047251C
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3KickOut, new ClientEventSystem.UIEventHandler(this.OnPk3v3KickOut));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Set3v3RoomName, new ClientEventSystem.UIEventHandler(this.OnSetName));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Set3v3RoomPassword, new ClientEventSystem.UIEventHandler(this.onSetPassword));
		}

		// Token: 0x060100B4 RID: 65716 RVA: 0x0047421C File Offset: 0x0047261C
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSimpleInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSimpleInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3RoomSlotInfoUpdate, new ClientEventSystem.UIEventHandler(this.OnPk3v3RoomSlotInfoUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3KickOut, new ClientEventSystem.UIEventHandler(this.OnPk3v3KickOut));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatch, new ClientEventSystem.UIEventHandler(this.OnBeginMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3BeginMatchRes, new ClientEventSystem.UIEventHandler(this.OnBeginMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatch, new ClientEventSystem.UIEventHandler(this.OnCancelMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3CancelMatchRes, new ClientEventSystem.UIEventHandler(this.OnCancelMatchRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Set3v3RoomName, new ClientEventSystem.UIEventHandler(this.OnSetName));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Set3v3RoomPassword, new ClientEventSystem.UIEventHandler(this.onSetPassword));
		}

		// Token: 0x060100B5 RID: 65717 RVA: 0x0047431C File Offset: 0x0047271C
		private void OnPk3v3RoomSimpleInfoUpdate(UIEvent iEvent)
		{
			this.UpdatePlayerList();
			this.SetRoomPassword();
		}

		// Token: 0x060100B6 RID: 65718 RVA: 0x0047432A File Offset: 0x0047272A
		private void OnPk3v3RoomSlotInfoUpdate(UIEvent iEvent)
		{
			this.UpdatePlayerList();
		}

		// Token: 0x060100B7 RID: 65719 RVA: 0x00474332 File Offset: 0x00472732
		private void OnPk3v3KickOut(UIEvent iEvent)
		{
			this.SwitchSceneToTown();
		}

		// Token: 0x060100B8 RID: 65720 RVA: 0x0047433C File Offset: 0x0047273C
		private void OnBeginMatch(UIEvent iEvent)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			PkSeekWaitingData pkSeekWaitingData = new PkSeekWaitingData();
			pkSeekWaitingData.roomtype = PkRoomType.Pk3v3;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, pkSeekWaitingData, string.Empty);
			if (roomInfo.roomSimpleInfo.roomType == 2)
			{
				this.ShowCancelText(roomInfo);
				ETCImageLoader.LoadSprite(ref this.mBtStartImage, this.StartBtnBluePath, true);
				this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomStatus == 3);
			}
			this.mBtBegin.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID || (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3));
		}

		// Token: 0x060100B9 RID: 65721 RVA: 0x00474416 File Offset: 0x00472816
		private void OnBeginMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x060100BA RID: 65722 RVA: 0x00474420 File Offset: 0x00472820
		private void OnCancelMatch(UIEvent iEvent)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			if (roomInfo.roomSimpleInfo.roomType == 2)
			{
				this.ShowBeginText(roomInfo);
				ETCImageLoader.LoadSprite(ref this.mBtStartImage, this.StartBtnRedPath, true);
				this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomStatus == 3);
			}
			this.mBtBegin.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID || (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3));
		}

		// Token: 0x060100BB RID: 65723 RVA: 0x004744E7 File Offset: 0x004728E7
		private void OnCancelMatchRes(UIEvent iEvent)
		{
			this.bMatchLock = false;
		}

		// Token: 0x060100BC RID: 65724 RVA: 0x004744F0 File Offset: 0x004728F0
		private void OnSetName(UIEvent iEvent)
		{
			string text = (string)iEvent.Param1;
			if (text != null && text != string.Empty)
			{
				this.mRoomName.text = text;
			}
		}

		// Token: 0x060100BD RID: 65725 RVA: 0x0047452B File Offset: 0x0047292B
		private void onSetPassword(UIEvent iEvent)
		{
			this.SetRoomPassword();
		}

		// Token: 0x060100BE RID: 65726 RVA: 0x00474533 File Offset: 0x00472933
		private void OnClickLeftIcon(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryOpenPlayerMenuFrame(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x060100BF RID: 65727 RVA: 0x0047454D File Offset: 0x0047294D
		private void OnClickLeftChangePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryChangePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x060100C0 RID: 65728 RVA: 0x00474567 File Offset: 0x00472967
		private void OnClickLeftClosePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryClosePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
		}

		// Token: 0x060100C1 RID: 65729 RVA: 0x00474581 File Offset: 0x00472981
		private void OnClickRightIcon(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryOpenPlayerMenuFrame(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x060100C2 RID: 65730 RVA: 0x0047459B File Offset: 0x0047299B
		private void OnClickRightChangePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryChangePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x060100C3 RID: 65731 RVA: 0x004745B5 File Offset: 0x004729B5
		private void OnClickRightClosePos(int iIndex)
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.TryClosePos(iIndex, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
		}

		// Token: 0x060100C4 RID: 65732 RVA: 0x004745CF File Offset: 0x004729CF
		private void InitInterface()
		{
			this.InitPlayerList();
			this._InitTalk();
			this.InitVoiceChat();
		}

		// Token: 0x060100C5 RID: 65733 RVA: 0x004745E4 File Offset: 0x004729E4
		private void InitPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitPlayerList]");
				return;
			}
			this.ShowBeginText(roomInfo);
			this.CheckSelfInfo();
			this.mRight.CustomActive(roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4);
			this.mBtSetting.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			this.mBtBegin.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			this.mRankBg.CustomActive(roomInfo.roomSimpleInfo.roomType == 2);
			this.mAmuseBg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4);
			this.mMatchTypeImg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 4);
			this.mAmuseTypeImg.gameObject.CustomActive(roomInfo.roomSimpleInfo.roomType == 1);
			this.InitLeftPlayerList();
			this.InitRightPlayerList();
			this.mRoomName.text = roomInfo.roomSimpleInfo.name;
			this.mRoomId.text = roomInfo.roomSimpleInfo.id.ToString();
			this.SetRoomPassword();
		}

		// Token: 0x060100C6 RID: 65734 RVA: 0x00474765 File Offset: 0x00472B65
		private void _InitTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkRoot);
		}

		// Token: 0x060100C7 RID: 65735 RVA: 0x00474778 File Offset: 0x00472B78
		private void InitLeftPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitLeftPlayerList]");
				return;
			}
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.PlayerInfoElePath, true, 0U);
				if (gameObject == null)
				{
					Logger.LogError("can't create left obj in pk3v3WaitinRoom");
					return;
				}
				gameObject.transform.SetParent(this.mLeft.transform, false);
				this.LeftList[i] = gameObject;
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
			}
		}

		// Token: 0x060100C8 RID: 65736 RVA: 0x0047482C File Offset: 0x00472C2C
		private void InitRightPlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitRightPlayerList]");
				return;
			}
			if (roomInfo.roomSimpleInfo.roomType == 2)
			{
				return;
			}
			for (int i = 0; i < this.RightList.Length; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.PlayerInfoElePath, true, 0U);
				if (gameObject == null)
				{
					Logger.LogError("can't create right obj in pk3v3WaitinRoom");
					return;
				}
				gameObject.transform.SetParent(this.mRight.transform, false);
				this.RightList[i] = gameObject;
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
			}
		}

		// Token: 0x060100C9 RID: 65737 RVA: 0x004748F4 File Offset: 0x00472CF4
		private void UpdatePlayerList()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [UpdatePlayerList]");
				return;
			}
			this.CheckSelfInfo();
			for (int i = 0; i < this.LeftList.Length; i++)
			{
				ComCommonBind component = this.LeftList[i].GetComponent<ComCommonBind>();
				if (component == null)
				{
					Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
					return;
				}
				this.UpdatePlayerBaseInfo(component, roomInfo, i, RoomSlotGroup.ROOM_SLOT_GROUP_RED);
			}
			if (roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4)
			{
				for (int j = 0; j < this.RightList.Length; j++)
				{
					ComCommonBind component2 = this.RightList[j].GetComponent<ComCommonBind>();
					if (component2 == null)
					{
						Logger.LogError("can't find ComCommonBind in PlayerInfoElePath");
						return;
					}
					this.UpdatePlayerBaseInfo(component2, roomInfo, j, RoomSlotGroup.ROOM_SLOT_GROUP_BLUE);
				}
			}
			this.mBtSetting.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			this.mBtBegin.gameObject.CustomActive(roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID || (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID && roomInfo.roomSimpleInfo.roomStatus == 3));
			this.mRoomName.text = roomInfo.roomSimpleInfo.name;
		}

		// Token: 0x060100CA RID: 65738 RVA: 0x00474A70 File Offset: 0x00472E70
		private void UpdatePlayerBaseInfo(ComCommonBind combind, RoomInfo roomInfo, int iIndex, RoomSlotGroup group)
		{
			Image com = combind.GetCom<Image>("Icon");
			Text com2 = combind.GetCom<Text>("Name");
			Text com3 = combind.GetCom<Text>("Lv");
			Image com4 = combind.GetCom<Image>("LvBack");
			Image com5 = combind.GetCom<Image>("RoomOwner");
			Image com6 = combind.GetCom<Image>("Lock");
			GameObject gameObject = combind.GetGameObject("What");
			UIGray com7 = combind.GetCom<UIGray>("IconGray");
			UIGray com8 = combind.GetCom<UIGray>("btIconGray");
			Button com9 = combind.GetCom<Button>("btIcon");
			Button com10 = combind.GetCom<Button>("ChangePos");
			Button com11 = combind.GetCom<Button>("ClosePos");
			ReplaceHeadPortraitFrame com12 = combind.GetCom<ReplaceHeadPortraitFrame>("ReplaceHeadPortraitFrame");
			bool flag = false;
			bool bActive = false;
			bool flag2 = false;
			bool enable = false;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)group)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIndex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == roomInfo.roomSimpleInfo.ownerId)
						{
							bActive = true;
						}
						if (roomInfo.roomSlotInfos[i].status == 2)
						{
							flag2 = true;
						}
						else if (roomInfo.roomSlotInfos[i].status == 4)
						{
							enable = true;
						}
						if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
						{
						}
						if (roomInfo.roomSlotInfos[i].playerId != 0UL)
						{
							flag = true;
							this.LoadSprite(ref com, (int)roomInfo.roomSlotInfos[i].playerOccu);
							com3.text = roomInfo.roomSlotInfos[i].playerLevel.ToString();
							com2.text = roomInfo.roomSlotInfos[i].playerName;
						}
						if (com12 != null)
						{
							if (roomInfo.roomSlotInfos[i].playerLabelInfo.headFrame != 0U)
							{
								com12.ReplacePhotoFrame((int)roomInfo.roomSlotInfos[i].playerLabelInfo.headFrame);
							}
							else
							{
								com12.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
							}
						}
						break;
					}
				}
			}
			com.gameObject.CustomActive(flag);
			com2.gameObject.CustomActive(flag);
			com4.gameObject.CustomActive(flag);
			com5.gameObject.CustomActive(bActive);
			com6.gameObject.CustomActive(flag2);
			com7.SetEnable(enable);
			com8.SetEnable(enable);
			gameObject.gameObject.CustomActive(group == RoomSlotGroup.ROOM_SLOT_GROUP_BLUE && roomInfo.roomSimpleInfo.roomType == 2);
			com10.gameObject.CustomActive(!flag && !flag2 && !this.bSelfIsRoomOwner);
			com11.gameObject.CustomActive(false);
			com9.onClick.RemoveAllListeners();
			int iIdex = iIndex;
			com10.onClick.RemoveAllListeners();
			int iIdx = iIndex;
			com11.onClick.RemoveAllListeners();
			int idx = iIndex;
			if (group == RoomSlotGroup.ROOM_SLOT_GROUP_RED)
			{
				com9.onClick.AddListener(delegate()
				{
					this.OnClickLeftIcon(iIdex);
				});
				com10.onClick.AddListener(delegate()
				{
					this.OnClickLeftChangePos(iIdx);
				});
				com11.onClick.AddListener(delegate()
				{
					this.OnClickLeftClosePos(idx);
				});
			}
			else if (group == RoomSlotGroup.ROOM_SLOT_GROUP_BLUE)
			{
				com9.onClick.AddListener(delegate()
				{
					this.OnClickRightIcon(iIdex);
				});
				com10.onClick.AddListener(delegate()
				{
					this.OnClickRightChangePos(iIdx);
				});
				com11.onClick.AddListener(delegate()
				{
					this.OnClickRightClosePos(idx);
				});
			}
		}

		// Token: 0x060100CB RID: 65739 RVA: 0x00474E44 File Offset: 0x00473244
		private void CheckSelfInfo()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			this.bSelfIsRoomOwner = (roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
				{
					this.SelfGroup = (RoomSlotGroup)roomInfo.roomSlotInfos[i].group;
					break;
				}
			}
		}

		// Token: 0x060100CC RID: 65740 RVA: 0x00474ED0 File Offset: 0x004732D0
		private void TryOpenPlayerMenuFrame(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			RoomSlotInfo roomSlotInfo = null;
			bool flag = false;
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
						{
							flag = true;
							break;
						}
						roomSlotInfo = roomInfo.roomSlotInfos[i];
						break;
					}
				}
			}
			if (roomSlotInfo == null)
			{
				return;
			}
			bool flag2 = false;
			if (roomSlotInfo.status == 2)
			{
				if (this.bSelfIsRoomOwner)
				{
					flag2 = true;
				}
			}
			else
			{
				flag2 = true;
			}
			if (!flag2)
			{
				return;
			}
			if (flag)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId && roomSlotInfo.playerId == 0UL)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3PlayerMenuFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<Pk3v3PlayerMenuFrame>(null, false);
			}
			else if (this.bSelfIsRoomOwner && roomSlotInfo.status == 2)
			{
				DataManager<Pk3v3DataManager>.GetInstance().SendClosePosReq(roomSlotInfo.group, roomSlotInfo.index);
			}
			else
			{
				Pk3v3PlayerMenuFrame pk3v3PlayerMenuFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3PlayerMenuFrame>(FrameLayer.Middle, roomSlotInfo, string.Empty) as Pk3v3PlayerMenuFrame;
				if (slotGroup == RoomSlotGroup.ROOM_SLOT_GROUP_RED)
				{
					pk3v3PlayerMenuFrame.SetPosition(this.LeftList[iIdex].GetComponent<RectTransform>().position);
				}
				else
				{
					pk3v3PlayerMenuFrame.SetPosition(this.RightList[iIdex].GetComponent<RectTransform>().position);
				}
			}
		}

		// Token: 0x060100CD RID: 65741 RVA: 0x00475074 File Offset: 0x00473474
		private void TryChangePos(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == 0UL)
						{
							if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
							{
							}
							DataManager<Pk3v3DataManager>.GetInstance().SendPk3v3ChangePosReq(roomInfo.roomSimpleInfo.id, roomInfo.roomSlotInfos[i]);
							break;
						}
					}
				}
			}
		}

		// Token: 0x060100CE RID: 65742 RVA: 0x00475134 File Offset: 0x00473534
		private void TryClosePos(int iIdex, RoomSlotGroup slotGroup)
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo.ownerId != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
			{
				if (roomInfo.roomSlotInfos[i].group == (byte)slotGroup)
				{
					if ((int)roomInfo.roomSlotInfos[i].index == iIdex)
					{
						if (roomInfo.roomSlotInfos[i].playerId == 0UL)
						{
							if (roomInfo.roomSlotInfos[i].group == (byte)this.SelfGroup)
							{
								DataManager<Pk3v3DataManager>.GetInstance().SendClosePosReq(roomInfo.roomSlotInfos[i].group, roomInfo.roomSlotInfos[i].index);
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x060100CF RID: 65743 RVA: 0x00475218 File Offset: 0x00473618
		private void LoadSprite(ref Image Icon, int Occu)
		{
			string text = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(Occu, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					text = tableItem2.IconPath;
				}
			}
			if (text != string.Empty)
			{
				ETCImageLoader.LoadSprite(ref Icon, text, true);
			}
		}

		// Token: 0x060100D0 RID: 65744 RVA: 0x00475288 File Offset: 0x00473688
		private void SwitchSceneToTown()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town from Pk3v3WaitingRoom");
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.RoomData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.RoomData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<Pk3v3WaitingRoom>(this, false);
		}

		// Token: 0x060100D1 RID: 65745 RVA: 0x0047530C File Offset: 0x0047370C
		private void SetRoomPassword()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				Logger.LogError("roomInfo is null in [InitPlayerList]");
				return;
			}
			if (roomInfo.roomSimpleInfo.isPassword > 0 && roomInfo.roomSimpleInfo.ownerId == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				this.SetActiveRoomPassword(true);
			}
			else
			{
				this.SetActiveRoomPassword(false);
			}
		}

		// Token: 0x060100D2 RID: 65746 RVA: 0x00475373 File Offset: 0x00473773
		private void SetActiveRoomPassword(bool isOpen)
		{
			if (isOpen)
			{
				this.mRoomPasswordGO.CustomActive(true);
				this.mRoomPasswordText.text = DataManager<Pk3v3DataManager>.GetInstance().PassWord;
			}
			else
			{
				this.mRoomPasswordGO.CustomActive(false);
			}
		}

		// Token: 0x060100D3 RID: 65747 RVA: 0x004753B0 File Offset: 0x004737B0
		[MessageHandle(607818U, false, 0)]
		private void OnQuitRoomRes(MsgDATA msg)
		{
			WorldQuitRoomRes worldQuitRoomRes = new WorldQuitRoomRes();
			worldQuitRoomRes.decode(msg.bytes);
			if (worldQuitRoomRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldQuitRoomRes.result, string.Empty);
			}
			DataManager<Pk3v3DataManager>.GetInstance().ClearRoomInfo();
			this.SwitchSceneToTown();
		}

		// Token: 0x060100D4 RID: 65748 RVA: 0x004753FC File Offset: 0x004737FC
		private void SendQuitRoomReq()
		{
			WorldQuitRoomReq cmd = new WorldQuitRoomReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldQuitRoomReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060100D5 RID: 65749 RVA: 0x00475420 File Offset: 0x00473820
		private void SendBeginGameReq()
		{
			WorldRoomBattleStartReq cmd = new WorldRoomBattleStartReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleStartReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060100D6 RID: 65750 RVA: 0x00475444 File Offset: 0x00473844
		private void SendCancelGameReq()
		{
			WorldRoomBattleCancelReq cmd = new WorldRoomBattleCancelReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRoomBattleCancelReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x060100D7 RID: 65751 RVA: 0x00475468 File Offset: 0x00473868
		private void ShowBeginText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4)
			{
				this.mBtMatchText.text = "开始决斗";
			}
			else
			{
				this.mBtMatchText.text = "开始匹配";
			}
		}

		// Token: 0x060100D8 RID: 65752 RVA: 0x004754BC File Offset: 0x004738BC
		private void ShowCancelText(RoomInfo roomInfo)
		{
			if (roomInfo.roomSimpleInfo.roomType == 1 || roomInfo.roomSimpleInfo.roomType == 4)
			{
				this.mBtMatchText.text = "取消决斗";
			}
			else
			{
				this.mBtMatchText.text = "取消匹配";
			}
		}

		// Token: 0x060100D9 RID: 65753 RVA: 0x00475510 File Offset: 0x00473910
		private void InitVoiceChat()
		{
			bool openTalkRealIn3v3Room = Singleton<PluginManager>.instance.OpenTalkRealIn3v3Room;
			if (this.mPvp3v3MicRoomBtn != null)
			{
				this.mPvp3v3MicRoomBtn.gameObject.CustomActive(openTalkRealIn3v3Room);
				this.ChangeMicBtnStatus(false);
			}
			if (this.mPvp3v3PlayerBtn != null)
			{
				this.mPvp3v3PlayerBtn.gameObject.CustomActive(openTalkRealIn3v3Room);
				this.ChangePlayerBtnStatus(false);
			}
			if (!openTalkRealIn3v3Room)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().AddRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
			string text = this.TryGetVoiceSDKChannalId();
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().JoinChannel(text, DataManager<PlayerBaseData>.GetInstance().RoleID + string.Empty, ClientApplication.playerinfo.openuid + string.Empty, ClientApplication.playerinfo.token + string.Empty);
		}

		// Token: 0x060100DA RID: 65754 RVA: 0x00475618 File Offset: 0x00473A18
		private void UnInitVoiceChat()
		{
			if (!Singleton<PluginManager>.instance.OpenTalkRealIn3v3Room)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
			Singleton<SDKVoiceManager>.GetInstance().RecoverGameVolumnInTalkVoice();
			Singleton<SDKVoiceManager>.GetInstance().LeaveAllChannel();
			Singleton<SDKVoiceManager>.GetInstance().RemoveRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x060100DB RID: 65755 RVA: 0x00475698 File Offset: 0x00473A98
		private string TryGetVoiceSDKChannalId()
		{
			string empty = string.Empty;
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null)
			{
				return empty;
			}
			uint id = ClientApplication.adminServer.id;
			int length = roomInfo.roomSimpleInfo.id.ToString().Length;
			if (length <= 0)
			{
				return empty;
			}
			return (id * Math.Pow(10.0, (double)length) + roomInfo.roomSimpleInfo.id).ToString();
		}

		// Token: 0x060100DC RID: 65756 RVA: 0x00475721 File Offset: 0x00473B21
		private void OnJoinChannelSucc()
		{
			Singleton<SDKVoiceManager>.GetInstance().ResetRealTalkVoiceParams();
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().OpenRealPlayer();
		}

		// Token: 0x060100DD RID: 65757 RVA: 0x00475741 File Offset: 0x00473B41
		private void OnVoiceSDKMicOn(bool isOn)
		{
			this.ChangeMicBtnStatus(isOn);
			if (isOn)
			{
				Singleton<SDKVoiceManager>.GetInstance().CutGameVolumnInTalkVoice();
			}
		}

		// Token: 0x060100DE RID: 65758 RVA: 0x0047575A File Offset: 0x00473B5A
		private void OnVoiceSDKPlayerOn(bool isOn)
		{
			this.ChangePlayerBtnStatus(isOn);
		}

		// Token: 0x060100DF RID: 65759 RVA: 0x00475764 File Offset: 0x00473B64
		private bool GetVoiceDeviceIsOn()
		{
			bool flag = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn();
			bool flag2 = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealPlayerOn();
			return flag || flag2;
		}

		// Token: 0x060100E0 RID: 65760 RVA: 0x00475794 File Offset: 0x00473B94
		private void ChangeMicBtnStatus(bool isMicOn)
		{
			if (this.mPvp3v3MicRoomBtnClose != null)
			{
				this.mPvp3v3MicRoomBtnClose.gameObject.CustomActive(!isMicOn);
			}
			if (this.mPvp3v3MicRoomBtnBg != null)
			{
				this.mPvp3v3MicRoomBtnBg.enabled = isMicOn;
			}
		}

		// Token: 0x060100E1 RID: 65761 RVA: 0x004757E4 File Offset: 0x00473BE4
		private void ChangePlayerBtnStatus(bool isPlayerOpen)
		{
			if (this.mPvp3v3PlayerBtnClose != null)
			{
				this.mPvp3v3PlayerBtnClose.gameObject.CustomActive(!isPlayerOpen);
			}
			if (this.mPvp3v3PlayerBtnBg != null)
			{
				this.mPvp3v3PlayerBtnBg.enabled = isPlayerOpen;
			}
		}

		// Token: 0x060100E2 RID: 65762 RVA: 0x00475834 File Offset: 0x00473C34
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtMenu = this.mBind.GetCom<Button>("btMenu");
			this.mBtMenu.onClick.AddListener(new UnityAction(this._onBtMenuButtonClick));
			this.mBtMenu.CustomActive(false);
			this.mBtInviteFriends = this.mBind.GetCom<Button>("btInviteFriends");
			this.mBtInviteFriends.onClick.AddListener(new UnityAction(this._onBtInviteFriendsButtonClick));
			this.mBtBegin = this.mBind.GetCom<Button>("btBegin");
			this.mBtBegin.onClick.AddListener(new UnityAction(this._onBtBeginButtonClick));
			this.mTalkRoot = this.mBind.GetGameObject("TalkRoot");
			this.mBtSetting = this.mBind.GetCom<Button>("btSetting");
			this.mBtSetting.onClick.AddListener(new UnityAction(this._onBtSettingButtonClick));
			this.mLeft = this.mBind.GetGameObject("left");
			this.mRight = this.mBind.GetGameObject("right");
			this.mRoomName = this.mBind.GetCom<Text>("RoomName");
			this.mRoomId = this.mBind.GetCom<Text>("RoomId");
			this.mMatchTypeImg = this.mBind.GetCom<Image>("MatchTypeImg");
			this.mAmuseTypeImg = this.mBind.GetCom<Image>("AmuseTypeImg");
			this.mBtMatchText = this.mBind.GetCom<Text>("btMatchText");
			this.mRankBg = this.mBind.GetGameObject("RankBg");
			this.mBtStartImage = this.mBind.GetCom<Image>("btStartImage");
			this.mAmuseBg = this.mBind.GetGameObject("AmuseBg");
			this.mRoomPasswordText = this.mBind.GetCom<Text>("RoomPasswordText");
			this.mRoomPasswordGO = this.mBind.GetGameObject("RoomPasswordGO");
			this.mPvp3v3PlayerBtn = this.mBind.GetCom<Button>("pvp3v3PlayerBtn");
			this.mPvp3v3PlayerBtn.onClick.AddListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtnBg = this.mBind.GetCom<Image>("pvp3v3PlayerBtnBg");
			this.mPvp3v3PlayerBtnClose = this.mBind.GetCom<Image>("pvp3v3PlayerBtnClose");
			this.mPvp3v3MicRoomBtn = this.mBind.GetCom<Button>("pvp3v3MicRoomBtn");
			this.mPvp3v3MicRoomBtn.onClick.AddListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtnBg = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnBg");
			this.mPvp3v3MicRoomBtnClose = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnClose");
		}

		// Token: 0x060100E3 RID: 65763 RVA: 0x00475B24 File Offset: 0x00473F24
		protected override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtMenu.onClick.RemoveListener(new UnityAction(this._onBtMenuButtonClick));
			this.mBtMenu = null;
			this.mBtInviteFriends.onClick.RemoveListener(new UnityAction(this._onBtInviteFriendsButtonClick));
			this.mBtInviteFriends = null;
			this.mBtBegin.onClick.RemoveListener(new UnityAction(this._onBtBeginButtonClick));
			this.mBtBegin = null;
			this.mTalkRoot = null;
			this.mBtSetting.onClick.RemoveListener(new UnityAction(this._onBtSettingButtonClick));
			this.mBtSetting = null;
			this.mLeft = null;
			this.mRight = null;
			this.mRoomName = null;
			this.mRoomId = null;
			this.mMatchTypeImg = null;
			this.mAmuseTypeImg = null;
			this.mBtMatchText = null;
			this.mRankBg = null;
			this.mBtStartImage = null;
			this.mAmuseBg = null;
			this.mRoomPasswordText = null;
			this.mRoomPasswordGO = null;
			this.mPvp3v3PlayerBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtn = null;
			this.mPvp3v3PlayerBtnBg = null;
			this.mPvp3v3PlayerBtnClose = null;
			this.mPvp3v3MicRoomBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtn = null;
			this.mPvp3v3MicRoomBtnBg = null;
			this.mPvp3v3MicRoomBtnClose = null;
		}

		// Token: 0x060100E4 RID: 65764 RVA: 0x00475C9D File Offset: 0x0047409D
		private void _onBtCloseButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			this.SendQuitRoomReq();
		}

		// Token: 0x060100E5 RID: 65765 RVA: 0x00475CB5 File Offset: 0x004740B5
		private void _onBtMenuButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060100E6 RID: 65766 RVA: 0x00475CD9 File Offset: 0x004740D9
		private void _onBtInviteFriendsButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamInvitePlayerListFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamInvitePlayerListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
		}

		// Token: 0x060100E7 RID: 65767 RVA: 0x00475D14 File Offset: 0x00474114
		private void _onBtBeginButtonClick()
		{
			RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
			if (roomInfo == null || roomInfo.roomSlotInfos == null)
			{
				return;
			}
			if (roomInfo.roomSimpleInfo.roomStatus == 1)
			{
				if (DataManager<PlayerBaseData>.GetInstance().RoleID != roomInfo.roomSimpleInfo.ownerId)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你不是房主,无法开始游戏", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
				{
					if (roomInfo.roomSlotInfos[i].playerId > 0UL && roomInfo.roomSlotInfos[i].status == 4)
					{
						SystemNotifyManager.SystemNotify(9216, string.Empty);
						return;
					}
				}
				if (roomInfo.roomSimpleInfo.roomType == 4)
				{
					int num = 0;
					int num2 = 0;
					for (int j = 0; j < roomInfo.roomSlotInfos.Length; j++)
					{
						if (roomInfo.roomSlotInfos[j].group == 2 && roomInfo.roomSlotInfos[j].playerId > 0UL)
						{
							num++;
						}
						if (roomInfo.roomSlotInfos[j].group == 1 && roomInfo.roomSlotInfos[j].playerId > 0UL)
						{
							num2++;
						}
					}
					if (num < 2 || num2 < 2)
					{
						SystemNotifyManager.SystemNotify(9934, string.Empty);
						return;
					}
				}
			}
			if (this.bMatchLock)
			{
				return;
			}
			this.bMatchLock = true;
			if (roomInfo.roomSimpleInfo.roomStatus == 1)
			{
				this.SendBeginGameReq();
			}
			else if (roomInfo.roomSimpleInfo.roomStatus == 3)
			{
				this.SendCancelGameReq();
			}
			else
			{
				Logger.LogErrorFormat("Pk3v3 begin state is error, roomstate = {0}", new object[]
				{
					roomInfo.roomSimpleInfo.roomStatus
				});
			}
		}

		// Token: 0x060100E8 RID: 65768 RVA: 0x00475EDE File Offset: 0x004742DE
		private void _onBtSettingButtonClick()
		{
			if (DataManager<Pk3v3DataManager>.GetInstance().CheckRoomIsMatching())
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3RoomSettingFrame>(null))
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3RoomSettingFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060100E9 RID: 65769 RVA: 0x00475F13 File Offset: 0x00474313
		private void _onPvp3v3PlayerBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVociePlayer();
		}

		// Token: 0x060100EA RID: 65770 RVA: 0x00475F3F File Offset: 0x0047433F
		private void _onPvp3v3MicRoomBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVoiceMic();
		}

		// Token: 0x0400A1FC RID: 41468
		private string PlayerInfoElePath = "UIFlatten/Prefabs/Pk3v3/Pk3v3PlayerInfo";

		// Token: 0x0400A1FD RID: 41469
		private string StartBtnRedPath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_06";

		// Token: 0x0400A1FE RID: 41470
		private string StartBtnBluePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Lanse_01";

		// Token: 0x0400A1FF RID: 41471
		private const int MaxPlayerNum = 3;

		// Token: 0x0400A200 RID: 41472
		private const int MaxMeleePlayerNum = 2;

		// Token: 0x0400A201 RID: 41473
		private PkWaitingRoomData RoomData = new PkWaitingRoomData();

		// Token: 0x0400A202 RID: 41474
		private RoomSlotGroup SelfGroup;

		// Token: 0x0400A203 RID: 41475
		private bool bSelfIsRoomOwner;

		// Token: 0x0400A204 RID: 41476
		private bool bMatchLock;

		// Token: 0x0400A205 RID: 41477
		private GameObject[] LeftList = new GameObject[3];

		// Token: 0x0400A206 RID: 41478
		private GameObject[] RightList = new GameObject[3];

		// Token: 0x0400A207 RID: 41479
		private ComTalk m_miniTalk;

		// Token: 0x0400A208 RID: 41480
		private Button mBtClose;

		// Token: 0x0400A209 RID: 41481
		private Button mBtMenu;

		// Token: 0x0400A20A RID: 41482
		private Button mBtInviteFriends;

		// Token: 0x0400A20B RID: 41483
		private Button mBtBegin;

		// Token: 0x0400A20C RID: 41484
		private GameObject mTalkRoot;

		// Token: 0x0400A20D RID: 41485
		private Button mBtSetting;

		// Token: 0x0400A20E RID: 41486
		private GameObject mLeft;

		// Token: 0x0400A20F RID: 41487
		private GameObject mRight;

		// Token: 0x0400A210 RID: 41488
		private Text mRoomName;

		// Token: 0x0400A211 RID: 41489
		private Text mRoomId;

		// Token: 0x0400A212 RID: 41490
		private Image mMatchTypeImg;

		// Token: 0x0400A213 RID: 41491
		private Image mAmuseTypeImg;

		// Token: 0x0400A214 RID: 41492
		private Text mBtMatchText;

		// Token: 0x0400A215 RID: 41493
		private GameObject mRankBg;

		// Token: 0x0400A216 RID: 41494
		private Image mBtStartImage;

		// Token: 0x0400A217 RID: 41495
		private GameObject mAmuseBg;

		// Token: 0x0400A218 RID: 41496
		private Text mRoomPasswordText;

		// Token: 0x0400A219 RID: 41497
		private GameObject mRoomPasswordGO;

		// Token: 0x0400A21A RID: 41498
		private Button mPvp3v3PlayerBtn;

		// Token: 0x0400A21B RID: 41499
		private Image mPvp3v3PlayerBtnBg;

		// Token: 0x0400A21C RID: 41500
		private Image mPvp3v3PlayerBtnClose;

		// Token: 0x0400A21D RID: 41501
		private Button mPvp3v3MicRoomBtn;

		// Token: 0x0400A21E RID: 41502
		private Image mPvp3v3MicRoomBtnBg;

		// Token: 0x0400A21F RID: 41503
		private Image mPvp3v3MicRoomBtnClose;
	}
}
