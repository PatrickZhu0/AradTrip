using System;

namespace behaviac
{
	// Token: 0x0200207C RID: 8316
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node34 : Action
	{
		// Token: 0x06012A91 RID: 76433 RVA: 0x005798D5 File Offset: 0x00577CD5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2512;
		}

		// Token: 0x06012A92 RID: 76434 RVA: 0x005798EF File Offset: 0x00577CEF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C485 RID: 50309
		private int method_p0;
	}
}
