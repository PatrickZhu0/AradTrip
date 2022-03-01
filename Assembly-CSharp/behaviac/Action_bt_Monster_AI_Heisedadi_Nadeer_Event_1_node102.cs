using System;

namespace behaviac
{
	// Token: 0x0200350B RID: 13579
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node102 : Action
	{
		// Token: 0x06015259 RID: 86617 RVA: 0x0065EFE6 File Offset: 0x0065D3E6
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node102()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 5000;
			this.method_p1 = 0;
		}

		// Token: 0x0601525A RID: 86618 RVA: 0x0065F008 File Offset: 0x0065D408
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400EB93 RID: 60307
		private int method_p0;

		// Token: 0x0400EB94 RID: 60308
		private int method_p1;
	}
}
