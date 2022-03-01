using System;

namespace behaviac
{
	// Token: 0x02002EAA RID: 11946
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node38 : Action
	{
		// Token: 0x0601462F RID: 83503 RVA: 0x0062111D File Offset: 0x0061F51D
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node38()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570308;
		}

		// Token: 0x06014630 RID: 83504 RVA: 0x0062113E File Offset: 0x0061F53E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFA5 RID: 57253
		private BE_Target method_p0;

		// Token: 0x0400DFA6 RID: 57254
		private int method_p1;
	}
}
