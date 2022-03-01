using System;

namespace behaviac
{
	// Token: 0x02003261 RID: 12897
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node21 : Action
	{
		// Token: 0x06014D41 RID: 85313 RVA: 0x0064633B File Offset: 0x0064473B
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "获得了魔王护符，附近的大魔王无法攻击到你！";
			this.method_p1 = 3f;
			this.method_p2 = 2;
		}

		// Token: 0x06014D42 RID: 85314 RVA: 0x00646367 File Offset: 0x00644767
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E681 RID: 59009
		private string method_p0;

		// Token: 0x0400E682 RID: 59010
		private float method_p1;

		// Token: 0x0400E683 RID: 59011
		private int method_p2;
	}
}
