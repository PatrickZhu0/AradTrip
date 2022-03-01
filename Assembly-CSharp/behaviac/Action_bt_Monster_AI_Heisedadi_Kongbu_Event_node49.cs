using System;

namespace behaviac
{
	// Token: 0x020034C6 RID: 13510
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node49 : Action
	{
		// Token: 0x060151D2 RID: 86482 RVA: 0x0065C69E File Offset: 0x0065AA9E
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node49()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521752;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151D3 RID: 86483 RVA: 0x0065C6D5 File Offset: 0x0065AAD5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EADE RID: 60126
		private BE_Target method_p0;

		// Token: 0x0400EADF RID: 60127
		private int method_p1;

		// Token: 0x0400EAE0 RID: 60128
		private int method_p2;

		// Token: 0x0400EAE1 RID: 60129
		private int method_p3;

		// Token: 0x0400EAE2 RID: 60130
		private int method_p4;
	}
}
