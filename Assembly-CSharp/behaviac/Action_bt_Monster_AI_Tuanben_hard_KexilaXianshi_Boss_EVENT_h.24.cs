using System;

namespace behaviac
{
	// Token: 0x02003CE5 RID: 15589
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node103 : Action
	{
		// Token: 0x0601616B RID: 90475 RVA: 0x006ACD16 File Offset: 0x006AB116
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x0601616C RID: 90476 RVA: 0x006ACD42 File Offset: 0x006AB142
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA13 RID: 64019
		private string method_p0;

		// Token: 0x0400FA14 RID: 64020
		private float method_p1;

		// Token: 0x0400FA15 RID: 64021
		private int method_p2;
	}
}
