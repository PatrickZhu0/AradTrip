using System;

namespace behaviac
{
	// Token: 0x020031D0 RID: 12752
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node1 : Action
	{
		// Token: 0x06014C32 RID: 85042 RVA: 0x006414C7 File Offset: 0x0063F8C7
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_BOSS_Moxiang_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 44900;
			this.method_p1 = 0;
		}

		// Token: 0x06014C33 RID: 85043 RVA: 0x006414E8 File Offset: 0x0063F8E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E586 RID: 58758
		private int method_p0;

		// Token: 0x0400E587 RID: 58759
		private int method_p1;
	}
}
