using System;

namespace behaviac
{
	// Token: 0x020032EF RID: 13039
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node42 : Action
	{
		// Token: 0x06014E4B RID: 85579 RVA: 0x0064B40B File Offset: 0x0064980B
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node42()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521433;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E4C RID: 85580 RVA: 0x0064B442 File Offset: 0x00649842
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E733 RID: 59187
		private BE_Target method_p0;

		// Token: 0x0400E734 RID: 59188
		private int method_p1;

		// Token: 0x0400E735 RID: 59189
		private int method_p2;

		// Token: 0x0400E736 RID: 59190
		private int method_p3;

		// Token: 0x0400E737 RID: 59191
		private int method_p4;
	}
}
