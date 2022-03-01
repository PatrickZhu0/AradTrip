using System;

namespace behaviac
{
	// Token: 0x0200202C RID: 8236
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node34 : Action
	{
		// Token: 0x060129F3 RID: 76275 RVA: 0x00575C9D File Offset: 0x0057409D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2512;
		}

		// Token: 0x060129F4 RID: 76276 RVA: 0x00575CB7 File Offset: 0x005740B7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3E7 RID: 50151
		private int method_p0;
	}
}
