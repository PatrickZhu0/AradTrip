using System;

namespace behaviac
{
	// Token: 0x02002198 RID: 8600
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node39 : Action
	{
		// Token: 0x06012CC0 RID: 76992 RVA: 0x005870FD File Offset: 0x005854FD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1006;
		}

		// Token: 0x06012CC1 RID: 76993 RVA: 0x00587117 File Offset: 0x00585517
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6B4 RID: 50868
		private int method_p0;
	}
}
