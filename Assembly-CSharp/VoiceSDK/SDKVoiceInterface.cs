using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameClient;

namespace VoiceSDK
{
	// Token: 0x0200467A RID: 18042
	public class SDKVoiceInterface : ISDKVoiceInterface, IYouMiVoiceChatImpl
	{
		// Token: 0x1400000E RID: 14
		// (add) Token: 0x060196DA RID: 104154 RVA: 0x00807A98 File Offset: 0x00805E98
		// (remove) Token: 0x060196DB RID: 104155 RVA: 0x00807AD0 File Offset: 0x00805ED0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnJoinChannelSuccess onJoinChannelSucc;

		// Token: 0x1400000F RID: 15
		// (add) Token: 0x060196DC RID: 104156 RVA: 0x00807B08 File Offset: 0x00805F08
		// (remove) Token: 0x060196DD RID: 104157 RVA: 0x00807B40 File Offset: 0x00805F40
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnLeaveChannelSuccess onLeaveChannelSucc;

		// Token: 0x14000010 RID: 16
		// (add) Token: 0x060196DE RID: 104158 RVA: 0x00807B78 File Offset: 0x00805F78
		// (remove) Token: 0x060196DF RID: 104159 RVA: 0x00807BB0 File Offset: 0x00805FB0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceMicOn onVoiceMicOn;

		// Token: 0x14000011 RID: 17
		// (add) Token: 0x060196E0 RID: 104160 RVA: 0x00807BE8 File Offset: 0x00805FE8
		// (remove) Token: 0x060196E1 RID: 104161 RVA: 0x00807C20 File Offset: 0x00806020
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoicePlayerOn onVoicePlayerOn;

		// Token: 0x14000012 RID: 18
		// (add) Token: 0x060196E2 RID: 104162 RVA: 0x00807C58 File Offset: 0x00806058
		// (remove) Token: 0x060196E3 RID: 104163 RVA: 0x00807C90 File Offset: 0x00806090
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceMicOffByOther onVoiceMicOffByOther;

		// Token: 0x14000013 RID: 19
		// (add) Token: 0x060196E4 RID: 104164 RVA: 0x00807CC8 File Offset: 0x008060C8
		// (remove) Token: 0x060196E5 RID: 104165 RVA: 0x00807D00 File Offset: 0x00806100
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceLimitOtherNotSpeack onVoiceLimitOtherNotSpeak;

		// Token: 0x14000014 RID: 20
		// (add) Token: 0x060196E6 RID: 104166 RVA: 0x00807D38 File Offset: 0x00806138
		// (remove) Token: 0x060196E7 RID: 104167 RVA: 0x00807D70 File Offset: 0x00806170
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkGlobalSilenceChanged onVoiceTalkGlobalSilenceChanged;

		// Token: 0x14000015 RID: 21
		// (add) Token: 0x060196E8 RID: 104168 RVA: 0x00807DA8 File Offset: 0x008061A8
		// (remove) Token: 0x060196E9 RID: 104169 RVA: 0x00807DE0 File Offset: 0x008061E0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkChannelChanged onVoiceTalkChannelChanged;

		// Token: 0x14000016 RID: 22
		// (add) Token: 0x060196EA RID: 104170 RVA: 0x00807E18 File Offset: 0x00806218
		// (remove) Token: 0x060196EB RID: 104171 RVA: 0x00807E50 File Offset: 0x00806250
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkOtherSpeakInChannel onOtherSpeakInChannel;

		// Token: 0x14000017 RID: 23
		// (add) Token: 0x060196EC RID: 104172 RVA: 0x00807E88 File Offset: 0x00806288
		// (remove) Token: 0x060196ED RID: 104173 RVA: 0x00807EC0 File Offset: 0x008062C0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkOtherControlMic onOtherControlMic;

