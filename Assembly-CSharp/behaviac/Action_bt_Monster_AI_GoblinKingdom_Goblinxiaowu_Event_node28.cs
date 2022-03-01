using System;

namespace behaviac
{
	// Token: 0x020032DF RID: 13023
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node28 : Action
	{
		// Token: 0x06014E2C RID: 85548 RVA: 0x0064AF2F File Offset: 0x0064932F
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "哪个傻子设计的这破游戏...只能被虐一点都不有趣！";
			this.method_p1 = 5f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E2D RID: 85549 RVA: 0x0064AF5B File Offset: 0x0064935B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E70C RID: 59148
		private string method_p0;

		// Token: 0x0400E70D RID: 59149
		private float method_p1;

		// Token: 0x0400E70E RID: 59150
		private int method_p2;
	}
}
