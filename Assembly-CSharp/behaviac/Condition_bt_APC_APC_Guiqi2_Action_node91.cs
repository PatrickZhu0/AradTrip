using System;

namespace behaviac
{
	// Token: 0x02001D1D RID: 7453
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node91 : Condition
	{
		// Token: 0x060123FD RID: 74749 RVA: 0x00551F27 File Offset: 0x00550327
		public Condition_bt_APC_APC_Guiqi2_Action_node91()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060123FE RID: 74750 RVA: 0x00551F5C File Offset: 0x0055035C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDEB RID: 48619
		private int opl_p0;

		// Token: 0x0400BDEC RID: 48620
		private int opl_p1;

		// Token: 0x0400BDED RID: 48621
		private int opl_p2;

		// Token: 0x0400BDEE RID: 48622
		private int opl_p3;
	}
}
