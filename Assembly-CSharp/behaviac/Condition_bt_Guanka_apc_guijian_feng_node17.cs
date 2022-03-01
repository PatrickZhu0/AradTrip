using System;

namespace behaviac
{
	// Token: 0x02002A4D RID: 10829
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_guijian_feng_node17 : Condition
	{
		// Token: 0x06013DC5 RID: 81349 RVA: 0x005F3742 File Offset: 0x005F1B42
		public Condition_bt_Guanka_apc_guijian_feng_node17()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 3000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013DC6 RID: 81350 RVA: 0x005F3778 File Offset: 0x005F1B78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D838 RID: 55352
		private int opl_p0;

		// Token: 0x0400D839 RID: 55353
		private int opl_p1;

		// Token: 0x0400D83A RID: 55354
		private int opl_p2;

		// Token: 0x0400D83B RID: 55355
		private int opl_p3;
	}
}
