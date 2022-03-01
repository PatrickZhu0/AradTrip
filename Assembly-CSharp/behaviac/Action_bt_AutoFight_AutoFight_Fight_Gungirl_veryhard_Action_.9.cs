using System;

namespace behaviac
{
	// Token: 0x020020B4 RID: 8372
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node24 : Action
	{
		// Token: 0x06012AFF RID: 76543 RVA: 0x0057C785 File Offset: 0x0057AB85
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012B00 RID: 76544 RVA: 0x0057C79F File Offset: 0x0057AB9F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4F3 RID: 50419
		private int method_p0;
	}
}
