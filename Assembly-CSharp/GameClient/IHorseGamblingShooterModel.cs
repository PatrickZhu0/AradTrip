using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200168A RID: 5770
	public interface IHorseGamblingShooterModel
	{
		// Token: 0x17001C64 RID: 7268
		// (get) Token: 0x0600E2BC RID: 58044
		int Id { get; }

		// Token: 0x17001C65 RID: 7269
		// (get) Token: 0x0600E2BD RID: 58045
		string IconPath { get; }

		// Token: 0x17001C66 RID: 7270
		// (get) Token: 0x0600E2BE RID: 58046
		string PortraitPath { get; }

		// Token: 0x17001C67 RID: 7271
		// (get) Token: 0x0600E2BF RID: 58047
		string Name { get; }

		// Token: 0x17001C68 RID: 7272
		// (get) Token: 0x0600E2C0 RID: 58048
		string Occupation { get; }

		// Token: 0x17001C69 RID: 7273
		// (get) Token: 0x0600E2C1 RID: 58049
		string OccupationIcon { get; }

		// Token: 0x17001C6A RID: 7274
		// (get) Token: 0x0600E2C2 RID: 58050
		string Terrain { get; }

		// Token: 0x17001C6B RID: 7275
		// (get) Token: 0x0600E2C3 RID: 58051
		string Weather { get; }

		// Token: 0x17001C6C RID: 7276
		// (get) Token: 0x0600E2C4 RID: 58052
		ShooterStatusType Status { get; }

		// Token: 0x17001C6D RID: 7277
		// (get) Token: 0x0600E2C5 RID: 58053
		float WinRate { get; }

		// Token: 0x17001C6E RID: 7278
		// (get) Token: 0x0600E2C6 RID: 58054
		bool IsUnknown { get; }

		// Token: 0x17001C6F RID: 7279
		// (get) Token: 0x0600E2C7 RID: 58055
		int ChampionCount { get; }

		// Token: 0x17001C70 RID: 7280
		// (get) Token: 0x0600E2C8 RID: 58056
		ShooterRecord[] Records { get; }
	}
}
