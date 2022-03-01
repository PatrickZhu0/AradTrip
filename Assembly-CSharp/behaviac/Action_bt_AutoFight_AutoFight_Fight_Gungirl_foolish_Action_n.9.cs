using System;

namespace behaviac
{
	// Token: 0x02001FA1 RID: 8097
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node24 : Action
	{
		// Token: 0x060128E1 RID: 76001 RVA: 0x0056F5AD File Offset: 0x0056D9AD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x060128E2 RID: 76002 RVA: 0x0056F5C7 File Offset: 0x0056D9C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2D4 RID: 49876
		private int method_p0;
	}
}
