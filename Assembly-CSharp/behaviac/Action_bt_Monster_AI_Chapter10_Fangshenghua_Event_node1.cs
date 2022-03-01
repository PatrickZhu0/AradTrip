using System;

namespace behaviac
{
	// Token: 0x020030F7 RID: 12535
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Fangshenghua_Event_node1 : Action
	{
		// Token: 0x06014A9D RID: 84637 RVA: 0x00638F87 File Offset: 0x00637387
		public Action_bt_Monster_AI_Chapter10_Fangshenghua_Event_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522987;
		}

		// Token: 0x06014A9E RID: 84638 RVA: 0x00638FA8 File Offset: 0x006373A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E411 RID: 58385
		private BE_Target method_p0;

		// Token: 0x0400E412 RID: 58386
		private int method_p1;
	}
}
