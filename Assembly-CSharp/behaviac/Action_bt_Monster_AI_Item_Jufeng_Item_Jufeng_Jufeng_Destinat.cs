using System;

namespace behaviac
{
	// Token: 0x02003577 RID: 13687
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node1 : Action
	{
		// Token: 0x06015322 RID: 86818 RVA: 0x006636FC File Offset: 0x00661AFC
		public Action_bt_Monster_AI_Item_Jufeng_Item_Jufeng_Jufeng_DestinationSelect_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET;
		}

		// Token: 0x06015323 RID: 86819 RVA: 0x00663712 File Offset: 0x00661B12
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECE3 RID: 60643
		private DestinationType method_p0;
	}
}
