using System;

namespace behaviac
{
	// Token: 0x020034B3 RID: 13491
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node11 : Action
	{
		// Token: 0x060151AC RID: 86444 RVA: 0x0065C099 File Offset: 0x0065A499
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521718;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151AD RID: 86445 RVA: 0x0065C0D4 File Offset: 0x0065A4D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAB4 RID: 60084
		private BE_Target method_p0;

		// Token: 0x0400EAB5 RID: 60085
		private int method_p1;

		// Token: 0x0400EAB6 RID: 60086
		private int method_p2;

		// Token: 0x0400EAB7 RID: 60087
		private int method_p3;

		// Token: 0x0400EAB8 RID: 60088
		private int method_p4;
	}
}
