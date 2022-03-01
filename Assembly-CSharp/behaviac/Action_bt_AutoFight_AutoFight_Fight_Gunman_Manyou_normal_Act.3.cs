using System;

namespace behaviac
{
	// Token: 0x02002180 RID: 8576
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node9 : Action
	{
		// Token: 0x06012C90 RID: 76944 RVA: 0x005865F5 File Offset: 0x005849F5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1101;
		}

		// Token: 0x06012C91 RID: 76945 RVA: 0x0058660F File Offset: 0x00584A0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C684 RID: 50820
		private int method_p0;
	}
}
