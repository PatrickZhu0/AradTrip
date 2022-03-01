using System;

namespace behaviac
{
	// Token: 0x02001D11 RID: 7441
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi2_Action_node2 : Condition
	{
		// Token: 0x060123E5 RID: 74725 RVA: 0x00551774 File Offset: 0x0054FB74
		public Condition_bt_APC_APC_Guiqi2_Action_node2()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 0;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060123E6 RID: 74726 RVA: 0x005517A4 File Offset: 0x0054FBA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDD7 RID: 48599
		private int opl_p0;

		// Token: 0x0400BDD8 RID: 48600
		private int opl_p1;

		// Token: 0x0400BDD9 RID: 48601
		private int opl_p2;

		// Token: 0x0400BDDA RID: 48602
		private int opl_p3;
	}
}
