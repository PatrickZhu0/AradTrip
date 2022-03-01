using System;

namespace behaviac
{
	// Token: 0x02003456 RID: 13398
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node27 : Action
	{
		// Token: 0x060150F8 RID: 86264 RVA: 0x006585CA File Offset: 0x006569CA
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521838;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150F9 RID: 86265 RVA: 0x00658602 File Offset: 0x00656A02
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9E1 RID: 59873
		private BE_Target method_p0;

		// Token: 0x0400E9E2 RID: 59874
		private int method_p1;

		// Token: 0x0400E9E3 RID: 59875
		private int method_p2;

		// Token: 0x0400E9E4 RID: 59876
		private int method_p3;

		// Token: 0x0400E9E5 RID: 59877
		private int method_p4;
	}
}
