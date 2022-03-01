using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001687 RID: 5767
	public interface IHorseGamblingMapZoneModel
	{
		// Token: 0x17001C5C RID: 7260
		// (get) Token: 0x0600E2B4 RID: 58036
		int Id { get; }

		// Token: 0x17001C5D RID: 7261
		// (get) Token: 0x0600E2B5 RID: 58037
		string TerrainPath { get; }

		// Token: 0x17001C5E RID: 7262
		// (get) Token: 0x0600E2B6 RID: 58038
		Dictionary<int, HorseGamblingMapShooterModel> Shooters { get; }

		// Token: 0x17001C5F RID: 7263
		// (get) Token: 0x0600E2B7 RID: 58039
		int Phase { get; }
	}
}
