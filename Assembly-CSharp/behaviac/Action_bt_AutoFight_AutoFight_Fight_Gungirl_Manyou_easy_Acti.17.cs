using System;

namespace behaviac
{
	// Token: 0x02001FE1 RID: 8161
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node44 : Action
	{
		// Token: 0x0601295F RID: 76127 RVA: 0x005721F9 File Offset: 0x005705F9
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_easy_Action_node44()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2507;
		}

		// Token: 0x06012960 RID: 76128 RVA: 0x00572213 File Offset: 0x00570613
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C352 RID: 50002
		private int method_p0;
	}
}
