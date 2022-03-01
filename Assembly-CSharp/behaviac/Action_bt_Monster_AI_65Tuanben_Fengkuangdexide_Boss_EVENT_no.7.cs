using System;

namespace behaviac
{
	// Token: 0x02002EFC RID: 12028
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node3 : Action
	{
		// Token: 0x060146D0 RID: 83664 RVA: 0x00624D39 File Offset: 0x00623139
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 92;
			this.method_p2 = 5000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x060146D1 RID: 83665 RVA: 0x00624D70 File Offset: 0x00623170
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E044 RID: 57412
		private BE_Target method_p0;

		// Token: 0x0400E045 RID: 57413
		private int method_p1;

		// Token: 0x0400E046 RID: 57414
		private int method_p2;

		// Token: 0x0400E047 RID: 57415
		private int method_p3;

		// Token: 0x0400E048 RID: 57416
		private int method_p4;
	}
}
