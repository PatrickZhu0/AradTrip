using System;

namespace behaviac
{
	// Token: 0x020030BF RID: 12479
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event1_node2 : Action
	{
		// Token: 0x06014A3B RID: 84539 RVA: 0x00637117 File Offset: 0x00635517
		public Action_bt_Monster_AI_BOSS_EVENT_BOSS_EVENT_buwanjia_kuangbao_event1_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 34;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014A3C RID: 84540 RVA: 0x0063714E File Offset: 0x0063554E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3A3 RID: 58275
		private BE_Target method_p0;

		// Token: 0x0400E3A4 RID: 58276
		private int method_p1;

		// Token: 0x0400E3A5 RID: 58277
		private int method_p2;

		// Token: 0x0400E3A6 RID: 58278
		private int method_p3;

		// Token: 0x0400E3A7 RID: 58279
		private int method_p4;
	}
}
