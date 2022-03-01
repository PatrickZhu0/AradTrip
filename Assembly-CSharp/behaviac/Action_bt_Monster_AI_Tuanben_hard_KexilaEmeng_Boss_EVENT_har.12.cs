using System;

namespace behaviac
{
	// Token: 0x02003BD9 RID: 15321
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node44 : Action
	{
		// Token: 0x06015F5F RID: 89951 RVA: 0x006A2C3F File Offset: 0x006A103F
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570218;
		}

		// Token: 0x06015F60 RID: 89952 RVA: 0x006A2C60 File Offset: 0x006A1060
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7FA RID: 63482
		private BE_Target method_p0;

		// Token: 0x0400F7FB RID: 63483
		private int method_p1;
	}
}
