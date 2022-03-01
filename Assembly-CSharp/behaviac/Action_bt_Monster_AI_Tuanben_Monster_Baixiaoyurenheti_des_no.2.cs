using System;

namespace behaviac
{
	// Token: 0x02003AF1 RID: 15089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node2 : Action
	{
		// Token: 0x06015D9F RID: 89503 RVA: 0x0069A57E File Offset: 0x0069897E
		public Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = DestinationType.GO_TO_TARGET2;
		}

		// Token: 0x06015DA0 RID: 89504 RVA: 0x0069A595 File Offset: 0x00698995
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_DoDestinationSelect(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A4 RID: 63140
		private DestinationType method_p0;
	}
}
