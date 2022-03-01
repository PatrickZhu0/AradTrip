using System;

namespace behaviac
{
	// Token: 0x02002D0C RID: 11532
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node6 : Action
	{
		// Token: 0x06014306 RID: 82694 RVA: 0x006109DF File Offset: 0x0060EDDF
		public Action_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 506408;
			this.method_p2 = 100;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014307 RID: 82695 RVA: 0x00610A17 File Offset: 0x0060EE17
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCAE RID: 56494
		private BE_Target method_p0;

		// Token: 0x0400DCAF RID: 56495
		private int method_p1;

		// Token: 0x0400DCB0 RID: 56496
		private int method_p2;

		// Token: 0x0400DCB1 RID: 56497
		private int method_p3;

		// Token: 0x0400DCB2 RID: 56498
		private int method_p4;
	}
}
