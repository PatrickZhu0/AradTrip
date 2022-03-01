using System;

namespace behaviac
{
	// Token: 0x02003426 RID: 13350
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node12 : Action
	{
		// Token: 0x0601509B RID: 86171 RVA: 0x006569E2 File Offset: 0x00654DE2
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node12()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 1000;
			this.method_p1 = 0;
		}

		// Token: 0x0601509C RID: 86172 RVA: 0x00656A04 File Offset: 0x00654E04
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E96C RID: 59756
		private int method_p0;

		// Token: 0x0400E96D RID: 59757
		private int method_p1;
	}
}
