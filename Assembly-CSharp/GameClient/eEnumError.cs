using System;

namespace GameClient
{
	// Token: 0x02000E30 RID: 3632
	public enum eEnumError
	{
		// Token: 0x04004867 RID: 18535
		UnkownError,
		// Token: 0x04004868 RID: 18536
		NetworkErrorSlowResponse,
		// Token: 0x04004869 RID: 18537
		NetworkErrorDisconnect,
		// Token: 0x0400486A RID: 18538
		ProcessError,
		// Token: 0x0400486B RID: 18539
		ReconnectPlayerOnline,
		// Token: 0x0400486C RID: 18540
		ReconnectPlayerOffline,
		// Token: 0x0400486D RID: 18541
		ReconnectPlayerInvalidSequence,
		// Token: 0x0400486E RID: 18542
		ReconnectOtherError,
		// Token: 0x0400486F RID: 18543
		UserCancelReconnect2Login,
		// Token: 0x04004870 RID: 18544
		ReloginFail,
		// Token: 0x04004871 RID: 18545
		ResumeTimeOut
	}
}
