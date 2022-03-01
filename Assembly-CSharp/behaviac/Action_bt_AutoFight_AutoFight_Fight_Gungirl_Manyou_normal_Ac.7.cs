using System;

namespace behaviac
{
	// Token: 0x02002048 RID: 8264
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node19 : Action
	{
		// Token: 0x06012A2A RID: 76330 RVA: 0x00577535 File Offset: 0x00575935
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x06012A2B RID: 76331 RVA: 0x0057754F File Offset: 0x0057594F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C41E RID: 50206
		private int method_p0;
	}
}
