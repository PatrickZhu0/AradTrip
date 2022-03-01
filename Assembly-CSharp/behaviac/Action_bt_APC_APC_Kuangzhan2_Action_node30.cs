using System;

namespace behaviac
{
	// Token: 0x02001D8A RID: 7562
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node30 : Action
	{
		// Token: 0x060124CF RID: 74959 RVA: 0x00557332 File Offset: 0x00555732
		public Action_bt_APC_APC_Kuangzhan2_Action_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 2000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x060124D0 RID: 74960 RVA: 0x0055736D File Offset: 0x0055576D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEBA RID: 48826
		private int method_p0;

		// Token: 0x0400BEBB RID: 48827
		private int method_p1;

		// Token: 0x0400BEBC RID: 48828
		private int method_p2;

		// Token: 0x0400BEBD RID: 48829
		private int method_p3;
	}
}
