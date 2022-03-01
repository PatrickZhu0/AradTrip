using System;

namespace behaviac
{
	// Token: 0x02001D01 RID: 7425
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node9 : Condition
	{
		// Token: 0x060123C7 RID: 74695 RVA: 0x00550C12 File Offset: 0x0054F012
		public Condition_bt_APC_APC_Demian_Action_node9()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060123C8 RID: 74696 RVA: 0x00550C48 File Offset: 0x0054F048
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDBD RID: 48573
		private int opl_p0;

		// Token: 0x0400BDBE RID: 48574
		private int opl_p1;

		// Token: 0x0400BDBF RID: 48575
		private int opl_p2;

		// Token: 0x0400BDC0 RID: 48576
		private int opl_p3;
	}
}
