using System;

namespace behaviac
{
	// Token: 0x02002158 RID: 8536
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node9 : Action
	{
		// Token: 0x06012C41 RID: 76865 RVA: 0x005847D9 File Offset: 0x00582BD9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1101;
		}

		// Token: 0x06012C42 RID: 76866 RVA: 0x005847F3 File Offset: 0x00582BF3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C635 RID: 50741
		private int method_p0;
	}
}
