using System;

namespace behaviac
{
	// Token: 0x02002014 RID: 8212
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node4 : Action
	{
		// Token: 0x060129C3 RID: 76227 RVA: 0x00575195 File Offset: 0x00573595
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2518;
		}

		// Token: 0x060129C4 RID: 76228 RVA: 0x005751AF File Offset: 0x005735AF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3B7 RID: 50103
		private int method_p0;
	}
}
