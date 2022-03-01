using System;

namespace behaviac
{
	// Token: 0x02001D66 RID: 7526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node8 : Condition
	{
		// Token: 0x06012489 RID: 74889 RVA: 0x005559FE File Offset: 0x00553DFE
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node8()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601248A RID: 74890 RVA: 0x00555A34 File Offset: 0x00553E34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE77 RID: 48759
		private int opl_p0;

		// Token: 0x0400BE78 RID: 48760
		private int opl_p1;

		// Token: 0x0400BE79 RID: 48761
		private int opl_p2;

		// Token: 0x0400BE7A RID: 48762
		private int opl_p3;
	}
}
