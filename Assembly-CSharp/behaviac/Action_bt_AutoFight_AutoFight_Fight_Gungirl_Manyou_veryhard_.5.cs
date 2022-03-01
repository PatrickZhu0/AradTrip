using System;

namespace behaviac
{
	// Token: 0x0200206C RID: 8300
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node14 : Action
	{
		// Token: 0x06012A71 RID: 76401 RVA: 0x00579105 File Offset: 0x00577505
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_veryhard_Action_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2504;
		}

		// Token: 0x06012A72 RID: 76402 RVA: 0x0057911F File Offset: 0x0057751F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C465 RID: 50277
		private int method_p0;
	}
}
