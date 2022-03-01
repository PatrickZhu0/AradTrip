using System;

namespace behaviac
{
	// Token: 0x020031D2 RID: 12754
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node4 : Action
	{
		// Token: 0x06014C36 RID: 85046 RVA: 0x00641548 File Offset: 0x0063F948
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570274;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014C37 RID: 85047 RVA: 0x00641580 File Offset: 0x0063F980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E588 RID: 58760
		private BE_Target method_p0;

		// Token: 0x0400E589 RID: 58761
		private int method_p1;

		// Token: 0x0400E58A RID: 58762
		private int method_p2;

		// Token: 0x0400E58B RID: 58763
		private int method_p3;

		// Token: 0x0400E58C RID: 58764
		private int method_p4;
	}
}
