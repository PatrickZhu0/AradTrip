using System;

namespace behaviac
{
	// Token: 0x02001E6E RID: 7790
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node18 : Action
	{
		// Token: 0x06012688 RID: 75400 RVA: 0x00561B32 File Offset: 0x0055FF32
		public Action_bt_APC_ShenyuanAPC_Kuangzhan2_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 1000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x06012689 RID: 75401 RVA: 0x00561B6D File Offset: 0x0055FF6D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C070 RID: 49264
		private int method_p0;

		// Token: 0x0400C071 RID: 49265
		private int method_p1;

		// Token: 0x0400C072 RID: 49266
		private int method_p2;

		// Token: 0x0400C073 RID: 49267
		private int method_p3;
	}
}
