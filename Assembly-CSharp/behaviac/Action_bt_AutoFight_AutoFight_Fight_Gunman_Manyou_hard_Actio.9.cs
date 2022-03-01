using System;

namespace behaviac
{
	// Token: 0x02002164 RID: 8548
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node24 : Action
	{
		// Token: 0x06012C59 RID: 76889 RVA: 0x00584D5D File Offset: 0x0058315D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012C5A RID: 76890 RVA: 0x00584D77 File Offset: 0x00583177
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C64D RID: 50765
		private int method_p0;
	}
}
