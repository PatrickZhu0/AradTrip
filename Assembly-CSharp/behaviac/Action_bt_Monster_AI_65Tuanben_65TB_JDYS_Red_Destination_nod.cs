using System;

namespace behaviac
{
	// Token: 0x02002BB4 RID: 11188
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node6 : Action
	{
		// Token: 0x0601406E RID: 82030 RVA: 0x00603E81 File Offset: 0x00602281
		public Action_bt_Monster_AI_65Tuanben_65TB_JDYS_Red_Destination_node6()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x0601406F RID: 82031 RVA: 0x00603E98 File Offset: 0x00602298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_INVALID;
		}

		// Token: 0x0400DA68 RID: 55912
		private DestinationType method_p0;
	}
}
