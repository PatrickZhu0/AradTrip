using System;

namespace behaviac
{
	// Token: 0x020020E0 RID: 8416
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node19 : Action
	{
		// Token: 0x06012B55 RID: 76629 RVA: 0x0057EAB9 File Offset: 0x0057CEB9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1011;
		}

		// Token: 0x06012B56 RID: 76630 RVA: 0x0057EAD3 File Offset: 0x0057CED3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C549 RID: 50505
		private int method_p0;
	}
}
