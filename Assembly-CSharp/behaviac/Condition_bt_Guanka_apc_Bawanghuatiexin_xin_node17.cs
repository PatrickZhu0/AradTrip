using System;

namespace behaviac
{
	// Token: 0x02002A1B RID: 10779
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node17 : Condition
	{
		// Token: 0x06013D65 RID: 81253 RVA: 0x005F0AF6 File Offset: 0x005EEEF6
		public Condition_bt_Guanka_apc_Bawanghuatiexin_xin_node17()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013D66 RID: 81254 RVA: 0x005F0B2C File Offset: 0x005EEF2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D7D2 RID: 55250
		private int opl_p0;

		// Token: 0x0400D7D3 RID: 55251
		private int opl_p1;

		// Token: 0x0400D7D4 RID: 55252
		private int opl_p2;

		// Token: 0x0400D7D5 RID: 55253
		private int opl_p3;
	}
}
