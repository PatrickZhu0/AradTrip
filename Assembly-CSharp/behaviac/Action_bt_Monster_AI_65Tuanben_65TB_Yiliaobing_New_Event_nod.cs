using System;

namespace behaviac
{
	// Token: 0x02002D29 RID: 11561
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node8 : Action
	{
		// Token: 0x0601433B RID: 82747 RVA: 0x00611B27 File Offset: 0x0060FF27
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_New_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601433C RID: 82748 RVA: 0x00611B5E File Offset: 0x0060FF5E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCF6 RID: 56566
		private BE_Target method_p0;

		// Token: 0x0400DCF7 RID: 56567
		private int method_p1;

		// Token: 0x0400DCF8 RID: 56568
		private int method_p2;

		// Token: 0x0400DCF9 RID: 56569
		private int method_p3;

		// Token: 0x0400DCFA RID: 56570
		private int method_p4;
	}
}
