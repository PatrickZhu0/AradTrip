using System;

namespace behaviac
{
	// Token: 0x02003A83 RID: 14979
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node0 : Action
	{
		// Token: 0x06015CCD RID: 89293 RVA: 0x006966AB File Offset: 0x00694AAB
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.Y_FIRST;
		}

		// Token: 0x06015CCE RID: 89294 RVA: 0x006966C1 File Offset: 0x00694AC1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F609 RID: 62985
		private DestinationType method_p0;
	}
}
