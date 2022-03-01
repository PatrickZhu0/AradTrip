using System;

namespace behaviac
{
	// Token: 0x02003569 RID: 13673
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2 : Action
	{
		// Token: 0x0601530B RID: 86795 RVA: 0x00662FAA File Offset: 0x006613AA
		public Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Hurt_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521999;
			this.method_p2 = 100;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601530C RID: 86796 RVA: 0x00662FE2 File Offset: 0x006613E2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECC2 RID: 60610
		private BE_Target method_p0;

		// Token: 0x0400ECC3 RID: 60611
		private int method_p1;

		// Token: 0x0400ECC4 RID: 60612
		private int method_p2;

		// Token: 0x0400ECC5 RID: 60613
		private int method_p3;

		// Token: 0x0400ECC6 RID: 60614
		private int method_p4;
	}
}
