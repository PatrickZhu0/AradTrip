using System;

namespace behaviac
{
	// Token: 0x02002E99 RID: 11929
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node29 : Action
	{
		// Token: 0x0601460D RID: 83469 RVA: 0x00620CFC File Offset: 0x0061F0FC
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x0601460E RID: 83470 RVA: 0x00620D12 File Offset: 0x0061F112
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF8B RID: 57227
		private int method_p0;
	}
}
