using System;

namespace behaviac
{
	// Token: 0x02002C23 RID: 11299
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node113 : Action
	{
		// Token: 0x06014145 RID: 82245 RVA: 0x0060651A File Offset: 0x0060491A
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node113()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
			this.method_p1 = 1;
		}

		// Token: 0x06014146 RID: 82246 RVA: 0x00606537 File Offset: 0x00604937
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB17 RID: 56087
		private int method_p0;

		// Token: 0x0400DB18 RID: 56088
		private int method_p1;
	}
}
