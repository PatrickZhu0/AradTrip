using System;

namespace behaviac
{
	// Token: 0x020030F0 RID: 12528
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node6 : Action
	{
		// Token: 0x06014A91 RID: 84625 RVA: 0x00638B52 File Offset: 0x00636F52
		public Action_bt_Monster_AI_Chapter10_Dazhoufaqiu_An_Event_node6()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522078;
			this.method_p2 = 1000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06014A92 RID: 84626 RVA: 0x00638B8D File Offset: 0x00636F8D
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E401 RID: 58369
		private BE_Target method_p0;

		// Token: 0x0400E402 RID: 58370
		private int method_p1;

		// Token: 0x0400E403 RID: 58371
		private int method_p2;

		// Token: 0x0400E404 RID: 58372
		private int method_p3;

		// Token: 0x0400E405 RID: 58373
		private int method_p4;
	}
}
