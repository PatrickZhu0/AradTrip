using System;

namespace behaviac
{
	// Token: 0x020020CC RID: 8396
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node24 : Action
	{
		// Token: 0x06012B2E RID: 76590 RVA: 0x0057DA45 File Offset: 0x0057BE45
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012B2F RID: 76591 RVA: 0x0057DA5F File Offset: 0x0057BE5F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C522 RID: 50466
		private int method_p0;
	}
}
