using System;

namespace behaviac
{
	// Token: 0x0200338F RID: 13199
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node30 : Action
	{
		// Token: 0x06014F7B RID: 85883 RVA: 0x00650EEC File Offset: 0x0064F2EC
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521404;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F7C RID: 85884 RVA: 0x00650F24 File Offset: 0x0064F324
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E852 RID: 59474
		private BE_Target method_p0;

		// Token: 0x0400E853 RID: 59475
		private int method_p1;

		// Token: 0x0400E854 RID: 59476
		private int method_p2;

		// Token: 0x0400E855 RID: 59477
		private int method_p3;

		// Token: 0x0400E856 RID: 59478
		private int method_p4;
	}
}
