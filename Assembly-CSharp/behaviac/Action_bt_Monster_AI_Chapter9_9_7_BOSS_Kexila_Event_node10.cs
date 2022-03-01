using System;

namespace behaviac
{
	// Token: 0x0200321C RID: 12828
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node10 : Action
	{
		// Token: 0x06014CC1 RID: 85185 RVA: 0x00644222 File Offset: 0x00642622
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 0;
		}

		// Token: 0x06014CC2 RID: 85186 RVA: 0x00644244 File Offset: 0x00642644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E60A RID: 58890
		private int method_p0;

		// Token: 0x0400E60B RID: 58891
		private int method_p1;
	}
}
