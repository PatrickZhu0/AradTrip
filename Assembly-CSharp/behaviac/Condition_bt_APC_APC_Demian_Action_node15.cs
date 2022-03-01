using System;

namespace behaviac
{
	// Token: 0x02001D05 RID: 7429
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node15 : Condition
	{
		// Token: 0x060123CF RID: 74703 RVA: 0x00550DC7 File Offset: 0x0054F1C7
		public Condition_bt_APC_APC_Demian_Action_node15()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060123D0 RID: 74704 RVA: 0x00550DF8 File Offset: 0x0054F1F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDC5 RID: 48581
		private int opl_p0;

		// Token: 0x0400BDC6 RID: 48582
		private int opl_p1;

		// Token: 0x0400BDC7 RID: 48583
		private int opl_p2;

		// Token: 0x0400BDC8 RID: 48584
		private int opl_p3;
	}
}
