using System;

namespace behaviac
{
	// Token: 0x020020BC RID: 8380
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node4 : Action
	{
		// Token: 0x06012B0E RID: 76558 RVA: 0x0057D1C5 File Offset: 0x0057B5C5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012B0F RID: 76559 RVA: 0x0057D1DF File Offset: 0x0057B5DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C502 RID: 50434
		private int method_p0;
	}
}
