using System;

namespace behaviac
{
	// Token: 0x020031D5 RID: 12757
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node5 : Action
	{
		// Token: 0x06014C3B RID: 85051 RVA: 0x0064173F File Offset: 0x0063FB3F
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Jishengshou_node5()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 30000;
			this.method_p1 = 0;
		}

		// Token: 0x06014C3C RID: 85052 RVA: 0x00641760 File Offset: 0x0063FB60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E590 RID: 58768
		private int method_p0;

		// Token: 0x0400E591 RID: 58769
		private int method_p1;
	}
}
