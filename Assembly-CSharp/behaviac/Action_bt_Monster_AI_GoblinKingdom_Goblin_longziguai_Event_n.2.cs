using System;

namespace behaviac
{
	// Token: 0x0200334E RID: 13134
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node11 : Action
	{
		// Token: 0x06014EFE RID: 85758 RVA: 0x0064F05B File Offset: 0x0064D45B
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1200;
			this.method_p1 = 0;
		}

		// Token: 0x06014EFF RID: 85759 RVA: 0x0064F07C File Offset: 0x0064D47C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E7DA RID: 59354
		private int method_p0;

		// Token: 0x0400E7DB RID: 59355
		private int method_p1;
	}
}
