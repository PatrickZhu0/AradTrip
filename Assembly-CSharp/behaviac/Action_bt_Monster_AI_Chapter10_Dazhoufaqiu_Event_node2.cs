using System;

namespace behaviac
{
	// Token: 0x020030F3 RID: 12531
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_Event_node2 : Action
	{
		// Token: 0x06014A96 RID: 84630 RVA: 0x00638DAA File Offset: 0x006371AA
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522077;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A97 RID: 84631 RVA: 0x00638DE5 File Offset: 0x006371E5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E408 RID: 58376
		private BE_Target method_p0;

		// Token: 0x0400E409 RID: 58377
		private int method_p1;

		// Token: 0x0400E40A RID: 58378
		private int method_p2;

		// Token: 0x0400E40B RID: 58379
		private int method_p3;

		// Token: 0x0400E40C RID: 58380
		private int method_p4;
	}
}
