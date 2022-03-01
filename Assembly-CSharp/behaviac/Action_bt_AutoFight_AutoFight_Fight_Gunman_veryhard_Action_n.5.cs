using System;

namespace behaviac
{
	// Token: 0x020021EC RID: 8684
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node14 : Action
	{
		// Token: 0x06012D65 RID: 77157 RVA: 0x0058B739 File Offset: 0x00589B39
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012D66 RID: 77158 RVA: 0x0058B753 File Offset: 0x00589B53
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C759 RID: 51033
		private int method_p0;
	}
}
