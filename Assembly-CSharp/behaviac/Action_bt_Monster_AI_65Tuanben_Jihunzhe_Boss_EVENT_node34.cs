using System;

namespace behaviac
{
	// Token: 0x02002F21 RID: 12065
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node34 : Action
	{
		// Token: 0x06014718 RID: 83736 RVA: 0x00626607 File Offset: 0x00624A07
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x06014719 RID: 83737 RVA: 0x0062661D File Offset: 0x00624A1D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E08D RID: 57485
		private int method_p0;
	}
}
