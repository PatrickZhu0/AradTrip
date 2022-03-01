using System;

namespace behaviac
{
	// Token: 0x02002AB5 RID: 10933
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_32_node9 : Condition
	{
		// Token: 0x06013E88 RID: 81544 RVA: 0x005F8DB7 File Offset: 0x005F71B7
		public Condition_bt_Guanka_apc_Shenqiangshou_32_node9()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013E89 RID: 81545 RVA: 0x005F8DEC File Offset: 0x005F71EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8FB RID: 55547
		private int opl_p0;

		// Token: 0x0400D8FC RID: 55548
		private int opl_p1;

		// Token: 0x0400D8FD RID: 55549
		private int opl_p2;

		// Token: 0x0400D8FE RID: 55550
		private int opl_p3;
	}
}
