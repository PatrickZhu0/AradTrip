using System;

namespace behaviac
{
	// Token: 0x02002A51 RID: 10833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node23 : Condition
	{
		// Token: 0x06013DCD RID: 81357 RVA: 0x005F38F7 File Offset: 0x005F1CF7
		public Condition_bt_Guanka_apc_guijian_feng_node23()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013DCE RID: 81358 RVA: 0x005F392C File Offset: 0x005F1D2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D840 RID: 55360
		private int opl_p0;

		// Token: 0x0400D841 RID: 55361
		private int opl_p1;

		// Token: 0x0400D842 RID: 55362
		private int opl_p2;

		// Token: 0x0400D843 RID: 55363
		private int opl_p3;
	}
}
