using System;

namespace behaviac
{
	// Token: 0x020021CC RID: 8652
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node4 : Action
	{
		// Token: 0x06012D26 RID: 77094 RVA: 0x0058A091 File Offset: 0x00588491
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012D27 RID: 77095 RVA: 0x0058A0AB File Offset: 0x005884AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C71A RID: 50970
		private int method_p0;
	}
}
