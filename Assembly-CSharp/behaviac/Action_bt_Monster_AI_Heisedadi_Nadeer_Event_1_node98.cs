using System;

namespace behaviac
{
	// Token: 0x0200353D RID: 13629
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node98 : Action
	{
		// Token: 0x060152BD RID: 86717 RVA: 0x00660215 File Offset: 0x0065E615
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node98()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521773;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152BE RID: 86718 RVA: 0x0066024C File Offset: 0x0065E64C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC66 RID: 60518
		private BE_Target method_p0;

		// Token: 0x0400EC67 RID: 60519
		private int method_p1;

		// Token: 0x0400EC68 RID: 60520
		private int method_p2;

		// Token: 0x0400EC69 RID: 60521
		private int method_p3;

		// Token: 0x0400EC6A RID: 60522
		private int method_p4;
	}
}
