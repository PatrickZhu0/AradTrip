using System;

namespace YouMe
{
	// Token: 0x02004AC0 RID: 19136
	public class IMUser : IUser
	{
		// Token: 0x0601BC69 RID: 113769 RVA: 0x00883784 File Offset: 0x00881B84
		public IMUser(string userID)
		{
			this.userID = userID;
		}

		// Token: 0x17002593 RID: 9619
		// (get) Token: 0x0601BC6A RID: 113770 RVA: 0x00883793 File Offset: 0x00881B93
		public string UserID
		{
			get
			{
				return this.userID;
			}
		}

		// Token: 0x040135CF RID: 79311
		private string userID;
	}
}
