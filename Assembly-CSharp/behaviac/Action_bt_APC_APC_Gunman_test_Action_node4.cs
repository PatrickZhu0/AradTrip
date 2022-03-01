using System;

namespace behaviac
{
	// Token: 0x02001D40 RID: 7488
	[GeneratedTypeMetaInfo]
	internal class Action_bt_APC_APC_Gunman_test_Action_node4 : Action
	{
		// Token: 0x06012441 RID: 74817 RVA: 0x00554185 File Offset: 0x00552585
		public Action_bt_APC_APC_Gunman_test_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1000;
		}

		// Token: 0x06012442 RID: 74818 RVA: 0x0055419F File Offset: 0x0055259F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE34 RID: 48692
		private int method_p0;
	}
}
