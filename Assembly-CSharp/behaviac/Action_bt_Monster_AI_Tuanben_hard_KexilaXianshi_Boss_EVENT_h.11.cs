using System;

namespace behaviac
{
	// Token: 0x02003CCA RID: 15562
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node45 : Action
	{
		// Token: 0x06016136 RID: 90422 RVA: 0x006AC646 File Offset: 0x006AAA46
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06016137 RID: 90423 RVA: 0x006AC667 File Offset: 0x006AAA67
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9E6 RID: 63974
		private BE_Target method_p0;

		// Token: 0x0400F9E7 RID: 63975
		private int method_p1;
	}
}
