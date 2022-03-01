using System;

namespace behaviac
{
	// Token: 0x0200334F RID: 13135
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3 : Action
	{
		// Token: 0x06014F00 RID: 85760 RVA: 0x0064F0A2 File Offset: 0x0064D4A2
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521406;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F01 RID: 85761 RVA: 0x0064F0D9 File Offset: 0x0064D4D9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E7DC RID: 59356
		private BE_Target method_p0;

		// Token: 0x0400E7DD RID: 59357
		private int method_p1;

		// Token: 0x0400E7DE RID: 59358
		private int method_p2;

		// Token: 0x0400E7DF RID: 59359
		private int method_p3;

		// Token: 0x0400E7E0 RID: 59360
		private int method_p4;
	}
}
