using System;

namespace behaviac
{
	// Token: 0x02003FC9 RID: 16329
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node19 : Action
	{
		// Token: 0x060166FB RID: 91899 RVA: 0x006C9D3D File Offset: 0x006C813D
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_DestinationSelect_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x060166FC RID: 91900 RVA: 0x006C9D53 File Offset: 0x006C8153
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF4E RID: 65358
		private DestinationType method_p0;
	}
}
