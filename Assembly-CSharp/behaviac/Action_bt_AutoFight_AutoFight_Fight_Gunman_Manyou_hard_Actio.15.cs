using System;

namespace behaviac
{
	// Token: 0x02002170 RID: 8560
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node39 : Action
	{
		// Token: 0x06012C71 RID: 76913 RVA: 0x005852E1 File Offset: 0x005836E1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1006;
		}

		// Token: 0x06012C72 RID: 76914 RVA: 0x005852FB File Offset: 0x005836FB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C665 RID: 50789
		private int method_p0;
	}
}
