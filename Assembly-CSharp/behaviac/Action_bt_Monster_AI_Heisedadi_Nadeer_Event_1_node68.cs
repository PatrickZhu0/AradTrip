using System;

namespace behaviac
{
	// Token: 0x0200350A RID: 13578
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node68 : Action
	{
		// Token: 0x06015257 RID: 86615 RVA: 0x0065EFAB File Offset: 0x0065D3AB
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node68()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521740;
		}

		// Token: 0x06015258 RID: 86616 RVA: 0x0065EFCC File Offset: 0x0065D3CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB91 RID: 60305
		private BE_Target method_p0;

		// Token: 0x0400EB92 RID: 60306
		private int method_p1;
	}
}
