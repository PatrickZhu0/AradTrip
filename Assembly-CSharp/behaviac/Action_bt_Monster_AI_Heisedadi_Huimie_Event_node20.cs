using System;

namespace behaviac
{
	// Token: 0x02003432 RID: 13362
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node20 : Action
	{
		// Token: 0x060150B2 RID: 86194 RVA: 0x00656E22 File Offset: 0x00655222
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node20()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 20000;
			this.method_p1 = 3;
		}

		// Token: 0x060150B3 RID: 86195 RVA: 0x00656E44 File Offset: 0x00655244
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E987 RID: 59783
		private int method_p0;

		// Token: 0x0400E988 RID: 59784
		private int method_p1;
	}
}
