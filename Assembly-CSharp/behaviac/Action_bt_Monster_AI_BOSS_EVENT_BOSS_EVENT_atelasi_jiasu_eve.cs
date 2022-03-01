using System;

namespace behaviac
{
	// Token: 0x020030AD RID: 12461
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_atelasi_jiasu_event_node2 : Action
	{
		// Token: 0x06014A1D RID: 84509 RVA: 0x0063680F File Offset: 0x00634C0F
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_atelasi_jiasu_event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521226;
			this.method_p2 = -1;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A1E RID: 84510 RVA: 0x00636845 File Offset: 0x00634C45
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E37B RID: 58235
		private BE_Target method_p0;

		// Token: 0x0400E37C RID: 58236
		private int method_p1;

		// Token: 0x0400E37D RID: 58237
		private int method_p2;

		// Token: 0x0400E37E RID: 58238
		private int method_p3;

		// Token: 0x0400E37F RID: 58239
		private int method_p4;
	}
}
