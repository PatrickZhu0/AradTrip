using System;

namespace behaviac
{
	// Token: 0x02003714 RID: 14100
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node15 : Action
	{
		// Token: 0x06015636 RID: 87606 RVA: 0x00673D2A File Offset: 0x0067212A
		public Action_bt_Monster_AI_Niutou_niutouhuwei_Niutou_niutouhuwei_Event_Hundun_node15()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 528402;
			this.method_p2 = 500;
			this.method_p3 = 100;
			this.method_p4 = 0;
		}

		// Token: 0x06015637 RID: 87607 RVA: 0x00673D65 File Offset: 0x00672165
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F000 RID: 61440
		private BE_Target method_p0;

		// Token: 0x0400F001 RID: 61441
		private int method_p1;

		// Token: 0x0400F002 RID: 61442
		private int method_p2;

		// Token: 0x0400F003 RID: 61443
		private int method_p3;

		// Token: 0x0400F004 RID: 61444
		private int method_p4;
	}
}
