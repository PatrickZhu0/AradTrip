using System;

namespace behaviac
{
	// Token: 0x0200210C RID: 8460
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node14 : Action
	{
		// Token: 0x06012BAB RID: 76715 RVA: 0x00580D3D File Offset: 0x0057F13D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012BAC RID: 76716 RVA: 0x00580D57 File Offset: 0x0057F157
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C59F RID: 50591
		private int method_p0;
	}
}
