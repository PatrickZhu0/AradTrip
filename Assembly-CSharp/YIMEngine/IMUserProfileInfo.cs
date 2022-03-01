using System;

namespace YIMEngine
{
	// Token: 0x02004A74 RID: 19060
	public class IMUserProfileInfo : IMUserSettingInfo
	{
		// Token: 0x170024E3 RID: 9443
		// (get) Token: 0x0601B98F RID: 113039 RVA: 0x0087B99B File Offset: 0x00879D9B
		// (set) Token: 0x0601B990 RID: 113040 RVA: 0x0087B9A3 File Offset: 0x00879DA3
		public string UserID
		{
			get
			{
				return this.strUserID;
			}
			set
			{
				this.strUserID = value;
			}
		}

		// Token: 0x170024E4 RID: 9444
		// (get) Token: 0x0601B991 RID: 113041 RVA: 0x0087B9AC File Offset: 0x00879DAC
		// (set) Token: 0x0601B992 RID: 113042 RVA: 0x0087B9B4 File Offset: 0x00879DB4
		public string PhotoURL
		{
			get
			{
				return this.strPhotoURL;
			}
			set
			{
				this.strPhotoURL = value;
			}
		}

		// Token: 0x170024E5 RID: 9445
		// (get) Token: 0x0601B993 RID: 113043 RVA: 0x0087B9BD File Offset: 0x00879DBD
		// (set) Token: 0x0601B994 RID: 113044 RVA: 0x0087B9C5 File Offset: 0x00879DC5
		public UserStatus OnlineState
		{
			get
			{
				return this.iOnlineState;
			}
			set
			{
				this.iOnlineState = value;
			}
		}

		// Token: 0x170024E6 RID: 9446
		// (get) Token: 0x0601B995 RID: 113045 RVA: 0x0087B9CE File Offset: 0x00879DCE
		// (set) Token: 0x0601B996 RID: 113046 RVA: 0x0087B9D6 File Offset: 0x00879DD6
		public IMUserBeAddPermission BeAddPermission
		{
			get
			{
				return this.iBeAddPermission;
			}
			set
			{
				this.iBeAddPermission = value;
			}
		}

		// Token: 0x170024E7 RID: 9447
		// (get) Token: 0x0601B997 RID: 113047 RVA: 0x0087B9DF File Offset: 0x00879DDF
		// (set) Token: 0x0601B998 RID: 113048 RVA: 0x0087B9E7 File Offset: 0x00879DE7
		public IMUserFoundPermission FoundPermission
		{
			get
			{
				return this.iFoundPermission;
			}
			set
			{
				this.iFoundPermission = value;
			}
		}

		// Token: 0x04013406 RID: 78854
		private string strUserID;

		// Token: 0x04013407 RID: 78855
		private string strPhotoURL;

		// Token: 0x04013408 RID: 78856
		private UserStatus iOnlineState;

		// Token: 0x04013409 RID: 78857
		private IMUserBeAddPermission iBeAddPermission;

		// Token: 0x0401340A RID: 78858
		private IMUserFoundPermission iFoundPermission;
	}
}
