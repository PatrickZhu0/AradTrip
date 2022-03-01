using System;

namespace behaviac
{
	// Token: 0x020034B1 RID: 13489
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node8 : Action
	{
		// Token: 0x060151A8 RID: 86440 RVA: 0x0065BFD3 File Offset: 0x0065A3D3
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521716;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151A9 RID: 86441 RVA: 0x0065C00A File Offset: 0x0065A40A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAAA RID: 60074
		private BE_Target method_p0;

		// Token: 0x0400EAAB RID: 60075
		private int method_p1;

		// Token: 0x0400EAAC RID: 60076
		private int method_p2;

		// Token: 0x0400EAAD RID: 60077
		private int method_p3;

		// Token: 0x0400EAAE RID: 60078
		private int method_p4;
	}
}
