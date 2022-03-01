using System;

namespace behaviac
{
	// Token: 0x02002CA7 RID: 11431
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node24 : Action
	{
		// Token: 0x06014243 RID: 82499 RVA: 0x0060CB81 File Offset: 0x0060AF81
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521951;
		}

		// Token: 0x06014244 RID: 82500 RVA: 0x0060CBA2 File Offset: 0x0060AFA2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF8 RID: 56312
		private BE_Target method_p0;

		// Token: 0x0400DBF9 RID: 56313
		private int method_p1;
	}
}
