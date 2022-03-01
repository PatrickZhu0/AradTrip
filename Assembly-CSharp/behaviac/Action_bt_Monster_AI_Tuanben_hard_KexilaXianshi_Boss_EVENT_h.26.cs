using System;

namespace behaviac
{
	// Token: 0x02003CED RID: 15597
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node109 : Action
	{
		// Token: 0x0601617B RID: 90491 RVA: 0x006ACEF6 File Offset: 0x006AB2F6
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node109()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x0601617C RID: 90492 RVA: 0x006ACF22 File Offset: 0x006AB322
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA1B RID: 64027
		private string method_p0;

		// Token: 0x0400FA1C RID: 64028
		private float method_p1;

		// Token: 0x0400FA1D RID: 64029
		private int method_p2;
	}
}
