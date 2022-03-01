using System;

namespace behaviac
{
	// Token: 0x0200338E RID: 13198
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node29 : Action
	{
		// Token: 0x06014F79 RID: 85881 RVA: 0x00650E88 File Offset: 0x0064F288
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521400;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F7A RID: 85882 RVA: 0x00650EC0 File Offset: 0x0064F2C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E84D RID: 59469
		private BE_Target method_p0;

		// Token: 0x0400E84E RID: 59470
		private int method_p1;

		// Token: 0x0400E84F RID: 59471
		private int method_p2;

		// Token: 0x0400E850 RID: 59472
		private int method_p3;

		// Token: 0x0400E851 RID: 59473
		private int method_p4;
	}
}
