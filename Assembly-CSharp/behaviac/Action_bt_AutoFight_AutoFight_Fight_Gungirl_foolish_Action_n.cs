using System;

namespace behaviac
{
	// Token: 0x02001F91 RID: 8081
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node4 : Action
	{
		// Token: 0x060128C1 RID: 75969 RVA: 0x0056ED2D File Offset: 0x0056D12D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x060128C2 RID: 75970 RVA: 0x0056ED47 File Offset: 0x0056D147
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2B4 RID: 49844
		private int method_p0;
	}
}
