using System;

namespace behaviac
{
	// Token: 0x02001E3B RID: 7739
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node11 : Condition
	{
		// Token: 0x06012624 RID: 75300 RVA: 0x0055F2FC File Offset: 0x0055D6FC
		public Condition_bt_APC_APC_Xiuluo_Action_node11()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012625 RID: 75301 RVA: 0x0055F330 File Offset: 0x0055D730
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C00B RID: 49163
		private int opl_p0;

		// Token: 0x0400C00C RID: 49164
		private int opl_p1;

		// Token: 0x0400C00D RID: 49165
		private int opl_p2;

		// Token: 0x0400C00E RID: 49166
		private int opl_p3;
	}
}
