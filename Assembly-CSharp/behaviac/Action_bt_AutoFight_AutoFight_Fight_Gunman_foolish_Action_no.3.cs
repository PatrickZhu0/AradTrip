using System;

namespace behaviac
{
	// Token: 0x020020D8 RID: 8408
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node9 : Action
	{
		// Token: 0x06012B45 RID: 76613 RVA: 0x0057E6D1 File Offset: 0x0057CAD1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_foolish_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012B46 RID: 76614 RVA: 0x0057E6EB File Offset: 0x0057CAEB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C539 RID: 50489
		private int method_p0;
	}
}
