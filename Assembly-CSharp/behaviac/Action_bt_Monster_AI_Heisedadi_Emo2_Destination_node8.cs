using System;

namespace behaviac
{
	// Token: 0x020033F4 RID: 13300
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node8 : Action
	{
		// Token: 0x0601503B RID: 86075 RVA: 0x00654D53 File Offset: 0x00653153
		public Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x0601503C RID: 86076 RVA: 0x00654D69 File Offset: 0x00653169
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E926 RID: 59686
		private DestinationType method_p0;
	}
}
