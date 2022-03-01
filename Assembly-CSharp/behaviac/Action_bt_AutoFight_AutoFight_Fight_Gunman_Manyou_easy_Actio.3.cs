using System;

namespace behaviac
{
	// Token: 0x02002108 RID: 8456
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node9 : Action
	{
		// Token: 0x06012BA3 RID: 76707 RVA: 0x00580BA1 File Offset: 0x0057EFA1
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1101;
		}

		// Token: 0x06012BA4 RID: 76708 RVA: 0x00580BBB File Offset: 0x0057EFBB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C597 RID: 50583
		private int method_p0;
	}
}
