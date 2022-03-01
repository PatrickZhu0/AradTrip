using System;

namespace MobileBind
{
	// Token: 0x020017D8 RID: 6104
	public enum MobileBindReturnCode
	{
		// Token: 0x04009399 RID: 37785
		None = -1,
		// Token: 0x0400939A RID: 37786
		Success,
		// Token: 0x0400939B RID: 37787
		DBError,
		// Token: 0x0400939C RID: 37788
		CD,
		// Token: 0x0400939D RID: 37789
		InvalidAccount,
		// Token: 0x0400939E RID: 37790
		RepeatBind,
		// Token: 0x0400939F RID: 37791
		InvalidVerifyCode,
		// Token: 0x040093A0 RID: 37792
		InvalidServerId,
		// Token: 0x040093A1 RID: 37793
		NoVerifyCode,
		// Token: 0x040093A2 RID: 37794
		ServerError,
		// Token: 0x040093A3 RID: 37795
		PlayerOffine,
		// Token: 0x040093A4 RID: 37796
		InvalidPhoneNum,
		// Token: 0x040093A5 RID: 37797
		Count
	}
}
