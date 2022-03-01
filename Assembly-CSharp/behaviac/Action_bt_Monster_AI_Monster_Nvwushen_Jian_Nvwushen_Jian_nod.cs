using System;

namespace behaviac
{
	// Token: 0x020036E6 RID: 14054
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node3 : Action
	{
		// Token: 0x060155E1 RID: 87521 RVA: 0x00672713 File Offset: 0x00670B13
		public Action_bt_Monster_AI_Monster_Nvwushen_Jian_Nvwushen_Jian_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521697;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060155E2 RID: 87522 RVA: 0x0067274B File Offset: 0x00670B4B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFB4 RID: 61364
		private BE_Target method_p0;

		// Token: 0x0400EFB5 RID: 61365
		private int method_p1;

		// Token: 0x0400EFB6 RID: 61366
		private int method_p2;

		// Token: 0x0400EFB7 RID: 61367
		private int method_p3;

		// Token: 0x0400EFB8 RID: 61368
		private int method_p4;
	}
}
