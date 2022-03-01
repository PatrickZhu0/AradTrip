using System;

namespace behaviac
{
	// Token: 0x0200315D RID: 12637
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2 : Action
	{
		// Token: 0x06014B57 RID: 84823 RVA: 0x0063CA42 File Offset: 0x0063AE42
		public Action_bt_Monster_AI_Chapter10_Zhaohuan_Pengkenan_Feiche_Fan_node2()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 0;
		}

		// Token: 0x06014B58 RID: 84824 RVA: 0x0063CA64 File Offset: 0x0063AE64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E4CF RID: 58575
		private int method_p0;

		// Token: 0x0400E4D0 RID: 58576
		private int method_p1;
	}
}
