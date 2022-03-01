using System;

namespace GameClient
{
	// Token: 0x02001ACC RID: 6860
	public class BeadPickItemModel
	{
		// Token: 0x06010D7B RID: 68987 RVA: 0x004CD6A9 File Offset: 0x004CBAA9
		public BeadPickItemModel(int expendItemID, int expendCount, int pickSuccessRate, int pickTotleNumber)
		{
			this.mExpendItemID = expendItemID;
			this.mExpendCount = expendCount;
			this.mPickSuccessRate = pickSuccessRate;
			this.mBeadPickTotleNumber = pickTotleNumber;
		}

		// Token: 0x0400ACB9 RID: 44217
		public int mExpendItemID;

		// Token: 0x0400ACBA RID: 44218
		public int mExpendCount;

		// Token: 0x0400ACBB RID: 44219
		public int mPickSuccessRate;

		// Token: 0x0400ACBC RID: 44220
		public int mBeadPickTotleNumber;
	}
}
