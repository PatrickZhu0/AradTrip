using System;

namespace behaviac
{
	// Token: 0x02003CE1 RID: 15585
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node100 : Action
	{
		// Token: 0x06016163 RID: 90467 RVA: 0x006ACC26 File Offset: 0x006AB026
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node100()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06016164 RID: 90468 RVA: 0x006ACC52 File Offset: 0x006AB052
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA0F RID: 64015
		private string method_p0;

		// Token: 0x0400FA10 RID: 64016
		private float method_p1;

		// Token: 0x0400FA11 RID: 64017
		private int method_p2;
	}
}
