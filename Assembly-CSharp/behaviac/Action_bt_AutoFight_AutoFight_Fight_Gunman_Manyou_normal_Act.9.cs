using System;

namespace behaviac
{
	// Token: 0x0200218C RID: 8588
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node24 : Action
	{
		// Token: 0x06012CA8 RID: 76968 RVA: 0x00586B79 File Offset: 0x00584F79
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012CA9 RID: 76969 RVA: 0x00586B93 File Offset: 0x00584F93
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C69C RID: 50844
		private int method_p0;
	}
}
