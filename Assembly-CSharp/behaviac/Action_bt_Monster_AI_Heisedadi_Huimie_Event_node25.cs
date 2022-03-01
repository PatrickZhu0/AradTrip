using System;

namespace behaviac
{
	// Token: 0x02003424 RID: 13348
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node25 : Action
	{
		// Token: 0x06015097 RID: 86167 RVA: 0x006568D2 File Offset: 0x00654CD2
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 38;
			this.method_p2 = 1500;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x06015098 RID: 86168 RVA: 0x0065690A File Offset: 0x00654D0A
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E965 RID: 59749
		private BE_Target method_p0;

		// Token: 0x0400E966 RID: 59750
		private int method_p1;

		// Token: 0x0400E967 RID: 59751
		private int method_p2;

		// Token: 0x0400E968 RID: 59752
		private int method_p3;

		// Token: 0x0400E969 RID: 59753
		private int method_p4;
	}
}
