using System;

namespace behaviac
{
	// Token: 0x02002FAD RID: 12205
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node6 : Condition
	{
		// Token: 0x06014827 RID: 84007 RVA: 0x0062C6E7 File Offset: 0x0062AAE7
		public Condition_bt_Monster_AI_BOSS_DestinationSelect_BOSS_DestinationSelect_1_1_0gebulin_DestinationSelect_node6()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06014828 RID: 84008 RVA: 0x0062C71C File Offset: 0x0062AB1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E184 RID: 57732
		private int opl_p0;

		// Token: 0x0400E185 RID: 57733
		private int opl_p1;

		// Token: 0x0400E186 RID: 57734
		private int opl_p2;

		// Token: 0x0400E187 RID: 57735
		private int opl_p3;
	}
}
