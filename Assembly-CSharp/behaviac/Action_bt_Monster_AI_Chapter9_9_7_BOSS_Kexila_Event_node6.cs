using System;

namespace behaviac
{
	// Token: 0x0200321E RID: 12830
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node6 : Action
	{
		// Token: 0x06014CC5 RID: 85189 RVA: 0x006442CD File Offset: 0x006426CD
		public Action_bt_Monster_AI_Chapter9_9_7_BOSS_Kexila_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 2000;
			this.method_p1 = 1;
		}

		// Token: 0x06014CC6 RID: 85190 RVA: 0x006442F0 File Offset: 0x006426F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E611 RID: 58897
		private int method_p0;

		// Token: 0x0400E612 RID: 58898
		private int method_p1;
	}
}
