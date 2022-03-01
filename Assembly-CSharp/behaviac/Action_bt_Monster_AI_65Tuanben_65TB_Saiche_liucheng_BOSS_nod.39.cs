using System;

namespace behaviac
{
	// Token: 0x02002C24 RID: 11300
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node34 : Action
	{
		// Token: 0x06014147 RID: 82247 RVA: 0x00606551 File Offset: 0x00604951
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node34()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 2;
		}

		// Token: 0x06014148 RID: 82248 RVA: 0x0060656E File Offset: 0x0060496E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB19 RID: 56089
		private int method_p0;

		// Token: 0x0400DB1A RID: 56090
		private int method_p1;
	}
}
