using System;

namespace behaviac
{
	// Token: 0x020032E3 RID: 13027
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node18 : Action
	{
		// Token: 0x06014E34 RID: 85556 RVA: 0x0064B057 File Offset: 0x00649457
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "快把门关上！别送！";
			this.method_p1 = 5f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E35 RID: 85557 RVA: 0x0064B083 File Offset: 0x00649483
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E714 RID: 59156
		private string method_p0;

		// Token: 0x0400E715 RID: 59157
		private float method_p1;

		// Token: 0x0400E716 RID: 59158
		private int method_p2;
	}
}
