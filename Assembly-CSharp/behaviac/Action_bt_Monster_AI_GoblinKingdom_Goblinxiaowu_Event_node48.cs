using System;

namespace behaviac
{
	// Token: 0x020032F5 RID: 13045
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node48 : Action
	{
		// Token: 0x06014E55 RID: 85589 RVA: 0x0064B57B File Offset: 0x0064997B
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node48()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521432;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E56 RID: 85590 RVA: 0x0064B5B2 File Offset: 0x006499B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E73F RID: 59199
		private BE_Target method_p0;

		// Token: 0x0400E740 RID: 59200
		private int method_p1;

		// Token: 0x0400E741 RID: 59201
		private int method_p2;

		// Token: 0x0400E742 RID: 59202
		private int method_p3;

		// Token: 0x0400E743 RID: 59203
		private int method_p4;
	}
}
