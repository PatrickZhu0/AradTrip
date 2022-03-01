using System;

namespace behaviac
{
	// Token: 0x02003AA3 RID: 15011
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node109 : Action
	{
		// Token: 0x06015D0A RID: 89354 RVA: 0x00696FC2 File Offset: 0x006953C2
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node109()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06015D0B RID: 89355 RVA: 0x00696FEE File Offset: 0x006953EE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F630 RID: 63024
		private string method_p0;

		// Token: 0x0400F631 RID: 63025
		private float method_p1;

		// Token: 0x0400F632 RID: 63026
		private int method_p2;
	}
}
