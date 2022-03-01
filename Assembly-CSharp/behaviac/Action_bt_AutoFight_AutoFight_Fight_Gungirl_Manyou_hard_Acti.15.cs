using System;

namespace behaviac
{
	// Token: 0x02002030 RID: 8240
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node39 : Action
	{
		// Token: 0x060129FB RID: 76283 RVA: 0x00575E39 File Offset: 0x00574239
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2519;
		}

		// Token: 0x060129FC RID: 76284 RVA: 0x00575E53 File Offset: 0x00574253
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3EF RID: 50159
		private int method_p0;
	}
}
