using System;

namespace behaviac
{
	// Token: 0x02003388 RID: 13192
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node27 : Action
	{
		// Token: 0x06014F6D RID: 85869 RVA: 0x00650C52 File Offset: 0x0064F052
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521399;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F6E RID: 85870 RVA: 0x00650C8A File Offset: 0x0064F08A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E83D RID: 59453
		private BE_Target method_p0;

		// Token: 0x0400E83E RID: 59454
		private int method_p1;

		// Token: 0x0400E83F RID: 59455
		private int method_p2;

		// Token: 0x0400E840 RID: 59456
		private int method_p3;

		// Token: 0x0400E841 RID: 59457
		private int method_p4;
	}
}
