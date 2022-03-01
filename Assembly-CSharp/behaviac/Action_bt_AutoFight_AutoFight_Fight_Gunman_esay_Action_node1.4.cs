using System;

namespace behaviac
{
	// Token: 0x020020C8 RID: 8392
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node19 : Action
	{
		// Token: 0x06012B26 RID: 76582 RVA: 0x0057D7F9 File Offset: 0x0057BBF9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1011;
		}

		// Token: 0x06012B27 RID: 76583 RVA: 0x0057D813 File Offset: 0x0057BC13
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C51A RID: 50458
		private int method_p0;
	}
}
