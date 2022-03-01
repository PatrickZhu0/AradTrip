using System;
using System.Collections.Generic;
using System.IO;
using GameClient;
using Protocol;
using YIMEngine;
using YouMe;

namespace VoiceSDK
{
	// Token: 0x02004691 RID: 18065
	public class YouMiVoiceInterface : SDKVoiceInterface, IYouMiVoiceChatImpl, LoginListen, MessageListen, ChatRoomListen, AudioPlayListen, ContactListen, LocationListen, DownloadListen, ISDKRealVoiceCallback
	{
		// Token: 0x06019816 RID: 104470 RVA: 0x0080A4D0 File Offset: 0x008088D0
		public override void Init()
		{
			this.cacheChatVoiceAccInfo = new YoumiVoiceGameAccInfo();
			SDKVoiceCallback instance = MonoSingleton<SDKVoiceCallback>.instance;
		}

		// Token: 0x06019817 RID: 104471 RVA: 0x0080A4F0 File Offset: 0x008088F0
		public override void InitChatVoice()
		{
			if (this.isChatVoiceInited)
			{
				return;
			}
			this.isVoiceTranslate = false;
			this.chatMethodResult = IMAPI.Instance().Init("YOUMEF6EFE7326698A3E3E0AEEEDA02BCA6B6B39EF406", "1VhLqAbGn5Da4gxsIowTYGQYJ1hwLZPOi6YiSBJgzfqskjE5m9Oo0y5+P781O5U9SsK9IURbybKr/YB/4h/qQ3rKTlFmyWDRbNf+gOWPvEq2ilqHhj1K4LKC8Av0ORqSSJQAlDPATj6tzx1LprJL1HLePObGZ5lzDCyVrggJtmcBAAE=", ServerZone.China);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				this.isChatVoiceInited = true;
				IMAPI.Instance().SetLoginListen(this);
				IMAPI.Instance().SetMessageListen(this);
				IMAPI.Instance().SetChatRoomListen(this);
				IMAPI.Instance().SetDownloadListen(this);
				IMAPI.Instance().SetContactListen(this);
				IMAPI.Instance().SetAudioPlayListen(this);
				IMAPI.Instance().SetLocationListen(this);
				if (!string.IsNullOrEmpty(this.SaveVoiceCachePath))
				{
					IMAPI.Instance().SetAudioCachePath(this.SaveVoiceCachePath);
					this.LogForYouMiChat("InitVoice params set:", this.chatMethodResult, "SaveVoiceCachePath: " + this.SaveVoiceCachePath, SDKVoiceLogLevel.Error);
				}
				this.voiceQueue = new Queue<string>();
				if (int.TryParse(TR.Value("voice_sdk_voice_queue_count"), out this.maxVoiceQueueLength))
				{
					this.LogForYouMiChat("InitVoice", ErrorCode.Success, "Set voice auto play queue captity is " + this.maxVoiceQueueLength, SDKVoiceLogLevel.Error);
				}
				if (uint.TryParse(TR.Value("voice_sdk_private_chat_deleteTime"), out this.onTimeDeletePrivateChat))
				{
					this.LogForYouMiChat("InitVoice", ErrorCode.Success, "Set private chat delete on time , day : " + this.onTimeDeletePrivateChat, SDKVoiceLogLevel.Error);
				}
				if (int.TryParse(TR.Value("voice_sdk_private_chat_queryCount"), out this.privateChatQueryMsgCount))
				{
					this.LogForYouMiChat("InitVoice", ErrorCode.Success, "Set private chat query chat msg count is " + this.privateChatQueryMsgCount, SDKVoiceLogLevel.Error);
				}
			}
			this.LogForYouMiChat("InitVoice", this.chatMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019818 RID: 104472 RVA: 0x0080A6A4 File Offset: 0x00808AA4
		public override void UnInitChatVoice()
		{
			base.UnInitChatVoice();
			this.voiceQueue = null;
			this.cacheChatVoiceAccInfo = null;
			this.isChatVoiceInited = false;
			this.isVoiceTranslate = false;
			this.maxVoiceQueueLength = 20;
			this.cacheLogMsg = string.Empty;
			this.voiceVolume = 0f;
			this.isRecording = false;
			this.isRecordPTTFailed = false;
			this._leastLocalAudioToken = string.Empty;
			this._currentReqPlayAudioToken = string.Empty;
			this._AudioCache.Clear();
			this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			this.isQueryHistoryMsgClear = false;
			this.voiceChatRoomIdList.Clear();
		}

		// Token: 0x06019819 RID: 104473 RVA: 0x0080A739 File Offset: 0x00808B39
		public string BuildRequestIdPath(ulong requestId)
		{
			return Path.Combine(VoiceDataHelper.saveLocalPath, requestId.ToString() + this.GetFileNameExtension());
		}

		// Token: 0x0601981A RID: 104474 RVA: 0x0080A760 File Offset: 0x00808B60
		public override void PlayVoiceCommon(string voicekey, string targetUserId = "")
		{
			if (string.IsNullOrEmpty(voicekey))
			{
				return;
			}
			this._currentReqPlayAudioToken = voicekey;
			if (this._AudioCache == null)
			{
				return;
			}
			if (this._AudioCache.ContainsKey(this._currentReqPlayAudioToken))
			{
				AudioInfo audioInfo = this._AudioCache[this._currentReqPlayAudioToken];
				if (audioInfo.status == DownloadStatus.DS_SUCCESS)
				{
					this.TryPlayVoiceByPath(audioInfo.path);
				}
				else if (audioInfo.status == DownloadStatus.DS_NOTDOWNLOAD)
				{
					this.DownloadAudioFile(audioInfo);
				}
			}
			else
			{
				if (string.IsNullOrEmpty(targetUserId))
				{
					return;
				}
				this.QueryPrivateHistoryMsgByUserId(targetUserId, this.privateChatQueryMsgCount, 0UL);
			}
		}

		// Token: 0x0601981B RID: 104475 RVA: 0x0080A804 File Offset: 0x00808C04
		public override void LoginVoice(string roleId, string openId, string token)
		{
			if (this.cacheChatVoiceAccInfo != null)
			{
				this.cacheChatVoiceAccInfo.RoleId = roleId;
				this.cacheChatVoiceAccInfo.OpenId = openId;
				this.cacheChatVoiceAccInfo.Token = token;
			}
			this.LogForYouMiChat("LoginVoice !!! Just Set !!! YoumiChatVoiceAccInfo : ", this.chatMethodResult, string.Concat(new string[]
			{
				"roleId ",
				roleId,
				"| pass ",
				openId,
				"| token ",
				token
			}), SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601981C RID: 104476 RVA: 0x0080A881 File Offset: 0x00808C81
		public override void LogoutVoice()
		{
			this.TryLogoutYoumiChatVoice();
		}

		// Token: 0x0601981D RID: 104477 RVA: 0x0080A88C File Offset: 0x00808C8C
		public override void AddVoicePathInQueue(string voiceKey)
		{
			if (this.voiceQueue != null && !string.IsNullOrEmpty(voiceKey))
			{
				if (this._AudioCache != null && this._AudioCache.ContainsKey(voiceKey))
				{
					return;
				}
				if (this.isRecording)
				{
					return;
				}
				if (this.voiceQueue.Count > this.maxVoiceQueueLength)
				{
					this.voiceQueue.Dequeue();
				}
				this.voiceQueue.Enqueue(voiceKey);
				this.PlayVoiceQueue();
			}
		}

		// Token: 0x0601981E RID: 104478 RVA: 0x0080A90D File Offset: 0x00808D0D
		public override void ClearVoicePathQueue()
		{
			if (this.voiceQueue != null && this.voiceQueue.Count > 0)
			{
				this.voiceQueue.Clear();
				this.LogForYouMiChat("ClearVoicePathQueue", ErrorCode.Success, "Chat Voice auto play queue is clear now", SDKVoiceLogLevel.Error);
			}
		}

		// Token: 0x0601981F RID: 104479 RVA: 0x0080A948 File Offset: 0x00808D48
		public override void StopPlayVoice()
		{
			this.TryStopPlayVoice();
			this.ClearVoicePathQueue();
		}

		// Token: 0x06019820 RID: 104480 RVA: 0x0080A958 File Offset: 0x00808D58
		public override void SetVoiceVolume(float volume)
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			try
			{
				IMAPI.Instance().SetVolume(volume);
				this.voiceVolume = volume;
				this.LogForYouMiChat("SetVoiceVolume", ErrorCode.Success, "set curr volumn is " + volume, SDKVoiceLogLevel.Error);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("Chat Voice Set Volumn is Failed : {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x06019821 RID: 104481 RVA: 0x0080A9D8 File Offset: 0x00808DD8
		public override float GetVoiceVolume()
		{
			return this.voiceVolume;
		}

		// Token: 0x06019822 RID: 104482 RVA: 0x0080A9E0 File Offset: 0x00808DE0
		public override void ClearLocalCache()
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			bool flag = IMAPI.Instance().ClearAudioCachePath();
			if (flag)
			{
				this.LogForYouMiChat("ClearLocalCache", ErrorCode.Success, "clear local voice cache succ", SDKVoiceLogLevel.Error);
			}
			else
			{
				this.LogForYouMiChat("ClearLocalCache", ErrorCode.Fail, "clear local voice cache failed", SDKVoiceLogLevel.Error);
			}
		}

		// Token: 0x06019823 RID: 104483 RVA: 0x0080AA37 File Offset: 0x00808E37
		public override void OnPause()
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			IMAPI.Instance().OnPause(false);
			this.LogForYouMiChat("OnPause Chat Voice", ErrorCode.Success, "[YouMe - Voice Chat] OnPause !!!", SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019824 RID: 104484 RVA: 0x0080AA62 File Offset: 0x00808E62
		public override void OnResume()
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			IMAPI.Instance().OnResume();
			this.LogForYouMiChat("OnResume Chat Voice", ErrorCode.Success, "[YouMe - Voice Chat] OnResume !!!", SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019825 RID: 104485 RVA: 0x0080AA8C File Offset: 0x00808E8C
		public override string ShowDebugLog()
		{
			return this.cacheLogMsg;
		}

		// Token: 0x06019826 RID: 104486 RVA: 0x0080AA94 File Offset: 0x00808E94
		public override bool IsVoiceRecording()
		{
			return this.CheckYoumiChatVoiceLoginState(false) && this.isRecording;
		}

		// Token: 0x06019827 RID: 104487 RVA: 0x0080AAAA File Offset: 0x00808EAA
		public override bool IsVoicePlaying()
		{
			return this.CheckYoumiChatVoiceLoginState(false) && IMAPI.Instance().IsPlaying();
		}

		// Token: 0x06019828 RID: 104488 RVA: 0x0080AAC4 File Offset: 0x00808EC4
		public override void JoinChatRoom(string roomId, bool beSaveRoomMsg = false)
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			if (string.IsNullOrEmpty(roomId))
			{
				this.LogForYouMiChat("LeaveChatRoom", ErrorCode.Fail, "LeaveChatRoom roomId is null", SDKVoiceLogLevel.Error);
				return;
			}
			this.TryJoinChatRoom(roomId, beSaveRoomMsg);
		}

		// Token: 0x06019829 RID: 104489 RVA: 0x0080AAFD File Offset: 0x00808EFD
		public override void LeaveChatRoom(string roomId)
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			if (string.IsNullOrEmpty(roomId))
			{
				this.LogForYouMiChat("LeaveChatRoom", ErrorCode.Fail, "LeaveChatRoom roomId is null", SDKVoiceLogLevel.Error);
				return;
			}
			this.TryLeaveChatRoom(roomId);
		}

		// Token: 0x0601982A RID: 104490 RVA: 0x0080AB38 File Offset: 0x00808F38
		public override void SendVoiceMessage(string receId, GameClient.ChatType chatType, ref ulong iReqId, bool bTranslate)
		{
			if (!this.CheckYoumiChatVoiceLoginState(true))
			{
				return;
			}
			if (this.isRecording)
			{
				return;
			}
			if (this.isRecordPTTFailed)
			{
				this.StopAudioMessage(string.Empty);
				this.LogForYouMiChat("SendVoiceMessage", ErrorCode.Success, "isRecordPTTFailed !!! stopaudioMessage", SDKVoiceLogLevel.Error);
				return;
			}
			if (string.IsNullOrEmpty(receId))
			{
				if (this.onVoiceChatNotJoinRoomHandler != null)
				{
					this.onVoiceChatNotJoinRoomHandler();
				}
				return;
			}
			YIMEngine.ChatType chatType2 = YIMEngine.ChatType.RoomChat;
			this._leasetLocalAudioChatType = chatType;
			if (!bTranslate)
			{
				this.chatMethodResult = IMAPI.Instance().SendOnlyAudioMessage(receId, chatType2, ref iReqId);
			}
			else
			{
				this.chatMethodResult = IMAPI.Instance().SendAudioMessage(receId, chatType2, ref iReqId);
			}
			this.LogForYouMiChat("SendVoiceMessage", this.chatMethodResult, string.Format("Record Voice chatType is {0}", chatType.ToString()), SDKVoiceLogLevel.Error);
			if (this.chatMethodResult != ErrorCode.Success)
			{
				if (this.chatMethodResult == ErrorCode.PTT_Fail)
				{
					this.isRecordPTTFailed = true;
					this.isRecording = false;
				}
				else if (this.chatMethodResult == ErrorCode.NotLogin)
				{
					this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
					this.TryLoginYoumiChatVoice(this.cacheChatVoiceAccInfo);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatRecordFailed, null, null, null, null);
			}
			else
			{
				this.isRecording = true;
				this.isRecordPTTFailed = false;
			}
		}

		// Token: 0x0601982B RID: 104491 RVA: 0x0080AC80 File Offset: 0x00809080
		public override void StopAudioMessage(string extra)
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			if (string.IsNullOrEmpty(extra))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatSendFailed, null, null, null, null);
				return;
			}
			this._leastLocalAudioToken = Singleton<SDKVoiceManager>.GetInstance().GetVoiceToken(extra);
			this.chatMethodResult = IMAPI.Instance().StopAudioMessage(this._leastLocalAudioToken);
			this.LogForYouMiChat("StopAudioMessage", this.chatMethodResult, "Stop record with token is " + extra, SDKVoiceLogLevel.Error);
			this.isRecording = false;
			if (this.chatMethodResult != ErrorCode.Success)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatRecordFailed, null, null, null, null);
			}
		}

