using System;

namespace behaviac
{
	// Token: 0x02003509 RID: 13577
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node50 : Action
	{
		// Token: 0x06015255 RID: 86613 RVA: 0x0065EF70 File Offset: 0x0065D370
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node50()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521749;
		}

		// Token: 0x06015256 RID: 86614 RVA: 0x0065EF91 File Offset: 0x0065D391
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB8F RID: 60303
		private BE_Target method_p0;

		// Token: 0x0400EB90 RID: 60304
		private int method_p1;
	}
}
