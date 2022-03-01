using System;

namespace behaviac
{
	// Token: 0x02001FB9 RID: 8121
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node24 : Action
	{
		// Token: 0x06012910 RID: 76048 RVA: 0x0057086D File Offset: 0x0056EC6D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012911 RID: 76049 RVA: 0x00570887 File Offset: 0x0056EC87
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C303 RID: 49923
		private int method_p0;
	}
}
