using System;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A91 RID: 19089
	public interface FriendListen
	{
		// Token: 0x0601BB1B RID: 113435
		void OnFindUser(ErrorCode errorcode, List<UserBriefInfo> users);

		// Token: 0x0601BB1C RID: 113436
		void OnRequestAddFriend(ErrorCode errorcode, string userID);

		// Token: 0x0601BB1D RID: 113437
		void OnBeRequestAddFriendNotify(string userID, string comments);

		// Token: 0x0601BB1E RID: 113438
		void OnBeAddFriendNotify(string userID, string comments);

		// Token: 0x0601BB1F RID: 113439
		void OnDealBeRequestAddFriend(ErrorCode errorcode, string userID, string comments, int dealResult);

		// Token: 0x0601BB20 RID: 113440
		void OnRequestAddFriendResultNotify(string userID, string comments, int dealResult);

		// Token: 0x0601BB21 RID: 113441
		void OnDeleteFriend(ErrorCode errorcode, string userID);

		// Token: 0x0601BB22 RID: 113442
		void OnBeDeleteFriendNotify(string userID);

		// Token: 0x0601BB23 RID: 113443
		void OnBlackFriend(ErrorCode errorcode, int type, string userID);

		// Token: 0x0601BB24 RID: 113444
		void OnQueryFriends(ErrorCode errorcode, int type, int startIndex, List<UserBriefInfo> friends);

		// Token: 0x0601BB25 RID: 113445
		void OnQueryFriendRequestList(ErrorCode errorcode, int startIndex, List<FriendRequestInfo> requestList);
	}
}
