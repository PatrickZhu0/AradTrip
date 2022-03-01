using System;

namespace GameClient
{
	// Token: 0x020011D1 RID: 4561
	public struct ExpeditionReward
	{
		// Token: 0x0600AEFD RID: 44797 RVA: 0x00263F6B File Offset: 0x0026236B
		public ExpeditionReward(int num, ExpeditionRewardCondition condition, string reward)
		{
			this.rolesNum = num;
			this.rewardCondition = condition;
			this.rewards = reward;
		}

		// Token: 0x040061F2 RID: 25074
		public int rolesNum;

		// Token: 0x040061F3 RID: 25075
		public ExpeditionRewardCondition rewardCondition;

		// Token: 0x040061F4 RID: 25076
		public string rewards;
	}
}
