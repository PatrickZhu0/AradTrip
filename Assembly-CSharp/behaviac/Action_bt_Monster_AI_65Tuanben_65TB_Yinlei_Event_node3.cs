using System;

namespace behaviac
{
	// Token: 0x02002D31 RID: 11569
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node3 : Action
	{
		// Token: 0x0601434A RID: 82762 RVA: 0x00612037 File Offset: 0x00610437
		public Action_bt_Monster_AI_65Tuanben_65TB_Yinlei_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 4000;
			this.method_p1 = 0;
		}

		// Token: 0x0601434B RID: 82763 RVA: 0x00612058 File Offset: 0x00610458
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400DD0C RID: 56588
		private int method_p0;

		// Token: 0x0400DD0D RID: 56589
		private int method_p1;
	}
}
