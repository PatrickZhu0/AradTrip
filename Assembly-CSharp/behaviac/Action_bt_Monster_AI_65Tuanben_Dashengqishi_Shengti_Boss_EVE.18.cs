using System;

namespace behaviac
{
	// Token: 0x02002EA8 RID: 11944
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node39 : Action
	{
		// Token: 0x0601462B RID: 83499 RVA: 0x006210C9 File Offset: 0x0061F4C9
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601462C RID: 83500 RVA: 0x006210DF File Offset: 0x0061F4DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFA3 RID: 57251
		private int method_p0;
	}
}
