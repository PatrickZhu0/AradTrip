using System;

namespace behaviac
{
	// Token: 0x020020C0 RID: 8384
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node9 : Action
	{
		// Token: 0x06012B16 RID: 76566 RVA: 0x0057D411 File Offset: 0x0057B811
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_esay_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012B17 RID: 76567 RVA: 0x0057D42B File Offset: 0x0057B82B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C50A RID: 50442
		private int method_p0;
	}
}
