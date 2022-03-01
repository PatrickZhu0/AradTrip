using System;

namespace behaviac
{
	// Token: 0x0200355F RID: 13663
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node1 : Action
	{
		// Token: 0x060152FA RID: 86778 RVA: 0x00662AF8 File Offset: 0x00660EF8
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_02_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 100000;
			this.method_p1 = 0;
		}

		// Token: 0x060152FB RID: 86779 RVA: 0x00662B1C File Offset: 0x00660F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400ECAC RID: 60588
		private int method_p0;

		// Token: 0x0400ECAD RID: 60589
		private int method_p1;
	}
}
