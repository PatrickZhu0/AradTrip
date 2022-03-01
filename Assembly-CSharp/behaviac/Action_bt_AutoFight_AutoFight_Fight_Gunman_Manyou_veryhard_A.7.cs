using System;

namespace behaviac
{
	// Token: 0x020021B0 RID: 8624
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node19 : Action
	{
		// Token: 0x06012CEF RID: 77039 RVA: 0x005887F9 File Offset: 0x00586BF9
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1007;
		}

		// Token: 0x06012CF0 RID: 77040 RVA: 0x00588813 File Offset: 0x00586C13
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6E3 RID: 50915
		private int method_p0;
	}
}
