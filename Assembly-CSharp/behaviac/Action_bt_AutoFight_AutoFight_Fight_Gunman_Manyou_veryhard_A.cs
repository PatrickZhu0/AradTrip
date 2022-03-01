using System;

namespace behaviac
{
	// Token: 0x020021A4 RID: 8612
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node4 : Action
	{
		// Token: 0x06012CD7 RID: 77015 RVA: 0x00588275 File Offset: 0x00586675
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1106;
		}

		// Token: 0x06012CD8 RID: 77016 RVA: 0x0058828F File Offset: 0x0058668F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6CB RID: 50891
		private int method_p0;
	}
}
