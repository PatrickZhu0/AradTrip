using System;

namespace behaviac
{
	// Token: 0x0200201C RID: 8220
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node14 : Action
	{
		// Token: 0x060129D3 RID: 76243 RVA: 0x005754CD File Offset: 0x005738CD
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x060129D4 RID: 76244 RVA: 0x005754E7 File Offset: 0x005738E7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3C7 RID: 50119
		private int method_p0;
	}
}
