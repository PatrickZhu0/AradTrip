using System;

namespace behaviac
{
	// Token: 0x02003350 RID: 13136
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2 : Action
	{
		// Token: 0x06014F02 RID: 85762 RVA: 0x0064F105 File Offset: 0x0064D505
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 1;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F03 RID: 85763 RVA: 0x0064F138 File Offset: 0x0064D538
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7E1 RID: 59361
		private BE_Target method_p0;

		// Token: 0x0400E7E2 RID: 59362
		private int method_p1;

		// Token: 0x0400E7E3 RID: 59363
		private int method_p2;

		// Token: 0x0400E7E4 RID: 59364
		private int method_p3;

		// Token: 0x0400E7E5 RID: 59365
		private int method_p4;
	}
}
