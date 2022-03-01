using System;

namespace behaviac
{
	// Token: 0x02003448 RID: 13384
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node2 : Action
	{
		// Token: 0x060150DC RID: 86236 RVA: 0x006580E1 File Offset: 0x006564E1
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521840;
		}

		// Token: 0x060150DD RID: 86237 RVA: 0x00658102 File Offset: 0x00656502
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9B3 RID: 59827
		private BE_Target method_p0;

		// Token: 0x0400E9B4 RID: 59828
		private int method_p1;
	}
}
