using System;

namespace behaviac
{
	// Token: 0x020020DC RID: 8412
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node14 : Action
	{
		// Token: 0x06012B4D RID: 76621 RVA: 0x0057E86D File Offset: 0x0057CC6D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012B4E RID: 76622 RVA: 0x0057E887 File Offset: 0x0057CC87
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C541 RID: 50497
		private int method_p0;
	}
}
