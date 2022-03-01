using System;

namespace behaviac
{
	// Token: 0x02003125 RID: 12581
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node8 : Action
	{
		// Token: 0x06014AEF RID: 84719 RVA: 0x0063A7D3 File Offset: 0x00638BD3
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014AF0 RID: 84720 RVA: 0x0063A80A File Offset: 0x00638C0A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E45E RID: 58462
		private BE_Target method_p0;

		// Token: 0x0400E45F RID: 58463
		private int method_p1;

		// Token: 0x0400E460 RID: 58464
		private int method_p2;

		// Token: 0x0400E461 RID: 58465
		private int method_p3;

		// Token: 0x0400E462 RID: 58466
		private int method_p4;
	}
}
