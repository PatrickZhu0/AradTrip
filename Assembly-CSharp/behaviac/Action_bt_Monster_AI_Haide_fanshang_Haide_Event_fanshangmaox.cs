using System;

namespace behaviac
{
	// Token: 0x020033C6 RID: 13254
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node6 : Action
	{
		// Token: 0x06014FE3 RID: 85987 RVA: 0x006534CD File Offset: 0x006518CD
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2402;
			this.method_p2 = 8000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FE4 RID: 85988 RVA: 0x00653507 File Offset: 0x00651907
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8CB RID: 59595
		private BE_Target method_p0;

		// Token: 0x0400E8CC RID: 59596
		private int method_p1;

		// Token: 0x0400E8CD RID: 59597
		private int method_p2;

		// Token: 0x0400E8CE RID: 59598
		private int method_p3;

		// Token: 0x0400E8CF RID: 59599
		private int method_p4;
	}
}
