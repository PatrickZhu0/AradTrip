using System;

namespace behaviac
{
	// Token: 0x02003151 RID: 12625
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node8 : Action
	{
		// Token: 0x06014B43 RID: 84803 RVA: 0x0063C3A6 File Offset: 0x0063A7A6
		public Action_bt_Monster_AI_Chapter10_Yiliaobao_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522974;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014B44 RID: 84804 RVA: 0x0063C3E1 File Offset: 0x0063A7E1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4B8 RID: 58552
		private BE_Target method_p0;

		// Token: 0x0400E4B9 RID: 58553
		private int method_p1;

		// Token: 0x0400E4BA RID: 58554
		private int method_p2;

		// Token: 0x0400E4BB RID: 58555
		private int method_p3;

		// Token: 0x0400E4BC RID: 58556
		private int method_p4;
	}
}
