using System;

namespace behaviac
{
	// Token: 0x0200325D RID: 12893
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node17 : Action
	{
		// Token: 0x06014D39 RID: 85305 RVA: 0x00646249 File Offset: 0x00644649
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node17()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "注意，大魔王在附近，请注意躲避攻击！";
			this.method_p1 = 3f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D3A RID: 85306 RVA: 0x00646275 File Offset: 0x00644675
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E67D RID: 59005
		private string method_p0;

		// Token: 0x0400E67E RID: 59006
		private float method_p1;

		// Token: 0x0400E67F RID: 59007
		private int method_p2;
	}
}
