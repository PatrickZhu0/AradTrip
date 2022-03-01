using System;

namespace behaviac
{
	// Token: 0x02003507 RID: 13575
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node47 : Action
	{
		// Token: 0x06015251 RID: 86609 RVA: 0x0065EEFA File Offset: 0x0065D2FA
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node47()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521747;
		}

		// Token: 0x06015252 RID: 86610 RVA: 0x0065EF1B File Offset: 0x0065D31B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB8B RID: 60299
		private BE_Target method_p0;

		// Token: 0x0400EB8C RID: 60300
		private int method_p1;
	}
}
