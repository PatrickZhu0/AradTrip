using System;

namespace behaviac
{
	// Token: 0x0200369E RID: 13982
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node8 : Action
	{
		// Token: 0x06015558 RID: 87384 RVA: 0x0066F741 File Offset: 0x0066DB41
		public Action_bt_Monster_AI_Monster_Jinshenzhidinggao_Monster_dinggao_event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521233;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015559 RID: 87385 RVA: 0x0066F777 File Offset: 0x0066DB77
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF22 RID: 61218
		private BE_Target method_p0;

		// Token: 0x0400EF23 RID: 61219
		private int method_p1;

		// Token: 0x0400EF24 RID: 61220
		private int method_p2;

		// Token: 0x0400EF25 RID: 61221
		private int method_p3;

		// Token: 0x0400EF26 RID: 61222
		private int method_p4;
	}
}
