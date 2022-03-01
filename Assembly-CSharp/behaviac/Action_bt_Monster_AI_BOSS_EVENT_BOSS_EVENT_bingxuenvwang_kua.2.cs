using System;

namespace behaviac
{
	// Token: 0x020030B9 RID: 12473
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node2 : Action
	{
		// Token: 0x06014A31 RID: 84529 RVA: 0x00636DF7 File Offset: 0x006351F7
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_bingxuenvwang_kuangbao_event1_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A32 RID: 84530 RVA: 0x00636E2E File Offset: 0x0063522E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E393 RID: 58259
		private BE_Target method_p0;

		// Token: 0x0400E394 RID: 58260
		private int method_p1;

		// Token: 0x0400E395 RID: 58261
		private int method_p2;

		// Token: 0x0400E396 RID: 58262
		private int method_p3;

		// Token: 0x0400E397 RID: 58263
		private int method_p4;
	}
}
