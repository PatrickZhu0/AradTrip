using System;

namespace behaviac
{
	// Token: 0x020021E8 RID: 8680
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node9 : Action
	{
		// Token: 0x06012D5D RID: 77149 RVA: 0x0058B59D File Offset: 0x0058999D
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012D5E RID: 77150 RVA: 0x0058B5B7 File Offset: 0x005899B7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C751 RID: 51025
		private int method_p0;
	}
}
