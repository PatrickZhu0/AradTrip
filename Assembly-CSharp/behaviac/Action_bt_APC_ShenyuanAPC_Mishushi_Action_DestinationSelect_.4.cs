using System;

namespace behaviac
{
	// Token: 0x02001EA9 RID: 7849
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node16 : Action
	{
		// Token: 0x060126FB RID: 75515 RVA: 0x00564595 File Offset: 0x00562995
		public Action_bt_APC_ShenyuanAPC_Mishushi_Action_DestinationSelect_node16()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.ESCAPE;
		}

		// Token: 0x060126FC RID: 75516 RVA: 0x005645AB File Offset: 0x005629AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0EA RID: 49386
		private DestinationType method_p0;
	}
}
