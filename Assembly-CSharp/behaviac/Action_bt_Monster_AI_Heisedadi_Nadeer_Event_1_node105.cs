using System;

namespace behaviac
{
	// Token: 0x02003533 RID: 13619
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node105 : Action
	{
		// Token: 0x060152A9 RID: 86697 RVA: 0x0065FE7A File Offset: 0x0065E27A
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node105()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521874;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152AA RID: 86698 RVA: 0x0065FEB1 File Offset: 0x0065E2B1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC3D RID: 60477
		private BE_Target method_p0;

		// Token: 0x0400EC3E RID: 60478
		private int method_p1;

		// Token: 0x0400EC3F RID: 60479
		private int method_p2;

		// Token: 0x0400EC40 RID: 60480
		private int method_p3;

		// Token: 0x0400EC41 RID: 60481
		private int method_p4;
	}
}
