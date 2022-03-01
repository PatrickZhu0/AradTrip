using System;

namespace behaviac
{
	// Token: 0x02002DBD RID: 11709
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node8 : Action
	{
		// Token: 0x06014459 RID: 83033 RVA: 0x00617749 File Offset: 0x00615B49
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_EVENT_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x0601445A RID: 83034 RVA: 0x0061775F File Offset: 0x00615B5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_CreateBossPhaseChange(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE1F RID: 56863
		private int method_p0;
	}
}
