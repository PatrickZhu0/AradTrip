using System;

namespace behaviac
{
	// Token: 0x02003688 RID: 13960
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node11 : Action
	{
		// Token: 0x0601552E RID: 87342 RVA: 0x0066E9D7 File Offset: 0x0066CDD7
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_Action_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521235;
			this.method_p2 = 10000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601552F RID: 87343 RVA: 0x0066EA12 File Offset: 0x0066CE12
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEED RID: 61165
		private BE_Target method_p0;

		// Token: 0x0400EEEE RID: 61166
		private int method_p1;

		// Token: 0x0400EEEF RID: 61167
		private int method_p2;

		// Token: 0x0400EEF0 RID: 61168
		private int method_p3;

		// Token: 0x0400EEF1 RID: 61169
		private int method_p4;
	}
}
