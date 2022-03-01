using System;

namespace behaviac
{
	// Token: 0x02001EBF RID: 7871
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node2 : Condition
	{
		// Token: 0x06012726 RID: 75558 RVA: 0x00565182 File Offset: 0x00563582
		public Condition_bt_APC_ShenyuanAPC_Nianqishi_Action_node2()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012727 RID: 75559 RVA: 0x005651B8 File Offset: 0x005635B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C114 RID: 49428
		private int opl_p0;

		// Token: 0x0400C115 RID: 49429
		private int opl_p1;

		// Token: 0x0400C116 RID: 49430
		private int opl_p2;

		// Token: 0x0400C117 RID: 49431
		private int opl_p3;
	}
}
