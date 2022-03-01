using System;

namespace behaviac
{
	// Token: 0x02002188 RID: 8584
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node19 : Action
	{
		// Token: 0x06012CA0 RID: 76960 RVA: 0x005869DD File Offset: 0x00584DDD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012CA1 RID: 76961 RVA: 0x005869F7 File Offset: 0x00584DF7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C694 RID: 50836
		private int method_p0;
	}
}
