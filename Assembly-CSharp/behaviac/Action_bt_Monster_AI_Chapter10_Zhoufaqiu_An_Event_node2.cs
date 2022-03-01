using System;

namespace behaviac
{
	// Token: 0x02003163 RID: 12643
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2 : Action
	{
		// Token: 0x06014B61 RID: 84833 RVA: 0x0063CCE6 File Offset: 0x0063B0E6
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522079;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014B62 RID: 84834 RVA: 0x0063CD21 File Offset: 0x0063B121
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4D6 RID: 58582
		private BE_Target method_p0;

		// Token: 0x0400E4D7 RID: 58583
		private int method_p1;

		// Token: 0x0400E4D8 RID: 58584
		private int method_p2;

		// Token: 0x0400E4D9 RID: 58585
		private int method_p3;

		// Token: 0x0400E4DA RID: 58586
		private int method_p4;
	}
}
