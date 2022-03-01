using System;

namespace behaviac
{
	// Token: 0x02002FEC RID: 12268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node26 : Condition
	{
		// Token: 0x060148A3 RID: 84131 RVA: 0x0062E9CB File Offset: 0x0062CDCB
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_2_1_0niutoujushou_DestinationSelect_node26()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x060148A4 RID: 84132 RVA: 0x0062EA00 File Offset: 0x0062CE00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E200 RID: 57856
		private int opl_p0;

		// Token: 0x0400E201 RID: 57857
		private int opl_p1;

		// Token: 0x0400E202 RID: 57858
		private int opl_p2;

		// Token: 0x0400E203 RID: 57859
		private int opl_p3;
	}
}
