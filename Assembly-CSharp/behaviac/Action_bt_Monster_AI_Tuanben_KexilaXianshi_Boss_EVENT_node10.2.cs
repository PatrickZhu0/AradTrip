using System;

namespace behaviac
{
	// Token: 0x02003A9B RID: 15003
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node103 : Action
	{
		// Token: 0x06015CFA RID: 89338 RVA: 0x00696DE2 File Offset: 0x006951E2
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "讨厌！讨厌！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06015CFB RID: 89339 RVA: 0x00696E0E File Offset: 0x0069520E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F628 RID: 63016
		private string method_p0;

		// Token: 0x0400F629 RID: 63017
		private float method_p1;

		// Token: 0x0400F62A RID: 63018
		private int method_p2;
	}
}
