using System;

namespace behaviac
{
	// Token: 0x02002C05 RID: 11269
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node103 : Action
	{
		// Token: 0x06014109 RID: 82185 RVA: 0x00605CE9 File Offset: 0x006040E9
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node103()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x0601410A RID: 82186 RVA: 0x00605CFF File Offset: 0x006040FF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DAEA RID: 56042
		private int method_p0;
	}
}
