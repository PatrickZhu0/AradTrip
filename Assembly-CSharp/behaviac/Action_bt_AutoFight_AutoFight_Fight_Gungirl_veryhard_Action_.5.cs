using System;

namespace behaviac
{
	// Token: 0x020020AC RID: 8364
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node14 : Action
	{
		// Token: 0x06012AEF RID: 76527 RVA: 0x0057C2ED File Offset: 0x0057A6ED
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012AF0 RID: 76528 RVA: 0x0057C307 File Offset: 0x0057A707
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4E3 RID: 50403
		private int method_p0;
	}
}
