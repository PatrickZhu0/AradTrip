using System;

namespace behaviac
{
	// Token: 0x0200344D RID: 13389
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node12 : Action
	{
		// Token: 0x060150E6 RID: 86246 RVA: 0x0065828E File Offset: 0x0065668E
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521888;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150E7 RID: 86247 RVA: 0x006582C6 File Offset: 0x006566C6
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9C0 RID: 59840
		private BE_Target method_p0;

		// Token: 0x0400E9C1 RID: 59841
		private int method_p1;

		// Token: 0x0400E9C2 RID: 59842
		private int method_p2;

		// Token: 0x0400E9C3 RID: 59843
		private int method_p3;

		// Token: 0x0400E9C4 RID: 59844
		private int method_p4;
	}
}
