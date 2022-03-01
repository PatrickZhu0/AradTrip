using System;

namespace behaviac
{
	// Token: 0x020021DC RID: 8668
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node24 : Action
	{
		// Token: 0x06012D46 RID: 77126 RVA: 0x0058A911 File Offset: 0x00588D11
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012D47 RID: 77127 RVA: 0x0058A92B File Offset: 0x00588D2B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C73A RID: 51002
		private int method_p0;
	}
}
