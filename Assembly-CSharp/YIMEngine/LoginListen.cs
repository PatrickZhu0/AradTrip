using System;

namespace YIMEngine
{
	// Token: 0x02004A93 RID: 19091
	public interface LoginListen
	{
		// Token: 0x0601BB29 RID: 113449
		void OnLogin(ErrorCode errorcode, string strYouMeID);

		// Token: 0x0601BB2A RID: 113450
		void OnLogout();

		// Token: 0x0601BB2B RID: 113451
		void OnKickOff();
	}
}
