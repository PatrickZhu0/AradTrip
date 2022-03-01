using System;

namespace behaviac
{
	// Token: 0x02002138 RID: 8504
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node19 : Action
	{
		// Token: 0x06012C02 RID: 76802 RVA: 0x00582DA5 File Offset: 0x005811A5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012C03 RID: 76803 RVA: 0x00582DBF File Offset: 0x005811BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5F6 RID: 50678
		private int method_p0;
	}
}
