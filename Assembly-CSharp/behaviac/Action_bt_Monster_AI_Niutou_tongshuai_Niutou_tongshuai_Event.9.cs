using System;

namespace behaviac
{
	// Token: 0x02003732 RID: 14130
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node21 : Action
	{
		// Token: 0x06015670 RID: 87664 RVA: 0x00674DB9 File Offset: 0x006731B9
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538804;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015671 RID: 87665 RVA: 0x00674DF3 File Offset: 0x006731F3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F03D RID: 61501
		private BE_Target method_p0;

		// Token: 0x0400F03E RID: 61502
		private int method_p1;

		// Token: 0x0400F03F RID: 61503
		private int method_p2;

		// Token: 0x0400F040 RID: 61504
		private int method_p3;

		// Token: 0x0400F041 RID: 61505
		private int method_p4;
	}
}
