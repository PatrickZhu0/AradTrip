using System;

namespace behaviac
{
	// Token: 0x020033CB RID: 13259
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node11 : Action
	{
		// Token: 0x06014FED RID: 85997 RVA: 0x00653651 File Offset: 0x00651A51
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangmaoxian_node11()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2502;
			this.method_p2 = 8000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FEE RID: 85998 RVA: 0x0065368B File Offset: 0x00651A8B
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8D6 RID: 59606
		private BE_Target method_p0;

		// Token: 0x0400E8D7 RID: 59607
		private int method_p1;

		// Token: 0x0400E8D8 RID: 59608
		private int method_p2;

		// Token: 0x0400E8D9 RID: 59609
		private int method_p3;

		// Token: 0x0400E8DA RID: 59610
		private int method_p4;
	}
}
