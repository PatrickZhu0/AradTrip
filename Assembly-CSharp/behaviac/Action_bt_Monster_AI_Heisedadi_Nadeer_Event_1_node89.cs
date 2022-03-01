using System;

namespace behaviac
{
	// Token: 0x02003525 RID: 13605
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node89 : Action
	{
		// Token: 0x0601528D RID: 86669 RVA: 0x0065F953 File Offset: 0x0065DD53
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node89()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521764;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601528E RID: 86670 RVA: 0x0065F98A File Offset: 0x0065DD8A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC00 RID: 60416
		private BE_Target method_p0;

		// Token: 0x0400EC01 RID: 60417
		private int method_p1;

		// Token: 0x0400EC02 RID: 60418
		private int method_p2;

		// Token: 0x0400EC03 RID: 60419
		private int method_p3;

		// Token: 0x0400EC04 RID: 60420
		private int method_p4;
	}
}
