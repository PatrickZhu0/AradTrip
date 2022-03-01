using System;

namespace YIMEngine
{
	// Token: 0x02004A8E RID: 19086
	public interface ChatRoomListen
	{
		// Token: 0x0601BB10 RID: 113424
		void OnJoinRoom(ErrorCode errorcode, string strChatRoomID);

		// Token: 0x0601BB11 RID: 113425
		void OnLeaveRoom(ErrorCode errorcode, string strChatRoomID);

		// Token: 0x0601BB12 RID: 113426
		void OnLeaveAllRooms(ErrorCode errorcode);

		// Token: 0x0601BB13 RID: 113427
		void OnUserJoinChatRoom(string strRoomID, string strUserID);

		// Token: 0x0601BB14 RID: 113428
		void OnUserLeaveChatRoom(string strRoomID, string strUserID);

		// Token: 0x0601BB15 RID: 113429
		void OnGetRoomMemberCount(ErrorCode errorcode, string strRoomID, uint count);
	}
}
