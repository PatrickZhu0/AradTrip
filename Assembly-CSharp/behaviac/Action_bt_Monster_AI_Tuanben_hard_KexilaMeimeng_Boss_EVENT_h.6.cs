using System;

namespace behaviac
{
	// Token: 0x02003C5B RID: 15451
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node53 : Action
	{
		// Token: 0x0601605E RID: 90206 RVA: 0x006A7EE9 File Offset: 0x006A62E9
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node53()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570211;
		}

		// Token: 0x0601605F RID: 90207 RVA: 0x006A7F0A File Offset: 0x006A630A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8DE RID: 63710
		private BE_Target method_p0;

		// Token: 0x0400F8DF RID: 63711
		private int method_p1;
	}
}
