using System;

namespace behaviac
{
	// Token: 0x02002070 RID: 8304
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node19 : Action
	{
		// Token: 0x06012A79 RID: 76409 RVA: 0x00579351 File Offset: 0x00577751
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x06012A7A RID: 76410 RVA: 0x0057936B File Offset: 0x0057776B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C46D RID: 50285
		private int method_p0;
	}
}
