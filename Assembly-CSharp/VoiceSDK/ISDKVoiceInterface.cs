using System;
using System.Collections.Generic;

namespace VoiceSDK
{
	// Token: 0x02004668 RID: 18024
	public interface ISDKVoiceInterface
	{
		// Token: 0x06019668 RID: 104040
		void InitChatVoice();

		// Token: 0x06019669 RID: 104041
		void UnInitChatVoice();

		// Token: 0x0601966A RID: 104042
		void LoginVoice(string roleId, string openId, string token);

		// Token: 0x0601966B RID: 104043
		void LogoutVoice();

		// Token: 0x0601966C RID: 104044
		bool StartRecordVoice();

		// Token: 0x0601966D RID: 104045
		bool StopRecordVoice();

		// Token: 0x0601966E RID: 104046
		void CancelRecordVoice();

		// Token: 0x0601966F RID: 104047
		void AddVoicePathInQueue(string voiceKey);

		// Token: 0x06019670 RID: 104048
		void ClearVoicePathQueue();

		// Token: 0x06019671 RID: 104049
		void StopPlayVoice();

		// Token: 0x06019672 RID: 104050
		void SetVoiceVolume(float volume);

		// Token: 0x06019673 RID: 104051
		float GetVoiceVolume();

		// Token: 0x06019674 RID: 104052
		void ClearLocalCache();

		// Token: 0x06019675 RID: 104053
		void OnPause();

		// Token: 0x06019676 RID: 104054
		void OnResume();

		// Token: 0x06019677 RID: 104055
		bool IsVoiceRecording();

		// Token: 0x06019678 RID: 104056
		bool IsVoicePlaying();

		// Token: 0x06019679 RID: 104057
		void InitTalkVoice();

		// Token: 0x0601967A RID: 104058
		void UnInitTalkVoice();

		// Token: 0x0601967B RID: 104059
		void JoinChannel(string channelId);

		// Token: 0x0601967C RID: 104060
		void LeaveAllChannel();

		// Token: 0x0601967D RID: 104061
		void LeaveChannel(string channelId);

		// Token: 0x0601967E RID: 104062
		void UpdateTalkChannel(IList<string> channelIds);

		// Token: 0x0601967F RID: 104063
		string CurrentTalkChannelId();

		// Token: 0x06019680 RID: 104064
		bool IsJoinedTalkChannel(string channelId);

		// Token: 0x06019681 RID: 104065
		bool HasJoinedTalkChannel();

		// Token: 0x06019682 RID: 104066
		void SetCurrentTalkChannelId(string channelId);

		// Token: 0x06019683 RID: 104067
		string GetOtherTalkChannelId(string voicePlayerId);

		// Token: 0x06019684 RID: 104068
		bool IsMicEnable();

		// Token: 0x06019685 RID: 104069
		void SetMicEnable(string voicePlayerId, bool bEnable);

		// Token: 0x06019686 RID: 104070
		bool IsGlobalSilence();

		// Token: 0x06019687 RID: 104071
		void SetGlobalSilenceInMainChannel(string mainChannelId, bool isNotSpeak);

		// Token: 0x06019688 RID: 104072
		void OpenRealMic();

		// Token: 0x06019689 RID: 104073
		void CloseRealMic();

		// Token: 0x0601968A RID: 104074
		void OpenRealPlayer();

		// Token: 0x0601968B RID: 104075
		void CloseReaPlayer();

		// Token: 0x0601968C RID: 104076
		bool IsTalkRealMicOn();

		// Token: 0x0601968D RID: 104077
		bool IsTalkRealPlayerOn();

		// Token: 0x0601968E RID: 104078
		void SetPlayerVolume(float volume);

		// Token: 0x0601968F RID: 104079
		float GetPlayerVolume();

		// Token: 0x06019690 RID: 104080
		void PauseChannel();

		// Token: 0x06019691 RID: 104081
		void ResumeChannel();

		// Token: 0x06019692 RID: 104082
		string ShowDebugLog();
	}
}
