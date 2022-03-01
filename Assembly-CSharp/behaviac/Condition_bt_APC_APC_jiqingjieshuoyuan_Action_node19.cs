using System;

namespace behaviac
{
	// Token: 0x02001D6F RID: 7535
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node19 : Condition
	{
		// Token: 0x0601249B RID: 74907 RVA: 0x00555DC2 File Offset: 0x005541C2
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node19()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 3000;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601249C RID: 74908 RVA: 0x00555DF8 File Offset: 0x005541F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE8A RID: 48778
		private int opl_p0;

		// Token: 0x0400BE8B RID: 48779
		private int opl_p1;

		// Token: 0x0400BE8C RID: 48780
		private int opl_p2;

		// Token: 0x0400BE8D RID: 48781
		private int opl_p3;
	}
}
