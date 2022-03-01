using System;

namespace behaviac
{
	// Token: 0x02002028 RID: 8232
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node29 : Action
	{
		// Token: 0x060129EB RID: 76267 RVA: 0x00575B01 File Offset: 0x00573F01
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2510;
		}

		// Token: 0x060129EC RID: 76268 RVA: 0x00575B1B File Offset: 0x00573F1B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3DF RID: 50143
		private int method_p0;
	}
}
