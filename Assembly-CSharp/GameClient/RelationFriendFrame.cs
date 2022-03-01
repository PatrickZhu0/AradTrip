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
	// Token: 0x02001A04 RID: 6660
	internal class RelationFriendFrame : ClientFrame
	{
		// Token: 0x0601057D RID: 66941 RVA: 0x004961A0 File Offset: 0x004945A0
		protected sealed override void _bindExUI()
		{
			this.mEmotionTab = this.mBind.GetGameObject("EmotionTab");
			this.mEmotion = this.mBind.GetCom<Button>("Emotion");
			if (null != this.mEmotion)
			{
				this.mEmotion.onClick.AddListener(new UnityAction(this._onEmotionButtonClick));
			}
			this.mSend = this.mBind.GetCom<Button>("Send");
			if (null != this.mSend)
			{
				this.mSend.onClick.AddListener(new UnityAction(this._onSendButtonClick));
			}
			this.mInput = this.mBind.GetCom<OnFocusInputField>("Input");
			this.mComUIList = this.mBind.GetCom<ComUIListScript>("ComUIList");
			this.mBtnDelete = this.mBind.GetCom<Button>("BtnDelete");
			if (null != this.mBtnDelete)
			{
				this.mBtnDelete.onClick.AddListener(new UnityAction(this._onBtnDeleteButtonClick));
			}
			this.mBtnAdd = this.mBind.GetCom<Button>("BtnAdd");
			if (null != this.mBtnAdd)
			{
				this.mBtnAdd.onClick.AddListener(new UnityAction(this._onBtnAddButtonClick));
			}
			this.mDegreeFriend = this.mBind.GetCom<Text>("DegreeFriend");
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mDegreeFriendsGO = this.mBind.GetGameObject("DegreeFriendsGO");
			this.mBtnAddGo = this.mBind.GetGameObject("BtnAddGo");
			this.mChatFrameNewRoot = this.mBind.GetGameObject("ChatFrameNew");
			this.mStrangersGeUISwitchBtn = this.mBind.GetCom<GeUISwitchButton>("Strangers");
			if (null != this.mStrangersGeUISwitchBtn)
			{
				this.mStrangersGeUISwitchBtn.onValueChanged.AddListener(new UnityAction<bool>(this._onStrangersToggleValueChange));
			}
			this.mToggleGroup = this.mBind.GetCom<ToggleGroup>("toggleGroup");
			this.mChatScrollViewRect = this.mBind.GetCom<RectTransform>("ChatScrollViewRect");
			this.mStrangerGO = this.mBind.GetGameObject("Stranger");
			this.mHintRoot = this.mBind.GetGameObject("HintRoot");
			this.mBlackRoot = this.mBind.GetGameObject("BlackRoot");
			this.mLevel = this.mBind.GetCom<Text>("Level");
			this.mBlackBtnAdd = this.mBind.GetCom<Button>("BlackBtnAdd");
			if (this.mBlackBtnAdd != null)
			{
				this.mBlackBtnAdd.onClick.AddListener(new UnityAction(this._onBlackButtonClick));
			}
			this.mBalckBtnRemove = this.mBind.GetCom<Button>("Remove");
			if (this.mBalckBtnRemove != null)
			{
				this.mBalckBtnRemove.onClick.AddListener(new UnityAction(this._onRemoveButtonClick));
			}
			this.mBlackJianbianRoot = this.mBind.GetGameObject("JianbianRoot");
			this.mRelation = this.mBind.GetCom<Text>("Relation");
			this.mDegreeFriendBtn = this.mBind.GetCom<Button>("DegreeFriendBtn");
			if (this.mDegreeFriendBtn != null)
			{
				this.mDegreeFriendBtn.onClick.AddListener(new UnityAction(this._onDegreeFriendClick));
			}
			this.mScrollRect = this.mBind.GetCom<ScrollRect>("ScrollView");
		}

		// Token: 0x0601057E RID: 66942 RVA: 0x0049653C File Offset: 0x0049493C
		protected sealed override void _unbindExUI()
		{
			this.mEmotionTab = null;
			if (null != this.mEmotion)
			{
				this.mEmotion.onClick.RemoveListener(new UnityAction(this._onEmotionButtonClick));
			}
			this.mEmotion = null;
			if (null != this.mSend)
			{
				this.mSend.onClick.RemoveListener(new UnityAction(this._onSendButtonClick));
			}
			this.mSend = null;
			this.mInput = null;
			this.mComUIList = null;
			if (null != this.mBtnDelete)
			{
				this.mBtnDelete.onClick.RemoveListener(new UnityAction(this._onBtnDeleteButtonClick));
			}
			this.mBtnDelete = null;
			if (null != this.mBtnAdd)
			{
				this.mBtnAdd.onClick.RemoveListener(new UnityAction(this._onBtnAddButtonClick));
			}
			this.mBtnAdd = null;
			this.mDegreeFriend = null;
			this.mName = null;
			this.mDegreeFriendsGO = null;
			this.mBtnAddGo = null;
			this.mChatFrameNewRoot = null;
			if (null != this.mStrangersGeUISwitchBtn)
			{
				this.mStrangersGeUISwitchBtn.onValueChanged.RemoveListener(new UnityAction<bool>(this._onStrangersToggleValueChange));
			}
			this.mStrangersGeUISwitchBtn = null;
			this.mToggleGroup = null;
			this.mChatScrollViewRect = null;
			this.mStrangerGO = null;
			this.mHintRoot = null;
			this.mBlackRoot = null;
			this.mLevel = null;
			if (this.mBlackBtnAdd != null)
			{
				this.mBlackBtnAdd.onClick.RemoveListener(new UnityAction(this._onBlackButtonClick));
			}
			this.mBlackBtnAdd = null;
			if (this.mBalckBtnRemove != null)
			{
				this.mBalckBtnRemove.onClick.RemoveListener(new UnityAction(this._onRemoveButtonClick));
			}
			this.mBalckBtnRemove = null;
			this.mBlackJianbianRoot = null;
			this.mRelation = null;
			if (this.mDegreeFriendBtn != null)
			{
				this.mDegreeFriendBtn.onClick.RemoveListener(new UnityAction(this._onDegreeFriendClick));
			}
			this.mDegreeFriendBtn = null;
			this.mScrollRect = null;
		}

		// Token: 0x0601057F RID: 66943 RVA: 0x00496760 File Offset: 0x00494B60
		private void _onEmotionButtonClick()
		{
			this.mEmotionTab.CustomActive(!this.mEmotionTab.activeSelf);
		}

		// Token: 0x06010580 RID: 66944 RVA: 0x0049677C File Offset: 0x00494B7C
		private void _onSendButtonClick()
		{
			if (!string.IsNullOrEmpty(this.mInput.text) && this.mInput.text.Length < 100)
			{
				ulong tarId = (this.relationData != null) ? this.relationData.uid : 0UL;
				DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_PRIVATE, RelationFriendFrame.GetFliterSizeString(this.mInput.text), tarId, 0);
				this.mInput.text = string.Empty;
			}
			else if (string.IsNullOrEmpty(this.mInput.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_relation_inputnull"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_relation_inputceil"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			if (this.mEmotionTab.activeSelf)
			{
				this.mEmotionTab.CustomActive(false);
			}
		}

		// Token: 0x06010581 RID: 66945 RVA: 0x0049685C File Offset: 0x00494C5C
		private void _onBtnDeleteButtonClick()
		{
			string msgContent = TR.Value("relation_relation_removechat");
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				DataManager<RelationDataManager>.GetInstance().DelPriChat(this.relationData.uid);
			}, delegate()
			{
			}, 0f, false);
		}

		// Token: 0x06010582 RID: 66946 RVA: 0x004968A9 File Offset: 0x00494CA9
		private void _onBtnAddButtonClick()
		{
			this.OnAddRelation();
		}

		// Token: 0x06010583 RID: 66947 RVA: 0x004968B1 File Offset: 0x00494CB1
		private void _onBlackButtonClick()
		{
			if (this.relationData == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_black_selectplayer"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_black_addrelation"), delegate()
			{
				this.OnAddRelation();
			}, null, 0f, false);
		}

		// Token: 0x06010584 RID: 66948 RVA: 0x004968F1 File Offset: 0x00494CF1
		private void _onRemoveButtonClick()
		{
			this.OnRemoveBlack();
		}

		// Token: 0x06010585 RID: 66949 RVA: 0x004968F9 File Offset: 0x00494CF9
		private void _onStrangersToggleValueChange(bool changed)
		{
			ChatManager.IsAcceptStrangerInfo = !changed;
		}

		// Token: 0x06010586 RID: 66950 RVA: 0x00496904 File Offset: 0x00494D04
		private void _onDegreeFriendClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FriendLinessSpecificationFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06010587 RID: 66951 RVA: 0x00496918 File Offset: 0x00494D18
		public static string GetFliterSizeString(string str)
		{
			str = str.Replace('<', '〈');
			str = str.Replace('>', '〉');
			return str;
		}

		// Token: 0x06010588 RID: 66952 RVA: 0x0049693C File Offset: 0x00494D3C
		private void OnAddRelation()
		{
			SceneRequest sceneRequest = new SceneRequest();
			sceneRequest.type = 3;
			sceneRequest.target = this.relationData.uid;
			sceneRequest.targetName = string.Empty;
			sceneRequest.param = 0U;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
		}

		// Token: 0x06010589 RID: 66953 RVA: 0x00496988 File Offset: 0x00494D88
		private void OnRemoveBlack()
		{
			if (this.relationData != null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("relation_confirm_to_del_black"), delegate()
				{
					DataManager<RelationDataManager>.GetInstance().DelBlack(this.relationData.uid);
				}, null, 0f, false);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_black_selectplayer"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
		}

		// Token: 0x0601058A RID: 66954 RVA: 0x004969D8 File Offset: 0x00494DD8
		protected sealed override void _OnOpenFrame()
		{
			this.data = (this.userData as RelationFriendFrameData);
			if (this.data == null)
			{
				return;
			}
			this.relationData = this.data.eCurrentRelationData;
			this.m_bWaitSearchRet = false;
			this.m_bIsQuery = false;
			this._RegisterUIEvent();
			this.comChatList.Initialize(this, Utility.FindChild(this.frame, "ChatRoot/ChatFrameNew/Middle"), this.relationData);
			this._CreateFirstMenuToggleList();
			this.m_akEmotionObjects.Clear();
			this._InitEmotionBag();
			DataManager<RelationDataManager>.GetInstance().SendUpdateRelation();
			this.mStrangersGeUISwitchBtn.SetSwitch(!ChatManager.IsAcceptStrangerInfo);
			DataManager<RelationDataManager>.GetInstance().QueryPlayerOnlineStatus();
			this.chatFrameData.eChatType = ChatType.CT_PRIVATE;
			this.chatFrameData.curPrivate = this.relationData;
			this.voiceChatModule = Singleton<SDKVoiceManager>.GetInstance().VoiceChatModule;
			this.voiceChatModule.BindRoot(Utility.FindChild(this.frame, "ChatRoot/ChatFrameNew/Bottom/InputField/VoiceInput"), VoiceInputType.ChatFrame, this.chatFrameData, null, null, new VoiceChatModule.HideEmotion(this.HideEmotionBar));
			GameObject gameObject = this.mBtnAdd.gameObject;
			UIGray uigray = gameObject.SafeAddComponent(true);
			if (uigray != null)
			{
				uigray.enabled = false;
			}
			Button component = gameObject.GetComponent<Button>();
			if (component != null)
			{
				component.interactable = true;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				if (uigray != null)
				{
					uigray.enabled = true;
				}
				if (component != null)
				{
					component.interactable = false;
				}
			}
			if (this.data.mTalk != string.Empty)
			{
				this.mInput.text = this.data.mTalk;
				this._onSendButtonClick();
			}
		}

		// Token: 0x0601058B RID: 66955 RVA: 0x00496B94 File Offset: 0x00494F94
		protected sealed override void _OnCloseFrame()
		{
			InvokeMethod.RemoveInvokeCall(this);
			DataManager<RelationDataManager>.GetInstance().ClearQueryInfo();
			this._UnRegisterUIEvent();
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.relationList = null;
			this.data = null;
			this.relationData = null;
			if (this.m_akEmotionObjects != null)
			{
				this.m_akEmotionObjects.Clear();
			}
			if (this.comChatList != null)
			{
				this.comChatList.UnInitialize();
			}
			if (this.mRelationNodeDic != null)
			{
				this.mRelationNodeDic.Clear();
			}
			if (this.mRelationSecondMenuDic != null)
			{
				this.mRelationSecondMenuDic.Clear();
			}
			if (this.comRecentlyRelationInfoList != null)
			{
				this.comRecentlyRelationInfoList.UnInitialize();
			}
			if (this.comFriendRelationInfoList != null)
			{
				this.comFriendRelationInfoList.UnInitialize();
			}
			if (this.comBlackRelationInfoList != null)
			{
				this.comBlackRelationInfoList.UnInitialize();
			}
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.UnBindRoot(VoiceInputType.ChatFrame, null);
			}
		}

		// Token: 0x0601058C RID: 66956 RVA: 0x00496C9C File Offset: 0x0049509C
		private void HideEmotionBar()
		{
			if (this.m_goEmotionTab != null)
			{
				this.m_goEmotionTab.CustomActive(false);
			}
		}

		// Token: 0x0601058D RID: 66957 RVA: 0x00496CBB File Offset: 0x004950BB
		private void SetStrangerTipShow()
		{
			this.mStrangerGO.CustomActive(true);
		}

		// Token: 0x0601058E RID: 66958 RVA: 0x00496CCC File Offset: 0x004950CC
		private void _OnItemSelected(RelationData relationData)
		{
			this.relationData = relationData;
			this.chatFrameData.curPrivate = this.relationData;
			this.data.eCurrentRelationData = null;
			if (this.data.eRelationTabType == RelationTabType.RTT_BLACK)
			{
				this.mChatFrameNewRoot.CustomActive(false);
				this.mHintRoot.CustomActive(false);
				this.mBlackRoot.CustomActive(true);
				return;
			}
			if (relationData == null)
			{
				this.mBlackRoot.CustomActive(false);
				this.mChatFrameNewRoot.CustomActive(false);
				this.mHintRoot.CustomActive(true);
				return;
			}
			this.mChatFrameNewRoot.CustomActive(true);
			this.mHintRoot.CustomActive(false);
			this.mBlackRoot.CustomActive(false);
			this.mStrangerGO.CustomActive(false);
			this.mChatScrollViewRect.offsetMax = new Vector2(this.mChatScrollViewRect.offsetMax.x, 0f);
			if (this.relationData.type == 3 || this.relationData.type == 0)
			{
				this.SetStrangerTipShow();
				this.mChatScrollViewRect.offsetMax = new Vector2(this.mChatScrollViewRect.offsetMax.x, -62f);
			}
			if (this.relationData != null)
			{
				DataManager<RelationDataManager>.GetInstance().ClearPriChatDirty(this.relationData.uid);
			}
			UIEventSystem.GetInstance().SendUIEvent(new UIEventPrivateChat(this.relationData, false));
		}

		// Token: 0x0601058F RID: 66959 RVA: 0x00496E3C File Offset: 0x0049523C
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnPrivateChat));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this._OnDelPrivate));
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddChatdata = (ChatManager.OnAddChatData)Delegate.Combine(instance.onAddChatdata, new ChatManager.OnAddChatData(this.OnAddChatData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPlayerOnLineStatusChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerOnLineStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FriendComMenuRemoveList, new ClientEventSystem.UIEventHandler(this._OnFriendComMenuRemoveList));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.SetAllRedPoint));
		}

		// Token: 0x06010590 RID: 66960 RVA: 0x00496F64 File Offset: 0x00495364
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPrivateChat, new ClientEventSystem.UIEventHandler(this._OnPrivateChat));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this._OnDelPrivate));
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddChatdata = (ChatManager.OnAddChatData)Delegate.Remove(instance.onAddChatdata, new ChatManager.OnAddChatData(this.OnAddChatData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPlayerOnLineStatusChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerOnLineStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FriendComMenuRemoveList, new ClientEventSystem.UIEventHandler(this._OnFriendComMenuRemoveList));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SetNoteNameSuccess, new ClientEventSystem.UIEventHandler(this.OnSetNoteNameSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.SetAllRedPoint));
		}

		// Token: 0x06010591 RID: 66961 RVA: 0x0049708A File Offset: 0x0049548A
		private void SetAllRedPoint(UIEvent uiEvent)
		{
			this.RefreshRelationNodeRePoint();
		}

		// Token: 0x06010592 RID: 66962 RVA: 0x00497092 File Offset: 0x00495492
		private void OnSetNoteNameSuccess(UIEvent iEvent)
		{
			this.RefreshChatData();
		}

		// Token: 0x06010593 RID: 66963 RVA: 0x0049709A File Offset: 0x0049549A
		private void _OnFriendComMenuRemoveList(UIEvent uiEvent)
		{
			this.RefreshRelationList();
		}

		// Token: 0x06010594 RID: 66964 RVA: 0x004970A2 File Offset: 0x004954A2
		private void _OnPlayerOnLineStatusChanged(UIEvent uiEvent)
		{
			this.RefreshRelationList();
		}

		// Token: 0x06010595 RID: 66965 RVA: 0x004970AC File Offset: 0x004954AC
		private void OnAddChatData(ChatBlock chatBlock)
		{
			if (chatBlock.chatData.eChatType == ChatType.CT_PRIVATE)
			{
				if (this.relationData != null)
				{
					if (this.relationData.uid == chatBlock.chatData.objid)
					{
						DataManager<RelationDataManager>.GetInstance().ClearPriChatDirty(this.relationData.uid);
					}
					else
					{
						DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(this.relationData, false);
						this.RefreshTabTitleCount();
					}
				}
				this.RefreshChatData();
			}
		}

		// Token: 0x06010596 RID: 66966 RVA: 0x00497128 File Offset: 0x00495528
		private void _OnDelPrivate(UIEvent uiEvent)
		{
			UIEventDelPrivate uieventDelPrivate = uiEvent as UIEventDelPrivate;
			if (this.relationData != null && uieventDelPrivate.m_uid == this.relationData.uid)
			{
				this.RefreshChatData();
			}
		}

		// Token: 0x06010597 RID: 66967 RVA: 0x00497164 File Offset: 0x00495564
		private void RefreshRelationList()
		{
			if (this.data.eRelationTabType == RelationTabType.RTT_RECENTLY)
			{
				if (this.comRecentlyRelationInfoList.Initilized)
				{
					this.comRecentlyRelationInfoList.RefreshAllRelations(this.data.eRelationTabType);
				}
			}
			else if (this.data.eRelationTabType == RelationTabType.RTT_FRIEND)
			{
				if (this.comFriendRelationInfoList.Initilized)
				{
					this.comFriendRelationInfoList.RefreshAllRelations(this.data.eRelationTabType);
				}
			}
			else if (this.data.eRelationTabType == RelationTabType.RTT_BLACK && this.comBlackRelationInfoList.Initilized)
			{
				this.comBlackRelationInfoList.RefreshAllRelations(this.data.eRelationTabType);
			}
			this.RefreshTabTitleCount();
			this.RefreshRelationListHide(this.data.eRelationTabType);
			this.RefreshTabNoRelationShowContent(this.data.eRelationTabType);
			this.RefreshRelationNodeRePoint();
		}

		// Token: 0x06010598 RID: 66968 RVA: 0x00497250 File Offset: 0x00495650
		private void RefreshTabTitleCount()
		{
			RelationFriendFrame.RelationNode relationNode = null;
			for (int i = 0; i < 3; i++)
			{
				RelationTabType relationTabType = (RelationTabType)i;
				if (this.mRelationNodeDic.TryGetValue(relationTabType, out relationNode) && relationNode != null)
				{
					ComCommonBind bind = relationNode.bind;
					Text com = bind.GetCom<Text>("desc");
					Text com2 = bind.GetCom<Text>("Text");
					Text text = com;
					string text2 = this.InitMenuGroupTitle(relationTabType);
					com2.text = text2;
					text.text = text2;
				}
			}
		}

		// Token: 0x06010599 RID: 66969 RVA: 0x004972C8 File Offset: 0x004956C8
		private void RefreshRelationListHide(RelationTabType type)
		{
			ComCommonBind comCommonBind = null;
			if (this.mRelationSecondMenuDic.TryGetValue(this.data.eRelationTabType, out comCommonBind))
			{
				GameObject gameObject = comCommonBind.GetGameObject("Content");
				if (gameObject == null)
				{
					return;
				}
				LayoutElement com = comCommonBind.GetCom<LayoutElement>("LayoutElement");
				if (com == null)
				{
					return;
				}
				RectTransform component = gameObject.GetComponent<RectTransform>();
				float x = component.sizeDelta.x;
				int num = this.RelationCount(type);
				float preferredHeight;
				if (num == 2)
				{
					preferredHeight = 310f;
				}
				else if (num == 0)
				{
					preferredHeight = 462f;
				}
				else if (num == 1)
				{
					preferredHeight = 160f;
				}
				else
				{
					preferredHeight = 462f;
				}
				com.preferredWidth = x;
				com.preferredHeight = preferredHeight;
			}
		}

		// Token: 0x0601059A RID: 66970 RVA: 0x004973A0 File Offset: 0x004957A0
		private void RefreshRelationNodeRePoint()
		{
			RelationFriendFrame.RelationNode relationNode = null;
			if (this.mRelationNodeDic.TryGetValue(RelationTabType.RTT_RECENTLY, out relationNode) && relationNode != null)
			{
				GameObject gameObject = relationNode.bind.GetGameObject("redPoint");
				if (gameObject != null)
				{
					gameObject.CustomActive(DataManager<RelationDataManager>.GetInstance().GetPriDirty());
				}
			}
		}

		// Token: 0x0601059B RID: 66971 RVA: 0x004973F8 File Offset: 0x004957F8
		private void _CreateFirstMenuToggleList()
		{
			for (int i = 0; i < 3; i++)
			{
				ComCommonBind comCommonBind = this.mBind.LoadExtraBind("UIFlatten/Prefabs/RelationFrame/RelationMenuGroup");
				if (null != comCommonBind)
				{
					RelationFriendFrame.RelationNode relationNode = new RelationFriendFrame.RelationNode();
					relationNode.bind = comCommonBind;
					if (!this.mRelationNodeDic.ContainsKey((RelationTabType)i))
					{
						this.mRelationNodeDic.Add((RelationTabType)i, relationNode);
					}
					Utility.AttachTo(comCommonBind.gameObject, this.mTargetRoot, false);
					Text com = comCommonBind.GetCom<Text>("desc");
					Toggle com2 = comCommonBind.GetCom<Toggle>("ongroup");
					GameObject gameObject = comCommonBind.GetGameObject("redPoint");
					if (i == 0)
					{
						gameObject.CustomActive(DataManager<RelationDataManager>.GetInstance().GetPriDirty());
					}
					else
					{
						gameObject.CustomActive(false);
					}
					com2.group = this.mToggleGroup;
					ComSwitchNode com3 = comCommonBind.GetCom<ComSwitchNode>("switchNode");
					if (com3 != null)
					{
						com3.Reset();
					}
					int index = i;
					com.text = this.InitMenuGroupTitle((RelationTabType)index);
					com2.onValueChanged.AddListener(delegate(bool value)
					{
						this.OnChooseFirstMenu((RelationTabType)index, value);
					});
					if (index == 0)
					{
						com2.isOn = true;
					}
				}
			}
		}

		// Token: 0x0601059C RID: 66972 RVA: 0x0049753C File Offset: 0x0049593C
		private string InitMenuGroupTitle(RelationTabType type)
		{
			string result = string.Empty;
			int num = 0;
			if (type == RelationTabType.RTT_RECENTLY)
			{
				List<PrivateChatPlayerData> priChatList = DataManager<RelationDataManager>.GetInstance().GetPriChatList();
				for (int i = 0; i < priChatList.Count; i++)
				{
					PrivateChatPlayerData privateChatPlayerData = priChatList[i];
					if (privateChatPlayerData.relationData.status != 2)
					{
						if (privateChatPlayerData.relationData.isOnline >= 1)
						{
							num++;
						}
					}
				}
				result = TR.Value("relation_recently", num, priChatList.Count);
			}
			else if (type == RelationTabType.RTT_FRIEND)
			{
				List<RelationData> list = new List<RelationData>();
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
				List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
				List<RelationData> relation3 = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				list.AddRange(relation);
				list.AddRange(relation2);
				list.AddRange(relation3);
				for (int j = 0; j < list.Count; j++)
				{
					RelationData relationData = list[j];
					if (relationData.status != 2)
					{
						num++;
					}
				}
				result = TR.Value("relation_friend", num, list.Count);
			}
			else if (type == RelationTabType.RTT_BLACK)
			{
				List<RelationData> relation4 = DataManager<RelationDataManager>.GetInstance().GetRelation(2);
				for (int k = 0; k < relation4.Count; k++)
				{
					RelationData relationData2 = relation4[k];
					if (relationData2.status != 2)
					{
						num++;
					}
				}
				result = TR.Value("relation_black_friend", num, relation4.Count);
			}
			return result;
		}

		// Token: 0x0601059D RID: 66973 RVA: 0x004976F4 File Offset: 0x00495AF4
		private int RelationCount(RelationTabType type)
		{
			List<RelationData> list = new List<RelationData>();
			if (type == RelationTabType.RTT_RECENTLY)
			{
				List<PrivateChatPlayerData> priChatList = DataManager<RelationDataManager>.GetInstance().GetPriChatList();
				for (int i = 0; i < priChatList.Count; i++)
				{
					PrivateChatPlayerData privateChatPlayerData = priChatList[i];
					list.Add(privateChatPlayerData.relationData);
				}
			}
			else if (type == RelationTabType.RTT_FRIEND)
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(1);
				List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
				List<RelationData> relation3 = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				list.AddRange(relation);
				list.AddRange(relation2);
				list.AddRange(relation3);
			}
			else if (type == RelationTabType.RTT_BLACK)
			{
				List<RelationData> relation4 = DataManager<RelationDataManager>.GetInstance().GetRelation(2);
				list.AddRange(relation4);
			}
			return list.Count;
		}

		// Token: 0x0601059E RID: 66974 RVA: 0x004977B8 File Offset: 0x00495BB8
		private void RefreshTabNoRelationShowContent(RelationTabType type)
		{
			if (this.relationData != null)
			{
				this.mChatFrameNewRoot.CustomActive(true);
				this.mHintRoot.CustomActive(false);
			}
			else
			{
				this.mChatFrameNewRoot.CustomActive(false);
				this.mHintRoot.CustomActive(true);
			}
			this.mBlackRoot.CustomActive(false);
			this.comStateFriend.Key = "None";
			int num = this.RelationCount(type);
			if (num <= 0)
			{
				if (type == RelationTabType.RTT_RECENTLY)
				{
					this.mHintRoot.CustomActive(true);
					this.comStateFriend.Key = "Recently";
				}
				else if (type == RelationTabType.RTT_FRIEND)
				{
					this.mHintRoot.CustomActive(true);
					this.comStateFriend.Key = "Friend";
				}
			}
			if (type == RelationTabType.RTT_BLACK)
			{
				this.mChatFrameNewRoot.CustomActive(false);
				this.mBlackRoot.CustomActive(true);
				if (num <= 0)
				{
					this.comStateFriend.Key = "Black";
					this.mBlackJianbianRoot.CustomActive(false);
				}
				else
				{
					this.mBlackJianbianRoot.CustomActive(true);
				}
			}
		}

		// Token: 0x0601059F RID: 66975 RVA: 0x004978D0 File Offset: 0x00495CD0
		private void OnChooseFirstMenu(RelationTabType type, bool value)
		{
			if (this.data.eRelationTabType == type)
			{
				return;
			}
			if (value)
			{
				ComRelationInfo.ms_selected = null;
				if (this.data.eCurrentRelationData != null)
				{
					this.relationData = this.data.eCurrentRelationData;
				}
				else
				{
					this.relationData = null;
				}
				this.mChatFrameNewRoot.CustomActive(true);
				this.mHintRoot.CustomActive(false);
				this.mBlackRoot.CustomActive(false);
				this.data.eRelationTabType = type;
				RelationFriendFrame.RelationNode relationNode = null;
				ComCommonBind comCommonBind = null;
				GameObject gameObject = null;
				List<RelationData> list = new List<RelationData>();
				if (this.mRelationNodeDic.TryGetValue(type, out relationNode))
				{
					if (!this.mRelationSecondMenuDic.ContainsKey(type))
					{
						ComCommonBind bind = relationNode.bind;
						ComSwitchNode com = bind.GetCom<ComSwitchNode>("switchNode");
						comCommonBind = com.AddOneSubItem();
						gameObject = comCommonBind.GetGameObject("go");
						this.mRelationSecondMenuDic.Add(type, comCommonBind);
					}
					else if (this.mRelationSecondMenuDic.TryGetValue(type, out comCommonBind))
					{
						gameObject = comCommonBind.GetGameObject("go");
					}
				}
				if (type != RelationTabType.RTT_RECENTLY)
				{
					DataManager<RelationDataManager>.GetInstance().SetRecentlyHaveRead();
				}
				if (type == RelationTabType.RTT_RECENTLY)
				{
					if (gameObject != null)
					{
						if (!this.comRecentlyRelationInfoList.Initilized)
						{
							this.comRecentlyRelationInfoList.Initialize(this, gameObject, new ComRelationInfoList.OnItemSelected(this._OnItemSelected), type, this.relationData);
						}
						else
						{
							this.comRecentlyRelationInfoList.RefreshAllRelations(type);
						}
					}
				}
				else if (type == RelationTabType.RTT_FRIEND)
				{
					if (gameObject != null)
					{
						if (!this.comFriendRelationInfoList.Initilized)
						{
							this.comFriendRelationInfoList.Initialize(this, gameObject, new ComRelationInfoList.OnItemSelected(this._OnItemSelected), type, this.relationData);
						}
						else
						{
							this.comFriendRelationInfoList.RefreshAllRelations(type);
						}
					}
				}
				else if (type == RelationTabType.RTT_BLACK && gameObject != null)
				{
					if (!this.comBlackRelationInfoList.Initilized)
					{
						this.comBlackRelationInfoList.Initialize(this, gameObject, new ComRelationInfoList.OnItemSelected(this._OnItemSelected), type, this.relationData);
					}
					else
					{
						this.comBlackRelationInfoList.RefreshAllRelations(type);
					}
				}
				this.RefreshTabNoRelationShowContent(type);
				GameObject gameObject2 = comCommonBind.GetGameObject("Content");
				if (gameObject2 == null)
				{
					return;
				}
				LayoutElement com2 = comCommonBind.GetCom<LayoutElement>("LayoutElement");
				if (com2 == null)
				{
					return;
				}
				RectTransform component = gameObject2.GetComponent<RectTransform>();
				float x = component.sizeDelta.x;
				int num = this.RelationCount(type);
				float preferredHeight;
				if (num == 2)
				{
					preferredHeight = 310f;
				}
				else if (num == 0)
				{
					preferredHeight = 462f;
				}
				else if (num == 1)
				{
					preferredHeight = 160f;
				}
				else
				{
					preferredHeight = 462f;
				}
				com2.preferredWidth = x;
				com2.preferredHeight = preferredHeight;
			}
			else
			{
				this.comStateFriend.Key = "None";
			}
		}

		// Token: 0x060105A0 RID: 66976 RVA: 0x00497BC9 File Offset: 0x00495FC9
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			this.RefreshRelationList();
		}

		// Token: 0x060105A1 RID: 66977 RVA: 0x00497BD1 File Offset: 0x00495FD1
		private void _OnRefreshInviteList(UIEvent uiEvent)
		{
			this._OnRelationChanged(null);
		}

		// Token: 0x060105A2 RID: 66978 RVA: 0x00497BDA File Offset: 0x00495FDA
		[UIEventHandle("LeftRoot/buttom/Recommended")]
		private void OnReconmmendClick()
		{
			this.OpenFriendRecommendFrame();
		}

		// Token: 0x060105A3 RID: 66979 RVA: 0x00497BE2 File Offset: 0x00495FE2
		private void OpenFriendRecommendFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FriendRecommendedFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060105A4 RID: 66980 RVA: 0x00497BF6 File Offset: 0x00495FF6
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/RelationFrame/RelationFriendFrame";
		}

		// Token: 0x060105A5 RID: 66981 RVA: 0x00497C00 File Offset: 0x00496000
		[UIEventHandle("Controls/BtnRefuseAll")]
		private void _OnRefuseAll()
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

		// Token: 0x060105A6 RID: 66982 RVA: 0x00497C84 File Offset: 0x00496084
		[UIEventHandle("Controls/BtnAcceptAll")]
		private void _OnAcceptAll()
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

		// Token: 0x060105A7 RID: 66983 RVA: 0x00497D08 File Offset: 0x00496108
		[UIEventHandle("Controls/BtnAddAll")]
		private void _OnAddAll()
		{
			if (this.relationList != null && this.relationList.Count > 0)
			{
				this.grayAddAll.enabled = true;
				this.btnAddAll.enabled = false;
				for (int i = 0; i < this.relationList.Count; i++)
				{
					string name = this.relationList[i].name;
					ulong uid = this.relationList[i].uid;
					InvokeMethod.Invoke(this, (float)i * 0.2f, delegate()
					{
						DataManager<RelationDataManager>.GetInstance().AddQueryInfo(uid);
						SceneRequest sceneRequest = new SceneRequest();
						sceneRequest.type = 29;
						sceneRequest.targetName = name;
						NetManager netManager = NetManager.Instance();
						netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, sceneRequest);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RelationAddRecommendFriendMsgSended, uid, null, null, null);
					});
				}
			}
		}

		// Token: 0x060105A8 RID: 66984 RVA: 0x00497DB4 File Offset: 0x004961B4
		[UIEventHandle("Controls/BtnSearch")]
		private void _OnClickSearch()
		{
			if (string.IsNullOrEmpty(this.inputFiled.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_search_name_empty"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.m_bWaitSearchRet)
			{
				return;
			}
			this.m_bWaitSearchRet = true;
			this.m_bIsQuery = true;
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
				this.m_bWaitSearchRet = false;
			});
			WorldQueryPlayerReq worldQueryPlayerReq = new WorldQueryPlayerReq();
			worldQueryPlayerReq.roleId = 0UL;
			DataManager<OtherPlayerInfoManager>.GetInstance().QueryPlayerType = WorldQueryPlayerType.WQPT_FRIEND;
			worldQueryPlayerReq.name = this.inputFiled.text;
			MonoSingleton<NetManager>.instance.SendCommand<WorldQueryPlayerReq>(ServerType.GATE_SERVER, worldQueryPlayerReq);
		}

		// Token: 0x060105A9 RID: 66985 RVA: 0x00497E4F File Offset: 0x0049624F
		public bool IsQuerying()
		{
			return this.m_bIsQuery;
		}

		// Token: 0x060105AA RID: 66986 RVA: 0x00497E58 File Offset: 0x00496258
		private void _UpdateFriendCount(int pre)
		{
			if (null != this.mFriendCount)
			{
				int maxFriendCount = DataManager<RelationDataManager>.GetInstance().maxFriendCount;
				this.mFriendCount.text = pre + "/" + maxFriendCount;
			}
		}

		// Token: 0x060105AB RID: 66987 RVA: 0x00497EA4 File Offset: 0x004962A4
		[UIEventHandle("Hint/ToRecommend")]
		private void OnClickGoToRecommendTab()
		{
			this.OpenFriendRecommendFrame();
		}

		// Token: 0x060105AC RID: 66988 RVA: 0x00497EAC File Offset: 0x004962AC
		[UIEventHandle("Hint_1/ToRecommend")]
		private void OnClickGoToRecommendTab1()
		{
			this.OpenFriendRecommendFrame();
		}

		// Token: 0x060105AD RID: 66989 RVA: 0x00497EB4 File Offset: 0x004962B4
		[UIEventHandle("BtnSort")]
		private void _OnSortMyFriend()
		{
		}

		// Token: 0x060105AE RID: 66990 RVA: 0x00497EB8 File Offset: 0x004962B8
		[UIEventHandle("BtnDonateAll")]
		private void _OnDonateAll()
		{
			if (this.data.eRelationTabType != RelationTabType.RTT_FRIEND)
			{
				return;
			}
			if (null == this.comDonateState)
			{
				return;
			}
			this.comDonateState.Key = "Disable";
			this._DonateAllFriends();
			if (null != this.labelDonateAll)
			{
				this.labelDonateAll.text = TR.Value("relation_donate_all_desc_param", this.iDonateCoolDown);
			}
			this.iDonateCoolDown--;
			InvokeMethod.Invoke(this, 1f, new UnityAction(this._DonateAllCoolDown));
		}

		// Token: 0x060105AF RID: 66991 RVA: 0x00497F58 File Offset: 0x00496358
		private void _DonateAllCoolDown()
		{
			this.labelDonateAll.text = TR.Value("relation_donate_all_desc_param", this.iDonateCoolDown);
			this.iDonateCoolDown--;
			if (this.iDonateCoolDown == -1)
			{
				this.labelDonateAll.text = TR.Value("relation_donate_all_desc", string.Empty);
				this.iDonateCoolDown = 5;
				this.comDonateState.Key = "Enable";
				this._UpdateDonateState();
			}
			else
			{
				InvokeMethod.Invoke(this, 1f, new UnityAction(this._DonateAllCoolDown));
			}
		}

		// Token: 0x060105B0 RID: 66992 RVA: 0x00497FF4 File Offset: 0x004963F4
		private void _UpdateDonateState()
		{
			if (this.data.eRelationTabType != RelationTabType.RTT_FRIEND)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.relationList.Count; i++)
			{
				RelationData relationData = this.relationList[i];
				if (relationData != null && relationData.dayGiftNum > 0 && relationData.status != 2)
				{
					flag = true;
					break;
				}
			}
			this.comDonateState.Key = ((!flag) ? "Disable" : "Enable");
		}

		// Token: 0x060105B1 RID: 66993 RVA: 0x00498084 File Offset: 0x00496484
		private void _DonateAllFriends()
		{
			float num = 0f;
			for (int i = 0; i < this.relationList.Count; i++)
			{
				RelationData relation = this.relationList[i];
				if (relation != null)
				{
					InvokeMethod.Invoke(this, num, delegate()
					{
						if (relation != null)
						{
							ComRelationInfo.SendGift(relation);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDonateAllSended, relation, null, null, null);
						}
					});
					num += 0.08f;
				}
			}
		}

		// Token: 0x060105B2 RID: 66994 RVA: 0x004980F8 File Offset: 0x004964F8
		protected void _OnShowFrienSecInfo(UIEvent uiEvent)
		{
			UIEventShowFriendSecMenu uieventShowFriendSecMenu = uiEvent as UIEventShowFriendSecMenu;
			if (this.m_openMenu != null)
			{
				this.m_openMenu.Close(true);
				this.m_openMenu = null;
			}
			this.m_openMenu = this.frameMgr.OpenFrame<FriendComMenuFrame>(FrameLayer.Middle, uieventShowFriendSecMenu.m_data, string.Empty);
		}

		// Token: 0x060105B3 RID: 66995 RVA: 0x00498147 File Offset: 0x00496547
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x060105B4 RID: 66996 RVA: 0x00498170 File Offset: 0x00496570
		private void _OnPrivateChat(UIEvent uiEvent)
		{
			UIEventPrivateChat uieventPrivateChat = uiEvent as UIEventPrivateChat;
			if (this.relationData != null)
			{
				DataManager<RelationDataManager>.GetInstance().ClearPriChatDirty(this.relationData.uid);
			}
			if (uieventPrivateChat.m_recvChat)
			{
				if (this.data.eRelationTabType == RelationTabType.RTT_RECENTLY)
				{
					this.comRecentlyRelationInfoList.RefreshAllRelations(this.data.eRelationTabType);
				}
			}
			else if (this.data.eRelationTabType != RelationTabType.RTT_BLACK)
			{
				this.RefreshChatData();
			}
			this.RefreshRelationNodeRePoint();
			this.RefreshRelationListHide(this.data.eRelationTabType);
			this.RefreshTabTitleCount();
			this.RefreshTabNoRelationShowContent(this.data.eRelationTabType);
			this.RefreshChatData();
		}

		// Token: 0x060105B5 RID: 66997 RVA: 0x00498225 File Offset: 0x00496625
		private void RefreshChatData()
		{
			this.RefreshChatInfo(this.relationData);
			this.comChatList.RefreshChatData(this.relationData);
			this.mScrollRect.verticalNormalizedPosition = 0f;
		}

		// Token: 0x060105B6 RID: 66998 RVA: 0x00498254 File Offset: 0x00496654
		private void RefreshChatInfo(RelationData data)
		{
			if (data == null)
			{
				return;
			}
			this.mRelation.CustomActive(false);
			if (this.mName != null)
			{
				if (data.remark != null && this.relationData.remark != string.Empty)
				{
					this.mName.text = data.remark;
				}
				else
				{
					this.mName.text = data.name;
				}
			}
			if (this.mLevel != null)
			{
				this.mLevel.text = string.Format("Lv.{0}", data.level);
			}
			if (data.type == 1 || data.type == 4 || data.type == 5)
			{
				this.mBtnAddGo.CustomActive(false);
			}
			else
			{
				this.mBtnAddGo.CustomActive(true);
			}
			if (this.mDegreeFriend != null)
			{
				this.mDegreeFriend.text = data.intimacy.ToString();
			}
			string friendlyDegreesIntervalName = DataManager<RelationDataManager>.GetInstance().GetFriendlyDegreesIntervalName((int)data.intimacy);
			if (friendlyDegreesIntervalName != string.Empty)
			{
				this.mRelation.CustomActive(true);
				this.mRelation.text = friendlyDegreesIntervalName;
			}
		}

		// Token: 0x060105B7 RID: 66999 RVA: 0x004983AC File Offset: 0x004967AC
		private void _InitEmotionBag()
		{
			this.m_goEmotionTab = Utility.FindChild(this.frame, "ChatRoot/ChatFrameNew/Bottom/EmotionTab");
			this.m_goEmotionTab.CustomActive(false);
			this.m_goEmotionPrefab = Utility.FindChild(this.m_goEmotionTab, "Emotion");
			this.m_goEmotionPrefab.CustomActive(false);
			this.m_spriteAsset = (Singleton<AssetLoader>.instance.LoadRes("UI/Image/Emotion/emotion.asset", typeof(SpriteAsset), true, 0U).obj as SpriteAsset);
			if (this.m_spriteAsset != null && this.m_spriteAsset.listSpriteAssetInfor != null)
			{
				for (int i = 0; i < this.m_spriteAsset.listSpriteAssetInfor.Count; i++)
				{
					SpriteAssetInfor spriteAssetInfor = this.m_spriteAsset.listSpriteAssetInfor[i];
					if (spriteAssetInfor != null)
					{
						this.m_akEmotionObjects.Create(i, new object[]
						{
							this.m_goEmotionTab,
							this.m_goEmotionPrefab,
							spriteAssetInfor,
							this
						});
					}
				}
			}
		}

		// Token: 0x060105B8 RID: 67000 RVA: 0x004984AF File Offset: 0x004968AF
		private void AddChatText(string content)
		{
			if (!string.IsNullOrEmpty(content))
			{
				OnFocusInputField onFocusInputField = this.mInput;
				onFocusInputField.text += content;
			}
		}

		// Token: 0x060105B9 RID: 67001 RVA: 0x004984D3 File Offset: 0x004968D3
		public void PlayVoice(string voiceKey, string chatTime, ChatVoiceInPlay voicePlayInQueue)
		{
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.PlayOnChatVoice(voiceKey, chatTime, voicePlayInQueue);
			}
		}

		// Token: 0x060105BA RID: 67002 RVA: 0x004984F0 File Offset: 0x004968F0
		public void OnPopupMenu()
		{
			if (this.relationData != null)
			{
				RelationMenuData relationMenuData = new RelationMenuData();
				relationMenuData.m_data = this.relationData;
				if (this.data.eRelationTabType == RelationTabType.RTT_RECENTLY)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT;
				}
				else if (this.data.eRelationTabType == RelationTabType.RTT_FRIEND)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_COMMON;
				}
				else if (this.data.eRelationTabType == RelationTabType.RTT_BLACK)
				{
					relationMenuData.type = CommonPlayerInfo.CommonPlayerType.CPT_BLACK;
				}
				UIEventSystem.GetInstance().SendUIEvent(new UIEventShowFriendSecMenu(relationMenuData));
			}
		}

		// Token: 0x0400A57B RID: 42363
		private const string kMenuPath = "UIFlatten/Prefabs/RelationFrame/RelationMenuGroup";

		// Token: 0x0400A57C RID: 42364
		private RelationFriendFrameData data;

		// Token: 0x0400A57D RID: 42365
		private List<RelationData> relationList;

		// Token: 0x0400A57E RID: 42366
		private List<InviteFriendData> inviteFriends;

		// Token: 0x0400A57F RID: 42367
		private ComChatListNew comChatList = new ComChatListNew();

		// Token: 0x0400A580 RID: 42368
		private RelationData relationData;

		// Token: 0x0400A581 RID: 42369
		private ComRelationInfoList comRecentlyRelationInfoList = new ComRelationInfoList();

		// Token: 0x0400A582 RID: 42370
		private ComRelationInfoList comFriendRelationInfoList = new ComRelationInfoList();

		// Token: 0x0400A583 RID: 42371
		private ComRelationInfoList comBlackRelationInfoList = new ComRelationInfoList();

		// Token: 0x0400A584 RID: 42372
		private Dictionary<RelationTabType, RelationFriendFrame.RelationNode> mRelationNodeDic = new Dictionary<RelationTabType, RelationFriendFrame.RelationNode>();

		// Token: 0x0400A585 RID: 42373
		private Dictionary<RelationTabType, ComCommonBind> mRelationSecondMenuDic = new Dictionary<RelationTabType, ComCommonBind>();

		// Token: 0x0400A586 RID: 42374
		private ChatFrameData chatFrameData = new ChatFrameData();

		// Token: 0x0400A587 RID: 42375
		private VoiceChatModule voiceChatModule;

		// Token: 0x0400A588 RID: 42376
		private GameObject mEmotionTab;

		// Token: 0x0400A589 RID: 42377
		private Button mEmotion;

		// Token: 0x0400A58A RID: 42378
		private Button mSend;

		// Token: 0x0400A58B RID: 42379
		private OnFocusInputField mInput;

		// Token: 0x0400A58C RID: 42380
		private ComUIListScript mComUIList;

		// Token: 0x0400A58D RID: 42381
		private Button mBtnDelete;

		// Token: 0x0400A58E RID: 42382
		private Button mBtnAdd;

		// Token: 0x0400A58F RID: 42383
		private Text mDegreeFriend;

		// Token: 0x0400A590 RID: 42384
		private Text mName;

		// Token: 0x0400A591 RID: 42385
		private GameObject mDegreeFriendsGO;

		// Token: 0x0400A592 RID: 42386
		private GameObject mBtnAddGo;

		// Token: 0x0400A593 RID: 42387
		private GameObject mChatFrameNewRoot;

		// Token: 0x0400A594 RID: 42388
		private GeUISwitchButton mStrangersGeUISwitchBtn;

		// Token: 0x0400A595 RID: 42389
		private ToggleGroup mToggleGroup;

		// Token: 0x0400A596 RID: 42390
		private RectTransform mChatScrollViewRect;

		// Token: 0x0400A597 RID: 42391
		private GameObject mStrangerGO;

		// Token: 0x0400A598 RID: 42392
		private GameObject mHintRoot;

		// Token: 0x0400A599 RID: 42393
		private GameObject mBlackRoot;

		// Token: 0x0400A59A RID: 42394
		private Text mLevel;

		// Token: 0x0400A59B RID: 42395
		private Button mBlackBtnAdd;

		// Token: 0x0400A59C RID: 42396
		private Button mBalckBtnRemove;

		// Token: 0x0400A59D RID: 42397
		private GameObject mBlackJianbianRoot;

		// Token: 0x0400A59E RID: 42398
		private Text mRelation;

		// Token: 0x0400A59F RID: 42399
		private Button mDegreeFriendBtn;

		// Token: 0x0400A5A0 RID: 42400
		private ScrollRect mScrollRect;

		// Token: 0x0400A5A1 RID: 42401
		[UIObject("LeftRoot/Content")]
		private GameObject mTargetRoot;

		// Token: 0x0400A5A2 RID: 42402
		[UIControl("Controls", typeof(StateController), 0)]
		private StateController comController;

		// Token: 0x0400A5A3 RID: 42403
		[UIControl("Controls/BtnAcceptAll", typeof(Button), 0)]
		private Button btnAcceptAll;

		// Token: 0x0400A5A4 RID: 42404
		[UIControl("Controls/BtnRefuseAll", typeof(Button), 0)]
		private Button btnRefuseAll;

		// Token: 0x0400A5A5 RID: 42405
		[UIControl("Controls/BtnAddAll", typeof(Button), 0)]
		private Button btnAddAll;

		// Token: 0x0400A5A6 RID: 42406
		[UIControl("Controls/BtnAddAll", typeof(UIGray), 0)]
		private UIGray grayAddAll;

		// Token: 0x0400A5A7 RID: 42407
		[UIControl("Controls/InputField", typeof(InputField), 0)]
		private InputField inputFiled;

		// Token: 0x0400A5A8 RID: 42408
		private bool m_bWaitSearchRet;

		// Token: 0x0400A5A9 RID: 42409
		private bool m_bIsQuery;

		// Token: 0x0400A5AA RID: 42410
		[UIObject("Hint")]
		private GameObject goHintAddRecommendFriend;

		// Token: 0x0400A5AB RID: 42411
		[UIObject("Hint_1")]
		private GameObject goHintApplyFriend;

		// Token: 0x0400A5AC RID: 42412
		[UIObject("Hint_2")]
		private GameObject goHintAddBlack;

		// Token: 0x0400A5AD RID: 42413
		[UIControl("", typeof(StateController), 0)]
		private StateController comStateFriend;

		// Token: 0x0400A5AE RID: 42414
		[UIControl("FriendCount/FriendCnt", typeof(Text), 0)]
		private Text mFriendCount;

		// Token: 0x0400A5AF RID: 42415
		[UIControl("BG", typeof(StateController), 0)]
		private StateController comDonateState;

		// Token: 0x0400A5B0 RID: 42416
		[UIControl("BtnDonateAll/Text", typeof(Text), 0)]
		private Text labelDonateAll;

		// Token: 0x0400A5B1 RID: 42417
		private int iDonateCoolDown = 5;

		// Token: 0x0400A5B2 RID: 42418
		private IClientFrame m_openMenu;

		// Token: 0x0400A5B3 RID: 42419
		[UIObject("ChatRoot")]
		private GameObject chatRoot;

		// Token: 0x0400A5B4 RID: 42420
		private GameObject m_goEmotionTab;

		// Token: 0x0400A5B5 RID: 42421
		private GameObject m_goEmotionPrefab;

		// Token: 0x0400A5B6 RID: 42422
		private SpriteAsset m_spriteAsset;

		// Token: 0x0400A5B7 RID: 42423
		private CachedObjectDicManager<int, RelationFriendFrame.EmotionObject> m_akEmotionObjects = new CachedObjectDicManager<int, RelationFriendFrame.EmotionObject>();

		// Token: 0x02001A05 RID: 6661
		private class RelationNode
		{
			// Token: 0x0400A5B9 RID: 42425
			public ComCommonBind bind;
		}

		// Token: 0x02001A06 RID: 6662
		public class EmotionObject : CachedObject
		{
			// Token: 0x060105C2 RID: 67010 RVA: 0x004985CC File Offset: 0x004969CC
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.spriteAssetInfo = (param[2] as SpriteAssetInfor);
				this.THIS = (param[3] as RelationFriendFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.emotion = this.goLocal.GetComponent<Image>();
					this.button = this.goLocal.GetComponent<Button>();
					this.button.onClick.RemoveAllListeners();
					this.button.onClick.AddListener(new UnityAction(this.OnClickEmotion));
				}
				this.Enable();
				this._UpdateItem();
			}

			// Token: 0x060105C3 RID: 67011 RVA: 0x0049869F File Offset: 0x00496A9F
			public sealed override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x060105C4 RID: 67012 RVA: 0x004986A7 File Offset: 0x00496AA7
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x060105C5 RID: 67013 RVA: 0x004986C6 File Offset: 0x00496AC6
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x060105C6 RID: 67014 RVA: 0x004986E5 File Offset: 0x00496AE5
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060105C7 RID: 67015 RVA: 0x004986EE File Offset: 0x00496AEE
			public sealed override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x060105C8 RID: 67016 RVA: 0x004986F7 File Offset: 0x00496AF7
			public sealed override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x060105C9 RID: 67017 RVA: 0x004986FA File Offset: 0x00496AFA
			private void _UpdateItem()
			{
				this.emotion.sprite = this.spriteAssetInfo.sprite;
			}

			// Token: 0x060105CA RID: 67018 RVA: 0x00498712 File Offset: 0x00496B12
			private void OnClickEmotion()
			{
				this.THIS.AddChatText("{F " + string.Format("{0}", this.spriteAssetInfo.ID) + "}");
			}

			// Token: 0x0400A5BA RID: 42426
			protected GameObject goLocal;

			// Token: 0x0400A5BB RID: 42427
			protected GameObject goParent;

			// Token: 0x0400A5BC RID: 42428
			protected GameObject goPrefab;

			// Token: 0x0400A5BD RID: 42429
			protected SpriteAssetInfor spriteAssetInfo;

			// Token: 0x0400A5BE RID: 42430
			protected RelationFriendFrame THIS;

			// Token: 0x0400A5BF RID: 42431
			private Image emotion;

			// Token: 0x0400A5C0 RID: 42432
			private Button button;
		}
	}
}
