using System;

namespace behaviac
{
	// Token: 0x02001D61 RID: 7521
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node2 : Condition
	{
		// Token: 0x0601247F RID: 74879 RVA: 0x005557EF File Offset: 0x00553BEF
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node2()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012480 RID: 74880 RVA: 0x00555824 File Offset: 0x00553C24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE6C RID: 48748
		private int opl_p0;

		// Token: 0x0400BE6D RID: 48749
		private int opl_p1;

		// Token: 0x0400BE6E RID: 48750
		private int opl_p2;

		// Token: 0x0400BE6F RID: 48751
		private int opl_p3;
	}
}
