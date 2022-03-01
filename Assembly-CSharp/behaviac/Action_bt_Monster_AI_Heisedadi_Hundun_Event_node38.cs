using System;

namespace behaviac
{
	// Token: 0x02003464 RID: 13412
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node38 : Action
	{
		// Token: 0x06015114 RID: 86292 RVA: 0x00658AAE File Offset: 0x00656EAE
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node38()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521865;
			this.method_p2 = 40;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015115 RID: 86293 RVA: 0x00658AE6 File Offset: 0x00656EE6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA11 RID: 59921
		private BE_Target method_p0;

		// Token: 0x0400EA12 RID: 59922
		private int method_p1;

		// Token: 0x0400EA13 RID: 59923
		private int method_p2;

		// Token: 0x0400EA14 RID: 59924
		private int method_p3;

		// Token: 0x0400EA15 RID: 59925
		private int method_p4;
	}
}
