using System;

namespace behaviac
{
	// Token: 0x02003458 RID: 13400
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node29 : Action
	{
		// Token: 0x060150FC RID: 86268 RVA: 0x00658669 File Offset: 0x00656A69
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521858;
			this.method_p2 = -1;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150FD RID: 86269 RVA: 0x006586A0 File Offset: 0x00656AA0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9E8 RID: 59880
		private BE_Target method_p0;

		// Token: 0x0400E9E9 RID: 59881
		private int method_p1;

		// Token: 0x0400E9EA RID: 59882
		private int method_p2;

		// Token: 0x0400E9EB RID: 59883
		private int method_p3;

		// Token: 0x0400E9EC RID: 59884
		private int method_p4;
	}
}
