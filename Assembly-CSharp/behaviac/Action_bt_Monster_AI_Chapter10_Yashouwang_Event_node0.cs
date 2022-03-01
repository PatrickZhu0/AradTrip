using System;

namespace behaviac
{
	// Token: 0x0200314E RID: 12622
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node0 : Action
	{
		// Token: 0x06014B3E RID: 84798 RVA: 0x0063C182 File Offset: 0x0063A582
		public Action_bt_Monster_AI_Chapter10_Yashouwang_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522977;
		}

		// Token: 0x06014B3F RID: 84799 RVA: 0x0063C1A3 File Offset: 0x0063A5A3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4B4 RID: 58548
		private BE_Target method_p0;

		// Token: 0x0400E4B5 RID: 58549
		private int method_p1;
	}
}
