using System;

namespace behaviac
{
	// Token: 0x02003427 RID: 13351
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node13 : Action
	{
		// Token: 0x0601509D RID: 86173 RVA: 0x00656A2A File Offset: 0x00654E2A
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node13()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521751;
			this.method_p2 = 9000000;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601509E RID: 86174 RVA: 0x00656A65 File Offset: 0x00654E65
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E96E RID: 59758
		private BE_Target method_p0;

		// Token: 0x0400E96F RID: 59759
		private int method_p1;

		// Token: 0x0400E970 RID: 59760
		private int method_p2;

		// Token: 0x0400E971 RID: 59761
		private int method_p3;

		// Token: 0x0400E972 RID: 59762
		private int method_p4;
	}
}
