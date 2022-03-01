using System;
using System.Collections.Generic;
using ProtoTable;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x02001575 RID: 5493
	public class VoiceTalkModule
	{
		// Token: 0x0600D678 RID: 54904 RVA: 0x003595BC File Offset: 0x003579BC
		private void _OnJoinChannelSucc()
		{
			if (this.bFirstJoinChannel)
			{
				Singleton<SDKVoiceManager>.GetInstance().ResetRealTalkVoiceParams();
				if (this.talkConfig.isMicOnAtFirst && this.IsSelfMicEnable())
				{
					if (!this.IsMicOn())
					{
						this.bJoinChannelMicChanged = true;
					}
					Singleton<SDKVoiceManager>.GetInstance().OpenRealMic();
				}
				else
				{
					if (this.IsMicOn())
					{
						this.bJoinChannelMicChanged = true;
					}
					Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
				}
				if (this.talkConfig.isPlayerOnAtFirst)
				{
					Singleton<SDKVoiceManager>.GetInstance().OpenRealPlayer();
				}
				else
				{
					Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
				}
				if (this.talkConfig.isGlobalSilenceAtFirst)
				{
					this.OpenGlobalSilence();
				}
				this.bFirstJoinChannel = false;
			}
		}

		// Token: 0x0600D679 RID: 54905 RVA: 0x0035967C File Offset: 0x00357A7C
		private void _OnLeaveChannelSucc()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().HasJoinedTalkChannel())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkLeaveAllChannel, null, null, null, null);
			}
		}

		// Token: 0x0600D67A RID: 54906 RVA: 0x003596A0 File Offset: 0x00357AA0
		private void _OnVoiceSDKMicOn(bool isOn)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkMicSwitch, new bool[]
			{
				isOn
			}, null, null, null);
			if (this.bJoinChannelMicChanged)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkJoinChannelAndMicChanged, null, null, null, null);
				this.bJoinChannelMicChanged = false;
			}
			if (isOn)
			{
				Singleton<SDKVoiceManager>.GetInstance().CutGameVolumnInTalkVoice();
				if (this.setMicCount > 0)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_self_mic_on"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					this.setMicCount--;
				}
			}
			else if (this.setMicCount > 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_self_mic_off"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				this.setMicCount--;
			}
		}

		// Token: 0x0600D67B RID: 54907 RVA: 0x0035975C File Offset: 0x00357B5C
		private void _OnVoiceSDKPlayerOn(bool isOn)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkPlayerSwitch, new bool[]
			{
				isOn
			}, null, null, null);
			if (isOn)
			{
				if (this.setPlayerCount > 0)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_self_player_on"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					this.setPlayerCount--;
				}
			}
			else if (this.setPlayerCount > 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_self_player_off"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				this.setPlayerCount--;
			}
		}

		// Token: 0x0600D67C RID: 54908 RVA: 0x003597E6 File Offset: 0x00357BE6
		private void _OnVoiceLimitAllNotSpeak(bool isOn)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkLimitAllNotSpeak, new bool[]
			{
				isOn
			}, null, null, null);
		}

		// Token: 0x0600D67D RID: 54909 RVA: 0x00359804 File Offset: 0x00357C04
		private void _OnVoiceMicClosedByOther(bool isOn)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkMicClosedByOther, new bool[]
			{
				isOn
			}, null, null, null);
		}

		// Token: 0x0600D67E RID: 54910 RVA: 0x00359822 File Offset: 0x00357C22
		private void _OnVoiceGlobalSilenceChanged(bool isSilence)
		{
			if (!isSilence)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_global_mic_on"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_global_mic_off"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600D67F RID: 54911 RVA: 0x00359854 File Offset: 0x00357C54
		private void _OnVoiceTalkChannelChanged(string channelId)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkChannelChanged, channelId, null, null, null);
			if (!string.IsNullOrEmpty(channelId))
			{
				if (this.talkSceneIds == null || this.talkSceneIds.Count <= 0)
				{
					return;
				}
				if (this.bFirstSelectChannel)
				{
					this.bFirstSelectChannel = false;
					return;
				}
				string currentTalkChanneld = this.GetCurrentTalkChanneld();
				if (currentTalkChanneld == channelId)
				{
					return;
				}
				if (this.talkSceneIds[0] == channelId)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_mic_teamcopy_mode"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_talk_mic_team_mode"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
		}

		// Token: 0x0600D680 RID: 54912 RVA: 0x00359901 File Offset: 0x00357D01
		private void _OnOtherSpeakInChannel(bool isSpeak, string voicePlayerId)
		{
			this._SendOtherSpeak(isSpeak, voicePlayerId);
		}

		// Token: 0x0600D681 RID: 54913 RVA: 0x0035990B File Offset: 0x00357D0B
		private void _OnOtherControlMic(bool isOn, string voicePlayerId)
		{
			if (!isOn)
			{
				this._SendOtherSpeak(false, voicePlayerId);
			}
		}

		// Token: 0x0600D682 RID: 54914 RVA: 0x0035991B File Offset: 0x00357D1B
		private void _OnOtherChangeSpeakChannel(string channelId, string voicePlayerId)
		{
			this._SendOtherSpeak(false, voicePlayerId);
		}

		// Token: 0x0600D683 RID: 54915 RVA: 0x00359928 File Offset: 0x00357D28
		private void _SendOtherSpeak(bool isSpeak, string voicePlayerId)
		{
			VoiceTalkOtherSpeakInfo voiceTalkOtherSpeakInfo = new VoiceTalkOtherSpeakInfo();
			voiceTalkOtherSpeakInfo.isSpeak = isSpeak;
			voiceTalkOtherSpeakInfo.gameAccId = Singleton<SDKVoiceManager>.GetInstance().GetGameAccIdByVoicePlayerId(voicePlayerId);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VoiceTalkOtherSpeakInChannel, voiceTalkOtherSpeakInfo, null, null, null);
		}

		// Token: 0x0600D684 RID: 54916 RVA: 0x00359966 File Offset: 0x00357D66
		private void _OnOtherLeaveChannel(string channelId, string voicePlayerId)
		{
			this._SendOtherSpeak(false, voicePlayerId);
		}

		// Token: 0x0600D685 RID: 54917 RVA: 0x00359970 File Offset: 0x00357D70
		private void _OnMicAuthNoPermission()
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("voice_sdk_audio_auth_request"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600D686 RID: 54918 RVA: 0x00359984 File Offset: 0x00357D84
		public void Reset(VoiceTalkConfig vtConfig, bool otherVoiceTalkSwitch = true)
		{
			this.talkConfig = vtConfig;
			if (this.talkSceneIds == null)
			{
				this.talkSceneIds = new List<string>();
			}
			this.isVoiceTalkOpen = (Singleton<PluginManager>.GetInstance().GetVoiceSDKSwitch(vtConfig.switchType) && otherVoiceTalkSwitch);
			this._Init();
		}

		// Token: 0x0600D687 RID: 54919 RVA: 0x003599D4 File Offset: 0x00357DD4
		private void _Init()
		{
			if (this.isInited)
			{
				return;
			}
			this.isInited = true;
			this.bFirstJoinChannel = true;
			this.bFirstSelectChannel = true;
			this.bJoinChannelMicChanged = false;
			if (!this.isVoiceTalkOpen)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().AddRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this._OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this._OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this._OnVoiceSDKPlayerOn), new SDKVoiceInterface.OnVoiceLimitOtherNotSpeack(this._OnVoiceLimitAllNotSpeak), new SDKVoiceInterface.OnVoiceMicOffByOther(this._OnVoiceMicClosedByOther), new SDKVoiceInterface.OnVoiceTalkGlobalSilenceChanged(this._OnVoiceGlobalSilenceChanged), new SDKVoiceInterface.OnVoiceTalkChannelChanged(this._OnVoiceTalkChannelChanged), new SDKVoiceInterface.OnVoiceTalkOtherSpeakInChannel(this._OnOtherSpeakInChannel), new SDKVoiceInterface.OnVoiceTalkOtherControlMic(this._OnOtherControlMic), new SDKVoiceInterface.OnVoiceTalkOtherChangeSpeakChannel(this._OnOtherChangeSpeakChannel), new SDKVoiceInterface.OnVoiceTalkOtherLeaveChannel(this._OnOtherLeaveChannel), new SDKVoiceInterface.OnVoiceTalkMicAuthNoPermission(this._OnMicAuthNoPermission), new SDKVoiceInterface.OnLeaveChannelSuccess(this._OnLeaveChannelSucc));
		}

		// Token: 0x0600D688 RID: 54920 RVA: 0x00359ABB File Offset: 0x00357EBB
		private void _UpdateTalkChannels()
		{
			if (this.talkSceneIds != null)
			{
				Singleton<SDKVoiceManager>.GetInstance().UpdateTalkChannel(this.talkSceneIds);
			}
		}

		// Token: 0x0600D689 RID: 54921 RVA: 0x00359AD8 File Offset: 0x00357ED8
		public void UnInit()
		{
			this.isInited = false;
			if (!this.isVoiceTalkOpen)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
			Singleton<SDKVoiceManager>.GetInstance().RecoverGameVolumnInTalkVoice();
			Singleton<SDKVoiceManager>.GetInstance().LeaveAllChannel();
			Singleton<SDKVoiceManager>.GetInstance().RemoveRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this._OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this._OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this._OnVoiceSDKPlayerOn), new SDKVoiceInterface.OnVoiceLimitOtherNotSpeack(this._OnVoiceLimitAllNotSpeak), new SDKVoiceInterface.OnVoiceMicOffByOther(this._OnVoiceMicClosedByOther), new SDKVoiceInterface.OnVoiceTalkGlobalSilenceChanged(this._OnVoiceGlobalSilenceChanged), new SDKVoiceInterface.OnVoiceTalkChannelChanged(this._OnVoiceTalkChannelChanged), new SDKVoiceInterface.OnVoiceTalkOtherSpeakInChannel(this._OnOtherSpeakInChannel), new SDKVoiceInterface.OnVoiceTalkOtherControlMic(this._OnOtherControlMic), new SDKVoiceInterface.OnVoiceTalkOtherChangeSpeakChannel(this._OnOtherChangeSpeakChannel), new SDKVoiceInterface.OnVoiceTalkOtherLeaveChannel(this._OnOtherLeaveChannel), new SDKVoiceInterface.OnVoiceTalkMicAuthNoPermission(this._OnMicAuthNoPermission), new SDKVoiceInterface.OnLeaveChannelSuccess(this._OnLeaveChannelSucc));
			if (this.talkSceneIds != null)
			{
				this.talkSceneIds.Clear();
				this.talkSceneIds = null;
			}
			this.setMicCount = (this.setPlayerCount = 0);
		}

		// Token: 0x0600D68A RID: 54922 RVA: 0x00359BF3 File Offset: 0x00357FF3
		public List<string> GetMultipleTalkChannels()
		{
			return this.talkSceneIds;
		}

		// Token: 0x0600D68B RID: 54923 RVA: 0x00359BFB File Offset: 0x00357FFB
		public void UpdateMultipleTalkChannel(List<string> sIds)
		{
			if (sIds == null)
			{
				return;
			}
			this.talkSceneIds = sIds;
			this._UpdateTalkChannels();
		}

		// Token: 0x0600D68C RID: 54924 RVA: 0x00359C11 File Offset: 0x00358011
		public void AddMultipleTalkChannel(string sId)
		{
			if (string.IsNullOrEmpty(sId))
			{
				return;
			}
			if (this.talkSceneIds != null && !this.talkSceneIds.Contains(sId))
			{
				this.talkSceneIds.Add(sId);
				this._UpdateTalkChannels();
			}
		}

		// Token: 0x0600D68D RID: 54925 RVA: 0x00359C4D File Offset: 0x0035804D
		public void RemoveMultipleTalkChannel(string sId)
		{
			if (string.IsNullOrEmpty(sId))
			{
				return;
			}
			if (this.talkSceneIds != null)
			{
				this.talkSceneIds.Remove(sId);
				this._UpdateTalkChannels();
			}
		}

		// Token: 0x0600D68E RID: 54926 RVA: 0x00359C79 File Offset: 0x00358079
		public bool IsMicOn()
		{
			return Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn();
		}

		// Token: 0x0600D68F RID: 54927 RVA: 0x00359C85 File Offset: 0x00358085
		public void OpenMic()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!this.IsSelfMicEnable())
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().OpenRealMic();
		}

		// Token: 0x0600D690 RID: 54928 RVA: 0x00359CC0 File Offset: 0x003580C0
		public bool CloseMic()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (!Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn())
			{
				return false;
			}
			Singleton<SDKVoiceManager>.GetInstance().CloseRealMic();
			this.setMicCount++;
			return true;
		}

		// Token: 0x0600D691 RID: 54929 RVA: 0x00359D18 File Offset: 0x00358118
		public void ControlMic()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVoiceMic();
			this.setMicCount++;
		}

		// Token: 0x0600D692 RID: 54930 RVA: 0x00359D52 File Offset: 0x00358152
		public bool IsPlayerOn()
		{
			return Singleton<SDKVoiceManager>.GetInstance().IsTalkRealPlayerOn();
		}

		// Token: 0x0600D693 RID: 54931 RVA: 0x00359D5E File Offset: 0x0035815E
		public void OpenPlayer()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().OpenRealPlayer();
		}

		// Token: 0x0600D694 RID: 54932 RVA: 0x00359D8A File Offset: 0x0035818A
		public void ClosePlayer()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().CloseReaPlayer();
		}

		// Token: 0x0600D695 RID: 54933 RVA: 0x00359DB6 File Offset: 0x003581B6
		public void ControlPlayer()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVociePlayer();
			this.setPlayerCount++;
		}

		// Token: 0x0600D696 RID: 54934 RVA: 0x00359DF0 File Offset: 0x003581F0
		public bool SwitchSpeakChannel(string sceneId, bool needMicOn = true)
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return false;
			}
			if (!this.IsSelfMicEnable())
			{
				return false;
			}
			string currentTalkChanneld = this.GetCurrentTalkChanneld();
			bool flag = currentTalkChanneld == sceneId;
			if (needMicOn && !Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn())
			{
				Singleton<SDKVoiceManager>.GetInstance().OpenRealMic();
				if (flag)
				{
					this._OnVoiceTalkChannelChanged(sceneId);
					return true;
				}
			}
			if (flag)
			{
				return false;
			}
			Singleton<SDKVoiceManager>.GetInstance().SwitchTalkChannel(sceneId);
			return true;
		}

		// Token: 0x0600D697 RID: 54935 RVA: 0x00359E7C File Offset: 0x0035827C
		public string GetCurrentTalkChanneld()
		{
			return Singleton<SDKVoiceManager>.GetInstance().GetCurrentTalkChanneld();
		}

		// Token: 0x0600D698 RID: 54936 RVA: 0x00359E88 File Offset: 0x00358288
		private bool _IsInOtherTalkChannel(string otherGameAccId)
		{
			string otherTalkChannelId = Singleton<SDKVoiceManager>.GetInstance().GetOtherTalkChannelId(otherGameAccId);
			return !string.IsNullOrEmpty(otherGameAccId) && this.IsJoinedTalkChannel(otherTalkChannelId);
		}

		// Token: 0x0600D699 RID: 54937 RVA: 0x00359EB5 File Offset: 0x003582B5
		public bool IsJoinedTalkChannel(string talkChannelId)
		{
			return !string.IsNullOrEmpty(talkChannelId) && Singleton<SDKVoiceManager>.GetInstance().IsJoinedTalkChannel(talkChannelId);
		}

		// Token: 0x0600D69A RID: 54938 RVA: 0x00359ECF File Offset: 0x003582CF
		public void ControlGlobalSilence()
		{
			if (this.talkSceneIds == null || this.talkSceneIds.Count <= 0)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlGlobalSilence(this.talkSceneIds[0]);
		}

		// Token: 0x0600D69B RID: 54939 RVA: 0x00359F04 File Offset: 0x00358304
		public void SetMicEnable(string gameAccId, bool bEnable)
		{
			Singleton<SDKVoiceManager>.GetInstance().SetMicEnable(gameAccId, bEnable);
		}

		// Token: 0x0600D69C RID: 54940 RVA: 0x00359F12 File Offset: 0x00358312
		public void ResetGlobalSilence()
		{
			if (this.talkSceneIds == null || this.talkSceneIds.Count <= 0)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().SetGlobalSilence(this.talkSceneIds[0], this.IsGlobalSilence());
		}

		// Token: 0x0600D69D RID: 54941 RVA: 0x00359F4D File Offset: 0x0035834D
		public void OpenGlobalSilence()
		{
			if (this.talkSceneIds == null || this.talkSceneIds.Count <= 0)
			{
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().SetGlobalSilence(this.talkSceneIds[0], true);
		}

		// Token: 0x0600D69E RID: 54942 RVA: 0x00359F83 File Offset: 0x00358383
		public bool IsSelfMicEnable()
		{
			return Singleton<SDKVoiceManager>.GetInstance().IsMicEnable();
		}

		// Token: 0x0600D69F RID: 54943 RVA: 0x00359F8F File Offset: 0x0035838F
		public bool IsGlobalSilence()
		{
			return Singleton<SDKVoiceManager>.GetInstance().IsGlobalSilence();
		}

		// Token: 0x04007DF4 RID: 32244
		private List<string> talkSceneIds;

		// Token: 0x04007DF5 RID: 32245
		private bool isVoiceTalkOpen;

		// Token: 0x04007DF6 RID: 32246
		private bool isInited;

		// Token: 0x04007DF7 RID: 32247
		private bool bFirstJoinChannel = true;

		// Token: 0x04007DF8 RID: 32248
		private VoiceTalkConfig talkConfig;

		// Token: 0x04007DF9 RID: 32249
		private int setMicCount;

		// Token: 0x04007DFA RID: 32250
		private int setPlayerCount;

		// Token: 0x04007DFB RID: 32251
		private bool bFirstSelectChannel = true;

		// Token: 0x04007DFC RID: 32252
		private bool bJoinChannelMicChanged;
	}
}
