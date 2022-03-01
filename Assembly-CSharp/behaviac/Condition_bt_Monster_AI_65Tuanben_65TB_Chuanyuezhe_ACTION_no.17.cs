using System;

namespace behaviac
{
	// Token: 0x02002B57 RID: 11095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node43 : Condition
	{
		// Token: 0x06013FBC RID: 81852 RVA: 0x005FFAD9 File Offset: 0x005FDED9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node43()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013FBD RID: 81853 RVA: 0x005FFB10 File Offset: 0x005FDF10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9D8 RID: 55768
		private int opl_p0;

		// Token: 0x0400D9D9 RID: 55769
		private int opl_p1;

		// Token: 0x0400D9DA RID: 55770
		private int opl_p2;

		// Token: 0x0400D9DB RID: 55771
		private int opl_p3;
	}
}
