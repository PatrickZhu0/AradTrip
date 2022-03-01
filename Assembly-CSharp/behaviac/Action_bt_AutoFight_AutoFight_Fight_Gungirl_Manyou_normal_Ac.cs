using System;

namespace behaviac
{
	// Token: 0x0200203C RID: 8252
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node4 : Action
	{
		// Token: 0x06012A12 RID: 76306 RVA: 0x00576FB1 File Offset: 0x005753B1
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2518;
		}

		// Token: 0x06012A13 RID: 76307 RVA: 0x00576FCB File Offset: 0x005753CB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C406 RID: 50182
		private int method_p0;
	}
}
