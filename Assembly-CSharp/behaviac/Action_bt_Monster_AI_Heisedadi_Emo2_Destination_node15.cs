using System;

namespace behaviac
{
	// Token: 0x020033F6 RID: 13302
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node15 : Action
	{
		// Token: 0x0601503F RID: 86079 RVA: 0x00654DC3 File Offset: 0x006531C3
		public Action_bt_Monster_AI_Heisedadi_Emo2_Destination_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015040 RID: 86080 RVA: 0x00654DD9 File Offset: 0x006531D9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E928 RID: 59688
		private DestinationType method_p0;
	}
}
