using System;

namespace behaviac
{
	// Token: 0x020030EE RID: 12526
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node2 : Action
	{
		// Token: 0x06014A8D RID: 84621 RVA: 0x00638AA2 File Offset: 0x00636EA2
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522077;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A8E RID: 84622 RVA: 0x00638ADD File Offset: 0x00636EDD
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3FA RID: 58362
		private BE_Target method_p0;

		// Token: 0x0400E3FB RID: 58363
		private int method_p1;

		// Token: 0x0400E3FC RID: 58364
		private int method_p2;

		// Token: 0x0400E3FD RID: 58365
		private int method_p3;

		// Token: 0x0400E3FE RID: 58366
		private int method_p4;
	}
}
