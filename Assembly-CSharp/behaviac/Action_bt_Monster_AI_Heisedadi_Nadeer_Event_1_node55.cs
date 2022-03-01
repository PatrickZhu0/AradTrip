using System;

namespace behaviac
{
	// Token: 0x02003510 RID: 13584
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node55 : Action
	{
		// Token: 0x06015263 RID: 86627 RVA: 0x0065F177 File Offset: 0x0065D577
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node55()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521785;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015264 RID: 86628 RVA: 0x0065F1AE File Offset: 0x0065D5AE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBA0 RID: 60320
		private BE_Target method_p0;

		// Token: 0x0400EBA1 RID: 60321
		private int method_p1;

		// Token: 0x0400EBA2 RID: 60322
		private int method_p2;

		// Token: 0x0400EBA3 RID: 60323
		private int method_p3;

		// Token: 0x0400EBA4 RID: 60324
		private int method_p4;
	}
}
