using System;

namespace behaviac
{
	// Token: 0x02001E21 RID: 7713
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node10 : Condition
	{
		// Token: 0x060125F3 RID: 75251 RVA: 0x0055DD9D File Offset: 0x0055C19D
		public Condition_bt_APC_APC_Tiantangmanbuzhe_Action_node10()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 0;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060125F4 RID: 75252 RVA: 0x0055DDD0 File Offset: 0x0055C1D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFDE RID: 49118
		private int opl_p0;

		// Token: 0x0400BFDF RID: 49119
		private int opl_p1;

		// Token: 0x0400BFE0 RID: 49120
		private int opl_p2;

		// Token: 0x0400BFE1 RID: 49121
		private int opl_p3;
	}
}
