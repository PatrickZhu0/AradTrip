using System;

namespace behaviac
{
	// Token: 0x0200353E RID: 13630
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node99 : Action
	{
		// Token: 0x060152BF RID: 86719 RVA: 0x00660278 File Offset: 0x0065E678
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node99()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521744;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x060152C0 RID: 86720 RVA: 0x006602AF File Offset: 0x0065E6AF
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC6B RID: 60523
		private BE_Target method_p0;

		// Token: 0x0400EC6C RID: 60524
		private int method_p1;

		// Token: 0x0400EC6D RID: 60525
		private int method_p2;

		// Token: 0x0400EC6E RID: 60526
		private int method_p3;

		// Token: 0x0400EC6F RID: 60527
		private int method_p4;
	}
}
