using System;

namespace behaviac
{
	// Token: 0x020032DC RID: 13020
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node0 : Action
	{
		// Token: 0x06014E27 RID: 85543 RVA: 0x0064AE72 File Offset: 0x00649272
		public Action_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521416;
			this.method_p2 = 900000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014E28 RID: 85544 RVA: 0x0064AEAD File Offset: 0x006492AD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E706 RID: 59142
		private BE_Target method_p0;

		// Token: 0x0400E707 RID: 59143
		private int method_p1;

		// Token: 0x0400E708 RID: 59144
		private int method_p2;

		// Token: 0x0400E709 RID: 59145
		private int method_p3;

		// Token: 0x0400E70A RID: 59146
		private int method_p4;
	}
}
