using System;

namespace behaviac
{
	// Token: 0x02001FDD RID: 8157
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node39 : Action
	{
		// Token: 0x06012957 RID: 76119 RVA: 0x00571F51 File Offset: 0x00570351
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2519;
		}

		// Token: 0x06012958 RID: 76120 RVA: 0x00571F6B File Offset: 0x0057036B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C34A RID: 49994
		private int method_p0;
	}
}
