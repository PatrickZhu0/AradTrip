using System;

namespace behaviac
{
	// Token: 0x02004031 RID: 16433
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node6 : Action
	{
		// Token: 0x060167C2 RID: 92098 RVA: 0x006CE50D File Offset: 0x006CC90D
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060167C3 RID: 92099 RVA: 0x006CE523 File Offset: 0x006CC923
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401000F RID: 65551
		private DestinationType method_p0;
	}
}
