using System;

namespace behaviac
{
	// Token: 0x02003433 RID: 13363
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node21 : Action
	{
		// Token: 0x060150B4 RID: 86196 RVA: 0x00656E6A File Offset: 0x0065526A
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node21()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x060150B5 RID: 86197 RVA: 0x00656E80 File Offset: 0x00655280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E989 RID: 59785
		private int method_p0;
	}
}
