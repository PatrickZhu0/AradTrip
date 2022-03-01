using System;

namespace behaviac
{
	// Token: 0x02002A98 RID: 10904
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Mofashi_li_node17 : Condition
	{
		// Token: 0x06013E52 RID: 81490 RVA: 0x005F7666 File Offset: 0x005F5A66
		public Condition_bt_Guanka_apc_Mofashi_li_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06013E53 RID: 81491 RVA: 0x005F769C File Offset: 0x005F5A9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D8C6 RID: 55494
		private int opl_p0;

		// Token: 0x0400D8C7 RID: 55495
		private int opl_p1;

		// Token: 0x0400D8C8 RID: 55496
		private int opl_p2;

		// Token: 0x0400D8C9 RID: 55497
		private int opl_p3;
	}
}
