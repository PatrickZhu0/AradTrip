using System;

namespace behaviac
{
	// Token: 0x02001DDA RID: 7642
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node49 : Condition
	{
		// Token: 0x0601256A RID: 75114 RVA: 0x0055AFA6 File Offset: 0x005593A6
		public Condition_bt_APC_APC_Nianqishi_Action_node49()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601256B RID: 75115 RVA: 0x0055AFDC File Offset: 0x005593DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF59 RID: 48985
		private int opl_p0;

		// Token: 0x0400BF5A RID: 48986
		private int opl_p1;

		// Token: 0x0400BF5B RID: 48987
		private int opl_p2;

		// Token: 0x0400BF5C RID: 48988
		private int opl_p3;
	}
}
