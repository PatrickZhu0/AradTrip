using System;

namespace behaviac
{
	// Token: 0x02002094 RID: 8340
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node14 : Action
	{
		// Token: 0x06012AC0 RID: 76480 RVA: 0x0057B02D File Offset: 0x0057942D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012AC1 RID: 76481 RVA: 0x0057B047 File Offset: 0x00579447
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4B4 RID: 50356
		private int method_p0;
	}
}
