using System;

namespace behaviac
{
	// Token: 0x0200217C RID: 8572
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node4 : Action
	{
		// Token: 0x06012C88 RID: 76936 RVA: 0x00586459 File Offset: 0x00584859
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1106;
		}

		// Token: 0x06012C89 RID: 76937 RVA: 0x00586473 File Offset: 0x00584873
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C67C RID: 50812
		private int method_p0;
	}
}