		// Token: 0x14000018 RID: 24
		// (add) Token: 0x060196EE RID: 104174 RVA: 0x00807EF8 File Offset: 0x008062F8
		// (remove) Token: 0x060196EF RID: 104175 RVA: 0x00807F30 File Offset: 0x00806330
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkOtherChangeSpeakChannel onOtherChangeSpeakChannel;

		// Token: 0x14000019 RID: 25
		// (add) Token: 0x060196F0 RID: 104176 RVA: 0x00807F68 File Offset: 0x00806368
		// (remove) Token: 0x060196F1 RID: 104177 RVA: 0x00807FA0 File Offset: 0x008063A0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkOtherLeaveChannel onOtherLeaveChannel;

		// Token: 0x1400001A RID: 26
		// (add) Token: 0x060196F2 RID: 104178 RVA: 0x00807FD8 File Offset: 0x008063D8
		// (remove) Token: 0x060196F3 RID: 104179 RVA: 0x00808010 File Offset: 0x00806410
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event SDKVoiceInterface.OnVoiceTalkMicAuthNoPermission onMicAuthNoPermission;

		// Token: 0x060196F4 RID: 104180 RVA: 0x00808046 File Offset: 0x00806446
		public virtual void Init()
		{
		}

		// Token: 0x060196F5 RID: 104181 RVA: 0x00808048 File Offset: 0x00806448
		public virtual void InitChatVoice()
		{
		}

		// Token: 0x060196F6 RID: 104182 RVA: 0x0080804C File Offset: 0x0080644C
		public virtual void UnInitChatVoice()
		{
			this.onVoiceChatLoginHandler = null;
			this.onVoiceChatLogoutHandler = null;
			this.onVoiceChatNotJoinRoomHandler = null;
			this.onJoinChannelSucc = null;
			this.onLeaveChannelSucc = null;
			this.onVoiceMicOn = null;
			this.onVoicePlayerOn = null;
			this.onVoiceMicOffByOther = null;
			this.onVoiceLimitOtherNotSpeak = null;
			this.onVoiceTalkGlobalSilenceChanged = null;
			this.onVoiceTalkChannelChanged = null;
			this.onOtherSpeakInChannel = null;
			this.onOtherControlMic = null;
			this.onOtherChangeSpeakChannel = null;
			this.onOtherLeaveChannel = null;
			this.onMicAuthNoPermission = null;
		}

		// Token: 0x060196F7 RID: 104183 RVA: 0x008080C9 File Offset: 0x008064C9
		public virtual void LoginVoice(string roleId, string openId, string token)
		{
		}

		// Token: 0x060196F8 RID: 104184 RVA: 0x008080CB File Offset: 0x008064CB
		public virtual void LogoutVoice()
		{
		}

		// Token: 0x060196F9 RID: 104185 RVA: 0x008080CD File Offset: 0x008064CD
		public virtual bool StartRecordVoice()
		{
			return false;
		}

		// Token: 0x060196FA RID: 104186 RVA: 0x008080D0 File Offset: 0x008064D0
		public virtual bool StopRecordVoice()
		{
			return false;
		}

		// Token: 0x060196FB RID: 104187 RVA: 0x008080D3 File Offset: 0x008064D3
		public virtual void CancelRecordVoice()
		{
		}

		// Token: 0x060196FC RID: 104188 RVA: 0x008080D5 File Offset: 0x008064D5
		public virtual void AddVoicePathInQueue(string voiceKey)
		{
		}

		// Token: 0x060196FD RID: 104189 RVA: 0x008080D7 File Offset: 0x008064D7
		public virtual void ClearVoicePathQueue()
		{
		}

		// Token: 0x060196FE RID: 104190 RVA: 0x008080D9 File Offset: 0x008064D9
		public virtual void StopPlayVoice()
		{
		}

		// Token: 0x060196FF RID: 104191 RVA: 0x008080DB File Offset: 0x008064DB
		public virtual void SetVoiceVolume(float volume)
		{
		}

