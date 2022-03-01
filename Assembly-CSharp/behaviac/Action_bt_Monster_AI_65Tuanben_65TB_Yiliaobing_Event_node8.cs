using System;

namespace behaviac
{
	// Token: 0x02002D1F RID: 11551
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node8 : Action
	{
		// Token: 0x06014329 RID: 82729 RVA: 0x0061159B File Offset: 0x0060F99B
		public Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Event_node8()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521983;
			this.method_p2 = -1;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x0601432A RID: 82730 RVA: 0x006115D2 File Offset: 0x0060F9D2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCDD RID: 56541
		private BE_Target method_p0;

		// Token: 0x0400DCDE RID: 56542
		private int method_p1;

		// Token: 0x0400DCDF RID: 56543
		private int method_p2;

		// Token: 0x0400DCE0 RID: 56544
		private int method_p3;

		// Token: 0x0400DCE1 RID: 56545
		private int method_p4;
	}
}
