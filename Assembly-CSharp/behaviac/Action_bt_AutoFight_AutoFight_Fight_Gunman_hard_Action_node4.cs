using System;

namespace behaviac
{
	// Token: 0x020020EC RID: 8428
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node4 : Action
	{
		// Token: 0x06012B6C RID: 76652 RVA: 0x0057F745 File Offset: 0x0057DB45
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012B6D RID: 76653 RVA: 0x0057F75F File Offset: 0x0057DB5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C560 RID: 50528
		private int method_p0;
	}
}