		// Token: 0x06019700 RID: 104192 RVA: 0x008080DD File Offset: 0x008064DD
		public virtual float GetVoiceVolume()
		{
			return 0f;
		}

		// Token: 0x06019701 RID: 104193 RVA: 0x008080E4 File Offset: 0x008064E4
		public virtual void ClearLocalCache()
		{
		}

		// Token: 0x06019702 RID: 104194 RVA: 0x008080E6 File Offset: 0x008064E6
		public virtual void OnPause()
		{
		}

		// Token: 0x06019703 RID: 104195 RVA: 0x008080E8 File Offset: 0x008064E8
		public virtual void OnResume()
		{
		}

		// Token: 0x06019704 RID: 104196 RVA: 0x008080EA File Offset: 0x008064EA
		public virtual bool IsVoiceRecording()
		{
			return false;
		}

		// Token: 0x06019705 RID: 104197 RVA: 0x008080ED File Offset: 0x008064ED
		public virtual bool IsVoicePlaying()
		{
			return false;
		}

		// Token: 0x06019706 RID: 104198 RVA: 0x008080F0 File Offset: 0x008064F0
		public virtual string ShowDebugLog()
		{
			return string.Empty;
		}

		// Token: 0x06019707 RID: 104199 RVA: 0x008080F7 File Offset: 0x008064F7
		public virtual void InitTalkVoice()
		{
		}

		// Token: 0x06019708 RID: 104200 RVA: 0x008080F9 File Offset: 0x008064F9
		public virtual void UnInitTalkVoice()
		{
		}

		// Token: 0x06019709 RID: 104201 RVA: 0x008080FB File Offset: 0x008064FB
		public virtual void JoinChannel(string channelId)
		{
		}

		// Token: 0x0601970A RID: 104202 RVA: 0x008080FD File Offset: 0x008064FD
		public virtual void LeaveAllChannel()
		{
		}

		// Token: 0x0601970B RID: 104203 RVA: 0x008080FF File Offset: 0x008064FF
		public virtual void LeaveChannel(string channelId)
		{
		}

		// Token: 0x0601970C RID: 104204 RVA: 0x00808101 File Offset: 0x00806501
		public virtual void UpdateTalkChannel(IList<string> channelIds)
		{
		}

		// Token: 0x0601970D RID: 104205 RVA: 0x00808103 File Offset: 0x00806503
		public virtual string CurrentTalkChannelId()
		{
			return string.Empty;
		}

		// Token: 0x0601970E RID: 104206 RVA: 0x0080810A File Offset: 0x0080650A
		public virtual bool IsJoinedTalkChannel(string channelId)
		{
			return false;
		}

		// Token: 0x0601970F RID: 104207 RVA: 0x0080810D File Offset: 0x0080650D
		public virtual bool HasJoinedTalkChannel()
		{
			return false;
		}

		// Token: 0x06019710 RID: 104208 RVA: 0x00808110 File Offset: 0x00806510
		public virtual void SetCurrentTalkChannelId(string channelId)
		{
		}

		// Token: 0x06019711 RID: 104209 RVA: 0x00808112 File Offset: 0x00806512
		public virtual string GetOtherTalkChannelId(string voicePlayerId)
		{
			return string.Empty;
		}

		// Token: 0x06019712 RID: 104210 RVA: 0x00808119 File Offset: 0x00806519
		public virtual bool IsMicEnable()
		{
			return false;
		}

		// Token: 0x06019713 RID: 104211 RVA: 0x0080811C File Offset: 0x0080651C
		public virtual bool IsGlobalSilence()
		{
			return false;
		}

		// Token: 0x06019714 RID: 104212 RVA: 0x0080811F File Offset: 0x0080651F
		public virtual void SetGlobalSilenceInMainChannel(string mainChannelId, bool isNotSpeak)
		{
		}

		// Token: 0x06019715 RID: 104213 RVA: 0x00808121 File Offset: 0x00806521
		public virtual void SetMicEnable(string voicePlayerId, bool bEnable)
		{
		}

