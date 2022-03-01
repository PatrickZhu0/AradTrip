using System;

namespace YouMe
{
	// Token: 0x02004AAF RID: 19119
	public class ConnectEvent
	{
		// Token: 0x0601BC14 RID: 113684 RVA: 0x00883106 File Offset: 0x00881506
		public ConnectEvent(StatusCode code, string userID)
		{
			this._code = code;
			this._userID = userID;
		}

		// Token: 0x17002568 RID: 9576
		// (get) Token: 0x0601BC15 RID: 113685 RVA: 0x0088311C File Offset: 0x0088151C
		public string UserID
		{
			get
			{
				return this._userID;
			}
		}

		// Token: 0x17002569 RID: 9577
		// (get) Token: 0x0601BC16 RID: 113686 RVA: 0x00883124 File Offset: 0x00881524
		public StatusCode Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x0401359B RID: 79259
		private StatusCode _code;

		// Token: 0x0401359C RID: 79260
		private string _userID;
	}
}
