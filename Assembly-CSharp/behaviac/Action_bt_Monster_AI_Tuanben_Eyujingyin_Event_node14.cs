using System;

namespace behaviac
{
	// Token: 0x02003990 RID: 14736
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node14 : Action
	{
		// Token: 0x06015AF5 RID: 88821 RVA: 0x0068CCC6 File Offset: 0x0068B0C6
		public Action_bt_Monster_AI_Tuanben_Eyujingyin_Event_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06015AF6 RID: 88822 RVA: 0x0068CCDC File Offset: 0x0068B0DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F491 RID: 62609
		private int method_p0;
	}
}
