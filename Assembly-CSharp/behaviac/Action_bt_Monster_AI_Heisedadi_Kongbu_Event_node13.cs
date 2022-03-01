using System;

namespace behaviac
{
	// Token: 0x020034AB RID: 13483
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node13 : Action
	{
		// Token: 0x0601519C RID: 86428 RVA: 0x0065BDFE File Offset: 0x0065A1FE
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node13()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 300;
			this.method_p1 = 3;
		}

		// Token: 0x0601519D RID: 86429 RVA: 0x0065BE20 File Offset: 0x0065A220
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EA9D RID: 60061
		private int method_p0;

		// Token: 0x0400EA9E RID: 60062
		private int method_p1;
	}
}
