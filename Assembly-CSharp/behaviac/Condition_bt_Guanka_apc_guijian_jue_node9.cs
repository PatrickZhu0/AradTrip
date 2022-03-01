using System;

namespace behaviac
{
	// Token: 0x02002A5B RID: 10843
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_jue_node9 : Condition
	{
		// Token: 0x06013DE0 RID: 81376 RVA: 0x005F449F File Offset: 0x005F289F
		public Condition_bt_Guanka_apc_guijian_jue_node9()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013DE1 RID: 81377 RVA: 0x005F44D4 File Offset: 0x005F28D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D853 RID: 55379
		private int opl_p0;

		// Token: 0x0400D854 RID: 55380
		private int opl_p1;

		// Token: 0x0400D855 RID: 55381
		private int opl_p2;

		// Token: 0x0400D856 RID: 55382
		private int opl_p3;
	}
}
