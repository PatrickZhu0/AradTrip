using System;

namespace behaviac
{
	// Token: 0x02003995 RID: 14741
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node10 : Action
	{
		// Token: 0x06015AFF RID: 88831 RVA: 0x0068CE76 File Offset: 0x0068B276
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015B00 RID: 88832 RVA: 0x0068CE8C File Offset: 0x0068B28C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F499 RID: 62617
		private int method_p0;
	}
}
