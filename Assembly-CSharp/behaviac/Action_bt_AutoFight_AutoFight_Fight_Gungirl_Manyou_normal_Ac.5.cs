using System;

namespace behaviac
{
	// Token: 0x02002044 RID: 8260
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node14 : Action
	{
		// Token: 0x06012A22 RID: 76322 RVA: 0x005772E9 File Offset: 0x005756E9
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012A23 RID: 76323 RVA: 0x00577303 File Offset: 0x00575703
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C416 RID: 50198
		private int method_p0;
	}
}
