using System;
using System.Collections.Generic;

namespace YIMEngine
{
	// Token: 0x02004A8F RID: 19087
	public interface ContactListen
	{
		// Token: 0x0601BB16 RID: 113430
		void OnGetContact(List<ContactsSessionInfo> contactLists);

		// Token: 0x0601BB17 RID: 113431
		void OnGetUserInfo(ErrorCode code, string userID, IMUserInfo userInfo);

		// Token: 0x0601BB18 RID: 113432
		void OnQueryUserStatus(ErrorCode code, string userID, UserStatus status);
	}
}
