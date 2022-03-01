using System;

namespace behaviac
{
	// Token: 0x020029E7 RID: 10727
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_BOSS_BOSS20_4_Action_node29 : Condition
	{
		// Token: 0x06013D01 RID: 81153 RVA: 0x005EE1CE File Offset: 0x005EC5CE
		public Condition_bt_BOSS_BOSS20_4_Action_node29()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x06013D02 RID: 81154 RVA: 0x005EE204 File Offset: 0x005EC604
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D774 RID: 55156
		private int opl_p0;

		// Token: 0x0400D775 RID: 55157
		private int opl_p1;

		// Token: 0x0400D776 RID: 55158
		private int opl_p2;

		// Token: 0x0400D777 RID: 55159
		private int opl_p3;
	}
}
