using System;

namespace behaviac
{
	// Token: 0x0200345E RID: 13406
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Hundun_Event_node9 : Action
	{
		// Token: 0x06015108 RID: 86280 RVA: 0x006588A2 File Offset: 0x00656CA2
		public Action_bt_Monster_AI_Heisedadi_Hundun_Event_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521839;
			this.method_p2 = 100;
			this.method_p3 = 61;
			this.method_p4 = 0;
		}

		// Token: 0x06015109 RID: 86281 RVA: 0x006588DA File Offset: 0x00656CDA
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E9FD RID: 59901
		private BE_Target method_p0;

		// Token: 0x0400E9FE RID: 59902
		private int method_p1;

		// Token: 0x0400E9FF RID: 59903
		private int method_p2;

		// Token: 0x0400EA00 RID: 59904
		private int method_p3;

		// Token: 0x0400EA01 RID: 59905
		private int method_p4;
	}
}
