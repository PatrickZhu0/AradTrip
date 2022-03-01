using System;

namespace behaviac
{
	// Token: 0x0200339B RID: 13211
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node7 : Action
	{
		// Token: 0x06014F91 RID: 85905 RVA: 0x00651A6A File Offset: 0x0064FE6A
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node7()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x06014F92 RID: 85906 RVA: 0x00651A8C File Offset: 0x0064FE8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E86C RID: 59500
		private int method_p0;

		// Token: 0x0400E86D RID: 59501
		private int method_p1;
	}
}
