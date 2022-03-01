using System;

namespace behaviac
{
	// Token: 0x02002118 RID: 8472
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node29 : Action
	{
		// Token: 0x06012BC3 RID: 76739 RVA: 0x00581371 File Offset: 0x0057F771
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1008;
		}

		// Token: 0x06012BC4 RID: 76740 RVA: 0x0058138B File Offset: 0x0057F78B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5B7 RID: 50615
		private int method_p0;
	}
}
