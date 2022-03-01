using System;

namespace behaviac
{
	// Token: 0x02003155 RID: 12629
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node8 : Action
	{
		// Token: 0x06014B49 RID: 84809 RVA: 0x0063C55F File Offset: 0x0063A95F
		public Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014B4A RID: 84810 RVA: 0x0063C596 File Offset: 0x0063A996
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4C0 RID: 58560
		private BE_Target method_p0;

		// Token: 0x0400E4C1 RID: 58561
		private int method_p1;

		// Token: 0x0400E4C2 RID: 58562
		private int method_p2;

		// Token: 0x0400E4C3 RID: 58563
		private int method_p3;

		// Token: 0x0400E4C4 RID: 58564
		private int method_p4;
	}
}
