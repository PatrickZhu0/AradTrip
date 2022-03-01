using System;

namespace behaviac
{
	// Token: 0x02003999 RID: 14745
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node22 : Action
	{
		// Token: 0x06015B07 RID: 88839 RVA: 0x0068CF7F File Offset: 0x0068B37F
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015B08 RID: 88840 RVA: 0x0068CF95 File Offset: 0x0068B395
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F49F RID: 62623
		private int method_p0;
	}
}
