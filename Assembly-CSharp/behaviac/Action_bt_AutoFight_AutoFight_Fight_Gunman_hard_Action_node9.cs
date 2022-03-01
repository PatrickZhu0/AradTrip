using System;

namespace behaviac
{
	// Token: 0x020020F0 RID: 8432
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node9 : Action
	{
		// Token: 0x06012B74 RID: 76660 RVA: 0x0057F991 File Offset: 0x0057DD91
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012B75 RID: 76661 RVA: 0x0057F9AB File Offset: 0x0057DDAB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C568 RID: 50536
		private int method_p0;
	}
}
