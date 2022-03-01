using System;

namespace behaviac
{
	// Token: 0x020033F2 RID: 13298
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node6 : Action
	{
		// Token: 0x06015037 RID: 86071 RVA: 0x00654CE3 File Offset: 0x006530E3
		public Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015038 RID: 86072 RVA: 0x00654CF9 File Offset: 0x006530F9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E924 RID: 59684
		private DestinationType method_p0;
	}
}
