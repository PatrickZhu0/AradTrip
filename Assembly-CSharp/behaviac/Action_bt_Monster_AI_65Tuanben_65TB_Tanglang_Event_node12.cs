using System;

namespace behaviac
{
	// Token: 0x02002CA6 RID: 11430
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node12 : Action
	{
		// Token: 0x06014241 RID: 82497 RVA: 0x0060CB46 File Offset: 0x0060AF46
		public Action_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521945;
		}

		// Token: 0x06014242 RID: 82498 RVA: 0x0060CB67 File Offset: 0x0060AF67
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBF6 RID: 56310
		private BE_Target method_p0;

		// Token: 0x0400DBF7 RID: 56311
		private int method_p1;
	}
}
