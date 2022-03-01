using System;

namespace behaviac
{
	// Token: 0x020032F2 RID: 13042
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node45 : Action
	{
		// Token: 0x06014E50 RID: 85584 RVA: 0x0064B4C3 File Offset: 0x006498C3
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node45()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521431;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E51 RID: 85585 RVA: 0x0064B4FA File Offset: 0x006498FA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E739 RID: 59193
		private BE_Target method_p0;

		// Token: 0x0400E73A RID: 59194
		private int method_p1;

		// Token: 0x0400E73B RID: 59195
		private int method_p2;

		// Token: 0x0400E73C RID: 59196
		private int method_p3;

		// Token: 0x0400E73D RID: 59197
		private int method_p4;
	}
}
