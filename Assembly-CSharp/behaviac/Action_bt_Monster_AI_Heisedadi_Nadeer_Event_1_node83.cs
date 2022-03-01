using System;

namespace behaviac
{
	// Token: 0x0200351F RID: 13599
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node83 : Action
	{
		// Token: 0x06015281 RID: 86657 RVA: 0x0065F701 File Offset: 0x0065DB01
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node83()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521787;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015282 RID: 86658 RVA: 0x0065F738 File Offset: 0x0065DB38
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EBE2 RID: 60386
		private BE_Target method_p0;

		// Token: 0x0400EBE3 RID: 60387
		private int method_p1;

		// Token: 0x0400EBE4 RID: 60388
		private int method_p2;

		// Token: 0x0400EBE5 RID: 60389
		private int method_p3;

		// Token: 0x0400EBE6 RID: 60390
		private int method_p4;
	}
}
