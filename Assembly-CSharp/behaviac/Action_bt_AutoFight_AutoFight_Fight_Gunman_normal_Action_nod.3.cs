using System;

namespace behaviac
{
	// Token: 0x020021D0 RID: 8656
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node9 : Action
	{
		// Token: 0x06012D2E RID: 77102 RVA: 0x0058A2DD File Offset: 0x005886DD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012D2F RID: 77103 RVA: 0x0058A2F7 File Offset: 0x005886F7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C722 RID: 50978
		private int method_p0;
	}
}
