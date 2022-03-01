using System;

namespace behaviac
{
	// Token: 0x02002144 RID: 8516
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node34 : Action
	{
		// Token: 0x06012C1A RID: 76826 RVA: 0x00583329 File Offset: 0x00581729
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1009;
		}

		// Token: 0x06012C1B RID: 76827 RVA: 0x00583343 File Offset: 0x00581743
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C60E RID: 50702
		private int method_p0;
	}
}
