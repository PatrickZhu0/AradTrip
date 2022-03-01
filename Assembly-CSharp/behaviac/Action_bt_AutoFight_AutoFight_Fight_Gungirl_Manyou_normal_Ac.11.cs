using System;

namespace behaviac
{
	// Token: 0x02002050 RID: 8272
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node29 : Action
	{
		// Token: 0x06012A3A RID: 76346 RVA: 0x0057791D File Offset: 0x00575D1D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2510;
		}

		// Token: 0x06012A3B RID: 76347 RVA: 0x00577937 File Offset: 0x00575D37
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C42E RID: 50222
		private int method_p0;
	}
}
