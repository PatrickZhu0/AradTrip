using System;

namespace behaviac
{
	// Token: 0x020030FB RID: 12539
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2 : Action
	{
		// Token: 0x06014AA4 RID: 84644 RVA: 0x0063917A File Offset: 0x0063757A
		public Action_bt_Monster_AI_Chapter10_Fengxiguang_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522994;
			this.method_p2 = 500;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014AA5 RID: 84645 RVA: 0x006391B5 File Offset: 0x006375B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E417 RID: 58391
		private BE_Target method_p0;

		// Token: 0x0400E418 RID: 58392
		private int method_p1;

		// Token: 0x0400E419 RID: 58393
		private int method_p2;

		// Token: 0x0400E41A RID: 58394
		private int method_p3;

		// Token: 0x0400E41B RID: 58395
		private int method_p4;
	}
}
