using System;

namespace behaviac
{
	// Token: 0x020030EF RID: 12527
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node8 : Action
	{
		// Token: 0x06014A8F RID: 84623 RVA: 0x00638B09 File Offset: 0x00636F09
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06014A90 RID: 84624 RVA: 0x00638B2C File Offset: 0x00636F2C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E3FF RID: 58367
		private int method_p0;

		// Token: 0x0400E400 RID: 58368
		private int method_p1;
	}
}
