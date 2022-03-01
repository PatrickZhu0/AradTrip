using System;

namespace behaviac
{
	// Token: 0x02002110 RID: 8464
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node19 : Action
	{
		// Token: 0x06012BB3 RID: 76723 RVA: 0x00580F89 File Offset: 0x0057F389
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012BB4 RID: 76724 RVA: 0x00580FA3 File Offset: 0x0057F3A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5A7 RID: 50599
		private int method_p0;
	}
}
