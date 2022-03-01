using System;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using VoiceSDK;

// Token: 0x0200468B RID: 18059
public class SDKVoiceManager : Singleton<SDKVoiceManager>
{
	// Token: 0x170020D1 RID: 8401
	// (get) Token: 0x06019777 RID: 104311 RVA: 0x008082BD File Offset: 0x008066BD
	// (set) Token: 0x06019778 RID: 104312 RVA: 0x008082C5 File Offset: 0x008066C5
	public bool IsChatVoiceEnabled { get; private set; }

	// Token: 0x170020D2 RID: 8402
	// (get) Token: 0x06019779 RID: 104313 RVA: 0x008082CE File Offset: 0x008066CE
	// (set) Token: 0x0601977A RID: 104314 RVA: 0x008082D6 File Offset: 0x008066D6
	public bool IsTalkRealVoiceEnabled { get; private set; }

	// Token: 0x170020D3 RID: 8403
	// (get) Token: 0x0601977B RID: 104315 RVA: 0x008082DF File Offset: 0x008066DF
	public VoiceChatModule VoiceChatModule
	{
		get
		{
			if (this._voiceChatModule == null)
			{
				this._voiceChatModule = new VoiceChatModule();
				return this._voiceChatModule;
			}
			return this._voiceChatModule;
		}
	}

	// Token: 0x170020D4 RID: 8404
	// (get) Token: 0x0601977C RID: 104316 RVA: 0x00808304 File Offset: 0x00806704
	// (set) Token: 0x0601977D RID: 104317 RVA: 0x0080830C File Offset: 0x0080670C
	public ChatType GameChatType
	{
		get
		{
			return this.gameChatType;
		}
		set
		{
			this.gameChatType = value;
		}
	}

	// Token: 0x170020D5 RID: 8405
	// (get) Token: 0x0601977E RID: 104318 RVA: 0x00808315 File Offset: 0x00806715
	public bool IsRecordVoiceEnabled
	{
		get
		{
			return this.GetMicPref();
		}
	}

	// Token: 0x170020D6 RID: 8406
	// (get) Token: 0x0601977F RID: 104319 RVA: 0x0080831D File Offset: 0x0080671D
	public bool IsPlayVoiceEnabled
	{
		get
		{
			return this.GetPlayerPref();
		}
	}

	// Token: 0x170020D7 RID: 8407
	// (get) Token: 0x06019780 RID: 104320 RVA: 0x00808325 File Offset: 0x00806725
	public bool IsAutoPlayInWorld
	{
		get
		{
			return this.GetWorldAutoPlayValue();
		}
	}

	// Token: 0x170020D8 RID: 8408
	// (get) Token: 0x06019781 RID: 104321 RVA: 0x0080832D File Offset: 0x0080672D
	public bool IsAutoPlayInTeam
	{
		get
		{
			return this.GetTeamAutoPlayValue();
		}
	}

	// Token: 0x170020D9 RID: 8409
	// (get) Token: 0x06019782 RID: 104322 RVA: 0x00808335 File Offset: 0x00806735
	public bool IsAutoPlayInGuild
	{
		get
		{
			return this.GetGuildAutoPlayValue();
		}
	}

	// Token: 0x170020DA RID: 8410
	// (get) Token: 0x06019783 RID: 104323 RVA: 0x0080833D File Offset: 0x0080673D
	public bool IsAutoPlayInNearby
	{
		get
		{
			return this.GetNearbyAutoPlayValue();
		}
	}

	// Token: 0x170020DB RID: 8411
	// (get) Token: 0x06019784 RID: 104324 RVA: 0x00808345 File Offset: 0x00806745
	public bool IsAutoPlayInPrivate
	{
		get
		{
			return this.GetPrivateAutoPlayValue();
		}
	}

	// Token: 0x170020DC RID: 8412
	// (get) Token: 0x06019785 RID: 104325 RVA: 0x0080834D File Offset: 0x0080674D
	public float VoicePlayerVolume
	{
		get
		{
			return this.GetPlayerVolumnPref();
		}
	}

	// Token: 0x06019786 RID: 104326 RVA: 0x00808355 File Offset: 0x00806755
	public override void Init()
	{
		SDKVoiceManager.isInit = true;
	}

	// Token: 0x06019787 RID: 104327 RVA: 0x00808360 File Offset: 0x00806760
	public override void UnInit()
	{
		if (this.sdkInterface != null)
		{
			this.ClearVoicePathQueue();
			this.ControlGameMusicMute(false);
			this.ControlGameMusicVolumn(false);
			this.UnInitChatVoice();
			this.UnInitTalkVoice();
		}
		SDKVoiceManager.isInit = false;
		this.hasWorldAutoPlayReported = false;
		this.hasTeamAutoPlayReported = false;
		this.hasGuildAutoPlayReported = false;
		this.hasNormalAutoPlayReported = false;
		this.hasPrivateAutoPlayReported = false;
		this.RemoveVoiceRoomEvent();
		this._voiceChatModule = null;
		this.gameChatType = ChatType.CT_ALL;
	}

	// Token: 0x06019788 RID: 104328 RVA: 0x008083D5 File Offset: 0x008067D5
	public void InitVoiceEnabled(bool chatVoiceEnabled, bool talkVoiceEnabled)
	{
		this.IsChatVoiceEnabled = chatVoiceEnabled;
		this.IsTalkRealVoiceEnabled = talkVoiceEnabled;
		if (!this.IsChatVoiceEnabled && !this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.Init();
		}
	}

