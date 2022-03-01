using System;

namespace behaviac
{
	// Token: 0x02002190 RID: 8592
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node29 : Action
	{
		// Token: 0x06012CB0 RID: 76976 RVA: 0x00586DC5 File Offset: 0x005851C5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1008;
		}

		// Token: 0x06012CB1 RID: 76977 RVA: 0x00586DDF File Offset: 0x005851DF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6A4 RID: 50852
		private int method_p0;
	}
}
