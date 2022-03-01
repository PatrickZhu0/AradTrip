using System;

namespace behaviac
{
	// Token: 0x02002114 RID: 8468
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node24 : Action
	{
		// Token: 0x06012BBB RID: 76731 RVA: 0x00581125 File Offset: 0x0057F525
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_easy_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012BBC RID: 76732 RVA: 0x0058113F File Offset: 0x0057F53F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5AF RID: 50607
		private int method_p0;
	}
}
