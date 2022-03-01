using System;

namespace behaviac
{
	// Token: 0x02002E3A RID: 11834
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node121 : Action
	{
		// Token: 0x06014551 RID: 83281 RVA: 0x0061AAEA File Offset: 0x00618EEA
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node121()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x06014552 RID: 83282 RVA: 0x0061AB0B File Offset: 0x00618F0B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEE6 RID: 57062
		private BE_Target method_p0;

		// Token: 0x0400DEE7 RID: 57063
		private int method_p1;
	}
}
