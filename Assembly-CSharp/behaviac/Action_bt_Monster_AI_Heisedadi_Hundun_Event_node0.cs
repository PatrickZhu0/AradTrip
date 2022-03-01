using System;

namespace behaviac
{
	// Token: 0x02003447 RID: 13383
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node0 : Action
	{
		// Token: 0x060150DA RID: 86234 RVA: 0x0065807E File Offset: 0x0065647E
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node0()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521822;
			this.method_p2 = -1;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x060150DB RID: 86235 RVA: 0x006580B5 File Offset: 0x006564B5
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9AE RID: 59822
		private BE_Target method_p0;

		// Token: 0x0400E9AF RID: 59823
		private int method_p1;

		// Token: 0x0400E9B0 RID: 59824
		private int method_p2;

		// Token: 0x0400E9B1 RID: 59825
		private int method_p3;

		// Token: 0x0400E9B2 RID: 59826
		private int method_p4;
	}
}
