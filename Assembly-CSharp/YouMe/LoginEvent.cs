using System;

namespace YouMe
{
	// Token: 0x02004AB0 RID: 19120
	public class LoginEvent : ConnectEvent
	{
		// Token: 0x0601BC17 RID: 113687 RVA: 0x0088312C File Offset: 0x0088152C
		public LoginEvent(StatusCode code, string userID) : base(code, userID)
		{
		}
	}
}
