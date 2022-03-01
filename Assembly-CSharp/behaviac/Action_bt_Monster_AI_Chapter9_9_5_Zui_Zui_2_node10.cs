using System;

namespace behaviac
{
	// Token: 0x020031E9 RID: 12777
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node10 : Action
	{
		// Token: 0x06014C5E RID: 85086 RVA: 0x00642113 File Offset: 0x00640513
		public Action_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node10()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570262;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014C5F RID: 85087 RVA: 0x0064214A File Offset: 0x0064054A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5B7 RID: 58807
		private BE_Target method_p0;

		// Token: 0x0400E5B8 RID: 58808
		private int method_p1;

		// Token: 0x0400E5B9 RID: 58809
		private int method_p2;

		// Token: 0x0400E5BA RID: 58810
		private int method_p3;

		// Token: 0x0400E5BB RID: 58811
		private int method_p4;
	}
}
