using System;

namespace behaviac
{
	// Token: 0x02003CDB RID: 15579
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node114 : Action
	{
		// Token: 0x06016158 RID: 90456 RVA: 0x006ACAB2 File Offset: 0x006AAEB2
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node114()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你欺负人！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06016159 RID: 90457 RVA: 0x006ACADE File Offset: 0x006AAEDE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA06 RID: 64006
		private string method_p0;

		// Token: 0x0400FA07 RID: 64007
		private float method_p1;

		// Token: 0x0400FA08 RID: 64008
		private int method_p2;
	}
}
