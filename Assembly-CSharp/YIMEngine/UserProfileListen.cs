using System;

namespace YIMEngine
{
	// Token: 0x02004A97 RID: 19095
	public interface UserProfileListen
	{
		// Token: 0x0601BB3F RID: 113471
		void OnQueryUserInfo(ErrorCode errorcode, IMUserProfileInfo userInfo);

		// Token: 0x0601BB40 RID: 113472
		void OnSetUserInfo(ErrorCode errorcode);

		// Token: 0x0601BB41 RID: 113473
		void OnSwitchUserOnlineState(ErrorCode errorcode);

		// Token: 0x0601BB42 RID: 113474
		void OnSetPhotoUrl(ErrorCode errorcode, string photoUrl);

		// Token: 0x0601BB43 RID: 113475
		void OnUserInfoChangeNotify(string userID);
	}
}
