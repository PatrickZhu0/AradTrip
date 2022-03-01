using System;

namespace behaviac
{
	// Token: 0x02002A12 RID: 10770
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_node17 : Condition
	{
		// Token: 0x06013D54 RID: 81236 RVA: 0x005F014E File Offset: 0x005EE54E
		public Condition_bt_Guanka_apc_Bawanghuatiexin_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D55 RID: 81237 RVA: 0x005F0184 File Offset: 0x005EE584
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7C0 RID: 55232
		private int opl_p0;

		// Token: 0x0400D7C1 RID: 55233
		private int opl_p1;

		// Token: 0x0400D7C2 RID: 55234
		private int opl_p2;

		// Token: 0x0400D7C3 RID: 55235
		private int opl_p3;
	}
}
