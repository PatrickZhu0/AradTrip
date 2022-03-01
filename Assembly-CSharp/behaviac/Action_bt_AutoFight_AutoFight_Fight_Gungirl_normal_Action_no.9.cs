using System;

namespace behaviac
{
	// Token: 0x0200209C RID: 8348
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node24 : Action
	{
		// Token: 0x06012AD0 RID: 76496 RVA: 0x0057B4C5 File Offset: 0x005798C5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012AD1 RID: 76497 RVA: 0x0057B4DF File Offset: 0x005798DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4C4 RID: 50372
		private int method_p0;
	}
}
