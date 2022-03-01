using System;

namespace behaviac
{
	// Token: 0x020030E0 RID: 12512
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node2 : Action
	{
		// Token: 0x06014A75 RID: 84597 RVA: 0x006382CE File Offset: 0x006366CE
		public Action_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522052;
			this.method_p2 = -1;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A76 RID: 84598 RVA: 0x00638305 File Offset: 0x00636705
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3E1 RID: 58337
		private BE_Target method_p0;

		// Token: 0x0400E3E2 RID: 58338
		private int method_p1;

		// Token: 0x0400E3E3 RID: 58339
		private int method_p2;

		// Token: 0x0400E3E4 RID: 58340
		private int method_p3;

		// Token: 0x0400E3E5 RID: 58341
		private int method_p4;
	}
}
