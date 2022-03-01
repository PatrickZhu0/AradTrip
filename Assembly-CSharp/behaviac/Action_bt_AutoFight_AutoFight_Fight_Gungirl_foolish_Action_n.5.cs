using System;

namespace behaviac
{
	// Token: 0x02001F99 RID: 8089
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node14 : Action
	{
		// Token: 0x060128D1 RID: 75985 RVA: 0x0056F115 File Offset: 0x0056D515
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x060128D2 RID: 75986 RVA: 0x0056F12F File Offset: 0x0056D52F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2C4 RID: 49860
		private int method_p0;
	}
}
