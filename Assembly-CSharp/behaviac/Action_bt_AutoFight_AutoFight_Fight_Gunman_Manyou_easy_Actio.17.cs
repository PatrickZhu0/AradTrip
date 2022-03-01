using System;

namespace behaviac
{
	// Token: 0x02002124 RID: 8484
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node44 : Action
	{
		// Token: 0x06012BDB RID: 76763 RVA: 0x00581951 File Offset: 0x0057FD51
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012BDC RID: 76764 RVA: 0x0058196B File Offset: 0x0057FD6B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5CF RID: 50639
		private int method_p0;
	}
}
