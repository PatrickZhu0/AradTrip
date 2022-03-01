using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001698 RID: 5784
	public interface IHorseGablingDataManager
	{
		// Token: 0x17001C82 RID: 7298
		// (get) Token: 0x0600E323 RID: 58147
		List<IHorseGamblingMapZoneModel> MapZoneModels { get; }

		// Token: 0x0600E324 RID: 58148
		HorseGamblingShooterModel GetShooterModel(int shooterId);

		// Token: 0x0600E325 RID: 58149
		ShooterRecord[] GetShooterHistory(int shooterId);

		// Token: 0x0600E326 RID: 58150
		List<IHorseGamblingStakeModel> GetStakeHistory();

		// Token: 0x17001C83 RID: 7299
		// (get) Token: 0x0600E327 RID: 58151
		BetHorsePhaseType State { get; }

		// Token: 0x17001C84 RID: 7300
		// (get) Token: 0x0600E328 RID: 58152
		WeatherType Weather { get; }

		// Token: 0x17001C85 RID: 7301
		// (get) Token: 0x0600E329 RID: 58153
		uint TimeStamp { get; }
	}
}
