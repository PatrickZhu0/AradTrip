using System;

namespace behaviac
{
	// Token: 0x0200343D RID: 13373
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node29 : Action
	{
		// Token: 0x060150C8 RID: 86216 RVA: 0x00657426 File Offset: 0x00655826
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node29()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 2;
		}

		// Token: 0x060150C9 RID: 86217 RVA: 0x0065743C File Offset: 0x0065583C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E99B RID: 59803
		private int method_p0;
	}
}
