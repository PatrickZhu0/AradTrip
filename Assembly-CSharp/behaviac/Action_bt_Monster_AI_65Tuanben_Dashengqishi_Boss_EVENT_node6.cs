using System;

namespace behaviac
{
	// Token: 0x02002DC6 RID: 11718
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node6 : Action
	{
		// Token: 0x0601446B RID: 83051 RVA: 0x00617983 File Offset: 0x00615D83
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 2;
		}

		// Token: 0x0601446C RID: 83052 RVA: 0x006179A0 File Offset: 0x00615DA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE2C RID: 56876
		private int method_p0;

		// Token: 0x0400DE2D RID: 56877
		private int method_p1;
	}
}
