using System;

namespace behaviac
{
	// Token: 0x020020F4 RID: 8436
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node14 : Action
	{
		// Token: 0x06012B7C RID: 76668 RVA: 0x0057FB2D File Offset: 0x0057DF2D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012B7D RID: 76669 RVA: 0x0057FB47 File Offset: 0x0057DF47
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C570 RID: 50544
		private int method_p0;
	}
}
