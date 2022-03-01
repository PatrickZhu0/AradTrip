using System;

namespace behaviac
{
	// Token: 0x020030C2 RID: 12482
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_geliya_zhaohuan_event_node2 : Action
	{
		// Token: 0x06014A40 RID: 84544 RVA: 0x006372A7 File Offset: 0x006356A7
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_geliya_zhaohuan_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521225;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A41 RID: 84545 RVA: 0x006372DD File Offset: 0x006356DD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3AB RID: 58283
		private BE_Target method_p0;

		// Token: 0x0400E3AC RID: 58284
		private int method_p1;

		// Token: 0x0400E3AD RID: 58285
		private int method_p2;

		// Token: 0x0400E3AE RID: 58286
		private int method_p3;

		// Token: 0x0400E3AF RID: 58287
		private int method_p4;
	}
}
