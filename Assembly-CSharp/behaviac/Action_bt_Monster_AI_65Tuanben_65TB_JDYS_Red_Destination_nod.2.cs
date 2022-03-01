using System;

namespace behaviac
{
	// Token: 0x02002BB6 RID: 11190
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node2 : Action
	{
		// Token: 0x06014072 RID: 82034 RVA: 0x00603F25 File Offset: 0x00602325
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06014073 RID: 82035 RVA: 0x00603F3B File Offset: 0x0060233B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA6D RID: 55917
		private DestinationType method_p0;
	}
}
