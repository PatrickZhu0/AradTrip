using System;

namespace behaviac
{
	// Token: 0x020032E9 RID: 13033
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node23 : Action
	{
		// Token: 0x06014E3F RID: 85567 RVA: 0x0064B21F File Offset: 0x0064961F
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "别怂！就是干！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E40 RID: 85568 RVA: 0x0064B24B File Offset: 0x0064964B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E723 RID: 59171
		private string method_p0;

		// Token: 0x0400E724 RID: 59172
		private float method_p1;

		// Token: 0x0400E725 RID: 59173
		private int method_p2;
	}
}
