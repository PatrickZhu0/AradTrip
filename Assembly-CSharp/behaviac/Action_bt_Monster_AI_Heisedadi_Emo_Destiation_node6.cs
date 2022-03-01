using System;

namespace behaviac
{
	// Token: 0x020033FD RID: 13309
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node6 : Action
	{
		// Token: 0x0601504C RID: 86092 RVA: 0x006552FB File Offset: 0x006536FB
		public Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601504D RID: 86093 RVA: 0x00655311 File Offset: 0x00653711
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E932 RID: 59698
		private DestinationType method_p0;
	}
}
