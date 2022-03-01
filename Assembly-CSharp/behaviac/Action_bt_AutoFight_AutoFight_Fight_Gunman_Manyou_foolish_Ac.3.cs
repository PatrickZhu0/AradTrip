using System;

namespace behaviac
{
	// Token: 0x02002130 RID: 8496
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node9 : Action
	{
		// Token: 0x06012BF2 RID: 76786 RVA: 0x005829BD File Offset: 0x00580DBD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1101;
		}

		// Token: 0x06012BF3 RID: 76787 RVA: 0x005829D7 File Offset: 0x00580DD7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5E6 RID: 50662
		private int method_p0;
	}
}
