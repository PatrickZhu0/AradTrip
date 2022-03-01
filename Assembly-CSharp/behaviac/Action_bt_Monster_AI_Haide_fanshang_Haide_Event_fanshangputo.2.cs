using System;

namespace behaviac
{
	// Token: 0x020033D6 RID: 13270
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node11 : Action
	{
		// Token: 0x06015002 RID: 86018 RVA: 0x00653C59 File Offset: 0x00652059
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2501;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06015003 RID: 86019 RVA: 0x00653C93 File Offset: 0x00652093
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8EC RID: 59628
		private BE_Target method_p0;

		// Token: 0x0400E8ED RID: 59629
		private int method_p1;

		// Token: 0x0400E8EE RID: 59630
		private int method_p2;

		// Token: 0x0400E8EF RID: 59631
		private int method_p3;

		// Token: 0x0400E8F0 RID: 59632
		private int method_p4;
	}
}
