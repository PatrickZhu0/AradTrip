using System;

namespace behaviac
{
	// Token: 0x02003439 RID: 13369
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node22 : Action
	{
		// Token: 0x060150C0 RID: 86208 RVA: 0x006572A6 File Offset: 0x006556A6
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node22()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060150C1 RID: 86209 RVA: 0x006572BC File Offset: 0x006556BC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E992 RID: 59794
		private int method_p0;
	}
}
