using System;

namespace behaviac
{
	// Token: 0x02002C20 RID: 11296
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node27 : Action
	{
		// Token: 0x0601413F RID: 82239 RVA: 0x00606455 File Offset: 0x00604855
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 4;
			this.method_p1 = 1;
		}

		// Token: 0x06014140 RID: 82240 RVA: 0x00606472 File Offset: 0x00604872
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB13 RID: 56083
		private int method_p0;

		// Token: 0x0400DB14 RID: 56084
		private int method_p1;
	}
}