		// Token: 0x06019716 RID: 104214 RVA: 0x00808123 File Offset: 0x00806523
		public virtual void OpenRealMic()
		{
		}

		// Token: 0x06019717 RID: 104215 RVA: 0x00808125 File Offset: 0x00806525
		public virtual void CloseRealMic()
		{
		}

		// Token: 0x06019718 RID: 104216 RVA: 0x00808127 File Offset: 0x00806527
		public virtual void OpenRealPlayer()
		{
		}

		// Token: 0x06019719 RID: 104217 RVA: 0x00808129 File Offset: 0x00806529
		public virtual void CloseReaPlayer()
		{
		}

		// Token: 0x0601971A RID: 104218 RVA: 0x0080812B File Offset: 0x0080652B
		public virtual bool IsTalkRealMicOn()
		{
			return false;
		}

		// Token: 0x0601971B RID: 104219 RVA: 0x0080812E File Offset: 0x0080652E
		public virtual bool IsTalkRealPlayerOn()
		{
			return false;
		}

		// Token: 0x0601971C RID: 104220 RVA: 0x00808131 File Offset: 0x00806531
		public virtual void SetPlayerVolume(float volume)
		{
		}

		// Token: 0x0601971D RID: 104221 RVA: 0x00808133 File Offset: 0x00806533
		public virtual float GetPlayerVolume()
		{
			return 0f;
		}

		// Token: 0x0601971E RID: 104222 RVA: 0x0080813A File Offset: 0x0080653A
		public virtual void PauseChannel()
		{
		}

		// Token: 0x0601971F RID: 104223 RVA: 0x0080813C File Offset: 0x0080653C
		public virtual void ResumeChannel()
		{
		}

		// Token: 0x06019720 RID: 104224 RVA: 0x0080813E File Offset: 0x0080653E
		public virtual bool BeInRealVoiceChannel()
		{
			return false;
		}

		// Token: 0x06019721 RID: 104225 RVA: 0x00808141 File Offset: 0x00806541
		public virtual void PlayVoiceCommon(string voicekey, string targetUserId = "")
		{
		}

		// Token: 0x06019722 RID: 104226 RVA: 0x00808143 File Offset: 0x00806543
		public virtual void JoinChatRoom(string roomId, bool beSaveRoomMsg = false)
		{
		}

		// Token: 0x06019723 RID: 104227 RVA: 0x00808145 File Offset: 0x00806545
		public virtual void LeaveChatRoom(string roomId)
		{
		}

		// Token: 0x06019724 RID: 104228 RVA: 0x00808147 File Offset: 0x00806547
		public virtual void SendVoiceMessage(string receId, ChatType chatType, ref ulong iReqId, bool bTranslate)
		{
		}

		// Token: 0x06019725 RID: 104229 RVA: 0x00808149 File Offset: 0x00806549
		public virtual void StopAudioMessage(string extra)
		{
		}

		// Token: 0x06019726 RID: 104230 RVA: 0x0080814B File Offset: 0x0080654B
		public virtual void ClearVoiceChatMsgCache()
		{
		}

		// Token: 0x06019727 RID: 104231 RVA: 0x0080814D File Offset: 0x0080654D
		public virtual bool CheckLoginChatVoice()
		{
			return true;
		}

		// Token: 0x06019728 RID: 104232 RVA: 0x00808150 File Offset: 0x00806550
		public void SetLogLevel(SDKVoiceLogLevel logLevel)
		{
			this.logLevel = logLevel;
		}

		// Token: 0x06019729 RID: 104233 RVA: 0x00808159 File Offset: 0x00806559
		protected virtual void JoinTalkChannelSucc()
		{
			if (this.onJoinChannelSucc != null)
			{
				this.onJoinChannelSucc();
			}
		}

		// Token: 0x0601972A RID: 104234 RVA: 0x00808171 File Offset: 0x00806571
		protected virtual void LeaveTalkChannelSucc()
		{
			if (this.onLeaveChannelSucc != null)
			{
				this.onLeaveChannelSucc();
			}
		}

