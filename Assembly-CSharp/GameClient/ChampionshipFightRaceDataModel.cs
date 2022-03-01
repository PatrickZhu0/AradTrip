using System;

namespace GameClient
{
	// Token: 0x0200120B RID: 4619
	public class ChampionshipFightRaceDataModel
	{
		// Token: 0x040063A6 RID: 25510
		public int FightGroupId;

		// Token: 0x040063A7 RID: 25511
		public ulong FirstPlayerGuid;

		// Token: 0x040063A8 RID: 25512
		public ulong SecondPlayerGuid;

		// Token: 0x040063A9 RID: 25513
		public uint FirstPlayerScore;

		// Token: 0x040063AA RID: 25514
		public uint SecondPlayerScore;

		// Token: 0x040063AB RID: 25515
		public ChampionshipFightStatus FightStatus;

		// Token: 0x040063AC RID: 25516
		public int StartTime;
	}
}
