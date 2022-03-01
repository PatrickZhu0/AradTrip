using System;

namespace behaviac
{
	// Token: 0x020035AA RID: 13738
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node13 : Action
	{
		// Token: 0x06015383 RID: 86915 RVA: 0x0066530E File Offset: 0x0066370E
		public Action_bt_Monster_AI_Longren_longren_Longren_longren_Event_longren_Hundun_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528402;
			this.method_p2 = 500;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x06015384 RID: 86916 RVA: 0x00665349 File Offset: 0x00663749
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ED4E RID: 60750
		private BE_Target method_p0;

		// Token: 0x0400ED4F RID: 60751
		private int method_p1;

		// Token: 0x0400ED50 RID: 60752
		private int method_p2;

		// Token: 0x0400ED51 RID: 60753
		private int method_p3;

		// Token: 0x0400ED52 RID: 60754
		private int method_p4;
	}
}
