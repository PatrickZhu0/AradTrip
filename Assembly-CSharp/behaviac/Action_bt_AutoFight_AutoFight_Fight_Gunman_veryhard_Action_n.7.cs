using System;

namespace behaviac
{
	// Token: 0x020021F0 RID: 8688
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node19 : Action
	{
		// Token: 0x06012D6D RID: 77165 RVA: 0x0058B9DD File Offset: 0x00589DDD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1011;
		}

		// Token: 0x06012D6E RID: 77166 RVA: 0x0058B9F7 File Offset: 0x00589DF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C761 RID: 51041
		private int method_p0;
	}
}
