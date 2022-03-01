using System;

namespace behaviac
{
	// Token: 0x020021D8 RID: 8664
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node19 : Action
	{
		// Token: 0x06012D3E RID: 77118 RVA: 0x0058A6C5 File Offset: 0x00588AC5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_normal_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1011;
		}

		// Token: 0x06012D3F RID: 77119 RVA: 0x0058A6DF File Offset: 0x00588ADF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C732 RID: 50994
		private int method_p0;
	}
}
