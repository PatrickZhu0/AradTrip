using System;

namespace behaviac
{
	// Token: 0x02002120 RID: 8480
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node39 : Action
	{
		// Token: 0x06012BD3 RID: 76755 RVA: 0x005816A9 File Offset: 0x0057FAA9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1006;
		}

		// Token: 0x06012BD4 RID: 76756 RVA: 0x005816C3 File Offset: 0x0057FAC3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5C7 RID: 50631
		private int method_p0;
	}
}
