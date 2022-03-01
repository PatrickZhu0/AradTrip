using System;

namespace behaviac
{
	// Token: 0x0200379F RID: 14239
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node18 : Action
	{
		// Token: 0x06015743 RID: 87875 RVA: 0x006795BB File Offset: 0x006779BB
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node18()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 6000;
			this.method_p1 = 0;
		}

		// Token: 0x06015744 RID: 87876 RVA: 0x006795DC File Offset: 0x006779DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F0F5 RID: 61685
		private int method_p0;

		// Token: 0x0400F0F6 RID: 61686
		private int method_p1;
	}
}
