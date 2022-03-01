using System;

namespace behaviac
{
	// Token: 0x02002E34 RID: 11828
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node114 : Action
	{
		// Token: 0x06014545 RID: 83269 RVA: 0x0061A8FA File Offset: 0x00618CFA
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node114()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570290;
		}

		// Token: 0x06014546 RID: 83270 RVA: 0x0061A91B File Offset: 0x00618D1B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DEDE RID: 57054
		private BE_Target method_p0;

		// Token: 0x0400DEDF RID: 57055
		private int method_p1;
	}
}
