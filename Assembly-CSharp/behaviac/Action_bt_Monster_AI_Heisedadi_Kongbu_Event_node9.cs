using System;

namespace behaviac
{
	// Token: 0x020034B2 RID: 13490
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node9 : Action
	{
		// Token: 0x060151AA RID: 86442 RVA: 0x0065C036 File Offset: 0x0065A436
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521717;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151AB RID: 86443 RVA: 0x0065C06D File Offset: 0x0065A46D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAAF RID: 60079
		private BE_Target method_p0;

		// Token: 0x0400EAB0 RID: 60080
		private int method_p1;

		// Token: 0x0400EAB1 RID: 60081
		private int method_p2;

		// Token: 0x0400EAB2 RID: 60082
		private int method_p3;

		// Token: 0x0400EAB3 RID: 60083
		private int method_p4;
	}
}
