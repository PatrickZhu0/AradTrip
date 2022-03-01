using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001547 RID: 5447
	public class ChatFrame : ClientFrame
	{
		// Token: 0x0600D4B1 RID: 54449 RVA: 0x003516B7 File Offset: 0x0034FAB7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chat/ChatFrame";
		}

		// Token: 0x0600D4B2 RID: 54450 RVA: 0x003516C0 File Offset: 0x0034FAC0
		protected override void _OnOpenFrame()
		{
			if (this.userData is ChatFrameData)
			{
				this.data = (this.userData as ChatFrameData);
			}
			this.m_inputField.text = ChatFrame.ms_holdText;
			this.m_bFirstEnter = true;
			this.m_akTabObjects.Clear();
			this.m_akEmotionObjects.Clear();
			this.m_inputFieldRoot = Utility.FindGameObject(this.frame, "ScrollviewBg/InputField", true);
			this.m_closeRoot = Utility.FindGameObject(this.frame, "ScrollviewBg/close", true);
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddChatdata = (ChatManager.OnAddChatData)Delegate.Combine(instance.onAddChatdata, new ChatManager.OnAddChatData(this.OnAddChatData));
			ChatManager instance2 = DataManager<ChatManager>.GetInstance();
			instance2.onRebuildChatData = (ChatManager.OnRebuildChatData)Delegate.Combine(instance2.onRebuildChatData, new ChatManager.OnRebuildChatData(this.OnRebuildChatData));
			this.m_inputField.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.scrollrect.onValueChanged.AddListener(new UnityAction<Vector2>(this.OnScrollrectBarChanged));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 2, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 2, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 3, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 3, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 8, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 8, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 10, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 10, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 11, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 11, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 12, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/Send", true));
			Singleton<ComIntervalGroup>.GetInstance().Register(this, 12, Utility.FindComponent<ComFunctionInterval>(this.frame, "ScrollviewBg/InputField/VoiceInput/VoiceSend", true));
			this._InitChatObject();
			this.comChatList.Initialize(this, Utility.FindChild(this.frame, "ScrollviewBg"), this.data);
			this.voiceChatModule = Singleton<SDKVoiceManager>.GetInstance().VoiceChatModule;
			this.voiceChatModule.BindRoot(Utility.FindChild(this.frame, "ScrollviewBg/InputField/VoiceInput"), VoiceInputType.ChatFrame, this.data, new VoiceChatModule.IsSatisfiedWithWTalkCondition(this.is_satisfied_with_talk_condition), new VoiceChatModule.IsRecordVoiceLimited(this.IsRecordVoiceLimited), new VoiceChatModule.HideEmotion(this.HideEmotionBar));
			this._InitEmotionBag();
			this._InitTabs();
			this._RegisterUIEvent();
			ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE_LIST);
			if (tabObject != null)
			{
				bool priDirty = DataManager<RelationDataManager>.GetInstance().GetPriDirty();
				tabObject.SetRedPointActive(priDirty);
			}
			this.Input.onEndEdit.AddListener(new UnityAction<string>(this._OnInputEndEdit));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChatFrameStatusChanged, true, null, null, null);
			DataManager<RelationDataManager>.GetInstance().QueryPlayerOnlineStatus();
			this.RefreshFriendIcon();
			bool flag = TeamDuplicationUtility.IsInTeamDuplicationScene();
			if (flag || BeUtility.IsRaidBattle())
			{
				if (TeamDuplicationUtility.IsTeamDuplicationOwnerTeam())
				{
					this.SetTab(ChatType.CT_TEAM_COPY_TEAM);
				}
				else
				{
					this.SetTab(ChatType.CT_TEAM_COPY_PREPARE);
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE || this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM || this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD)
			{
				this.SetTab(ChatType.CT_WORLD);
			}
			if (flag)
			{
				StaticUtility.SafeSetVisible(this.mBind, "voiceInput", false);
				StaticUtility.SafeSetVisible(this.mBind, "Laba", false);
			}
		}

		// Token: 0x0600D4B3 RID: 54451 RVA: 0x00351AE4 File Offset: 0x0034FEE4
		private void _UpdateInputHoldplaceText()
		{
			Text text = this.m_inputField.placeholder as Text;
			if (text != null)
			{
				if (this.data.eChatType == ChatType.CT_WORLD)
				{
					SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						text.text = string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value);
						return;
					}
					int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
					if (freeWorldChatLeftTimes > 0)
					{
						float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(19);
						text.text = string.Format(TR.Value("chat_world_first_hold_place"), DataManager<PlayerBaseData>.GetInstance().VipLevel, freeWorldChatLeftTimes, curVipLevelPrivilegeData);
						return;
					}
					int activityValue = DataManager<PlayerBaseData>.GetInstance().ActivityValue;
					int worldChatCostActivityValue = ChatManager.WorldChatCostActivityValue;
					text.text = string.Format(TR.Value("chat_world_talk_need_activity_value"), worldChatCostActivityValue, activityValue, worldChatCostActivityValue);
					return;
				}
				else
				{
					if (this.data.eChatType == ChatType.CT_ACOMMPANY)
					{
						SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(174, string.Empty, string.Empty);
						if (tableItem2 != null && tableItem2.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
						{
							text.text = string.Format(TR.Value("chat_team_talk_need_level"), tableItem2.Value);
							return;
						}
					}
					else if (this.data.eChatType == ChatType.CT_TEAM)
					{
						bool flag = DataManager<TeamDataManager>.GetInstance().HasTeam();
						if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
						{
							flag = DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam();
						}
						if (!flag)
						{
							text.text = TR.Value("chat_team_talk_need_team");
							return;
						}
					}
					else if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM)
					{
						if (!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() && !BeUtility.IsRaidBattle())
						{
							text.text = TR.Value("chat_failed_for_has_no_team_copy_team");
							return;
						}
					}
					else if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD)
					{
						if (!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() && !BeUtility.IsRaidBattle())
						{
							text.text = TR.Value("chat_failed_for_has_no_team_copy_squad");
							return;
						}
					}
					else if (this.data.eChatType == ChatType.CT_NORMAL)
					{
						SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(173, string.Empty, string.Empty);
						if (tableItem3 != null && tableItem3.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
						{
							text.text = string.Format(TR.Value("chat_normal_talk_need_level"), tableItem3.Value);
							return;
						}
					}
					text.text = TR.Value("chat_generation_hint");
				}
			}
		}

		// Token: 0x0600D4B4 RID: 54452 RVA: 0x00351DC6 File Offset: 0x003501C6
		private bool CheckFunction()
		{
			return this.data != null && this.data.eChatType == ChatType.CT_WORLD;
		}

		// Token: 0x0600D4B5 RID: 54453 RVA: 0x00351DE4 File Offset: 0x003501E4
		protected override void _OnCloseFrame()
		{
			CachedSelectedObject<ChatFrame.ChatTypeData, ChatFrame.TabObject>.Clear();
			this.m_akTabObjects.DestroyAllObjects();
			this.m_akEmotionObjects.Clear();
			OnFocusInputField inputField = this.m_inputField;
			inputField.onClick = (OnFocusInputField.OnClick)Delegate.Remove(inputField.onClick, new OnFocusInputField.OnClick(this.OnClickInputField));
			this.m_inputField.onValueChanged.RemoveListener(new UnityAction<string>(this.OnValueChanged));
			ChatManager instance = DataManager<ChatManager>.GetInstance();
			instance.onAddChatdata = (ChatManager.OnAddChatData)Delegate.Remove(instance.onAddChatdata, new ChatManager.OnAddChatData(this.OnAddChatData));
			ChatManager instance2 = DataManager<ChatManager>.GetInstance();
			instance2.onRebuildChatData = (ChatManager.OnRebuildChatData)Delegate.Remove(instance2.onRebuildChatData, new ChatManager.OnRebuildChatData(this.OnRebuildChatData));
			this._UnRegisterUIEvent();
			this.Input.onEndEdit.RemoveListener(new UnityAction<string>(this._OnInputEndEdit));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnChatFrameStatusChanged, false, null, null, null);
			this.comChatList.UnInitialize();
			this.voiceChatModule.UnBindRoot(VoiceInputType.ChatFrame, null);
			this.scrollrect.onValueChanged.RemoveListener(new UnityAction<Vector2>(this.OnScrollrectBarChanged));
			this.newMessageNumber = 0;
			Singleton<ComIntervalGroup>.GetInstance().UnRegister(this);
		}

		// Token: 0x0600D4B6 RID: 54454 RVA: 0x00351F1C File Offset: 0x0035031C
		protected void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnUpdatePrivate, new ClientEventSystem.UIEventHandler(this._OnUpdatePrivate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this._OnDelPrivate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPrivateRdChanged, new ClientEventSystem.UIEventHandler(this._OnPrivateRdChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPlayerOnLineStatusChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerOnLineStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SetChatTab, new ClientEventSystem.UIEventHandler(this._OnSetChatTab));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LockStatuNewMessageNumber, new ClientEventSystem.UIEventHandler(this._OnLockStatuNewMessageNumberChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshChatData, new ClientEventSystem.UIEventHandler(this._RefreshChatData));
			Button button = this.mScriptBinder.GetObject(3) as Button;
			if (null != button)
			{
				button.onClick.AddListener(delegate()
				{
					if (DataManager<ChijiDataManager>.GetInstance().CheckCurrentSystemIsClientSystemGameBattle())
					{
						SystemNotifyManager.SysNotifyTextAnimation("本场景无法加入队伍", CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
					if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossTeamListFrame>(FrameLayer.Middle, null, string.Empty);
						this.frameMgr.CloseFrame<ChatFrame>(this, false);
						return;
					}
					FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(30, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return;
					}
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
					{
						SystemNotifyManager.SystemNotify(1300031, string.Empty);
						return;
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
					this.frameMgr.CloseFrame<ChatFrame>(this, false);
				});
			}
			Button button2 = this.mScriptBinder.GetObject(4) as Button;
			if (null != button2)
			{
				button2.onClick.AddListener(delegate()
				{
					FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(15, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return;
					}
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_not_open_need_lv"), CommonTipsDesc.eShowMode.SI_IMMEDIATELY, 0);
						return;
					}
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildListFrame>(FrameLayer.Middle, null, string.Empty);
					this.frameMgr.CloseFrame<ChatFrame>(this, false);
				});
			}
			Button button3 = this.mScriptBinder.GetObject(7) as Button;
			if (null != button3)
			{
				button3.SafeSetOnClickListener(delegate
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamDuplicationTeamListFrame>(FrameLayer.Middle, null, string.Empty);
					this.frameMgr.CloseFrame<ChatFrame>(this, false);
				});
			}
		}

		// Token: 0x0600D4B7 RID: 54455 RVA: 0x003520EC File Offset: 0x003504EC
		protected void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnShowFriendSecMenu, new ClientEventSystem.UIEventHandler(this._OnShowFrienSecInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseMenu, new ClientEventSystem.UIEventHandler(this._OnCloseMenu));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnUpdatePrivate, new ClientEventSystem.UIEventHandler(this._OnUpdatePrivate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this._OnDelPrivate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPrivateRdChanged, new ClientEventSystem.UIEventHandler(this._OnPrivateRdChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this._OnRoleChatDirtyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPlayerOnLineStatusChanged, new ClientEventSystem.UIEventHandler(this._OnPlayerOnLineStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCounterChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SetChatTab, new ClientEventSystem.UIEventHandler(this._OnSetChatTab));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LockStatuNewMessageNumber, new ClientEventSystem.UIEventHandler(this._OnLockStatuNewMessageNumberChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshChatData, new ClientEventSystem.UIEventHandler(this._RefreshChatData));
		}

		// Token: 0x0600D4B8 RID: 54456 RVA: 0x00352224 File Offset: 0x00350624
		protected void _OnShowFrienSecInfo(UIEvent uiEvent)
		{
			UIEventShowFriendSecMenu uieventShowFriendSecMenu = uiEvent as UIEventShowFriendSecMenu;
			bool flag = true;
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle)
				{
					flag = false;
				}
			}
			if (flag)
			{
				if (!Pk3v3DataManager.HasInPk3v3Room() && !DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationFrameNew>(null))
					{
						return;
					}
					this.m_openMenu = this.frameMgr.OpenFrame<RelationMenuFram>(FrameLayer.Middle, uieventShowFriendSecMenu.m_data, string.Empty);
				}
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect("跨服公会战场景下无法查看玩家信息", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600D4B9 RID: 54457 RVA: 0x003522ED File Offset: 0x003506ED
		protected void _OnCloseMenu(UIEvent uiEvent)
		{
			if (this.m_openMenu != null)
			{
				this.frameMgr.CloseFrame<IClientFrame>(this.m_openMenu, false);
				this.m_openMenu = null;
			}
		}

		// Token: 0x0600D4BA RID: 54458 RVA: 0x00352314 File Offset: 0x00350714
		private void _InitTabs()
		{
			this.m_goTabParent = Utility.FindChild(this.frame, "tabs");
			this.m_goTabPrefab = Utility.FindChild(this.m_goTabParent, "tab");
			this.m_goTabPrefab.CustomActive(false);
			for (int i = 0; i < 13; i++)
			{
				ChatType mapIndex = (ChatType)ChatManager.GetMapIndex(i);
				if (mapIndex != ChatType.CT_PK3V3_ROOM)
				{
					string content = string.Empty;
					if (mapIndex != ChatType.CT_PRIVATE)
					{
						if (mapIndex != ChatType.CT_PRIVATE_LIST)
						{
							content = Utility.GetEnumDescription<ChatType>(mapIndex);
							ChatFrame.TabObject tabObject = this.m_akTabObjects.Create(new object[]
							{
								this.m_goTabParent,
								this.m_goTabPrefab,
								new ChatFrame.ChatTypeData
								{
									eChatType = mapIndex,
									content = content
								},
								Delegate.CreateDelegate(typeof(CachedSelectedObject<ChatFrame.ChatTypeData, ChatFrame.TabObject>.OnSelectedDelegate), this, "OnFilterChanged"),
								false
							});
							if (this._NeedShowTab(mapIndex))
							{
								tabObject.Enable();
							}
							else
							{
								tabObject.Disable();
							}
						}
					}
				}
			}
			ChatFrame.TabObject tabObject2 = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == this.data.eChatType);
			if (tabObject2 != null)
			{
				tabObject2.OnSelected();
			}
		}

		// Token: 0x0600D4BB RID: 54459 RVA: 0x0035244C File Offset: 0x0035084C
		private bool _NeedShowTab(ChatType tabType)
		{
			if (BattleMain.instance != null && (tabType == ChatType.CT_NORMAL || (tabType == ChatType.CT_GUILD && !DataManager<GuildDataManager>.GetInstance().HasSelfGuild())))
			{
				return false;
			}
			bool flag = TeamDuplicationUtility.IsInTeamDuplicationScene();
			bool flag2 = BeUtility.IsRaidBattle();
			if (tabType == ChatType.CT_TEAM_COPY_PREPARE || tabType == ChatType.CT_TEAM_COPY_TEAM || tabType == ChatType.CT_TEAM_COPY_SQUAD)
			{
				return flag || flag2;
			}
			return !flag && !flag2 && (tabType != ChatType.CT_PRIVATE || this.data.curPrivate != null) && tabType != ChatType.CT_ALL;
		}

		// Token: 0x0600D4BC RID: 54460 RVA: 0x003524E1 File Offset: 0x003508E1
		public void SetPrivateChatTab(RelationData data)
		{
			this.data.eChatType = ChatType.CT_PRIVATE;
			this.data.curPrivate = data;
			this.SetTab(ChatType.CT_PRIVATE);
		}

		// Token: 0x0600D4BD RID: 54461 RVA: 0x00352504 File Offset: 0x00350904
		private string _GetPrivateChatTabContent()
		{
			string result = "CT_PRIVATE";
			if (this.data != null && this.data.curPrivate != null)
			{
				result = this.data.curPrivate.name;
			}
			return result;
		}

		// Token: 0x0600D4BE RID: 54462 RVA: 0x00352544 File Offset: 0x00350944
		public void SetTab(ChatType eType)
		{
			ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == eType);
			if (tabObject != null)
			{
				tabObject.Enable();
				tabObject.OnSelected();
			}
		}

		// Token: 0x0600D4BF RID: 54463 RVA: 0x00352588 File Offset: 0x00350988
		private void _UpdateFriendlyHint()
		{
			if (null != this.friendlyHint)
			{
				if (null != this.mScriptBinder)
				{
					this.mScriptBinder.SetAction(0);
				}
				if (this.data.eChatType == ChatType.CT_GUILD)
				{
					if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
					{
						this.friendlyHint.SetText(TR.Value("chat_failed_for_has_no_guild"), true);
						if (null != this.mScriptBinder)
						{
							this.mScriptBinder.SetAction(2);
						}
					}
					else
					{
						this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
					}
				}
				else if (this.data.eChatType == ChatType.CT_TEAM)
				{
					if (!DataManager<TeamDataManager>.GetInstance().HasTeam())
					{
						this.friendlyHint.SetText(TR.Value("chat_failed_for_has_no_team"), true);
						if (null != this.mScriptBinder)
						{
							this.mScriptBinder.SetAction(1);
						}
					}
					else
					{
						this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
					}
				}
				else if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM)
				{
					if (!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam())
					{
						this.friendlyHint.SetText(TR.Value("chat_failed_for_has_no_team_copy_team"), true);
						if (null != this.mScriptBinder)
						{
							this.mScriptBinder.SetAction(6);
						}
					}
					else
					{
						this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
					}
				}
				else if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD)
				{
					if (!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam())
					{
						this.friendlyHint.SetText(TR.Value("chat_failed_for_has_no_team_copy_squad"), true);
						if (null != this.mScriptBinder)
						{
							this.mScriptBinder.SetAction(6);
						}
					}
					else
					{
						this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
					}
				}
				else if (this.data.eChatType == ChatType.CT_ACOMMPANY)
				{
					this.friendlyHint.SetText(TR.Value("chat_failed_for_accompany"), true);
				}
				else if (this.data.eChatType == ChatType.CT_PRIVATE_LIST)
				{
					this.friendlyHint.SetText(TR.Value("chat_failed_for_private"), true);
				}
				else if (this.data.eChatType == ChatType.CT_PRIVATE)
				{
					this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
				}
				else if (this.data.eChatType == ChatType.CT_SYSTEM)
				{
					this.friendlyHint.SetText(TR.Value("chat_failed_for_system"), true);
				}
				else if (this.data.eChatType == ChatType.CT_NORMAL)
				{
					this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
				}
				else if (this.data.eChatType == ChatType.CT_WORLD)
				{
					this.friendlyHint.SetText(TR.Value("chat_succeed"), true);
				}
				else
				{
					this.friendlyHint.SetText(TR.Value("chat_failed"), true);
				}
			}
		}

		// Token: 0x0600D4C0 RID: 54464 RVA: 0x003528A8 File Offset: 0x00350CA8
		private void OnFilterChanged(ChatFrame.ChatTypeData chatTypeData)
		{
			this.data.eChatType = chatTypeData.eChatType;
			this._SwitchContent(true);
			this._UpdateWorldChatCoolDown();
			this._UpdateNormalChatCoolDown();
			this._UpdateTeamCopyPrepareChatCoolDown();
			this._UpdateTeamCopyTeamChatCoolDown();
			this._UpdateTeamCopySquadChatCoolDown();
			this._UpdateAccompanyChatCoolDown();
			this._UpdateDefaultCoolDown();
			this._ShowInputFiled();
			this._UpdateInputHoldplaceText();
			this._UpdateFriendlyHint();
			DataManager<RelationDataManager>.GetInstance().SetCurPriChatUid(0UL);
			if (this.data.eChatType == ChatType.CT_GUILD)
			{
				if (!DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
				{
					this.m_kTextChatHint.CustomActive(true);
					this.m_kTextChatHint.text = TR.Value("enchant_no_gang");
				}
				else
				{
					this.m_kTextChatHint.CustomActive(false);
				}
				this.m_inputFieldRoot.SetActive(DataManager<GuildDataManager>.GetInstance().HasSelfGuild());
			}
			else if (this.data.eChatType == ChatType.CT_TEAM)
			{
				if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
				{
					this.m_kTextChatHint.CustomActive(!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam());
					this.m_kTextChatHint.text = TR.Value("enchant_no_team");
					this.m_inputFieldRoot.SetActive(DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam());
				}
				else
				{
					this.m_kTextChatHint.CustomActive(!DataManager<TeamDataManager>.GetInstance().HasTeam());
					this.m_kTextChatHint.text = TR.Value("enchant_no_team");
					this.m_inputFieldRoot.SetActive(DataManager<TeamDataManager>.GetInstance().HasTeam());
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM)
			{
				this.m_kTextChatHint.CustomActive(!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() && !BeUtility.IsRaidBattle());
				this.m_kTextChatHint.text = TR.Value("chat_failed_for_has_no_team_copy_team");
				this.m_inputFieldRoot.SetActive(TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() || BeUtility.IsRaidBattle());
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD)
			{
				this.m_kTextChatHint.CustomActive(!TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() && !BeUtility.IsRaidBattle());
				this.m_kTextChatHint.text = TR.Value("chat_failed_for_has_no_team_copy_squad");
				this.m_inputFieldRoot.SetActive(TeamDuplicationUtility.IsTeamDuplicationOwnerTeam() || BeUtility.IsRaidBattle());
			}
			else if (this.data.eChatType == ChatType.CT_ACOMMPANY)
			{
				this.m_inputFieldRoot.SetActive(true);
				this.m_kTextChatHint.CustomActive(false);
				this.m_inputFieldRoot.SetActive(false);
			}
			else if (this.data.eChatType == ChatType.CT_PRIVATE_LIST)
			{
				this.m_kTextChatHint.CustomActive(false);
				this._AddPrivateChatPlayerList();
			}
			else if (this.data.eChatType == ChatType.CT_PRIVATE)
			{
				this.m_kTextChatHint.CustomActive(false);
				if (this.data.curPrivate != null)
				{
					DataManager<RelationDataManager>.GetInstance().ClearPriChatDirty(this.data.curPrivate.uid);
				}
				ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE);
				if (tabObject != null)
				{
					tabObject.OnRefresh(new object[]
					{
						new ChatFrame.ChatTypeData
						{
							eChatType = this.data.eChatType,
							content = this._GetPrivateChatTabContent()
						}
					});
				}
			}
			else
			{
				this.m_kTextChatHint.CustomActive(false);
			}
			this.friendlyHint.CustomActive(!this.m_inputFieldRoot.activeSelf);
			this.screenLocked = false;
			this.MarkChatDataDirty();
		}

		// Token: 0x0600D4C1 RID: 54465 RVA: 0x00352C48 File Offset: 0x00351048
		private void _ShowInputFiled()
		{
			if (this.data.eChatType == ChatType.CT_ALL || this.data.eChatType == ChatType.CT_SYSTEM || this.data.eChatType == ChatType.CT_PRIVATE_LIST)
			{
				this.m_inputFieldRoot.SetActive(false);
			}
			else
			{
				this.m_inputFieldRoot.SetActive(true);
			}
		}

		// Token: 0x0600D4C2 RID: 54466 RVA: 0x00352CA4 File Offset: 0x003510A4
		public void SetTalkContent(string content)
		{
			if (this.m_inputFieldRoot.activeSelf)
			{
				this.Input.text = content;
			}
		}

		// Token: 0x0600D4C3 RID: 54467 RVA: 0x00352CC4 File Offset: 0x003510C4
		private void _AddPrivateChatPlayerList()
		{
			this._ClearChatPlayerList();
			List<PrivateChatPlayerData> list = new List<PrivateChatPlayerData>();
			List<PrivateChatPlayerData> priChatList = DataManager<RelationDataManager>.GetInstance().GetPriChatList();
			list.AddRange(priChatList);
			list.Sort(delegate(PrivateChatPlayerData x, PrivateChatPlayerData y)
			{
				if (x.chatNum > 0 != y.chatNum > 0)
				{
					return (x.chatNum <= 0) ? 1 : -1;
				}
				if (x.relationData.isOnline != y.relationData.isOnline)
				{
					return (x.relationData.isOnline != 1) ? 1 : -1;
				}
				if (x.iOrder != y.iOrder)
				{
					return y.iOrder - x.iOrder;
				}
				return (x.relationData.uid >= y.relationData.uid) ? ((x.relationData.uid != y.relationData.uid) ? 1 : 0) : -1;
			});
			GameObject gameObject = this.mScriptBinder.GetObject(5) as GameObject;
			for (int i = 0; i < list.Count; i++)
			{
				CommonPlayerInfo commonPlayerInfo = new CommonPlayerInfo(list[i].relationData.uid, list[i].relationData.name, list[i].relationData.level, list[i].relationData.occu, CommonPlayerInfo.CommonPlayerType.CPT_PRIVAT_CHAT, list[i].chatNum > 0, list[i].relationData.isOnline, list[i].relationData.type, list[i].relationData.vipLv);
				this.m_chatPlayerList.Add(commonPlayerInfo);
				commonPlayerInfo.m_friendPrefab.transform.SetParent(gameObject.transform, false);
			}
			this._SwitchContent(false);
		}

		// Token: 0x0600D4C4 RID: 54468 RVA: 0x00352E00 File Offset: 0x00351200
		private void _SwitchContent(bool isChatContent)
		{
			GameObject gameObject = this.mScriptBinder.GetObject(5) as GameObject;
			if (isChatContent)
			{
				gameObject.CustomActive(false);
			}
			else
			{
				gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600D4C5 RID: 54469 RVA: 0x00352E38 File Offset: 0x00351238
		private void _UpdateWorldChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_WORLD)
			{
				if (ChatManager.world_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 2, (float)ChatManager.world_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 2);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 2);
				}
			}
		}

		// Token: 0x0600D4C6 RID: 54470 RVA: 0x00352E90 File Offset: 0x00351290
		private void _UpdateNormalChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_NORMAL)
			{
				if (ChatManager.arround_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 3, (float)ChatManager.arround_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 3);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 3);
				}
			}
		}

		// Token: 0x0600D4C7 RID: 54471 RVA: 0x00352EE8 File Offset: 0x003512E8
		private void _UpdateTeamCopyPrepareChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE)
			{
				if (ChatManager.teamcopy_prepare_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 10, (float)ChatManager.teamcopy_prepare_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 10);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 10);
				}
			}
		}

		// Token: 0x0600D4C8 RID: 54472 RVA: 0x00352F44 File Offset: 0x00351344
		private void _UpdateTeamCopyTeamChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM)
			{
				if (ChatManager.teamcopy_team_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 11, (float)ChatManager.teamcopy_team_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 11);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 11);
				}
			}
		}

		// Token: 0x0600D4C9 RID: 54473 RVA: 0x00352FA0 File Offset: 0x003513A0
		private void _UpdateTeamCopySquadChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD)
			{
				if (ChatManager.teamcopy_squad_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 12, (float)ChatManager.teamcopy_squad_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 12);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 12);
				}
			}
		}

		// Token: 0x0600D4CA RID: 54474 RVA: 0x00352FFC File Offset: 0x003513FC
		private void _UpdateAccompanyChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_ACOMMPANY)
			{
				if (ChatManager.accompany_cool_time > 0)
				{
					Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 8, (float)ChatManager.accompany_cool_time);
					Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 8);
				}
				else
				{
					Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 8);
				}
			}
		}

		// Token: 0x0600D4CB RID: 54475 RVA: 0x00353054 File Offset: 0x00351454
		private void _UpdateDefaultCoolDown()
		{
			if (this.data.eChatType != ChatType.CT_ACOMMPANY && this.data.eChatType != ChatType.CT_NORMAL && this.data.eChatType != ChatType.CT_WORLD && this.data.eChatType != ChatType.CT_TEAM_COPY_PREPARE && this.data.eChatType != ChatType.CT_TEAM_COPY_TEAM && this.data.eChatType != ChatType.CT_TEAM_COPY_SQUAD)
			{
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 8);
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 3);
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 2);
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 10);
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 11);
				Singleton<ComIntervalGroup>.GetInstance().EnableFunction(this, 12);
			}
		}

		// Token: 0x0600D4CC RID: 54476 RVA: 0x00353118 File Offset: 0x00351518
		private void _ClearChatPlayerList()
		{
			for (int i = 0; i < this.m_chatPlayerList.Count; i++)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.m_chatPlayerList[i].m_friendPrefab);
			}
			this.m_chatPlayerList.Clear();
		}

		// Token: 0x0600D4CD RID: 54477 RVA: 0x00353167 File Offset: 0x00351567
		private void _RefreshPrivateChatList(ref List<PrivateChatPlayerData> list)
		{
		}

		// Token: 0x0600D4CE RID: 54478 RVA: 0x00353169 File Offset: 0x00351569
		private void _InitChatObject()
		{
			OnFocusInputField inputField = this.m_inputField;
			inputField.onClick = (OnFocusInputField.OnClick)Delegate.Combine(inputField.onClick, new OnFocusInputField.OnClick(this.OnClickInputField));
		}

		// Token: 0x0600D4CF RID: 54479 RVA: 0x00353192 File Offset: 0x00351592
		private void OnClickInputField()
		{
			this.m_goEmotionTab.CustomActive(false);
			this.m_closeRoot.SetActive(false);
		}

		// Token: 0x0600D4D0 RID: 54480 RVA: 0x003531AC File Offset: 0x003515AC
		private void OnValueChanged(string value)
		{
			ChatFrame.ms_holdText = value;
		}

		// Token: 0x17001BFE RID: 7166
		// (get) Token: 0x0600D4D1 RID: 54481 RVA: 0x003531B4 File Offset: 0x003515B4
		// (set) Token: 0x0600D4D2 RID: 54482 RVA: 0x003531BC File Offset: 0x003515BC
		public bool ScreenLocked
		{
			get
			{
				return this.screenLocked;
			}
			set
			{
				if (this.screenLocked != value)
				{
					this.screenLocked = value;
					if (!value)
					{
						this.MarkChatDataDirty();
					}
				}
			}
		}

		// Token: 0x0600D4D3 RID: 54483 RVA: 0x003531DD File Offset: 0x003515DD
		private void OnScrollrectBarChanged(Vector2 vector)
		{
			if (vector.y <= 0.001f)
			{
				this.ScreenLocked = false;
				this.goNewMessageBumber.CustomActive(false);
				this.newMessageNumber = 0;
			}
			else
			{
				this.ScreenLocked = true;
			}
		}

		// Token: 0x0600D4D4 RID: 54484 RVA: 0x00353216 File Offset: 0x00351616
		public bool world_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_WORLD && !ChatManager.world_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 2, (float)ChatManager.ms_world_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 2);
			return true;
		}

		// Token: 0x0600D4D5 RID: 54485 RVA: 0x00353254 File Offset: 0x00351654
		private bool arround_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_NORMAL && !ChatManager.arround_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 3, (float)ChatManager.ms_arround_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 3);
			return true;
		}

		// Token: 0x0600D4D6 RID: 54486 RVA: 0x00353294 File Offset: 0x00351694
		private bool teamcopy_prepare_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE && !ChatManager.teamcopy_prepare_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 10, (float)ChatManager.ms_teamcopy_prepare_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 10);
			return true;
		}

		// Token: 0x0600D4D7 RID: 54487 RVA: 0x003532E0 File Offset: 0x003516E0
		private bool teamcopy_team_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM && !ChatManager.teamcopy_team_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 11, (float)ChatManager.ms_teamcopy_team_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 11);
			return true;
		}

		// Token: 0x0600D4D8 RID: 54488 RVA: 0x0035332C File Offset: 0x0035172C
		private bool teamcopy_squad_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD && !ChatManager.teamcopy_squad_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 12, (float)ChatManager.ms_teamcopy_squad_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 12);
			return true;
		}

		// Token: 0x0600D4D9 RID: 54489 RVA: 0x00353378 File Offset: 0x00351778
		private bool accompany_chat_try_enter_cool_down()
		{
			if (this.data.eChatType == ChatType.CT_ACOMMPANY && !ChatManager.accompany_chat_try_enter_cool_down())
			{
				return false;
			}
			Singleton<ComIntervalGroup>.GetInstance().BeginInvoke(this, 8, (float)ChatManager.ms_accompany_cool_down);
			Singleton<ComIntervalGroup>.GetInstance().DisableFunction(this, 8);
			return true;
		}

		// Token: 0x0600D4DA RID: 54490 RVA: 0x003533B8 File Offset: 0x003517B8
		private bool is_satisfied_with_talk_condition()
		{
			if (this.data.eChatType == ChatType.CT_WORLD)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return false;
				}
				int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
				if (freeWorldChatLeftTimes <= 0 && !DataManager<ChatManager>.GetInstance().CheckWorldActivityValueEnough())
				{
					SystemNotifyManager.SystemNotify(7006, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.VIP, string.Empty);
					});
					return false;
				}
				if (!this.world_chat_try_enter_cool_down())
				{
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_ACOMMPANY)
			{
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(174, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_team_talk_need_level"), tableItem2.Value), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return false;
				}
				if (!this.accompany_chat_try_enter_cool_down())
				{
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_NORMAL)
			{
				if (!this.arround_chat_try_enter_cool_down())
				{
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM)
			{
				if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
				{
					if (!DataManager<Pk3v3CrossDataManager>.GetInstance().HasTeam())
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chat_team_talk_need_team"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return false;
					}
				}
				else if (!DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chat_team_talk_need_team"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE)
			{
				if (!this.teamcopy_prepare_chat_try_enter_cool_down())
				{
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_TEAM)
			{
				if (!this.teamcopy_team_chat_try_enter_cool_down())
				{
					return false;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_SQUAD && !this.teamcopy_squad_chat_try_enter_cool_down())
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600D4DB RID: 54491 RVA: 0x003535FC File Offset: 0x003519FC
		[UIEventHandle("ScrollviewBg/InputField/Send")]
		private void OnClickSendChatContent()
		{
			if (!string.IsNullOrEmpty(this.m_inputField.text) && this.m_inputField.text.Length < 100)
			{
				ulong tarId = (this.data.curPrivate != null) ? this.data.curPrivate.uid : 0UL;
				if (!this.is_satisfied_with_talk_condition())
				{
					return;
				}
				if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null) && this.data.eChatType == ChatType.CT_TEAM)
				{
					DataManager<ChatManager>.GetInstance().SendChat(ChatType.CT_PK3V3_ROOM, ChatFrame.GetFliterSizeString(this.m_inputField.text), tarId, 0);
				}
				else
				{
					DataManager<ChatManager>.GetInstance().SendChat(this.data.eChatType, ChatFrame.GetFliterSizeString(this.m_inputField.text), tarId, 0);
				}
				this.m_inputField.text = string.Empty;
			}
			else if (this.m_inputField.text != null && this.m_inputField.text.Length >= 100)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("chat_too_many_words"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600D4DC RID: 54492 RVA: 0x00353722 File Offset: 0x00351B22
		public static string GetFliterSizeString(string str)
		{
			str = str.Replace('<', '〈');
			str = str.Replace('>', '〉');
			return str;
		}

		// Token: 0x0600D4DD RID: 54493 RVA: 0x00353743 File Offset: 0x00351B43
		[UIEventHandle("ScrollviewBg/InputField/Button/Emotion")]
		private void OnClickEmotionBag()
		{
			this.m_goEmotionTab.SetActive(!this.m_goEmotionTab.activeSelf);
		}

		// Token: 0x0600D4DE RID: 54494 RVA: 0x00353760 File Offset: 0x00351B60
		private void _InitEmotionBag()
		{
			this.m_goEmotionTab = Utility.FindChild(this.frame, "ScrollviewBg/EmotionTab");
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

		// Token: 0x0600D4DF RID: 54495 RVA: 0x00353863 File Offset: 0x00351C63
		private void AddChatText(string content)
		{
			if (!string.IsNullOrEmpty(content))
			{
				OnFocusInputField inputField = this.m_inputField;
				inputField.text += content;
			}
		}

		// Token: 0x0600D4E0 RID: 54496 RVA: 0x00353887 File Offset: 0x00351C87
		private void OnRebuildChatData(ulong preGuid, ChatBlock chatBlock)
		{
			if (chatBlock.chatData.eChatType == this.data.eChatType)
			{
				this.MarkChatDataDirty();
			}
		}

		// Token: 0x0600D4E1 RID: 54497 RVA: 0x003538AA File Offset: 0x00351CAA
		private void OnAddChatData(ChatBlock chatBlock)
		{
			if (chatBlock.chatData.eChatType == ChatType.CT_PRIVATE)
			{
				return;
			}
			if (chatBlock.chatData.eChatType == this.data.eChatType)
			{
				this.MarkChatDataDirty();
			}
		}

		// Token: 0x0600D4E2 RID: 54498 RVA: 0x003538DF File Offset: 0x00351CDF
		private void RefreshChatData()
		{
			this.comChatList.RefreshChatData(this.data);
			this.scrollrect.verticalNormalizedPosition = 0f;
		}

		// Token: 0x0600D4E3 RID: 54499 RVA: 0x00353902 File Offset: 0x00351D02
		private void MarkChatDataDirty()
		{
			if (this.screenLocked)
			{
				return;
			}
			this.m_bDirty = true;
		}

		// Token: 0x0600D4E4 RID: 54500 RVA: 0x00353917 File Offset: 0x00351D17
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D4E5 RID: 54501 RVA: 0x0035391A File Offset: 0x00351D1A
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.m_bDirty)
			{
				this.RefreshChatData();
				this.m_bDirty = false;
			}
		}

		// Token: 0x0600D4E6 RID: 54502 RVA: 0x00353934 File Offset: 0x00351D34
		private void _InitCurrentChatData()
		{
			for (int i = 0; i < 13; i++)
			{
				List<ChatBlock> list = null;
				if (i == 7 && this.data.curPrivate != null)
				{
					list = DataManager<ChatManager>.GetInstance().GetPrivateChat(this.data.curPrivate.uid);
				}
				else if (i == 7)
				{
					this._AddPrivateChatPlayerList();
				}
				else
				{
					list = DataManager<ChatManager>.GetInstance().GetChatDataByChanelType(DataManager<ChatManager>.GetInstance()._TransChatType((ChatType)i));
				}
				if (list != null)
				{
					List<ChatBlock> list2 = new List<ChatBlock>();
					list2.AddRange(list);
					list2.Sort((ChatBlock x, ChatBlock y) => x.iOrder - y.iOrder);
					for (int j = 0; j < list2.Count; j++)
					{
						this.OnAddChatData(list2[j]);
					}
				}
			}
		}

		// Token: 0x0600D4E7 RID: 54503 RVA: 0x00353A0F File Offset: 0x00351E0F
		[UIEventHandle("ScrollviewBg/close")]
		private void OnClickClose()
		{
			this.m_goEmotionTab.SetActive(false);
			this.frameMgr.CloseFrame<ChatFrame>(this, false);
		}

		// Token: 0x0600D4E8 RID: 54504 RVA: 0x00353A2C File Offset: 0x00351E2C
		private void _OnPrivateChat(UIEvent uiEvent)
		{
			UIEventPrivateChat uieventPrivateChat = uiEvent as UIEventPrivateChat;
			if (uieventPrivateChat.m_recvChat)
			{
				bool priDirty = DataManager<RelationDataManager>.GetInstance().GetPriDirty();
				ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => ChatType.CT_PRIVATE_LIST == x.Value.eChatType);
				if (tabObject != null && tabObject.isOn)
				{
					this._AddPrivateChatPlayerList();
				}
			}
			else
			{
				this.SetPrivateChatTab(uieventPrivateChat.m_data);
			}
		}

		// Token: 0x0600D4E9 RID: 54505 RVA: 0x00353AA8 File Offset: 0x00351EA8
		private void _OnUpdatePrivate(UIEvent uiEvent)
		{
			ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE_LIST);
			if (tabObject != null && tabObject.isOn)
			{
				this._AddPrivateChatPlayerList();
			}
		}

		// Token: 0x0600D4EA RID: 54506 RVA: 0x00353AF8 File Offset: 0x00351EF8
		private void _OnDelPrivate(UIEvent uiEvent)
		{
			UIEventDelPrivate uieventDelPrivate = uiEvent as UIEventDelPrivate;
			ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE_LIST);
			if (tabObject != null && tabObject.isOn)
			{
				this._AddPrivateChatPlayerList();
			}
			if (this.data != null && this.data.curPrivate != null && uieventDelPrivate.m_uid == this.data.curPrivate.uid)
			{
				ChatFrame.TabObject tabObject2 = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE);
				if (tabObject2 != null)
				{
					if (tabObject2.isOn)
					{
						CachedSelectedObject<ChatFrame.ChatTypeData, ChatFrame.TabObject>.Clear();
					}
					tabObject2.Disable();
					this.data.curPrivate = null;
				}
			}
			ChatFrame.TabObject tabObject3 = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE_LIST);
			if (tabObject3 != null)
			{
				tabObject3.SetRedPointActive(DataManager<RelationDataManager>.GetInstance().GetPriDirty());
			}
		}

		// Token: 0x0600D4EB RID: 54507 RVA: 0x00353C12 File Offset: 0x00352012
		private void _OnPrivateRdChanged(UIEvent uiEvent)
		{
			this.data = (uiEvent.Param1 as ChatFrameData);
			if (this.data != null)
			{
				this.SetTab(this.data.eChatType);
			}
		}

		// Token: 0x0600D4EC RID: 54508 RVA: 0x00353C41 File Offset: 0x00352041
		private void _OnRoleChatDirtyChanged(UIEvent uiEvent)
		{
			this.RefreshFriendIcon();
		}

		// Token: 0x0600D4ED RID: 54509 RVA: 0x00353C4C File Offset: 0x0035204C
		private void _OnPlayerOnLineStatusChanged(UIEvent uiEvent)
		{
			ChatFrame.TabObject tabObject = this.m_akTabObjects.Find((ChatFrame.TabObject x) => x.Value.eChatType == ChatType.CT_PRIVATE_LIST);
			if (tabObject != null && tabObject.isOn)
			{
				this._AddPrivateChatPlayerList();
			}
		}

		// Token: 0x0600D4EE RID: 54510 RVA: 0x00353C99 File Offset: 0x00352099
		private void _OnCounterChanged(UIEvent uiEvent)
		{
			if (uiEvent.Param1 as string == CounterKeys.COUNTER_ACTIVITY_VALUE || uiEvent.Param1 as string == CounterKeys.COUNTER_WORLD_FREE_CHAT_TIMES)
			{
				this._UpdateInputHoldplaceText();
			}
		}

		// Token: 0x0600D4EF RID: 54511 RVA: 0x00353CD8 File Offset: 0x003520D8
		private void _OnSetChatTab(UIEvent uiEvent)
		{
			ChatType tab = (ChatType)uiEvent.Param1;
			this.SetTab(tab);
		}

		// Token: 0x0600D4F0 RID: 54512 RVA: 0x00353CF8 File Offset: 0x003520F8
		private void _OnLockStatuNewMessageNumberChanged(UIEvent uiEvent)
		{
			ChatBlock chatBlock = uiEvent.Param1 as ChatBlock;
			if (chatBlock.chatData.channel == 3)
			{
				this.RefreshNewMessageBumber();
			}
		}

		// Token: 0x0600D4F1 RID: 54513 RVA: 0x00353D28 File Offset: 0x00352128
		private void _RefreshChatData(UIEvent uiEvent)
		{
			this.m_bDirty = true;
		}

		// Token: 0x0600D4F2 RID: 54514 RVA: 0x00353D31 File Offset: 0x00352131
		private void _OnInputEndEdit(string str)
		{
			this.m_closeRoot.SetActive(true);
		}

		// Token: 0x0600D4F3 RID: 54515 RVA: 0x00353D40 File Offset: 0x00352140
		private bool IsRecordVoiceLimited()
		{
			if (this.data.eChatType == ChatType.CT_WORLD)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(172, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_world_talk_need_level"), tableItem.Value), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return true;
				}
				int freeWorldChatLeftTimes = DataManager<ChatManager>.GetInstance().FreeWorldChatLeftTimes;
				if (freeWorldChatLeftTimes <= 0 && !DataManager<ChatManager>.GetInstance().CheckWorldActivityValueEnough())
				{
					SystemNotifyManager.SystemNotify(7006, delegate()
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.VIP, string.Empty);
					});
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_ACOMMPANY)
			{
				SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(174, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_team_talk_need_level"), tableItem2.Value), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_NORMAL)
			{
				SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(173, string.Empty, string.Empty);
				if (tableItem3 != null && tableItem3.Value > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("chat_normal_talk_need_level"), tableItem3.Value), CommonTipsDesc.eShowMode.SI_UNIQUE);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D4F4 RID: 54516 RVA: 0x00353EDC File Offset: 0x003522DC
		private bool IsSendChatCoolDown()
		{
			if (this.data.eChatType == ChatType.CT_WORLD)
			{
				if (!this.world_chat_try_enter_cool_down())
				{
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_ACOMMPANY)
			{
				if (!this.accompany_chat_try_enter_cool_down())
				{
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_NORMAL)
			{
				if (!this.arround_chat_try_enter_cool_down())
				{
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE)
			{
				if (!this.teamcopy_prepare_chat_try_enter_cool_down())
				{
					return true;
				}
			}
			else if (this.data.eChatType == ChatType.CT_TEAM_COPY_PREPARE && !this.teamcopy_team_chat_try_enter_cool_down())
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600D4F5 RID: 54517 RVA: 0x00353F96 File Offset: 0x00352396
		private void HideEmotionBar()
		{
			if (this.m_goEmotionTab != null)
			{
				this.m_goEmotionTab.CustomActive(false);
			}
		}

		// Token: 0x0600D4F6 RID: 54518 RVA: 0x00353FB5 File Offset: 0x003523B5
		public void PlayVoice(string voiceKey, string chatTime, ChatVoiceInPlay voicePlayInQueue)
		{
			if (this.voiceChatModule != null)
			{
				this.voiceChatModule.PlayOnChatVoice(voiceKey, chatTime, voicePlayInQueue);
			}
		}

		// Token: 0x0600D4F7 RID: 54519 RVA: 0x00353FD0 File Offset: 0x003523D0
		[UIEventHandle("ScrollviewBg/InputField/VoiceInput/Laba")]
		private void _OnOpenHornFrame()
		{
			if (this.frameMgr.IsFrameOpen<Pk3v3CrossWaitingRoom>(null))
			{
				return;
			}
			if (Pk3v3DataManager.HasInPk3v3Room())
			{
				return;
			}
			HornFrame.Open();
			base.Close(false);
		}

		// Token: 0x0600D4F8 RID: 54520 RVA: 0x00353FFB File Offset: 0x003523FB
		private void RefreshFriendIcon()
		{
			if (DataManager<RelationDataManager>.GetInstance().GetPriDirty())
			{
				this.goFriend.CustomActive(true);
			}
			else
			{
				this.goFriend.CustomActive(false);
			}
		}

		// Token: 0x0600D4F9 RID: 54521 RVA: 0x00354029 File Offset: 0x00352429
		[UIEventHandle("tabs/Friend")]
		private void OnFriendButtonClick()
		{
			RelationFrameNew.CommandOpen(null);
			this.frameMgr.CloseFrame<ChatFrame>(this, false);
		}

		// Token: 0x0600D4FA RID: 54522 RVA: 0x00354040 File Offset: 0x00352440
		private void RefreshNewMessageBumber()
		{
			if (this.screenLocked)
			{
				this.newMessageNumber++;
				this.goNewMessageBumber.CustomActive(true);
				if (this.mNewMessageText != null)
				{
					this.mNewMessageText.text = string.Format("有{0}条新消息", this.newMessageNumber);
				}
			}
			else
			{
				this.goNewMessageBumber.CustomActive(false);
			}
		}

		// Token: 0x0600D4FB RID: 54523 RVA: 0x003540B4 File Offset: 0x003524B4
		[UIEventHandle("ScrollviewBg/newmessagenumber")]
		private void OnNewMessageNumberClick()
		{
			this.screenLocked = false;
			this.MarkChatDataDirty();
			this.goNewMessageBumber.CustomActive(false);
			this.newMessageNumber = 0;
		}

		// Token: 0x04007CF0 RID: 31984
		private bool m_bFirstEnter;

		// Token: 0x04007CF1 RID: 31985
		private static string ms_holdText = string.Empty;

		// Token: 0x04007CF2 RID: 31986
		private ChatFrameData data = new ChatFrameData();

		// Token: 0x04007CF3 RID: 31987
		private ComChatList comChatList = new ComChatList();

		// Token: 0x04007CF4 RID: 31988
		private VoiceChatModule voiceChatModule;

		// Token: 0x04007CF5 RID: 31989
		[UIControl("ScrollviewBg/Scrollview", typeof(ScrollRect), 0)]
		private ScrollRect scrollrect;

		// Token: 0x04007CF6 RID: 31990
		[UIControl("", typeof(ComScriptBinder), 0)]
		private ComScriptBinder mScriptBinder;

		// Token: 0x04007CF7 RID: 31991
		private IClientFrame m_openMenu;

		// Token: 0x04007CF8 RID: 31992
		private GameObject m_goTabParent;

		// Token: 0x04007CF9 RID: 31993
		private GameObject m_goTabPrefab;

		// Token: 0x04007CFA RID: 31994
		private List<CommonPlayerInfo> m_chatPlayerList = new List<CommonPlayerInfo>();

		// Token: 0x04007CFB RID: 31995
		private GameObject m_inputFieldRoot;

		// Token: 0x04007CFC RID: 31996
		private GameObject m_closeRoot;

		// Token: 0x04007CFD RID: 31997
		[UIControl("ScrollviewBg/InputField/Button/Input", null, 0)]
		private OnFocusInputField Input;

		// Token: 0x04007CFE RID: 31998
		[UIControl("Bottom/Text", typeof(LinkParse), 0)]
		private LinkParse friendlyHint;

		// Token: 0x04007CFF RID: 31999
		private CachedObjectListManager<ChatFrame.TabObject> m_akTabObjects = new CachedObjectListManager<ChatFrame.TabObject>();

		// Token: 0x04007D00 RID: 32000
		[UIControl("ScrollviewBg/Scrollview/TipText", typeof(Text), 0)]
		private Text m_kTextChatHint;

		// Token: 0x04007D01 RID: 32001
		private bool screenLocked;

		// Token: 0x04007D02 RID: 32002
		[UIControl("ScrollviewBg/InputField/Button/Input", typeof(OnFocusInputField), 0)]
		private OnFocusInputField m_inputField;

		// Token: 0x04007D03 RID: 32003
		private GameObject m_goEmotionTab;

		// Token: 0x04007D04 RID: 32004
		private GameObject m_goEmotionPrefab;

		// Token: 0x04007D05 RID: 32005
		private SpriteAsset m_spriteAsset;

		// Token: 0x04007D06 RID: 32006
		private CachedObjectDicManager<int, ChatFrame.EmotionObject> m_akEmotionObjects = new CachedObjectDicManager<int, ChatFrame.EmotionObject>();

		// Token: 0x04007D07 RID: 32007
		private bool m_bDirty;

		// Token: 0x04007D08 RID: 32008
		[UIObject("tabs/Friend")]
		private GameObject goFriend;

		// Token: 0x04007D09 RID: 32009
		[UIObject("ScrollviewBg/newmessagenumber")]
		private GameObject goNewMessageBumber;

		// Token: 0x04007D0A RID: 32010
		[UIControl("ScrollviewBg/newmessagenumber/Text", null, 0)]
		private Text mNewMessageText;

		// Token: 0x04007D0B RID: 32011
		private int newMessageNumber;

		// Token: 0x02001548 RID: 5448
		private class ChatTypeData
		{
			// Token: 0x04007D18 RID: 32024
			public ChatType eChatType;

			// Token: 0x04007D19 RID: 32025
			public string content;
		}

		// Token: 0x02001549 RID: 5449
		private class TabObject : CachedSelectedObject<ChatFrame.ChatTypeData, ChatFrame.TabObject>
		{
			// Token: 0x0600D50F RID: 54543 RVA: 0x003543EC File Offset: 0x003527EC
			public override void Initialize()
			{
				this.labelText = Utility.FindComponent<Text>(this.goLocal, "Label", true);
				this.labelMarkText = Utility.FindComponent<Text>(this.goLocal, "Checkmark/Label", true);
				this.m_redPt = Utility.FindComponent<Image>(this.goLocal, "RedPt", true);
				this.m_redPt.CustomActive(false);
				this.goCheckMark = Utility.FindChild(this.goLocal, "Checkmark");
			}

			// Token: 0x0600D510 RID: 54544 RVA: 0x00354460 File Offset: 0x00352860
			public override void UnInitialize()
			{
			}

			// Token: 0x0600D511 RID: 54545 RVA: 0x00354464 File Offset: 0x00352864
			public override void OnUpdate()
			{
				if (base.Value != null)
				{
					if (this.labelText != null)
					{
						this.labelText.text = base.Value.content;
					}
					if (this.labelMarkText != null)
					{
						this.labelMarkText.text = base.Value.content;
					}
				}
			}

			// Token: 0x0600D512 RID: 54546 RVA: 0x003544CA File Offset: 0x003528CA
			public override void OnDisplayChanged(bool bShow)
			{
				if (this.goCheckMark != null)
				{
					this.goCheckMark.CustomActive(bShow);
				}
			}

			// Token: 0x0600D513 RID: 54547 RVA: 0x003544E9 File Offset: 0x003528E9
			public void SetRedPointActive(bool active)
			{
				this.m_redPt.gameObject.SetActive(active);
			}

			// Token: 0x04007D1A RID: 32026
			private Text labelText;

			// Token: 0x04007D1B RID: 32027
			private Text labelMarkText;

			// Token: 0x04007D1C RID: 32028
			private Image m_redPt;

			// Token: 0x04007D1D RID: 32029
			private GameObject goCheckMark;
		}

		// Token: 0x0200154A RID: 5450
		public class EmotionObject : CachedObject
		{
			// Token: 0x0600D515 RID: 54549 RVA: 0x00354504 File Offset: 0x00352904
			public override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.spriteAssetInfo = (param[2] as SpriteAssetInfor);
				this.THIS = (param[3] as ChatFrame);
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

			// Token: 0x0600D516 RID: 54550 RVA: 0x003545D7 File Offset: 0x003529D7
			public override void OnRecycle()
			{
				this.Disable();
			}

			// Token: 0x0600D517 RID: 54551 RVA: 0x003545DF File Offset: 0x003529DF
			public override void Enable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0600D518 RID: 54552 RVA: 0x003545FE File Offset: 0x003529FE
			public override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0600D519 RID: 54553 RVA: 0x0035461D File Offset: 0x00352A1D
			public override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600D51A RID: 54554 RVA: 0x00354626 File Offset: 0x00352A26
			public override void OnRefresh(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0600D51B RID: 54555 RVA: 0x0035462F File Offset: 0x00352A2F
			public override bool NeedFilter(object[] param)
			{
				return false;
			}

			// Token: 0x0600D51C RID: 54556 RVA: 0x00354632 File Offset: 0x00352A32
			private void _UpdateItem()
			{
				this.emotion.sprite = this.spriteAssetInfo.sprite;
			}

			// Token: 0x0600D51D RID: 54557 RVA: 0x0035464A File Offset: 0x00352A4A
			private void OnClickEmotion()
			{
				this.THIS.AddChatText("{F " + string.Format("{0}", this.spriteAssetInfo.ID) + "}");
			}

			// Token: 0x04007D1E RID: 32030
			protected GameObject goLocal;

			// Token: 0x04007D1F RID: 32031
			protected GameObject goParent;

			// Token: 0x04007D20 RID: 32032
			protected GameObject goPrefab;

			// Token: 0x04007D21 RID: 32033
			protected SpriteAssetInfor spriteAssetInfo;

			// Token: 0x04007D22 RID: 32034
			protected ChatFrame THIS;

			// Token: 0x04007D23 RID: 32035
			private Image emotion;

			// Token: 0x04007D24 RID: 32036
			private Button button;
		}
	}
}
