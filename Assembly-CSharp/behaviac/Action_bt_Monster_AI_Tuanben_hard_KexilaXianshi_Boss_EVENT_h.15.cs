using System;

namespace behaviac
{
	// Token: 0x02003CD0 RID: 15568
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node67 : Action
	{
		// Token: 0x06016142 RID: 90434 RVA: 0x006AC7F1 File Offset: 0x006AABF1
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node67()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，超级强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016143 RID: 90435 RVA: 0x006AC81D File Offset: 0x006AAC1D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9F3 RID: 63987
		private string method_p0;

		// Token: 0x0400F9F4 RID: 63988
		private float method_p1;

		// Token: 0x0400F9F5 RID: 63989
		private int method_p2;
	}
}
