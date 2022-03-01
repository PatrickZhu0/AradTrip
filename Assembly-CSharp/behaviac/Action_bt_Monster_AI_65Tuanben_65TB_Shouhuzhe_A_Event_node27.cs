using System;

namespace behaviac
{
	// Token: 0x02002C51 RID: 11345
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node27 : Action
	{
		// Token: 0x0601419E RID: 82334 RVA: 0x0060924F File Offset: 0x0060764F
		public Action_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522111;
			this.method_p2 = 500;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601419F RID: 82335 RVA: 0x0060928A File Offset: 0x0060768A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB65 RID: 56165
		private BE_Target method_p0;

		// Token: 0x0400DB66 RID: 56166
		private int method_p1;

		// Token: 0x0400DB67 RID: 56167
		private int method_p2;

		// Token: 0x0400DB68 RID: 56168
		private int method_p3;

		// Token: 0x0400DB69 RID: 56169
		private int method_p4;
	}
}
