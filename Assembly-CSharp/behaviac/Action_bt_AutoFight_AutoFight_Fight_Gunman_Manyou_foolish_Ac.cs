using System;

namespace behaviac
{
	// Token: 0x0200212C RID: 8492
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node4 : Action
	{
		// Token: 0x06012BEA RID: 76778 RVA: 0x00582821 File Offset: 0x00580C21
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1106;
		}

		// Token: 0x06012BEB RID: 76779 RVA: 0x0058283B File Offset: 0x00580C3B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5DE RID: 50654
		private int method_p0;
	}
}
