using System;

namespace behaviac
{
	// Token: 0x02002BAA RID: 11178
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node8 : Action
	{
		// Token: 0x0601405C RID: 82012 RVA: 0x006036EB File Offset: 0x00601AEB
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Green_Destination_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601405D RID: 82013 RVA: 0x00603701 File Offset: 0x00601B01
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA56 RID: 55894
		private DestinationType method_p0;
	}
}
