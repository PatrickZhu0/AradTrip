using System;

namespace behaviac
{
	// Token: 0x02003514 RID: 13588
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node64 : Action
	{
		// Token: 0x0601526B RID: 86635 RVA: 0x0065F303 File Offset: 0x0065D703
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node64()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521789;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601526C RID: 86636 RVA: 0x0065F33A File Offset: 0x0065D73A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBB4 RID: 60340
		private BE_Target method_p0;

		// Token: 0x0400EBB5 RID: 60341
		private int method_p1;

		// Token: 0x0400EBB6 RID: 60342
		private int method_p2;

		// Token: 0x0400EBB7 RID: 60343
		private int method_p3;

		// Token: 0x0400EBB8 RID: 60344
		private int method_p4;
	}
}
