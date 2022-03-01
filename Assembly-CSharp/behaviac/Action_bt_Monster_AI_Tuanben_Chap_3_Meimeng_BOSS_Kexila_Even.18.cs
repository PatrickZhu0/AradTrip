using System;

namespace behaviac
{
	// Token: 0x02003967 RID: 14695
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node41 : Action
	{
		// Token: 0x06015AA5 RID: 88741 RVA: 0x0068B2EF File Offset: 0x006896EF
		public Action_bt_Monster_AI_Tuanben_Chap_3_Meimeng_BOSS_Kexila_Event_Hard_node41()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x06015AA6 RID: 88742 RVA: 0x0068B310 File Offset: 0x00689710
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F449 RID: 62537
		private BE_Target method_p0;

		// Token: 0x0400F44A RID: 62538
		private int method_p1;
	}
}
