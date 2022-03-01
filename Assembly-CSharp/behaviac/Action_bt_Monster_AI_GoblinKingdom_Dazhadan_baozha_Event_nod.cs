using System;

namespace behaviac
{
	// Token: 0x020032D7 RID: 13015
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node5 : Action
	{
		// Token: 0x06014E1E RID: 85534 RVA: 0x0064ABF1 File Offset: 0x00648FF1
		public Action_bt_Monster_AI_GoblinKingdom_Dazhadan_baozha_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 9000;
			this.method_p1 = 0;
		}

		// Token: 0x06014E1F RID: 85535 RVA: 0x0064AC14 File Offset: 0x00649014
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E6FC RID: 59132
		private int method_p0;

		// Token: 0x0400E6FD RID: 59133
		private int method_p1;
	}
}
