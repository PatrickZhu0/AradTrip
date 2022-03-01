using System;

namespace behaviac
{
	// Token: 0x020030B6 RID: 12470
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event_node2 : Action
	{
		// Token: 0x06014A2C RID: 84524 RVA: 0x00636C67 File Offset: 0x00635067
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A2D RID: 84525 RVA: 0x00636C9E File Offset: 0x0063509E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E38B RID: 58251
		private BE_Target method_p0;

		// Token: 0x0400E38C RID: 58252
		private int method_p1;

		// Token: 0x0400E38D RID: 58253
		private int method_p2;

		// Token: 0x0400E38E RID: 58254
		private int method_p3;

		// Token: 0x0400E38F RID: 58255
		private int method_p4;
	}
}
