using System;

namespace behaviac
{
	// Token: 0x020037A5 RID: 14245
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node4 : Action
	{
		// Token: 0x0601574D RID: 87885 RVA: 0x00679D38 File Offset: 0x00678138
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521661;
			this.method_p2 = 100;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601574E RID: 87886 RVA: 0x00679D70 File Offset: 0x00678170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F0FC RID: 61692
		private BE_Target method_p0;

		// Token: 0x0400F0FD RID: 61693
		private int method_p1;

		// Token: 0x0400F0FE RID: 61694
		private int method_p2;

		// Token: 0x0400F0FF RID: 61695
		private int method_p3;

		// Token: 0x0400F100 RID: 61696
		private int method_p4;
	}
}
