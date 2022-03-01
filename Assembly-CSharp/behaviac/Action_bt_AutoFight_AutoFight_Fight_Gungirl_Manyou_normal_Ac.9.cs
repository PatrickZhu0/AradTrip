using System;

namespace behaviac
{
	// Token: 0x0200204C RID: 8268
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node24 : Action
	{
		// Token: 0x06012A32 RID: 76338 RVA: 0x005776D1 File Offset: 0x00575AD1
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x06012A33 RID: 76339 RVA: 0x005776EB File Offset: 0x00575AEB
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C426 RID: 50214
		private int method_p0;
	}
}
