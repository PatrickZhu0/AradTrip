using System;

namespace behaviac
{
	// Token: 0x02002BF9 RID: 11257
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node76 : Action
	{
		// Token: 0x060140F1 RID: 82161 RVA: 0x00605964 File Offset: 0x00603D64
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node76()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060140F2 RID: 82162 RVA: 0x0060597A File Offset: 0x00603D7A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAD4 RID: 56020
		private int method_p0;
	}
}
