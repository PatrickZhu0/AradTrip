using System;

namespace behaviac
{
	// Token: 0x020030B3 RID: 12467
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node7 : Action
	{
		// Token: 0x06014A27 RID: 84519 RVA: 0x006369FF File Offset: 0x00634DFF
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_beijibati_event_node7()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521231;
			this.method_p2 = 5000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A28 RID: 84520 RVA: 0x00636A3A File Offset: 0x00634E3A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E383 RID: 58243
		private BE_Target method_p0;

		// Token: 0x0400E384 RID: 58244
		private int method_p1;

		// Token: 0x0400E385 RID: 58245
		private int method_p2;

		// Token: 0x0400E386 RID: 58246
		private int method_p3;

		// Token: 0x0400E387 RID: 58247
		private int method_p4;
	}
}
