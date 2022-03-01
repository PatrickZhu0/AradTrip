using System;

namespace GameClient
{
	// Token: 0x02001957 RID: 6487
	public class PayPrivilegeFrameData
	{
		// Token: 0x17001D0F RID: 7439
		// (get) Token: 0x0600FC36 RID: 64566 RVA: 0x00454661 File Offset: 0x00452A61
		// (set) Token: 0x0600FC37 RID: 64567 RVA: 0x00454669 File Offset: 0x00452A69
		public int CurShowVipLevel
		{
			get
			{
				return this.mCurShowVipLevel;
			}
			set
			{
				this.mCurShowVipLevel = value;
			}
		}

		// Token: 0x17001D10 RID: 7440
		// (get) Token: 0x0600FC38 RID: 64568 RVA: 0x00454672 File Offset: 0x00452A72
		// (set) Token: 0x0600FC39 RID: 64569 RVA: 0x0045467A File Offset: 0x00452A7A
		public int PrivilegeNum
		{
			get
			{
				return this.mPrivilegeNum;
			}
			set
			{
				this.mPrivilegeNum = value;
			}
		}

		// Token: 0x17001D11 RID: 7441
		// (get) Token: 0x0600FC3A RID: 64570 RVA: 0x00454683 File Offset: 0x00452A83
		// (set) Token: 0x0600FC3B RID: 64571 RVA: 0x0045468B File Offset: 0x00452A8B
		public int MaxVipLevel
		{
			get
			{
				return this.mMaxVipLevel;
			}
			set
			{
				this.mMaxVipLevel = value;
			}
		}

		// Token: 0x0600FC3C RID: 64572 RVA: 0x00454694 File Offset: 0x00452A94
		public void ClearData()
		{
		}

		// Token: 0x04009DEE RID: 40430
		private int mCurShowVipLevel;

		// Token: 0x04009DEF RID: 40431
		private int mPrivilegeNum;

		// Token: 0x04009DF0 RID: 40432
		private int mMaxVipLevel;
	}
}
