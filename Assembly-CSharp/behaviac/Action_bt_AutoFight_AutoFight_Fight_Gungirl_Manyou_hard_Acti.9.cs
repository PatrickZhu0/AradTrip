using System;

namespace behaviac
{
	// Token: 0x02002024 RID: 8228
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node24 : Action
	{
		// Token: 0x060129E3 RID: 76259 RVA: 0x005758B5 File Offset: 0x00573CB5
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_hard_Action_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2513;
		}

		// Token: 0x060129E4 RID: 76260 RVA: 0x005758CF File Offset: 0x00573CCF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C3D7 RID: 50135
		private int method_p0;
	}
}
