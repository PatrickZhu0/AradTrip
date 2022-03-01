using System;

namespace behaviac
{
	// Token: 0x02001DE7 RID: 7655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node3 : Condition
	{
		// Token: 0x06012584 RID: 75140 RVA: 0x0055B51A File Offset: 0x0055991A
		public Condition_bt_APC_APC_Nianqishi_Action_node3()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06012585 RID: 75141 RVA: 0x0055B550 File Offset: 0x00559950
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF74 RID: 49012
		private int opl_p0;

		// Token: 0x0400BF75 RID: 49013
		private int opl_p1;

		// Token: 0x0400BF76 RID: 49014
		private int opl_p2;

		// Token: 0x0400BF77 RID: 49015
		private int opl_p3;
	}
}
