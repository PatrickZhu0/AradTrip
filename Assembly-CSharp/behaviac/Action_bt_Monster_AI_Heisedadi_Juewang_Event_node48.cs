using System;

namespace behaviac
{
	// Token: 0x0200349E RID: 13470
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node48 : Action
	{
		// Token: 0x06015185 RID: 86405 RVA: 0x0065AAE3 File Offset: 0x00658EE3
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 560001;
		}

		// Token: 0x06015186 RID: 86406 RVA: 0x0065AB04 File Offset: 0x00658F04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA86 RID: 60038
		private BE_Target method_p0;

		// Token: 0x0400EA87 RID: 60039
		private int method_p1;
	}
}
