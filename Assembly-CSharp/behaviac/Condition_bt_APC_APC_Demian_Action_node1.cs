using System;

namespace behaviac
{
	// Token: 0x02001CFC RID: 7420
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node1 : Condition
	{
		// Token: 0x060123BE RID: 74686 RVA: 0x005501FE File Offset: 0x0054E5FE
		public Condition_bt_APC_APC_Demian_Action_node1()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060123BF RID: 74687 RVA: 0x00550234 File Offset: 0x0054E634
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDB3 RID: 48563
		private int opl_p0;

		// Token: 0x0400BDB4 RID: 48564
		private int opl_p1;

		// Token: 0x0400BDB5 RID: 48565
		private int opl_p2;

		// Token: 0x0400BDB6 RID: 48566
		private int opl_p3;
	}
}
