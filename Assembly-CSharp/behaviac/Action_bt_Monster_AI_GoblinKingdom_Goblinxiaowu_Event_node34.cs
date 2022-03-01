using System;

namespace behaviac
{
	// Token: 0x020032EB RID: 13035
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node34 : Action
	{
		// Token: 0x06014E43 RID: 85571 RVA: 0x0064B2B3 File Offset: 0x006496B3
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521431;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E44 RID: 85572 RVA: 0x0064B2EA File Offset: 0x006496EA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E727 RID: 59175
		private BE_Target method_p0;

		// Token: 0x0400E728 RID: 59176
		private int method_p1;

		// Token: 0x0400E729 RID: 59177
		private int method_p2;

		// Token: 0x0400E72A RID: 59178
		private int method_p3;

		// Token: 0x0400E72B RID: 59179
		private int method_p4;
	}
}
