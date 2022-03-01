using System;

namespace behaviac
{
	// Token: 0x020030BC RID: 12476
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node2 : Action
	{
		// Token: 0x06014A36 RID: 84534 RVA: 0x00636F87 File Offset: 0x00635387
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A37 RID: 84535 RVA: 0x00636FBE File Offset: 0x006353BE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E39B RID: 58267
		private BE_Target method_p0;

		// Token: 0x0400E39C RID: 58268
		private int method_p1;

		// Token: 0x0400E39D RID: 58269
		private int method_p2;

		// Token: 0x0400E39E RID: 58270
		private int method_p3;

		// Token: 0x0400E39F RID: 58271
		private int method_p4;
	}
}
