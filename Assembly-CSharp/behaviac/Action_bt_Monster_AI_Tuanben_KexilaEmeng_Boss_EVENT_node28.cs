using System;

namespace behaviac
{
	// Token: 0x02003A0C RID: 14860
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node28 : Action
	{
		// Token: 0x06015BE5 RID: 89061 RVA: 0x00690FA6 File Offset: 0x0068F3A6
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
			this.method_p1 = 1;
		}

		// Token: 0x06015BE6 RID: 89062 RVA: 0x00690FC3 File Offset: 0x0068F3C3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F506 RID: 62726
		private int method_p0;

		// Token: 0x0400F507 RID: 62727
		private int method_p1;
	}
}
