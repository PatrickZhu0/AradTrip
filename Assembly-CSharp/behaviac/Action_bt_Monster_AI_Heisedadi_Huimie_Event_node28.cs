using System;

namespace behaviac
{
	// Token: 0x02003437 RID: 13367
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Huimie_Event_node28 : Action
	{
		// Token: 0x060150BC RID: 86204 RVA: 0x00657232 File Offset: 0x00655632
		public Action_bt_Monster_AI_Heisedadi_Huimie_Event_node28()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 1;
		}

		// Token: 0x060150BD RID: 86205 RVA: 0x00657248 File Offset: 0x00655648
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E98F RID: 59791
		private int method_p0;
	}
}
