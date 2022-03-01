using System;

namespace behaviac
{
	// Token: 0x02003CE9 RID: 15593
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node106 : Action
	{
		// Token: 0x06016173 RID: 90483 RVA: 0x006ACE06 File Offset: 0x006AB206
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node106()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06016174 RID: 90484 RVA: 0x006ACE32 File Offset: 0x006AB232
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA17 RID: 64023
		private string method_p0;

		// Token: 0x0400FA18 RID: 64024
		private float method_p1;

		// Token: 0x0400FA19 RID: 64025
		private int method_p2;
	}
}
