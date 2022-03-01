using System;

namespace behaviac
{
	// Token: 0x02001FAD RID: 8109
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node9 : Action
	{
		// Token: 0x060128F8 RID: 76024 RVA: 0x00570239 File Offset: 0x0056E639
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x060128F9 RID: 76025 RVA: 0x00570253 File Offset: 0x0056E653
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2EB RID: 49899
		private int method_p0;
	}
}
