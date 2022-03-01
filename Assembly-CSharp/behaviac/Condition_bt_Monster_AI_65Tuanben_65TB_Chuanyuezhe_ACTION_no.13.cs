using System;

namespace behaviac
{
	// Token: 0x02002B4F RID: 11087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node41 : Condition
	{
		// Token: 0x06013FAC RID: 81836 RVA: 0x005FF7D9 File Offset: 0x005FDBD9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Chuanyuezhe_ACTION_node41()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 5000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013FAD RID: 81837 RVA: 0x005FF810 File Offset: 0x005FDC10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9CA RID: 55754
		private int opl_p0;

		// Token: 0x0400D9CB RID: 55755
		private int opl_p1;

		// Token: 0x0400D9CC RID: 55756
		private int opl_p2;

		// Token: 0x0400D9CD RID: 55757
		private int opl_p3;
	}
}
