using System;

namespace behaviac
{
	// Token: 0x020034CC RID: 13516
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node39 : Action
	{
		// Token: 0x060151DE RID: 86494 RVA: 0x0065C88E File Offset: 0x0065AC8E
		public Action_bt_Monster_AI_Heisedadi_Kongbu_Event_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521721;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060151DF RID: 86495 RVA: 0x0065C8C5 File Offset: 0x0065ACC5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAED RID: 60141
		private BE_Target method_p0;

		// Token: 0x0400EAEE RID: 60142
		private int method_p1;

		// Token: 0x0400EAEF RID: 60143
		private int method_p2;

		// Token: 0x0400EAF0 RID: 60144
		private int method_p3;

		// Token: 0x0400EAF1 RID: 60145
		private int method_p4;
	}
}
