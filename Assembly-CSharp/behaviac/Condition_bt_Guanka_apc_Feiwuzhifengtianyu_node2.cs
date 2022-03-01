using System;

namespace behaviac
{
	// Token: 0x02002A2D RID: 10797
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node2 : Condition
	{
		// Token: 0x06013D87 RID: 81287 RVA: 0x005F1C9D File Offset: 0x005F009D
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node2()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D88 RID: 81288 RVA: 0x005F1CD4 File Offset: 0x005F00D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7F4 RID: 55284
		private int opl_p0;

		// Token: 0x0400D7F5 RID: 55285
		private int opl_p1;

		// Token: 0x0400D7F6 RID: 55286
		private int opl_p2;

		// Token: 0x0400D7F7 RID: 55287
		private int opl_p3;
	}
}
