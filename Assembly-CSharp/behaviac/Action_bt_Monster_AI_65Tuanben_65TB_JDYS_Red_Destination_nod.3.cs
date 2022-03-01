using System;

namespace behaviac
{
	// Token: 0x02002BB7 RID: 11191
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node8 : Action
	{
		// Token: 0x06014074 RID: 82036 RVA: 0x00603F4F File Offset: 0x0060234F
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x06014075 RID: 82037 RVA: 0x00603F65 File Offset: 0x00602365
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA6E RID: 55918
		private DestinationType method_p0;
	}
}
