using System;

namespace behaviac
{
	// Token: 0x02002C0B RID: 11275
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node110 : Action
	{
		// Token: 0x06014115 RID: 82197 RVA: 0x00605E4A File Offset: 0x0060424A
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node110()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x06014116 RID: 82198 RVA: 0x00605E60 File Offset: 0x00604260
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAF2 RID: 56050
		private int method_p0;
	}
}
