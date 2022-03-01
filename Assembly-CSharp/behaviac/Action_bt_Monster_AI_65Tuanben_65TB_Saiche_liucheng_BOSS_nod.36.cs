using System;

namespace behaviac
{
	// Token: 0x02002C1F RID: 11295
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node114 : Action
	{
		// Token: 0x0601413D RID: 82237 RVA: 0x0060641E File Offset: 0x0060481E
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node114()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
			this.method_p1 = 0;
		}

		// Token: 0x0601413E RID: 82238 RVA: 0x0060643B File Offset: 0x0060483B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB11 RID: 56081
		private int method_p0;

		// Token: 0x0400DB12 RID: 56082
		private int method_p1;
	}
}
