using System;

namespace behaviac
{
	// Token: 0x02002020 RID: 8224
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node19 : Action
	{
		// Token: 0x060129DB RID: 76251 RVA: 0x00575719 File Offset: 0x00573B19
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x060129DC RID: 76252 RVA: 0x00575733 File Offset: 0x00573B33
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3CF RID: 50127
		private int method_p0;
	}
}
