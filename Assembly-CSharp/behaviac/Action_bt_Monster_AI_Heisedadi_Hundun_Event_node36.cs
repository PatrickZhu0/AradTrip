using System;

namespace behaviac
{
	// Token: 0x02003450 RID: 13392
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node36 : Action
	{
		// Token: 0x060150EC RID: 86252 RVA: 0x00658391 File Offset: 0x00656791
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node36()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521857;
			this.method_p2 = -1;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150ED RID: 86253 RVA: 0x006583C8 File Offset: 0x006567C8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9CC RID: 59852
		private BE_Target method_p0;

		// Token: 0x0400E9CD RID: 59853
		private int method_p1;

		// Token: 0x0400E9CE RID: 59854
		private int method_p2;

		// Token: 0x0400E9CF RID: 59855
		private int method_p3;

		// Token: 0x0400E9D0 RID: 59856
		private int method_p4;
	}
}
