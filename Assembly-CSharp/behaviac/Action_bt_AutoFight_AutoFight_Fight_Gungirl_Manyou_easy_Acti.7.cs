using System;

namespace behaviac
{
	// Token: 0x02001FCD RID: 8141
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node19 : Action
	{
		// Token: 0x06012937 RID: 76087 RVA: 0x00571831 File Offset: 0x0056FC31
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x06012938 RID: 76088 RVA: 0x0057184B File Offset: 0x0056FC4B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C32A RID: 49962
		private int method_p0;
	}
}