		// Token: 0x0601982C RID: 104492 RVA: 0x0080AD24 File Offset: 0x00809124
		public override void ClearVoiceChatMsgCache()
		{
			this.DeleteRoomChatMsgOnTime(this.onTimeDeletePrivateChat);
			if (this.voiceChatRoomIdList != null && this.voiceChatRoomIdList.Count > 0)
			{
				string chatRoomId = this.voiceChatRoomIdList[0];
				this.QueryHistoryMsgToClear(chatRoomId, this.privateChatQueryMsgCount, 0UL);
			}
			else
			{
				this.TryLogoutYoumiChatVoice();
			}
		}

		// Token: 0x0601982D RID: 104493 RVA: 0x0080AD80 File Offset: 0x00809180
		public override bool CheckLoginChatVoice()
		{
			return this.CheckYoumiChatVoiceLoginState(true);
		}

		// Token: 0x0601982E RID: 104494 RVA: 0x0080AD89 File Offset: 0x00809189
		public override bool StartRecordVoice()
		{
			return false;
		}

		// Token: 0x0601982F RID: 104495 RVA: 0x0080AD8C File Offset: 0x0080918C
		public override bool StopRecordVoice()
		{
			return false;
		}

		// Token: 0x06019830 RID: 104496 RVA: 0x0080AD8F File Offset: 0x0080918F
		public override void CancelRecordVoice()
		{
		}

		// Token: 0x06019831 RID: 104497 RVA: 0x0080AD94 File Offset: 0x00809194
		public override void InitTalkVoice()
		{
			if (this.isTalkVoiceInited)
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetCallback(MonoSingleton<SDKVoiceCallback>.instance.gameObject.name);
			this.talkChannelIds = new List<string>();
			this.otherTalkChannelInfos = new List<OtheTalkChannelInfo>();
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoiceInitHandler = new SDKVoiceCallback.OnRealVoiceInitHandler(this.OnTalkVoiceInit);
			MonoSingleton<SDKVoiceCallback>.instance.onJoinChannelHandler = new SDKVoiceCallback.OnJoinChannelHandler(this.OnTalkVoiceJoinChannel);
			MonoSingleton<SDKVoiceCallback>.instance.onLeaveChannelHandler = new SDKVoiceCallback.OnLeaveChannelHandler(this.OnTalkVoiceLeaveChannel);
			MonoSingleton<SDKVoiceCallback>.instance.onLeaveAllChanenlHandler = new SDKVoiceCallback.OnLeaveAllChannelHandler(this.OnTalkVoiceLeaveAllChannels);
			MonoSingleton<SDKVoiceCallback>.instance.onPauseChannelHandler = new SDKVoiceCallback.OnPauseChannelHanlder(this.OnTalkVoiceChannelPause);
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoiceMicHandler = new SDKVoiceCallback.OnRealVoiceMicOnHandler(this.OnTalkVoiceMicOn);
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoicePlayerHandler = new SDKVoiceCallback.OnRealVoicePlayerOnHandler(this.OnTalkVoicePlayerOn);
			MonoSingleton<SDKVoiceCallback>.instance.onChannelMemberChange = new SDKVoiceCallback.OnChannelMemberChangeHandler(this.OnChannelMemberChange);
			MonoSingleton<SDKVoiceCallback>.instance.onMicChangeByOther = new SDKVoiceCallback.OnMicChangeByOtherHandler(this.OnTalkVoiceMicChangeByOther);
			MonoSingleton<SDKVoiceCallback>.instance.onSetSpeakChannel = new SDKVoiceCallback.OnSetSpeackChannelHandler(this.OnSetSpeakChannel);
			MonoSingleton<SDKVoiceCallback>.instance.onOtherSpeakInChannel = new SDKVoiceCallback.OnOtherSpeakInChannelHandler(this.OnOtherSpeakInChannel);
			MonoSingleton<SDKVoiceCallback>.instance.onOtherControlMic = new SDKVoiceCallback.OnOtherControlMicHandler(this.OnOtherControlMic);
			MonoSingleton<SDKVoiceCallback>.instance.onVoiceTalkMicAuth = new SDKVoiceCallback.OnVoiceTalkMicAuth(this.OnVoiceTalkMicAuth);
			MonoSingleton<SDKVoiceCallback>.instance.onBroadcastMsg = new SDKVoiceCallback.OnBroadcastMsg(this.OnBroadcastMsg);
			this.TryInitTalkVoice();
		}

		// Token: 0x06019832 RID: 104498 RVA: 0x0080AF18 File Offset: 0x00809318
		public override void UnInitTalkVoice()
		{
			base.UnInitTalkVoice();
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoiceInitHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onJoinChannelHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onLeaveChannelHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onLeaveAllChanenlHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onPauseChannelHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoiceMicHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onRealVoicePlayerHandler = null;
			MonoSingleton<SDKVoiceCallback>.instance.onChannelMemberChange = null;
			MonoSingleton<SDKVoiceCallback>.instance.onMicChangeByOther = null;
			MonoSingleton<SDKVoiceCallback>.instance.onSetSpeakChannel = null;
			MonoSingleton<SDKVoiceCallback>.instance.onOtherSpeakInChannel = null;
			MonoSingleton<SDKVoiceCallback>.instance.onOtherControlMic = null;
			MonoSingleton<SDKVoiceCallback>.instance.onVoiceTalkMicAuth = null;
			MonoSingleton<SDKVoiceCallback>.instance.onBroadcastMsg = null;
			this.isTalkVoiceInited = false;
			this.playerVolume = 0f;
			this.joinTalkRoomStartTime = 0UL;
			this.voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Resumed;
			this._ResetVoiceTalk();
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().UnInit();
		}

		// Token: 0x06019833 RID: 104499 RVA: 0x0080AFFC File Offset: 0x008093FC
		private void _ResetVoiceTalk()
		{
			this.isTalkMicEnable = true;
			this.isTalkMicMaunalOn = false;
			this.isTalkMicEnableChangedDirty = false;
			this.isTalkMicAutoOn = false;
			this.isTalkMicForceOffDirty = false;
			if (this.talkChannelIds != null)
			{
				this.talkChannelIds.Clear();
			}
			this.currTalkChannelId = string.Empty;
			if (this.otherTalkChannelInfos != null)
			{
				this.otherTalkChannelInfos.Clear();
			}
			this.isLastGlobalSilence = false;
			this.isGlobalSilence = false;
			this.isSetGlobalSilenceSucc = true;
			this.hasReqVoiceAuth = false;
		}

		// Token: 0x06019834 RID: 104500 RVA: 0x0080B07F File Offset: 0x0080947F
		public override void JoinChannel(string channelId)
		{
			if (!this.isTalkVoiceInited)
			{
				return;
			}
			this.TryJoinYoumiTalkChannel(channelId);
		}

		// Token: 0x06019835 RID: 104501 RVA: 0x0080B094 File Offset: 0x00809494
		public override void LeaveAllChannel()
		{
			this.TryLeaveAllYoumiTalkChannel();
		}

		// Token: 0x06019836 RID: 104502 RVA: 0x0080B09C File Offset: 0x0080949C
		public override void LeaveChannel(string channelId)
		{
			this.TryLeaveYoumiTalkChannel(channelId);
		}

