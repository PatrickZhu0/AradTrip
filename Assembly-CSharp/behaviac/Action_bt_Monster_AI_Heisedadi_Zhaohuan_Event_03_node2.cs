using System;

namespace behaviac
{
	// Token: 0x02003563 RID: 13667
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2 : Action
	{
		// Token: 0x06015301 RID: 86785 RVA: 0x00662CBA File Offset: 0x006610BA
		public Action_bt_Monster_AI_Heisedadi_Zhaohuan_Event_03_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521853;
			this.method_p2 = 1000;
			this.method_p3 = 0;
			this.method_p4 = 0;
		}

		// Token: 0x06015302 RID: 86786 RVA: 0x00662CF4 File Offset: 0x006610F4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECB5 RID: 60597
		private BE_Target method_p0;

		// Token: 0x0400ECB6 RID: 60598
		private int method_p1;

		// Token: 0x0400ECB7 RID: 60599
		private int method_p2;

		// Token: 0x0400ECB8 RID: 60600
		private int method_p3;

		// Token: 0x0400ECB9 RID: 60601
		private int method_p4;
	}
}
