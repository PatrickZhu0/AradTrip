using System;

namespace behaviac
{
	// Token: 0x020031EC RID: 12780
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node9 : Action
	{
		// Token: 0x06014C64 RID: 85092 RVA: 0x0064225C File Offset: 0x0064065C
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node9()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 25000;
			this.method_p1 = 0;
		}

		// Token: 0x06014C65 RID: 85093 RVA: 0x00642280 File Offset: 0x00640680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E5BE RID: 58814
		private int method_p0;

		// Token: 0x0400E5BF RID: 58815
		private int method_p1;
	}
}
