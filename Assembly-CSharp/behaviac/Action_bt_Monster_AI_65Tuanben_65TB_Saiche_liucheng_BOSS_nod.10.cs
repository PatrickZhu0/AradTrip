using System;

namespace behaviac
{
	// Token: 0x02002BE8 RID: 11240
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node14 : Action
	{
		// Token: 0x060140CF RID: 82127 RVA: 0x0060546E File Offset: 0x0060386E
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140D0 RID: 82128 RVA: 0x00605484 File Offset: 0x00603884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAB3 RID: 55987
		private int method_p0;
	}
}
