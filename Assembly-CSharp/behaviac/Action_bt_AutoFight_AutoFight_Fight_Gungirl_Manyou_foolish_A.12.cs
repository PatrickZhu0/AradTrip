using System;

namespace behaviac
{
	// Token: 0x02002000 RID: 8192
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node29 : Action
	{
		// Token: 0x0601299C RID: 76188 RVA: 0x00573BF9 File Offset: 0x00571FF9
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2510;
		}

		// Token: 0x0601299D RID: 76189 RVA: 0x00573C13 File Offset: 0x00572013
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C390 RID: 50064
		private int method_p0;
	}
}
