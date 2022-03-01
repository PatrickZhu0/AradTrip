using System;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A94 RID: 19092
	public interface MessageListen
	{
		// Token: 0x0601BB2C RID: 113452
		void OnSendMessageStatus(ulong iRequestID, ErrorCode errorcode, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime);

		// Token: 0x0601BB2D RID: 113453
		void OnRecvMessage(MessageInfoBase message);

		// Token: 0x0601BB2E RID: 113454
		void OnStartSendAudioMessage(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration);

		// Token: 0x0601BB2F RID: 113455
		void OnSendAudioMessageStatus(ulong iRequestID, ErrorCode errorcode, string strText, string strAudioPath, int iDuration, uint sendTime, bool isForbidRoom, int reasonType, ulong forbidEndTime);

		// Token: 0x0601BB30 RID: 113456
		void OnQueryHistoryMessage(ErrorCode errorcode, string targetID, int remain, List<HistoryMsg> messageList);

		// Token: 0x0601BB31 RID: 113457
		void OnQueryRoomHistoryMessageFromServer(ErrorCode errorcode, string roomID, int remain, List<MessageInfoBase> messageList);

		// Token: 0x0601BB32 RID: 113458
		void OnStopAudioSpeechStatus(ErrorCode errorcode, ulong iRequestID, string strDownloadURL, int iDuration, int iFileSize, string strLocalPath, string strText);

		// Token: 0x0601BB33 RID: 113459
		void OnRecvNewMessage(ChatType chatType, string targetID);

		// Token: 0x0601BB34 RID: 113460
		void OnAccusationResultNotify(AccusationDealResult result, string userID, uint accusationTime);

		// Token: 0x0601BB35 RID: 113461
		void OnGetForbiddenSpeakInfo(ErrorCode errorcode, List<ForbiddenSpeakInfo> forbiddenSpeakList);

		// Token: 0x0601BB36 RID: 113462
		void OnGetRecognizeSpeechText(ulong iRequestID, ErrorCode errorcode, string text);

		// Token: 0x0601BB37 RID: 113463
		void OnBlockUser(ErrorCode errorcode, string userID, bool block);

		// Token: 0x0601BB38 RID: 113464
		void OnUnBlockAllUser(ErrorCode errorcode);

		// Token: 0x0601BB39 RID: 113465
		void OnGetBlockUsers(ErrorCode errorcode, List<string> userList);

		// Token: 0x0601BB3A RID: 113466
		void OnRecordVolumeChange(float volume);
	}
}
