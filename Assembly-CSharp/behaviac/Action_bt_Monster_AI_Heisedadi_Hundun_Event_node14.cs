using System;

namespace behaviac
{
	// Token: 0x02003444 RID: 13380
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node14 : Action
	{
		// Token: 0x060150D4 RID: 86228 RVA: 0x00657F87 File Offset: 0x00656387
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node14()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521855;
			this.method_p2 = -1;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150D5 RID: 86229 RVA: 0x00657FBE File Offset: 0x006563BE
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9A4 RID: 59812
		private BE_Target method_p0;

		// Token: 0x0400E9A5 RID: 59813
		private int method_p1;

		// Token: 0x0400E9A6 RID: 59814
		private int method_p2;

		// Token: 0x0400E9A7 RID: 59815
		private int method_p3;

		// Token: 0x0400E9A8 RID: 59816
		private int method_p4;
	}
}
