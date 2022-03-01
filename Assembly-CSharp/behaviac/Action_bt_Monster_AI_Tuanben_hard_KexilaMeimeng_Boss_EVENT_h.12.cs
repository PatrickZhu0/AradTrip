using System;

namespace behaviac
{
	// Token: 0x02003C65 RID: 15461
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node44 : Action
	{
		// Token: 0x06016072 RID: 90226 RVA: 0x006A81C7 File Offset: 0x006A65C7
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_EVENT_hard_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
		}

		// Token: 0x06016073 RID: 90227 RVA: 0x006A81E8 File Offset: 0x006A65E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8F4 RID: 63732
		private BE_Target method_p0;

		// Token: 0x0400F8F5 RID: 63733
		private int method_p1;
	}
}
