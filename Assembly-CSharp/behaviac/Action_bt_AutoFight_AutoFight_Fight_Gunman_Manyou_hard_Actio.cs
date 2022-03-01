using System;

namespace behaviac
{
	// Token: 0x02002154 RID: 8532
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node4 : Action
	{
		// Token: 0x06012C39 RID: 76857 RVA: 0x0058463D File Offset: 0x00582A3D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1106;
		}

		// Token: 0x06012C3A RID: 76858 RVA: 0x00584657 File Offset: 0x00582A57
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C62D RID: 50733
		private int method_p0;
	}
}
