using System;

namespace behaviac
{
	// Token: 0x02003521 RID: 13601
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node85 : Action
	{
		// Token: 0x06015285 RID: 86661 RVA: 0x0065F7C7 File Offset: 0x0065DBC7
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node85()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521789;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015286 RID: 86662 RVA: 0x0065F7FE File Offset: 0x0065DBFE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBEC RID: 60396
		private BE_Target method_p0;

		// Token: 0x0400EBED RID: 60397
		private int method_p1;

		// Token: 0x0400EBEE RID: 60398
		private int method_p2;

		// Token: 0x0400EBEF RID: 60399
		private int method_p3;

		// Token: 0x0400EBF0 RID: 60400
		private int method_p4;
	}
}
