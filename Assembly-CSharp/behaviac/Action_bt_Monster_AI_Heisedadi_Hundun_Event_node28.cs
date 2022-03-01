using System;

namespace behaviac
{
	// Token: 0x02003457 RID: 13399
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node28 : Action
	{
		// Token: 0x060150FA RID: 86266 RVA: 0x0065862E File Offset: 0x00656A2E
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521857;
		}

		// Token: 0x060150FB RID: 86267 RVA: 0x0065864F File Offset: 0x00656A4F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9E6 RID: 59878
		private BE_Target method_p0;

		// Token: 0x0400E9E7 RID: 59879
		private int method_p1;
	}
}
