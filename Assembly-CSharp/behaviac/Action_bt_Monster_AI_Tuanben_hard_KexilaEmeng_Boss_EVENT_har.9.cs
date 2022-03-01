using System;

namespace behaviac
{
	// Token: 0x02003BD4 RID: 15316
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node41 : Action
	{
		// Token: 0x06015F55 RID: 89941 RVA: 0x006A2ACF File Offset: 0x006A0ECF
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570215;
		}

		// Token: 0x06015F56 RID: 89942 RVA: 0x006A2AF0 File Offset: 0x006A0EF0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7EF RID: 63471
		private BE_Target method_p0;

		// Token: 0x0400F7F0 RID: 63472
		private int method_p1;
	}
}
