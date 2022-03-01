using System;

namespace behaviac
{
	// Token: 0x020020D4 RID: 8404
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node4 : Action
	{
		// Token: 0x06012B3D RID: 76605 RVA: 0x0057E485 File Offset: 0x0057C885
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012B3E RID: 76606 RVA: 0x0057E49F File Offset: 0x0057C89F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C531 RID: 50481
		private int method_p0;
	}
}