		// Token: 0x06019837 RID: 104503 RVA: 0x0080B0A5 File Offset: 0x008094A5
		public override void OpenRealMic()
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.isTalkMicEnableChangedDirty = false;
			this.isTalkMicAutoOn = false;
			YouMeVoiceAPI.GetInstance().SetMicrophoneMute(false);
			this.LogForYouMiTalk("OpenRealMic", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019838 RID: 104504 RVA: 0x0080B0DE File Offset: 0x008094DE
		public override void CloseRealMic()
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.isTalkMicEnableChangedDirty = false;
			YouMeVoiceAPI.GetInstance().SetMicrophoneMute(true);
			this.LogForYouMiTalk("CloseRealMic", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019839 RID: 104505 RVA: 0x0080B110 File Offset: 0x00809510
		private void _CloseRealMicOnMicEnable()
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetMicrophoneMute(true);
			this.LogForYouMiTalk("CloseRealMic On Mic Enable", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601983A RID: 104506 RVA: 0x0080B13B File Offset: 0x0080953B
		public override void OpenRealPlayer()
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetSpeakerMute(false);
			this.LogForYouMiTalk("OpenRealPlayer", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601983B RID: 104507 RVA: 0x0080B166 File Offset: 0x00809566
		public override void CloseReaPlayer()
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetSpeakerMute(true);
			this.LogForYouMiTalk("CloseReaPlayer", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601983C RID: 104508 RVA: 0x0080B191 File Offset: 0x00809591
		public override bool IsTalkRealMicOn()
		{
			return this.CheckYouMiTalkVoiceJoinState() && !YouMeVoiceAPI.GetInstance().GetMicrophoneMute();
		}

		// Token: 0x0601983D RID: 104509 RVA: 0x0080B1AD File Offset: 0x008095AD
		public override bool IsTalkRealPlayerOn()
		{
			return this.CheckYouMiTalkVoiceJoinState() && !YouMeVoiceAPI.GetInstance().GetSpeakerMute();
		}

		// Token: 0x0601983E RID: 104510 RVA: 0x0080B1CC File Offset: 0x008095CC
		public override void SetPlayerVolume(float volume)
		{
			try
			{
				if (volume <= 0f)
				{
					volume = 0f;
				}
				else if (volume > 1f)
				{
					volume = 1f;
				}
				YouMeVoiceAPI.GetInstance().SetVolume((uint)(volume * 100f));
				this.playerVolume = volume;
				this.LogForYouMiTalk("SetPlayerVolume", YouMeErrorCode.YOUME_SUCCESS, "set volume is " + this.playerVolume, SDKVoiceLogLevel.Error);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("Real Talk Voice Set Volumn is Failed : {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x0601983F RID: 104511 RVA: 0x0080B274 File Offset: 0x00809674
		public override float GetPlayerVolume()
		{
			int volume = YouMeVoiceAPI.GetInstance().GetVolume();
			return (float)(volume / 100);
		}

		// Token: 0x06019840 RID: 104512 RVA: 0x0080B291 File Offset: 0x00809691
		public override void PauseChannel()
		{
			if (this.voiceTalkPauseState == YouMiVoiceInterface.VoiceTalkPauseState.Resumed)
			{
				this.talkMethodResult = YouMeVoiceAPI.GetInstance().PauseChannel();
				this.voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Pausing;
				this.LogForYouMiTalk("PauseChannel", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
			}
		}

		// Token: 0x06019841 RID: 104513 RVA: 0x0080B2C8 File Offset: 0x008096C8
		public override void ResumeChannel()
		{
			if (this.voiceTalkPauseState == YouMiVoiceInterface.VoiceTalkPauseState.Paused)
			{
				this.talkMethodResult = YouMeVoiceAPI.GetInstance().ResumeChannel();
				this.voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Resuming;
				this.LogForYouMiTalk("ResumeChannel", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
			}
		}

		// Token: 0x06019842 RID: 104514 RVA: 0x0080B300 File Offset: 0x00809700
		public override bool BeInRealVoiceChannel()
		{
			bool flag = this.CheckYouMiTalkVoiceJoinState();
			this.LogForYouMiTalk("BeInRealVoiceChannel", YouMeErrorCode.YOUME_SUCCESS, (!flag) ? "has not join channel" : "has join chennal", SDKVoiceLogLevel.Error);
			return flag;
		}

		// Token: 0x06019843 RID: 104515 RVA: 0x0080B337 File Offset: 0x00809737
		public override string CurrentTalkChannelId()
		{
			return this.currTalkChannelId;
		}

		// Token: 0x06019844 RID: 104516 RVA: 0x0080B33F File Offset: 0x0080973F
		public override bool IsJoinedTalkChannel(string channelId)
		{
			if (this.talkChannelIds != null)
			{
				return this.talkChannelIds.Contains(channelId);
			}
			return base.IsJoinedTalkChannel(channelId);
		}

		// Token: 0x06019845 RID: 104517 RVA: 0x0080B360 File Offset: 0x00809760
		public override bool HasJoinedTalkChannel()
		{
			return this.talkChannelIds != null && this.talkChannelIds.Count > 0;
		}

		// Token: 0x06019846 RID: 104518 RVA: 0x0080B37D File Offset: 0x0080977D
		public override void SetCurrentTalkChannelId(string channelId)
		{
			this._TrySetSpeackChannelInMultiMode(channelId);
		}

		// Token: 0x06019847 RID: 104519 RVA: 0x0080B388 File Offset: 0x00809788
		public override void UpdateTalkChannel(IList<string> channelIds)
		{
			if (channelIds == null)
			{
				return;
			}
			if (channelIds.Count == 0)
			{
				this.LeaveAllChannel();
				return;
			}
			if (this.talkChannelIds == null)
			{
				return;
			}
			List<string> list = channelIds.Except(this.talkChannelIds);
			List<string> list2 = this.talkChannelIds.Except(channelIds);
			if (list2 != null)
			{
				for (int i = 0; i < list2.Count; i++)
				{
					this.LeaveChannel(list2[i]);
				}
			}
			if (list != null)
			{
				for (int j = 0; j < list.Count; j++)
				{
					this.JoinChannel(list[j]);
				}
			}
		}

		// Token: 0x06019848 RID: 104520 RVA: 0x0080B428 File Offset: 0x00809828
		public override string GetOtherTalkChannelId(string voicePlayerId)
		{
			if (this.otherTalkChannelInfos == null || this.otherTalkChannelInfos.Count <= 0)
			{
				return string.Empty;
			}
			OtheTalkChannelInfo otheTalkChannelInfo = this.otherTalkChannelInfos.Find((OtheTalkChannelInfo x) => x.userId == voicePlayerId);
			if (otheTalkChannelInfo == null)
			{
				return string.Empty;
			}
			return otheTalkChannelInfo.currentTalkChannelId;
		}

		// Token: 0x06019849 RID: 104521 RVA: 0x0080B48E File Offset: 0x0080988E
		public override bool IsMicEnable()
		{
			return this.isTalkMicEnable;
		}

		// Token: 0x0601984A RID: 104522 RVA: 0x0080B496 File Offset: 0x00809896
		public override bool IsGlobalSilence()
		{
			this.LogForYouMiTalk("IsGlobalSilence", this.talkMethodResult, "global silence is " + this.isGlobalSilence, SDKVoiceLogLevel.Error);
			return this.isGlobalSilence;
		}

		// Token: 0x0601984B RID: 104523 RVA: 0x0080B4C8 File Offset: 0x008098C8
		public override void SetGlobalSilenceInMainChannel(string mainChannelId, bool isNotSpeak)
		{
			this._SetGlobalSilenceStatus(isNotSpeak);
			this.LogForYouMiTalk("SetGlobalSilenceInMainChannel", this.talkMethodResult, "1 set global silence " + this.isGlobalSilence, SDKVoiceLogLevel.Error);
			if (string.IsNullOrEmpty(mainChannelId))
			{
				return;
			}
			if (this.talkChannelIds == null || this.talkChannelIds.Count <= 0)
			{
				return;
			}
			if (!this.talkChannelIds.Contains(mainChannelId))
			{
				return;
			}
			this._GetChannelUserList(mainChannelId, true);
		}

		// Token: 0x0601984C RID: 104524 RVA: 0x0080B546 File Offset: 0x00809946
		public override void SetMicEnable(string voicePlayerId, bool bEnable)
		{
			this._SetOtherMicMute(voicePlayerId, !bEnable);
		}

		// Token: 0x0601984D RID: 104525 RVA: 0x0080B554 File Offset: 0x00809954
		private bool TryPlayVoiceByPath(string voicePath)
		{
			if (!this.CheckYoumiChatVoiceLoginState(true))
			{
				return false;
			}
			this.chatMethodResult = IMAPI.Instance().StartPlayAudio(voicePath);
			this.LogForYouMiChat("PlayVoiceSelected", this.chatMethodResult, "curr play voice path is " + voicePath, SDKVoiceLogLevel.Error);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPlayStart, null, null, null, null);
				return true;
			}
			if (this.chatMethodResult == ErrorCode.PTT_IsPlaying)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPlayStart, null, null, null, null);
				return true;
			}
			if (this.chatMethodResult == ErrorCode.NotLogin)
			{
				this.TryLoginYoumiChatVoice(this.cacheChatVoiceAccInfo);
			}
			return false;
		}

		// Token: 0x0601984E RID: 104526 RVA: 0x0080B5FC File Offset: 0x008099FC
		private bool TryStopPlayVoice()
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return false;
			}
			this.chatMethodResult = IMAPI.Instance().StopPlayAudio();
			this.LogForYouMiChat("StopPlayVoice", this.chatMethodResult, string.Empty, SDKVoiceLogLevel.Error);
			return this.chatMethodResult == ErrorCode.Success;
		}

		// Token: 0x0601984F RID: 104527 RVA: 0x0080B64C File Offset: 0x00809A4C
		private bool CheckYoumiChatVoiceLoginState(bool beTryLogin = true)
		{
			if (this.loginVoiceState == YouMiVoiceInterface.LoginVoiceState.Logined)
			{
				return true;
			}
			if (this.loginVoiceState == YouMiVoiceInterface.LoginVoiceState.Logouted)
			{
				if (beTryLogin)
				{
					this.LogForYouMiChat("CheckYoumiChatVoiceLoginState", ErrorCode.Success, "beTryLogin current loginState is " + this.loginVoiceState.ToString(), SDKVoiceLogLevel.Error);
					this.TryLoginYoumiChatVoice(this.cacheChatVoiceAccInfo);
				}
				return false;
			}
			return false;
		}

		// Token: 0x06019850 RID: 104528 RVA: 0x0080B6B0 File Offset: 0x00809AB0
		private void TryLoginYoumiChatVoice(YoumiVoiceGameAccInfo accInfo)
		{
			if (accInfo == null)
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", ErrorCode.NotLogin, "TryLoginYoumiChatVoice accinfo is null", SDKVoiceLogLevel.Error);
				return;
			}
			if (string.IsNullOrEmpty(accInfo.RoleId) || string.IsNullOrEmpty(accInfo.OpenId))
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", ErrorCode.NotLogin, "TryLoginYoumiChatVoice accinfo RoleId is " + accInfo.RoleId + ", OpenId is " + accInfo.OpenId, SDKVoiceLogLevel.Error);
				return;
			}
			this.LogForYouMiChat("TryLoginYoumiChatVoice isChatVoiceInited : ", ErrorCode.Success, this.isChatVoiceInited.ToString(), SDKVoiceLogLevel.Error);
			if (!this.isChatVoiceInited)
			{
				return;
			}
			this.LogForYouMiChat("TryLoginYoumiChatVoice loginVoiceState : ", ErrorCode.Success, this.loginVoiceState.ToString(), SDKVoiceLogLevel.Error);
			if (this.loginVoiceState != YouMiVoiceInterface.LoginVoiceState.Logouted)
			{
				return;
			}
			this.chatMethodResult = IMAPI.Instance().Login(accInfo.RoleId, accInfo.OpenId, accInfo.Token);
			this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logining;
			this.LogForYouMiChat("TryLoginYoumiChatVoice", this.chatMethodResult, string.Concat(new string[]
			{
				"roleId ",
				accInfo.RoleId,
				"| pass ",
				accInfo.OpenId,
				"| token ",
				accInfo.Token
			}), SDKVoiceLogLevel.Error);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", this.chatMethodResult, "is Logining !!!", SDKVoiceLogLevel.Error);
			}
			else if (this.chatMethodResult == ErrorCode.AlreadyLogin)
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", this.chatMethodResult, "已经登录聊天语音了", SDKVoiceLogLevel.Error);
				this.TryLogoutYoumiChatVoice();
			}
			else if (this.chatMethodResult == ErrorCode.ParamInvalid)
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", this.chatMethodResult, "ErrorCode.ParamInvalid !!!", SDKVoiceLogLevel.Error);
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			}
			else
			{
				this.LogForYouMiChat("TryLoginYoumiChatVoice", this.chatMethodResult, "ErrorCode not success !!!", SDKVoiceLogLevel.Error);
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			}
		}

		// Token: 0x06019851 RID: 104529 RVA: 0x0080B890 File Offset: 0x00809C90
		private void TryLogoutYoumiChatVoice()
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			this.LogForYouMiChat("TryLogoutYoumiChatVoice loginVoiceState : ", ErrorCode.Success, this.loginVoiceState.ToString(), SDKVoiceLogLevel.Error);
			if (this.loginVoiceState == YouMiVoiceInterface.LoginVoiceState.Logouting)
			{
				return;
			}
			this.chatMethodResult = IMAPI.Instance().Logout();
			if (this.chatMethodResult != ErrorCode.Success)
			{
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			}
			else
			{
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouting;
			}
			this.LogForYouMiChat("TryLogoutYoumiChatVoice", this.chatMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019852 RID: 104530 RVA: 0x0080B91C File Offset: 0x00809D1C
		private void DownloadAudioFile(AudioInfo audio)
		{
			if (!this.CheckYoumiChatVoiceLoginState(true))
			{
				return;
			}
			if (audio == null)
			{
				this.LogForYouMiChat("DownloadAudioFile audio", ErrorCode.Fail, "AudioInfo audio  is null", SDKVoiceLogLevel.Error);
				return;
			}
			this.chatMethodResult = IMAPI.Instance().DownloadAudioFile(audio.requestId, audio.path);
			this.LogForYouMiChat("DownloadAudioFile audio", this.chatMethodResult, string.Format("AudioInfo audio requestId is {0}, path is {1}", audio.requestId, audio.path), SDKVoiceLogLevel.Error);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				audio.status = DownloadStatus.DS_DOWNLOADING;
			}
			else if (this.chatMethodResult == ErrorCode.NotLogin)
			{
				this.TryLoginYoumiChatVoice(this.cacheChatVoiceAccInfo);
			}
		}

		// Token: 0x06019853 RID: 104531 RVA: 0x0080B9CC File Offset: 0x00809DCC
		private AudioDeviceStatus TryGetMicroPhoneStatus()
		{
			int microphoneStatus = (int)IMAPI.Instance().GetMicrophoneStatus();
			this.LogForYouMiChat("TryGetMicroPhoneStatus", ErrorCode.Success, "尝试获取麦克风状态，是否有权限 是否有麦 : " + (AudioDeviceStatus)microphoneStatus, SDKVoiceLogLevel.Error);
			return (AudioDeviceStatus)microphoneStatus;
		}

		// Token: 0x06019854 RID: 104532 RVA: 0x0080BA04 File Offset: 0x00809E04
		private void TryJoinChatRoom(string chatRoomId, bool beSaveRoomMsg)
		{
			if (string.IsNullOrEmpty(chatRoomId))
			{
				return;
			}
			if (beSaveRoomMsg)
			{
				this.SetSaveHistoryChatRoomMsg(chatRoomId, beSaveRoomMsg);
				this.LogForYouMiChat("SetSaveHistoryChatRoomMsg", ErrorCode.Success, "chatRoomId is " + chatRoomId, SDKVoiceLogLevel.Error);
			}
			this.chatMethodResult = IMAPI.Instance().JoinChatRoom(chatRoomId);
			this.LogForYouMiChat("JoinChatRoom", this.chatMethodResult, "JoinChatRoom id is " + chatRoomId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019855 RID: 104533 RVA: 0x0080BA71 File Offset: 0x00809E71
		private void TryLeaveChatRoom(string chatRoomId)
		{
			this.chatMethodResult = IMAPI.Instance().LeaveChatRoom(chatRoomId);
			this.LogForYouMiChat("LeaveChatRoom", this.chatMethodResult, "LeaveChatRoom id is " + chatRoomId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019856 RID: 104534 RVA: 0x0080BAA1 File Offset: 0x00809EA1
		private string GetFileNameExtension()
		{
			return ".wav";
		}

		// Token: 0x06019857 RID: 104535 RVA: 0x0080BAA8 File Offset: 0x00809EA8
		private bool PlayVoiceQueue()
		{
			if (this.IsVoicePlaying())
			{
				return false;
			}
			if (this.voiceQueue != null)
			{
				if (this.voiceQueue.Count <= 0)
				{
					return false;
				}
				string text = this.voiceQueue.Dequeue();
				if (!string.IsNullOrEmpty(text))
				{
					this.PlayVoiceCommon(text, string.Empty);
					return true;
				}
			}
			return false;
		}

		// Token: 0x06019858 RID: 104536 RVA: 0x0080BB08 File Offset: 0x00809F08
		private void SetSaveHistoryChatRoomMsg(string chatRoomId, bool bSave)
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			List<string> roomIDs = new List<string>
			{
				chatRoomId
			};
			IMAPI.Instance().SetRoomHistoryMessageSwitch(roomIDs, bSave);
		}

		// Token: 0x06019859 RID: 104537 RVA: 0x0080BB3C File Offset: 0x00809F3C
		private void DeleteHistoryChatMsgByTime()
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			ulong serverTimeStamp = Singleton<SDKVoiceManager>.GetInstance().GetServerTimeStamp();
			this.chatMethodResult = IMAPI.Instance().DeleteHistoryMessage(YIMEngine.ChatType.RoomChat, serverTimeStamp);
			this.LogForYouMiChat("DeleteHistoryChatMsgByTime", this.chatMethodResult, "Delete history chat msg by curr time, type Room Chat", SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601985A RID: 104538 RVA: 0x0080BB8C File Offset: 0x00809F8C
		private void DeleteRoomChatMsgOnTime(uint day)
		{
			if (!this.CheckYoumiChatVoiceLoginState(false))
			{
				return;
			}
			uint num = day * 24U * 60U * 60U;
			ulong serverTimeStamp = Singleton<SDKVoiceManager>.GetInstance().GetServerTimeStamp();
			ulong time = serverTimeStamp - (ulong)num;
			this.chatMethodResult = IMAPI.Instance().DeleteHistoryMessage(YIMEngine.ChatType.RoomChat, time);
			this.LogForYouMiChat("DeletePrivateChatMsgOnTime", this.chatMethodResult, "Delete history chat msg by curr time, type Private Chat", SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601985B RID: 104539 RVA: 0x0080BBEA File Offset: 0x00809FEA
		private void DeleteRoomChatMsgByMsgId(ulong msgId)
		{
			this.chatMethodResult = IMAPI.Instance().DeleteHistoryMessageByID(msgId);
			this.LogForYouMiChat("DeleteRoomChatMsgByMsgId", this.chatMethodResult, "Delete history chat msg by msg id : " + msgId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601985C RID: 104540 RVA: 0x0080BC20 File Offset: 0x0080A020
		private void QueryPrivateHistoryMsgByUserId(string targetId, int onceQueryMsgCount, ulong startId = 0UL)
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			if (onceQueryMsgCount < 0)
			{
				return;
			}
			this.chatMethodResult = IMAPI.Instance().QueryHistoryMessage(targetId, YIMEngine.ChatType.RoomChat, startId, onceQueryMsgCount, 0);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				this.isQueryHistoryMsgClear = false;
			}
			this.LogForYouMiChat("QueryPrivateHistoryMsgByUserId", this.chatMethodResult, string.Format("query History private msg , tarId {0} , once query count {1}", targetId, onceQueryMsgCount), SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601985D RID: 104541 RVA: 0x0080BC8C File Offset: 0x0080A08C
		private void QueryHistoryMsgToClear(string chatRoomId, int onceQueryMsgCount, ulong startId = 0UL)
		{
			if (!this.isChatVoiceInited)
			{
				return;
			}
			this.chatMethodResult = IMAPI.Instance().QueryHistoryMessage(chatRoomId, YIMEngine.ChatType.RoomChat, startId, onceQueryMsgCount, 0);
			if (this.chatMethodResult == ErrorCode.Success)
			{
				this.isQueryHistoryMsgClear = true;
			}
			this.LogForYouMiChat("QueryHistoryMsgToClear !", this.chatMethodResult, string.Format("query History private msg , tarId {0} , once query count {1}", chatRoomId, this.privateChatQueryMsgCount), SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601985E RID: 104542 RVA: 0x0080BCF4 File Offset: 0x0080A0F4
		private void TryInitTalkVoice()
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().Init("YOUMEF6EFE7326698A3E3E0AEEEDA02BCA6B6B39EF406", "1VhLqAbGn5Da4gxsIowTYGQYJ1hwLZPOi6YiSBJgzfqskjE5m9Oo0y5+P781O5U9SsK9IURbybKr/YB/4h/qQ3rKTlFmyWDRbNf+gOWPvEq2ilqHhj1K4LKC8Av0ORqSSJQAlDPATj6tzx1LprJL1HLePObGZ5lzDCyVrggJtmcBAAE=", YOUME_RTC_SERVER_REGION.RTC_CN_SERVER, "cn");
			this.LogForYouMiTalk("TryInitTalkVoice", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
			if (this.talkMethodResult == YouMeErrorCode.YOUME_ERROR_WRONG_STATE)
			{
				this.isTalkVoiceInited = true;
			}
		}

		// Token: 0x0601985F RID: 104543 RVA: 0x0080BD4C File Offset: 0x0080A14C
		private void TryJoinYoumiTalkChannel(string channelId)
		{
			if (string.IsNullOrEmpty(channelId))
			{
				this.LogForYouMiTalk("TryJoinYoumiTalkChannel", YouMeErrorCode.YOUME_ERROR_INVALID_PARAM, "TryLoginYoumiChatVoice channelId is null", SDKVoiceLogLevel.Error);
				return;
			}
			if (this.cacheChatVoiceAccInfo == null || this.cacheChatVoiceAccInfo.RoleId == string.Empty)
			{
				this.LogForYouMiTalk("TryJoinYoumiTalkChannel", YouMeErrorCode.YOUME_ERROR_INVALID_PARAM, "TryLoginYoumiChatVoice accinfo roleid is " + this.cacheChatVoiceAccInfo.RoleId, SDKVoiceLogLevel.Error);
				return;
			}
			if (!this.isTalkVoiceInited)
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().JoinChannelMultiMode(this.cacheChatVoiceAccInfo.RoleId, channelId, YouMeUserRole.YOUME_USER_TALKER_FREE, false);
			this._ReportJoinTalkChannel(channelId, "start");
			this.LogForYouMiTalk("TryJoinYoumiTalkChannel", this.talkMethodResult, "res :RoleId : " + this.cacheChatVoiceAccInfo.RoleId + "TalkChannelId : " + channelId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019860 RID: 104544 RVA: 0x0080BE24 File Offset: 0x0080A224
		private void TryLeaveAllYoumiTalkChannel()
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().LeaveChannelAll();
			this.LogForYouMiTalk("LeaveChannel", this.talkMethodResult, "离开全部频道", SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019861 RID: 104545 RVA: 0x0080BE4D File Offset: 0x0080A24D
		private void TryLeaveYoumiTalkChannel(string channelId)
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().LeaveChannelMultiMode(channelId);
			this.LogForYouMiTalk("LeaveChannel", this.talkMethodResult, "离开指定频道: channel id = " + channelId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019862 RID: 104546 RVA: 0x0080BE7D File Offset: 0x0080A27D
		private void _TrySetSpeackChannelInMultiMode(string channelId)
		{
			if (string.IsNullOrEmpty(channelId))
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SpeakToChannel(channelId);
			this.LogForYouMiTalk("Speak To Channel", this.talkMethodResult, "指定讲话频道 ：channel id = " + channelId, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019863 RID: 104547 RVA: 0x0080BEBC File Offset: 0x0080A2BC
		private bool CheckYouMiTalkVoiceJoinState()
		{
			bool result = false;
			if (this.talkChannelIds != null)
			{
				result = (this.talkChannelIds.Count > 0);
			}
			return result;
		}

		// Token: 0x06019864 RID: 104548 RVA: 0x0080BEE6 File Offset: 0x0080A2E6
		private void SetMobileNetworkEnabled(bool enabled)
		{
			if (this.GetMobileNetworkEnabled() == enabled)
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetUseMobileNetworkEnabled(enabled);
			this.LogForYouMiTalk("SetMobileNetworkEnabled", YouMeErrorCode.YOUME_SUCCESS, "是否允许在移动网络下可用 实时语音 isAllow : " + enabled, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019865 RID: 104549 RVA: 0x0080BF1D File Offset: 0x0080A31D
		public bool GetMobileNetworkEnabled()
		{
			return YouMeVoiceAPI.GetInstance().GetUseMobileNetworkEnabled();
		}

		// Token: 0x06019866 RID: 104550 RVA: 0x0080BF29 File Offset: 0x0080A329
		private void SetYoumiReleaseMicWhenMicOff(bool isRelease)
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetReleaseMicWhenMute(isRelease);
			this.LogForYouMiTalk("SetYoumiReleaseMicWhenMicOff", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019867 RID: 104551 RVA: 0x0080BF53 File Offset: 0x0080A353
		private void SetYoumiHeadsetMontorOn(bool enabled)
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetHeadsetMonitorOn(enabled, enabled);
			this.LogForYouMiTalk("SetYoumiHeadsetMontorOn", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019868 RID: 104552 RVA: 0x0080BF8A File Offset: 0x0080A38A
		private void SetYoumiAutoSendStatus(bool isAutoSend)
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			YouMeVoiceAPI.GetInstance().SetAutoSendStatus(isAutoSend);
			this.LogForYouMiTalk("SetYoumiAutoSendStatus", YouMeErrorCode.YOUME_SUCCESS, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019869 RID: 104553 RVA: 0x0080BFB5 File Offset: 0x0080A3B5
		private void SetYoumiTalkVoiceListener(bool isOpen)
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetVadCallbackEnabled(isOpen);
			this.LogForYouMiTalk("SetYoumiTalkVoiceListener", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601986A RID: 104554 RVA: 0x0080BFEB File Offset: 0x0080A3EB
		private void SetYoumiOutputToPlayer(bool outToPlayer)
		{
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetOutputToSpeaker(outToPlayer);
			this.LogForYouMiTalk("SetOutputToPlayer", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601986B RID: 104555 RVA: 0x0080C024 File Offset: 0x0080A424
		private void _GetChannelUserList(string channelId, bool stayListen)
		{
			if (string.IsNullOrEmpty(channelId))
			{
				return;
			}
			if (!this.CheckYouMiTalkVoiceJoinState())
			{
				return;
			}
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().GetChannelUserList(channelId, -1, stayListen);
			this.LogForYouMiTalk("_GetChannelUserList", this.talkMethodResult, string.Empty, SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601986C RID: 104556 RVA: 0x0080C073 File Offset: 0x0080A473
		private bool _SetOtherMicStatus(string userId)
		{
			return !string.IsNullOrEmpty(userId) && (this.cacheChatVoiceAccInfo == null || !(this.cacheChatVoiceAccInfo.RoleId == userId)) && this._SetOtherMicMute(userId, this.isGlobalSilence);
		}

		// Token: 0x0601986D RID: 104557 RVA: 0x0080C0B4 File Offset: 0x0080A4B4
		private bool _SetOtherMicMute(string userId, bool isMute)
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetOtherMicMute(userId, isMute);
			this.LogForYouMiTalk("_SetOtherMicStatus", this.talkMethodResult, "Set Other Mic Mute : " + isMute, SDKVoiceLogLevel.Error);
			return this.talkMethodResult == YouMeErrorCode.YOUME_SUCCESS;
		}

		// Token: 0x0601986E RID: 104558 RVA: 0x0080C104 File Offset: 0x0080A504
		private bool _SetListenOtherVoice(string userId, bool isOn)
		{
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SetListenOtherVoice(userId, isOn);
			this.LogForYouMiTalk("_SetListenOtherVoice", this.talkMethodResult, "Set Listen Other Voice : " + isOn, SDKVoiceLogLevel.Error);
			return this.talkMethodResult == YouMeErrorCode.YOUME_SUCCESS;
		}

		// Token: 0x0601986F RID: 104559 RVA: 0x0080C153 File Offset: 0x0080A553
		private void _SetSendSelfMicAndPlayerStatus(bool bSend)
		{
			YouMeVoiceAPI.GetInstance().SetAutoSendStatus(bSend);
		}

		// Token: 0x06019870 RID: 104560 RVA: 0x0080C160 File Offset: 0x0080A560
		private void _SendBroadcastMsg(string talkChannelId, string content)
		{
			int num = 0;
			this.talkMethodResult = YouMeVoiceAPI.GetInstance().SendMessage(talkChannelId, content, ref num);
			this.LogForYouMiTalk("SendBroadcastMsg", this.talkMethodResult, "Set Broadcast Message : " + talkChannelId + " msg : " + content, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019871 RID: 104561 RVA: 0x0080C1A8 File Offset: 0x0080A5A8
		private string _GenerateBroadcastMsg(YouMiVoiceInterface.TalkBroadcastType type, string param1 = "")
		{
			if (type == YouMiVoiceInterface.TalkBroadcastType.None || type == YouMiVoiceInterface.TalkBroadcastType.Count)
			{
				return string.Empty;
			}
			string arg = YouMiVoiceInterface.TALK_BROADCAST_TYPES[(int)type];
			string arg2 = string.Empty;
			if (this.cacheChatVoiceAccInfo != null)
			{
				arg2 = this.cacheChatVoiceAccInfo.RoleId;
			}
			if (string.IsNullOrEmpty(param1))
			{
				return string.Format("{0}|{1}", arg, arg2);
			}
			return string.Format("{0}|{1}|{2}", arg, arg2, param1);
		}

		// Token: 0x06019872 RID: 104562 RVA: 0x0080C214 File Offset: 0x0080A614
		private string _GetVoicePlayerIdFromBCMsg(string[] broadcastMsgs)
		{
			string empty = string.Empty;
			if (broadcastMsgs == null || broadcastMsgs.Length < 2)
			{
				return empty;
			}
			return broadcastMsgs[1];
		}

		// Token: 0x06019873 RID: 104563 RVA: 0x0080C240 File Offset: 0x0080A640
		private string _GetVoicePlayerIdFromBCMsg(string broadcastMsg)
		{
			string empty = string.Empty;
			if (string.IsNullOrEmpty(broadcastMsg))
			{
				return empty;
			}
			string[] broadcastMsgs = broadcastMsg.Split(new char[]
			{
				'|'
			});
			return this._GetVoicePlayerIdFromBCMsg(broadcastMsgs);
		}

		// Token: 0x06019874 RID: 104564 RVA: 0x0080C27C File Offset: 0x0080A67C
		private YouMiVoiceInterface.TalkBroadcastType _GetTalkBroadcastTypeFromBCMsg(string[] broadcastMsgs)
		{
			if (broadcastMsgs == null || broadcastMsgs.Length < 2)
			{
				return YouMiVoiceInterface.TalkBroadcastType.None;
			}
			string b = broadcastMsgs[0];
			for (int i = 0; i < YouMiVoiceInterface.TALK_BROADCAST_TYPES.Length; i++)
			{
				if (YouMiVoiceInterface.TALK_BROADCAST_TYPES[i] == b)
				{
					return (YouMiVoiceInterface.TalkBroadcastType)i;
				}
			}
			return YouMiVoiceInterface.TalkBroadcastType.None;
		}

		// Token: 0x06019875 RID: 104565 RVA: 0x0080C2CC File Offset: 0x0080A6CC
		private YouMiVoiceInterface.TalkBroadcastType _GetTalkBroadcastTypeFromBCMsg(string broadcastMsg)
		{
			if (string.IsNullOrEmpty(broadcastMsg))
			{
				return YouMiVoiceInterface.TalkBroadcastType.None;
			}
			string[] broadcastMsgs = broadcastMsg.Split(new char[]
			{
				'|'
			});
			return this._GetTalkBroadcastTypeFromBCMsg(broadcastMsgs);
		}

		// Token: 0x06019876 RID: 104566 RVA: 0x0080C300 File Offset: 0x0080A700
		private string _GetVoiceParam1FromBCMsg(string[] broadcastMsgs)
		{
			string empty = string.Empty;
			if (broadcastMsgs == null || broadcastMsgs.Length < 3)
			{
				return empty;
			}
			return broadcastMsgs[2];
		}

		// Token: 0x06019877 RID: 104567 RVA: 0x0080C32C File Offset: 0x0080A72C
		private string _GetVoiceParam1FromBCMsg(string broadcastMsg)
		{
			string empty = string.Empty;
			if (string.IsNullOrEmpty(broadcastMsg))
			{
				return empty;
			}
			string[] broadcastMsgs = broadcastMsg.Split(new char[]
			{
				'|'
			});
			return this._GetVoiceParam1FromBCMsg(broadcastMsgs);
		}

		// Token: 0x06019878 RID: 104568 RVA: 0x0080C367 File Offset: 0x0080A767
		public void OnUpdateLocation(ErrorCode errorcode, GeographyLocation location)
		{
		}

		// Token: 0x06019879 RID: 104569 RVA: 0x0080C369 File Offset: 0x0080A769
		public void OnGetNearbyObjects(ErrorCode errorcode, List<RelativeLocation> neighbourList, uint startDistance, uint endDistance)
		{
		}

		// Token: 0x0601987A RID: 104570 RVA: 0x0080C36B File Offset: 0x0080A76B
		public void OnGetContact(List<ContactsSessionInfo> contactLists)
		{
		}

		// Token: 0x0601987B RID: 104571 RVA: 0x0080C36D File Offset: 0x0080A76D
		public void OnGetUserInfo(ErrorCode code, string userID, IMUserInfo userInfo)
		{
		}

		// Token: 0x0601987C RID: 104572 RVA: 0x0080C36F File Offset: 0x0080A76F
		public void OnQueryUserStatus(ErrorCode code, string userID, UserStatus status)
		{
		}

		// Token: 0x0601987D RID: 104573 RVA: 0x0080C374 File Offset: 0x0080A774
		public void OnPlayCompletion(ErrorCode errorcode, string path)
		{
			this.LogForYouMiChat("OnPlayCompletion", errorcode, "voice play end , voice path is " + path, SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success || errorcode == ErrorCode.PTT_IsPlaying)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPlayEnd, null, null, null, null);
				if (this.voiceQueue != null && this.voiceQueue.Count > 0)
				{
					this.LogForYouMiChat("Start Play Voice Queue", errorcode, "curr voice queue length is " + this.voiceQueue.Count, SDKVoiceLogLevel.Error);
					this.PlayVoiceQueue();
				}
				else
				{
					this.LogForYouMiChat("Start Play Voice Queue is NULL, could do some things other", errorcode, string.Empty, SDKVoiceLogLevel.Error);
				}
			}
		}

		// Token: 0x0601987E RID: 104574 RVA: 0x0080C41E File Offset: 0x0080A81E
		public void OnGetMicrophoneStatus(AudioDeviceStatus status)
		{
			this.LogForYouMiChat("OnGetMicrophoneStatus", ErrorCode.Success, "curr AudioDeviceStatus is " + status.ToString(), SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601987F RID: 104575 RVA: 0x0080C444 File Offset: 0x0080A844
		public void OnJoinRoom(ErrorCode errorcode, string strChatRoomID)
		{
			this.LogForYouMiChat("OnJoinRoom", errorcode, "strChatRoomID = " + strChatRoomID, SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPrivateJoin, strChatRoomID, null, null, null);
				if (this.voiceChatRoomIdList != null && !this.voiceChatRoomIdList.Contains(strChatRoomID))
				{
					this.voiceChatRoomIdList.Add(strChatRoomID);
				}
			}
		}

		// Token: 0x06019880 RID: 104576 RVA: 0x0080C4AF File Offset: 0x0080A8AF
		public void OnLeaveRoom(ErrorCode errorcode, string strChatRoomID)
		{
			this.LogForYouMiChat("OnLeaveRoom", errorcode, "strChatRoomID = " + strChatRoomID, SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatPrivateLeave, strChatRoomID, null, null, null);
			}
		}

		// Token: 0x06019881 RID: 104577 RVA: 0x0080C4E7 File Offset: 0x0080A8E7
		public void OnUserJoinChatRoom(string strRoomID, string strUserID)
		{
			this.LogForYouMiChat("OnUserJoinChatRoom", ErrorCode.Success, "有玩家 : " + strUserID + ",加入了房间 ：strChatRoomID = " + strRoomID, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019882 RID: 104578 RVA: 0x0080C507 File Offset: 0x0080A907
		public void OnUserLeaveChatRoom(string strRoomID, string strUserID)
		{
			this.LogForYouMiChat("OnUserLeaveChatRoom", ErrorCode.Success, "有玩家 : " + strUserID + ",离开了房间 ：strChatRoomID = " + strRoomID, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019883 RID: 104579 RVA: 0x0080C527 File Offset: 0x0080A927
		public void OnGetRoomMemberCount(ErrorCode errorcode, string strRoomID, uint count)
		{
			this.LogForYouMiChat("OnGetRoomMemberCount", errorcode, strRoomID + " 号房间内当前一共有玩家人数 : " + count, SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019884 RID: 104580 RVA: 0x0080C547 File Offset: 0x0080A947
		public void OnSendMessageStatus(ulong iRequestID, ErrorCode errorcode, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime)
		{
		}

		// Token: 0x06019885 RID: 104581 RVA: 0x0080C54C File Offset: 0x0080A94C
		public void OnRecvMessage(MessageInfoBase message)
		{
			if (message == null)
			{
				return;
			}
			if (message.MessageType == MessageBodyType.Voice)
			{
				this.LogForYouMiChat("OnRecvMessage", ErrorCode.Success, "message is voice", SDKVoiceLogLevel.Error);
				VoiceMessage voiceMessage = message as VoiceMessage;
				if (voiceMessage == null)
				{
					return;
				}
				this.LogForYouMiChat("OnRecvMessage", ErrorCode.Success, string.Concat(new object[]
				{
					"message is voice  req id is ",
					voiceMessage.RequestID,
					" | req token is ",
					voiceMessage.Param
				}), SDKVoiceLogLevel.Error);
				if (string.IsNullOrEmpty(voiceMessage.Param))
				{
					return;
				}
				AudioInfo audioInfo = new AudioInfo();
				audioInfo.token = voiceMessage.Param;
				audioInfo.requestId = voiceMessage.RequestID;
				audioInfo.status = DownloadStatus.DS_NOTDOWNLOAD;
				audioInfo.path = this.BuildRequestIdPath(audioInfo.requestId);
				GameClient.ChatType chatTypeInVoiceKey = Singleton<SDKVoiceManager>.GetInstance().GetChatTypeInVoiceKey(voiceMessage.Param);
				audioInfo.bPrivate = (chatTypeInVoiceKey == GameClient.ChatType.CT_PRIVATE);
				this.LogForYouMiChat("OnRecvMessage", ErrorCode.Success, string.Format("AudioInfo token : {0}, requestId : {1}, path : {2} , is private ：{3}", new object[]
				{
					audioInfo.token,
					audioInfo.requestId,
					audioInfo.path,
					audioInfo.bPrivate
				}), SDKVoiceLogLevel.Error);
				if (this._AudioCache.ContainsKey(voiceMessage.Param))
				{
					this.LogForYouMiChat("OnRecvMessage", ErrorCode.Success, "TOKEN冲突", SDKVoiceLogLevel.Error);
					this._AudioCache.Remove(voiceMessage.Param);
				}
				this._AudioCache.Add(voiceMessage.Param, audioInfo);
				if (audioInfo.token.Equals(this._currentReqPlayAudioToken))
				{
					this.DownloadAudioFile(audioInfo);
				}
			}
			else
			{
				this.LogForYouMiChat("OnRecvMessage", ErrorCode.Success, "message is not voice", SDKVoiceLogLevel.Error);
			}
		}

		// Token: 0x06019886 RID: 104582 RVA: 0x0080C704 File Offset: 0x0080AB04
		public void OnStartSendAudioMessage(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration)
		{
			this.isRecording = false;
			this.LogForYouMiChat("OnStartSendAudioMessage", errorcode, string.Format("reqID {0} , text {1} , path {2} , duration {3}", new object[]
			{
				iRequestID,
				strText,
				strAudioPath,
				iDuration
			}), SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success || errorcode == ErrorCode.PTT_ReachMaxDuration)
			{
				if (string.IsNullOrEmpty(strText))
				{
					strText = TR.Value("voice_sdk_message");
				}
				if (string.IsNullOrEmpty(this._leastLocalAudioToken))
				{
					this.LogForYouMiChat("OnStartSendAudioMessage", errorcode, "这条消息没有透传参数", SDKVoiceLogLevel.Error);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatSendFailed, null, null, null, null);
					return;
				}
				if (this._AudioCache.ContainsKey(this._leastLocalAudioToken))
				{
					this.LogForYouMiChat("OnStartSendAudioMessage", errorcode, "TOKEN冲突", SDKVoiceLogLevel.Error);
					this._AudioCache.Remove(this._leastLocalAudioToken);
				}
				AudioInfo audioInfo = new AudioInfo();
				audioInfo.token = this._leastLocalAudioToken;
				audioInfo.requestId = iRequestID;
				audioInfo.path = strAudioPath;
				audioInfo.status = DownloadStatus.DS_SUCCESS;
				audioInfo.bPrivate = (this._leasetLocalAudioChatType == GameClient.ChatType.CT_PRIVATE);
				this._AudioCache.Add(this._leastLocalAudioToken, audioInfo);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatSendStart, this._leastLocalAudioToken, strText, strAudioPath, iDuration);
				this._leastLocalAudioToken = string.Empty;
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatRecordFailed, null, null, null, null);
			}
		}

		// Token: 0x06019887 RID: 104583 RVA: 0x0080C880 File Offset: 0x0080AC80
		public void OnSendAudioMessageStatus(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime)
		{
			this.isRecording = false;
			this.LogForYouMiChat("OnSendAudioMessageStatus", errorcode, string.Format("reqID {0} , text {1} , path {2} , duration {3} , sendTime {4}", new object[]
			{
				iRequestID,
				strText,
				strAudioPath,
				iDuration,
				sendTime
			}), SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success || errorcode == ErrorCode.PTT_ReachMaxDuration)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatSendSucc, null, null, null, null);
				string text = string.Empty;
				if (this.cacheChatVoiceAccInfo != null)
				{
					text = this.cacheChatVoiceAccInfo.YoumiId;
				}
				Singleton<SDKVoiceManager>.GetInstance().ReportUsingVoice(CustomLogReportType.CLRT_SEND_RECORD_VOICE, iRequestID + string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatSendFailed, null, null, null, null);
			}
		}

		// Token: 0x06019888 RID: 104584 RVA: 0x0080C94C File Offset: 0x0080AD4C
		public void OnStopAudioSpeechStatus(ErrorCode errorcode, ulong iRequestID, string strDownloadURL, int iDuration, int iFileSize, string strLocalPath, string strText)
		{
			this.LogForYouMiChat("OnStopAudioSpeechStatus", errorcode, string.Format("reqID {0} , text {1} , path {2} , duration {3", new object[]
			{
				iRequestID,
				strText,
				strLocalPath,
				iDuration
			}), SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatRecordEnd, null, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnVoiceChatRecordFailed, null, null, null, null);
			}
		}

		// Token: 0x06019889 RID: 104585 RVA: 0x0080C9C4 File Offset: 0x0080ADC4
		public void OnRecordVolume(int volume)
		{
			this.LogForYouMiChat("OnRecordVolume", ErrorCode.Success, string.Format("当前录音音量为 ： " + volume, new object[0]), SDKVoiceLogLevel.Error);
		}

		// Token: 0x0601988A RID: 104586 RVA: 0x0080C9F0 File Offset: 0x0080ADF0
		public void OnQueryHistoryMessage(ErrorCode errorcode, string targetID, int remain, List<HistoryMsg> messageList)
		{
			this.LogForYouMiChat("OnQueryHistoryMessage", errorcode, string.Format("OnQueryHistoryMessage targetId is {0}, remain msg num is {1}", targetID, remain), SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				if (messageList == null)
				{
					Logger.LogError("OnQueryHistoryMessage callback messageList is null !!!");
					return;
				}
				this.LogForYouMiChat("OnQueryHistoryMessage", errorcode, string.Format("OnQueryHistoryMessage msgListCount is {0}", messageList.Count), SDKVoiceLogLevel.Error);
				bool flag = false;
				int count = messageList.Count;
				int num = count + remain;
				if (this.isQueryHistoryMsgClear)
				{
					for (int i = 0; i < messageList.Count; i++)
					{
						HistoryMsg historyMsg = messageList[i];
						if (historyMsg.MessageType != MessageBodyType.Voice)
						{
							return;
						}
						string param = historyMsg.Param;
						GameClient.ChatType chatTypeInVoiceKey = Singleton<SDKVoiceManager>.GetInstance().GetChatTypeInVoiceKey(param);
						if (chatTypeInVoiceKey != GameClient.ChatType.CT_PRIVATE)
						{
							this.DeleteRoomChatMsgByMsgId(historyMsg.MessageID);
						}
					}
					if (remain > 0)
					{
						int num2 = num - count;
						if (this.privateChatQueryMsgCount > remain)
						{
							this.QueryHistoryMsgToClear(targetID, remain, (ulong)((long)num2));
						}
						else
						{
							this.QueryHistoryMsgToClear(targetID, this.privateChatQueryMsgCount, (ulong)((long)num2));
						}
						return;
					}
					if (this.voiceChatRoomIdList == null)
					{
						this.TryLogoutYoumiChatVoice();
						return;
					}
					if (this.voiceChatRoomIdList.Contains(targetID))
					{
						this.voiceChatRoomIdList.Remove(targetID);
					}
					if (this.voiceChatRoomIdList.Count <= 0)
					{
						this.TryLogoutYoumiChatVoice();
						return;
					}
					this.QueryHistoryMsgToClear(this.voiceChatRoomIdList[0], this.privateChatQueryMsgCount, 0UL);
					return;
				}
				else
				{
					for (int j = 0; j < count; j++)
					{
						HistoryMsg historyMsg2 = messageList[j];
						if (historyMsg2.MessageType == MessageBodyType.Voice && historyMsg2.ChatType == YIMEngine.ChatType.RoomChat && historyMsg2.Param.Equals(this._currentReqPlayAudioToken))
						{
							this.TryPlayVoiceByPath(historyMsg2.LocalPath);
							flag = true;
							this.LogForYouMiChat("OnQueryHistoryMessage", errorcode, string.Format("hMsg MessageType sendId is {0} , recId is {1} , MessageID is {2}", historyMsg2.SenderID, historyMsg2.ReceiveID, historyMsg2.MessageID), SDKVoiceLogLevel.Error);
							break;
						}
					}
					if (remain <= 0)
					{
						return;
					}
					if (!flag)
					{
						int num3 = num - count;
						if (this.privateChatQueryMsgCount > remain)
						{
							this.QueryPrivateHistoryMsgByUserId(targetID, remain, (ulong)((long)num3));
						}
						else
						{
							this.QueryPrivateHistoryMsgByUserId(targetID, this.privateChatQueryMsgCount, (ulong)((long)num3));
						}
					}
				}
			}
		}

		// Token: 0x0601988B RID: 104587 RVA: 0x0080CC40 File Offset: 0x0080B040
		public void OnRecvNewMessage(YIMEngine.ChatType chatType, string targetID)
		{
		}

		// Token: 0x0601988C RID: 104588 RVA: 0x0080CC42 File Offset: 0x0080B042
		public void OnAccusationResultNotify(AccusationDealResult result, string userID, uint accusationTime)
		{
		}

		// Token: 0x0601988D RID: 104589 RVA: 0x0080CC44 File Offset: 0x0080B044
		public void OnGetForbiddenSpeakInfo(ErrorCode errorcode, List<ForbiddenSpeakInfo> forbiddenSpeakList)
		{
		}

		// Token: 0x0601988E RID: 104590 RVA: 0x0080CC46 File Offset: 0x0080B046
		public void OnGetRecognizeSpeechText(ulong iRequestID, ErrorCode errorcode, string text)
		{
		}

		// Token: 0x0601988F RID: 104591 RVA: 0x0080CC48 File Offset: 0x0080B048
		public void OnBlockUser(ErrorCode errorcode, string userID, bool block)
		{
		}

		// Token: 0x06019890 RID: 104592 RVA: 0x0080CC4A File Offset: 0x0080B04A
		public void OnUnBlockAllUser(ErrorCode errorcode)
		{
		}

		// Token: 0x06019891 RID: 104593 RVA: 0x0080CC4C File Offset: 0x0080B04C
		public void OnGetBlockUsers(ErrorCode errorcode, List<string> userList)
		{
		}

		// Token: 0x06019892 RID: 104594 RVA: 0x0080CC50 File Offset: 0x0080B050
		public void OnLogin(ErrorCode errorcode, string strYouMeID)
		{
			this.LogForYouMiChat("OnLogin", errorcode, "login strYouMeID " + strYouMeID, SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logined;
				if (this.cacheChatVoiceAccInfo != null)
				{
					this.cacheChatVoiceAccInfo.YoumiId = strYouMeID;
				}
				if (this.onVoiceChatLoginHandler != null)
				{
					this.onVoiceChatLoginHandler();
				}
			}
			else
			{
				this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			}
		}

		// Token: 0x06019893 RID: 104595 RVA: 0x0080CCBB File Offset: 0x0080B0BB
		public void OnLogout()
		{
			this.LogForYouMiChat("OnLogout !", ErrorCode.Success, string.Empty, SDKVoiceLogLevel.Error);
			this.loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;
			if (this.onVoiceChatLogoutHandler != null)
			{
				this.onVoiceChatLogoutHandler();
			}
		}

		// Token: 0x06019894 RID: 104596 RVA: 0x0080CCEC File Offset: 0x0080B0EC
		public void OnDownload(ErrorCode errorcode, MessageInfoBase message, string strSavePath)
		{
			this.LogForYouMiChat("OnDownload", errorcode, string.Concat(new object[]
			{
				"message RequestID : ",
				message.RequestID,
				" , savePath : ",
				strSavePath
			}), SDKVoiceLogLevel.Error);
			if (errorcode == ErrorCode.Success)
			{
				if (string.IsNullOrEmpty(strSavePath))
				{
					return;
				}
				VoiceMessage voiceMessage = message as VoiceMessage;
				if (voiceMessage == null)
				{
					return;
				}
				string text = string.Empty;
				if (this.cacheChatVoiceAccInfo != null)
				{
					text = this.cacheChatVoiceAccInfo.YoumiId;
				}
				Singleton<SDKVoiceManager>.GetInstance().ReportUsingVoice(CustomLogReportType.CLRT_LOAD_RECORD_VOICE, voiceMessage.RequestID + string.Empty);
				if (this._AudioCache == null)
				{
					return;
				}
				AudioInfo audioInfo;
				if (!this._AudioCache.ContainsKey(voiceMessage.Param))
				{
					this.LogForYouMiChat("OnDownload", errorcode, "下载了未知的音频文件", SDKVoiceLogLevel.Error);
					audioInfo = new AudioInfo();
					audioInfo.token = voiceMessage.Param;
					audioInfo.requestId = voiceMessage.RequestID;
					audioInfo.path = strSavePath;
					audioInfo.status = DownloadStatus.DS_SUCCESS;
					this._AudioCache.Add(voiceMessage.Param, audioInfo);
					return;
				}
				audioInfo = this._AudioCache[voiceMessage.Param];
				audioInfo.status = DownloadStatus.DS_SUCCESS;
				audioInfo.path = strSavePath;
				if (audioInfo.token.Equals(this._currentReqPlayAudioToken))
				{
					this.TryPlayVoiceByPath(audioInfo.path);
				}
			}
		}

		// Token: 0x06019895 RID: 104597 RVA: 0x0080CE48 File Offset: 0x0080B248
		public void OnDownloadByUrl(ErrorCode errorcode, string strFromUrl, string strSavePath)
		{
			this.LogForYouMiChat("OnDownloadByUrl", errorcode, "通过URL下载语音文件到指定路径", SDKVoiceLogLevel.Error);
		}

		// Token: 0x06019896 RID: 104598 RVA: 0x0080CE5C File Offset: 0x0080B25C
		public void OnKickOff()
		{
		}

		// Token: 0x06019897 RID: 104599 RVA: 0x0080CE5E File Offset: 0x0080B25E
		public void OnQueryRoomHistoryMessageFromServer(ErrorCode errorcode, string roomID, int remain, List<MessageInfoBase> messageList)
		{
		}

		// Token: 0x06019898 RID: 104600 RVA: 0x0080CE60 File Offset: 0x0080B260
		public void OnRecordVolumeChange(float volume)
		{
		}

		// Token: 0x06019899 RID: 104601 RVA: 0x0080CE62 File Offset: 0x0080B262
		public void OnLeaveAllRooms(ErrorCode errorcode)
		{
		}

		// Token: 0x0601989A RID: 104602 RVA: 0x0080CE64 File Offset: 0x0080B264
		public void OnGetDistance(ErrorCode errorcode, string userID, uint distance)
		{
		}

		// Token: 0x0601989B RID: 104603 RVA: 0x0080CE66 File Offset: 0x0080B266
		public void OnTalkVoiceInit(bool isInited, YouMeErrorCode errorCode)
		{
			this.isTalkVoiceInited = isInited;
			this.LogForYouMiTalk("OnTalkVoiceInit", errorCode, string.Empty, SDKVoiceLogLevel.Error);
			if (isInited)
			{
				this.SetMobileNetworkEnabled(true);
				this.SetYoumiReleaseMicWhenMicOff(true);
			}
		}

		// Token: 0x0601989C RID: 104604 RVA: 0x0080CE98 File Offset: 0x0080B298
		public void OnTalkVoiceJoinChannel(bool isSuccess, string channelId, YouMeErrorCode errorCode)
		{
			this.LogForYouMiTalk("OnTalkVoiceJoinChannel", errorCode, string.Format("join channel {0} res is {1}", channelId, isSuccess), SDKVoiceLogLevel.Error);
			if (isSuccess)
			{
				if (this.talkChannelIds != null && !this.talkChannelIds.Contains(channelId))
				{
					this.talkChannelIds.Add(channelId);
				}
				this.JoinTalkChannelSucc();
				this.SetYoumiAutoSendStatus(true);
				this.SetYoumiTalkVoiceListener(true);
				this._ReportJoinTalkChannel(channelId, "end");
				if (!this.hasReqVoiceAuth)
				{
					AudioDeviceStatus audioDeviceStatus = this.TryGetMicroPhoneStatus();
					if (audioDeviceStatus != AudioDeviceStatus.STATUS_AVAILABLE)
					{
						this.TalkVoiceMicAuthNoPermission();
					}
					this.hasReqVoiceAuth = true;
				}
			}
		}

		// Token: 0x0601989D RID: 104605 RVA: 0x0080CF38 File Offset: 0x0080B338
		private void _ReportJoinTalkChannel(string channelId, string type)
		{
			if (!string.IsNullOrEmpty(channelId))
			{
				this.joinTalkRoomStartTime = Singleton<SDKVoiceManager>.GetInstance().GetServerTimeStamp();
				string param = string.Format("{0}|{1}|{2}", channelId, this.joinTalkRoomStartTime, type);
				Singleton<SDKVoiceManager>.GetInstance().ReportUsingVoice(CustomLogReportType.CLRT_JOIN_VOICE_ROOM, param);
			}
		}

		// Token: 0x0601989E RID: 104606 RVA: 0x0080CF84 File Offset: 0x0080B384
		private void _ReportLeaveTalkeChannel(string channelId = "")
		{
			if (this.joinTalkRoomStartTime > 0UL)
			{
				ulong serverTimeStamp = Singleton<SDKVoiceManager>.GetInstance().GetServerTimeStamp();
				ulong num = serverTimeStamp - this.joinTalkRoomStartTime;
				this.joinTalkRoomStartTime = 0UL;
				string param = string.Empty;
				if (string.IsNullOrEmpty(channelId))
				{
					param = num.ToString();
				}
				else
				{
					param = string.Format("{0}|{1}", channelId, num);
				}
				Singleton<SDKVoiceManager>.GetInstance().ReportUsingVoice(CustomLogReportType.CLRT_QUIT_VOICE_ROOM, param);
			}
		}

		// Token: 0x0601989F RID: 104607 RVA: 0x0080CFFC File Offset: 0x0080B3FC
		public void OnTalkVoiceLeaveChannel(bool isSuccess, string channelId, YouMeErrorCode errorCode)
		{
			if (isSuccess)
			{
				if (this.talkChannelIds != null)
				{
					this.talkChannelIds.Remove(channelId);
				}
				this.LeaveTalkChannelSucc();
				this._ReportLeaveTalkeChannel(channelId);
			}
			this.LogForYouMiTalk("OnTalkVoiceLeaveChannel", errorCode, string.Format("leave channel {0} res is {1}", channelId, isSuccess), SDKVoiceLogLevel.Error);
		}

		// Token: 0x060198A0 RID: 104608 RVA: 0x0080D054 File Offset: 0x0080B454
		public void OnTalkVoiceLeaveAllChannels(bool isSuccess, YouMeErrorCode errorCode)
		{
			if (isSuccess)
			{
				if (this.talkChannelIds != null)
				{
					this.talkChannelIds.Clear();
				}
				this.LeaveTalkChannelSucc();
				this._ResetVoiceTalk();
				this._ReportLeaveTalkeChannel(string.Empty);
			}
			this.LogForYouMiTalk("OnTalkVoiceLeaveChannel", errorCode, "level all channel res is " + isSuccess, SDKVoiceLogLevel.Error);
		}

		// Token: 0x060198A1 RID: 104609 RVA: 0x0080D0B4 File Offset: 0x0080B4B4
		public void OnTalkVoiceChannelPause(bool isPaused, YouMeErrorCode errorCode)
		{
			this.LogForYouMiTalk("OnTalkVoiceChannelPause", errorCode, "[YouMe - Voice Talk] " + ((!isPaused) ? "Resumed !!!" : "Paused !!! "), SDKVoiceLogLevel.Error);
			if (errorCode != YouMeErrorCode.YOUME_SUCCESS)
			{
				this.LogForYouMiTalk("OnTalkVoiceChannelPause", errorCode, "[YouMe - Voice Talk] " + ((!isPaused) ? "Resumed Failed!!!" : "Paused Failed!!! "), SDKVoiceLogLevel.Error);
				return;
			}
			if (isPaused)
			{
				this.voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Paused;
				this.ResumeChannel();
			}
			else
			{
				this.voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Resumed;
			}
		}

		// Token: 0x060198A2 RID: 104610 RVA: 0x0080D140 File Offset: 0x0080B540
		public void OnTalkVoiceMicOn(bool isOn, YouMeErrorCode errorCode)
		{
			this.LogForYouMiTalk("OnTalkVoiceMicOn", errorCode, "Set Mic on : " + isOn, SDKVoiceLogLevel.Error);
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				if (!isOn || !this.isTalkMicAutoOn || !this.isTalkMicForceOffDirty)
				{
					this.TalkVoiceMicOpenOn(isOn);
				}
				if (!this.isTalkMicEnableChangedDirty)
				{
					this.isTalkMicMaunalOn = isOn;
				}
				if (isOn && !this.IsTalkRealPlayerOn() && !this.isTalkMicAutoOn)
				{
					this.OpenRealPlayer();
				}
			}
		}

		// Token: 0x060198A3 RID: 104611 RVA: 0x0080D1CC File Offset: 0x0080B5CC
		public void OnTalkVoicePlayerOn(bool isOn, YouMeErrorCode errorCode)
		{
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				this.TalkVoicePlayerOpenOn(isOn);
				if (!isOn && this.IsTalkRealMicOn())
				{
					this.CloseRealMic();
				}
			}
			this.LogForYouMiTalk("OnTalkVoicePlayerOn", errorCode, "Set Player on : " + isOn, SDKVoiceLogLevel.Error);
		}

		// Token: 0x060198A4 RID: 104612 RVA: 0x0080D21C File Offset: 0x0080B61C
		public void OnChannelMemberChange(IList<TalkChannelMemberInfo> members)
		{
			this.isSetGlobalSilenceSucc = true;
			List<TalkChannelMemberInfo> list = members as List<TalkChannelMemberInfo>;
			if (list != null && list.Count > 0)
			{
				list.ForEach(new Action<TalkChannelMemberInfo>(this._ForeachChannelMembers));
			}
			if (!this.isSetGlobalSilenceSucc)
			{
				this._ResetGlobalSilenceStatus();
				this.LogForYouMiTalk("SetGlobalSilenceInMainChannel - OnChannelMemberChange", this.talkMethodResult, "2 set global silence failed " + this.isGlobalSilence, SDKVoiceLogLevel.Error);
			}
			this.TalkVoiceLimitOtherNotSpeak(this.isGlobalSilence);
			this.LogForYouMiTalk("OnChannelMemberChange", YouMeErrorCode.YOUME_SUCCESS, "talk channel members count is " + members.Count, SDKVoiceLogLevel.Error);
		}

		// Token: 0x060198A5 RID: 104613 RVA: 0x0080D2C4 File Offset: 0x0080B6C4
		private void _ForeachChannelMembers(TalkChannelMemberInfo memberInfo)
		{
			string userId = memberInfo.userId;
			if (string.IsNullOrEmpty(userId))
			{
				return;
			}
			if (this.cacheChatVoiceAccInfo != null && this.cacheChatVoiceAccInfo.RoleId == userId)
			{
				return;
			}
			if (memberInfo.isJoined)
			{
				this.isSetGlobalSilenceSucc = this._SetOtherMicStatus(userId);
			}
			else
			{
				this._SetOtherMicMute(userId, false);
				this.TalkVoiceOtherLeaveChannel(memberInfo.talkChannelId, userId);
			}
		}

		// Token: 0x060198A6 RID: 104614 RVA: 0x0080D33C File Offset: 0x0080B73C
		public void OnTalkVoiceMicChangeByOther(bool isOn, string voicePlayerId, YouMeErrorCode errorCode)
		{
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				this._SetCurrentMicSilenceStatus(isOn);
				if (this.cacheChatVoiceAccInfo != null && voicePlayerId != this.cacheChatVoiceAccInfo.RoleId)
				{
					this._SetGlobalSilenceStatus(!isOn);
					this.LogForYouMiTalk("OnTalkVoiceMicChangeByOther", errorCode, "Current Global Silence is : " + this.isGlobalSilence, SDKVoiceLogLevel.Error);
				}
				this.LogForYouMiTalk("SetGlobalSilenceInMainChannel - OnTalkVoiceMicChangeByOther", this.talkMethodResult, "3 set global silence " + this.isGlobalSilence, SDKVoiceLogLevel.Error);
			}
			this.LogForYouMiTalk("OnTalkVoiceMicChangeByOther", errorCode, "Set Mic on : " + isOn, SDKVoiceLogLevel.Error);
		}

		// Token: 0x060198A7 RID: 104615 RVA: 0x0080D3E7 File Offset: 0x0080B7E7
		private void _SetGlobalSilenceStatus(bool isSilence)
		{
			this.isLastGlobalSilence = this.isGlobalSilence;
			this.isGlobalSilence = isSilence;
			if (this.isLastGlobalSilence != this.isGlobalSilence)
			{
				this.TalkVoiceGlobalSilenceChanged(isSilence);
			}
		}

		// Token: 0x060198A8 RID: 104616 RVA: 0x0080D414 File Offset: 0x0080B814
		private void _ResetGlobalSilenceStatus()
		{
			if (this.isLastGlobalSilence != this.isGlobalSilence)
			{
				this.TalkVoiceGlobalSilenceChanged(this.isLastGlobalSilence);
			}
			this.isGlobalSilence = this.isLastGlobalSilence;
		}

		// Token: 0x060198A9 RID: 104617 RVA: 0x0080D440 File Offset: 0x0080B840
		private void _SetCurrentMicSilenceStatus(bool isMicEnable)
		{
			this.TalkVoiceMicOffByOther(isMicEnable);
			this.isTalkMicEnable = isMicEnable;
			this.isTalkMicEnableChangedDirty = true;
			this.isTalkMicForceOffDirty = false;
			if (!this.isTalkMicMaunalOn)
			{
				this.isTalkMicForceOffDirty = true;
			}
			if (isMicEnable)
			{
				this.isTalkMicAutoOn = true;
				if (this.isTalkMicForceOffDirty)
				{
					this._CloseRealMicOnMicEnable();
				}
			}
		}

		// Token: 0x060198AA RID: 104618 RVA: 0x0080D49C File Offset: 0x0080B89C
		public void OnSetSpeakChannel(bool success, string channelId, YouMeErrorCode erroCode)
		{
			if (success)
			{
				this.LogForYouMiTalk("OnSetSpeakChannel", erroCode, "Set Speak Channel Succ : " + channelId, SDKVoiceLogLevel.Error);
				this.TalkVoiceChannelChanged(channelId);
				this.currTalkChannelId = channelId;
				string content = this._GenerateBroadcastMsg(YouMiVoiceInterface.TalkBroadcastType.ChangeTalkChannel, channelId);
				if (this.talkChannelIds != null && this.talkChannelIds.Count > 0)
				{
					this._SendBroadcastMsg(this.talkChannelIds[0], content);
				}
			}
			else
			{
				this.LogForYouMiTalk("OnSetSpeakChannel", erroCode, "Set Speak Channel Failed : " + channelId, SDKVoiceLogLevel.Error);
				if (erroCode == YouMeErrorCode.YOUME_ERROR_UNKNOWN)
				{
					this.LeaveChannel(channelId);
					this.JoinChannel(channelId);
					this.TalkVoiceChannelChanged(string.Empty);
					return;
				}
				if (this.currTalkChannelId == channelId)
				{
					this.TalkVoiceChannelChanged(this.currTalkChannelId);
					return;
				}
				if (this.talkChannelIds != null && !this.talkChannelIds.Contains(channelId))
				{
					this.JoinChannel(channelId);
				}
				this.TalkVoiceChannelChanged(string.Empty);
			}
		}

		// Token: 0x060198AB RID: 104619 RVA: 0x0080D59B File Offset: 0x0080B99B
		public void OnOtherSpeakInChannel(bool isSpeak, string voicePlayerId, YouMeErrorCode errorCode)
		{
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				this.TalkVoiceOtherSpeakInChannel(isSpeak, voicePlayerId);
			}
		}

		// Token: 0x060198AC RID: 104620 RVA: 0x0080D5AB File Offset: 0x0080B9AB
		public void OnOtherControlMic(bool isOn, string voicePlayerId, YouMeErrorCode errorCode)
		{
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				this.TalkVoiceOtherControlMic(isOn, voicePlayerId);
			}
		}

		// Token: 0x060198AD RID: 104621 RVA: 0x0080D5BB File Offset: 0x0080B9BB
		public void OnVoiceTalkMicAuth(YouMeErrorCode errorCode)
		{
			if (errorCode != YouMeErrorCode.YOUME_SUCCESS)
			{
				this.TalkVoiceMicAuthNoPermission();
			}
		}

		// Token: 0x060198AE RID: 104622 RVA: 0x0080D5CC File Offset: 0x0080B9CC
		public void OnBroadcastMsg(string channelId, string content, YouMeErrorCode errorCode)
		{
			if (errorCode == YouMeErrorCode.YOUME_SUCCESS)
			{
				int num = 0;
				if (int.TryParse(content, out num))
				{
					this.LogForYouMiTalk("OnBroadcastMsg", errorCode, "Send Broadcast msg success : " + num, SDKVoiceLogLevel.Error);
					return;
				}
				string[] broadcastMsgs = content.Split(new char[]
				{
					'|'
				});
				YouMiVoiceInterface.TalkBroadcastType talkBroadcastType = this._GetTalkBroadcastTypeFromBCMsg(broadcastMsgs);
				string text = this._GetVoicePlayerIdFromBCMsg(broadcastMsgs);
				string text2 = this._GetVoiceParam1FromBCMsg(broadcastMsgs);
				this.LogForYouMiTalk("OnBroadcastMsg", errorCode, string.Format("Receive Broadcast msg, type : {0}, broadcast channelId : {1}, playerId : {2}, msg param1 : {3}", new object[]
				{
					talkBroadcastType.ToString(),
					channelId,
					text,
					text2
				}), SDKVoiceLogLevel.Error);
				if (talkBroadcastType != YouMiVoiceInterface.TalkBroadcastType.ChangeTalkChannel)
				{
					if (talkBroadcastType != YouMiVoiceInterface.TalkBroadcastType.JoinTalkChannel)
					{
						if (talkBroadcastType == YouMiVoiceInterface.TalkBroadcastType.LeaveTalkChannel)
						{
							this._RemoveOtherTalkChannelInfo(channelId, text);
						}
					}
					else
					{
						this._AddOtherTalkChannelInfo(channelId, text, true);
					}
				}
				else if (!string.IsNullOrEmpty(text2))
				{
					this._AddOtherTalkChannelInfo(text2, text, true);
					this.TalkVoiceOtherChangeSpeakChannel(text2, text);
				}
			}
		}

		// Token: 0x060198AF RID: 104623 RVA: 0x0080D6CC File Offset: 0x0080BACC
		private void _AddOtherTalkChannelInfo(string channelId, string voicePlayerId, bool bOverride)
		{
			if (this.otherTalkChannelInfos != null)
			{
				OtheTalkChannelInfo otheTalkChannelInfo = this.otherTalkChannelInfos.Find((OtheTalkChannelInfo x) => x.userId == voicePlayerId);
				if (otheTalkChannelInfo == null)
				{
					OtheTalkChannelInfo item = new OtheTalkChannelInfo
					{
						userId = voicePlayerId,
						currentTalkChannelId = channelId
					};
					this.otherTalkChannelInfos.Add(item);
				}
				else if (bOverride)
				{
					otheTalkChannelInfo.currentTalkChannelId = channelId;
				}
			}
		}

		// Token: 0x060198B0 RID: 104624 RVA: 0x0080D748 File Offset: 0x0080BB48
		private void _RemoveOtherTalkChannelInfo(string channelId, string voicePlayerId)
		{
			if (this.otherTalkChannelInfos != null)
			{
				this.otherTalkChannelInfos.RemoveAll((OtheTalkChannelInfo x) => x.userId == voicePlayerId);
			}
		}

		// Token: 0x060198B1 RID: 104625 RVA: 0x0080D785 File Offset: 0x0080BB85
		private void LogForYouMiChat(string method, ErrorCode errorCode, string errorMsg = "", SDKVoiceLogLevel logLevel = SDKVoiceLogLevel.Error)
		{
			if (this.logLevel > SDKVoiceLogLevel.None)
			{
				this.cacheLogMsg = string.Format("[youmi voice] - Chat - method : {0} , errorCode : {1} , errorMsg : {2}", method, errorCode, errorMsg);
				this.SetLogLevel(this.cacheLogMsg, logLevel);
			}
		}

		// Token: 0x060198B2 RID: 104626 RVA: 0x0080D7B9 File Offset: 0x0080BBB9
		private void LogForYouMiTalk(string method, YouMeErrorCode errorCode, string errorMsg = "", SDKVoiceLogLevel logLevel = SDKVoiceLogLevel.Error)
		{
			if (this.logLevel > SDKVoiceLogLevel.None)
			{
				this.cacheLogMsg = string.Format("[youmi voice] - Talk -method : {0} , errorCode : {1} , errorMsg : {2}", method, errorCode, errorMsg);
				this.SetLogLevel(this.cacheLogMsg, logLevel);
			}
		}

		// Token: 0x060198B3 RID: 104627 RVA: 0x0080D7ED File Offset: 0x0080BBED
		private void SetLogLevel(string log, SDKVoiceLogLevel logLevel)
		{
			if (logLevel != SDKVoiceLogLevel.Error)
			{
				if (logLevel != SDKVoiceLogLevel.Warning)
				{
					if (logLevel != SDKVoiceLogLevel.Debug)
					{
					}
				}
			}
			else
			{
				Logger.LogError(log);
			}
		}

		// Token: 0x0401236C RID: 74604
		private const string AppKey = "YOUMEF6EFE7326698A3E3E0AEEEDA02BCA6B6B39EF406";

		// Token: 0x0401236D RID: 74605
		private const string AppSecret = "1VhLqAbGn5Da4gxsIowTYGQYJ1hwLZPOi6YiSBJgzfqskjE5m9Oo0y5+P781O5U9SsK9IURbybKr/YB/4h/qQ3rKTlFmyWDRbNf+gOWPvEq2ilqHhj1K4LKC8Av0ORqSSJQAlDPATj6tzx1LprJL1HLePObGZ5lzDCyVrggJtmcBAAE=";

		// Token: 0x0401236E RID: 74606
		private string cacheLogMsg = string.Empty;

		// Token: 0x0401236F RID: 74607
		private YoumiVoiceGameAccInfo cacheChatVoiceAccInfo;

		// Token: 0x04012370 RID: 74608
		private YouMiVoiceInterface.LoginVoiceState loginVoiceState = YouMiVoiceInterface.LoginVoiceState.Logouted;

		// Token: 0x04012371 RID: 74609
		private bool isChatVoiceInited;

		// Token: 0x04012372 RID: 74610
		private bool isVoiceTranslate;

		// Token: 0x04012373 RID: 74611
		private float voiceVolume;

		// Token: 0x04012374 RID: 74612
		private bool isRecording;

		// Token: 0x04012375 RID: 74613
		private bool isRecordPTTFailed;

		// Token: 0x04012376 RID: 74614
		private ErrorCode chatMethodResult;

		// Token: 0x04012377 RID: 74615
		private bool isQueryHistoryMsgClear;

		// Token: 0x04012378 RID: 74616
		private List<string> voiceChatRoomIdList = new List<string>();

		// Token: 0x04012379 RID: 74617
		private YouMiVoiceInterface.VoiceTalkPauseState voiceTalkPauseState = YouMiVoiceInterface.VoiceTalkPauseState.Resumed;

		// Token: 0x0401237A RID: 74618
		private bool isTalkVoiceInited;

		// Token: 0x0401237B RID: 74619
		private float playerVolume;

		// Token: 0x0401237C RID: 74620
		private bool isTalkMicEnable = true;

		// Token: 0x0401237D RID: 74621
		private bool isTalkMicMaunalOn;

		// Token: 0x0401237E RID: 74622
		private bool isTalkMicEnableChangedDirty;

		// Token: 0x0401237F RID: 74623
		private bool isTalkMicAutoOn;

		// Token: 0x04012380 RID: 74624
		private bool isTalkMicForceOffDirty;

		// Token: 0x04012381 RID: 74625
		private YouMeErrorCode talkMethodResult;

		// Token: 0x04012382 RID: 74626
		private ulong joinTalkRoomStartTime;

		// Token: 0x04012383 RID: 74627
		private bool isFirstJoinTalkChannelDirty = true;

		// Token: 0x04012384 RID: 74628
		private List<string> talkChannelIds;

		// Token: 0x04012385 RID: 74629
		private string currTalkChannelId;

		// Token: 0x04012386 RID: 74630
		private List<OtheTalkChannelInfo> otherTalkChannelInfos;

		// Token: 0x04012387 RID: 74631
		private bool isLastGlobalSilence;

		// Token: 0x04012388 RID: 74632
		private bool isGlobalSilence;

		// Token: 0x04012389 RID: 74633
		private bool isSetGlobalSilenceSucc = true;

		// Token: 0x0401238A RID: 74634
		private bool isSetGlobalSilenceDirty;

		// Token: 0x0401238B RID: 74635
		private bool hasReqVoiceAuth;

		// Token: 0x0401238C RID: 74636
		private static readonly string[] TALK_BROADCAST_TYPES = new string[]
		{
			"none",
			"changeTalkChannel",
			"leaveTalkChannel",
			"joinTalkChannel"
		};

		// Token: 0x0401238D RID: 74637
		private string _leastLocalAudioToken = string.Empty;

		// Token: 0x0401238E RID: 74638
		private string _currentReqPlayAudioToken = string.Empty;

		// Token: 0x0401238F RID: 74639
		private GameClient.ChatType _leasetLocalAudioChatType;

		// Token: 0x04012390 RID: 74640
		private Dictionary<string, AudioInfo> _AudioCache = new Dictionary<string, AudioInfo>();

		// Token: 0x02004692 RID: 18066
		public enum LoginVoiceState
		{
			// Token: 0x04012392 RID: 74642
			Logined,
			// Token: 0x04012393 RID: 74643
			Logining,
			// Token: 0x04012394 RID: 74644
			Logouted,
			// Token: 0x04012395 RID: 74645
			Logouting
		}

		// Token: 0x02004693 RID: 18067
		public enum VoiceTalkPauseState
		{
			// Token: 0x04012397 RID: 74647
			Paused,
			// Token: 0x04012398 RID: 74648
			Pausing,
			// Token: 0x04012399 RID: 74649
			Resumed,
			// Token: 0x0401239A RID: 74650
			Resuming
		}

		// Token: 0x02004694 RID: 18068
		public enum TalkBroadcastType
		{
			// Token: 0x0401239C RID: 74652
			None,
			// Token: 0x0401239D RID: 74653
			ChangeTalkChannel,
			// Token: 0x0401239E RID: 74654
			LeaveTalkChannel,
			// Token: 0x0401239F RID: 74655
			JoinTalkChannel,
			// Token: 0x040123A0 RID: 74656
			Count
		}
	}
}
