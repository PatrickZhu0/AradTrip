using System;

namespace behaviac
{
	// Token: 0x02003403 RID: 13315
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node7 : Action
	{
		// Token: 0x06015058 RID: 86104 RVA: 0x0065544B File Offset: 0x0065384B
		public Action_bt_Monster_AI_Heisedadi_Emo_Destiation_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06015059 RID: 86105 RVA: 0x00655461 File Offset: 0x00653861
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E938 RID: 59704
		private DestinationType method_p0;
	}
}
