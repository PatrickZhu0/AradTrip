using System;

namespace behaviac
{
	// Token: 0x02003C0D RID: 15373
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node40 : Action
	{
		// Token: 0x06015FC5 RID: 90053 RVA: 0x006A4BD1 File Offset: 0x006A2FD1
		public Action_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node40()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06015FC6 RID: 90054 RVA: 0x006A4BEE File Offset: 0x006A2FEE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F848 RID: 63560
		private int method_p0;

		// Token: 0x0400F849 RID: 63561
		private int method_p1;
	}
}
