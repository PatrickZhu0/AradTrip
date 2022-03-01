using System;

namespace behaviac
{
	// Token: 0x02002080 RID: 8320
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node39 : Action
	{
		// Token: 0x06012A99 RID: 76441 RVA: 0x00579A71 File Offset: 0x00577E71
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2519;
		}

		// Token: 0x06012A9A RID: 76442 RVA: 0x00579A8B File Offset: 0x00577E8B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C48D RID: 50317
		private int method_p0;
	}
}
