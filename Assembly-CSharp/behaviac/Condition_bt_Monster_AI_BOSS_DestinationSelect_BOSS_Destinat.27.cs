using System;

namespace behaviac
{
	// Token: 0x02002FD4 RID: 12244
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node26 : Condition
	{
		// Token: 0x06014874 RID: 84084 RVA: 0x0062DAA7 File Offset: 0x0062BEA7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_2_0niutoubing_DestinationSelect_node26()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x06014875 RID: 84085 RVA: 0x0062DADC File Offset: 0x0062BEDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E1D1 RID: 57809
		private int opl_p0;

		// Token: 0x0400E1D2 RID: 57810
		private int opl_p1;

		// Token: 0x0400E1D3 RID: 57811
		private int opl_p2;

		// Token: 0x0400E1D4 RID: 57812
		private int opl_p3;
	}
}
