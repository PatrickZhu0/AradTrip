using System;

namespace behaviac
{
	// Token: 0x02001E13 RID: 7699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node2 : Condition
	{
		// Token: 0x060125D7 RID: 75223 RVA: 0x0055D7B0 File Offset: 0x0055BBB0
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node2()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060125D8 RID: 75224 RVA: 0x0055D7E4 File Offset: 0x0055BBE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFBF RID: 49087
		private int opl_p0;

		// Token: 0x0400BFC0 RID: 49088
		private int opl_p1;

		// Token: 0x0400BFC1 RID: 49089
		private int opl_p2;

		// Token: 0x0400BFC2 RID: 49090
		private int opl_p3;
	}
}
