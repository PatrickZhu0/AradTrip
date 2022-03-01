using System;

namespace behaviac
{
	// Token: 0x02002E85 RID: 11909
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node8 : Action
	{
		// Token: 0x060145E5 RID: 83429 RVA: 0x006207ED File Offset: 0x0061EBED
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
		}

		// Token: 0x060145E6 RID: 83430 RVA: 0x00620803 File Offset: 0x0061EC03
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CreateBossPhaseChange(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF6D RID: 57197
		private int method_p0;
	}
}
