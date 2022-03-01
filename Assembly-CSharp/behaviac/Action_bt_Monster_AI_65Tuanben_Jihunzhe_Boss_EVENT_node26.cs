using System;

namespace behaviac
{
	// Token: 0x02002F1F RID: 12063
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node26 : Action
	{
		// Token: 0x06014714 RID: 83732 RVA: 0x006265A6 File Offset: 0x006249A6
		public Action_bt_Monster_AI_65Tuanben_Jihunzhe_Boss_EVENT_node26()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 0;
		}

		// Token: 0x06014715 RID: 83733 RVA: 0x006265C3 File Offset: 0x006249C3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E08A RID: 57482
		private int method_p0;

		// Token: 0x0400E08B RID: 57483
		private int method_p1;
	}
}
