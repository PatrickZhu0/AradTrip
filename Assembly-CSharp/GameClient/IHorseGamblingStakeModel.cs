using System;

namespace GameClient
{
	// Token: 0x02001699 RID: 5785
	public interface IHorseGamblingStakeModel
	{
		// Token: 0x17001C86 RID: 7302
		// (get) Token: 0x0600E32A RID: 58154
		int ShooterId { get; }

		// Token: 0x17001C87 RID: 7303
		// (get) Token: 0x0600E32B RID: 58155
		string ShooterName { get; }

		// Token: 0x17001C88 RID: 7304
		// (get) Token: 0x0600E32C RID: 58156
		int Stake { get; }

		// Token: 0x17001C89 RID: 7305
		// (get) Token: 0x0600E32D RID: 58157
		int GameId { get; }

		// Token: 0x17001C8A RID: 7306
		// (get) Token: 0x0600E32E RID: 58158
		int Profit { get; }

		// Token: 0x17001C8B RID: 7307
		// (get) Token: 0x0600E32F RID: 58159
		float Odds { get; }
	}
}
