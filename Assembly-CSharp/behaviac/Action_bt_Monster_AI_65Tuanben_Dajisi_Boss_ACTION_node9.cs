using System;

namespace behaviac
{
	// Token: 0x02002D6B RID: 11627
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node9 : Action
	{
		// Token: 0x060143B8 RID: 82872 RVA: 0x00614052 File Offset: 0x00612452
		public Action_bt_Monster_AI_65Tuanben_Dajisi_Boss_ACTION_node9()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 0;
		}

		// Token: 0x060143B9 RID: 82873 RVA: 0x0061406F File Offset: 0x0061246F
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD81 RID: 56705
		private int method_p0;

		// Token: 0x0400DD82 RID: 56706
		private int method_p1;
	}
}
