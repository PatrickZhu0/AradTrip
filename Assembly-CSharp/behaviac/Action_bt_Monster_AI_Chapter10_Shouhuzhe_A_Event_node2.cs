using System;

namespace behaviac
{
	// Token: 0x02003123 RID: 12579
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node2 : Action
	{
		// Token: 0x06014AEB RID: 84715 RVA: 0x0063A710 File Offset: 0x00638B10
		public Action_bt_Monster_AI_Chapter10_Shouhuzhe_A_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522054;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014AEC RID: 84716 RVA: 0x0063A747 File Offset: 0x00638B47
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E456 RID: 58454
		private BE_Target method_p0;

		// Token: 0x0400E457 RID: 58455
		private int method_p1;

		// Token: 0x0400E458 RID: 58456
		private int method_p2;

		// Token: 0x0400E459 RID: 58457
		private int method_p3;

		// Token: 0x0400E45A RID: 58458
		private int method_p4;
	}
}
