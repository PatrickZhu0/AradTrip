using System;

namespace behaviac
{
	// Token: 0x02002084 RID: 8324
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node44 : Action
	{
		// Token: 0x06012AA1 RID: 76449 RVA: 0x00579D75 File Offset: 0x00578175
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012AA2 RID: 76450 RVA: 0x00579D8F File Offset: 0x0057818F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C495 RID: 50325
		private int method_p0;
	}
}
