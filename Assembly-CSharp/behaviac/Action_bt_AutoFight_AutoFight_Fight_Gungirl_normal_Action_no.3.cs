using System;

namespace behaviac
{
	// Token: 0x02002090 RID: 8336
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node9 : Action
	{
		// Token: 0x06012AB8 RID: 76472 RVA: 0x0057AE91 File Offset: 0x00579291
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_normal_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x06012AB9 RID: 76473 RVA: 0x0057AEAB File Offset: 0x005792AB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4AC RID: 50348
		private int method_p0;
	}
}
