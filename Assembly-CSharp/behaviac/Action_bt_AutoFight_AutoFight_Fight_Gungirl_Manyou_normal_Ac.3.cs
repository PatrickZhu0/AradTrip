using System;

namespace behaviac
{
	// Token: 0x02002040 RID: 8256
	[GeneratedTypeMetaInfo]
	internal class Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node9 : Action
	{
		// Token: 0x06012A1A RID: 76314 RVA: 0x0057714D File Offset: 0x0057554D
		public Action_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2517;
		}

		// Token: 0x06012A1B RID: 76315 RVA: 0x00577167 File Offset: 0x00575567
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Condition_CanUseSkill(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C40E RID: 50190
		private int method_p0;
	}
}
