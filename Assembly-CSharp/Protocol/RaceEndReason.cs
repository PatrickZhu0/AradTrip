using System;

namespace Protocol
{
	// Token: 0x02000A8B RID: 2699
	public enum RaceEndReason
	{
		// Token: 0x04003702 RID: 14082
		Normal,
		// Token: 0x04003703 RID: 14083
		Timeout,
		// Token: 0x04003704 RID: 14084
		LoginTimeout,
		// Token: 0x04003705 RID: 14085
		Errro,
		// Token: 0x04003706 RID: 14086
		System,
		// Token: 0x04003707 RID: 14087
		WaitRaceEndTimeout,
		// Token: 0x04003708 RID: 14088
		GamerOffline,
		// Token: 0x04003709 RID: 14089
		FrameChecksumTimeout,
		// Token: 0x0400370A RID: 14090
		FrameChecksumDifferent
	}
}
