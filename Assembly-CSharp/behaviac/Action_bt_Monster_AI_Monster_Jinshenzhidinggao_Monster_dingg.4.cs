using System;

namespace behaviac
{
	// Token: 0x02003695 RID: 13973
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node8 : Action
	{
		// Token: 0x06015547 RID: 87367 RVA: 0x0066F223 File Offset: 0x0066D623
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.IDLE;
		}

		// Token: 0x06015548 RID: 87368 RVA: 0x0066F239 File Offset: 0x0066D639
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF0B RID: 61195
		private DestinationType method_p0;
	}
}
