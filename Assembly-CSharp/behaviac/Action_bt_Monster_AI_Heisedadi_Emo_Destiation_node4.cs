using System;

namespace behaviac
{
	// Token: 0x020033FB RID: 13307
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4 : Action
	{
		// Token: 0x06015048 RID: 86088 RVA: 0x0065526F File Offset: 0x0065366F
		public Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015049 RID: 86089 RVA: 0x00655285 File Offset: 0x00653685
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E92E RID: 59694
		private DestinationType method_p0;
	}
}
