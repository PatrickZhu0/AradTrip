using System;

namespace behaviac
{
	// Token: 0x02003157 RID: 12631
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node11 : Action
	{
		// Token: 0x06014B4D RID: 84813 RVA: 0x0063C623 File Offset: 0x0063AA23
		public Action_bt_Monster_AI_Chapter10_Yiliaobing_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
		}

		// Token: 0x06014B4E RID: 84814 RVA: 0x0063C644 File Offset: 0x0063AA44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E4C8 RID: 58568
		private BE_Target method_p0;

		// Token: 0x0400E4C9 RID: 58569
		private int method_p1;
	}
}
