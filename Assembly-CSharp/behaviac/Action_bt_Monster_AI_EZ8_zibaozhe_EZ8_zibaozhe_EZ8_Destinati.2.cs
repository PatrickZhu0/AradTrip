using System;

namespace behaviac
{
	// Token: 0x020032A2 RID: 12962
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node6 : Action
	{
		// Token: 0x06014DBB RID: 85435 RVA: 0x006486E3 File Offset: 0x00646AE3
		public Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.WANDER;
		}

		// Token: 0x06014DBC RID: 85436 RVA: 0x006486F9 File Offset: 0x00646AF9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AD RID: 59053
		private DestinationType method_p0;
	}
}
