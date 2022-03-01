using System;

namespace behaviac
{
	// Token: 0x02001FD5 RID: 8149
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node29 : Action
	{
		// Token: 0x06012947 RID: 76103 RVA: 0x00571C19 File Offset: 0x00570019
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2510;
		}

		// Token: 0x06012948 RID: 76104 RVA: 0x00571C33 File Offset: 0x00570033
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C33A RID: 49978
		private int method_p0;
	}
}
