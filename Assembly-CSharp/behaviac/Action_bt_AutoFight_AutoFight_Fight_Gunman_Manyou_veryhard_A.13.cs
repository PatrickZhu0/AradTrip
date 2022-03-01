using System;

namespace behaviac
{
	// Token: 0x020021BC RID: 8636
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node34 : Action
	{
		// Token: 0x06012D07 RID: 77063 RVA: 0x00588D7D File Offset: 0x0058717D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1009;
		}

		// Token: 0x06012D08 RID: 77064 RVA: 0x00588D97 File Offset: 0x00587197
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6FB RID: 50939
		private int method_p0;
	}
}
