using System;

namespace behaviac
{
	// Token: 0x02003527 RID: 13607
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node90 : Action
	{
		// Token: 0x06015291 RID: 86673 RVA: 0x0065FA19 File Offset: 0x0065DE19
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node90()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521774;
		}

		// Token: 0x06015292 RID: 86674 RVA: 0x0065FA3A File Offset: 0x0065DE3A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC0A RID: 60426
		private BE_Target method_p0;

		// Token: 0x0400EC0B RID: 60427
		private int method_p1;
	}
}
