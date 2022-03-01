using System;

namespace behaviac
{
	// Token: 0x020032A0 RID: 12960
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node5 : Action
	{
		// Token: 0x06014DB7 RID: 85431 RVA: 0x00648673 File Offset: 0x00646A73
		public Action_bt_Monster_AI_EZ8_zibaozhe_EZ8_zibaozhe_EZ8_DestinationSelect_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x06014DB8 RID: 85432 RVA: 0x00648689 File Offset: 0x00646A89
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E6AB RID: 59051
		private DestinationType method_p0;
	}
}
