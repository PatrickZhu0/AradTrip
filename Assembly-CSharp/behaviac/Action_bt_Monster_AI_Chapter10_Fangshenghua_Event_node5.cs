using System;

namespace behaviac
{
	// Token: 0x020030F8 RID: 12536
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Chapter10_Fangshenghua_Event_node5 : Action
	{
		// Token: 0x06014A9F RID: 84639 RVA: 0x00638FC2 File Offset: 0x006373C2
		public Action_bt_Monster_AI_Chapter10_Fangshenghua_Event_node5()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522975;
		}

		// Token: 0x06014AA0 RID: 84640 RVA: 0x00638FE3 File Offset: 0x006373E3
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E413 RID: 58387
		private BE_Target method_p0;

		// Token: 0x0400E414 RID: 58388
		private int method_p1;
	}
}
