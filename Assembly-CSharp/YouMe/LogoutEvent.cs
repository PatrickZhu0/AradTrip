using System;

namespace YouMe
{
	// Token: 0x02004AB1 RID: 19121
	public class LogoutEvent : ConnectEvent
	{
		// Token: 0x0601BC18 RID: 113688 RVA: 0x00883136 File Offset: 0x00881536
		public LogoutEvent(StatusCode code, string userID) : base(code, userID)
		{
		}
	}
}
