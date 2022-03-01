using System;

namespace behaviac
{
	// Token: 0x020020A8 RID: 8360
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node9 : Action
	{
		// Token: 0x06012AE7 RID: 76519 RVA: 0x0057C151 File Offset: 0x0057A551
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x06012AE8 RID: 76520 RVA: 0x0057C16B File Offset: 0x0057A56B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4DB RID: 50395
		private int method_p0;
	}
}
