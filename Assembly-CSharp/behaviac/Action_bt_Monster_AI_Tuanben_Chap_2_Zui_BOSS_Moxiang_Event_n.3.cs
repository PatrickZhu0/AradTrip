using System;

namespace behaviac
{
	// Token: 0x02003790 RID: 14224
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node10 : Action
	{
		// Token: 0x06015725 RID: 87845 RVA: 0x006790B4 File Offset: 0x006774B4
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 60000;
			this.method_p1 = 1;
		}

		// Token: 0x06015726 RID: 87846 RVA: 0x006790D8 File Offset: 0x006774D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F0DC RID: 61660
		private int method_p0;

		// Token: 0x0400F0DD RID: 61661
		private int method_p1;
	}
}
