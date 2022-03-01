using System;

namespace behaviac
{
	// Token: 0x02001E6A RID: 7786
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node30 : Action
	{
		// Token: 0x06012680 RID: 75392 RVA: 0x00561996 File Offset: 0x0055FD96
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 2000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x06012681 RID: 75393 RVA: 0x005619D1 File Offset: 0x0055FDD1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C068 RID: 49256
		private int method_p0;

		// Token: 0x0400C069 RID: 49257
		private int method_p1;

		// Token: 0x0400C06A RID: 49258
		private int method_p2;

		// Token: 0x0400C06B RID: 49259
		private int method_p3;
	}
}
