using System;
using System.Collections.Generic;
using ActivityLimitTime;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F1F RID: 3871
	internal class ComTalk : MonoBehaviour
	{
		// Token: 0x060096DD RID: 38621 RVA: 0x001CC120 File Offset: 0x001CA520
		public static ComTalk Create(GameObject goParent)
		{
			if (ComTalk.ms_comTalk != null)
			{
				Utility.AttachTo(ComTalk.ms_comTalk.gameObject, goParent, false);
				ComTalk.ms_comTalk.gameObject.CustomActive(true);
				ComTalk.ms_comTalk.gameObject.transform.localScale = Vector3.one;
				(ComTalk.ms_comTalk.gameObject.transform as RectTransform).anchoredPosition3D = Vector3.zero;
				ComTalk.ms_comTalk.TrySetVoiceChatBtnsPos();
				return ComTalk.ms_comTalk;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes("UIFlatten/Prefabs/Common/ComTalk", typeof(GameObject), true, 0U).obj as GameObject;
			if (gameObject != null)
			{
				Utility.AttachTo(gameObject, goParent, false);
				gameObject.CustomActive(true);
				ComTalk.ms_comTalk = gameObject.AddComponent<ComTalk>();
				(ComTalk.ms_comTalk.gameObject.transform as RectTransform).anchoredPosition3D = Vector3.zero;
				ComTalk.ms_comTalk.TrySetVoiceChatBtnsPos();
				return ComTalk.ms_comTalk;
			}
			return null;
		}

		// Token: 0x060096DE RID: 38622 RVA: 0x001CC220 File Offset: 0x001CA620
		public static void Recycle()
		{
			if (null != ComTalk.ms_comTalk)
			{
				ComTalk.ms_comTalk.gameObject.transform.SetParent(null);
			}
		}

		// Token: 0x060096DF RID: 38623 RVA: 0x001CC247 File Offset: 0x001CA647
		public static void ForceDestroy()
		{
			if (null != ComTalk.ms_comTalk)
			{
				ComTalk.ms_comTalk.gameObject.transform.SetParent(null);
				Object.Destroy(ComTalk.ms_comTalk.gameObject);
				ComTalk.ms_comTalk = null;
			}
		}

		// Token: 0x060096E0 RID: 38624 RVA: 0x001CC283 File Offset: 0x001CA683
		private void Update()
		{
		}

		// Token: 0x060096E1 RID: 38625 RVA: 0x001CC288 File Offset: 0x001CA688
		private void Awake()
		{
			this.m_root = base.gameObject;
			this.m_goBtnUp = Utility.FindChild(this.m_root, "UpButton");
			this.m_goBtnDown = Utility.FindChild(this.m_root, "DownButton");
			this.m_goChatParent = Utility.FindChild(this.m_root, "Viewport/Content");
			this.m_goChatPrefab = Utility.FindChild(this.m_goChatParent, "ChatPrefab");
			this.m_goChatPrefab.CustomActive(false);
			this.m_kFastVerticalLayout = this.m_goChatParent.GetComponent<FastVerticalLayout>();
			this.m_goBtnDown.CustomActive(false);
			this.m_newMailNotice = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/NewMailNotice", true);
			this.m_ActivityNotice = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/ActivityNotice", true);
			this.m_TeamInvite = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/TeamInvite", true);
			this.m_TeamDuplicationRequest = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/TeamDuplicationRequest", true);
			this.m_TeamDuplicationTeamInvite = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/TeamDuplicationTeamInvite", true);
			this.m_RoomInvite = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/RoomInvite", true);
			this.m_SkillLvUp = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/SkillLvUpNotice", true);
			this.m_FriendRequest = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/FriendRequest", true);
			this.m_GuildInvite = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/GuildRequest", true);
			this.m_LimitTimeGift = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/NewMallGiftNotice", true);
			this.m_ItemTimeLess = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/ItemTimeLess", true);
			this.m_PrivateOrdering = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/PrivateOrdering", true);
			this.m_FinancialPlan = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/FinancialPlan", true);
			this.mGuildMerge = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/GuildMerge", true);
			this.m_AuctionFreezeRemind = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/AuctionFreezeRemind", true);
			this.m_CrossPK3V3 = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/CrossPK3V3", true);
			this.m_CrossPK3v3RoomInvite = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/CrossPK3v3RoomInvite", true);
			this.m_SecurityLockApplyState = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/SecurityLockApplyState", true);
			this.m_newMailNoticeButton = this.m_newMailNotice.GetCom<Button>("NoticeButton");
			this.m_newMailNoticeButton.onClick.AddListener(new UnityAction(this.OnClickNewMailNotice));
			this.m_newMailItemTip = this.m_newMailNotice.GetCom<Image>("ItemTip");
			this.m_ActivityNoticeButton = this.m_ActivityNotice.GetCom<Button>("NoticeButton");
			this.m_ActivityNoticeButton.onClick.AddListener(new UnityAction(this.OnClickActivityNoticeButton));
			this.m_ActivityNoticeText = this.m_ActivityNotice.GetCom<Text>("RedPointText");
			this.m_TeamInviteButton = this.m_TeamInvite.GetCom<Button>("NoticeButton");
			this.m_TeamInviteButton.onClick.AddListener(new UnityAction(this.OnClickTeamInviteButton));
			this.m_TeamInviteText = this.m_TeamInvite.GetCom<Text>("RedPointText");
			if (this.m_TeamDuplicationRequest != null)
			{
				this.m_teamDuplicationRequestText = this.m_TeamDuplicationRequest.GetCom<Text>("RedPointText");
				this.m_TeamDuplicationRequestButton = this.m_TeamDuplicationRequest.GetCom<Button>("NoticeButton");
				if (this.m_TeamDuplicationRequestButton != null)
				{
					this.m_TeamDuplicationRequestButton.onClick.AddListener(new UnityAction(this.OnClickTeamDuplicationRequestButton));
				}
			}
			if (this.m_TeamDuplicationTeamInvite != null)
			{
				this.m_TeamDuplicationTeamInviteText = this.m_TeamDuplicationTeamInvite.GetCom<Text>("RedPointText");
				this.m_TeamDuplicationTeamInviteButton = this.m_TeamDuplicationTeamInvite.GetCom<Button>("NoticeButton");
				if (this.m_TeamDuplicationTeamInviteButton != null)
				{
					this.m_TeamDuplicationTeamInviteButton.onClick.AddListener(new UnityAction(this.OnClickTeamDuplicationTeamInviteButton));
				}
			}
			this.m_RoomInviteButton = this.m_RoomInvite.GetCom<Button>("NoticeButton");
			this.m_RoomInviteButton.onClick.AddListener(new UnityAction(this.OnClickRoomInviteButton));
			this.m_RoomInviteText = this.m_RoomInvite.GetCom<Text>("RedPointText");
			this.m_CrossPK3v3RoomInviteButton = this.m_CrossPK3v3RoomInvite.GetCom<Button>("NoticeButton");
			this.m_CrossPK3v3RoomInviteButton.onClick.AddListener(new UnityAction(this.OnCrossPK3v3RoomInviteButton));
			this.m_SkillLvUpButton = this.m_SkillLvUp.GetCom<Button>("NoticeButton");
			this.m_SkillLvUpButton.onClick.AddListener(new UnityAction(this.OnClickSkillLvUpButton));
			this.m_FinancialPlanButton = this.m_FinancialPlan.GetCom<Button>("NoticeButton");
			this.m_FinancialPlanButton.onClick.AddListener(new UnityAction(this.OnClickFinancialPlan));
			this.m_FinancialPlanText = this.m_FinancialPlan.GetCom<Text>("FinancialPlanText");
			this.m_FriendRequestButton = this.m_FriendRequest.GetCom<Button>("NoticeButton");
			this.m_FriendRequestButton.onClick.AddListener(new UnityAction(this.OnClickFriendRequestButton));
			this.m_FriendRequestText = this.m_FriendRequest.GetCom<Text>("RedPointText");
			this.m_GuildInviteButton = this.m_GuildInvite.GetCom<Button>("NoticeButton");
			this.m_GuildInviteButton.onClick.AddListener(new UnityAction(this.OnClickGuildInviteButton));
			this.m_GuildInviteText = this.m_GuildInvite.GetCom<Text>("RedPointText");
			this.m_LimitTimeGiftButton = this.m_LimitTimeGift.GetCom<Button>("NoticeButton");
			this.m_LimitTimeGiftButton.onClick.AddListener(new UnityAction(this.OnClickLimitTimeGiftButton));
			this.m_LimitTimeGiftText = this.m_LimitTimeGift.GetCom<Text>("RedPointText");
			this.m_ItemTimeLessButton = this.m_ItemTimeLess.GetCom<Button>("NoticeButton");
			this.m_ItemTimeLessButton.onClick.AddListener(new UnityAction(this.OnClickItemTimeLessButton));
			this.m_PrivateOrderingButton = this.m_PrivateOrdering.GetCom<Button>("NoticeButton");
			this.m_PrivateOrderingButton.onClick.AddListener(new UnityAction(this.OnClickPrivateOrderingButton));
			this.m_PrivateOrderingDes = this.m_PrivateOrdering.GetCom<Text>("Des");
			this.m_AuctionFreezeRemindButton = this.m_AuctionFreezeRemind.GetCom<Button>("NoticeButton");
			this.m_AuctionFreezeRemindButton.onClick.AddListener(new UnityAction(this.OnAuctinFreezeRemindClick));
			this.m_CrossPk3V3Button = this.m_CrossPK3V3.GetCom<Button>("NoticeButton");
			this.m_CrossPk3V3Button.onClick.AddListener(new UnityAction(this.OpenJoinPK3V3CrossFrame));
			this.m_SecurityLockApplyStateButton = this.m_SecurityLockApplyState.GetCom<Button>("NoticeButton");
			this.m_SecurityLockApplyStateButton.onClick.AddListener(new UnityAction(this.OpenSettingFrameWithApplyState));
			this.mGuildMergeBtn = this.mGuildMerge.GetCom<Button>("NoticeButton");
			this.mGuildMergeBtn.onClick.AddListener(new UnityAction(this.OnGuildMergeAskBtnClick));
			this.m_btnChat = Utility.FindComponent<Button>(this.m_root, "BtnChat", true);
			this.m_btnChat.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this.m_MasterDisciple = Utility.FindComponent<ComCommonBind>(this.m_root, "Vertical/NoticeRoot/MasterDisciple", true);
			this.m_MasterDiscipleButton = this.m_MasterDisciple.GetCom<Button>("MasterDiscipleButton");
			this.m_MasterDiscipleButton.onClick.AddListener(new UnityAction(this.OnMasterDiscipleBtnClick));
			this.m_btnSetting = Utility.FindComponent<Button>(this.m_root, "SettingButton", true);
			this.m_btnSetting.onClick.AddListener(delegate()
			{
				TalkTabFrame.Open();
			});
			this.extraParam = this.m_root.GetComponent<ComTalkExtraParam>();
			if (this.extraParam)
			{
				this.fOffset = this.extraParam.upOffsetHeight;
				this.fOffset2 = this.extraParam.normalHeight;
			}
			this.m_btnUp = Utility.FindComponent<Button>(this.m_root, "UpButton", true);
			this.m_btnUp.onClick.AddListener(delegate()
			{
				this.m_goBtnUp.CustomActive(false);
				this.m_goBtnDown.CustomActive(true);
				RectTransform rectTransform = this.m_root.transform as RectTransform;
				rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, this.fOffset);
				rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0f);
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0f);
				rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x, 0f, rectTransform.anchoredPosition3D.z);
			});
			this.m_btnDown = Utility.FindComponent<Button>(this.m_root, "DownButton", true);
			this.m_btnDown.onClick.AddListener(delegate()
			{
				this.m_goBtnUp.CustomActive(true);
				this.m_goBtnDown.CustomActive(false);
				RectTransform rectTransform = this.m_root.transform as RectTransform;
				rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, this.fOffset2);
				rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, 0f);
				rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, 0f);
				rectTransform.anchoredPosition3D = new Vector3(rectTransform.anchoredPosition3D.x, 0f, rectTransform.anchoredPosition3D.z);
			});
			this.InitVoiceChat();
			this.InitChat();
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddGlobalChatData = (ChatManager.OnAddGlobalChatData)Delegate.Combine(instance.onAddGlobalChatData, new ChatManager.OnAddGlobalChatData(this.OnAddChat));
			ChatManager instance2 = DataManager<ChatManager>.GetInstance();
			instance2.onRebuildGlobalChatData = (ChatManager.OnRebuildGlobalChatData)Delegate.Combine(instance2.onRebuildGlobalChatData, new ChatManager.OnRebuildGlobalChatData(this.OnRebuildChatData));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance3.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance4 = DataManager<ItemDataManager>.GetInstance();
			instance4.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance4.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance5 = DataManager<ItemDataManager>.GetInstance();
			instance5.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance5.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			this.BindUIEvent();
			this.UpdateNewMailNotice();
			this.UpdateActivityNotice();
			this.UpdateNewTeamInviteNotice();
			this.UpdateTeamDuplicationRequest();
			this.UpdateTeamDuplicationNewTeamInvite();
			this.UpdateNewRoomInviteNotice();
			this.UpdateNewRoomInviteNoticePk3v3Cross();
			this.UpdateSkillLvUpNotice();
			this.UpdateFriendRequestNotice();
			this.UpdateItemTimeLess();
			this.InitFinancialPlan();
			this.OnPK3V3CrossButtonIsShow(new UIEvent
			{
				Param1 = (byte)DataManager<Pk3v3CrossDataManager>.GetInstance().Get3v3CrossWarStatus()
			});
			this.OnSecurityLockApplyStateButtonIsShow(null);
			this.UpdateMasterDiscipleNotice(null);
		}

		// Token: 0x060096E2 RID: 38626 RVA: 0x001CCC37 File Offset: 0x001CB037
		private void Start()
		{
		}

		// Token: 0x060096E3 RID: 38627 RVA: 0x001CCC3C File Offset: 0x001CB03C
		private void OnDestroy()
		{
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddGlobalChatData = (ChatManager.OnAddGlobalChatData)Delegate.Remove(instance.onAddGlobalChatData, new ChatManager.OnAddGlobalChatData(this.OnAddChat));
			ChatManager instance2 = DataManager<ChatManager>.GetInstance();
			instance2.onRebuildGlobalChatData = (ChatManager.OnRebuildGlobalChatData)Delegate.Remove(instance2.onRebuildGlobalChatData, new ChatManager.OnRebuildGlobalChatData(this.OnRebuildChatData));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance3.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance4 = DataManager<ItemDataManager>.GetInstance();
			instance4.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance4.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance5 = DataManager<ItemDataManager>.GetInstance();
			instance5.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance5.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			if (this.m_btnDown != null)
			{
				this.m_btnDown.onClick.RemoveAllListeners();
				this.m_btnDown = null;
			}
			if (this.m_btnUp != null)
			{
				this.m_btnUp.onClick.RemoveAllListeners();
				this.m_btnUp = null;
			}
			if (this.m_btnChat != null)
			{
				this.m_btnChat.onClick.RemoveAllListeners();
				this.m_btnChat = null;
			}
			if (this.m_btnSetting != null)
			{
				this.m_btnSetting.onClick.RemoveAllListeners();
				this.m_btnSetting = null;
			}
			if (this.m_newMailNoticeButton != null)
			{
				this.m_newMailNoticeButton.onClick.RemoveListener(new UnityAction(this.OnClickNewMailNotice));
			}
			if (this.m_ActivityNoticeButton != null)
			{
				this.m_ActivityNoticeButton.onClick.RemoveListener(new UnityAction(this.OnClickActivityNoticeButton));
			}
			if (this.m_TeamInviteButton != null)
			{
				this.m_TeamInviteButton.onClick.RemoveListener(new UnityAction(this.OnClickTeamInviteButton));
			}
			if (this.m_TeamDuplicationRequestButton != null)
			{
				this.m_TeamDuplicationRequestButton.onClick.RemoveListener(new UnityAction(this.OnClickTeamDuplicationRequestButton));
			}
			if (this.m_TeamDuplicationTeamInviteButton != null)
			{
				this.m_TeamDuplicationTeamInviteButton.onClick.RemoveListener(new UnityAction(this.OnClickTeamDuplicationTeamInviteButton));
			}
			if (this.m_RoomInviteButton != null)
			{
				this.m_RoomInviteButton.onClick.RemoveListener(new UnityAction(this.OnClickRoomInviteButton));
			}
			if (this.m_CrossPK3v3RoomInviteButton != null)
			{
				this.m_CrossPK3v3RoomInviteButton.onClick.RemoveListener(new UnityAction(this.OnCrossPK3v3RoomInviteButton));
			}
			if (this.m_SkillLvUpButton != null)
			{
				this.m_SkillLvUpButton.onClick.RemoveListener(new UnityAction(this.OnClickSkillLvUpButton));
			}
			if (this.m_FriendRequestButton != null)
			{
				this.m_FriendRequestButton.onClick.RemoveListener(new UnityAction(this.OnClickFriendRequestButton));
			}
			if (this.m_GuildInviteButton != null)
			{
				this.m_GuildInviteButton.onClick.RemoveListener(new UnityAction(this.OnClickGuildInviteButton));
			}
			if (this.m_ItemTimeLessButton != null)
			{
				this.m_ItemTimeLessButton.onClick.RemoveListener(new UnityAction(this.OnClickItemTimeLessButton));
			}
			if (this.m_PrivateOrderingButton != null)
			{
				this.m_PrivateOrderingButton.onClick.RemoveListener(new UnityAction(this.OnClickPrivateOrderingButton));
			}
			if (this.m_AuctionFreezeRemindButton != null)
			{
				this.m_AuctionFreezeRemindButton.onClick.RemoveListener(new UnityAction(this.OnAuctinFreezeRemindClick));
			}
			if (this.m_FinancialPlanButton != null)
			{
				this.m_FinancialPlanButton.onClick.RemoveAllListeners();
			}
			if (this.m_CrossPk3V3Button != null)
			{
				this.m_CrossPk3V3Button.onClick.RemoveListener(new UnityAction(this.OpenJoinPK3V3CrossFrame));
			}
			if (this.m_SecurityLockApplyStateButton != null)
			{
				this.m_SecurityLockApplyStateButton.onClick.RemoveListener(new UnityAction(this.OpenSettingFrameWithApplyState));
			}
			if (this.mGuildMergeBtn != null)
			{
				this.mGuildMergeBtn.onClick.RemoveListener(new UnityAction(this.OnGuildMergeAskBtnClick));
			}
			if (this.m_MasterDiscipleButton != null)
			{
				this.m_MasterDiscipleButton.onClick.RemoveListener(new UnityAction(this.OnMasterDiscipleBtnClick));
			}
			this.UnBindUIEvent();
			this.UninitVoiceChatModule();
			this.m_akChatObjects.DestroyAllObjects();
			if (null != this.voiceSettingBtn)
			{
				this.voiceSettingBtn.gameObject.CustomActive(false);
				this.voiceSettingBtn = null;
			}
			if (ComTalk.ms_comTalk == this)
			{
				ComTalk.ms_comTalk = null;
			}
			this.NeedReshowEffectFuncs.Clear();
		}

		// Token: 0x060096E4 RID: 38628 RVA: 0x001CD126 File Offset: 0x001CB526
		public GameObject GetTeamInvitedBtn()
		{
			if (this.m_TeamInvite == null)
			{
				return null;
			}
			return this.m_TeamInvite.gameObject;
		}

		// Token: 0x060096E5 RID: 38629 RVA: 0x001CD148 File Offset: 0x001CB548
		private void InitChat()
		{
			this.m_akChatObjects.RecycleAllObject();
			List<ChatBlock> list = new List<ChatBlock>();
			list.AddRange(DataManager<ChatManager>.GetInstance().GlobalChatBlock);
			list.Sort((ChatBlock x, ChatBlock y) => x.iOrder - y.iOrder);
			for (int i = 0; i < list.Count; i++)
			{
				this.OnAddChat(list[i]);
			}
		}

		// Token: 0x060096E6 RID: 38630 RVA: 0x001CD1BD File Offset: 0x001CB5BD
		public GameObject GetRoot()
		{
			return this.m_root;
		}

		// Token: 0x060096E7 RID: 38631 RVA: 0x001CD1C8 File Offset: 0x001CB5C8
		public void OnAddChat(ChatBlock chatBlock)
		{
			if (chatBlock == null || chatBlock.chatData == null)
			{
				return;
			}
			if (chatBlock.chatData.eChatType == ChatType.CT_PRIVATE)
			{
				return;
			}
			GameObject goChatParent = this.m_goChatParent;
			GameObject goChatPrefab = this.m_goChatPrefab;
			ChatData chatData = chatBlock.chatData;
			if (this.m_akChatObjects.HasObject(chatData.guid))
			{
				return;
			}
			if (this.m_akChatObjects.Create(chatData.guid, new object[]
			{
				this.m_goChatParent,
				this.m_goChatPrefab,
				chatBlock,
				this
			}) == null)
			{
				return;
			}
			this.m_akChatObjects.FilterObject(chatData.guid, new object[]
			{
				DataManager<SystemConfigManager>.GetInstance().ChatFilters
			});
			if (this.m_kFastVerticalLayout != null)
			{
				this.m_kFastVerticalLayout.MarkDirty();
			}
		}

		// Token: 0x060096E8 RID: 38632 RVA: 0x001CD29E File Offset: 0x001CB69E
		public void OnChatFilterChanged(List<bool> chatFilters)
		{
			this.m_akChatObjects.Filter(new object[]
			{
				DataManager<SystemConfigManager>.GetInstance().ChatFilters
			});
		}

		// Token: 0x060096E9 RID: 38633 RVA: 0x001CD2BE File Offset: 0x001CB6BE
		private void _OnAddNewItem(List<Item> items)
		{
			this.UpdateItemTimeLess();
		}

		// Token: 0x060096EA RID: 38634 RVA: 0x001CD2C6 File Offset: 0x001CB6C6
		private void _OnUpdateItem(List<Item> items)
		{
			this.UpdateItemTimeLess();
		}

		// Token: 0x060096EB RID: 38635 RVA: 0x001CD2CE File Offset: 0x001CB6CE
		private void _OnRemoveItem(ItemData data)
		{
			this.UpdateItemTimeLess();
		}

		// Token: 0x060096EC RID: 38636 RVA: 0x001CD2D8 File Offset: 0x001CB6D8
		public void OnRebuildChatData(ulong preGuid, ChatBlock chatBlock)
		{
			ChatData chatData = chatBlock.chatData;
			if (this.m_akChatObjects.HasObject(chatData.guid))
			{
				return;
			}
			if (this.m_akChatObjects.RebuildOrCreate((int)preGuid, chatData.guid, new object[]
			{
				this.m_goChatParent,
				this.m_goChatPrefab,
				chatBlock,
				this
			}) == null)
			{
				return;
			}
			this.m_akChatObjects.FilterObject(chatData.guid, new object[]
			{
				DataManager<SystemConfigManager>.GetInstance().ChatFilters
			});
			if (this.m_kFastVerticalLayout != null)
			{
				this.m_kFastVerticalLayout.MarkDirty();
			}
		}

		// Token: 0x060096ED RID: 38637 RVA: 0x001CD380 File Offset: 0x001CB780
		private void DelayUpdatePosition()
		{
			ScrollRect component = this.m_root.GetComponent<ScrollRect>();
			component.verticalNormalizedPosition = 0f;
		}

		// Token: 0x060096EE RID: 38638 RVA: 0x001CD3A4 File Offset: 0x001CB7A4
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnNewMailNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TeamNewInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnTeamNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationRequestUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationNewTeamInviteUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnRoomNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SkillLvUpNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnSkillLvUpNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FriendRequestNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnFriendRequestNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnGuildInviteNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.OnPrivateOrderingNoticeUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.MiddleFrameClose, new ClientEventSystem.UIEventHandler(this._OnMiddleFrameClose));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanBuyRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateByLevel, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateByLogin, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdateByLogin));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateBySceneChanged, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanButtonUpdateBySceneChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.HasLimitTimeGiftToBuy, new ClientEventSystem.UIEventHandler(this.OnNewLimitTimeGift));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DeadLineReminderChanged, new ClientEventSystem.UIEventHandler(this._OnTimeLessItemsChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatTeamJoin, new ClientEventSystem.UIEventHandler(this.CheckInTeam));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatTeamLeave, new ClientEventSystem.UIEventHandler(this.CheckInTeam));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatGuildJoin, new ClientEventSystem.UIEventHandler(this.CheckInGuild));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatGuildLeave, new ClientEventSystem.UIEventHandler(this.CheckInGuild));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatComtalkBtnPressed, new ClientEventSystem.UIEventHandler(this.ChangeThisScrollRectActive));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AuctionFreezeRemind, new ClientEventSystem.UIEventHandler(this._OnAuctionFreezeRemind));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.OnPK3V3CrossButtonIsShow));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SecurityLockApplyStateButton, new ClientEventSystem.UIEventHandler(this.OnSecurityLockApplyStateButtonIsShow));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildReceiveMergerd, new ClientEventSystem.UIEventHandler(this.OnGuildReceiveMergerRequest));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefuseAllReceive, new ClientEventSystem.UIEventHandler(this.OnRefuseAllReciveRequest));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdateMissionListBtn, new ClientEventSystem.UIEventHandler(this.UpdateMasterDiscipleNotice));
		}

		// Token: 0x060096EF RID: 38639 RVA: 0x001CD6C0 File Offset: 0x001CBAC0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this.OnNewMailNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TeamNewInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnTeamNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationRequestUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewTeamInviteMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationNewTeamInviteUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3InviteRoomListUpdate, new ClientEventSystem.UIEventHandler(this.OnRoomNewInviteNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SkillLvUpNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnSkillLvUpNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FriendRequestNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnFriendRequestNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInviteNoticeUpdate, new ClientEventSystem.UIEventHandler(this.OnGuildInviteNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoodsRecommend, new ClientEventSystem.UIEventHandler(this.OnPrivateOrderingNoticeUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.MiddleFrameClose, new ClientEventSystem.UIEventHandler(this._OnMiddleFrameClose));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanBuyRes, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateByLevel, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateByLogin, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanUpdateByLogin));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FinancialPlanButtonUpdateBySceneChanged, new ClientEventSystem.UIEventHandler(this.OnFinancialPlanButtonUpdateBySceneChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.HasLimitTimeGiftToBuy, new ClientEventSystem.UIEventHandler(this.OnNewLimitTimeGift));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DeadLineReminderChanged, new ClientEventSystem.UIEventHandler(this._OnTimeLessItemsChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatTeamJoin, new ClientEventSystem.UIEventHandler(this.CheckInTeam));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatTeamLeave, new ClientEventSystem.UIEventHandler(this.CheckInTeam));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatGuildJoin, new ClientEventSystem.UIEventHandler(this.CheckInGuild));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatGuildLeave, new ClientEventSystem.UIEventHandler(this.CheckInGuild));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatComtalkBtnPressed, new ClientEventSystem.UIEventHandler(this.ChangeThisScrollRectActive));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AuctionFreezeRemind, new ClientEventSystem.UIEventHandler(this._OnAuctionFreezeRemind));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3CrossButton, new ClientEventSystem.UIEventHandler(this.OnPK3V3CrossButtonIsShow));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SecurityLockApplyStateButton, new ClientEventSystem.UIEventHandler(this.OnSecurityLockApplyStateButtonIsShow));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildReceiveMergerd, new ClientEventSystem.UIEventHandler(this.OnGuildReceiveMergerRequest));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefuseAllReceive, new ClientEventSystem.UIEventHandler(this.OnRefuseAllReciveRequest));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdateMissionListBtn, new ClientEventSystem.UIEventHandler(this.UpdateMasterDiscipleNotice));
		}

		// Token: 0x060096F0 RID: 38640 RVA: 0x001CD9DC File Offset: 0x001CBDDC
		private void OnNewMailNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateNewMailNotice();
		}

		// Token: 0x060096F1 RID: 38641 RVA: 0x001CD9E4 File Offset: 0x001CBDE4
		private void OnActivityNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateActivityNotice();
		}

		// Token: 0x060096F2 RID: 38642 RVA: 0x001CD9EC File Offset: 0x001CBDEC
		private void OnTeamNewInviteNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateNewTeamInviteNotice();
		}

		// Token: 0x060096F3 RID: 38643 RVA: 0x001CD9F4 File Offset: 0x001CBDF4
		private void OnTeamDuplicationRequestUpdate(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationRequest();
		}

		// Token: 0x060096F4 RID: 38644 RVA: 0x001CD9FC File Offset: 0x001CBDFC
		private void OnTeamDuplicationNewTeamInviteUpdate(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationNewTeamInvite();
		}

		// Token: 0x060096F5 RID: 38645 RVA: 0x001CDA04 File Offset: 0x001CBE04
		private void OnRoomNewInviteNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateNewRoomInviteNotice();
		}

		// Token: 0x060096F6 RID: 38646 RVA: 0x001CDA0C File Offset: 0x001CBE0C
		private void OnSkillLvUpNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateSkillLvUpNotice();
		}

		// Token: 0x060096F7 RID: 38647 RVA: 0x001CDA14 File Offset: 0x001CBE14
		private void OnFriendRequestNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateFriendRequestNotice();
		}

		// Token: 0x060096F8 RID: 38648 RVA: 0x001CDA1C File Offset: 0x001CBE1C
		private void OnGuildInviteNoticeUpdate(UIEvent iEvent)
		{
			this.UpdateNewTeamInviteNotice();
		}

		// Token: 0x060096F9 RID: 38649 RVA: 0x001CDA24 File Offset: 0x001CBE24
		private void OnPrivateOrderingNoticeUpdate(UIEvent iEvent)
		{
		}

		// Token: 0x060096FA RID: 38650 RVA: 0x001CDA28 File Offset: 0x001CBE28
		private void _OnMiddleFrameClose(UIEvent iEvent)
		{
			for (int i = 0; i < this.NeedReshowEffectFuncs.Count; i++)
			{
				ComCommonBind comCommonBind = this.NeedReshowEffectFuncs[i];
				if (comCommonBind != null)
				{
					comCommonBind.CustomActive(true);
				}
			}
			this.NeedReshowEffectFuncs.Clear();
		}

		// Token: 0x060096FB RID: 38651 RVA: 0x001CDA7C File Offset: 0x001CBE7C
		private bool _IsMiddleFrameOpen()
		{
			DictionaryView<string, IClientFrame> allFrames = Singleton<ClientSystemManager>.GetInstance().GetAllFrames();
			foreach (KeyValuePair<string, IClientFrame> keyValuePair in allFrames)
			{
				IClientFrame value = keyValuePair.Value;
				if (value != null)
				{
					if (value.GetLayer() == FrameLayer.Middle && value.GetFrameType() == eFrameType.FullScreen)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060096FC RID: 38652 RVA: 0x001CDAE4 File Offset: 0x001CBEE4
		private void _AddReshowEffectFuncs(ComCommonBind combind)
		{
			ComCommonBind comCommonBind = this.NeedReshowEffectFuncs.Find((ComCommonBind value) => value == combind);
			if (comCommonBind == null && combind != null)
			{
				this.NeedReshowEffectFuncs.Add(combind);
			}
		}

		// Token: 0x060096FD RID: 38653 RVA: 0x001CDB44 File Offset: 0x001CBF44
		private void UpdateNewMailNotice()
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_newMailNoticeButton.gameObject.SetActive(false);
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				this.m_newMailNoticeButton.gameObject.SetActive(false);
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.FairDuelPrepare)
			{
				this.m_newMailNoticeButton.gameObject.SetActive(false);
				return;
			}
			if (MailDataManager.UnReadMailNum > 0 || MailDataManager.OneKeyReceiveNum > 0)
			{
				if (DataManager<MailDataManager>.GetInstance().mRewardMailTitleInfoList.Count > 0 || DataManager<MailDataManager>.GetInstance().mGuildMailTitleInfoList.Count > 0 || DataManager<MailDataManager>.GetInstance().mAnnouncementMailTitleInfoList.Count > 0)
				{
					if (this._IsMiddleFrameOpen() && !this.m_newMailNotice.gameObject.activeSelf)
					{
						this._AddReshowEffectFuncs(this.m_newMailNotice);
						return;
					}
					this.m_newMailItemTip.gameObject.SetActive(true);
				}
				else
				{
					this.m_newMailItemTip.gameObject.SetActive(false);
				}
				if (this.m_newMailNoticeButton.gameObject.activeSelf)
				{
					return;
				}
				if (this._IsMiddleFrameOpen() && !this.m_newMailNotice.gameObject.activeSelf)
				{
					this._AddReshowEffectFuncs(this.m_newMailNotice);
					return;
				}
				this.m_newMailNoticeButton.gameObject.SetActive(true);
			}
			else
			{
				this.m_newMailNoticeButton.gameObject.SetActive(false);
			}
		}

		// Token: 0x060096FE RID: 38654 RVA: 0x001CDD20 File Offset: 0x001CC120
		private void UpdateActivityNotice()
		{
		}

		// Token: 0x060096FF RID: 38655 RVA: 0x001CDD30 File Offset: 0x001CC130
		private void UpdateNewTeamInviteNotice()
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_TeamInviteButton.gameObject.SetActive(false);
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				this.m_TeamInviteButton.gameObject.SetActive(false);
				return;
			}
			List<NewTeamInviteList> inviteTeamList = DataManager<TeamDataManager>.GetInstance().GetInviteTeamList();
			List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
			if (inviteTeamList.Count > 0 || guildInviteList.Count > 0)
			{
				this.m_TeamInviteText.text = (inviteTeamList.Count + guildInviteList.Count).ToString();
				if (this._IsMiddleFrameOpen() && !this.m_TeamInvite.gameObject.activeSelf)
				{
					this._AddReshowEffectFuncs(this.m_TeamInvite);
				}
				else
				{
					this.m_TeamInviteButton.gameObject.SetActive(true);
				}
			}
			else
			{
				this.m_TeamInviteButton.gameObject.SetActive(false);
			}
		}

		// Token: 0x06009700 RID: 38656 RVA: 0x001CDE88 File Offset: 0x001CC288
		private void UpdateTeamDuplicationRequest()
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
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationBuid && tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationRequestButton, false);
				return;
			}
			if (TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() && TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication() && DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewRequester)
			{
				if (this.m_TeamDuplicationRequest != null)
				{
					if (this._IsMiddleFrameOpen() && !this.m_TeamDuplicationRequest.gameObject.activeSelf)
					{
						this._AddReshowEffectFuncs(this.m_TeamDuplicationRequest);
					}
					else
					{
						CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationRequestButton, true);
					}
				}
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationRequestButton, false);
			}
		}

		// Token: 0x06009701 RID: 38657 RVA: 0x001CDF78 File Offset: 0x001CC378
		private void UpdateTeamDuplicationNewTeamInvite()
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
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationBuid && tableItem.SceneSubType != CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationTeamInviteButton, false);
				return;
			}
			if (TeamDuplicationUtility.IsTeamDuplicationOwnerTeam())
			{
				CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationTeamInviteButton, false);
			}
			else if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewInvite)
			{
				CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationTeamInviteButton, false);
			}
			else if (this.m_TeamDuplicationTeamInvite != null)
			{
				if (this._IsMiddleFrameOpen() && !this.m_TeamDuplicationTeamInvite.gameObject.activeSelf)
				{
					this._AddReshowEffectFuncs(this.m_TeamDuplicationTeamInvite);
				}
				else
				{
					CommonUtility.UpdateButtonVisible(this.m_TeamDuplicationTeamInviteButton, true);
				}
			}
		}

		// Token: 0x06009702 RID: 38658 RVA: 0x001CE070 File Offset: 0x001CC470
		private void UpdateNewRoomInviteNoticePk3v3Cross()
		{
		}

		// Token: 0x06009703 RID: 38659 RVA: 0x001CE080 File Offset: 0x001CC480
		private bool HideButtonIn3v3Cross(Button button)
		{
			if (button == null)
			{
				return false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				button.gameObject.SetActive(false);
				return true;
			}
			return false;
		}

		// Token: 0x06009704 RID: 38660 RVA: 0x001CE118 File Offset: 0x001CC518
		private void UpdateNewRoomInviteNotice()
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
			if (tableItem.SceneSubType != CitySceneTable.eSceneSubType.TRADITION)
			{
				this.m_RoomInviteButton.gameObject.SetActive(false);
				return;
			}
			List<WorldSyncRoomInviteInfo> inviteRoomList = DataManager<Pk3v3DataManager>.GetInstance().GetInviteRoomList();
			List<WorldSyncRoomInviteInfo> inviteRoomList2 = DataManager<Pk3v3CrossDataManager>.GetInstance().GetInviteRoomList();
			List<SceneSyncRequest> friendsPlayInviteList = DataManager<RelationDataManager>.GetInstance().FriendsPlayInviteList;
			if (inviteRoomList.Count > 0 || inviteRoomList2.Count > 0 || friendsPlayInviteList.Count > 0)
			{
				this.m_RoomInviteText.text = (inviteRoomList.Count + inviteRoomList2.Count + friendsPlayInviteList.Count).ToString();
				if (this._IsMiddleFrameOpen() && !this.m_RoomInvite.gameObject.activeSelf)
				{
					this._AddReshowEffectFuncs(this.m_RoomInvite);
				}
				else
				{
					this.m_RoomInviteButton.gameObject.SetActive(true);
				}
			}
			else
			{
				this.m_RoomInviteButton.gameObject.SetActive(false);
			}
		}

		// Token: 0x06009705 RID: 38661 RVA: 0x001CE24A File Offset: 0x001CC64A
		private void OnFinancialPlanButtonUpdateBySceneChanged(UIEvent uiEvent)
		{
			this.UpdateFinancialPlanButtonState();
		}

		// Token: 0x06009706 RID: 38662 RVA: 0x001CE254 File Offset: 0x001CC654
		private void UpdateFinancialPlanButtonState()
		{
		}

		// Token: 0x06009707 RID: 38663 RVA: 0x001CE261 File Offset: 0x001CC661
		private void OnFinancialPlanUpdateByLogin(UIEvent uiEvent)
		{
			this.UpdateFinancialPlanByLogin();
		}

		// Token: 0x06009708 RID: 38664 RVA: 0x001CE26C File Offset: 0x001CC66C
		private void UpdateFinancialPlanByLogin()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (!DataManager<FinancialPlanDataManager>.GetInstance().IsShowFinancialPlanButton())
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(false);
				return;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_FinancialPlanButton.gameObject.SetActive(false);
				return;
			}
			if (DataManager<FinancialPlanDataManager>.GetInstance().IsPlayerAlreadyShowOnceFinancialPlanInLogin())
			{
				this.m_FinancialPlanButton.CustomActive(false);
				DataManager<FinancialPlanDataManager>.GetInstance().SetFinancialPlanButtonState(FinancialPlanButtonState.IsNotShowing);
				return;
			}
			if (this._IsMiddleFrameOpen() && !this.m_FinancialPlan.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_FinancialPlan);
			}
			else
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(true);
				DataManager<FinancialPlanDataManager>.GetInstance().SetFinancialPlanButtonState(FinancialPlanButtonState.IsShowing);
			}
			this.m_FinancialPlanText.text = TR.Value("financial_plan_text");
			DataManager<FinancialPlanDataManager>.GetInstance().SetPlayerAlreadyShowFinancialPlanInLogin();
		}

		// Token: 0x06009709 RID: 38665 RVA: 0x001CE3AC File Offset: 0x001CC7AC
		private void InitFinancialPlan()
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_FinancialPlanButton.gameObject.SetActive(false);
				return;
			}
			if (!DataManager<FinancialPlanDataManager>.GetInstance().IsShowFinancialPlanButton())
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(false);
				return;
			}
			if (this._IsMiddleFrameOpen() && !this.m_FinancialPlan.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_FinancialPlan);
			}
			else if (DataManager<FinancialPlanDataManager>.GetInstance().GetFinancialPlanButtonShowState() == FinancialPlanButtonState.IsShowing || DataManager<FinancialPlanDataManager>.GetInstance().GetFinancialPlanButtonShowState() == FinancialPlanButtonState.Invalid)
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(true);
				DataManager<FinancialPlanDataManager>.GetInstance().SetFinancialPlanButtonState(FinancialPlanButtonState.IsShowing);
			}
			this.m_FinancialPlanText.text = TR.Value("financial_plan_text");
		}

		// Token: 0x0600970A RID: 38666 RVA: 0x001CE4D9 File Offset: 0x001CC8D9
		private void OnFinancialPlanUpdate(UIEvent uiEvent)
		{
			this.UpdateFinancialPlan();
		}

		// Token: 0x0600970B RID: 38667 RVA: 0x001CE4E4 File Offset: 0x001CC8E4
		private void UpdateFinancialPlan()
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_FinancialPlanButton.gameObject.SetActive(false);
				return;
			}
			if (!DataManager<FinancialPlanDataManager>.GetInstance().IsShowFinancialPlanButton())
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(false);
				return;
			}
			if (this._IsMiddleFrameOpen() && !this.m_FinancialPlan.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_FinancialPlan);
			}
			else
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(true);
				DataManager<FinancialPlanDataManager>.GetInstance().SetFinancialPlanButtonState(FinancialPlanButtonState.IsShowing);
			}
			this.m_FinancialPlanText.text = TR.Value("financial_plan_text");
		}

		// Token: 0x0600970C RID: 38668 RVA: 0x001CE5F4 File Offset: 0x001CC9F4
		private void UpdateSkillLvUpNotice()
		{
		}

		// Token: 0x0600970D RID: 38669 RVA: 0x001CE604 File Offset: 0x001CCA04
		private void UpdateFriendRequestNotice()
		{
		}

		// Token: 0x0600970E RID: 38670 RVA: 0x001CE614 File Offset: 0x001CCA14
		private void UpdateGuildInviteNotice()
		{
			if (!(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown))
			{
				return;
			}
			if (this.HideButtonIn3v3Cross(this.m_GuildInviteButton))
			{
				return;
			}
			List<WorldGuildInviteNotify> guildInviteList = DataManager<GuildDataManager>.GetInstance().GuildInviteList;
			if (guildInviteList.Count > 0)
			{
				this.m_GuildInviteText.text = guildInviteList.Count.ToString();
				this.m_GuildInviteButton.gameObject.SetActive(true);
			}
			else
			{
				this.m_GuildInviteButton.gameObject.SetActive(false);
			}
		}

		// Token: 0x0600970F RID: 38671 RVA: 0x001CE6A8 File Offset: 0x001CCAA8
		private void UpdateItemTimeLess()
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_ItemTimeLess.gameObject.SetActive(false);
				return;
			}
			if (DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadLineReminderModelList().Count > 0 && this._IsMiddleFrameOpen() && !this.m_ItemTimeLess.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_ItemTimeLess);
				return;
			}
			this.m_ItemTimeLess.gameObject.SetActive(DataManager<DeadLineReminderDataManager>.GetInstance().GetDeadLineReminderModelList().Count > 0);
		}

		// Token: 0x06009710 RID: 38672 RVA: 0x001CE798 File Offset: 0x001CCB98
		private void UpdateMasterDiscipleNotice(UIEvent uiEvent)
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
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossPk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3 || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationBuid || tableItem.SceneSubType == CitySceneTable.eSceneSubType.TeamDuplicationFight)
			{
				this.m_MasterDiscipleButton.CustomActive(false);
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				this.m_MasterDiscipleButton.CustomActive(false);
				return;
			}
			if (tableItem.SceneSubType == CitySceneTable.eSceneSubType.FairDuelPrepare)
			{
				this.m_MasterDiscipleButton.CustomActive(false);
				return;
			}
			List<RelationData> taskFinishedPupils = DataManager<TAPNewDataManager>.GetInstance().TaskFinishedPupils;
			if (taskFinishedPupils == null)
			{
				this.m_MasterDiscipleButton.CustomActive(false);
				return;
			}
			if (taskFinishedPupils.Count > 0 && this._IsMiddleFrameOpen() && !this.m_MasterDisciple.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_MasterDisciple);
				return;
			}
			this.m_MasterDisciple.CustomActive(taskFinishedPupils.Count > 0);
		}

		// Token: 0x06009711 RID: 38673 RVA: 0x001CE8BC File Offset: 0x001CCCBC
		private void OnClickNewMailNotice()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<MailNewFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_NewMailNotice");
		}

		// Token: 0x06009712 RID: 38674 RVA: 0x001CE8DF File Offset: 0x001CCCDF
		private void OnClickActivityNoticeButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<ActivityNoticeListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_ActivityNotice");
		}

		// Token: 0x06009713 RID: 38675 RVA: 0x001CE902 File Offset: 0x001CCD02
		private void OnClickTeamInviteButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<GuildBeInvitedListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_TeamInviteNotice");
		}

		// Token: 0x06009714 RID: 38676 RVA: 0x001CE925 File Offset: 0x001CCD25
		private void OnClickTeamDuplicationRequestButton()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationRequesterListFrame();
		}

		// Token: 0x06009715 RID: 38677 RVA: 0x001CE92C File Offset: 0x001CCD2C
		private void OnClickTeamDuplicationTeamInviteButton()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamInviteListFrame();
		}

		// Token: 0x06009716 RID: 38678 RVA: 0x001CE933 File Offset: 0x001CCD33
		private void OnClickRoomInviteButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamBeInvitedListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_RoomInviteNotice");
		}

		// Token: 0x06009717 RID: 38679 RVA: 0x001CE95B File Offset: 0x001CCD5B
		private void OnCrossPK3v3RoomInviteButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TeamBeInvitedListFrame>(FrameLayer.Middle, InviteType.Pk3v3Invite, "Pk3v3Cross");
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_RoomInvitePk3v3Notice");
		}

		// Token: 0x06009718 RID: 38680 RVA: 0x001CE983 File Offset: 0x001CCD83
		private void OnClickFinancialPlan()
		{
			if (this.m_FinancialPlanButton != null)
			{
				this.m_FinancialPlanButton.gameObject.CustomActive(false);
				DataManager<FinancialPlanDataManager>.GetInstance().SetFinancialPlanButtonState(FinancialPlanButtonState.AlreadyClicked);
			}
			DataManager<FinancialPlanDataManager>.GetInstance().ShowFinancialPlanActivity();
		}

		// Token: 0x06009719 RID: 38681 RVA: 0x001CE9BC File Offset: 0x001CCDBC
		private void OnClickSkillLvUpButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_SkillLvUpNotice");
		}

		// Token: 0x0600971A RID: 38682 RVA: 0x001CE9E0 File Offset: 0x001CCDE0
		private void OnClickFriendRequestButton()
		{
			RelationFrameNew.CommandOpen(new RelationFrameData
			{
				eRelationOptionType = RelationOptionType.ROT_MY_FRIEND
			});
			this.m_FriendRequestButton.gameObject.SetActive(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_FrendRequestNotice");
		}

		// Token: 0x0600971B RID: 38683 RVA: 0x001CEA20 File Offset: 0x001CCE20
		private void OnClickGuildInviteButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<GuildBeInvitedListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_GuildInviteNotice");
		}

		// Token: 0x0600971C RID: 38684 RVA: 0x001CEA43 File Offset: 0x001CCE43
		private void OnClickItemTimeLessButton()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<DeadLineReminderFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_ItemTimeLessNotice");
		}

		// Token: 0x0600971D RID: 38685 RVA: 0x001CEA66 File Offset: 0x001CCE66
		private void OnClickPrivateOrderingButton()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<GoodsRecommendFrame>(FrameLayer.Middle, null, string.Empty);
			this.m_PrivateOrderingButton.gameObject.CustomActive(false);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_PrivateOrderingNotice");
		}

		// Token: 0x0600971E RID: 38686 RVA: 0x001CEA9A File Offset: 0x001CCE9A
		private void OnAuctinFreezeRemindClick()
		{
			DataManager<AuctionDataManager>.GetInstance().SendSceneAbnormalTransactionRecordReq();
		}

		// Token: 0x0600971F RID: 38687 RVA: 0x001CEAA6 File Offset: 0x001CCEA6
		private void OpenJoinPK3V3CrossFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinPK3v3CrossFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06009720 RID: 38688 RVA: 0x001CEABA File Offset: 0x001CCEBA
		private void OpenSettingFrameWithApplyState()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SettingFrame>(FrameLayer.Middle, SettingFrame.TabType.ACCOUNT_LOCK, string.Empty);
			this.m_SecurityLockApplyStateButton.gameObject.CustomActive(false);
			DataManager<SecurityLockDataManager>.GetInstance().BtnClickedCount += 1U;
		}

		// Token: 0x06009721 RID: 38689 RVA: 0x001CEAF8 File Offset: 0x001CCEF8
		private void OnClickLimitTimeGiftButton()
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.m_LimitTimeGiftIsClick = true;
			MallNewFrame mallNewFrame = Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.LimitTimeMall
			}, string.Empty) as MallNewFrame;
			if (this.m_LimitTimeGift)
			{
				this.m_LimitTimeGift.CustomActive(false);
			}
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_LimitTimeNotice");
		}

		// Token: 0x06009722 RID: 38690 RVA: 0x001CEB64 File Offset: 0x001CCF64
		private void OnGuildMergeAskBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMergeAskFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06009723 RID: 38691 RVA: 0x001CEB78 File Offset: 0x001CCF78
		private void OnMasterDiscipleBtnClick()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<TapMissionNoticeListFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<GameStatisticManager>.GetInstance().DoStartUIButton("ComTalk_MasterDiscipleNotice");
		}

		// Token: 0x06009724 RID: 38692 RVA: 0x001CEB9B File Offset: 0x001CCF9B
		private void OnNewLimitTimeGift(UIEvent uiEvent)
		{
			this.UpdateLimitTimeGiftNotice();
		}

		// Token: 0x06009725 RID: 38693 RVA: 0x001CEBA4 File Offset: 0x001CCFA4
		private void UpdateLimitTimeGiftNotice()
		{
		}

		// Token: 0x06009726 RID: 38694 RVA: 0x001CEBB1 File Offset: 0x001CCFB1
		private void OnClickOpenVoiceSettings()
		{
		}

		// Token: 0x06009727 RID: 38695 RVA: 0x001CEBB3 File Offset: 0x001CCFB3
		private void CheckInTeam(UIEvent iEvent)
		{
			this.TrySetVoiceChatBtnsPos();
		}

		// Token: 0x06009728 RID: 38696 RVA: 0x001CEBBB File Offset: 0x001CCFBB
		private void CheckInGuild(UIEvent iEvent)
		{
			this.TrySetVoiceChatBtnsPos();
		}

		// Token: 0x06009729 RID: 38697 RVA: 0x001CEBC4 File Offset: 0x001CCFC4
		private void ChangeThisScrollRectActive(UIEvent uiEvent)
		{
			if (uiEvent != null && uiEvent.Param1 != null)
			{
				bool enabled = (bool)uiEvent.Param1;
				ScrollRect component = this.m_root.GetComponent<ScrollRect>();
				if (component)
				{
					component.enabled = enabled;
				}
			}
		}

		// Token: 0x0600972A RID: 38698 RVA: 0x001CEC0C File Offset: 0x001CD00C
		private void _OnTimeLessItemsChanged(UIEvent a_event)
		{
			this.UpdateItemTimeLess();
		}

		// Token: 0x0600972B RID: 38699 RVA: 0x001CEC14 File Offset: 0x001CD014
		private void _OnAuctionFreezeRemind(UIEvent a_event)
		{
			if (this.HideButtonIn3v3Cross(this.m_AuctionFreezeRemindButton))
			{
				return;
			}
			bool flag = (bool)a_event.Param1;
			if (flag && this._IsMiddleFrameOpen() && !this.m_AuctionFreezeRemind.gameObject.activeSelf)
			{
				this._AddReshowEffectFuncs(this.m_AuctionFreezeRemind);
				return;
			}
			this.m_AuctionFreezeRemindButton.CustomActive(flag);
		}

		// Token: 0x0600972C RID: 38700 RVA: 0x001CEC80 File Offset: 0x001CD080
		private void OnSecurityLockApplyStateButtonIsShow(UIEvent uiEvent)
		{
		}

		// Token: 0x0600972D RID: 38701 RVA: 0x001CEC90 File Offset: 0x001CD090
		private void OnPK3V3CrossButtonIsShow(UIEvent uiEvent)
		{
		}

		// Token: 0x0600972E RID: 38702 RVA: 0x001CECA0 File Offset: 0x001CD0A0
		private void _OnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			ComCommonBind component = this.m_ActivityNoticeButton.gameObject.GetComponent<ComCommonBind>();
			if (component != null)
			{
				GameObject gameObject = component.GetGameObject("Effect");
				if (gameObject != null)
				{
					gameObject.CustomActive(false);
					if (DataManager<MoneyRewardsDataManager>.GetInstance().Status == PremiumLeagueStatus.PLS_ENROLL)
					{
						gameObject.CustomActive(true);
					}
				}
			}
		}

		// Token: 0x0600972F RID: 38703 RVA: 0x001CED00 File Offset: 0x001CD100
		private void OnGuildReceiveMergerRequest(UIEvent uiEvent)
		{
			this.mGuildMerge.CustomActive(DataManager<GuildDataManager>.GetInstance().IsHaveMergedRequest);
		}

		// Token: 0x06009730 RID: 38704 RVA: 0x001CED17 File Offset: 0x001CD117
		private void OnRefuseAllReciveRequest(UIEvent uiEvent)
		{
			if (!DataManager<GuildDataManager>.GetInstance().IsAgreeMergerRequest)
			{
				this.mGuildMerge.CustomActive(false);
			}
		}

		// Token: 0x06009731 RID: 38705 RVA: 0x001CED34 File Offset: 0x001CD134
		private void InitVoiceChat()
		{
			this.voiceSettingBtn = Utility.FindComponent<Button>(this.m_root, "VoiceSetBtn", true);
			if (this.voiceSettingBtn)
			{
				this.voiceSettingBtn.gameObject.CustomActive(false);
			}
			this.teamVoiceBtnGo = Utility.FindChild(this.m_root, "TeamVoiceBtn");
			this.guildVoiceBtnGo = Utility.FindChild(this.m_root, "GuildVoiceBtn");
			RectTransform rectTransform = base.transform as RectTransform;
			if (rectTransform == null)
			{
				return;
			}
			this.currComTalkOriginalPos = rectTransform.anchoredPosition;
			this.SetVoiceBtnsActive(false, false);
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			this.InitVoiceChatModule();
			if (this.teamVoiceBtnGo && this.guildVoiceBtnGo)
			{
				RectTransform component = this.teamVoiceBtnGo.GetComponent<RectTransform>();
				RectTransform component2 = this.guildVoiceBtnGo.GetComponent<RectTransform>();
				if (component == null || component2 == null)
				{
					return;
				}
				float x = component.sizeDelta.x;
				float x2 = component2.sizeDelta.x;
				this.voiceBtnWidth = ((x < x2) ? x2 : x);
			}
		}

		// Token: 0x06009732 RID: 38706 RVA: 0x001CEE70 File Offset: 0x001CD270
		private void TrySetVoiceChatBtnsPos()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			bool flag = DataManager<TeamDataManager>.GetInstance().HasTeam();
			bool flag2 = DataManager<GuildDataManager>.GetInstance().myGuild != null;
			if (!flag && !flag2)
			{
				this.ChangeComTalkPos(false);
			}
			else
			{
				this.ChangeComTalkPos(true);
			}
			if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
			{
				flag2 = false;
			}
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemGameBattle;
			if (clientSystemGameBattle != null)
			{
				this.SetVoiceBtnsActive(false, false);
				return;
			}
			if (TeamDuplicationUtility.IsInTeamDuplicationScene())
			{
				this.SetVoiceBtnsActive(false, false);
				return;
			}
			this.SetVoiceBtnsActive(flag, flag2);
		}

		// Token: 0x06009733 RID: 38707 RVA: 0x001CEF25 File Offset: 0x001CD325
		private void SetVoiceBtnsActive(bool isTeamShow, bool isGuildShow)
		{
			if (this.teamVoiceBtnGo)
			{
				this.teamVoiceBtnGo.CustomActive(isTeamShow);
			}
			if (this.guildVoiceBtnGo)
			{
				this.guildVoiceBtnGo.CustomActive(isGuildShow);
			}
		}

		// Token: 0x06009734 RID: 38708 RVA: 0x001CEF60 File Offset: 0x001CD360
		private void ChangeComTalkPos(bool isOffset)
		{
			RectTransform rectTransform = base.transform as RectTransform;
			if (rectTransform == null)
			{
				return;
			}
			if (rectTransform.anchoredPosition == this.currComTalkOriginalPos && !isOffset)
			{
				return;
			}
			if (isOffset)
			{
				rectTransform.anchoredPosition = new Vector2(this.currComTalkOriginalPos.x + Mathf.Abs(this.voiceBtnWidth), this.currComTalkOriginalPos.y);
			}
			else
			{
				rectTransform.anchoredPosition = this.currComTalkOriginalPos;
			}
		}

		// Token: 0x06009735 RID: 38709 RVA: 0x001CEFE8 File Offset: 0x001CD3E8
		private void InitVoiceChatModule()
		{
			if (this.isVoiceChatModulesInited)
			{
				return;
			}
			this.voiceChatModule = Singleton<SDKVoiceManager>.GetInstance().VoiceChatModule;
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.BindRoot(this.guildVoiceBtnGo, VoiceInputType.ComtalkGuild, null);
				this.voiceChatModule.BindRoot(this.teamVoiceBtnGo, VoiceInputType.ComtalkTeam, null);
			}
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 4, Utility.FindComponent<ComFunctionInterval>(this.guildVoiceBtnGo, "VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 5, Utility.FindComponent<ComFunctionInterval>(this.teamVoiceBtnGo, "VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 0, null);
			this.isVoiceChatModulesInited = true;
		}

		// Token: 0x06009736 RID: 38710 RVA: 0x001CF090 File Offset: 0x001CD490
		private void UninitVoiceChatModule()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return;
			}
			if (this.voiceChatModule != null)
			{
				if (this.guildVoiceBtnGo)
				{
					VoiceInputBtn componetInChild = Utility.GetComponetInChild<VoiceInputBtn>(this.guildVoiceBtnGo, "VoiceSend");
					this.voiceChatModule.UnBindRoot(VoiceInputType.ComtalkGuild, componetInChild);
				}
				if (this.teamVoiceBtnGo)
				{
					VoiceInputBtn componetInChild2 = Utility.GetComponetInChild<VoiceInputBtn>(this.teamVoiceBtnGo, "VoiceSend");
					this.voiceChatModule.UnBindRoot(VoiceInputType.ComtalkTeam, componetInChild2);
				}
			}
			this.isVoiceChatModulesInited = false;
			Singleton<ComIntervalGroup>.GetInstance().UnRegister(this);
		}

		// Token: 0x04004D94 RID: 19860
		public static ComTalk ms_comTalk;

		// Token: 0x04004D95 RID: 19861
		private const string prefabPath = "UIFlatten/Prefabs/Common/ComTalk";

		// Token: 0x04004D96 RID: 19862
		private GameObject m_root;

		// Token: 0x04004D97 RID: 19863
		private GameObject m_goBtnUp;

		// Token: 0x04004D98 RID: 19864
		private GameObject m_goBtnDown;

		// Token: 0x04004D99 RID: 19865
		private GameObject m_goChatParent;

		// Token: 0x04004D9A RID: 19866
		private GameObject m_goChatPrefab;

		// Token: 0x04004D9B RID: 19867
		private FastVerticalLayout m_kFastVerticalLayout;

		// Token: 0x04004D9C RID: 19868
		private Button m_btnChat;

		// Token: 0x04004D9D RID: 19869
		private Button m_btnSetting;

		// Token: 0x04004D9E RID: 19870
		private Button m_btnUp;

		// Token: 0x04004D9F RID: 19871
		private Button m_btnDown;

		// Token: 0x04004DA0 RID: 19872
		private Button voiceSettingBtn;

		// Token: 0x04004DA1 RID: 19873
		private GameObject teamVoiceBtnGo;

		// Token: 0x04004DA2 RID: 19874
		private GameObject guildVoiceBtnGo;

		// Token: 0x04004DA3 RID: 19875
		private VoiceChatModule voiceChatModule;

		// Token: 0x04004DA4 RID: 19876
		private bool isVoiceChatModulesInited;

		// Token: 0x04004DA5 RID: 19877
		private float fOffset = 150f;

		// Token: 0x04004DA6 RID: 19878
		private float fOffset2 = 89f;

		// Token: 0x04004DA7 RID: 19879
		private ComTalkExtraParam extraParam;

		// Token: 0x04004DA8 RID: 19880
		private List<ComCommonBind> NeedReshowEffectFuncs = new List<ComCommonBind>();

		// Token: 0x04004DA9 RID: 19881
		private CachedObjectDicManager<int, ComTalk.ChatObject> m_akChatObjects = new CachedObjectDicManager<int, ComTalk.ChatObject>();

		// Token: 0x04004DAA RID: 19882
		private ComCommonBind m_newMailNotice;

		// Token: 0x04004DAB RID: 19883
		private Button m_newMailNoticeButton;

		// Token: 0x04004DAC RID: 19884
		private Image m_newMailItemTip;

		// Token: 0x04004DAD RID: 19885
		private ComCommonBind m_ActivityNotice;

		// Token: 0x04004DAE RID: 19886
		private Button m_ActivityNoticeButton;

		// Token: 0x04004DAF RID: 19887
		private Text m_ActivityNoticeText;

		// Token: 0x04004DB0 RID: 19888
		private ComCommonBind m_TeamInvite;

		// Token: 0x04004DB1 RID: 19889
		private Button m_TeamInviteButton;

		// Token: 0x04004DB2 RID: 19890
		private Text m_TeamInviteText;

		// Token: 0x04004DB3 RID: 19891
		private ComCommonBind m_TeamDuplicationRequest;

		// Token: 0x04004DB4 RID: 19892
		private Button m_TeamDuplicationRequestButton;

		// Token: 0x04004DB5 RID: 19893
		private Text m_teamDuplicationRequestText;

		// Token: 0x04004DB6 RID: 19894
		private ComCommonBind m_TeamDuplicationTeamInvite;

		// Token: 0x04004DB7 RID: 19895
		private Button m_TeamDuplicationTeamInviteButton;

		// Token: 0x04004DB8 RID: 19896
		private Text m_TeamDuplicationTeamInviteText;

		// Token: 0x04004DB9 RID: 19897
		private ComCommonBind m_RoomInvite;

		// Token: 0x04004DBA RID: 19898
		private Button m_RoomInviteButton;

		// Token: 0x04004DBB RID: 19899
		private Text m_RoomInviteText;

		// Token: 0x04004DBC RID: 19900
		private ComCommonBind m_CrossPK3v3RoomInvite;

		// Token: 0x04004DBD RID: 19901
		private Button m_CrossPK3v3RoomInviteButton;

		// Token: 0x04004DBE RID: 19902
		private ComCommonBind m_SkillLvUp;

		// Token: 0x04004DBF RID: 19903
		private Button m_SkillLvUpButton;

		// Token: 0x04004DC0 RID: 19904
		private ComCommonBind m_FinancialPlan;

		// Token: 0x04004DC1 RID: 19905
		private Button m_FinancialPlanButton;

		// Token: 0x04004DC2 RID: 19906
		private Text m_FinancialPlanText;

		// Token: 0x04004DC3 RID: 19907
		private ComCommonBind m_FriendRequest;

		// Token: 0x04004DC4 RID: 19908
		private Button m_FriendRequestButton;

		// Token: 0x04004DC5 RID: 19909
		private Text m_FriendRequestText;

		// Token: 0x04004DC6 RID: 19910
		private ComCommonBind m_GuildInvite;

		// Token: 0x04004DC7 RID: 19911
		private Button m_GuildInviteButton;

		// Token: 0x04004DC8 RID: 19912
		private Text m_GuildInviteText;

		// Token: 0x04004DC9 RID: 19913
		private ComCommonBind m_LimitTimeGift;

		// Token: 0x04004DCA RID: 19914
		private Button m_LimitTimeGiftButton;

		// Token: 0x04004DCB RID: 19915
		private Text m_LimitTimeGiftText;

		// Token: 0x04004DCC RID: 19916
		private ComCommonBind m_ItemTimeLess;

		// Token: 0x04004DCD RID: 19917
		private Button m_ItemTimeLessButton;

		// Token: 0x04004DCE RID: 19918
		private ComCommonBind m_PrivateOrdering;

		// Token: 0x04004DCF RID: 19919
		private Button m_PrivateOrderingButton;

		// Token: 0x04004DD0 RID: 19920
		private Text m_PrivateOrderingDes;

		// Token: 0x04004DD1 RID: 19921
		private ComCommonBind m_AuctionFreezeRemind;

		// Token: 0x04004DD2 RID: 19922
		private Button m_AuctionFreezeRemindButton;

		// Token: 0x04004DD3 RID: 19923
		private ComCommonBind m_CrossPK3V3;

		// Token: 0x04004DD4 RID: 19924
		private Button m_CrossPk3V3Button;

		// Token: 0x04004DD5 RID: 19925
		private ComCommonBind m_SecurityLockApplyState;

		// Token: 0x04004DD6 RID: 19926
		private Button m_SecurityLockApplyStateButton;

		// Token: 0x04004DD7 RID: 19927
		private ComCommonBind mGuildMerge;

		// Token: 0x04004DD8 RID: 19928
		private Button mGuildMergeBtn;

		// Token: 0x04004DD9 RID: 19929
		private ulong mDataVersion = ulong.MaxValue;

		// Token: 0x04004DDA RID: 19930
		private ComCommonBind m_MasterDisciple;

		// Token: 0x04004DDB RID: 19931
		private Button m_MasterDiscipleButton;

		// Token: 0x04004DDC RID: 19932
		private Vector2 currComTalkOriginalPos;

		// Token: 0x04004DDD RID: 19933
		private float voiceBtnWidth;

		// Token: 0x02000F20 RID: 3872
		private class ChatObject : CachedObject
		{
			// Token: 0x1700191E RID: 6430
			// (get) Token: 0x0600973E RID: 38718 RVA: 0x001CF2DA File Offset: 0x001CD6DA
			public int SortOrder
			{
				get
				{
					return this.iOrder;
				}
			}

			// Token: 0x0600973F RID: 38719 RVA: 0x001CF2E2 File Offset: 0x001CD6E2
			public sealed override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x06009740 RID: 38720 RVA: 0x001CF305 File Offset: 0x001CD705
			public sealed override void OnDestroy()
			{
				this.kContent.RemoveFailedListener(new UnityAction(this._OnClickFailed));
			}

			// Token: 0x06009741 RID: 38721 RVA: 0x001CF31E File Offset: 0x001CD71E
			private void _OnClickFailed()
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChatFrame>(FrameLayer.Middle, null, string.Empty);
			}

			// Token: 0x06009742 RID: 38722 RVA: 0x001CF334 File Offset: 0x001CD734
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.chatBlock = (param[2] as ChatBlock);
				this.chatData = this.chatBlock.chatData;
				this.chatBlock.iPreID = (ulong)((long)this.chatBlock.chatData.guid);
				this.chatBlock.eType = ChatBlockType.CBT_KEEP;
				this.eChatType = this.chatData.eChatType;
				this.iOrder = this.chatBlock.iOrder;
				this.chatBlock = null;
				if (this.goPrefab == null)
				{
					return;
				}
				this.THIS = (param[3] as ComTalk);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					this.kContent = Utility.FindComponent<LinkParse>(this.goLocal, "Emotion", true);
					this.kSortOrder = this.goLocal.GetComponent<LayoutSortOrder>();
					Utility.AttachTo(this.goLocal, this.goParent, false);
					this.kContent.RemoveFailedListener(new UnityAction(this._OnClickFailed));
					this.kContent.AddOnFailedListener(new UnityAction(this._OnClickFailed));
				}
				this._UpdateItem();
				this.Enable();
			}

			// Token: 0x06009743 RID: 38723 RVA: 0x001CF483 File Offset: 0x001CD883
			public sealed override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x06009744 RID: 38724 RVA: 0x001CF48B File Offset: 0x001CD88B
			public sealed override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x06009745 RID: 38725 RVA: 0x001CF4AA File Offset: 0x001CD8AA
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x06009746 RID: 38726 RVA: 0x001CF4C9 File Offset: 0x001CD8C9
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06009747 RID: 38727 RVA: 0x001CF4D2 File Offset: 0x001CD8D2
			public sealed override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x06009748 RID: 38728 RVA: 0x001CF4DC File Offset: 0x001CD8DC
			public sealed override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x06009749 RID: 38729 RVA: 0x001CF4EC File Offset: 0x001CD8EC
			private void _UpdateItem()
			{
				try
				{
					if (this.chatData != null)
					{
						string nameLink = this.chatData.GetNameLink();
						if (!string.IsNullOrEmpty(nameLink))
						{
							this.kContent.SetText(this.chatData.GetChannelString() + nameLink + ":" + this.chatData.GetWords(), true);
						}
						else
						{
							this.kContent.SetText(this.chatData.GetChannelString() + this.chatData.GetWords(), true);
						}
						this.chatData = null;
					}
					if (this.kSortOrder != null)
					{
						this.kSortOrder.SortID = this.iOrder;
					}
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
				}
			}

			// Token: 0x04004DE1 RID: 19937
			protected GameObject goLocal;

			// Token: 0x04004DE2 RID: 19938
			protected GameObject goParent;

			// Token: 0x04004DE3 RID: 19939
			protected GameObject goPrefab;

			// Token: 0x04004DE4 RID: 19940
			protected ChatBlock chatBlock;

			// Token: 0x04004DE5 RID: 19941
			protected ChatData chatData;

			// Token: 0x04004DE6 RID: 19942
			protected ComTalk THIS;

			// Token: 0x04004DE7 RID: 19943
			protected ChatType eChatType;

			// Token: 0x04004DE8 RID: 19944
			protected int iOrder;

			// Token: 0x04004DE9 RID: 19945
			private Image kIcon;

			// Token: 0x04004DEA RID: 19946
			private Text kTime;

			// Token: 0x04004DEB RID: 19947
			private LinkParse kContent;

			// Token: 0x04004DEC RID: 19948
			private LayoutSortOrder kSortOrder;
		}
	}
}
