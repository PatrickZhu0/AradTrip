using System;

namespace behaviac
{
	// Token: 0x02002098 RID: 8344
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node19 : Action
	{
		// Token: 0x06012AC8 RID: 76488 RVA: 0x0057B279 File Offset: 0x00579679
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2509;
		}

		// Token: 0x06012AC9 RID: 76489 RVA: 0x0057B293 File Offset: 0x00579693
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4BC RID: 50364
		private int method_p0;
	}
}
