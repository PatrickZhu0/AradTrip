using System;

namespace behaviac
{
	// Token: 0x0200352C RID: 13612
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node73 : Action
	{
		// Token: 0x0601529B RID: 86683 RVA: 0x0065FBC5 File Offset: 0x0065DFC5
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node73()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521783;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601529C RID: 86684 RVA: 0x0065FBFC File Offset: 0x0065DFFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC1A RID: 60442
		private BE_Target method_p0;

		// Token: 0x0400EC1B RID: 60443
		private int method_p1;

		// Token: 0x0400EC1C RID: 60444
		private int method_p2;

		// Token: 0x0400EC1D RID: 60445
		private int method_p3;

		// Token: 0x0400EC1E RID: 60446
		private int method_p4;
	}
}
