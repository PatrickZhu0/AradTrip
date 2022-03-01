using System;

namespace behaviac
{
	// Token: 0x02003558 RID: 13656
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node7 : Action
	{
		// Token: 0x060152EE RID: 86766 RVA: 0x00662707 File Offset: 0x00660B07
		public Action_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x060152EF RID: 86767 RVA: 0x0066271D File Offset: 0x00660B1D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA2 RID: 60578
		private DestinationType method_p0;
	}
}
