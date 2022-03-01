using System;

namespace behaviac
{
	// Token: 0x02003AF2 RID: 15090
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node6 : Action
	{
		// Token: 0x06015DA1 RID: 89505 RVA: 0x0069A5A9 File Offset: 0x006989A9
		public Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DA2 RID: 89506 RVA: 0x0069A5C0 File Offset: 0x006989C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A5 RID: 63141
		private DestinationType method_p0;
	}
}
