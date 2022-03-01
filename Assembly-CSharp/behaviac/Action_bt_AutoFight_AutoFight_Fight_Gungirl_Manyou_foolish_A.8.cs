using System;

namespace behaviac
{
	// Token: 0x02001FF8 RID: 8184
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node19 : Action
	{
		// Token: 0x0601298C RID: 76172 RVA: 0x00573811 File Offset: 0x00571C11
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x0601298D RID: 76173 RVA: 0x0057382B File Offset: 0x00571C2B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C380 RID: 50048
		private int method_p0;
	}
}
