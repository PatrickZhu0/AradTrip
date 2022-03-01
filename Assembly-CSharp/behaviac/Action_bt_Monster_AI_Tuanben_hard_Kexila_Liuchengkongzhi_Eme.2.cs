using System;

namespace behaviac
{
	// Token: 0x02003CF4 RID: 15604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node40 : Action
	{
		// Token: 0x06016187 RID: 90503 RVA: 0x006ADFFA File Offset: 0x006AC3FA
		public Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06016188 RID: 90504 RVA: 0x006AE017 File Offset: 0x006AC417
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA23 RID: 64035
		private int method_p0;

		// Token: 0x0400FA24 RID: 64036
		private int method_p1;
	}
}
