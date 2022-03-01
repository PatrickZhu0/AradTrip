using System;

namespace behaviac
{
	// Token: 0x02002B4B RID: 11083
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node40 : Condition
	{
		// Token: 0x06013FA4 RID: 81828 RVA: 0x005FF659 File Offset: 0x005FDA59
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node40()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013FA5 RID: 81829 RVA: 0x005FF690 File Offset: 0x005FDA90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9C3 RID: 55747
		private int opl_p0;

		// Token: 0x0400D9C4 RID: 55748
		private int opl_p1;

		// Token: 0x0400D9C5 RID: 55749
		private int opl_p2;

		// Token: 0x0400D9C6 RID: 55750
		private int opl_p3;
	}
}
