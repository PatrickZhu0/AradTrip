using System;

namespace behaviac
{
	// Token: 0x02003BDA RID: 15322
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node46 : Action
	{
		// Token: 0x06015F61 RID: 89953 RVA: 0x006A2C7A File Offset: 0x006A107A
		public Action_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_EVENT_hard_node46()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570214;
		}

		// Token: 0x06015F62 RID: 89954 RVA: 0x006A2C9B File Offset: 0x006A109B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F7FC RID: 63484
		private BE_Target method_p0;

		// Token: 0x0400F7FD RID: 63485
		private int method_p1;
	}
}
