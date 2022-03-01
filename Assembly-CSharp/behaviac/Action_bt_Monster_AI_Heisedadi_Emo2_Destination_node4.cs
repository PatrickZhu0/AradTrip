using System;

namespace behaviac
{
	// Token: 0x020033F0 RID: 13296
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node4 : Action
	{
		// Token: 0x06015033 RID: 86067 RVA: 0x00654C57 File Offset: 0x00653057
		public Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015034 RID: 86068 RVA: 0x00654C6D File Offset: 0x0065306D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E920 RID: 59680
		private DestinationType method_p0;
	}
}
