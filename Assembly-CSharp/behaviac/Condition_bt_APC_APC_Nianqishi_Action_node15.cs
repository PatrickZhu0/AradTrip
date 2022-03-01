using System;

namespace behaviac
{
	// Token: 0x02001DDF RID: 7647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Nianqishi_Action_node15 : Condition
	{
		// Token: 0x06012574 RID: 75124 RVA: 0x0055B1B6 File Offset: 0x005595B6
		public Condition_bt_APC_APC_Nianqishi_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 4000;
			this.opl_p2 = 4000;
			this.opl_p3 = 4000;
		}

		// Token: 0x06012575 RID: 75125 RVA: 0x0055B1EC File Offset: 0x005595EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF64 RID: 48996
		private int opl_p0;

		// Token: 0x0400BF65 RID: 48997
		private int opl_p1;

		// Token: 0x0400BF66 RID: 48998
		private int opl_p2;

		// Token: 0x0400BF67 RID: 48999
		private int opl_p3;
	}
}
