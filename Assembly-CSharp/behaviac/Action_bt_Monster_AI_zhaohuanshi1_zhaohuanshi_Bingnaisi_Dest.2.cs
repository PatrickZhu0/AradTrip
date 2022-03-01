using System;

namespace behaviac
{
	// Token: 0x02004034 RID: 16436
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node9 : Action
	{
		// Token: 0x060167C8 RID: 92104 RVA: 0x006CE5F9 File Offset: 0x006CC9F9
		public Action_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Bingnaisi_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x060167C9 RID: 92105 RVA: 0x006CE60F File Offset: 0x006CCA0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010015 RID: 65557
		private DestinationType method_p0;
	}
}
