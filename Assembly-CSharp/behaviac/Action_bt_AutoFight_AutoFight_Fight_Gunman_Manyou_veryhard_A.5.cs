using System;

namespace behaviac
{
	// Token: 0x020021AC RID: 8620
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node14 : Action
	{
		// Token: 0x06012CE7 RID: 77031 RVA: 0x005885AD File Offset: 0x005869AD
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1005;
		}

		// Token: 0x06012CE8 RID: 77032 RVA: 0x005885C7 File Offset: 0x005869C7
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6DB RID: 50907
		private int method_p0;
	}
}
