using System;

namespace behaviac
{
	// Token: 0x0200347C RID: 13436
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node36 : Action
	{
		// Token: 0x06015141 RID: 86337 RVA: 0x0065A0B1 File Offset: 0x006584B1
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node36()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 0;
		}

		// Token: 0x06015142 RID: 86338 RVA: 0x0065A0D4 File Offset: 0x006584D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA43 RID: 59971
		private int method_p0;

		// Token: 0x0400EA44 RID: 59972
		private int method_p1;
	}
}
