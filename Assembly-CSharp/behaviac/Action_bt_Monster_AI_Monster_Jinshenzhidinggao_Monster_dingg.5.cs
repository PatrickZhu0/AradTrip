using System;

namespace behaviac
{
	// Token: 0x02003698 RID: 13976
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3 : Action
	{
		// Token: 0x0601554D RID: 87373 RVA: 0x0066F30F File Offset: 0x0066D70F
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x0601554E RID: 87374 RVA: 0x0066F325 File Offset: 0x0066D725
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF11 RID: 61201
		private DestinationType method_p0;
	}
}
