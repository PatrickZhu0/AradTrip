using System;

namespace GameClient
{
	// Token: 0x02001208 RID: 4616
	public class ChampionshipScoreFightRecordDataModel
	{
		// Token: 0x04006392 RID: 25490
		public ulong FirstPlayerGuid;

		// Token: 0x04006393 RID: 25491
		public string FirstPlayerName;

		// Token: 0x04006394 RID: 25492
		public ulong SecondPlayerGuid;

		// Token: 0x04006395 RID: 25493
		public string SecondPlayerName;

		// Token: 0x04006396 RID: 25494
		public bool IsWin;

		// Token: 0x04006397 RID: 25495
		public bool IsNullTurnFlag;

		// Token: 0x04006398 RID: 25496
		public bool IsSelfFightRecord;
	}
}
