using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001323 RID: 4899
	public class TeamDuplicationFightPointDataModel
	{
		// Token: 0x04006B8C RID: 27532
		public int FightPointId;

		// Token: 0x04006B8D RID: 27533
		public TeamCopyFieldStatus FightPointStatusType;

		// Token: 0x04006B8E RID: 27534
		public List<uint> FightPointTeamList;

		// Token: 0x04006B8F RID: 27535
		public int FightPointLeftFightNumber;

		// Token: 0x04006B90 RID: 27536
		public int FightPointRebornTime;

		// Token: 0x04006B91 RID: 27537
		public int FightPointEnergyAccumulationStartTime;

		// Token: 0x04006B92 RID: 27538
		public int FightPointPosition;

		// Token: 0x04006B93 RID: 27539
		public int FightPointTotalFightNumber;
	}
}
