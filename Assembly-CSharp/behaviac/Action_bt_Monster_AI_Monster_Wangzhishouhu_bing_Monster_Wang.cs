using System;

namespace behaviac
{
	// Token: 0x020036EE RID: 14062
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node1 : Action
	{
		// Token: 0x060155EF RID: 87535 RVA: 0x00672B78 File Offset: 0x00670F78
		public Action_bt_Monster_AI_Monster_Wangzhishouhu_bing_Monster_Wangzhishouhu_bing_Gunman_DestinationSelect_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060155F0 RID: 87536 RVA: 0x00672B8E File Offset: 0x00670F8E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFC0 RID: 61376
		private DestinationType method_p0;
	}
}
