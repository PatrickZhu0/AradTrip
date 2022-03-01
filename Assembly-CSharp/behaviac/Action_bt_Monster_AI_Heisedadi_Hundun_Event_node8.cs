using System;

namespace behaviac
{
	// Token: 0x0200345C RID: 13404
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node8 : Action
	{
		// Token: 0x06015104 RID: 86276 RVA: 0x006587F6 File Offset: 0x00656BF6
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 2;
		}

		// Token: 0x06015105 RID: 86277 RVA: 0x00658818 File Offset: 0x00656C18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E9F6 RID: 59894
		private int method_p0;

		// Token: 0x0400E9F7 RID: 59895
		private int method_p1;
	}
}
