using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012B7 RID: 4791
	internal class PromotionInfo
	{
		// Token: 0x0400681B RID: 26651
		public EPromotionState eState;

		// Token: 0x0400681C RID: 26652
		public int nTargetWinCount;

		// Token: 0x0400681D RID: 26653
		public int nTotalCount;

		// Token: 0x0400681E RID: 26654
		public int nCurrentWinCount;

		// Token: 0x0400681F RID: 26655
		public int nCurrentLoseCount;

		// Token: 0x04006820 RID: 26656
		public List<byte> arrRecords;

		// Token: 0x04006821 RID: 26657
		public int nNextSeasonLevel;
	}
}
