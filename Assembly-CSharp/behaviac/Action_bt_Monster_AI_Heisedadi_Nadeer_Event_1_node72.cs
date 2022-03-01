using System;

namespace behaviac
{
	// Token: 0x0200352B RID: 13611
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node72 : Action
	{
		// Token: 0x06015299 RID: 86681 RVA: 0x0065FB62 File Offset: 0x0065DF62
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node72()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521786;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601529A RID: 86682 RVA: 0x0065FB99 File Offset: 0x0065DF99
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC15 RID: 60437
		private BE_Target method_p0;

		// Token: 0x0400EC16 RID: 60438
		private int method_p1;

		// Token: 0x0400EC17 RID: 60439
		private int method_p2;

		// Token: 0x0400EC18 RID: 60440
		private int method_p3;

		// Token: 0x0400EC19 RID: 60441
		private int method_p4;
	}
}
