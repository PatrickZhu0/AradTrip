using System;

namespace behaviac
{
	// Token: 0x02002A6B RID: 10859
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node2 : Condition
	{
		// Token: 0x06013DFD RID: 81405 RVA: 0x005F5381 File Offset: 0x005F3781
		public Condition_bt_Guanka_apc_guijian_sha_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013DFE RID: 81406 RVA: 0x005F53B8 File Offset: 0x005F37B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D86E RID: 55406
		private int opl_p0;

		// Token: 0x0400D86F RID: 55407
		private int opl_p1;

		// Token: 0x0400D870 RID: 55408
		private int opl_p2;

		// Token: 0x0400D871 RID: 55409
		private int opl_p3;
	}
}
