using System;

namespace behaviac
{
	// Token: 0x020032ED RID: 13037
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node39 : Action
	{
		// Token: 0x06014E47 RID: 85575 RVA: 0x0064B35F File Offset: 0x0064975F
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521432;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E48 RID: 85576 RVA: 0x0064B396 File Offset: 0x00649796
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E72D RID: 59181
		private BE_Target method_p0;

		// Token: 0x0400E72E RID: 59182
		private int method_p1;

		// Token: 0x0400E72F RID: 59183
		private int method_p2;

		// Token: 0x0400E730 RID: 59184
		private int method_p3;

		// Token: 0x0400E731 RID: 59185
		private int method_p4;
	}
}
