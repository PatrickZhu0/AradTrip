using System;

namespace behaviac
{
	// Token: 0x0200353A RID: 13626
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node95 : Action
	{
		// Token: 0x060152B7 RID: 86711 RVA: 0x006600EC File Offset: 0x0065E4EC
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node95()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521788;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152B8 RID: 86712 RVA: 0x00660123 File Offset: 0x0065E523
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC57 RID: 60503
		private BE_Target method_p0;

		// Token: 0x0400EC58 RID: 60504
		private int method_p1;

		// Token: 0x0400EC59 RID: 60505
		private int method_p2;

		// Token: 0x0400EC5A RID: 60506
		private int method_p3;

		// Token: 0x0400EC5B RID: 60507
		private int method_p4;
	}
}
