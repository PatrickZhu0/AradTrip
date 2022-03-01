using System;

namespace behaviac
{
	// Token: 0x02003D96 RID: 15766
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node4 : Action
	{
		// Token: 0x060162C0 RID: 90816 RVA: 0x006B4074 File Offset: 0x006B2474
		public Action_bt_Monster_AI_Tuanben_hard_Shuiren_Xiaoshuiqiu_hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x060162C1 RID: 90817 RVA: 0x006B408B File Offset: 0x006B248B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB10 RID: 64272
		private DestinationType method_p0;
	}
}
