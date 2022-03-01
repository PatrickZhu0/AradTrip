using System;

namespace behaviac
{
	// Token: 0x020021F4 RID: 8692
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node24 : Action
	{
		// Token: 0x06012D75 RID: 77173 RVA: 0x0058BC29 File Offset: 0x0058A029
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_veryhard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012D76 RID: 77174 RVA: 0x0058BC43 File Offset: 0x0058A043
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C769 RID: 51049
		private int method_p0;
	}
}
