using System;

namespace behaviac
{
	// Token: 0x02003998 RID: 14744
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node13 : Action
	{
		// Token: 0x06015B05 RID: 88837 RVA: 0x0068CF33 File Offset: 0x0068B333
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "接下来谁尝尝我炮弹的厉害呢！";
			this.method_p1 = 2f;
			this.method_p2 = 0;
		}

		// Token: 0x06015B06 RID: 88838 RVA: 0x0068CF5F File Offset: 0x0068B35F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F49C RID: 62620
		private string method_p0;

		// Token: 0x0400F49D RID: 62621
		private float method_p1;

		// Token: 0x0400F49E RID: 62622
		private int method_p2;
	}
}
