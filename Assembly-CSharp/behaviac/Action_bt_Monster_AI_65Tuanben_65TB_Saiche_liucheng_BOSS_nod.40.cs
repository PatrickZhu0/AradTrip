using System;

namespace behaviac
{
	// Token: 0x02002C27 RID: 11303
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node115 : Action
	{
		// Token: 0x0601414D RID: 82253 RVA: 0x00606616 File Offset: 0x00604A16
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node115()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
			this.method_p1 = 2;
		}

		// Token: 0x0601414E RID: 82254 RVA: 0x00606633 File Offset: 0x00604A33
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB1D RID: 56093
		private int method_p0;

		// Token: 0x0400DB1E RID: 56094
		private int method_p1;
	}
}
