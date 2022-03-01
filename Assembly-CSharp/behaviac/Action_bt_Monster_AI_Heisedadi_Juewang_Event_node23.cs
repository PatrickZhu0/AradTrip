using System;

namespace behaviac
{
	// Token: 0x0200348D RID: 13453
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node23 : Action
	{
		// Token: 0x06015163 RID: 86371 RVA: 0x0065A5AE File Offset: 0x006589AE
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node23()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1500;
			this.method_p1 = 2;
		}

		// Token: 0x06015164 RID: 86372 RVA: 0x0065A5D0 File Offset: 0x006589D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA60 RID: 60000
		private int method_p0;

		// Token: 0x0400EA61 RID: 60001
		private int method_p1;
	}
}
