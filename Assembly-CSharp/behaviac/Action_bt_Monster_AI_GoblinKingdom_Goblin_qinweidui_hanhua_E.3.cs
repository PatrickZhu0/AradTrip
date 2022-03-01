using System;

namespace behaviac
{
	// Token: 0x02003358 RID: 13144
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4 : Action
	{
		// Token: 0x06014F10 RID: 85776 RVA: 0x0064F45B File Offset: 0x0064D85B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2100;
			this.method_p1 = 0;
		}

		// Token: 0x06014F11 RID: 85777 RVA: 0x0064F47C File Offset: 0x0064D87C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E7EE RID: 59374
		private int method_p0;

		// Token: 0x0400E7EF RID: 59375
		private int method_p1;
	}
}
