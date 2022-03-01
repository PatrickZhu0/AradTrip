using System;

namespace GameClient
{
	// Token: 0x02001213 RID: 4627
	public class ChampionshipGuessRecordDataModel
	{
		// Token: 0x040063CC RID: 25548
		public uint ProjectId;

		// Token: 0x040063CD RID: 25549
		public ulong ProjectOptionId;

		// Token: 0x040063CE RID: 25550
		public ChampionshipGuessResultType GuessResultType;

		// Token: 0x040063CF RID: 25551
		public ulong GuessResult;

		// Token: 0x040063D0 RID: 25552
		public ulong GuessReward;

		// Token: 0x040063D1 RID: 25553
		public uint BetTime;

		// Token: 0x040063D2 RID: 25554
		public ulong BetNumber;

		// Token: 0x040063D3 RID: 25555
		public bool IsAlreadyUpdate;

		// Token: 0x040063D4 RID: 25556
		public string GuessRecordTitleStr;

		// Token: 0x040063D5 RID: 25557
		public string GuessRecordContentStr;

		// Token: 0x040063D6 RID: 25558
		public string GuessRecordResultStr;
	}
}
