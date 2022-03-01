using System;

namespace behaviac
{
	// Token: 0x020033A0 RID: 13216
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node14 : Action
	{
		// Token: 0x06014F9B RID: 85915 RVA: 0x00651C66 File Offset: 0x00650066
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_skill_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 1;
		}

		// Token: 0x06014F9C RID: 85916 RVA: 0x00651C88 File Offset: 0x00650088
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E876 RID: 59510
		private int method_p0;

		// Token: 0x0400E877 RID: 59511
		private int method_p1;
	}
}
