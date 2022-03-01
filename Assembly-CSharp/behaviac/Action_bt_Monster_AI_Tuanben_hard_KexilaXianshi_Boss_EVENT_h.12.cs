using System;

namespace behaviac
{
	// Token: 0x02003CCB RID: 15563
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node66 : Action
	{
		// Token: 0x06016138 RID: 90424 RVA: 0x006AC681 File Offset: 0x006AAA81
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node66()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "贝希摩斯之心已被击破，强化将消除。";
			this.method_p1 = 5f;
			this.method_p2 = 2;
		}

		// Token: 0x06016139 RID: 90425 RVA: 0x006AC6AD File Offset: 0x006AAAAD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9E8 RID: 63976
		private string method_p0;

		// Token: 0x0400F9E9 RID: 63977
		private float method_p1;

		// Token: 0x0400F9EA RID: 63978
		private int method_p2;
	}
}
