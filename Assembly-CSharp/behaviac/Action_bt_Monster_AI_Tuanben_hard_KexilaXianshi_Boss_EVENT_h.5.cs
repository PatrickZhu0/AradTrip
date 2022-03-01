using System;

namespace behaviac
{
	// Token: 0x02003CC2 RID: 15554
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node37 : Action
	{
		// Token: 0x06016126 RID: 90406 RVA: 0x006AC3D7 File Offset: 0x006AA7D7
		public Action_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570212;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06016127 RID: 90407 RVA: 0x006AC40E File Offset: 0x006AA80E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F9CF RID: 63951
		private BE_Target method_p0;

		// Token: 0x0400F9D0 RID: 63952
		private int method_p1;

		// Token: 0x0400F9D1 RID: 63953
		private int method_p2;

		// Token: 0x0400F9D2 RID: 63954
		private int method_p3;

		// Token: 0x0400F9D3 RID: 63955
		private int method_p4;
	}
}
