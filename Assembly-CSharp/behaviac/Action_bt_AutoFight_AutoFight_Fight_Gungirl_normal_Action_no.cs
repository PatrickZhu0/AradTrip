using System;

namespace behaviac
{
	// Token: 0x0200208C RID: 8332
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node4 : Action
	{
		// Token: 0x06012AB0 RID: 76464 RVA: 0x0057AC45 File Offset: 0x00579045
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012AB1 RID: 76465 RVA: 0x0057AC5F File Offset: 0x0057905F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4A4 RID: 50340
		private int method_p0;
	}
}
