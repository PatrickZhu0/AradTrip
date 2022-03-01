using System;

namespace behaviac
{
	// Token: 0x02003255 RID: 12885
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7 : Action
	{
		// Token: 0x06014D29 RID: 85289 RVA: 0x0064602C File Offset: 0x0064442C
		public Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 3;
			this.method_p2 = 10000000;
			this.method_p3 = 60;
			this.method_p4 = 1000;
		}

		// Token: 0x06014D2A RID: 85290 RVA: 0x00646067 File Offset: 0x00644467
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E66F RID: 58991
		private BE_Target method_p0;

		// Token: 0x0400E670 RID: 58992
		private int method_p1;

		// Token: 0x0400E671 RID: 58993
		private int method_p2;

		// Token: 0x0400E672 RID: 58994
		private int method_p3;

		// Token: 0x0400E673 RID: 58995
		private int method_p4;
	}
}
