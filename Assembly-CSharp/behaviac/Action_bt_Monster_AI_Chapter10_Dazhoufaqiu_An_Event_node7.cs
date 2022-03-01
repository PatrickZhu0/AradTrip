using System;

namespace behaviac
{
	// Token: 0x020030ED RID: 12525
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node7 : Action
	{
		// Token: 0x06014A8B RID: 84619 RVA: 0x00638A5A File Offset: 0x00636E5A
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node7()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x06014A8C RID: 84620 RVA: 0x00638A7C File Offset: 0x00636E7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E3F8 RID: 58360
		private int method_p0;

		// Token: 0x0400E3F9 RID: 58361
		private int method_p1;
	}
}
