using System;

namespace behaviac
{
	// Token: 0x02002018 RID: 8216
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node9 : Action
	{
		// Token: 0x060129CB RID: 76235 RVA: 0x00575331 File Offset: 0x00573731
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2517;
		}

		// Token: 0x060129CC RID: 76236 RVA: 0x0057534B File Offset: 0x0057374B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3BF RID: 50111
		private int method_p0;
	}
}
