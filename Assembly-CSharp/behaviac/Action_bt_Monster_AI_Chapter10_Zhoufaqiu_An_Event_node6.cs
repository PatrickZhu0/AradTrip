using System;

namespace behaviac
{
	// Token: 0x02003165 RID: 12645
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node6 : Action
	{
		// Token: 0x06014B65 RID: 84837 RVA: 0x0063CD96 File Offset: 0x0063B196
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522078;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014B66 RID: 84838 RVA: 0x0063CDD1 File Offset: 0x0063B1D1
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4DD RID: 58589
		private BE_Target method_p0;

		// Token: 0x0400E4DE RID: 58590
		private int method_p1;

		// Token: 0x0400E4DF RID: 58591
		private int method_p2;

		// Token: 0x0400E4E0 RID: 58592
		private int method_p3;

		// Token: 0x0400E4E1 RID: 58593
		private int method_p4;
	}
}
