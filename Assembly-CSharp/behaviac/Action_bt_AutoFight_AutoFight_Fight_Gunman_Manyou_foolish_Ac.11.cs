using System;

namespace behaviac
{
	// Token: 0x02002140 RID: 8512
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node29 : Action
	{
		// Token: 0x06012C12 RID: 76818 RVA: 0x0058318D File Offset: 0x0058158D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1008;
		}

		// Token: 0x06012C13 RID: 76819 RVA: 0x005831A7 File Offset: 0x005815A7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C606 RID: 50694
		private int method_p0;
	}
}
