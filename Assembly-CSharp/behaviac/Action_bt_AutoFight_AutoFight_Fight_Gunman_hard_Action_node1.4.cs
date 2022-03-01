using System;

namespace behaviac
{
	// Token: 0x020020F8 RID: 8440
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node19 : Action
	{
		// Token: 0x06012B84 RID: 76676 RVA: 0x0057FD79 File Offset: 0x0057E179
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1011;
		}

		// Token: 0x06012B85 RID: 76677 RVA: 0x0057FD93 File Offset: 0x0057E193
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C578 RID: 50552
		private int method_p0;
	}
}