		// Token: 0x0601972B RID: 104235 RVA: 0x00808189 File Offset: 0x00806589
		protected virtual void TalkVoiceMicOpenOn(bool isOn)
		{
			if (this.onVoiceMicOn != null)
			{
				this.onVoiceMicOn(isOn);
			}
		}

		// Token: 0x0601972C RID: 104236 RVA: 0x008081A2 File Offset: 0x008065A2
		protected virtual void TalkVoicePlayerOpenOn(bool isOn)
		{
			if (this.onVoicePlayerOn != null)
			{
				this.onVoicePlayerOn(isOn);
			}
		}

		// Token: 0x0601972D RID: 104237 RVA: 0x008081BB File Offset: 0x008065BB
		protected virtual void TalkVoiceMicOffByOther(bool isOn)
		{
			if (this.onVoiceMicOffByOther != null)
			{
				this.onVoiceMicOffByOther(isOn);
			}
		}

		// Token: 0x0601972E RID: 104238 RVA: 0x008081D4 File Offset: 0x008065D4
		protected virtual void TalkVoiceLimitOtherNotSpeak(bool isOn)
		{
			if (this.onVoiceLimitOtherNotSpeak != null)
			{
				this.onVoiceLimitOtherNotSpeak(isOn);
			}
		}

		// Token: 0x0601972F RID: 104239 RVA: 0x008081ED File Offset: 0x008065ED
		protected virtual void TalkVoiceGlobalSilenceChanged(bool isSilence)
		{
			if (this.onVoiceTalkGlobalSilenceChanged != null)
			{
				this.onVoiceTalkGlobalSilenceChanged(isSilence);
			}
		}

		// Token: 0x06019730 RID: 104240 RVA: 0x00808206 File Offset: 0x00806606
		protected virtual void TalkVoiceChannelChanged(string channelId)
		{
			if (this.onVoiceTalkChannelChanged != null)
			{
				this.onVoiceTalkChannelChanged(channelId);
			}
		}

		// Token: 0x06019731 RID: 104241 RVA: 0x0080821F File Offset: 0x0080661F
		protected virtual void TalkVoiceOtherSpeakInChannel(bool isSpeak, string voicePlayerId)
		{
			if (this.onOtherSpeakInChannel != null)
			{
				this.onOtherSpeakInChannel(isSpeak, voicePlayerId);
			}
		}

		// Token: 0x06019732 RID: 104242 RVA: 0x00808239 File Offset: 0x00806639
		protected virtual void TalkVoiceOtherControlMic(bool isOn, string voicePlayerId)
		{
			if (this.onOtherControlMic != null)
			{
				this.onOtherControlMic(isOn, voicePlayerId);
			}
		}

		// Token: 0x06019733 RID: 104243 RVA: 0x00808253 File Offset: 0x00806653
		protected virtual void TalkVoiceOtherChangeSpeakChannel(string channelId, string voicePlayerId)
		{
			if (this.onOtherChangeSpeakChannel != null)
			{
				this.onOtherChangeSpeakChannel(channelId, voicePlayerId);
			}
		}

		// Token: 0x06019734 RID: 104244 RVA: 0x0080826D File Offset: 0x0080666D
		protected virtual void TalkVoiceOtherLeaveChannel(string channelId, string voicePlayerId)
		{
			if (this.onOtherLeaveChannel != null)
			{
				this.onOtherLeaveChannel(channelId, voicePlayerId);
			}
		}

		// Token: 0x06019735 RID: 104245 RVA: 0x00808287 File Offset: 0x00806687
		protected virtual void TalkVoiceMicAuthNoPermission()
		{
			if (this.onMicAuthNoPermission != null)
			{
				this.onMicAuthNoPermission();
			}
		}

		// Token: 0x04012328 RID: 74536
		public string SaveVoiceCachePath = string.Empty;

