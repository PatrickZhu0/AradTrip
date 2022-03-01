using System;

namespace behaviac
{
	// Token: 0x02003512 RID: 13586
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node57 : Action
	{
		// Token: 0x06015267 RID: 86631 RVA: 0x0065F23D File Offset: 0x0065D63D
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node57()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521787;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015268 RID: 86632 RVA: 0x0065F274 File Offset: 0x0065D674
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBAA RID: 60330
		private BE_Target method_p0;

		// Token: 0x0400EBAB RID: 60331
		private int method_p1;

		// Token: 0x0400EBAC RID: 60332
		private int method_p2;

		// Token: 0x0400EBAD RID: 60333
		private int method_p3;

		// Token: 0x0400EBAE RID: 60334
		private int method_p4;
	}
}
