using System;

namespace behaviac
{
	// Token: 0x02003431 RID: 13361
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node27 : Action
	{
		// Token: 0x060150B0 RID: 86192 RVA: 0x00656DF8 File Offset: 0x006551F8
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node27()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x060150B1 RID: 86193 RVA: 0x00656E0E File Offset: 0x0065520E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E986 RID: 59782
		private int method_p0;
	}
}
