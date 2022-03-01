using System;

namespace behaviac
{
	// Token: 0x02001DEC RID: 7660
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node10 : Condition
	{
		// Token: 0x0601258E RID: 75150 RVA: 0x0055B765 File Offset: 0x00559B65
		public Condition_bt_APC_APC_Nianqishi_Action_node10()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601258F RID: 75151 RVA: 0x0055B79C File Offset: 0x00559B9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF82 RID: 49026
		private int opl_p0;

		// Token: 0x0400BF83 RID: 49027
		private int opl_p1;

		// Token: 0x0400BF84 RID: 49028
		private int opl_p2;

		// Token: 0x0400BF85 RID: 49029
		private int opl_p3;
	}
}
