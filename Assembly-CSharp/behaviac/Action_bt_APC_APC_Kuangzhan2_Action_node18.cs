using System;

namespace behaviac
{
	// Token: 0x02001D8E RID: 7566
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Kuangzhan2_Action_node18 : Action
	{
		// Token: 0x060124D7 RID: 74967 RVA: 0x005574CE File Offset: 0x005558CE
		public Action_bt_APC_APC_Kuangzhan2_Action_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 6000;
			this.method_p1 = 1000;
			this.method_p2 = 3000;
			this.method_p3 = 3000;
		}

		// Token: 0x060124D8 RID: 74968 RVA: 0x00557509 File Offset: 0x00555909
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_EnemyNumberOfInAttackArea(this.method_p0, this.method_p1, this.method_p2, this.method_p3);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BEC2 RID: 48834
		private int method_p0;

		// Token: 0x0400BEC3 RID: 48835
		private int method_p1;

		// Token: 0x0400BEC4 RID: 48836
		private int method_p2;

		// Token: 0x0400BEC5 RID: 48837
		private int method_p3;
	}
}
