using System;

namespace behaviac
{
	// Token: 0x02001F95 RID: 8085
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node9 : Action
	{
		// Token: 0x060128C9 RID: 75977 RVA: 0x0056EF79 File Offset: 0x0056D379
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2508;
		}

		// Token: 0x060128CA RID: 75978 RVA: 0x0056EF93 File Offset: 0x0056D393
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2BC RID: 49852
		private int method_p0;
	}
}
