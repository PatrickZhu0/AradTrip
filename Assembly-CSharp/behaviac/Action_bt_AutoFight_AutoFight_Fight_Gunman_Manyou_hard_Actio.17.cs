using System;

namespace behaviac
{
	// Token: 0x02002174 RID: 8564
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node44 : Action
	{
		// Token: 0x06012C79 RID: 76921 RVA: 0x00585589 File Offset: 0x00583989
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_hard_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012C7A RID: 76922 RVA: 0x005855A3 File Offset: 0x005839A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C66D RID: 50797
		private int method_p0;
	}
}
