using System;

namespace behaviac
{
	// Token: 0x02002C1E RID: 11294
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node24 : Action
	{
		// Token: 0x0601413B RID: 82235 RVA: 0x006063F4 File Offset: 0x006047F4
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node24()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x0601413C RID: 82236 RVA: 0x0060640A File Offset: 0x0060480A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB10 RID: 56080
		private int method_p0;
	}
}
