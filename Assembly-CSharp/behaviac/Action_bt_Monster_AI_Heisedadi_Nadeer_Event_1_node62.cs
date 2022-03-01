using System;

namespace behaviac
{
	// Token: 0x02003517 RID: 13591
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node62 : Action
	{
		// Token: 0x06015271 RID: 86641 RVA: 0x0065F42C File Offset: 0x0065D82C
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node62()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521741;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015272 RID: 86642 RVA: 0x0065F463 File Offset: 0x0065D863
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBC3 RID: 60355
		private BE_Target method_p0;

		// Token: 0x0400EBC4 RID: 60356
		private int method_p1;

		// Token: 0x0400EBC5 RID: 60357
		private int method_p2;

		// Token: 0x0400EBC6 RID: 60358
		private int method_p3;

		// Token: 0x0400EBC7 RID: 60359
		private int method_p4;
	}
}
