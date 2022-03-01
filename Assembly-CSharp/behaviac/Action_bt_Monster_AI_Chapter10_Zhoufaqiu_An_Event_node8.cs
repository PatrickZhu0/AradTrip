using System;

namespace behaviac
{
	// Token: 0x02003164 RID: 12644
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node8 : Action
	{
		// Token: 0x06014B63 RID: 84835 RVA: 0x0063CD4D File Offset: 0x0063B14D
		public Action_bt_Monster_AI_Chapter10_Zhoufaqiu_An_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06014B64 RID: 84836 RVA: 0x0063CD70 File Offset: 0x0063B170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4DB RID: 58587
		private int method_p0;

		// Token: 0x0400E4DC RID: 58588
		private int method_p1;
	}
}
