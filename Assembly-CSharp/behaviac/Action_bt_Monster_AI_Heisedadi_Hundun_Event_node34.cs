using System;

namespace behaviac
{
	// Token: 0x0200344E RID: 13390
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node34 : Action
	{
		// Token: 0x060150E8 RID: 86248 RVA: 0x006582F2 File Offset: 0x006566F2
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521837;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150E9 RID: 86249 RVA: 0x0065832A File Offset: 0x0065672A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9C5 RID: 59845
		private BE_Target method_p0;

		// Token: 0x0400E9C6 RID: 59846
		private int method_p1;

		// Token: 0x0400E9C7 RID: 59847
		private int method_p2;

		// Token: 0x0400E9C8 RID: 59848
		private int method_p3;

		// Token: 0x0400E9C9 RID: 59849
		private int method_p4;
	}
}
