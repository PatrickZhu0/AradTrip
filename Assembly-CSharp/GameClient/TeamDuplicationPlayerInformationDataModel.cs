using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001314 RID: 4884
	public class TeamDuplicationPlayerInformationDataModel
	{
		// Token: 0x04006B1D RID: 27421
		public int DayAlreadyFightNumber;

		// Token: 0x04006B1E RID: 27422
		public int WeekAlreadyFightNumber;

		// Token: 0x04006B1F RID: 27423
		public bool IsCanCreateGold;

		// Token: 0x04006B20 RID: 27424
		public int DayFreeQuitNumber;

		// Token: 0x04006B21 RID: 27425
		public int WeekFreeQuitNumber;

		// Token: 0x04006B22 RID: 27426
		public int DayTotalFightNumber;

		// Token: 0x04006B23 RID: 27427
		public int WeekTotalFightNumber;

		// Token: 0x04006B24 RID: 27428
		public int HardLevelAlreadyFightNumber;

		// Token: 0x04006B25 RID: 27429
		public int HardLevelTotalFightNumber;

		// Token: 0x04006B26 RID: 27430
		public int CommonLevelPassNumber;

		// Token: 0x04006B27 RID: 27431
		public int UnLockCommonLevelTotalNumber;

		// Token: 0x04006B28 RID: 27432
		public bool TicketIsEnough;

		// Token: 0x04006B29 RID: 27433
		public List<uint> AlreadyOpenDifficultyList = new List<uint>();
	}
}
