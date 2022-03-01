using System;

namespace behaviac
{
	// Token: 0x02001FC1 RID: 8129
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node4 : Action
	{
		// Token: 0x0601291F RID: 76063 RVA: 0x005712AD File Offset: 0x0056F6AD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2518;
		}

		// Token: 0x06012920 RID: 76064 RVA: 0x005712C7 File Offset: 0x0056F6C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C312 RID: 49938
		private int method_p0;
	}
}
