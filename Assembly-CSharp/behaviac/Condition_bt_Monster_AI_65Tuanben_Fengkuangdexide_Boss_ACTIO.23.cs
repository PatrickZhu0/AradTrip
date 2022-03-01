using System;

namespace behaviac
{
	// Token: 0x02002ECF RID: 11983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node20 : Condition
	{
		// Token: 0x06014678 RID: 83576 RVA: 0x006228CB File Offset: 0x00620CCB
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node20()
		{
			this.opl_p0 = 9000;
			this.opl_p1 = 1800;
			this.opl_p2 = 2400;
			this.opl_p3 = 2400;
		}

		// Token: 0x06014679 RID: 83577 RVA: 0x00622900 File Offset: 0x00620D00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFE6 RID: 57318
		private int opl_p0;

		// Token: 0x0400DFE7 RID: 57319
		private int opl_p1;

		// Token: 0x0400DFE8 RID: 57320
		private int opl_p2;

		// Token: 0x0400DFE9 RID: 57321
		private int opl_p3;
	}
}
