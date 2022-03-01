using System;

namespace behaviac
{
	// Token: 0x02003CF9 RID: 15609
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node14 : Action
	{
		// Token: 0x06016191 RID: 90513 RVA: 0x006AE1AA File Offset: 0x006AC5AA
		public Action_bt_Monster_AI_Tuanben_hard_Kexila_Liuchengkongzhi_Emeng_hard_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 1;
		}

		// Token: 0x06016192 RID: 90514 RVA: 0x006AE1C7 File Offset: 0x006AC5C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA2A RID: 64042
		private int method_p0;

		// Token: 0x0400FA2B RID: 64043
		private int method_p1;
	}
}
