using System;

namespace behaviac
{
	// Token: 0x0200372E RID: 14126
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node13 : Action
	{
		// Token: 0x06015668 RID: 87656 RVA: 0x00674C78 File Offset: 0x00673078
		public Action_bt_Monster_AI_Niutou_tongshuai_Niutou_tongshuai_Event_jiasu_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 538802;
			this.method_p2 = 60000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015669 RID: 87657 RVA: 0x00674CB2 File Offset: 0x006730B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F033 RID: 61491
		private BE_Target method_p0;

		// Token: 0x0400F034 RID: 61492
		private int method_p1;

		// Token: 0x0400F035 RID: 61493
		private int method_p2;

		// Token: 0x0400F036 RID: 61494
		private int method_p3;

		// Token: 0x0400F037 RID: 61495
		private int method_p4;
	}
}
