using System;

namespace behaviac
{
	// Token: 0x020033DC RID: 13276
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node6 : Action
	{
		// Token: 0x0601500D RID: 86029 RVA: 0x006540DD File Offset: 0x006524DD
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangwangzhe_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2404;
			this.method_p2 = 4000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x0601500E RID: 86030 RVA: 0x00654117 File Offset: 0x00652517
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8F7 RID: 59639
		private BE_Target method_p0;

		// Token: 0x0400E8F8 RID: 59640
		private int method_p1;

		// Token: 0x0400E8F9 RID: 59641
		private int method_p2;

		// Token: 0x0400E8FA RID: 59642
		private int method_p3;

		// Token: 0x0400E8FB RID: 59643
		private int method_p4;
	}
}
