using System;

namespace behaviac
{
	// Token: 0x020034AC RID: 13484
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node0 : Action
	{
		// Token: 0x0601519E RID: 86430 RVA: 0x0065BE46 File Offset: 0x0065A246
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Enemy;
			this.method_p1 = 521703;
			this.method_p2 = 650;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601519F RID: 86431 RVA: 0x0065BE81 File Offset: 0x0065A281
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA9F RID: 60063
		private BE_Target method_p0;

		// Token: 0x0400EAA0 RID: 60064
		private int method_p1;

		// Token: 0x0400EAA1 RID: 60065
		private int method_p2;

		// Token: 0x0400EAA2 RID: 60066
		private int method_p3;

		// Token: 0x0400EAA3 RID: 60067
		private int method_p4;
	}
}
