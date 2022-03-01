using System;

namespace behaviac
{
	// Token: 0x02002168 RID: 8552
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node29 : Action
	{
		// Token: 0x06012C61 RID: 76897 RVA: 0x00584FA9 File Offset: 0x005833A9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1008;
		}

		// Token: 0x06012C62 RID: 76898 RVA: 0x00584FC3 File Offset: 0x005833C3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C655 RID: 50773
		private int method_p0;
	}
}
