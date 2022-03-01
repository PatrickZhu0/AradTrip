using System;

namespace behaviac
{
	// Token: 0x02003A97 RID: 14999
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node100 : Action
	{
		// Token: 0x06015CF2 RID: 89330 RVA: 0x00696CF2 File Offset: 0x006950F2
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node100()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06015CF3 RID: 89331 RVA: 0x00696D1E File Offset: 0x0069511E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F624 RID: 63012
		private string method_p0;

		// Token: 0x0400F625 RID: 63013
		private float method_p1;

		// Token: 0x0400F626 RID: 63014
		private int method_p2;
	}
}
