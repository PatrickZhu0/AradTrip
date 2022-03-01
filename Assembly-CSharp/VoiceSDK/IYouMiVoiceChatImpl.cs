using System;
using GameClient;

namespace VoiceSDK
{
	// Token: 0x02004669 RID: 18025
	public interface IYouMiVoiceChatImpl
	{
		// Token: 0x06019693 RID: 104083
		void JoinChatRoom(string roomId, bool beSaveRoomMsg = false);

		// Token: 0x06019694 RID: 104084
		void LeaveChatRoom(string roomId);

		// Token: 0x06019695 RID: 104085
		void SendVoiceMessage(string receId, ChatType chatType, ref ulong iReqId, bool isTranslate);

		// Token: 0x06019696 RID: 104086
		void StopAudioMessage(string extra);
	}
}
