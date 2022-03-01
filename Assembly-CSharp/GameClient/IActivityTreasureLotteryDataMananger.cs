using System;
using DataModel;

namespace GameClient
{
	// Token: 0x020011C0 RID: 4544
	public interface IActivityTreasureLotteryDataMananger
	{
		// Token: 0x0600AEAA RID: 44714
		int GetModelAmount<T>();

		// Token: 0x0600AEAB RID: 44715
		string GetRemainTime();

		// Token: 0x0600AEAC RID: 44716
		ETreasureLotterState GetState();

		// Token: 0x0600AEAD RID: 44717
		int GetModelIndexByLotteryId<T>(int lotteryId);

		// Token: 0x0600AEAE RID: 44718
		T GetModel<T>(int id) where T : IActivityTreasureLotteryModelBase;

		// Token: 0x0600AEAF RID: 44719
		bool IsHadData();
	}
}
