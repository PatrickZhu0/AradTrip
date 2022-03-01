using System;

namespace behaviac
{
	// Token: 0x020033D1 RID: 13265
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6 : Action
	{
		// Token: 0x06014FF8 RID: 86008 RVA: 0x00653AD5 File Offset: 0x00651ED5
		public Action_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 2401;
			this.method_p2 = 10000;
			this.method_p3 = 1;
			this.method_p4 = 0;
		}

		// Token: 0x06014FF9 RID: 86009 RVA: 0x00653B0F File Offset: 0x00651F0F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8E1 RID: 59617
		private BE_Target method_p0;

		// Token: 0x0400E8E2 RID: 59618
		private int method_p1;

		// Token: 0x0400E8E3 RID: 59619
		private int method_p2;

		// Token: 0x0400E8E4 RID: 59620
		private int method_p3;

		// Token: 0x0400E8E5 RID: 59621
		private int method_p4;
	}
}
