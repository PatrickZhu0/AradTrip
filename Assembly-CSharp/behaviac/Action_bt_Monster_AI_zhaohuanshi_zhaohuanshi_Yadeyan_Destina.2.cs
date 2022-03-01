using System;

namespace behaviac
{
	// Token: 0x02003FFC RID: 16380
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node9 : Action
	{
		// Token: 0x0601675D RID: 91997 RVA: 0x006CC171 File Offset: 0x006CA571
		public Action_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Yadeyan_DestinationSelect_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.BYPASS_TRACK;
		}

		// Token: 0x0601675E RID: 91998 RVA: 0x006CC187 File Offset: 0x006CA587
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFAE RID: 65454
		private DestinationType method_p0;
	}
}
