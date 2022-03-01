using System;

namespace behaviac
{
	// Token: 0x02001FC9 RID: 8137
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node14 : Action
	{
		// Token: 0x0601292F RID: 76079 RVA: 0x005715E5 File Offset: 0x0056F9E5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012930 RID: 76080 RVA: 0x005715FF File Offset: 0x0056F9FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C322 RID: 49954
		private int method_p0;
	}
}
