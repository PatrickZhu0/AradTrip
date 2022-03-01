using System;

namespace GameClient
{
	// Token: 0x02001689 RID: 5769
	public interface IHorseGamblingMapShooterModel
	{
		// Token: 0x17001C60 RID: 7264
		// (get) Token: 0x0600E2B8 RID: 58040
		int Id { get; }

		// Token: 0x17001C61 RID: 7265
		// (get) Token: 0x0600E2B9 RID: 58041
		string Name { get; }

		// Token: 0x17001C62 RID: 7266
		// (get) Token: 0x0600E2BA RID: 58042
		bool IsShowOdds { get; }

		// Token: 0x17001C63 RID: 7267
		// (get) Token: 0x0600E2BB RID: 58043
		EHorseGamblingBattleResult BattleState { get; }
	}
}
