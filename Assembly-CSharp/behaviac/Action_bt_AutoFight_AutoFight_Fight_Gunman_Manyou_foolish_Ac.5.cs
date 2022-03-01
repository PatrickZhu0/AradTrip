using System;

namespace behaviac
{
	// Token: 0x02002134 RID: 8500
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node14 : Action
	{
		// Token: 0x06012BFA RID: 76794 RVA: 0x00582B59 File Offset: 0x00580F59
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_foolish_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012BFB RID: 76795 RVA: 0x00582B73 File Offset: 0x00580F73
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C5EE RID: 50670
		private int method_p0;
	}
}
