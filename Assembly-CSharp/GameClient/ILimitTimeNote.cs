using System;

namespace GameClient
{
	// Token: 0x020018D0 RID: 6352
	public interface ILimitTimeNote
	{
		// Token: 0x17001CFF RID: 7423
		// (get) Token: 0x0600F80C RID: 63500
		string NotePrefabPath { get; }

		// Token: 0x17001D00 RID: 7424
		// (get) Token: 0x0600F80D RID: 63501
		uint StartTime { get; }

		// Token: 0x17001D01 RID: 7425
		// (get) Token: 0x0600F80E RID: 63502
		string RuleDesc { get; }

		// Token: 0x17001D02 RID: 7426
		// (get) Token: 0x0600F80F RID: 63503
		string LogoDesc { get; }

		// Token: 0x17001D03 RID: 7427
		// (get) Token: 0x0600F810 RID: 63504
		uint EndTime { get; }

		// Token: 0x17001D04 RID: 7428
		// (get) Token: 0x0600F811 RID: 63505
		string LogoPath { get; }

		// Token: 0x17001D05 RID: 7429
		// (get) Token: 0x0600F812 RID: 63506
		string NoteBgPath { get; }
	}
}
