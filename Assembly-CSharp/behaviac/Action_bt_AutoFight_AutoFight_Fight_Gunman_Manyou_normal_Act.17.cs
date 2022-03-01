using System;

namespace behaviac
{
	// Token: 0x0200219C RID: 8604
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node44 : Action
	{
		// Token: 0x06012CC8 RID: 77000 RVA: 0x005873A5 File Offset: 0x005857A5
		public Action_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_normal_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1204;
		}

		// Token: 0x06012CC9 RID: 77001 RVA: 0x005873BF File Offset: 0x005857BF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C6BC RID: 50876
		private int method_p0;
	}
}
