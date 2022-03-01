using System;

namespace behaviac
{
	// Token: 0x020021D4 RID: 8660
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node14 : Action
	{
		// Token: 0x06012D36 RID: 77110 RVA: 0x0058A479 File Offset: 0x00588879
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012D37 RID: 77111 RVA: 0x0058A493 File Offset: 0x00588893
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C72A RID: 50986
		private int method_p0;
	}
}
