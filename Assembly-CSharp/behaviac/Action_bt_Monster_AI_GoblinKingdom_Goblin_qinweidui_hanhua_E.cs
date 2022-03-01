using System;

namespace behaviac
{
	// Token: 0x02003354 RID: 13140
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node11 : Action
	{
		// Token: 0x06014F08 RID: 85768 RVA: 0x0064F337 File Offset: 0x0064D737
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2100;
			this.method_p1 = 0;
		}

		// Token: 0x06014F09 RID: 85769 RVA: 0x0064F358 File Offset: 0x0064D758
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E7E7 RID: 59367
		private int method_p0;

		// Token: 0x0400E7E8 RID: 59368
		private int method_p1;
	}
}
