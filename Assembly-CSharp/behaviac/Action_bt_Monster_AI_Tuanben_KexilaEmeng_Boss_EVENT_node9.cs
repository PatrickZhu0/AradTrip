using System;

namespace behaviac
{
	// Token: 0x02003A02 RID: 14850
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node9 : Action
	{
		// Token: 0x06015BD2 RID: 89042 RVA: 0x00690D7D File Offset: 0x0068F17D
		public Action_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
			this.method_p1 = 2;
		}

		// Token: 0x06015BD3 RID: 89043 RVA: 0x00690D9A File Offset: 0x0068F19A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4FB RID: 62715
		private int method_p0;

		// Token: 0x0400F4FC RID: 62716
		private int method_p1;
	}
}
