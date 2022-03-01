using System;

namespace behaviac
{
	// Token: 0x02002034 RID: 8244
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node44 : Action
	{
		// Token: 0x06012A03 RID: 76291 RVA: 0x005760E1 File Offset: 0x005744E1
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012A04 RID: 76292 RVA: 0x005760FB File Offset: 0x005744FB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3F7 RID: 50167
		private int method_p0;
	}
}
