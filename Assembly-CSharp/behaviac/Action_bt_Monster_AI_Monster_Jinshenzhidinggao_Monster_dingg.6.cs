using System;

namespace behaviac
{
	// Token: 0x0200369D RID: 13981
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4 : Action
	{
		// Token: 0x06015556 RID: 87382 RVA: 0x0066F6DF File Offset: 0x0066DADF
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521232;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015557 RID: 87383 RVA: 0x0066F715 File Offset: 0x0066DB15
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF1D RID: 61213
		private BE_Target method_p0;

		// Token: 0x0400EF1E RID: 61214
		private int method_p1;

		// Token: 0x0400EF1F RID: 61215
		private int method_p2;

		// Token: 0x0400EF20 RID: 61216
		private int method_p3;

		// Token: 0x0400EF21 RID: 61217
		private int method_p4;
	}
}
