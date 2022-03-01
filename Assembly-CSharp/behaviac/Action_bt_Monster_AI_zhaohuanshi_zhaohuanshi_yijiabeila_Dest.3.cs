using System;

namespace behaviac
{
	// Token: 0x02004016 RID: 16406
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node14 : Action
	{
		// Token: 0x0601678F RID: 92047 RVA: 0x006CD1A9 File Offset: 0x006CB5A9
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_yijiabeila_DestinationSelect_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06016790 RID: 92048 RVA: 0x006CD1BF File Offset: 0x006CB5BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFDF RID: 65503
		private DestinationType method_p0;
	}
}
