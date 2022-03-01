using System;

namespace behaviac
{
	// Token: 0x02003968 RID: 14696
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node45 : Action
	{
		// Token: 0x06015AA7 RID: 88743 RVA: 0x0068B32A File Offset: 0x0068972A
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06015AA8 RID: 88744 RVA: 0x0068B34B File Offset: 0x0068974B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F44B RID: 62539
		private BE_Target method_p0;

		// Token: 0x0400F44C RID: 62540
		private int method_p1;
	}
}
