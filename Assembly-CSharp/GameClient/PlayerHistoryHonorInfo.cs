using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x0200127B RID: 4731
	public class PlayerHistoryHonorInfo
	{
		// Token: 0x040066F1 RID: 26353
		public HONOR_DATE_TYPE HonorDateType;

		// Token: 0x040066F2 RID: 26354
		public uint HonorTotalNumber;

		// Token: 0x040066F3 RID: 26355
		public List<PvpNumberStatistics> PvpNumberStatisticsList = new List<PvpNumberStatistics>();
	}
}
