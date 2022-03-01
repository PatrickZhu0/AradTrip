using System;

namespace behaviac
{
	// Token: 0x02002EF1 RID: 12017
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node19 : Action
	{
		// Token: 0x060146BA RID: 83642 RVA: 0x00624A9A File Offset: 0x00622E9A
		public Action_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node19()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
		}

		// Token: 0x060146BB RID: 83643 RVA: 0x00624AB0 File Offset: 0x00622EB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E033 RID: 57395
		private int method_p0;
	}
}
