using System;

namespace behaviac
{
	// Token: 0x02003438 RID: 13368
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node11 : Action
	{
		// Token: 0x060150BE RID: 86206 RVA: 0x0065725C File Offset: 0x0065565C
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node11()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 15000;
			this.method_p1 = 1;
		}

		// Token: 0x060150BF RID: 86207 RVA: 0x00657280 File Offset: 0x00655680
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E990 RID: 59792
		private int method_p0;

		// Token: 0x0400E991 RID: 59793
		private int method_p1;
	}
}
