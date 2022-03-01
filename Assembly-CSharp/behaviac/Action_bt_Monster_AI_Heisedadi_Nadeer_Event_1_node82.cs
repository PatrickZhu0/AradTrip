using System;

namespace behaviac
{
	// Token: 0x0200351E RID: 13598
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node82 : Action
	{
		// Token: 0x0601527F RID: 86655 RVA: 0x0065F69E File Offset: 0x0065DA9E
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node82()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521784;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015280 RID: 86656 RVA: 0x0065F6D5 File Offset: 0x0065DAD5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBDD RID: 60381
		private BE_Target method_p0;

		// Token: 0x0400EBDE RID: 60382
		private int method_p1;

		// Token: 0x0400EBDF RID: 60383
		private int method_p2;

		// Token: 0x0400EBE0 RID: 60384
		private int method_p3;

		// Token: 0x0400EBE1 RID: 60385
		private int method_p4;
	}
}
