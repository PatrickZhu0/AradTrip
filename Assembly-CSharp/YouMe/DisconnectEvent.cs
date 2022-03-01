using System;

namespace YouMe
{
	// Token: 0x02004AB3 RID: 19123
	public class DisconnectEvent : ConnectEvent
	{
		// Token: 0x0601BC1A RID: 113690 RVA: 0x0088314A File Offset: 0x0088154A
		public DisconnectEvent(StatusCode code, string userID) : base(code, userID)
		{
		}
	}
}
