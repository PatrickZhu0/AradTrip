using System;

namespace behaviac
{
	// Token: 0x02001D6B RID: 7531
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node14 : Condition
	{
		// Token: 0x06012493 RID: 74899 RVA: 0x00555C0E File Offset: 0x0055400E
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node14()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06012494 RID: 74900 RVA: 0x00555C44 File Offset: 0x00554044
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE82 RID: 48770
		private int opl_p0;

		// Token: 0x0400BE83 RID: 48771
		private int opl_p1;

		// Token: 0x0400BE84 RID: 48772
		private int opl_p2;

		// Token: 0x0400BE85 RID: 48773
		private int opl_p3;
	}
}
