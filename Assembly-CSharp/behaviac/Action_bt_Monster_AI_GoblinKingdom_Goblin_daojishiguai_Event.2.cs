using System;

namespace behaviac
{
	// Token: 0x02003313 RID: 13075
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node3 : Action
	{
		// Token: 0x06014E8E RID: 85646 RVA: 0x0064CE43 File Offset: 0x0064B243
		public Action_bt_Monster_AI_GoblinKingdom_Goblin_daojishiguai_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521258;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E8F RID: 85647 RVA: 0x0064CE7B File Offset: 0x0064B27B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E77A RID: 59258
		private BE_Target method_p0;

		// Token: 0x0400E77B RID: 59259
		private int method_p1;

		// Token: 0x0400E77C RID: 59260
		private int method_p2;

		// Token: 0x0400E77D RID: 59261
		private int method_p3;

		// Token: 0x0400E77E RID: 59262
		private int method_p4;
	}
}
