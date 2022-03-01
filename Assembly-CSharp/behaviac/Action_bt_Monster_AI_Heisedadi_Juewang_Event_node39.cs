using System;

namespace behaviac
{
	// Token: 0x02003498 RID: 13464
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node39 : Action
	{
		// Token: 0x06015179 RID: 86393 RVA: 0x0065A8E2 File Offset: 0x00658CE2
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 69;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601517A RID: 86394 RVA: 0x0065A916 File Offset: 0x00658D16
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA75 RID: 60021
		private BE_Target method_p0;

		// Token: 0x0400EA76 RID: 60022
		private int method_p1;

		// Token: 0x0400EA77 RID: 60023
		private int method_p2;

		// Token: 0x0400EA78 RID: 60024
		private int method_p3;

		// Token: 0x0400EA79 RID: 60025
		private int method_p4;
	}
}
