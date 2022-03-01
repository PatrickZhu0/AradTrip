using System;

namespace behaviac
{
	// Token: 0x02003BD5 RID: 15317
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node45 : Action
	{
		// Token: 0x06015F57 RID: 89943 RVA: 0x006A2B0A File Offset: 0x006A0F0A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06015F58 RID: 89944 RVA: 0x006A2B2B File Offset: 0x006A0F2B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7F1 RID: 63473
		private BE_Target method_p0;

		// Token: 0x0400F7F2 RID: 63474
		private int method_p1;
	}
}
