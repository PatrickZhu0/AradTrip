using System;

namespace behaviac
{
	// Token: 0x020020B0 RID: 8368
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node19 : Action
	{
		// Token: 0x06012AF7 RID: 76535 RVA: 0x0057C539 File Offset: 0x0057A939
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2509;
		}

		// Token: 0x06012AF8 RID: 76536 RVA: 0x0057C553 File Offset: 0x0057A953
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4EB RID: 50411
		private int method_p0;
	}
}
