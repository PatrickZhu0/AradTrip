using System;
using DataModel;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E3 RID: 5091
	public interface IActivityTreasureLotteryItem
	{
		// Token: 0x0600C56F RID: 50543
		void OnSelect(bool value);

		// Token: 0x0600C570 RID: 50544
		void Init<T>(T model, bool isOn) where T : IActivityTreasureLotteryModelBase;
	}
}
