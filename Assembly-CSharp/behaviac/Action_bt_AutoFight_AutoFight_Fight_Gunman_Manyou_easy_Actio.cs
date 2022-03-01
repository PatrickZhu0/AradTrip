using System;

namespace behaviac
{
	// Token: 0x02002104 RID: 8452
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node4 : Action
	{
		// Token: 0x06012B9B RID: 76699 RVA: 0x00580A05 File Offset: 0x0057EE05
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1106;
		}

		// Token: 0x06012B9C RID: 76700 RVA: 0x00580A1F File Offset: 0x0057EE1F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C58F RID: 50575
		private int method_p0;
	}
}
