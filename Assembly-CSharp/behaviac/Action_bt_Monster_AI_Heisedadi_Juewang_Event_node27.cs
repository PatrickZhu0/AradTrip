using System;

namespace behaviac
{
	// Token: 0x02003490 RID: 13456
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node27 : Action
	{
		// Token: 0x06015169 RID: 86377 RVA: 0x0065A67E File Offset: 0x00658A7E
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1500;
			this.method_p1 = 3;
		}

		// Token: 0x0601516A RID: 86378 RVA: 0x0065A6A0 File Offset: 0x00658AA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA65 RID: 60005
		private int method_p0;

		// Token: 0x0400EA66 RID: 60006
		private int method_p1;
	}
}
