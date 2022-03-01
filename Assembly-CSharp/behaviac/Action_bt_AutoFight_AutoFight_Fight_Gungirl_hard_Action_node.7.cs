using System;

namespace behaviac
{
	// Token: 0x02001FB5 RID: 8117
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node19 : Action
	{
		// Token: 0x06012908 RID: 76040 RVA: 0x00570621 File Offset: 0x0056EA21
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2509;
		}

		// Token: 0x06012909 RID: 76041 RVA: 0x0057063B File Offset: 0x0056EA3B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2FB RID: 49915
		private int method_p0;
	}
}
