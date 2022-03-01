using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020019ED RID: 6637
	internal class RelationFrame : WndFrame
	{
		// Token: 0x17001D42 RID: 7490
		// (set) Token: 0x06010450 RID: 66640 RVA: 0x0048F197 File Offset: 0x0048D597
		public bool GiveFriend
		{
			set
			{
				this.m_bGiveFriend = value;
			}
		}

		// Token: 0x06010451 RID: 66641 RVA: 0x0048F1A0 File Offset: 0x0048D5A0
		public override string GetContentPath()
		{
			return "UIFlatten/Prefabs/Friends/RelationFrame.prefab";
		}

		// Token: 0x06010452 RID: 66642 RVA: 0x0048F1A7 File Offset: 0x0048D5A7
		public override string GetTitle()
		{
			return "好友";
		}

		// Token: 0x06010453 RID: 66643 RVA: 0x0048F1AE File Offset: 0x0048D5AE
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this.Init();
		}

		// Token: 0x06010454 RID: 66644 RVA: 0x0048F1BC File Offset: 0x0048D5BC
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
			this._ClearFriendList();
		}

		// Token: 0x06010455 RID: 66645 RVA: 0x0048F1CA File Offset: 0x0048D5CA
		private HelpFrame.HelpType _GetHelpType()
		{
			return HelpFrame.HelpType.HT_RELATION;
		}

		// Token: 0x06010456 RID: 66646 RVA: 0x0048F1CE File Offset: 0x0048D5CE
		private HelpFrame.HelpType _GetTapHelpType()
		{
			return HelpFrame.HelpType.HT_RELATION;
		}

		// Token: 0x06010457 RID: 66647 RVA: 0x0048F1D4 File Offset: 0x0048D5D4
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecievRecommendFriend));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this._OnRefreshFriendList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRefreshInviteList, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryEnd, new ClientEventSystem.UIEventHandler(this._OnQueryEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnPrivateChat));
		}

		// Token: 0x06010458 RID: 66648 RVA: 0x0048F2A0 File Offset: 0x0048D6A0
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecievRecommendFriend, new ClientEventSystem.UIEventHandler(this._OnRecievRecommendFriend));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshFriendList, new ClientEventSystem.UIEventHandler(this._OnRefreshFriendList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRefreshInviteList, new ClientEventSystem.UIEventHandler(this._OnRefreshInviteList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryEnd, new ClientEventSystem.UIEventHandler(this._OnQueryEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnPrivateChat));
		}

		// Token: 0x06010459 RID: 66649 RVA: 0x0048F36C File Offset: 0x0048D76C
		[UIEventHandle("Content/RelationFrame(Clone)/BottomBG/FriendListBtn")]
		protected void _OnQuerryFriend()
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = 1;
			worldRelationFindPlayersReq.name = string.Empty;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x0601045A RID: 66650 RVA: 0x0048F3A0 File Offset: 0x0048D7A0
		[UIEventHandle("Content/RelationFrame(Clone)/UpBG/ToggleGroup/Toggle{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		protected void _OnTabChanged(int index, bool isChecked)
		{
			if (isChecked)
			{
				if (index == 0)
				{
					this._ChangeFriendTab();
				}
				else if (index == 1)
				{
					this._ChangeInviteTab();
				}
				else if (index == 2)
				{
					this._ChangeBlackTab();
				}
			}
		}

		// Token: 0x0601045B RID: 66651 RVA: 0x0048F3D8 File Offset: 0x0048D7D8
		public void ChangeTabChange(int index)
		{
			this.m_Tab[index].isOn = true;
			if (index == 0)
			{
				this._ChangeFriendTab();
			}
			else if (index == 1)
			{
				this._ChangeInviteTab();
			}
			else if (index == 2)
			{
				this._ChangeBlackTab();
			}
		}

		// Token: 0x0601045C RID: 66652 RVA: 0x0048F418 File Offset: 0x0048D818
		[UIEventHandle("Content/RelationFrame(Clone)/BottomBG/AllAcceptBtn")]
		protected void _OnAllAcceptBtn()
		{
			List<InviteFriendData> inviteFriendData = DataManager<RelationDataManager>.GetInstance().GetInviteFriendData();
			for (int i = 0; i < inviteFriendData.Count; i++)
			{
				SceneReply sceneReply = new SceneReply();
				sceneReply.type = 3;
				sceneReply.requester = inviteFriendData[i].requester;
				sceneReply.result = 1;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
			}
			DataManager<RelationDataManager>.GetInstance().DelAllInviter();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshInviteList, null, null, null, null);
		}

		// Token: 0x0601045D RID: 66653 RVA: 0x0048F49C File Offset: 0x0048D89C
		[UIEventHandle("Content/RelationFrame(Clone)/BottomBG/AllRefuseBtn")]
		protected void _OnAllRefuseBtn()
		{
			List<InviteFriendData> inviteFriendData = DataManager<RelationDataManager>.GetInstance().GetInviteFriendData();
			for (int i = 0; i < inviteFriendData.Count; i++)
			{
				SceneReply sceneReply = new SceneReply();
				sceneReply.type = 3;
				sceneReply.requester = inviteFriendData[i].requester;
				sceneReply.result = 0;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<SceneReply>(ServerType.GATE_SERVER, sceneReply);
			}
			DataManager<RelationDataManager>.GetInstance().DelAllInviter();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshInviteList, null, null, null, null);
		}

		// Token: 0x0601045E RID: 66654 RVA: 0x0048F520 File Offset: 0x0048D920
		[UIEventHandle("Content/RelationFrame(Clone)/UpBG/QueryBtn")]
		protected void _OnQueryFriend()
		{
			if (this.m_queryName.text == string.Empty)
			{
				return;
			}
			this.m_bQuerying = true;
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.roleId = 0UL;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_FRIEND;
			worldQueryPlayerReq.name = this.m_queryName.text;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x0601045F RID: 66655 RVA: 0x0048F588 File Offset: 0x0048D988
		protected void _ChangeFriendTab()
		{
			this.m_curState = FriendListType.FLT_FRIEND;
			this.AddFriendToList();
			this.mAllAccept.gameObject.SetActive(false);
			this.mAllRefuse.gameObject.SetActive(false);
			this.m_addFriend.gameObject.SetActive(true);
			this.m_frendNum.gameObject.SetActive(true);
		}

		// Token: 0x06010460 RID: 66656 RVA: 0x0048F5E8 File Offset: 0x0048D9E8
		protected void _ChangeInviteTab()
		{
			this.m_curState = FriendListType.FLT_NOTIFY;
			this.AddInviteFriend();
			this.mAllAccept.gameObject.SetActive(true);
			this.mAllRefuse.gameObject.SetActive(true);
			this.mEmptyTip.gameObject.SetActive(false);
			this.m_addFriend.gameObject.SetActive(true);
			this.m_frendNum.gameObject.SetActive(true);
		}

		// Token: 0x06010461 RID: 66657 RVA: 0x0048F658 File Offset: 0x0048DA58
		protected void _ChangeBlackTab()
		{
			this.m_curState = FriendListType.FLT_BLACK;
			this.mAllAccept.gameObject.SetActive(false);
			this.mAllRefuse.gameObject.SetActive(false);
			this.mEmptyTip.gameObject.SetActive(false);
			this.m_addFriend.gameObject.SetActive(false);
			this.m_frendNum.gameObject.SetActive(false);
			this._AddBlackList();
		}

		// Token: 0x06010462 RID: 66658 RVA: 0x0048F6C7 File Offset: 0x0048DAC7
		[UIEventHandle("Title/Close")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<RelationFrame>(this, false);
		}

		// Token: 0x06010463 RID: 66659 RVA: 0x0048F6D6 File Offset: 0x0048DAD6
		[UIEventHandle("Title/Help")]
		private void OnClickHelp()
		{
			this.frameMgr.OpenFrame<HelpFrame>(FrameLayer.Middle, this._GetHelpType(), string.Empty);
		}

		// Token: 0x06010464 RID: 66660 RVA: 0x0048F6F5 File Offset: 0x0048DAF5
		[UIEventHandle("Title/TapHelp")]
		private void OnClickTapHelp()
		{
			this.frameMgr.OpenFrame<HelpFrame>(FrameLayer.Middle, this._GetTapHelpType(), string.Empty);
		}

		// Token: 0x06010465 RID: 66661 RVA: 0x0048F714 File Offset: 0x0048DB14
		public bool IsQuerying()
		{
			return this.m_bQuerying;
		}

		// Token: 0x06010466 RID: 66662 RVA: 0x0048F71C File Offset: 0x0048DB1C
		public void _OnQueryEnd(UIEvent uiEvent)
		{
			this.m_bQuerying = false;
		}

		// Token: 0x06010467 RID: 66663 RVA: 0x0048F728 File Offset: 0x0048DB28
		protected void _OnPrivateChat(UIEvent uiEvent)
		{
			UIEventPrivateChat uieventPrivateChat = uiEvent as UIEventPrivateChat;
			for (int i = 0; i < this.m_friendInfoList.Count; i++)
			{
				if (this.m_friendInfoList[i].m_uid == uieventPrivateChat.m_data.uid)
				{
					this.m_friendInfoList[i].ShowRedPoint();
					return;
				}
			}
		}

		// Token: 0x06010468 RID: 66664 RVA: 0x0048F78C File Offset: 0x0048DB8C
		protected void AddFriendToList()
		{
			this._ClearFriendList();
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
			this.m_addList = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AddRelationDataToList(relation, FriendListType.FLT_FRIEND));
			this.mEmptyTip.gameObject.SetActive(relation.Count <= 0);
			this.mFriendNum.text = string.Format("{0}", relation.Count);
		}

		// Token: 0x06010469 RID: 66665 RVA: 0x0048F808 File Offset: 0x0048DC08
		protected void AddInviteFriend()
		{
			this._ClearFriendList();
			List<InviteFriendData> inviteFriendData = DataManager<RelationDataManager>.GetInstance().GetInviteFriendData();
			if (inviteFriendData.Count > 0)
			{
				this.m_redPt.gameObject.SetActive(true);
				this.m_addList = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AddInviteDataToList(inviteFriendData, FriendListType.FLT_NOTIFY));
			}
			else
			{
				this.m_redPt.gameObject.SetActive(false);
			}
		}

		// Token: 0x0601046A RID: 66666 RVA: 0x0048F874 File Offset: 0x0048DC74
		protected new void Init()
		{
			this.m_bGiveFriend = false;
			this._InitRedPoint();
			this.m_Tab[0].isOn = true;
			for (int i = 1; i < 3; i++)
			{
				this.m_Tab[i].isOn = false;
			}
		}

		// Token: 0x0601046B RID: 66667 RVA: 0x0048F8BC File Offset: 0x0048DCBC
		protected void ShowFriendInfo(GameObject friend, RelationData data)
		{
			Text componetInChild = Utility.GetComponetInChild<Text>(friend, "Left/Name");
			componetInChild.text = string.Format("Lv:     {0}", data.name);
			Text componetInChild2 = Utility.GetComponetInChild<Text>(friend, "Left/Name/Lv");
			componetInChild2.text = string.Format("{0}", data.level);
			GameObject gameObject = Utility.FindGameObject(friend, "Left/HeadBoard/OccuHead_1", true);
			GameObject gameObject2 = Utility.FindGameObject(friend, "Left/HeadBoard/OccuHead_2", true);
			GameObject gameObject3 = Utility.FindGameObject(friend, "Left/HeadBoard/OccuHead_3", true);
			gameObject.SetActive(false);
			gameObject2.SetActive(false);
			gameObject3.SetActive(false);
			if (data.occu / 10 == 1)
			{
				gameObject.SetActive(true);
			}
			else if (data.occu / 10 == 2)
			{
				gameObject2.SetActive(true);
			}
			else if (data.occu / 10 == 3)
			{
				gameObject3.SetActive(true);
			}
			GameObject gameObject4 = Utility.FindGameObject(friend, "Left/Occu_1", true);
			GameObject gameObject5 = Utility.FindGameObject(friend, "Left/Occu_2", true);
			GameObject gameObject6 = Utility.FindGameObject(friend, "Left/Occu_3", true);
			gameObject4.SetActive(false);
			gameObject5.SetActive(false);
			gameObject6.SetActive(false);
			if (data.occu / 10 == 1)
			{
				gameObject4.SetActive(true);
			}
			else if (data.occu / 10 == 2)
			{
				gameObject5.SetActive(true);
			}
			else if (data.occu / 10 == 3)
			{
				gameObject6.SetActive(true);
			}
			GameObject gameObject7 = Utility.FindGameObject(friend, "Right/Talk", true);
			GameObject gameObject8 = Utility.FindGameObject(friend, "Right/Give", true);
			GameObject gameObject9 = Utility.FindGameObject(friend, "Right/Accept", true);
			GameObject gameObject10 = Utility.FindGameObject(friend, "Right/Refuse", true);
			GameObject gameObject11 = Utility.FindGameObject(friend, "Right/AlreadyGive", true);
			gameObject7.SetActive(true);
			gameObject8.SetActive(true);
			gameObject9.SetActive(false);
			gameObject10.SetActive(false);
			gameObject11.SetActive(false);
		}

		// Token: 0x0601046C RID: 66668 RVA: 0x0048FA9C File Offset: 0x0048DE9C
		protected void _OnRecievRecommendFriend(UIEvent uiEvent)
		{
			UIEventRecievRecommendFriend uieventRecievRecommendFriend = uiEvent as UIEventRecievRecommendFriend;
			this._AddRecommendFriend(uieventRecievRecommendFriend.m_friendList);
		}

		// Token: 0x0601046D RID: 66669 RVA: 0x0048FABC File Offset: 0x0048DEBC
		protected void _OnRefreshFriendList(UIEvent uiEvent)
		{
			if (this.m_bGiveFriend)
			{
				return;
			}
			this._OnCloseMenu(new UIEvent());
			if (this.m_curState == FriendListType.FLT_FRIEND)
			{
				this.AddFriendToList();
			}
			else if (this.m_curState == FriendListType.FLT_BLACK)
			{
				this._AddBlackList();
			}
		}

		// Token: 0x0601046E RID: 66670 RVA: 0x0048FB09 File Offset: 0x0048DF09
		protected void _OnRefreshInviteList(UIEvent uiEvent)
		{
			this._InitRedPoint();
			if (this.m_curState == FriendListType.FLT_NOTIFY)
			{
				this.AddInviteFriend();
				this._OnCloseMenu(new UIEvent());
			}
		}

		// Token: 0x0601046F RID: 66671 RVA: 0x0048FB2E File Offset: 0x0048DF2E
		protected void _OnNotifyInvite(UIEvent uiEvent)
		{
			this._InitRedPoint();
		}

		// Token: 0x06010470 RID: 66672 RVA: 0x0048FB38 File Offset: 0x0048DF38
		protected void _InitRedPoint()
		{
			List<InviteFriendData> inviteFriendData = DataManager<RelationDataManager>.GetInstance().GetInviteFriendData();
			if (inviteFriendData.Count > 0)
			{
				this.m_redPt.gameObject.SetActive(true);
			}
			else
			{
				this.m_redPt.gameObject.SetActive(false);
			}
		}

		// Token: 0x06010471 RID: 66673 RVA: 0x0048FB84 File Offset: 0x0048DF84
		protected void _OnShowFrienSecInfo(UIEvent uiEvent)
		{
			UIEventShowFriendSecMenu uieventShowFriendSecMenu = uiEvent as UIEventShowFriendSecMenu;
			this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, uieventShowFriendSecMenu.m_data, string.Empty);
		}

		// Token: 0x06010472 RID: 66674 RVA: 0x0048FBB5 File Offset: 0x0048DFB5
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x06010473 RID: 66675 RVA: 0x0048FBDC File Offset: 0x0048DFDC
		protected void _AddRecommendFriend(RelationData[] list)
		{
			if (this.frameMgr.IsFrameOpen<RelationPopupFram>(null))
			{
				return;
			}
			RelationPopupFram relationPopupFram = (RelationPopupFram)this.frameMgr.OpenFrame<RelationPopupFram>(this.frame, list, string.Empty);
			relationPopupFram.SetData(list);
		}

		// Token: 0x06010474 RID: 66676 RVA: 0x0048FC1F File Offset: 0x0048E01F
		protected void _ClearNotifyList()
		{
			this._ClearRecommendFriend();
			this._ClearInviteList();
		}

		// Token: 0x06010475 RID: 66677 RVA: 0x0048FC30 File Offset: 0x0048E030
		protected void _ClearRecommendFriend()
		{
			for (int i = 0; i < this.m_recommendList.Count; i++)
			{
				this.m_recommendList[i].Finatial();
			}
			this.m_recommendList.Clear();
		}

		// Token: 0x06010476 RID: 66678 RVA: 0x0048FC78 File Offset: 0x0048E078
		protected void _ClearFriendList()
		{
			if (this.m_addList != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.m_addList);
			}
			for (int i = 0; i < this.m_friendInfoList.Count; i++)
			{
				this.m_friendInfoList[i].Finatial();
			}
			this.m_friendInfoList.Clear();
		}

		// Token: 0x06010477 RID: 66679 RVA: 0x0048FCDC File Offset: 0x0048E0DC
		protected void _AddBlackList()
		{
			this._ClearFriendList();
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(2);
			this.m_addList = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._AddRelationDataToList(relation, FriendListType.FLT_BLACK));
		}

		// Token: 0x06010478 RID: 66680 RVA: 0x0048FD14 File Offset: 0x0048E114
		public IEnumerator _AddRelationDataToList(List<RelationData> relationList, FriendListType type)
		{
			for (int i = 0; i < relationList.Count; i++)
			{
				FriendInfo friend = new FriendInfo(relationList[i].uid, relationList[i].name, relationList[i].level, relationList[i].occu, relationList[i].dayGiftNum, type, relationList[i].isOnline, relationList[i].vipLv, relationList[i].seasonLv);
				friend.SetRelationData(relationList[i]);
				this.m_friendInfoList.Add(friend);
				friend.SetCustomParent(this.mListContent);
				yield return null;
			}
			yield break;
		}

		// Token: 0x06010479 RID: 66681 RVA: 0x0048FD40 File Offset: 0x0048E140
		public IEnumerator _AddInviteDataToList(List<InviteFriendData> inviteFriends, FriendListType type)
		{
			for (int i = 0; i < inviteFriends.Count; i++)
			{
				FriendInfo friend = new FriendInfo(inviteFriends[i].requester, inviteFriends[i].requesterName, inviteFriends[i].requesterLevel, inviteFriends[i].requesterOccu, 0, type, 1, inviteFriends[i].vipLv, 0U);
				this.m_friendInfoList.Add(friend);
				friend.SetCustomParent(this.mListContent);
				yield return null;
			}
			yield break;
		}

		// Token: 0x0601047A RID: 66682 RVA: 0x0048FD6C File Offset: 0x0048E16C
		protected void _ClearInviteList()
		{
			for (int i = 0; i < this.m_inviteInfoList.Count; i++)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_inviteInfoList[i].m_friendPrefab);
				this.m_inviteInfoList[i] = null;
			}
			this.m_inviteInfoList.Clear();
		}

		// Token: 0x0601047B RID: 66683 RVA: 0x0048FDC8 File Offset: 0x0048E1C8
		protected void _SendUpdateRelation()
		{
			WorldUpdateRelation cmd = new WorldUpdateRelation();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldUpdateRelation>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0400A4D2 RID: 42194
		private const int m_TabNum = 3;

		// Token: 0x0400A4D3 RID: 42195
		private const string WndRoot = "Content/RelationFrame(Clone)/";

		// Token: 0x0400A4D4 RID: 42196
		[UIControl("Content/RelationFrame(Clone)/Tip", typeof(RectTransform), 0)]
		protected RectTransform mEmptyTip;

		// Token: 0x0400A4D5 RID: 42197
		[UIControl("Content/RelationFrame(Clone)/BottomBG/AllAcceptBtn", typeof(RectTransform), 0)]
		protected RectTransform mAllAccept;

		// Token: 0x0400A4D6 RID: 42198
		[UIControl("Content/RelationFrame(Clone)/BottomBG/AllRefuseBtn", typeof(RectTransform), 0)]
		protected RectTransform mAllRefuse;

		// Token: 0x0400A4D7 RID: 42199
		[UIControl("Content/RelationFrame(Clone)/FriendListView/Viewport/Content", typeof(RectTransform), 0)]
		protected RectTransform mListContent;

		// Token: 0x0400A4D8 RID: 42200
		[UIControl("Content/RelationFrame(Clone)/BottomBG/ImgFriendNum/TextNum", typeof(Text), 0)]
		protected Text mFriendNum;

		// Token: 0x0400A4D9 RID: 42201
		[UIControl("Content/RelationFrame(Clone)/UpBG/ToggleGroup", typeof(ToggleGroup), 0)]
		protected ToggleGroup mTabGroup;

		// Token: 0x0400A4DA RID: 42202
		[UIControl("Content/RelationFrame(Clone)/UpBG/ToggleGroup/Toggle{0}", typeof(Toggle), 1)]
		protected Toggle[] m_Tab = new Toggle[3];

		// Token: 0x0400A4DB RID: 42203
		[UIControl("Content/RelationFrame(Clone)/UpBG/ToggleGroup/Toggle2/RedPt", typeof(Image), 0)]
		protected Image m_redPt;

		// Token: 0x0400A4DC RID: 42204
		[UIControl("Content/RelationFrame(Clone)/UpBG/Input/Text", typeof(Text), 0)]
		protected Text m_queryName;

		// Token: 0x0400A4DD RID: 42205
		[UIControl("Content/RelationFrame(Clone)/BottomBG/FriendListBtn", typeof(RectTransform), 0)]
		protected RectTransform m_addFriend;

		// Token: 0x0400A4DE RID: 42206
		[UIControl("Content/RelationFrame(Clone)/BottomBG/ImgFriendNum", typeof(RectTransform), 0)]
		protected RectTransform m_frendNum;

		// Token: 0x0400A4DF RID: 42207
		protected List<FriendInfo> m_friendInfoList = new List<FriendInfo>();

		// Token: 0x0400A4E0 RID: 42208
		protected List<FriendInfo> m_recommendList = new List<FriendInfo>();

		// Token: 0x0400A4E1 RID: 42209
		protected List<FriendInfo> m_inviteInfoList = new List<FriendInfo>();

		// Token: 0x0400A4E2 RID: 42210
		private FriendListType m_curState;

		// Token: 0x0400A4E3 RID: 42211
		private IClientFrame m_openMenu;

		// Token: 0x0400A4E4 RID: 42212
		private bool m_bQuerying;

		// Token: 0x0400A4E5 RID: 42213
		private bool m_bGiveFriend;

		// Token: 0x0400A4E6 RID: 42214
		private Coroutine m_addList;
	}
}
