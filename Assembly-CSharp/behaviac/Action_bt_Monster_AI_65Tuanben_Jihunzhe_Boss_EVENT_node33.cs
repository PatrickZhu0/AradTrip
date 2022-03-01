using System;

namespace behaviac
{
	// Token: 0x02002F20 RID: 12064
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node33 : Action
	{
		// Token: 0x06014716 RID: 83734 RVA: 0x006265DD File Offset: 0x006249DD
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node33()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014717 RID: 83735 RVA: 0x006265F3 File Offset: 0x006249F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E08C RID: 57484
		private int method_p0;
	}
}
