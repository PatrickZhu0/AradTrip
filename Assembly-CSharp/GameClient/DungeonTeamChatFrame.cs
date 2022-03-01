using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010BB RID: 4283
	public class DungeonTeamChatFrame : ClientFrame
	{
		// Token: 0x0600A1B4 RID: 41396 RVA: 0x0020EC32 File Offset: 0x0020D032
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Chat/DungeonTeamChatFrame";
		}

		// Token: 0x0600A1B5 RID: 41397 RVA: 0x0020EC3C File Offset: 0x0020D03C
		protected override void _bindExUI()
		{
			this.mEasyChat = this.mBind.GetCom<Toggle>("EasyChatToggle");
			if (this.mEasyChat != null)
			{
				this.mEasyChat.onValueChanged.AddListener(new UnityAction<bool>(this._onEasyChatToggleClick));
			}
			this.mChatRecord = this.mBind.GetCom<Toggle>("ChatRecordToggle");
			if (this.mChatRecord != null)
			{
				this.mChatRecord.onValueChanged.AddListener(new UnityAction<bool>(this._onChatRecordToggleClick));
			}
			this.mSocialBtn = this.mBind.GetCom<Button>("SocialBtn");
			if (this.mSocialBtn != null)
			{
				this.mSocialBtn.onClick.AddListener(new UnityAction(this._onSocialBtnClick));
			}
			this.mChangeChannel = this.mBind.GetCom<Toggle>("changeChannel");
			if (this.mChangeChannel != null)
			{
				this.mChangeChannel.onValueChanged.AddListener(new UnityAction<bool>(this._onChangeChannelToggleValueChange));
			}
			this.mChannel = this.mBind.GetCom<Text>("channelText");
			this.mEasyChatTips = this.mBind.GetCom<ComUIListScript>("easyChatTipsList");
			this.mChatRecordList = this.mBind.GetCom<ComUIListScript>("chatRecordList");
			this.mInputField = this.mBind.GetCom<OnFocusInputField>("ChatInputField");
			if (this.mInputField != null)
			{
				this.mInputField.onValueChanged.AddListener(new UnityAction<string>(this.OnInputValueChanged));
				OnFocusInputField onFocusInputField = this.mInputField;
				onFocusInputField.onClick = (OnFocusInputField.OnClick)Delegate.Combine(onFocusInputField.onClick, new OnFocusInputField.OnClick(this.OnInputFieldClick));
				this.mInputField.onEndEdit.AddListener(new UnityAction<string>(this.OnInputFieldEndEdit));
			}
			this.mSendMsgBtn = this.mBind.GetCom<Button>("SendMsgBtn");
			if (this.mSendMsgBtn != null)
			{
				this.mSendMsgBtn.onClick.AddListener(new UnityAction(this.OnClickSendChatContent));
			}
			this.mCloseBtn = this.mBind.GetCom<Button>("closeBtn");
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.AddListener(new UnityAction(this._onCloseBtnClick));
			}
			this.mWorldChatBtn = this.mBind.GetCom<Button>("worldChatBtn");
			if (this.mWorldChatBtn != null)
			{
				this.mWorldChatBtn.onClick.AddListener(new UnityAction(this._onWorldChatBtnClick));
			}
		}

		// Token: 0x0600A1B6 RID: 41398 RVA: 0x0020EEE8 File Offset: 0x0020D2E8
		protected override void _unbindExUI()
		{
			if (this.mEasyChat != null)
			{
				this.mEasyChat.onValueChanged.RemoveListener(new UnityAction<bool>(this._onEasyChatToggleClick));
			}
			this.mEasyChat = null;
			if (this.mChatRecord != null)
			{
				this.mChatRecord.onValueChanged.RemoveListener(new UnityAction<bool>(this._onChatRecordToggleClick));
			}
			this.mChatRecord = null;
			if (this.mSocialBtn != null)
			{
				this.mSocialBtn.onClick.RemoveListener(new UnityAction(this._onSocialBtnClick));
			}
			this.mSocialBtn = null;
			if (this.mChangeChannel != null)
			{
				this.mChangeChannel.onValueChanged.RemoveListener(new UnityAction<bool>(this._onChangeChannelToggleValueChange));
			}
			this.mChangeChannel = null;
			this.mChannel = null;
			this.mEasyChatTips = null;
			this.mChatRecordList = null;
			if (this.mInputField != null)
			{
				this.mInputField.onValueChanged.RemoveListener(new UnityAction<string>(this.OnInputValueChanged));
				OnFocusInputField onFocusInputField = this.mInputField;
				onFocusInputField.onClick = (OnFocusInputField.OnClick)Delegate.Remove(onFocusInputField.onClick, new OnFocusInputField.OnClick(this.OnInputFieldClick));
				this.mInputField.onEndEdit.RemoveListener(new UnityAction<string>(this.OnInputFieldEndEdit));
			}
			if (this.mSendMsgBtn != null)
			{
				this.mSendMsgBtn.onClick.RemoveListener(new UnityAction(this.OnClickSendChatContent));
			}
			this.mSendMsgBtn = null;
			if (this.mCloseBtn != null)
			{
				this.mCloseBtn.onClick.RemoveListener(new UnityAction(this._onCloseBtnClick));
			}
			this.mCloseBtn = null;
			if (this.mWorldChatBtn != null)
			{
				this.mWorldChatBtn.onClick.RemoveListener(new UnityAction(this._onWorldChatBtnClick));
			}
		}

		// Token: 0x0600A1B7 RID: 41399 RVA: 0x0020F0DF File Offset: 0x0020D4DF
		private void _onEasyChatToggleClick(bool flag)
		{
			if (this.mEasyChatTips != null)
			{
				this.mEasyChatTips.gameObject.SetActive(flag);
			}
		}

		// Token: 0x0600A1B8 RID: 41400 RVA: 0x0020F104 File Offset: 0x0020D504
		private void _onChatRecordToggleClick(bool flag)
		{
			if (this.mChatRecord != null)
			{
				this.mChatRecordList.gameObject.SetActive(flag);
				int chatDataArrayLength = DataManager<BattleEasyChatDataManager>.GetInstance().GetChatDataArrayLength();
				if (chatDataArrayLength > 0)
				{
					this.mChatRecordList.SetElementAmount(chatDataArrayLength, DataManager<BattleEasyChatDataManager>.GetInstance().GetChatDataArraySize());
					if (chatDataArrayLength > 0)
					{
						this.mChatRecordList.EnsureElementVisable(chatDataArrayLength - 1);
					}
				}
			}
		}

		// Token: 0x0600A1B9 RID: 41401 RVA: 0x0020F170 File Offset: 0x0020D570
		private void _onSocialBtnClick()
		{
			if (BeUtility.IsRaidBattle())
			{
				SystemNotifyManager.SysNotifyTextAnimation("团本地下城点击无效", CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				RelationFrameNew.CommandOpen(null);
			}
		}

		// Token: 0x0600A1BA RID: 41402 RVA: 0x0020F192 File Offset: 0x0020D592
		private void _onCloseBtnClick()
		{
			base.Close(false);
		}

		// Token: 0x0600A1BB RID: 41403 RVA: 0x0020F19B File Offset: 0x0020D59B
		public void _onWorldChatBtnClick()
		{
			if (!this.isRaidBattle)
			{
				DataManager<ChatManager>.GetInstance().OpenTeamChatFrame();
				base.Close(false);
			}
		}

		// Token: 0x0600A1BC RID: 41404 RVA: 0x0020F1BC File Offset: 0x0020D5BC
		private void _onChangeChannelToggleValueChange(bool flag)
		{
			if (flag)
			{
				if (this.isRaidBattle)
				{
					DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType = ChatType.CT_TEAM_COPY_SQUAD;
				}
				else
				{
					DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType = ChatType.CT_TEAM;
				}
			}
			else if (this.isRaidBattle)
			{
				DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType = ChatType.CT_TEAM_COPY_TEAM;
			}
			if (this.mChannel != null)
			{
				this.mChannel.text = DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType.GetDescription(true);
			}
		}

		// Token: 0x0600A1BD RID: 41405 RVA: 0x0020F243 File Offset: 0x0020D643
		private void OnInputValueChanged(string value)
		{
			DungeonTeamChatFrame.ms_holdText = value;
		}

		// Token: 0x0600A1BE RID: 41406 RVA: 0x0020F24B File Offset: 0x0020D64B
		private void OnInputFieldClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonChatInputFieldOpen, null, null, null, null);
		}

		// Token: 0x0600A1BF RID: 41407 RVA: 0x0020F260 File Offset: 0x0020D660
		private void OnInputFieldEndEdit(string content)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonChatInputFieldClose, null, null, null, null);
		}

		// Token: 0x0600A1C0 RID: 41408 RVA: 0x0020F278 File Offset: 0x0020D678
		private void OnClickSendChatContent()
		{
			if (!string.IsNullOrEmpty(this.mInputField.text) && this.mInputField.text.Length < 100)
			{
				DataManager<BattleEasyChatDataManager>.GetInstance().SendBattleChatMsg(ChatFrame.GetFliterSizeString(this.mInputField.text));
				this.mInputField.text = string.Empty;
				base.Close(false);
			}
			else if (this.mInputField.text != null && this.mInputField.text.Length >= 100)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("chat_too_many_words"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600A1C1 RID: 41409 RVA: 0x0020F320 File Offset: 0x0020D720
		protected override void _OnOpenFrame()
		{
			object[] array = this.userData as object[];
			if (array == null)
			{
				return;
			}
			this.isRaidBattle = (bool)array[0];
			bool flag = (bool)array[1];
			this.InitChatChannel();
			this._InitEasyChatUIListScrollListBind();
			this._InitChatRecordUIListScrollListBind();
			if (this.mEasyChat != null)
			{
				this.mEasyChat.isOn = true;
			}
			if (this.mChatRecord)
			{
				this.mChatRecord.isOn = false;
			}
			if (this.mEasyChatTips != null && DataManager<BattleEasyChatDataManager>.GetInstance().mEasyChatTips != null)
			{
				this.mEasyChatTips.SetElementAmount(DataManager<BattleEasyChatDataManager>.GetInstance().mEasyChatTips.Count);
			}
			if (this.isRaidBattle)
			{
				this.mWorldChatBtn.enabled = false;
			}
			else
			{
				this.mSendMsgBtn.CustomActive(false);
				this.mInputField.enabled = false;
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonChatMsgDataUpdate, new ClientEventSystem.UIEventHandler(this._onReceiveChatDataMsg));
			this.bInitialize = true;
		}

		// Token: 0x0600A1C2 RID: 41410 RVA: 0x0020F432 File Offset: 0x0020D832
		protected override void _OnCloseFrame()
		{
			this.chatDatas.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonChatMsgDataUpdate, new ClientEventSystem.UIEventHandler(this._onReceiveChatDataMsg));
			this.bInitialize = false;
		}

		// Token: 0x0600A1C3 RID: 41411 RVA: 0x0020F464 File Offset: 0x0020D864
		private void InitChatChannel()
		{
			if (!this.isRaidBattle)
			{
				if (this.mChangeChannel != null)
				{
					this.mChangeChannel.isOn = true;
					this.mChangeChannel.enabled = false;
				}
			}
			else if (DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType == ChatType.CT_TEAM_COPY_SQUAD)
			{
				this.mChangeChannel.isOn = true;
				this.mChangeChannel.enabled = true;
			}
			else if (DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType == ChatType.CT_TEAM_COPY_TEAM)
			{
				this.mChangeChannel.isOn = false;
				this._onChangeChannelToggleValueChange(false);
				this.mChangeChannel.enabled = true;
			}
			else
			{
				DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType = ChatType.CT_TEAM_COPY_SQUAD;
				this.mChangeChannel.isOn = true;
				this.mChangeChannel.enabled = true;
			}
		}

		// Token: 0x0600A1C4 RID: 41412 RVA: 0x0020F534 File Offset: 0x0020D934
		private void _InitEasyChatUIListScrollListBind()
		{
			this.mEasyChatTips.Initialize();
			this.mEasyChatTips.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					EasyChatItem component = item.GetComponent<EasyChatItem>();
					if (component != null)
					{
						component.Init(item.m_index);
					}
				}
			};
			this.mEasyChatTips.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				if (item != null)
				{
					EasyChatItem component = item.GetComponent<EasyChatItem>();
					if (component != null)
					{
						component.Recycle();
					}
				}
			};
		}

		// Token: 0x0600A1C5 RID: 41413 RVA: 0x0020F59C File Offset: 0x0020D99C
		private void _InitChatRecordUIListScrollListBind()
		{
			this.mChatRecordList.Initialize();
			this.mChatRecordList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item != null && item.m_index >= 0)
				{
					ComCommonBind component = item.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					LinkParse com = component.GetCom<LinkParse>("linkParse");
					Image com2 = component.GetCom<Image>("Index");
					if (com == null)
					{
						return;
					}
					ChatBlock chatBlockByIndex = DataManager<BattleEasyChatDataManager>.GetInstance().GetChatBlockByIndex(item.m_index);
					if (chatBlockByIndex == null)
					{
						return;
					}
					try
					{
						if (chatBlockByIndex.chatData != null)
						{
							if (DataManager<BattleEasyChatDataManager>.GetInstance().DungeonChatType == ChatType.CT_TEAM)
							{
								if (com2 != null)
								{
									com2.gameObject.SetActive(false);
								}
								com.SetText(string.Format("{0}{1}:{2}", chatBlockByIndex.chatData.GetChannelString(), chatBlockByIndex.chatData.objname, chatBlockByIndex.chatData.GetWords()), true);
							}
							else
							{
								int num = TeamDuplicationUtility.GetTeamDuplicationCaptainIdByPlayerGuid(chatBlockByIndex.chatData.objid) - 1;
								if (com2 != null)
								{
									com2.gameObject.SetActive(true);
									if (num >= 0 && num < DungeonTeamChatFrame.INDEX_PATH_ARRAY.Length)
									{
										ETCImageLoader.LoadSprite(ref com2, DungeonTeamChatFrame.INDEX_PATH_ARRAY[num], true);
									}
								}
								com.SetText(string.Format("<color=#00000000>XX</color>{0}{1}:{2}", chatBlockByIndex.chatData.GetChannelString(), chatBlockByIndex.chatData.objname, chatBlockByIndex.chatData.GetWords()), true);
							}
						}
					}
					catch (Exception ex)
					{
						Logger.LogError(ex.ToString());
					}
				}
			};
		}

		// Token: 0x0600A1C6 RID: 41414 RVA: 0x0020F5D4 File Offset: 0x0020D9D4
		private void _onReceiveChatDataMsg(UIEvent ui)
		{
			if (this.mChatRecord.isOn)
			{
				int chatDataArrayLength = DataManager<BattleEasyChatDataManager>.GetInstance().GetChatDataArrayLength();
				if (chatDataArrayLength > 0)
				{
					this.mChatRecordList.SetElementAmount(chatDataArrayLength, DataManager<BattleEasyChatDataManager>.GetInstance().GetChatDataArraySize());
					if (chatDataArrayLength > 0)
					{
						this.mChatRecordList.EnsureElementVisable(chatDataArrayLength - 1);
					}
				}
			}
			if (!this.mChatRecord.isOn)
			{
				this.mChatRecord.isOn = true;
				this.mEasyChat.isOn = false;
			}
		}

		// Token: 0x04005A31 RID: 23089
		private Toggle mEasyChat;

		// Token: 0x04005A32 RID: 23090
		private Toggle mChatRecord;

		// Token: 0x04005A33 RID: 23091
		private Button mSocialBtn;

		// Token: 0x04005A34 RID: 23092
		private Toggle mChangeChannel;

		// Token: 0x04005A35 RID: 23093
		private Text mChannel;

		// Token: 0x04005A36 RID: 23094
		private ComUIListScript mEasyChatTips;

		// Token: 0x04005A37 RID: 23095
		private ComUIListScript mChatRecordList;

		// Token: 0x04005A38 RID: 23096
		private OnFocusInputField mInputField;

		// Token: 0x04005A39 RID: 23097
		private Button mSendMsgBtn;

		// Token: 0x04005A3A RID: 23098
		private Button mCloseBtn;

		// Token: 0x04005A3B RID: 23099
		private Button mWorldChatBtn;

		// Token: 0x04005A3C RID: 23100
		private bool isRaidBattle;

		// Token: 0x04005A3D RID: 23101
		private bool bInitialize;

		// Token: 0x04005A3E RID: 23102
		private List<ChatData> chatDatas = new List<ChatData>();

		// Token: 0x04005A3F RID: 23103
		private static string ms_holdText = string.Empty;

		// Token: 0x04005A40 RID: 23104
		private static string[] INDEX_PATH_ARRAY = new string[]
		{
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_1",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_2",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_3",
			"UI/Image/Packed/p_UI_Battle_Pve.png:UI_Battle_Shuzi_4"
		};
	}
}
