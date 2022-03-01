using System;

namespace behaviac
{
	// Token: 0x020020C4 RID: 8388
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node14 : Action
	{
		// Token: 0x06012B1E RID: 76574 RVA: 0x0057D5AD File Offset: 0x0057B9AD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012B1F RID: 76575 RVA: 0x0057D5C7 File Offset: 0x0057B9C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C512 RID: 50450
		private int method_p0;
	}
}
