using System;

namespace behaviac
{
	// Token: 0x020021E4 RID: 8676
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node4 : Action
	{
		// Token: 0x06012D55 RID: 77141 RVA: 0x0058B351 File Offset: 0x00589751
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012D56 RID: 77142 RVA: 0x0058B36B File Offset: 0x0058976B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C749 RID: 51017
		private int method_p0;
	}
}
