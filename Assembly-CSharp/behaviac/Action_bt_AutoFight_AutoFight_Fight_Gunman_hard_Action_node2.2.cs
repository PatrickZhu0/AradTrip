using System;

namespace behaviac
{
	// Token: 0x020020FC RID: 8444
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node24 : Action
	{
		// Token: 0x06012B8C RID: 76684 RVA: 0x0057FFC5 File Offset: 0x0057E3C5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_hard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012B8D RID: 76685 RVA: 0x0057FFDF File Offset: 0x0057E3DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C580 RID: 50560
		private int method_p0;
	}
}
