using System;

namespace behaviac
{
	// Token: 0x0200211C RID: 8476
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node34 : Action
	{
		// Token: 0x06012BCB RID: 76747 RVA: 0x0058150D File Offset: 0x0057F90D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1009;
		}

		// Token: 0x06012BCC RID: 76748 RVA: 0x00581527 File Offset: 0x0057F927
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5BF RID: 50623
		private int method_p0;
	}
}
