using System;

namespace behaviac
{
	// Token: 0x02003A81 RID: 14977
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node10 : Action
	{
		// Token: 0x06015CC9 RID: 89289 RVA: 0x00696620 File Offset: 0x00694A20
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_DESTINATIONSELET_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.FOLLOW;
		}

		// Token: 0x06015CCA RID: 89290 RVA: 0x00696636 File Offset: 0x00694A36
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F605 RID: 62981
		private DestinationType method_p0;
	}
}
