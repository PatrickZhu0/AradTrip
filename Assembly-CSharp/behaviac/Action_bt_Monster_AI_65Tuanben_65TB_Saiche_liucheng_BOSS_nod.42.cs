using System;

namespace behaviac
{
	// Token: 0x02002C29 RID: 11305
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node37 : Action
	{
		// Token: 0x06014151 RID: 82257 RVA: 0x00606677 File Offset: 0x00604A77
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node37()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 3;
		}

		// Token: 0x06014152 RID: 82258 RVA: 0x00606694 File Offset: 0x00604A94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB20 RID: 56096
		private int method_p0;

		// Token: 0x0400DB21 RID: 56097
		private int method_p1;
	}
}
