using System;

namespace behaviac
{
	// Token: 0x02001FA9 RID: 8105
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node4 : Action
	{
		// Token: 0x060128F0 RID: 76016 RVA: 0x0056FFED File Offset: 0x0056E3ED
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x060128F1 RID: 76017 RVA: 0x00570007 File Offset: 0x0056E407
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2E3 RID: 49891
		private int method_p0;
	}
}
