using System;

namespace behaviac
{
	// Token: 0x02002A36 RID: 10806
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_cha_node2 : Condition
	{
		// Token: 0x06013D98 RID: 81304 RVA: 0x005F24CA File Offset: 0x005F08CA
		public Condition_bt_Guanka_apc_guijian_cha_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D99 RID: 81305 RVA: 0x005F2500 File Offset: 0x005F0900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D806 RID: 55302
		private int opl_p0;

		// Token: 0x0400D807 RID: 55303
		private int opl_p1;

		// Token: 0x0400D808 RID: 55304
		private int opl_p2;

		// Token: 0x0400D809 RID: 55305
		private int opl_p3;
	}
}
