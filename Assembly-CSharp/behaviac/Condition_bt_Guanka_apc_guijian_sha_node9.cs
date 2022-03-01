using System;

namespace behaviac
{
	// Token: 0x02002A6E RID: 10862
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_sha_node9 : Condition
	{
		// Token: 0x06013E03 RID: 81411 RVA: 0x005F55A6 File Offset: 0x005F39A6
		public Condition_bt_Guanka_apc_guijian_sha_node9()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013E04 RID: 81412 RVA: 0x005F55DC File Offset: 0x005F39DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D875 RID: 55413
		private int opl_p0;

		// Token: 0x0400D876 RID: 55414
		private int opl_p1;

		// Token: 0x0400D877 RID: 55415
		private int opl_p2;

		// Token: 0x0400D878 RID: 55416
		private int opl_p3;
	}
}
