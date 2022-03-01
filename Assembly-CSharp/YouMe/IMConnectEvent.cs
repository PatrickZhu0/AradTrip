using System;

namespace YouMe
{
	// Token: 0x02004AAE RID: 19118
	public class IMConnectEvent
	{
		// Token: 0x0601BC10 RID: 113680 RVA: 0x008830D1 File Offset: 0x008814D1
		public IMConnectEvent(StatusCode code, ConnectEventType type, string userID)
		{
			this._code = code;
			this._type = type;
			this._userID = userID;
		}

		// Token: 0x17002565 RID: 9573
		// (get) Token: 0x0601BC11 RID: 113681 RVA: 0x008830EE File Offset: 0x008814EE
		public StatusCode Code
		{
			get
			{
				return this._code;
			}
		}

		// Token: 0x17002566 RID: 9574
		// (get) Token: 0x0601BC12 RID: 113682 RVA: 0x008830F6 File Offset: 0x008814F6
		public ConnectEventType EventType
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x17002567 RID: 9575
		// (get) Token: 0x0601BC13 RID: 113683 RVA: 0x008830FE File Offset: 0x008814FE
		public string UserID
		{
			get
			{
				return this._userID;
			}
		}

		// Token: 0x04013598 RID: 79256
		private StatusCode _code;

		// Token: 0x04013599 RID: 79257
		private ConnectEventType _type;

		// Token: 0x0401359A RID: 79258
		private string _userID;
	}
}
