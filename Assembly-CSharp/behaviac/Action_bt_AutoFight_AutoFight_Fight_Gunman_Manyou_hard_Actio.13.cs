using System;

namespace behaviac
{
	// Token: 0x0200216C RID: 8556
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node34 : Action
	{
		// Token: 0x06012C69 RID: 76905 RVA: 0x00585145 File Offset: 0x00583545
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1009;
		}

		// Token: 0x06012C6A RID: 76906 RVA: 0x0058515F File Offset: 0x0058355F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C65D RID: 50781
		private int method_p0;
	}
}
