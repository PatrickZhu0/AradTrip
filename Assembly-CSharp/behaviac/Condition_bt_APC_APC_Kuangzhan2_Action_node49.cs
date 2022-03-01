using System;

namespace behaviac
{
	// Token: 0x02001D7E RID: 7550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Kuangzhan2_Action_node49 : Condition
	{
		// Token: 0x060124B7 RID: 74935 RVA: 0x00556AC5 File Offset: 0x00554EC5
		public Condition_bt_APC_APC_Kuangzhan2_Action_node49()
		{
			this.opl_p0 = 1503;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060124B8 RID: 74936 RVA: 0x00556AFC File Offset: 0x00554EFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEA0 RID: 48800
		private int opl_p0;

		// Token: 0x0400BEA1 RID: 48801
		private int opl_p1;

		// Token: 0x0400BEA2 RID: 48802
		private int opl_p2;

		// Token: 0x0400BEA3 RID: 48803
		private int opl_p3;
	}
}
