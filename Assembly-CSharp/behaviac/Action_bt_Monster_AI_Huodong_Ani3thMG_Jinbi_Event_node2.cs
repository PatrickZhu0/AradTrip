using System;

namespace behaviac
{
	// Token: 0x02003566 RID: 13670
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node2 : Action
	{
		// Token: 0x06015306 RID: 86790 RVA: 0x00662E2F File Offset: 0x0066122F
		public Action_bt_Monster_AI_Huodong_Ani3thMG_Jinbi_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522098;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06015307 RID: 86791 RVA: 0x00662E6A File Offset: 0x0066126A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECBB RID: 60603
		private BE_Target method_p0;

		// Token: 0x0400ECBC RID: 60604
		private int method_p1;

		// Token: 0x0400ECBD RID: 60605
		private int method_p2;

		// Token: 0x0400ECBE RID: 60606
		private int method_p3;

		// Token: 0x0400ECBF RID: 60607
		private int method_p4;
	}
}
