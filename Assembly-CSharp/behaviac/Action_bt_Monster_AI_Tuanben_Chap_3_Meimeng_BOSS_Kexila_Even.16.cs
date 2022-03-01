using System;

namespace behaviac
{
	// Token: 0x02003963 RID: 14691
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node56 : Action
	{
		// Token: 0x06015A9D RID: 88733 RVA: 0x0068B1BC File Offset: 0x006895BC
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node56()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570213;
		}

		// Token: 0x06015A9E RID: 88734 RVA: 0x0068B1DD File Offset: 0x006895DD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F440 RID: 62528
		private BE_Target method_p0;

		// Token: 0x0400F441 RID: 62529
		private int method_p1;
	}
}
