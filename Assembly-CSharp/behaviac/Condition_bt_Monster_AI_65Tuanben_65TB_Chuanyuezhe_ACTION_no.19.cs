using System;

namespace behaviac
{
	// Token: 0x02002B5A RID: 11098
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node44 : Condition
	{
		// Token: 0x06013FC2 RID: 81858 RVA: 0x005FFC46 File Offset: 0x005FE046
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node44()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013FC3 RID: 81859 RVA: 0x005FFC7C File Offset: 0x005FE07C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9DF RID: 55775
		private int opl_p0;

		// Token: 0x0400D9E0 RID: 55776
		private int opl_p1;

		// Token: 0x0400D9E1 RID: 55777
		private int opl_p2;

		// Token: 0x0400D9E2 RID: 55778
		private int opl_p3;
	}
}
