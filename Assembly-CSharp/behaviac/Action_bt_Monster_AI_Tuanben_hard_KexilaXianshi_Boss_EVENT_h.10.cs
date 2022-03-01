using System;

namespace behaviac
{
	// Token: 0x02003CC9 RID: 15561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node41 : Action
	{
		// Token: 0x06016134 RID: 90420 RVA: 0x006AC60B File Offset: 0x006AAA0B
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x06016135 RID: 90421 RVA: 0x006AC62C File Offset: 0x006AAA2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9E4 RID: 63972
		private BE_Target method_p0;

		// Token: 0x0400F9E5 RID: 63973
		private int method_p1;
	}
}
