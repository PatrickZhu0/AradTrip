using System;

namespace behaviac
{
	// Token: 0x020021B4 RID: 8628
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node24 : Action
	{
		// Token: 0x06012CF7 RID: 77047 RVA: 0x00588995 File Offset: 0x00586D95
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1013;
		}

		// Token: 0x06012CF8 RID: 77048 RVA: 0x005889AF File Offset: 0x00586DAF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6EB RID: 50923
		private int method_p0;
	}
}
