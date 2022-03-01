using System;

namespace behaviac
{
	// Token: 0x0200275F RID: 10079
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node6 : Condition
	{
		// Token: 0x060137FF RID: 79871 RVA: 0x005CFCFE File Offset: 0x005CE0FE
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node6()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013800 RID: 79872 RVA: 0x005CFD34 File Offset: 0x005CE134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D25F RID: 53855
		private int opl_p0;

		// Token: 0x0400D260 RID: 53856
		private int opl_p1;

		// Token: 0x0400D261 RID: 53857
		private int opl_p2;

		// Token: 0x0400D262 RID: 53858
		private int opl_p3;
	}
}
