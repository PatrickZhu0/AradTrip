using System;

namespace behaviac
{
	// Token: 0x02002148 RID: 8520
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node39 : Action
	{
		// Token: 0x06012C22 RID: 76834 RVA: 0x005834C5 File Offset: 0x005818C5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1006;
		}

		// Token: 0x06012C23 RID: 76835 RVA: 0x005834DF File Offset: 0x005818DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C616 RID: 50710
		private int method_p0;
	}
}
