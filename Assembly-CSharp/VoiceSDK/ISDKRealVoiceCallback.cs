using System;
using System.Collections.Generic;
using YouMe;

namespace VoiceSDK
{
	// Token: 0x02004667 RID: 18023
	public interface ISDKRealVoiceCallback
	{
		// Token: 0x0601965A RID: 104026
		void OnTalkVoiceInit(bool isInited, YouMeErrorCode errorCode);

		// Token: 0x0601965B RID: 104027
		void OnTalkVoiceJoinChannel(bool isSuccess, string channelId, YouMeErrorCode errorCode);

		// Token: 0x0601965C RID: 104028
		void OnTalkVoiceLeaveChannel(bool isSuccess, string channelId, YouMeErrorCode errorCode);

		// Token: 0x0601965D RID: 104029
		void OnTalkVoiceLeaveAllChannels(bool isSuccess, YouMeErrorCode errorCode);

		// Token: 0x0601965E RID: 104030
		void OnTalkVoiceMicOn(bool isOn, YouMeErrorCode errorCode);

		// Token: 0x0601965F RID: 104031
		void OnTalkVoicePlayerOn(bool isOn, YouMeErrorCode errorCode);

		// Token: 0x06019660 RID: 104032
		void OnTalkVoiceChannelPause(bool isPaused, YouMeErrorCode errorCode);

		// Token: 0x06019661 RID: 104033
		void OnChannelMemberChange(IList<TalkChannelMemberInfo> talkChannelMembers);

		// Token: 0x06019662 RID: 104034
		void OnTalkVoiceMicChangeByOther(bool isOn, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x06019663 RID: 104035
		void OnSetSpeakChannel(bool success, string channelId, YouMeErrorCode erroCode);

		// Token: 0x06019664 RID: 104036
		void OnOtherSpeakInChannel(bool isSpeak, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x06019665 RID: 104037
		void OnOtherControlMic(bool isOn, string voicePlayerId, YouMeErrorCode errorCode);

		// Token: 0x06019666 RID: 104038
		void OnVoiceTalkMicAuth(YouMeErrorCode errorCode);

		// Token: 0x06019667 RID: 104039
		void OnBroadcastMsg(string channelId, string content, YouMeErrorCode errorCode);
	}
}
