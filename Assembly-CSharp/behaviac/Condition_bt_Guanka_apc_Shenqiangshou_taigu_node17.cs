using System;

namespace behaviac
{
	// Token: 0x02002ACA RID: 10954
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Shenqiangshou_taigu_node17 : Condition
	{
		// Token: 0x06013EAF RID: 81583 RVA: 0x005F9DB7 File Offset: 0x005F81B7
		public Condition_bt_Guanka_apc_Shenqiangshou_taigu_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013EB0 RID: 81584 RVA: 0x005F9DEC File Offset: 0x005F81EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D921 RID: 55585
		private int opl_p0;

		// Token: 0x0400D922 RID: 55586
		private int opl_p1;

		// Token: 0x0400D923 RID: 55587
		private int opl_p2;

		// Token: 0x0400D924 RID: 55588
		private int opl_p3;
	}
}
