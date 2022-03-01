using System;

namespace behaviac
{
	// Token: 0x0200215C RID: 8540
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node14 : Action
	{
		// Token: 0x06012C49 RID: 76873 RVA: 0x00584975 File Offset: 0x00582D75
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012C4A RID: 76874 RVA: 0x0058498F File Offset: 0x00582D8F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C63D RID: 50749
		private int method_p0;
	}
}
