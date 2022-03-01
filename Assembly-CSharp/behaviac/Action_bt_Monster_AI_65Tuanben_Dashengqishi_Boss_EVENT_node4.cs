using System;

namespace behaviac
{
	// Token: 0x02002DC2 RID: 11714
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node4 : Action
	{
		// Token: 0x06014463 RID: 83043 RVA: 0x00617873 File Offset: 0x00615C73
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x06014464 RID: 83044 RVA: 0x00617890 File Offset: 0x00615C90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE25 RID: 56869
		private int method_p0;

		// Token: 0x0400DE26 RID: 56870
		private int method_p1;
	}
}
