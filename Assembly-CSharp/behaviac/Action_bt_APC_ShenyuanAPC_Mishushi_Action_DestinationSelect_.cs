using System;

namespace behaviac
{
	// Token: 0x02001EA2 RID: 7842
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3 : Action
	{
		// Token: 0x060126ED RID: 75501 RVA: 0x0056435B File Offset: 0x0056275B
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.KEEP_DISTANCE;
		}

		// Token: 0x060126EE RID: 75502 RVA: 0x00564371 File Offset: 0x00562771
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0DA RID: 49370
		private DestinationType method_p0;
	}
}
