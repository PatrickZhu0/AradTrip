using System;

namespace behaviac
{
	// Token: 0x020020A4 RID: 8356
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node4 : Action
	{
		// Token: 0x06012ADF RID: 76511 RVA: 0x0057BF05 File Offset: 0x0057A305
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012AE0 RID: 76512 RVA: 0x0057BF1F File Offset: 0x0057A31F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4D3 RID: 50387
		private int method_p0;
	}
}
