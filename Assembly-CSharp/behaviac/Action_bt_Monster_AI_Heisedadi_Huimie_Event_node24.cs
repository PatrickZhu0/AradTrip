using System;

namespace behaviac
{
	// Token: 0x0200343E RID: 13374
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node24 : Action
	{
		// Token: 0x060150CA RID: 86218 RVA: 0x00657450 File Offset: 0x00655850
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node24()
		{
			this.m_resultOption = EBTStatus.BT_INVALID;
			this.method_p0 = 500;
			this.method_p1 = 2;
		}

		// Token: 0x060150CB RID: 86219 RVA: 0x00657474 File Offset: 0x00655874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			return ((BTAgent)pAgent).Action_WaitGameTime(this.method_p0, this.method_p1);
		}

		// Token: 0x0400E99C RID: 59804
		private int method_p0;

		// Token: 0x0400E99D RID: 59805
		private int method_p1;
	}
}
