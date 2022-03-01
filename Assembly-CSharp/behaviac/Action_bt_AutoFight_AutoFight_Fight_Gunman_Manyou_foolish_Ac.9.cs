using System;

namespace behaviac
{
	// Token: 0x0200213C RID: 8508
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node24 : Action
	{
		// Token: 0x06012C0A RID: 76810 RVA: 0x00582F41 File Offset: 0x00581341
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012C0B RID: 76811 RVA: 0x00582F5B File Offset: 0x0058135B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5FE RID: 50686
		private int method_p0;
	}
}
