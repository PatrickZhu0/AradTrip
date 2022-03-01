using System;

namespace behaviac
{
	// Token: 0x020037A3 RID: 14243
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node1 : Action
	{
		// Token: 0x06015749 RID: 87881 RVA: 0x00679CB7 File Offset: 0x006780B7
		public Action_bt_Monster_AI_Tuanben_Chap_2_Zui_BOSS_Moxiang_Event_Hard_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 44900;
			this.method_p1 = 0;
		}

		// Token: 0x0601574A RID: 87882 RVA: 0x00679CD8 File Offset: 0x006780D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400F0FA RID: 61690
		private int method_p0;

		// Token: 0x0400F0FB RID: 61691
		private int method_p1;
	}
}
