using System;

namespace behaviac
{
	// Token: 0x02002FBC RID: 12220
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node26 : Condition
	{
		// Token: 0x06014845 RID: 84037 RVA: 0x0062CB83 File Offset: 0x0062AF83
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node26()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014846 RID: 84038 RVA: 0x0062CBB8 File Offset: 0x0062AFB8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1A2 RID: 57762
		private int opl_p0;

		// Token: 0x0400E1A3 RID: 57763
		private int opl_p1;

		// Token: 0x0400E1A4 RID: 57764
		private int opl_p2;

		// Token: 0x0400E1A5 RID: 57765
		private int opl_p3;
	}
}
