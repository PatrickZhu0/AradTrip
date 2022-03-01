using System;

namespace behaviac
{
	// Token: 0x02003B03 RID: 15107
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node2 : Action
	{
		// Token: 0x06015DC1 RID: 89537 RVA: 0x0069AF8A File Offset: 0x0069938A
		public Action_bt_Monster_AI_Tuanben_Monster_Hongxiaoyurenheti_des_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DC2 RID: 89538 RVA: 0x0069AFA1 File Offset: 0x006993A1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6B9 RID: 63161
		private DestinationType method_p0;
	}
}
