using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001328 RID: 4904
	public class TeamDuplicationFightStageRewardDataModel
	{
		// Token: 0x04006B9D RID: 27549
		public ulong PlayerGuid;

		// Token: 0x04006B9E RID: 27550
		public string PlayerName;

		// Token: 0x04006B9F RID: 27551
		public int RewardId;

		// Token: 0x04006BA0 RID: 27552
		public int RewardNum;

		// Token: 0x04006BA1 RID: 27553
		public int RewardIndex;

		// Token: 0x04006BA2 RID: 27554
		public bool IsGoldReward;

		// Token: 0x04006BA3 RID: 27555
		public TeamCopyFlopLimit IsLimit;
	}
}
