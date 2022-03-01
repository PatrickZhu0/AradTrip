using System;

namespace behaviac
{
	// Token: 0x020034ED RID: 13549
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node7 : Action
	{
		// Token: 0x0601521D RID: 86557 RVA: 0x0065E6AE File Offset: 0x0065CAAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521799;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601521E RID: 86558 RVA: 0x0065E6E5 File Offset: 0x0065CAE5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB3A RID: 60218
		private BE_Target method_p0;

		// Token: 0x0400EB3B RID: 60219
		private int method_p1;

		// Token: 0x0400EB3C RID: 60220
		private int method_p2;

		// Token: 0x0400EB3D RID: 60221
		private int method_p3;

		// Token: 0x0400EB3E RID: 60222
		private int method_p4;
	}
}
