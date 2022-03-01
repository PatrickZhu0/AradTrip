using System;

namespace GameClient
{
	// Token: 0x020010CE RID: 4302
	public interface IDungeonFinish
	{
		// Token: 0x0600A2AB RID: 41643
		void SetName(string name);

		// Token: 0x0600A2AC RID: 41644
		void SetBestTime(int time);

		// Token: 0x0600A2AD RID: 41645
		void SetCurrentTime(int time);

		// Token: 0x0600A2AE RID: 41646
		void SetDrops(ComItemList.Items[] items);

		// Token: 0x0600A2AF RID: 41647
		void SetExp(ulong exp);

		// Token: 0x0600A2B0 RID: 41648
		void SetLevel(int lvl);

		// Token: 0x0600A2B1 RID: 41649
		void SetDiff(int diff);

		// Token: 0x0600A2B2 RID: 41650
		void SetFinish(bool isFinish);
	}
}
