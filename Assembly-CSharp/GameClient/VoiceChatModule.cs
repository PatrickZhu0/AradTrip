using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x0200155A RID: 5466
	public class VoiceChatModule
	{
		// Token: 0x17001C0D RID: 7181
		// (get) Token: 0x0600D571 RID: 54641 RVA: 0x0035563E File Offset: 0x00353A3E
		public bool IsInitilized
		{
			get
			{
				return this.isInitialized;
			}
		}

		// Token: 0x17001C0E RID: 7182
		// (get) Token: 0x0600D572 RID: 54642 RVA: 0x00355646 File Offset: 0x00353A46
		public bool IsRecordVoiceEnabled
		{
			get
			{
				return this.isRecordVoiceEnabled;
			}
		}

		// Token: 0x17001C0F RID: 7183
		// (get) Token: 0x0600D573 RID: 54643 RVA: 0x0035564E File Offset: 0x00353A4E
		public bool IsSendVoiceEnabled
		{
			get
			{
				return this.isSendVoiceEnabled;
			}
		}

		// Token: 0x17001C10 RID: 7184
		// (get) Token: 0x0600D574 RID: 54644 RVA: 0x00355656 File Offset: 0x00353A56
		// (set) Token: 0x0600D575 RID: 54645 RVA: 0x00355674 File Offset: 0x00353A74
		public VoiceButtonUsed currentUsedButton
		{
			get
			{
				if (this._currentUsedButton == null)
				{
					this._currentUsedButton = new VoiceButtonUsed();
				}
				return this._currentUsedButton;
			}
			set
			{
				this._currentUsedButton = value;
			}
		}

		// Token: 0x17001C11 RID: 7185
		// (get) Token: 0x0600D576 RID: 54646 RVA: 0x0035567D File Offset: 0x00353A7D
		// (set) Token: 0x0600D577 RID: 54647 RVA: 0x00355685 File Offset: 0x00353A85
		public bool CanSendVoice
		{
			get
			{
				return this.canSendVoice;
			}
			set
			{
				this.canSendVoice = value;
			}
		}

		// Token: 0x0600D578 RID: 54648 RVA: 0x00355690 File Offset: 0x00353A90
		public void Init()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoice)
			{
				return;
			}
			if (this.isInitialized)
			{
				return;
			}
			this.isInitialized = true;
			this.AddUIHandler();
			this.sdkInterface = Singleton<SDKVoiceManager>.GetInstance().GetCurrVoiceInterface();
			this.teamVoiceBtnList = new List<VoiceInputBtn>();
			this.guildVoiceBtnList = new List<VoiceInputBtn>();
		}

		// Token: 0x0600D579 RID: 54649 RVA: 0x003556EC File Offset: 0x00353AEC
		public void Unint()
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoice)
			{
				return;
			}
			this.isInitialized = false;
			this.RemoveUIHandler();
			this.UnBindRoot(VoiceInputType.ChatFrame, this.chatFrameVoiceBtn);
			if (this.guildVoiceBtnList != null)
			{
				for (int i = 0; i < this.guildVoiceBtnList.Count; i++)
				{
					VoiceInputBtn voiceBtn = this.guildVoiceBtnList[i];
					this.UnBindRoot(VoiceInputType.ComtalkGuild, voiceBtn);
				}
			}
			if (this.teamVoiceBtnList != null)
			{
				for (int j = 0; j < this.teamVoiceBtnList.Count; j++)
				{
					VoiceInputBtn voiceBtn2 = this.teamVoiceBtnList[j];
					this.UnBindRoot(VoiceInputType.ComtalkTeam, voiceBtn2);
				}
			}
			this.chatType = ChatType.CT_ALL;
			this.tempChatRichVoice = null;
			this.sdkInterface = null;
			this.chatFrameVoiceBtn = null;
			if (this.teamVoiceBtnList != null)
			{
				this.teamVoiceBtnList.Clear();
			}
			if (this.guildVoiceBtnList != null)
			{
				this.guildVoiceBtnList.Clear();
			}
			this.teamVoiceBtnList = null;
			this.guildVoiceBtnList = null;
			this._currentUsedButton = null;
		}

		// Token: 0x0600D57A RID: 54650 RVA: 0x003557F8 File Offset: 0x00353BF8
		private void AddUIHandler()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatRecordEnd, new ClientEventSystem.UIEventHandler(this.OnRecordVoiceEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatRecordFailed, new ClientEventSystem.UIEventHandler(this.OnRecordVoiceFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatSendStart, new ClientEventSystem.UIEventHandler(this.OnSendVoiceStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatSendSucc, new ClientEventSystem.UIEventHandler(this.OnSendVoiceSucc));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatSendFailed, new ClientEventSystem.UIEventHandler(this.OnSendVoiceFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPlayEnd, new ClientEventSystem.UIEventHandler(this.OnPlayChatVoiceEnd));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatMicNoAuth, new ClientEventSystem.UIEventHandler(this.OnMicAutoNoEnabled));
		}

		// Token: 0x0600D57B RID: 54651 RVA: 0x003558C4 File Offset: 0x00353CC4
		private void RemoveUIHandler()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatRecordEnd, new ClientEventSystem.UIEventHandler(this.OnRecordVoiceEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatRecordFailed, new ClientEventSystem.UIEventHandler(this.OnRecordVoiceFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatSendStart, new ClientEventSystem.UIEventHandler(this.OnSendVoiceStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatSendSucc, new ClientEventSystem.UIEventHandler(this.OnSendVoiceSucc));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatSendFailed, new ClientEventSystem.UIEventHandler(this.OnSendVoiceFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPlayEnd, new ClientEventSystem.UIEventHandler(this.OnPlayChatVoiceEnd));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatMicNoAuth, new ClientEventSystem.UIEventHandler(this.OnMicAutoNoEnabled));
		}

		// Token: 0x0600D57C RID: 54652 RVA: 0x00355990 File Offset: 0x00353D90
		public void BindRoot(GameObject root, VoiceInputType btnType, ChatFrameData cdata, VoiceChatModule.IsSatisfiedWithWTalkCondition CheckTalkCondition, VoiceChatModule.IsRecordVoiceLimited IsRecordVoiceLimited, VoiceChatModule.HideEmotion hideEmotion)
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoice)
			{
				return;
			}
			if (btnType == VoiceInputType.ChatFrame)
			{
				this.root = root;
				this.chatFrameData = cdata;
				this.Hide_Emotion = hideEmotion;
				this.Is_RecordVoice_Limited = IsRecordVoiceLimited;
				this.Is_satisfied_with_talk_condition = CheckTalkCondition;
				this.InitVoiceFrameBtn(btnType);
				this.AddVoiceChangeBtnListener();
				if (this.chatFrameVoiceBtn != null)
				{
					this.chatFrameVoiceBtn.AddStartRecordListener(new VoiceInputBtn.StartRecordSendAudio(this.OnVoiceInputBtnStartRecord));
					this.chatFrameVoiceBtn.AddStopRecordListener(new VoiceInputBtn.StopRecordAudio(this.OnVoiceInputBtnStopRecord));
					this.chatFrameVoiceBtn.AddCancelRecordListener(new VoiceInputBtn.CancelRecordAudio(this.OnVoiceInputBtnCancelRecord));
				}
			}
		}

		// Token: 0x0600D57D RID: 54653 RVA: 0x00355A40 File Offset: 0x00353E40
		public void BindRoot(GameObject parent, VoiceInputType btnType, ScrollRect scrollRect = null)
		{
			float num = 85f;
			int num2 = 85;
			if (int.TryParse(TR.Value("voice_sdk_comtalk_voice_btn_width"), out num2))
			{
				num = (float)num2;
			}
			if (btnType == VoiceInputType.ComtalkGuild)
			{
				VoiceInputBtn voiceInputBtn = null;
				if (parent)
				{
					voiceInputBtn = Utility.GetComponetInChild<VoiceInputBtn>(parent, "VoiceSend");
					RectTransform component = parent.GetComponent<RectTransform>();
					if (component)
					{
						component.sizeDelta = new Vector2(num, num);
					}
				}
				if (voiceInputBtn != null)
				{
					RectTransform component2 = voiceInputBtn.GetComponent<RectTransform>();
					if (component2)
					{
						component2.sizeDelta = new Vector2(num, num);
					}
					voiceInputBtn.InitComponent(this, btnType);
					voiceInputBtn.AddStartRecordListener(new VoiceInputBtn.StartRecordSendAudio(this.OnVoiceInputBtnStartRecord));
					voiceInputBtn.AddStopRecordListener(new VoiceInputBtn.StopRecordAudio(this.OnVoiceInputBtnStopRecord));
					voiceInputBtn.AddCancelRecordListener(new VoiceInputBtn.CancelRecordAudio(this.OnVoiceInputBtnCancelRecord));
				}
				if (this.guildVoiceBtnList == null)
				{
					return;
				}
				if (!this.guildVoiceBtnList.Contains(voiceInputBtn))
				{
					this.guildVoiceBtnList.Add(voiceInputBtn);
				}
			}
			else if (btnType == VoiceInputType.ComtalkTeam)
			{
				VoiceInputBtn voiceInputBtn2 = null;
				if (parent)
				{
					voiceInputBtn2 = Utility.GetComponetInChild<VoiceInputBtn>(parent, "VoiceSend");
					RectTransform component3 = parent.GetComponent<RectTransform>();
					if (component3)
					{
						component3.sizeDelta = new Vector2(num, num);
					}
				}
				if (voiceInputBtn2 != null)
				{
					RectTransform component4 = voiceInputBtn2.GetComponent<RectTransform>();
					if (component4)
					{
						component4.sizeDelta = new Vector2(num, num);
					}
					voiceInputBtn2.InitComponent(this, btnType);
					voiceInputBtn2.AddStartRecordListener(new VoiceInputBtn.StartRecordSendAudio(this.OnVoiceInputBtnStartRecord));
					voiceInputBtn2.AddStopRecordListener(new VoiceInputBtn.StopRecordAudio(this.OnVoiceInputBtnStopRecord));
					voiceInputBtn2.AddCancelRecordListener(new VoiceInputBtn.CancelRecordAudio(this.OnVoiceInputBtnCancelRecord));
				}
				if (this.teamVoiceBtnList == null)
				{
					return;
				}
				if (!this.teamVoiceBtnList.Contains(voiceInputBtn2))
				{
					this.teamVoiceBtnList.Add(voiceInputBtn2);
				}
			}
		}

		// Token: 0x0600D57E RID: 54654 RVA: 0x00355C2C File Offset: 0x0035402C
		public void UnBindRoot(VoiceInputType btnType, VoiceInputBtn voiceBtn = null)
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoice)
			{
				return;
			}
			if (btnType == VoiceInputType.ChatFrame)
			{
				this.root = null;
				this.chatFrameData = null;
				this.Is_RecordVoice_Limited = null;
				this.Hide_Emotion = null;
				this.Is_satisfied_with_talk_condition = null;
				this.voiceSend = null;
				this.voiceInputRoot = null;
				this.changeInputModeBtn = null;
				this.voiceSprite = null;
				this.keyboardSprite = null;
				this.voiceSendBtnRect = null;
				this.voiceSendOriginalRectPos = Vector2.zero;
				this.ResetInputMode();
				this.RemoveVoiceChangeBtnListener();
				if (this.chatFrameVoiceBtn != null)
				{
					this.chatFrameVoiceBtn.UnInitComponent();
					this.chatFrameVoiceBtn.RemoveAllStartRecordListener();
					this.chatFrameVoiceBtn.RemoveAllStopRecordListener();
					this.chatFrameVoiceBtn.RemoveAllCancelRecordListener();
					this.chatFrameVoiceBtn = null;
				}
			}
			else if (btnType == VoiceInputType.ComtalkGuild)
			{
				if (voiceBtn == null)
				{
					return;
				}
				if (this.guildVoiceBtnList == null)
				{
					return;
				}
				if (this.guildVoiceBtnList.Contains(voiceBtn) && voiceBtn != null)
				{
					voiceBtn.UnInitComponent();
					voiceBtn.RemoveAllStartRecordListener();
					voiceBtn.RemoveAllStopRecordListener();
					voiceBtn.RemoveAllCancelRecordListener();
					this.guildVoiceBtnList.Remove(voiceBtn);
					voiceBtn = null;
				}
			}
			else if (btnType == VoiceInputType.ComtalkTeam)
			{
				if (voiceBtn == null)
				{
					return;
				}
				if (this.teamVoiceBtnList == null)
				{
					return;
				}
				if (this.teamVoiceBtnList.Contains(voiceBtn) && voiceBtn != null)
				{
					voiceBtn.UnInitComponent();
					voiceBtn.RemoveAllStartRecordListener();
					voiceBtn.RemoveAllStopRecordListener();
					voiceBtn.RemoveAllCancelRecordListener();
					this.teamVoiceBtnList.Remove(voiceBtn);
					voiceBtn = null;
				}
			}
		}

		// Token: 0x0600D57F RID: 54655 RVA: 0x00355DCC File Offset: 0x003541CC
		private void InitVoiceFrameBtn(VoiceInputType btnType)
		{
			if (this.root == null)
			{
				return;
			}
			this.changeInputModeBtn = Utility.FindComponent<Button>(this.root, "ChangeInputMode", false);
			this.voiceSend = Utility.FindGameObject(this.root, "VoiceSend", true);
			if (this.voiceInputRoot)
			{
				this.voiceInputRoot.SetActive(true);
			}
			if (this.voiceSend)
			{
				this.chatFrameVoiceBtn = this.voiceSend.GetComponent<VoiceInputBtn>();
				this.voiceSend.SetActive(true);
				this.voiceSendBtnRect = this.voiceSend.GetComponent<RectTransform>();
				this.voiceSendOriginalRectPos = this.voiceSendBtnRect.anchoredPosition;
			}
			if (this.changeInputModeBtn)
			{
				this.changeInputModeBtn.gameObject.SetActive(true);
				this.voiceSprite = Utility.FindComponent<Image>(this.changeInputModeBtn.gameObject, "voice", false);
				this.keyboardSprite = Utility.FindComponent<Image>(this.changeInputModeBtn.gameObject, "keyboard", false);
			}
			if (this.chatFrameVoiceBtn)
			{
				this.chatFrameVoiceBtn.InitComponent(this, btnType);
			}
		}

		// Token: 0x0600D580 RID: 54656 RVA: 0x00355EFC File Offset: 0x003542FC
		private void OnClickVoiceInputChange()
		{
			this.isVoiceSendShow = !this.isVoiceSendShow;
			if (this.voiceSend)
			{
				this.ShowoutVoiceSendBtn(this.isVoiceSendShow);
			}
			if (this.keyboardSprite)
			{
				this.keyboardSprite.gameObject.CustomActive(this.isVoiceSendShow);
			}
			if (this.voiceSprite)
			{
				this.voiceSprite.gameObject.CustomActive(!this.isVoiceSendShow);
			}
			if (this.isVoiceSendShow && this.Hide_Emotion != null)
			{
				this.Hide_Emotion();
			}
		}

		// Token: 0x0600D581 RID: 54657 RVA: 0x00355FA4 File Offset: 0x003543A4
		private void ShowoutVoiceSendBtn(bool isShowout)
		{
			if (this.voiceSend != null)
			{
				if (isShowout)
				{
					this.voiceSendBtnRect.anchoredPosition = new Vector2(this.voiceSendOriginalRectPos.x, this.voiceSendOriginalRectPos.y + VoiceDataHelper.VoiceInputBtnOffset);
				}
				else
				{
					this.voiceSendBtnRect.anchoredPosition = this.voiceSendOriginalRectPos;
				}
			}
		}

		// Token: 0x0600D582 RID: 54658 RVA: 0x0035600C File Offset: 0x0035440C
		private void ResetInputMode()
		{
			this.isVoiceSendShow = false;
			if (this.voiceSend)
			{
				this.voiceSend.SetActive(this.isVoiceSendShow);
				this.ShowoutVoiceSendBtn(this.isVoiceSendShow);
			}
			if (this.keyboardSprite)
			{
				this.keyboardSprite.gameObject.CustomActive(this.isVoiceSendShow);
			}
			if (this.voiceSprite)
			{
				this.voiceSprite.gameObject.CustomActive(!this.isVoiceSendShow);
			}
		}

		// Token: 0x0600D583 RID: 54659 RVA: 0x0035609C File Offset: 0x0035449C
		public void PlayOnChatVoice(string voiceKey, string chatTime, ChatVoiceInPlay voiceQueue)
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				if (this.chatFrameVoiceBtn != null)
				{
					this.chatFrameVoiceBtn.SetPlayVoiceNotEnabled();
				}
				return;
			}
			if (Singleton<SDKVoiceManager>.GetInstance().BeInRealVoiceChannel())
			{
				if (this.chatFrameVoiceBtn != null)
				{
					this.chatFrameVoiceBtn.SetNotifyInRealVoice();
				}
				return;
			}
			if (!Singleton<SDKVoiceManager>.GetInstance().CheckLoginChatVoice())
			{
				if (this.chatFrameVoiceBtn != null)
				{
					this.chatFrameVoiceBtn.SetNotLoginChatVoice();
				}
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ClearVoicePathQueue();
			Singleton<SDKVoiceManager>.GetInstance().PlayVoiceCommon(voiceKey);
		}

		// Token: 0x0600D584 RID: 54660 RVA: 0x00356144 File Offset: 0x00354544
		public void TryAutoPlayVoiceMessage(ChatData chatdata)
		{
			if (chatdata == null)
			{
				return;
			}
			if (!this.IsChatVoiceAutoPlay(chatdata))
			{
				return;
			}
			if (!Singleton<SDKVoiceManager>.GetInstance().CheckLoginChatVoice())
			{
				return;
			}
			if (chatdata.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			if (!string.IsNullOrEmpty(chatdata.voiceKey))
			{
				Singleton<SDKVoiceManager>.GetInstance().AddVoicePathInQueue(chatdata.voiceKey);
			}
		}

		// Token: 0x0600D585 RID: 54661 RVA: 0x003561AC File Offset: 0x003545AC
		private bool IsChatVoiceAutoPlay(ChatData chatData)
		{
			if (!Singleton<PluginManager>.instance.OpenChatVoiceInGloabl)
			{
				return false;
			}
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				return false;
			}
			if (Singleton<SDKVoiceManager>.GetInstance().BeInRealVoiceChannel())
			{
				return false;
			}
			if (chatData == null)
			{
				return false;
			}
			if (chatData.objid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return false;
			}
			switch (chatData.eChatType)
			{
			case ChatType.CT_WORLD:
				return Singleton<SDKVoiceManager>.instance.IsAutoPlayInWorld;
			case ChatType.CT_NORMAL:
				return Singleton<SDKVoiceManager>.instance.IsAutoPlayInNearby;
			case ChatType.CT_GUILD:
				return Singleton<SDKVoiceManager>.instance.IsAutoPlayInGuild;
			case ChatType.CT_TEAM:
				return Singleton<SDKVoiceManager>.instance.IsAutoPlayInTeam;
			case ChatType.CT_PRIVATE:
				return Singleton<SDKVoiceManager>.instance.IsAutoPlayInPrivate;
			}
			return false;
		}

		// Token: 0x0600D586 RID: 54662 RVA: 0x00356270 File Offset: 0x00354670
		private void OnVoiceInputBtnStartRecord(VoiceInputType btnType)
		{
			Singleton<SDKVoiceManager>.GetInstance().StopPlayVoice();
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(true);
			switch (btnType)
			{
			case VoiceInputType.ChatFrame:
				if (this.chatFrameData != null)
				{
					this.chatType = this.chatFrameData.eChatType;
				}
				break;
			case VoiceInputType.ComtalkTeam:
				this.chatType = ChatType.CT_TEAM;
				break;
			case VoiceInputType.ComtalkGuild:
				this.chatType = ChatType.CT_GUILD;
				break;
			default:
				this.chatType = ChatType.CT_ALL;
				break;
			}
			if (this.chatType == ChatType.CT_ALL)
			{
				if (this._currentUsedButton != null && this._currentUsedButton.currActiveBtn != null)
				{
					this._currentUsedButton.currActiveBtn.SetSendFailed();
					this._currentUsedButton.Reset();
				}
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().StartRecordVoiceCommon(this.chatType);
		}

		// Token: 0x0600D587 RID: 54663 RVA: 0x00356348 File Offset: 0x00354748
		private void OnVoiceInputBtnStopRecord()
		{
			Singleton<SDKVoiceManager>.GetInstance().StopAudioMessage();
		}

		// Token: 0x0600D588 RID: 54664 RVA: 0x00356354 File Offset: 0x00354754
		private void OnVoiceInputBtnCancelRecord()
		{
			Singleton<SDKVoiceManager>.GetInstance().CancelRecordVoice();
		}

		// Token: 0x0600D589 RID: 54665 RVA: 0x00356360 File Offset: 0x00354760
		private void OnRecordVoiceEnd(UIEvent uiEvent)
		{
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(false);
		}

		// Token: 0x0600D58A RID: 54666 RVA: 0x00356370 File Offset: 0x00354770
		private void OnRecordVoiceFailed(UIEvent uiEvent)
		{
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(false);
			if (this._currentUsedButton != null && null != this._currentUsedButton.currActiveBtn)
			{
				this._currentUsedButton.currActiveBtn.SetRecordFailed();
				this._currentUsedButton.Reset();
			}
		}

		// Token: 0x0600D58B RID: 54667 RVA: 0x003563C4 File Offset: 0x003547C4
		private void OnSendVoiceStart(UIEvent uiEvent)
		{
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(false);
			if (uiEvent == null)
			{
				return;
			}
			this.tempChatRichVoice = new ChatVoiceSendInfo();
			this.tempChatRichVoice.VoiceKey = (string)uiEvent.Param1;
			this.tempChatRichVoice.VoiceText = (string)uiEvent.Param2;
			this.tempChatRichVoice.VoicePath = (string)uiEvent.Param3;
			this.tempChatRichVoice.VoiceDuration = (int)uiEvent.Param4;
			if (this._currentUsedButton == null || null == this._currentUsedButton.currActiveBtn)
			{
				return;
			}
			this._currentUsedButton.currActiveBtn.SetSendEnd();
			if (this.canSendVoice)
			{
				if (this.tempChatRichVoice.VoiceDuration <= 0)
				{
					return;
				}
				this.SendVoiceChatToGame((string)uiEvent.Param1);
			}
			this._currentUsedButton.Reset();
		}

		// Token: 0x0600D58C RID: 54668 RVA: 0x003564B1 File Offset: 0x003548B1
		private void OnSendVoiceSucc(UIEvent uiEvent)
		{
		}

		// Token: 0x0600D58D RID: 54669 RVA: 0x003564B4 File Offset: 0x003548B4
		private void OnSendVoiceFailed(UIEvent uiEvent)
		{
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(false);
			if (this._currentUsedButton != null && null != this._currentUsedButton.currActiveBtn)
			{
				this._currentUsedButton.currActiveBtn.SetSendFailed();
				this._currentUsedButton.Reset();
			}
		}

		// Token: 0x0600D58E RID: 54670 RVA: 0x00356508 File Offset: 0x00354908
		private void OnPlayChatVoiceEnd(UIEvent uiEvent)
		{
		}

		// Token: 0x0600D58F RID: 54671 RVA: 0x0035650C File Offset: 0x0035490C
		private void OnMicAutoNoEnabled(UIEvent uiEvent)
		{
			Singleton<SDKVoiceManager>.GetInstance().ControlGameMusicMute(false);
			if (this._currentUsedButton != null && null != this._currentUsedButton.currActiveBtn)
			{
				this._currentUsedButton.currActiveBtn.SetAudioAuthFailed();
				this._currentUsedButton.Reset();
			}
		}

		// Token: 0x0600D590 RID: 54672 RVA: 0x00356560 File Offset: 0x00354960
		private void SendVoiceChatToGame(string key)
		{
			if (string.IsNullOrEmpty(key))
			{
				return;
			}
			if (this._currentUsedButton == null || this._currentUsedButton.currActiveBtn == null)
			{
				return;
			}
			if (this.tempChatRichVoice == null)
			{
				return;
			}
			if (this.tempChatRichVoice.VoiceText.Length < 100)
			{
				if (this.Is_satisfied_with_talk_condition != null && !this.Is_satisfied_with_talk_condition())
				{
					return;
				}
				this.tempChatRichVoice.VoiceKey = key;
				if (this._currentUsedButton.currActiveBtn.BtnType == VoiceInputType.ChatFrame)
				{
					if (this.chatFrameData == null)
					{
						return;
					}
					ulong tarId = (this.chatFrameData.curPrivate != null) ? this.chatFrameData.curPrivate.uid : 0UL;
					DataManager<ChatManager>.GetInstance().SendVoiceChat(this.chatFrameData.eChatType, this.tempChatRichVoice.VoiceKey, this.tempChatRichVoice.VoiceText, (byte)this.tempChatRichVoice.VoiceDuration, tarId);
				}
				else
				{
					DataManager<ChatManager>.GetInstance().SendVoiceChat(this.chatType, this.tempChatRichVoice.VoiceKey, this.tempChatRichVoice.VoiceText, (byte)this.tempChatRichVoice.VoiceDuration, 0UL);
				}
				this.tempChatRichVoice = null;
			}
		}

		// Token: 0x0600D591 RID: 54673 RVA: 0x003566A8 File Offset: 0x00354AA8
		private void AddVoiceChangeBtnListener()
		{
			if (this.changeInputModeBtn)
			{
				this.changeInputModeBtn.onClick.RemoveListener(new UnityAction(this.OnClickVoiceInputChange));
				this.changeInputModeBtn.onClick.AddListener(new UnityAction(this.OnClickVoiceInputChange));
			}
		}

		// Token: 0x0600D592 RID: 54674 RVA: 0x003566FD File Offset: 0x00354AFD
		private void RemoveVoiceChangeBtnListener()
		{
			if (this.changeInputModeBtn)
			{
				this.changeInputModeBtn.onClick.RemoveListener(new UnityAction(this.OnClickVoiceInputChange));
			}
		}

		// Token: 0x04007D57 RID: 32087
		private bool isInitialized;

		// Token: 0x04007D58 RID: 32088
		private bool isRecordVoiceEnabled;

		// Token: 0x04007D59 RID: 32089
		private bool isSendVoiceEnabled;

		// Token: 0x04007D5A RID: 32090
		public VoiceChatModule.IsSatisfiedWithWTalkCondition Is_satisfied_with_talk_condition;

		// Token: 0x04007D5B RID: 32091
		public VoiceChatModule.HideEmotion Hide_Emotion;

		// Token: 0x04007D5C RID: 32092
		public VoiceChatModule.IsRecordVoiceLimited Is_RecordVoice_Limited;

		// Token: 0x04007D5D RID: 32093
		private GameObject root;

		// Token: 0x04007D5E RID: 32094
		private GameObject voiceSend;

		// Token: 0x04007D5F RID: 32095
		private GameObject voiceInputRoot;

		// Token: 0x04007D60 RID: 32096
		private Button changeInputModeBtn;

		// Token: 0x04007D61 RID: 32097
		private Image voiceSprite;

		// Token: 0x04007D62 RID: 32098
		private Image keyboardSprite;

		// Token: 0x04007D63 RID: 32099
		private RectTransform voiceSendBtnRect;

		// Token: 0x04007D64 RID: 32100
		private Vector2 voiceSendOriginalRectPos = Vector2.zero;

		// Token: 0x04007D65 RID: 32101
		private ChatFrameData chatFrameData = new ChatFrameData();

		// Token: 0x04007D66 RID: 32102
		private ChatType chatType;

		// Token: 0x04007D67 RID: 32103
		private SDKVoiceInterface sdkInterface;

		// Token: 0x04007D68 RID: 32104
		private ChatVoiceSendInfo tempChatRichVoice;

		// Token: 0x04007D69 RID: 32105
		private VoiceInputBtn chatFrameVoiceBtn;

		// Token: 0x04007D6A RID: 32106
		private List<VoiceInputBtn> teamVoiceBtnList;

		// Token: 0x04007D6B RID: 32107
		private List<VoiceInputBtn> guildVoiceBtnList;

		// Token: 0x04007D6C RID: 32108
		private VoiceButtonUsed _currentUsedButton;

		// Token: 0x04007D6D RID: 32109
		private bool canSendVoice;

		// Token: 0x04007D6E RID: 32110
		private bool isVoiceSendShow;

		// Token: 0x0200155B RID: 5467
		// (Invoke) Token: 0x0600D594 RID: 54676
		public delegate bool IsSatisfiedWithWTalkCondition();

		// Token: 0x0200155C RID: 5468
		// (Invoke) Token: 0x0600D598 RID: 54680
		public delegate void HideEmotion();

		// Token: 0x0200155D RID: 5469
		// (Invoke) Token: 0x0600D59C RID: 54684
		public delegate bool IsRecordVoiceLimited();
	}
}