		// Token: 0x04012329 RID: 74537
		protected Queue<string> voiceQueue;

		// Token: 0x0401232A RID: 74538
		protected int maxVoiceQueueLength = 20;

		// Token: 0x0401232B RID: 74539
		protected uint onTimeDeletePrivateChat = 10U;

		// Token: 0x0401232C RID: 74540
		protected int privateChatQueryMsgCount = 10;

		// Token: 0x0401232D RID: 74541
		public SDKVoiceInterface.OnVoiceChatLogin onVoiceChatLoginHandler;

		// Token: 0x0401232E RID: 74542
		public SDKVoiceInterface.OnVoiceChatLogout onVoiceChatLogoutHandler;

		// Token: 0x0401232F RID: 74543
		public SDKVoiceInterface.OnVoiceChatNotJoinRoom onVoiceChatNotJoinRoomHandler;

		// Token: 0x0401233D RID: 74557
		protected SDKVoiceLogLevel logLevel;

		// Token: 0x0200467B RID: 18043
		// (Invoke) Token: 0x06019737 RID: 104247
		public delegate void OnVoiceChatLogin();

		// Token: 0x0200467C RID: 18044
		// (Invoke) Token: 0x0601973B RID: 104251
		public delegate void OnVoiceChatLogout();

		// Token: 0x0200467D RID: 18045
		// (Invoke) Token: 0x0601973F RID: 104255
		public delegate void OnVoiceChatNotJoinRoom();

		// Token: 0x0200467E RID: 18046
		// (Invoke) Token: 0x06019743 RID: 104259
		public delegate void OnJoinChannelSuccess();

		// Token: 0x0200467F RID: 18047
		// (Invoke) Token: 0x06019747 RID: 104263
		public delegate void OnLeaveChannelSuccess();

		// Token: 0x02004680 RID: 18048
		// (Invoke) Token: 0x0601974B RID: 104267
		public delegate void OnVoiceMicOn(bool isOn);

		// Token: 0x02004681 RID: 18049
		// (Invoke) Token: 0x0601974F RID: 104271
		public delegate void OnVoicePlayerOn(bool isOn);

		// Token: 0x02004682 RID: 18050
		// (Invoke) Token: 0x06019753 RID: 104275
		public delegate void OnVoiceMicOffByOther(bool isOn);

		// Token: 0x02004683 RID: 18051
		// (Invoke) Token: 0x06019757 RID: 104279
		public delegate void OnVoiceLimitOtherNotSpeack(bool isOn);

		// Token: 0x02004684 RID: 18052
		// (Invoke) Token: 0x0601975B RID: 104283
		public delegate void OnVoiceTalkGlobalSilenceChanged(bool isSilence);

		// Token: 0x02004685 RID: 18053
		// (Invoke) Token: 0x0601975F RID: 104287
		public delegate void OnVoiceTalkChannelChanged(string channelId);

		// Token: 0x02004686 RID: 18054
		// (Invoke) Token: 0x06019763 RID: 104291
		public delegate void OnVoiceTalkOtherSpeakInChannel(bool isSpeak, string voicePlayerId);

		// Token: 0x02004687 RID: 18055
		// (Invoke) Token: 0x06019767 RID: 104295
		public delegate void OnVoiceTalkOtherControlMic(bool isOn, string voicePlayerId);

		// Token: 0x02004688 RID: 18056
		// (Invoke) Token: 0x0601976B RID: 104299
		public delegate void OnVoiceTalkOtherChangeSpeakChannel(string channelId, string voicePlayerId);

		// Token: 0x02004689 RID: 18057
		// (Invoke) Token: 0x0601976F RID: 104303
		public delegate void OnVoiceTalkOtherLeaveChannel(string channelId, string voicePlayerId);

		// Token: 0x0200468A RID: 18058
		// (Invoke) Token: 0x06019773 RID: 104307
		public delegate void OnVoiceTalkMicAuthNoPermission();
	}
}
