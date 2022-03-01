using System;

namespace behaviac
{
	// Token: 0x0200330C RID: 13068
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node18 : Action
	{
		// Token: 0x06014E81 RID: 85633 RVA: 0x0064CADB File Offset: 0x0064AEDB
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node18()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "疼疼疼！";
			this.method_p1 = 3f;
			this.method_p2 = 0;
		}

		// Token: 0x06014E82 RID: 85634 RVA: 0x0064CB07 File Offset: 0x0064AF07
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E76B RID: 59243
		private string method_p0;

		// Token: 0x0400E76C RID: 59244
		private float method_p1;

		// Token: 0x0400E76D RID: 59245
		private int method_p2;
	}
}
