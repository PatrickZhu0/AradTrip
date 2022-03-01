using System;

namespace behaviac
{
	// Token: 0x02002054 RID: 8276
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node34 : Action
	{
		// Token: 0x06012A42 RID: 76354 RVA: 0x00577AB9 File Offset: 0x00575EB9
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2512;
		}

		// Token: 0x06012A43 RID: 76355 RVA: 0x00577AD3 File Offset: 0x00575ED3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C436 RID: 50230
		private int method_p0;
	}
}
