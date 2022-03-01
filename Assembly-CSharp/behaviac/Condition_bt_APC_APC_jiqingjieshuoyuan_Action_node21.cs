using System;

namespace behaviac
{
	// Token: 0x02001D70 RID: 7536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node21 : Condition
	{
		// Token: 0x0601249D RID: 74909 RVA: 0x00555E3D File Offset: 0x0055423D
		public Condition_bt_APC_APC_jiqingjieshuoyuan_Action_node21()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 0;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601249E RID: 74910 RVA: 0x00555E70 File Offset: 0x00554270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE8E RID: 48782
		private int opl_p0;

		// Token: 0x0400BE8F RID: 48783
		private int opl_p1;

		// Token: 0x0400BE90 RID: 48784
		private int opl_p2;

		// Token: 0x0400BE91 RID: 48785
		private int opl_p3;
	}
}
