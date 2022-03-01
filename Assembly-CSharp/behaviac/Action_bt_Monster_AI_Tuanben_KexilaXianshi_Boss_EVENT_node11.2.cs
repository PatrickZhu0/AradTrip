using System;

namespace behaviac
{
	// Token: 0x02003A91 RID: 14993
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node114 : Action
	{
		// Token: 0x06015CE7 RID: 89319 RVA: 0x00696B7E File Offset: 0x00694F7E
		public Action_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node114()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "你欺负人！";
			this.method_p1 = 2.5f;
			this.method_p2 = 0;
		}

		// Token: 0x06015CE8 RID: 89320 RVA: 0x00696BAA File Offset: 0x00694FAA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F61B RID: 63003
		private string method_p0;

		// Token: 0x0400F61C RID: 63004
		private float method_p1;

		// Token: 0x0400F61D RID: 63005
		private int method_p2;
	}
}
