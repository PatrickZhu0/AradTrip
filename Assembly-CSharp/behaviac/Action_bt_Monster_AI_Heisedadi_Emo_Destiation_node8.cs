using System;

namespace behaviac
{
	// Token: 0x020033FF RID: 13311
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node8 : Action
	{
		// Token: 0x06015050 RID: 86096 RVA: 0x0065536B File Offset: 0x0065376B
		public Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015051 RID: 86097 RVA: 0x00655381 File Offset: 0x00653781
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E934 RID: 59700
		private DestinationType method_p0;
	}
}
