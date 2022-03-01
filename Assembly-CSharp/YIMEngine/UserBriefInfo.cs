using System;

namespace YIMEngine
{
	// Token: 0x02004A6D RID: 19053
	public class UserBriefInfo
	{
		// Token: 0x170024D2 RID: 9426
		// (get) Token: 0x0601B96A RID: 113002 RVA: 0x0087B80C File Offset: 0x00879C0C
		// (set) Token: 0x0601B96B RID: 113003 RVA: 0x0087B814 File Offset: 0x00879C14
		public string UserID
		{
			get
			{
				return this.userID;
			}
			set
			{
				this.userID = value;
			}
		}

		// Token: 0x170024D3 RID: 9427
		// (get) Token: 0x0601B96C RID: 113004 RVA: 0x0087B81D File Offset: 0x00879C1D
		// (set) Token: 0x0601B96D RID: 113005 RVA: 0x0087B825 File Offset: 0x00879C25
		public string Nickname
		{
			get
			{
				return this.nickname;
			}
			set
			{
				this.nickname = value;
			}
		}

		// Token: 0x170024D4 RID: 9428
		// (get) Token: 0x0601B96E RID: 113006 RVA: 0x0087B82E File Offset: 0x00879C2E
		// (set) Token: 0x0601B96F RID: 113007 RVA: 0x0087B836 File Offset: 0x00879C36
		public UserStatus Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}

		// Token: 0x040133E5 RID: 78821
		private string userID;

		// Token: 0x040133E6 RID: 78822
		private string nickname;

		// Token: 0x040133E7 RID: 78823
		private UserStatus status;
	}
}
