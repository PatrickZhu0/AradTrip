using System;

namespace behaviac
{
	// Token: 0x02001FB1 RID: 8113
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node14 : Action
	{
		// Token: 0x06012900 RID: 76032 RVA: 0x005703D5 File Offset: 0x0056E7D5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012901 RID: 76033 RVA: 0x005703EF File Offset: 0x0056E7EF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2F3 RID: 49907
		private int method_p0;
	}
}
