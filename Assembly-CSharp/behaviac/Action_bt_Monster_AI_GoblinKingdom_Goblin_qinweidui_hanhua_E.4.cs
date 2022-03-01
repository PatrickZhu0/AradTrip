using System;

namespace behaviac
{
	// Token: 0x0200335A RID: 13146
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node8 : Action
	{
		// Token: 0x06014F14 RID: 85780 RVA: 0x0064F4EB File Offset: 0x0064D8EB
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "无敌保护罩！";
			this.method_p1 = 3f;
			this.method_p2 = 1;
		}

		// Token: 0x06014F15 RID: 85781 RVA: 0x0064F517 File Offset: 0x0064D917
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7F1 RID: 59377
		private string method_p0;

		// Token: 0x0400E7F2 RID: 59378
		private float method_p1;

		// Token: 0x0400E7F3 RID: 59379
		private int method_p2;
	}
}
