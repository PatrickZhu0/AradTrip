using System;

namespace behaviac
{
	// Token: 0x020034F3 RID: 13555
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node15 : Action
	{
		// Token: 0x06015229 RID: 86569 RVA: 0x0065E8AE File Offset: 0x0065CCAE
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521797;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601522A RID: 86570 RVA: 0x0065E8E5 File Offset: 0x0065CCE5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB4E RID: 60238
		private BE_Target method_p0;

		// Token: 0x0400EB4F RID: 60239
		private int method_p1;

		// Token: 0x0400EB50 RID: 60240
		private int method_p2;

		// Token: 0x0400EB51 RID: 60241
		private int method_p3;

		// Token: 0x0400EB52 RID: 60242
		private int method_p4;
	}
}
