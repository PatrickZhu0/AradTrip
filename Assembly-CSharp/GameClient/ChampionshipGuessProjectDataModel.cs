using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001211 RID: 4625
	public class ChampionshipGuessProjectDataModel
	{
		// Token: 0x040063C0 RID: 25536
		public uint ProjectId;

		// Token: 0x040063C1 RID: 25537
		public GambleType ProjectType;

		// Token: 0x040063C2 RID: 25538
		public ulong ProjectParam;

		// Token: 0x040063C3 RID: 25539
		public int FightRaceId;

		// Token: 0x040063C4 RID: 25540
		public int ScheduleId;

		// Token: 0x040063C5 RID: 25541
		public uint StartTime;

		// Token: 0x040063C6 RID: 25542
		public uint EndTime;

		// Token: 0x040063C7 RID: 25543
		public Dictionary<ulong, ChampionshipGuessOptionDataModel> GuessOptionDataModelDictionary = new Dictionary<ulong, ChampionshipGuessOptionDataModel>();

		// Token: 0x040063C8 RID: 25544
		public List<ulong> GuessOptionIdList = new List<ulong>();
	}
}
