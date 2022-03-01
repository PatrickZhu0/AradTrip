using System;

namespace behaviac
{
	// Token: 0x02003356 RID: 13142
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node1 : Action
	{
		// Token: 0x06014F0C RID: 85772 RVA: 0x0064F3C7 File Offset: 0x0064D7C7
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_qinweidui_hanhua_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "公主快进来！";
			this.method_p1 = 3f;
			this.method_p2 = 1;
		}

		// Token: 0x06014F0D RID: 85773 RVA: 0x0064F3F3 File Offset: 0x0064D7F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7EA RID: 59370
		private string method_p0;

		// Token: 0x0400E7EB RID: 59371
		private float method_p1;

		// Token: 0x0400E7EC RID: 59372
		private int method_p2;
	}
}
