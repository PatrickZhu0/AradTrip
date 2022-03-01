using System;

namespace behaviac
{
	// Token: 0x0200399C RID: 14748
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node26 : Action
	{
		// Token: 0x06015B0D RID: 88845 RVA: 0x0068D03B File Offset: 0x0068B43B
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015B0E RID: 88846 RVA: 0x0068D051 File Offset: 0x0068B451
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4A4 RID: 62628
		private int method_p0;
	}
}