	// Token: 0x06019789 RID: 104329 RVA: 0x00808412 File Offset: 0x00806812
	public void SetVoiceDebugLevel(SDKVoiceLogLevel level)
	{
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SetLogLevel(level);
		}
	}

	// Token: 0x0601978A RID: 104330 RVA: 0x0080842B File Offset: 0x0080682B
	public void SetVoiceSavePath(string path)
	{
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SaveVoiceCachePath = path;
		}
	}

	// Token: 0x0601978B RID: 104331 RVA: 0x00808444 File Offset: 0x00806844
	public void ResetRealTalkVoiceParams()
	{
		float playerVolumnPref = this.GetPlayerVolumnPref();
		this.SetPlayerVolume(playerVolumnPref);
		this.ControlGameMusicVolumn(true);
	}

	// Token: 0x0601978C RID: 104332 RVA: 0x00808466 File Offset: 0x00806866
	public void CutGameVolumnInTalkVoice()
	{
		this.ControlGameMusicVolumn(true);
	}

	// Token: 0x0601978D RID: 104333 RVA: 0x0080846F File Offset: 0x0080686F
	public void RecoverGameVolumnInTalkVoice()
	{
		this.ControlGameMusicVolumn(false);
	}

	// Token: 0x0601978E RID: 104334 RVA: 0x00808478 File Offset: 0x00806878
	public void ControlGameMusicMute(bool isMute)
	{
		if (isMute)
		{
			if (MonoSingleton<AudioManager>.instance != null)
			{
				MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioStream, isMute);
			}
		}
		else
		{
			bool mute = DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Mute;
			if (MonoSingleton<AudioManager>.instance != null)
			{
				MonoSingleton<AudioManager>.instance.SetMute(AudioType.AudioStream, mute);
				float volume = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
				MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, volume);
			}
		}
	}

	// Token: 0x0601978F RID: 104335 RVA: 0x00808500 File Offset: 0x00806900
	private void ControlGameMusicVolumn(bool beLower)
	{
		float num = (float)DataManager<SystemConfigManager>.GetInstance().SystemConfigData.SoundConfig.Volume;
		if (MonoSingleton<AudioManager>.instance == null)
		{
			return;
		}
		if (beLower)
		{
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, num * 0.5f);
		}
		else
		{
			MonoSingleton<AudioManager>.instance.SetVolume(AudioType.AudioStream, num);
		}
	}

	// Token: 0x06019790 RID: 104336 RVA: 0x0080855D File Offset: 0x0080695D
	public SDKVoiceInterface GetCurrVoiceInterface()
	{
		return this.sdkInterface;
	}

	// Token: 0x06019791 RID: 104337 RVA: 0x00808568 File Offset: 0x00806968
	public void ControlRealVoiceMic()
	{
		bool flag = this.IsTalkRealMicOn();
		if (flag)
		{
			this.CloseRealMic();
		}
		else
		{
			this.OpenRealMic();
		}
	}

	// Token: 0x06019792 RID: 104338 RVA: 0x00808594 File Offset: 0x00806994
	public void ControlRealVociePlayer()
	{
		bool flag = this.IsTalkRealPlayerOn();
		if (flag)
		{
			this.CloseReaPlayer();
		}
		else
		{
			this.OpenRealPlayer();
		}
	}

	// Token: 0x06019793 RID: 104339 RVA: 0x008085BF File Offset: 0x008069BF
	public void InitChatVoice()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.InitChatVoice();
		}
	}

	// Token: 0x06019794 RID: 104340 RVA: 0x008085E3 File Offset: 0x008069E3
	public void UnInitChatVoice()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.UnInitChatVoice();
		}
	}

	// Token: 0x06019795 RID: 104341 RVA: 0x00808608 File Offset: 0x00806A08
	public void LoginVoice(string roleId, string openId, string token)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		this.AddVoiceRoomEvent();
		if (this.sdkInterface != null)
		{
			if (string.IsNullOrEmpty(openId))
			{
				openId = "123456";
			}
			this.sdkInterface.LoginVoice(roleId, openId, token);
		}
		if (this.VoiceChatModule != null)
		{
			this.VoiceChatModule.Init();
		}
		this.InitReportAutoPlayRoleInfo();
	}

	// Token: 0x06019796 RID: 104342 RVA: 0x0080866E File Offset: 0x00806A6E
	public void LogoutVoice()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.LogoutVoice();
		}
		this.OnLogoutingVoice();
	}

	// Token: 0x06019797 RID: 104343 RVA: 0x00808698 File Offset: 0x00806A98
	public void CancelRecordVoice()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.CancelRecordVoice();
		}
	}

	// Token: 0x06019798 RID: 104344 RVA: 0x008086BC File Offset: 0x00806ABC
	public void AddVoicePathInQueue(string voiceKey)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.AddVoicePathInQueue(voiceKey);
		}
	}

	// Token: 0x06019799 RID: 104345 RVA: 0x008086E1 File Offset: 0x00806AE1
	public void ClearVoicePathQueue()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.ClearVoicePathQueue();
		}
	}

	// Token: 0x0601979A RID: 104346 RVA: 0x00808705 File Offset: 0x00806B05
	public void StopPlayVoice()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.StopPlayVoice();
		}
	}

	// Token: 0x0601979B RID: 104347 RVA: 0x00808729 File Offset: 0x00806B29
	public void SetVoiceVolume(float volume)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SetVoiceVolume(volume);
		}
	}

	// Token: 0x0601979C RID: 104348 RVA: 0x0080874E File Offset: 0x00806B4E
	public float GetVoiceVolume()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return 0f;
		}
		if (this.sdkInterface != null)
		{
			return this.sdkInterface.GetVoiceVolume();
		}
		return 0f;
	}

	// Token: 0x0601979D RID: 104349 RVA: 0x0080877D File Offset: 0x00806B7D
	public void OnPause()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.OnPause();
		}
	}

	// Token: 0x0601979E RID: 104350 RVA: 0x008087A1 File Offset: 0x00806BA1
	public void OnResume()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.OnResume();
		}
	}

	// Token: 0x0601979F RID: 104351 RVA: 0x008087C5 File Offset: 0x00806BC5
	public void ClearLocalCache()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.ClearLocalCache();
		}
	}

	// Token: 0x060197A0 RID: 104352 RVA: 0x008087E9 File Offset: 0x00806BE9
	public void ClearVoiceChatCache()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.ClearVoiceChatMsgCache();
		}
	}

	// Token: 0x060197A1 RID: 104353 RVA: 0x0080880D File Offset: 0x00806C0D
	public string ShowDebugLog()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return string.Empty;
		}
		if (this.sdkInterface != null)
		{
			return this.sdkInterface.ShowDebugLog();
		}
		return string.Empty;
	}

	// Token: 0x060197A2 RID: 104354 RVA: 0x0080883C File Offset: 0x00806C3C
	public bool IsVoiceRecording()
	{
		return this.IsChatVoiceEnabled && this.sdkInterface != null && this.sdkInterface.IsVoiceRecording();
	}

	// Token: 0x060197A3 RID: 104355 RVA: 0x00808863 File Offset: 0x00806C63
	public bool IsVoicePlaying()
	{
		return this.IsChatVoiceEnabled && this.sdkInterface != null && this.sdkInterface.IsVoicePlaying();
	}

	// Token: 0x060197A4 RID: 104356 RVA: 0x0080888A File Offset: 0x00806C8A
	public void JoinChatRoom(string roomId, bool beSaveRoomMsg)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.JoinChatRoom(roomId, beSaveRoomMsg);
		}
	}

	// Token: 0x060197A5 RID: 104357 RVA: 0x008088B0 File Offset: 0x00806CB0
	public void LeaveChatRoom(string roomId)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.LeaveChatRoom(roomId);
		}
	}

	// Token: 0x060197A6 RID: 104358 RVA: 0x008088D5 File Offset: 0x00806CD5
	public void StopAudioMessage()
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.StopAudioMessage((int)this.gameChatType + string.Empty);
		}
	}

	// Token: 0x060197A7 RID: 104359 RVA: 0x00808910 File Offset: 0x00806D10
	public void PlayVoiceCommon(string voiceKey)
	{
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			string chatChannelId = this.GetChatChannelId(ChatType.CT_PRIVATE);
			this.sdkInterface.PlayVoiceCommon(voiceKey, chatChannelId);
		}
	}

	// Token: 0x060197A8 RID: 104360 RVA: 0x0080894C File Offset: 0x00806D4C
	public void StartRecordVoiceCommon(ChatType gameChatType)
	{
		this.gameChatType = gameChatType;
		ulong num = 0UL;
		string chatChannelId = this.GetChatChannelId(gameChatType);
		bool bTranslate = TR.Value("voice_sdk_be_translate").Equals("1");
		if (!this.IsChatVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SendVoiceMessage(chatChannelId, gameChatType, ref num, bTranslate);
		}
	}

	// Token: 0x060197A9 RID: 104361 RVA: 0x008089B3 File Offset: 0x00806DB3
	public bool CheckLoginChatVoice()
	{
		return this.IsChatVoiceEnabled && this.sdkInterface != null && this.sdkInterface.CheckLoginChatVoice();
	}

	// Token: 0x060197AA RID: 104362 RVA: 0x008089DC File Offset: 0x00806DDC
	private void AddVoiceRoomEvent()
	{
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatGuildJoin, new ClientEventSystem.UIEventHandler(this.OnGuildJoinSucc));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatGuildLeave, new ClientEventSystem.UIEventHandler(this.OnGuildLeaveSucc));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatTeamJoin, new ClientEventSystem.UIEventHandler(this.OnTeamJoinSucc));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatTeamLeave, new ClientEventSystem.UIEventHandler(this.OnTeamLeaveSucc));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.OnSelectRolePrivateChat));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this.OnDeleteAllPrivateChat));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPrivateJoin, new ClientEventSystem.UIEventHandler(this.OnPrivateChatJoin));
		UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnVoiceChatPrivateLeave, new ClientEventSystem.UIEventHandler(this.OnPrivateChatLeave));
		this.AddVoiceChatLoginHandler();
	}

	// Token: 0x060197AB RID: 104363 RVA: 0x00808AC8 File Offset: 0x00806EC8
	private void RemoveVoiceRoomEvent()
	{
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatGuildJoin, new ClientEventSystem.UIEventHandler(this.OnGuildJoinSucc));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatGuildLeave, new ClientEventSystem.UIEventHandler(this.OnGuildLeaveSucc));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatTeamJoin, new ClientEventSystem.UIEventHandler(this.OnTeamJoinSucc));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatTeamLeave, new ClientEventSystem.UIEventHandler(this.OnTeamLeaveSucc));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RoleChatDirtyChanged, new ClientEventSystem.UIEventHandler(this.OnSelectRolePrivateChat));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDelPrivate, new ClientEventSystem.UIEventHandler(this.OnDeleteAllPrivateChat));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPrivateJoin, new ClientEventSystem.UIEventHandler(this.OnPrivateChatJoin));
		UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnVoiceChatPrivateLeave, new ClientEventSystem.UIEventHandler(this.OnPrivateChatLeave));
		this.RemoveVoiceChatLoginHandler();
	}

	// Token: 0x060197AC RID: 104364 RVA: 0x00808BB3 File Offset: 0x00806FB3
	private void OnGuildJoinSucc(UIEvent evt)
	{
		this.JoinGuildChannel();
	}

	// Token: 0x060197AD RID: 104365 RVA: 0x00808BBB File Offset: 0x00806FBB
	private void OnGuildLeaveSucc(UIEvent evt)
	{
		this.LeaveGuildChannel();
	}

	// Token: 0x060197AE RID: 104366 RVA: 0x00808BC3 File Offset: 0x00806FC3
	private void OnTeamJoinSucc(UIEvent evt)
	{
		this.JoinTeamChannel();
	}

	// Token: 0x060197AF RID: 104367 RVA: 0x00808BCB File Offset: 0x00806FCB
	private void OnTeamLeaveSucc(UIEvent evt)
	{
		this.LeaveTeamChannel();
	}

	// Token: 0x060197B0 RID: 104368 RVA: 0x00808BD3 File Offset: 0x00806FD3
	private void OnSelectRolePrivateChat(UIEvent evt)
	{
		if (evt == null)
		{
			return;
		}
		if (evt.Param1 == null)
		{
			return;
		}
		this.currSelectPlayerVoiceId = this.GetPrivateChatRoomId((ulong)evt.Param1);
		this.JoinPrivateChannel(this.currSelectPlayerVoiceId);
	}

	// Token: 0x060197B1 RID: 104369 RVA: 0x00808C0C File Offset: 0x0080700C
	private void OnDeleteAllPrivateChat(UIEvent evt)
	{
		if (evt == null)
		{
			return;
		}
		UIEventDelPrivate uieventDelPrivate = evt as UIEventDelPrivate;
		this.currSelectPlayerVoiceId = this.GetPrivateChatRoomId(uieventDelPrivate.m_uid);
		this.LeavePrivateChannel(false, this.currSelectPlayerVoiceId);
	}

	// Token: 0x060197B2 RID: 104370 RVA: 0x00808C48 File Offset: 0x00807048
	private void OnPrivateChatJoin(UIEvent evt)
	{
		if (evt == null)
		{
			return;
		}
		if (evt.Param1 == null)
		{
			return;
		}
		string item = (string)evt.Param1;
		if (this.privateChannelIdList != null && !this.privateChannelIdList.Contains(item))
		{
			this.privateChannelIdList.Add(item);
		}
	}

	// Token: 0x060197B3 RID: 104371 RVA: 0x00808C9C File Offset: 0x0080709C
	private void OnPrivateChatLeave(UIEvent evt)
	{
		if (evt == null)
		{
			return;
		}
		if (evt.Param1 == null)
		{
			return;
		}
		string item = (string)evt.Param1;
		if (this.privateChannelIdList != null && this.privateChannelIdList.Contains(item))
		{
			this.privateChannelIdList.Remove(item);
		}
	}

	// Token: 0x170020DD RID: 8413
	// (get) Token: 0x060197B4 RID: 104372 RVA: 0x00808CF1 File Offset: 0x008070F1
	public string localPlayerVoiceId
	{
		get
		{
			if (string.IsNullOrEmpty(this._localPlayerVoiceId))
			{
				this._localPlayerVoiceId = this.GetPlayerVoiceId(ClientApplication.playerinfo.accid + string.Empty);
			}
			return this._localPlayerVoiceId;
		}
	}

	// Token: 0x060197B5 RID: 104373 RVA: 0x00808D2E File Offset: 0x0080712E
	public string GetVoiceToken(string extra)
	{
		return string.Format("{0}_{1}_{2}", this.localPlayerVoiceId, this.GetServerTimeStamp(), extra);
	}

	// Token: 0x060197B6 RID: 104374 RVA: 0x00808D4C File Offset: 0x0080714C
	public ulong GetServerTimeStamp()
	{
		ulong result = 0UL;
		try
		{
			result = (ulong)DataManager<TimeManager>.GetInstance().GetServerTime();
		}
		catch (Exception ex)
		{
			Logger.LogError("get server timeStamp error" + ex.ToString());
		}
		return result;
	}

	// Token: 0x060197B7 RID: 104375 RVA: 0x00808D9C File Offset: 0x0080719C
	public ChatType GetChatTypeInVoiceKey(string voiceKey)
	{
		ChatType result = ChatType.CT_ALL;
		if (string.IsNullOrEmpty(voiceKey))
		{
			return result;
		}
		string[] array = voiceKey.Split(new char[]
		{
			'_'
		});
		if (array != null && array.Length == 5)
		{
			if (string.IsNullOrEmpty(array[4]))
			{
				return result;
			}
			int num = -1;
			if (int.TryParse(array[4], out num))
			{
				if (num < 0)
				{
					return result;
				}
				return (ChatType)num;
			}
		}
		return result;
	}

	// Token: 0x060197B8 RID: 104376 RVA: 0x00808E08 File Offset: 0x00807208
	public string GetTargetUIdFromVoiceKey(string voiceKey)
	{
		ulong accIdInVoiceKey = this.GetAccIdInVoiceKey(voiceKey);
		return this.GetPlayerVoiceId(accIdInVoiceKey + string.Empty);
	}

	// Token: 0x060197B9 RID: 104377 RVA: 0x00808E35 File Offset: 0x00807235
	private string GetPlayerVoiceId(string accId)
	{
		return string.Format("{0}_{1}_{2}", ClientApplication.playerinfo.serverID, SDKInterface.instance.GetPlatformNameBySelect(), accId);
	}

	// Token: 0x060197BA RID: 104378 RVA: 0x00808E5C File Offset: 0x0080725C
	private string GetPrivateChatRoomId(ulong targetId)
	{
		ulong roleID = DataManager<PlayerBaseData>.GetInstance().RoleID;
		string arg = (targetId <= roleID) ? string.Format("{0}_{1}", targetId, roleID) : string.Format("{0}_{1}", roleID, targetId);
		return string.Format("{0}_p_{1}_{2}", ClientApplication.playerinfo.serverID, SDKInterface.instance.GetPlatformNameBySelect(), arg);
	}

	// Token: 0x060197BB RID: 104379 RVA: 0x00808ED4 File Offset: 0x008072D4
	private ulong GetAccIdInVoiceKey(string voiceKey)
	{
		ulong result = 0UL;
		if (string.IsNullOrEmpty(voiceKey))
		{
			return result;
		}
		string[] array = voiceKey.Split(new char[]
		{
			'_'
		});
		if (array != null && array.Length == 5)
		{
			if (string.IsNullOrEmpty(array[2]))
			{
				return result;
			}
			if (ulong.TryParse(array[2], out result))
			{
				return result;
			}
		}
		return result;
	}

	// Token: 0x060197BC RID: 104380 RVA: 0x00808F34 File Offset: 0x00807334
	private string GetChatChannelId(ChatType chatType)
	{
		switch (chatType)
		{
		case ChatType.CT_WORLD:
			return this.worldChannelId;
		case ChatType.CT_NORMAL:
			return this.sceneChannelId;
		case ChatType.CT_GUILD:
			return this.guildChannelId;
		case ChatType.CT_TEAM:
			return this.teamChannelId;
		case ChatType.CT_PRIVATE:
			return this.currSelectPlayerVoiceId;
		}
		return string.Empty;
	}

	// Token: 0x060197BD RID: 104381 RVA: 0x00808F90 File Offset: 0x00807390
	private void AddVoiceChatLoginHandler()
	{
		if (this.sdkInterface != null)
		{
			this.sdkInterface.onVoiceChatLoginHandler = new SDKVoiceInterface.OnVoiceChatLogin(this.OnVoiceChatLogin);
			this.sdkInterface.onVoiceChatLogoutHandler = new SDKVoiceInterface.OnVoiceChatLogout(this.OnVoiceChatLogout);
			this.sdkInterface.onVoiceChatNotJoinRoomHandler = new SDKVoiceInterface.OnVoiceChatNotJoinRoom(this.OnVoiceChatNotJoinRoom);
		}
	}

	// Token: 0x060197BE RID: 104382 RVA: 0x00808FED File Offset: 0x008073ED
	private void RemoveVoiceChatLoginHandler()
	{
		if (this.sdkInterface != null)
		{
			this.sdkInterface.onVoiceChatLoginHandler = null;
			this.sdkInterface.onVoiceChatLogoutHandler = null;
			this.sdkInterface.onVoiceChatNotJoinRoomHandler = null;
		}
	}

	// Token: 0x060197BF RID: 104383 RVA: 0x00809020 File Offset: 0x00807420
	private void OnVoiceChatLogin()
	{
		this.JoinWorldChannel();
		this.TryJoinGuildChannel();
		this.TryJoinTeamChannel();
		this.TryJoinSceneChannel();
		this.JoinPrivateChannel(this.currSelectPlayerVoiceId);
		DataManager<ChatManager>.GetInstance().AddSyncVoiceChatListener(new Action<ChatData>(this.VoiceChatModule.TryAutoPlayVoiceMessage));
	}

	// Token: 0x060197C0 RID: 104384 RVA: 0x0080906C File Offset: 0x0080746C
	private void OnVoiceChatLogout()
	{
		DataManager<ChatManager>.GetInstance().RemoveAllSyncVoiceChatListener();
	}

	// Token: 0x060197C1 RID: 104385 RVA: 0x00809078 File Offset: 0x00807478
	private void OnVoiceChatNotJoinRoom()
	{
		switch (this.gameChatType)
		{
		case ChatType.CT_WORLD:
			this.JoinWorldChannel();
			break;
		case ChatType.CT_NORMAL:
			this.TryJoinSceneChannel();
			break;
		case ChatType.CT_GUILD:
			this.TryJoinGuildChannel();
			break;
		case ChatType.CT_TEAM:
			this.TryJoinTeamChannel();
			break;
		case ChatType.CT_PRIVATE:
			this.JoinPrivateChannel(this.currSelectPlayerVoiceId);
			break;
		}
	}

	// Token: 0x060197C2 RID: 104386 RVA: 0x008090F4 File Offset: 0x008074F4
	private void TryJoinGuildChannel()
	{
		bool myGuild = DataManager<GuildDataManager>.GetInstance().myGuild != null;
		if (myGuild)
		{
			this.JoinGuildChannel();
		}
	}

	// Token: 0x060197C3 RID: 104387 RVA: 0x00809124 File Offset: 0x00807524
	private void TryJoinTeamChannel()
	{
		bool flag = DataManager<TeamDataManager>.GetInstance().HasTeam();
		if (flag)
		{
			this.JoinTeamChannel();
		}
	}

	// Token: 0x060197C4 RID: 104388 RVA: 0x00809148 File Offset: 0x00807548
	private void TryJoinSceneChannel()
	{
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown != null)
		{
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SceneType == CitySceneTable.eSceneType.NORMAL || tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
			{
				this.JoinSceneChannel();
			}
		}
	}

	// Token: 0x060197C5 RID: 104389 RVA: 0x008091AC File Offset: 0x008075AC
	public void JoinWorldChannel()
	{
		this.worldChannelId = string.Format("{0}_world", ClientApplication.playerinfo.serverID);
		this.JoinChatRoom(this.worldChannelId, true);
	}

	// Token: 0x060197C6 RID: 104390 RVA: 0x008091DA File Offset: 0x008075DA
	public void LeaveWorldChannel()
	{
		this.LeaveChatRoom(this.worldChannelId);
		this.worldChannelId = string.Empty;
	}

	// Token: 0x060197C7 RID: 104391 RVA: 0x008091F4 File Offset: 0x008075F4
	public void JoinSceneChannel()
	{
		string arg = string.Empty;
		ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
		if (clientSystemTown != null)
		{
			arg = clientSystemTown.CurrentSceneID.ToString();
			this.sceneChannelId = string.Format("{0}_s_{1}", ClientApplication.playerinfo.serverID, arg);
			this.JoinChatRoom(this.sceneChannelId, true);
		}
	}

	// Token: 0x060197C8 RID: 104392 RVA: 0x00809264 File Offset: 0x00807664
	public void LeaveSceneChannel()
	{
		this.LeaveChatRoom(this.sceneChannelId);
		this.sceneChannelId = string.Empty;
	}

	// Token: 0x060197C9 RID: 104393 RVA: 0x00809280 File Offset: 0x00807680
	public void JoinDungeonChannel()
	{
		if (BattleMain.instance == null || BattleMain.instance.GetDungeonManager() == null || BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
		{
			return;
		}
		int dungeonID = BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID;
		this.dungeonChannelId = string.Format("{0}_f_{1}", ClientApplication.playerinfo.serverID, dungeonID);
		this.JoinChatRoom(this.dungeonChannelId, true);
	}

	// Token: 0x060197CA RID: 104394 RVA: 0x00809307 File Offset: 0x00807707
	public void LeaveDungeonChannel()
	{
		this.LeaveChatRoom(this.dungeonChannelId);
		this.dungeonChannelId = string.Empty;
	}

	// Token: 0x060197CB RID: 104395 RVA: 0x00809320 File Offset: 0x00807720
	public void JoinGuildChannel()
	{
		GuildMyData myGuild = DataManager<GuildDataManager>.GetInstance().myGuild;
		if (myGuild == null)
		{
			return;
		}
		this.guildChannelId = string.Format("{0}_g_{1}", ClientApplication.playerinfo.serverID, myGuild.uGUID);
		this.JoinChatRoom(this.guildChannelId, true);
	}

	// Token: 0x060197CC RID: 104396 RVA: 0x00809376 File Offset: 0x00807776
	public void LeaveGuildChannel()
	{
		this.LeaveChatRoom(this.guildChannelId);
		this.guildChannelId = string.Empty;
	}

	// Token: 0x060197CD RID: 104397 RVA: 0x00809390 File Offset: 0x00807790
	public void JoinTeamChannel()
	{
		Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
		if (myTeam == null)
		{
			return;
		}
		this.teamChannelId = string.Format("{0}_t_{1}", ClientApplication.playerinfo.serverID, myTeam.teamID);
		this.JoinChatRoom(this.teamChannelId, true);
	}

	// Token: 0x060197CE RID: 104398 RVA: 0x008093E6 File Offset: 0x008077E6
	public void LeaveTeamChannel()
	{
		this.LeaveChatRoom(this.teamChannelId);
		this.teamChannelId = string.Empty;
	}

	// Token: 0x060197CF RID: 104399 RVA: 0x008093FF File Offset: 0x008077FF
	private void JoinPrivateChannel(string privateChannelId)
	{
		if (this.privateChannelIdList == null)
		{
			return;
		}
		if (this.privateChannelIdList.Contains(privateChannelId))
		{
			return;
		}
		this.JoinChatRoom(privateChannelId, true);
	}

	// Token: 0x060197D0 RID: 104400 RVA: 0x00809428 File Offset: 0x00807828
	public void LeavePrivateChannel(bool beLeaveAll = false, string pChannelId = "")
	{
		if (this.privateChannelIdList == null)
		{
			return;
		}
		if (!beLeaveAll && !string.IsNullOrEmpty(pChannelId))
		{
			if (this.privateChannelIdList.Contains(pChannelId))
			{
				this.LeaveChatRoom(pChannelId);
			}
		}
		else
		{
			for (int i = 0; i < this.privateChannelIdList.Count; i++)
			{
				string roomId = this.privateChannelIdList[i];
				this.LeaveChatRoom(roomId);
			}
		}
	}

	// Token: 0x060197D1 RID: 104401 RVA: 0x0080949F File Offset: 0x0080789F
	public void LeaveVoiceSDK(bool beLogout = false)
	{
		this.LeaveAllChatChannel();
		this.ClearVoiceChatCache();
		if (beLogout)
		{
			this.LogoutVoice();
		}
		else
		{
			this.OnLogoutingVoice();
		}
		this.LeaveAllChannel();
		ComVoiceTalk.ForceDestroy();
	}

	// Token: 0x060197D2 RID: 104402 RVA: 0x008094D0 File Offset: 0x008078D0
	private void OnLogoutingVoice()
	{
		this.RemoveVoiceRoomEvent();
		if (this.VoiceChatModule != null)
		{
			this.VoiceChatModule.Unint();
		}
		this.currSelectPlayerVoiceId = string.Empty;
		this._localPlayerVoiceId = string.Empty;
		this.worldChannelId = string.Empty;
		this.sceneChannelId = string.Empty;
		this.dungeonChannelId = string.Empty;
		this.guildChannelId = string.Empty;
		this.teamChannelId = string.Empty;
		this.privateChannelIdList.Clear();
	}

	// Token: 0x060197D3 RID: 104403 RVA: 0x00809551 File Offset: 0x00807951
	private void LeaveAllChatChannel()
	{
		this.LeaveWorldChannel();
		this.LeaveSceneChannel();
		this.LeaveGuildChannel();
		this.LeaveTeamChannel();
		this.LeaveDungeonChannel();
		this.LeavePrivateChannel(true, string.Empty);
	}

	// Token: 0x060197D4 RID: 104404 RVA: 0x0080957D File Offset: 0x0080797D
	public void InitTalkVoice()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.InitTalkVoice();
		}
	}

	// Token: 0x060197D5 RID: 104405 RVA: 0x008095A1 File Offset: 0x008079A1
	public void UnInitTalkVoice()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.UnInitTalkVoice();
		}
	}

	// Token: 0x060197D6 RID: 104406 RVA: 0x008095C5 File Offset: 0x008079C5
	public bool BeInRealVoiceChannel()
	{
		return this.IsTalkRealVoiceEnabled && this.sdkInterface != null && this.sdkInterface.BeInRealVoiceChannel();
	}

	// Token: 0x060197D7 RID: 104407 RVA: 0x008095EC File Offset: 0x008079EC
	public void AddRealVoiceHandler(SDKVoiceInterface.OnJoinChannelSuccess joinSuccHandler, SDKVoiceInterface.OnVoiceMicOn voiceMicHandler, SDKVoiceInterface.OnVoicePlayerOn voicePlayerHandler, SDKVoiceInterface.OnVoiceLimitOtherNotSpeack voiceSpeakLimit = null, SDKVoiceInterface.OnVoiceMicOffByOther voiceMicOffByOther = null, SDKVoiceInterface.OnVoiceTalkGlobalSilenceChanged globalSilenceChanged = null, SDKVoiceInterface.OnVoiceTalkChannelChanged voiceTalkChannelChanged = null, SDKVoiceInterface.OnVoiceTalkOtherSpeakInChannel voiceTalkOtherSpeak = null, SDKVoiceInterface.OnVoiceTalkOtherControlMic voiceTalkOtherCtrlMic = null, SDKVoiceInterface.OnVoiceTalkOtherChangeSpeakChannel voiceTalkOtherChangeChannel = null, SDKVoiceInterface.OnVoiceTalkOtherLeaveChannel voiceTalkOtherLeaveChannel = null, SDKVoiceInterface.OnVoiceTalkMicAuthNoPermission micAuthNoPermission = null, SDKVoiceInterface.OnLeaveChannelSuccess leaveSuccHandler = null)
	{
		if (this.sdkInterface == null)
		{
			return;
		}
		if (joinSuccHandler != null)
		{
			this.sdkInterface.onJoinChannelSucc += joinSuccHandler;
		}
		if (leaveSuccHandler != null)
		{
			this.sdkInterface.onLeaveChannelSucc += leaveSuccHandler;
		}
		if (voiceMicHandler != null)
		{
			this.sdkInterface.onVoiceMicOn += voiceMicHandler;
		}
		if (voicePlayerHandler != null)
		{
			this.sdkInterface.onVoicePlayerOn += voicePlayerHandler;
		}
		if (voiceSpeakLimit != null)
		{
			this.sdkInterface.onVoiceLimitOtherNotSpeak += voiceSpeakLimit;
		}
		if (voiceMicOffByOther != null)
		{
			this.sdkInterface.onVoiceMicOffByOther += voiceMicOffByOther;
		}
		if (globalSilenceChanged != null)
		{
			this.sdkInterface.onVoiceTalkGlobalSilenceChanged += globalSilenceChanged;
		}
		if (voiceTalkChannelChanged != null)
		{
			this.sdkInterface.onVoiceTalkChannelChanged += voiceTalkChannelChanged;
		}
		if (voiceTalkOtherSpeak != null)
		{
			this.sdkInterface.onOtherSpeakInChannel += voiceTalkOtherSpeak;
		}
		if (voiceTalkOtherCtrlMic != null)
		{
			this.sdkInterface.onOtherControlMic += voiceTalkOtherCtrlMic;
		}
		if (voiceTalkOtherChangeChannel != null)
		{
			this.sdkInterface.onOtherChangeSpeakChannel += voiceTalkOtherChangeChannel;
		}
		if (voiceTalkOtherLeaveChannel != null)
		{
			this.sdkInterface.onOtherLeaveChannel += voiceTalkOtherLeaveChannel;
		}
		if (micAuthNoPermission != null)
		{
			this.sdkInterface.onMicAuthNoPermission += micAuthNoPermission;
		}
	}

	// Token: 0x060197D8 RID: 104408 RVA: 0x00809704 File Offset: 0x00807B04
	public void RemoveRealVoiceHandler(SDKVoiceInterface.OnJoinChannelSuccess joinSuccHandler, SDKVoiceInterface.OnVoiceMicOn voiceMicHandler, SDKVoiceInterface.OnVoicePlayerOn voicePlayerHandler, SDKVoiceInterface.OnVoiceLimitOtherNotSpeack voiceSpeakLimit = null, SDKVoiceInterface.OnVoiceMicOffByOther voiceMicOffByOther = null, SDKVoiceInterface.OnVoiceTalkGlobalSilenceChanged globalSilenceChanged = null, SDKVoiceInterface.OnVoiceTalkChannelChanged voiceTalkChannelChanged = null, SDKVoiceInterface.OnVoiceTalkOtherSpeakInChannel voiceTalkOtherSpeak = null, SDKVoiceInterface.OnVoiceTalkOtherControlMic voiceTalkOtherCtrlMic = null, SDKVoiceInterface.OnVoiceTalkOtherChangeSpeakChannel voiceTalkOtherChangeChannel = null, SDKVoiceInterface.OnVoiceTalkOtherLeaveChannel voiceTalkOtherLeaveChannel = null, SDKVoiceInterface.OnVoiceTalkMicAuthNoPermission micAuthNoPermission = null, SDKVoiceInterface.OnLeaveChannelSuccess leaveSuccHandler = null)
	{
		if (this.sdkInterface == null)
		{
			return;
		}
		if (joinSuccHandler != null)
		{
			this.sdkInterface.onJoinChannelSucc -= joinSuccHandler;
		}
		if (leaveSuccHandler != null)
		{
			this.sdkInterface.onLeaveChannelSucc -= leaveSuccHandler;
		}
		if (voiceMicHandler != null)
		{
			this.sdkInterface.onVoiceMicOn -= voiceMicHandler;
		}
		if (voicePlayerHandler != null)
		{
			this.sdkInterface.onVoicePlayerOn -= voicePlayerHandler;
		}
		if (voiceSpeakLimit != null)
		{
			this.sdkInterface.onVoiceLimitOtherNotSpeak -= voiceSpeakLimit;
		}
		if (voiceMicOffByOther != null)
		{
			this.sdkInterface.onVoiceMicOffByOther -= voiceMicOffByOther;
		}
		if (globalSilenceChanged != null)
		{
			this.sdkInterface.onVoiceTalkGlobalSilenceChanged -= globalSilenceChanged;
		}
		if (voiceTalkChannelChanged != null)
		{
			this.sdkInterface.onVoiceTalkChannelChanged -= voiceTalkChannelChanged;
		}
		if (voiceTalkOtherSpeak != null)
		{
			this.sdkInterface.onOtherSpeakInChannel -= voiceTalkOtherSpeak;
		}
		if (voiceTalkOtherCtrlMic != null)
		{
			this.sdkInterface.onOtherControlMic -= voiceTalkOtherCtrlMic;
		}
		if (voiceTalkOtherChangeChannel != null)
		{
			this.sdkInterface.onOtherChangeSpeakChannel -= voiceTalkOtherChangeChannel;
		}
		if (voiceTalkOtherLeaveChannel != null)
		{
			this.sdkInterface.onOtherLeaveChannel -= voiceTalkOtherLeaveChannel;
		}
		if (micAuthNoPermission != null)
		{
			this.sdkInterface.onMicAuthNoPermission -= micAuthNoPermission;
		}
	}

	// Token: 0x060197D9 RID: 104409 RVA: 0x0080981C File Offset: 0x00807C1C
	public static string GenerateTalkChannelId(int sceneId)
	{
		string result = string.Empty;
		int length = sceneId.ToString().Length;
		if (length > 0)
		{
			result = (ClientApplication.playerinfo.serverID * Math.Pow(10.0, (double)length) + (double)sceneId).ToString();
		}
		return result;
	}

	// Token: 0x060197DA RID: 104410 RVA: 0x0080987C File Offset: 0x00807C7C
	public static string GetTalkGameSceneId(string talkChannelId)
	{
		if (string.IsNullOrEmpty(talkChannelId))
		{
			return string.Empty;
		}
		int length = talkChannelId.Length;
		int num;
		if (int.TryParse(talkChannelId, out num))
		{
			return (num % (int)Math.Pow(10.0, (double)length)).ToString();
		}
		return talkChannelId;
	}

	// Token: 0x060197DB RID: 104411 RVA: 0x008098D8 File Offset: 0x00807CD8
	private static string _TryGetTalkChannelId(string sIdStr)
	{
		if (string.IsNullOrEmpty(sIdStr))
		{
			return string.Empty;
		}
		int sceneId;
		string result;
		if (int.TryParse(sIdStr, out sceneId))
		{
			result = SDKVoiceManager.GenerateTalkChannelId(sceneId);
		}
		else
		{
			result = sIdStr;
		}
		return result;
	}

	// Token: 0x060197DC RID: 104412 RVA: 0x00809912 File Offset: 0x00807D12
	public void JoinChannel(string channelId, string roleId, string openId, string token)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.JoinChannel(channelId);
		}
	}

	// Token: 0x060197DD RID: 104413 RVA: 0x00809937 File Offset: 0x00807D37
	public void LeaveAllChannel()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.LeaveAllChannel();
		}
	}

	// Token: 0x060197DE RID: 104414 RVA: 0x0080995C File Offset: 0x00807D5C
	public void JoinTalkChannel(string sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		int sceneId2;
		if (int.TryParse(sceneId, out sceneId2))
		{
			this.JoinTalkChannel(sceneId2);
		}
		else
		{
			this._JoinTalkChannel(sceneId);
		}
	}

	// Token: 0x060197DF RID: 104415 RVA: 0x00809998 File Offset: 0x00807D98
	public void JoinTalkChannel(int sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager.GenerateTalkChannelId(sceneId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.JoinChannel(text);
		}
	}

	// Token: 0x060197E0 RID: 104416 RVA: 0x008099DC File Offset: 0x00807DDC
	private void _JoinTalkChannel(string channelId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager._TryGetTalkChannelId(channelId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.JoinChannel(text);
		}
	}

	// Token: 0x060197E1 RID: 104417 RVA: 0x00809A20 File Offset: 0x00807E20
	public void LeaveTalkChannel(string sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		int sceneId2;
		if (int.TryParse(sceneId, out sceneId2))
		{
			this.LeaveTalkChannel(sceneId2);
		}
		else
		{
			this._LeaveTalkChannel(sceneId);
		}
	}

	// Token: 0x060197E2 RID: 104418 RVA: 0x00809A5C File Offset: 0x00807E5C
	public void LeaveTalkChannel(int sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager.GenerateTalkChannelId(sceneId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.LeaveChannel(text);
		}
	}

	// Token: 0x060197E3 RID: 104419 RVA: 0x00809AA0 File Offset: 0x00807EA0
	private void _LeaveTalkChannel(string channelId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager._TryGetTalkChannelId(channelId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.LeaveChannel(text);
		}
	}

	// Token: 0x060197E4 RID: 104420 RVA: 0x00809AE4 File Offset: 0x00807EE4
	public string GetCurrentTalkChanneld()
	{
		string talkChannelId = string.Empty;
		if (this.sdkInterface != null)
		{
			talkChannelId = this.sdkInterface.CurrentTalkChannelId();
		}
		return SDKVoiceManager.GetTalkGameSceneId(talkChannelId);
	}

	// Token: 0x060197E5 RID: 104421 RVA: 0x00809B14 File Offset: 0x00807F14
	public void SwitchTalkChannel(string sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		int sceneId2;
		if (int.TryParse(sceneId, out sceneId2))
		{
			this.SwitchTalkChannel(sceneId2);
		}
		else
		{
			this._SwitchTalkChannel(sceneId);
		}
	}

	// Token: 0x060197E6 RID: 104422 RVA: 0x00809B50 File Offset: 0x00807F50
	public void SwitchTalkChannel(int sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager.GenerateTalkChannelId(sceneId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.SetCurrentTalkChannelId(text);
		}
	}

	// Token: 0x060197E7 RID: 104423 RVA: 0x00809B94 File Offset: 0x00807F94
	private void _SwitchTalkChannel(string channelId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (string.IsNullOrEmpty(channelId))
		{
			return;
		}
		string text = SDKVoiceManager._TryGetTalkChannelId(channelId);
		if (!string.IsNullOrEmpty(text) && this.sdkInterface != null)
		{
			this.sdkInterface.SetCurrentTalkChannelId(text);
		}
	}

	// Token: 0x060197E8 RID: 104424 RVA: 0x00809BE4 File Offset: 0x00807FE4
	public void UpdateTalkChannel(List<string> sceneIds)
	{
		if (sceneIds == null)
		{
			return;
		}
		List<string> list = new List<string>();
		for (int i = 0; i < sceneIds.Count; i++)
		{
			string sIdStr = sceneIds[i];
			string text = SDKVoiceManager._TryGetTalkChannelId(sIdStr);
			if (!string.IsNullOrEmpty(text))
			{
				if (!list.Contains(text))
				{
					list.Add(text);
				}
			}
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.UpdateTalkChannel(list);
		}
	}

	// Token: 0x060197E9 RID: 104425 RVA: 0x00809C60 File Offset: 0x00808060
	public bool IsJoinedTalkChannel(int sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return false;
		}
		string channelId = SDKVoiceManager.GenerateTalkChannelId(sceneId);
		return this.sdkInterface != null && this.sdkInterface.IsJoinedTalkChannel(channelId);
	}

	// Token: 0x060197EA RID: 104426 RVA: 0x00809C9C File Offset: 0x0080809C
	public bool IsJoinedTalkChannel(string sceneId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return false;
		}
		if (this.sdkInterface != null)
		{
			string text = SDKVoiceManager._TryGetTalkChannelId(sceneId);
			if (!string.IsNullOrEmpty(text))
			{
				return this.sdkInterface.IsJoinedTalkChannel(text);
			}
		}
		return false;
	}

	// Token: 0x060197EB RID: 104427 RVA: 0x00809CE1 File Offset: 0x008080E1
	public bool HasJoinedTalkChannel()
	{
		return this.IsTalkRealVoiceEnabled && this.sdkInterface != null && this.sdkInterface.HasJoinedTalkChannel();
	}

	// Token: 0x060197EC RID: 104428 RVA: 0x00809D08 File Offset: 0x00808108
	public string GetOtherTalkChannelId(string gameAccId)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return string.Empty;
		}
		string playerVoiceId = this.GetPlayerVoiceId(gameAccId);
		if (string.IsNullOrEmpty(playerVoiceId))
		{
			return string.Empty;
		}
		if (this.sdkInterface != null)
		{
			return this.sdkInterface.GetOtherTalkChannelId(playerVoiceId);
		}
		return string.Empty;
	}

	// Token: 0x060197ED RID: 104429 RVA: 0x00809D5C File Offset: 0x0080815C
	public void ControlGlobalSilence(string mainChannelIdStr)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsRecordVoiceEnabled)
		{
			return;
		}
		if (string.IsNullOrEmpty(mainChannelIdStr))
		{
			return;
		}
		if (this.IsGlobalSilence())
		{
			this.SetGlobalSilence(mainChannelIdStr, false);
		}
		else
		{
			this.SetGlobalSilence(mainChannelIdStr, true);
		}
	}

	// Token: 0x060197EE RID: 104430 RVA: 0x00809DAD File Offset: 0x008081AD
	public bool IsMicEnable()
	{
		return this.sdkInterface != null && this.sdkInterface.IsMicEnable();
	}

	// Token: 0x060197EF RID: 104431 RVA: 0x00809DC7 File Offset: 0x008081C7
	public bool IsGlobalSilence()
	{
		return this.sdkInterface != null && this.sdkInterface.IsGlobalSilence();
	}

	// Token: 0x060197F0 RID: 104432 RVA: 0x00809DE4 File Offset: 0x008081E4
	public void SetGlobalSilence(string mainChannelId, bool isNotSpeak)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsRecordVoiceEnabled)
		{
			return;
		}
		string text = SDKVoiceManager._TryGetTalkChannelId(mainChannelId);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SetGlobalSilenceInMainChannel(text, isNotSpeak);
		}
	}

	// Token: 0x060197F1 RID: 104433 RVA: 0x00809E34 File Offset: 0x00808234
	public string GetGameAccIdByVoicePlayerId(string voicePlayerId)
	{
		string text = voicePlayerId;
		if (string.IsNullOrEmpty(voicePlayerId))
		{
			return text;
		}
		string[] array = text.Split(new char[]
		{
			'_'
		});
		if (array != null && array.Length >= 3)
		{
			text = array[2];
		}
		return text;
	}

	// Token: 0x060197F2 RID: 104434 RVA: 0x00809E78 File Offset: 0x00808278
	public void SetMicEnable(string gameAccId, bool bEnable)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsRecordVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			string playerVoiceId = this.GetPlayerVoiceId(gameAccId);
			this.sdkInterface.SetMicEnable(playerVoiceId, bEnable);
		}
	}

	// Token: 0x060197F3 RID: 104435 RVA: 0x00809EBD File Offset: 0x008082BD
	public void OpenRealMic()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsRecordVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.OpenRealMic();
		}
	}

	// Token: 0x060197F4 RID: 104436 RVA: 0x00809EED File Offset: 0x008082ED
	public void CloseRealMic()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsRecordVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.CloseRealMic();
		}
	}

	// Token: 0x060197F5 RID: 104437 RVA: 0x00809F1D File Offset: 0x0080831D
	public void OpenRealPlayer()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsPlayVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.OpenRealPlayer();
		}
	}

	// Token: 0x060197F6 RID: 104438 RVA: 0x00809F4D File Offset: 0x0080834D
	public void CloseReaPlayer()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (!this.IsPlayVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.CloseReaPlayer();
		}
	}

	// Token: 0x060197F7 RID: 104439 RVA: 0x00809F7D File Offset: 0x0080837D
	public bool IsTalkRealMicOn()
	{
		return this.IsTalkRealVoiceEnabled && this.sdkInterface != null && this.sdkInterface.IsTalkRealMicOn();
	}

	// Token: 0x060197F8 RID: 104440 RVA: 0x00809FA4 File Offset: 0x008083A4
	public bool IsTalkRealPlayerOn()
	{
		return this.IsTalkRealVoiceEnabled && this.sdkInterface != null && this.sdkInterface.IsTalkRealPlayerOn();
	}

	// Token: 0x060197F9 RID: 104441 RVA: 0x00809FCB File Offset: 0x008083CB
	public void SetPlayerVolume(float volume)
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.SetPlayerVolume(volume);
		}
	}

	// Token: 0x060197FA RID: 104442 RVA: 0x00809FF0 File Offset: 0x008083F0
	public float GetPlayerVolume()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return 0f;
		}
		if (this.sdkInterface != null)
		{
			return this.sdkInterface.GetPlayerVolume();
		}
		return 0f;
	}

	// Token: 0x060197FB RID: 104443 RVA: 0x0080A01F File Offset: 0x0080841F
	public void PauseChannel()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.PauseChannel();
		}
	}

	// Token: 0x060197FC RID: 104444 RVA: 0x0080A043 File Offset: 0x00808443
	public void ResumeChannel()
	{
		if (!this.IsTalkRealVoiceEnabled)
		{
			return;
		}
		if (this.sdkInterface != null)
		{
			this.sdkInterface.ResumeChannel();
		}
	}

	// Token: 0x060197FD RID: 104445 RVA: 0x0080A067 File Offset: 0x00808467
	public void SaveWorldAutoPlayValue(bool world)
	{
		PlayerPrefs.SetInt("SDKVoiceAutoPlayWorld", (!world) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x060197FE RID: 104446 RVA: 0x0080A085 File Offset: 0x00808485
	public void SaveTeamAutoPlayValue(bool team)
	{
		PlayerPrefs.SetInt("SDKVoiceAutoPlayTeam", (!team) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x060197FF RID: 104447 RVA: 0x0080A0A3 File Offset: 0x008084A3
	public void SaveGuildAutoPlayValue(bool guild)
	{
		PlayerPrefs.SetInt("SDKVoiceAutoPlayGuild", (!guild) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x06019800 RID: 104448 RVA: 0x0080A0C1 File Offset: 0x008084C1
	public void SaveNearbyAutoPlayValue(bool nearby)
	{
		PlayerPrefs.SetInt("SDKVoiceAutoPlayNearby", (!nearby) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x06019801 RID: 104449 RVA: 0x0080A0DF File Offset: 0x008084DF
	public void SavePrivateAutoPlayValue(bool _private)
	{
		PlayerPrefs.SetInt("SDKVoiceAutoPlayPrivate", (!_private) ? 0 : 1);
		PlayerPrefs.Save();
	}

	// Token: 0x06019802 RID: 104450 RVA: 0x0080A100 File Offset: 0x00808500
	public void SaveMicPref(bool isOn)
	{
		int num = (!isOn) ? 0 : 1;
		PlayerPrefs.SetInt("SDKVoiceMicON", num);
		PlayerPrefs.Save();
	}

	// Token: 0x06019803 RID: 104451 RVA: 0x0080A12C File Offset: 0x0080852C
	public void SavePlayerPref(bool isOn)
	{
		int num = (!isOn) ? 0 : 1;
		PlayerPrefs.SetInt("SDKVoicePlayerON", num);
		PlayerPrefs.Save();
	}

	// Token: 0x06019804 RID: 104452 RVA: 0x0080A157 File Offset: 0x00808557
	public void SavePlayerVolumnPref(float volumn)
	{
		PlayerPrefs.SetFloat("SDKVoicePlayerVolumn", volumn);
		PlayerPrefs.Save();
	}

	// Token: 0x06019805 RID: 104453 RVA: 0x0080A169 File Offset: 0x00808569
	private bool GetWorldAutoPlayValue()
	{
		return PlayerPrefs.HasKey("SDKVoiceAutoPlayWorld") && PlayerPrefs.GetInt("SDKVoiceAutoPlayWorld") == 1;
	}

	// Token: 0x06019806 RID: 104454 RVA: 0x0080A193 File Offset: 0x00808593
	private bool GetTeamAutoPlayValue()
	{
		return PlayerPrefs.HasKey("SDKVoiceAutoPlayTeam") && PlayerPrefs.GetInt("SDKVoiceAutoPlayTeam") == 1;
	}

	// Token: 0x06019807 RID: 104455 RVA: 0x0080A1BD File Offset: 0x008085BD
	private bool GetGuildAutoPlayValue()
	{
		return PlayerPrefs.HasKey("SDKVoiceAutoPlayGuild") && PlayerPrefs.GetInt("SDKVoiceAutoPlayGuild") == 1;
	}

	// Token: 0x06019808 RID: 104456 RVA: 0x0080A1E7 File Offset: 0x008085E7
	private bool GetNearbyAutoPlayValue()
	{
		return PlayerPrefs.HasKey("SDKVoiceAutoPlayNearby") && PlayerPrefs.GetInt("SDKVoiceAutoPlayNearby") == 1;
	}

	// Token: 0x06019809 RID: 104457 RVA: 0x0080A211 File Offset: 0x00808611
	private bool GetPrivateAutoPlayValue()
	{
		return PlayerPrefs.HasKey("SDKVoiceAutoPlayPrivate") && PlayerPrefs.GetInt("SDKVoiceAutoPlayPrivate") == 1;
	}

	// Token: 0x0601980A RID: 104458 RVA: 0x0080A23B File Offset: 0x0080863B
	private bool GetMicPref()
	{
		return !PlayerPrefs.HasKey("SDKVoiceMicON") || PlayerPrefs.GetInt("SDKVoiceMicON") == 1;
	}

	// Token: 0x0601980B RID: 104459 RVA: 0x0080A265 File Offset: 0x00808665
	private bool GetPlayerPref()
	{
		return !PlayerPrefs.HasKey("SDKVoicePlayerON") || PlayerPrefs.GetInt("SDKVoicePlayerON") == 1;
	}

	// Token: 0x0601980C RID: 104460 RVA: 0x0080A28F File Offset: 0x0080868F
	private float GetPlayerVolumnPref()
	{
		if (PlayerPrefs.HasKey("SDKVoicePlayerVolumn"))
		{
			return PlayerPrefs.GetFloat("SDKVoicePlayerVolumn");
		}
		return this.GetPlayerVolume();
	}

	// Token: 0x0601980D RID: 104461 RVA: 0x0080A2B4 File Offset: 0x008086B4
	private void ReportAutoPlayRole(ChatType chatType)
	{
		switch (chatType)
		{
		case ChatType.CT_WORLD:
			if (this.hasWorldAutoPlayReported)
			{
				return;
			}
			if (!this.IsAutoPlayInWorld)
			{
				return;
			}
			this.SetReportAutoPlayRoleInfo(chatType);
			this.hasWorldAutoPlayReported = true;
			break;
		case ChatType.CT_NORMAL:
			if (this.hasNormalAutoPlayReported)
			{
				return;
			}
			if (!this.IsAutoPlayInNearby)
			{
				return;
			}
			this.SetReportAutoPlayRoleInfo(chatType);
			this.hasNormalAutoPlayReported = true;
			break;
		case ChatType.CT_GUILD:
			if (this.hasGuildAutoPlayReported)
			{
				return;
			}
			if (!this.IsAutoPlayInGuild)
			{
				return;
			}
			this.SetReportAutoPlayRoleInfo(chatType);
			this.hasGuildAutoPlayReported = true;
			break;
		case ChatType.CT_TEAM:
			if (this.hasTeamAutoPlayReported)
			{
				return;
			}
			if (!this.IsAutoPlayInTeam)
			{
				return;
			}
			this.SetReportAutoPlayRoleInfo(chatType);
			this.hasTeamAutoPlayReported = true;
			break;
		case ChatType.CT_PRIVATE:
			if (this.hasPrivateAutoPlayReported)
			{
				return;
			}
			if (!this.IsAutoPlayInPrivate)
			{
				return;
			}
			this.SetReportAutoPlayRoleInfo(chatType);
			this.hasPrivateAutoPlayReported = true;
			break;
		}
	}

	// Token: 0x0601980E RID: 104462 RVA: 0x0080A3C0 File Offset: 0x008087C0
	private void SetReportAutoPlayRoleInfo(ChatType chatType)
	{
		string param = string.Format("openAutoPlay|chatType,{0}|", chatType.ToString());
		Singleton<GameStatisticManager>.GetInstance().DoYouMiVoiceIM(YouMiVoiceSDKCostType.VOICE_SDK_OPEN_AUTOPLAY, param);
	}

	// Token: 0x0601980F RID: 104463 RVA: 0x0080A3F4 File Offset: 0x008087F4
	private void InitReportAutoPlayRoleInfo()
	{
		ChatType[] array = new ChatType[]
		{
			ChatType.CT_WORLD,
			ChatType.CT_GUILD,
			ChatType.CT_TEAM,
			ChatType.CT_NORMAL,
			ChatType.CT_PRIVATE
		};
	}

	// Token: 0x06019810 RID: 104464 RVA: 0x0080A414 File Offset: 0x00808814
	public void ReportUsingVoice(CustomLogReportType voiceType, string param = "")
	{
		SceneCustomLogReport sceneCustomLogReport = new SceneCustomLogReport();
		sceneCustomLogReport.type = (byte)voiceType;
		sceneCustomLogReport.param = param;
		NetManager.Instance().SendCommand<SceneCustomLogReport>(ServerType.GATE_SERVER, sceneCustomLogReport);
	}

	// Token: 0x0401233E RID: 74558
	public const string VOICE_MIC_SETTING_KEY = "SDKVoiceMicON";

	// Token: 0x0401233F RID: 74559
	public const string VOICE_PLAYER_SETTING_KEY = "SDKVoicePlayerON";

	// Token: 0x04012340 RID: 74560
	public const string VOICE_AUTO_PLAY_WORLD = "SDKVoiceAutoPlayWorld";

	// Token: 0x04012341 RID: 74561
	public const string VOICE_AUTO_PLAY_TEAM = "SDKVoiceAutoPlayTeam";

	// Token: 0x04012342 RID: 74562
	public const string VOICE_AUTO_PLAY_GUILD = "SDKVoiceAutoPlayGuild";

	// Token: 0x04012343 RID: 74563
	public const string VOICE_AUTO_PLAY_NEARBY = "SDKVoiceAutoPlayNearby";

	// Token: 0x04012344 RID: 74564
	public const string VOICE_AUTO_PLAY_PRIVATE = "SDKVoiceAutoPlayPrivate";

	// Token: 0x04012345 RID: 74565
	public const string VOICE_PLAYER_VOLUMN = "SDKVoicePlayerVolumn";

	// Token: 0x04012346 RID: 74566
	private SDKVoiceInterface sdkInterface = new YouMiVoiceInterface();

	// Token: 0x04012347 RID: 74567
	public static bool isInit;

	// Token: 0x0401234A RID: 74570
	private VoiceChatModule _voiceChatModule;

	// Token: 0x0401234B RID: 74571
	protected ChatType gameChatType;

	// Token: 0x0401234C RID: 74572
	private bool hasWorldAutoPlayReported;

	// Token: 0x0401234D RID: 74573
	private bool hasTeamAutoPlayReported;

	// Token: 0x0401234E RID: 74574
	private bool hasGuildAutoPlayReported;

	// Token: 0x0401234F RID: 74575
	private bool hasNormalAutoPlayReported;

	// Token: 0x04012350 RID: 74576
	private bool hasPrivateAutoPlayReported;

	// Token: 0x04012351 RID: 74577
	private string currSelectPlayerVoiceId;

	// Token: 0x04012352 RID: 74578
	private string _localPlayerVoiceId;

	// Token: 0x04012353 RID: 74579
	public string worldChannelId;

	// Token: 0x04012354 RID: 74580
	public string sceneChannelId;

	// Token: 0x04012355 RID: 74581
	public string dungeonChannelId;

	// Token: 0x04012356 RID: 74582
	public string guildChannelId;

	// Token: 0x04012357 RID: 74583
	public string teamChannelId;

	// Token: 0x04012358 RID: 74584
	public List<string> privateChannelIdList = new List<string>();
}
