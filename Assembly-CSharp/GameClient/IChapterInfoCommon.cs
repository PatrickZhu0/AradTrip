using System;

namespace GameClient
{
	// Token: 0x02000E96 RID: 3734
	public interface IChapterInfoCommon
	{
		// Token: 0x060093B7 RID: 37815
		void SetName(string name);

		// Token: 0x060093B8 RID: 37816
		void SetDescription(string desc);

		// Token: 0x060093B9 RID: 37817
		void SetRecommnedLevel(string level);

		// Token: 0x060093BA RID: 37818
		void SetRecommnedLevel(string[] level);

		// Token: 0x060093BB RID: 37819
		void SetRecommnedWeapon(string weapon);

		// Token: 0x060093BC RID: 37820
		void SetOpenTime(string opentime);
	}
}
