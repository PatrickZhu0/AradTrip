using System;

namespace behaviac
{
	// Token: 0x0200337A RID: 13178
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19 : Action
	{
		// Token: 0x06014F51 RID: 85841 RVA: 0x006507B0 File Offset: 0x0064EBB0
		public Action_bt_Monster_AI_GoblinKingdom_Juxingbaodan_idle_Event_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521400;
			this.method_p2 = 10;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014F52 RID: 85842 RVA: 0x006507E8 File Offset: 0x0064EBE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E815 RID: 59413
		private BE_Target method_p0;

		// Token: 0x0400E816 RID: 59414
		private int method_p1;

		// Token: 0x0400E817 RID: 59415
		private int method_p2;

		// Token: 0x0400E818 RID: 59416
		private int method_p3;

		// Token: 0x0400E819 RID: 59417
		private int method_p4;
	}
}
