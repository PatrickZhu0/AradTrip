using System;

namespace behaviac
{
	// Token: 0x02002008 RID: 8200
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node39 : Action
	{
		// Token: 0x060129AC RID: 76204 RVA: 0x00573F31 File Offset: 0x00572331
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_foolish_Action_node39()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2519;
		}

		// Token: 0x060129AD RID: 76205 RVA: 0x00573F4B File Offset: 0x0057234B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3A0 RID: 50080
		private int method_p0;
	}
}
