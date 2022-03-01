using System;

namespace behaviac
{
	// Token: 0x02002BF4 RID: 11252
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node69 : Action
	{
		// Token: 0x060140E7 RID: 82151 RVA: 0x0060582C File Offset: 0x00603C2C
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node69()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140E8 RID: 82152 RVA: 0x00605842 File Offset: 0x00603C42
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DACD RID: 56013
		private int method_p0;
	}
}
