using System;

namespace behaviac
{
	// Token: 0x02003BDF RID: 15327
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node30 : Action
	{
		// Token: 0x06015F6B RID: 89963 RVA: 0x006A2E07 File Offset: 0x006A1207
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 1;
		}

		// Token: 0x06015F6C RID: 89964 RVA: 0x006A2E24 File Offset: 0x006A1224
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F80A RID: 63498
		private int method_p0;

		// Token: 0x0400F80B RID: 63499
		private int method_p1;
	}
}
