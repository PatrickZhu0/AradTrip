using System;

namespace behaviac
{
	// Token: 0x02003AF0 RID: 15088
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node3 : Action
	{
		// Token: 0x06015D9D RID: 89501 RVA: 0x0069A543 File Offset: 0x00698943
		public Action_bt_Monster_AI_Tuanben_Monster_Baixiaoyurenheti_des_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 80020011;
			this.method_p1 = false;
		}

		// Token: 0x06015D9E RID: 89502 RVA: 0x0069A564 File Offset: 0x00698964
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AssignAITarget(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F6A2 RID: 63138
		private int method_p0;

		// Token: 0x0400F6A3 RID: 63139
		private bool method_p1;
	}
}
