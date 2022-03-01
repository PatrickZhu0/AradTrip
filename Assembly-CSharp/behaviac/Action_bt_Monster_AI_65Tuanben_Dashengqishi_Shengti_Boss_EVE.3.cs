using System;

namespace behaviac
{
	// Token: 0x02002E8A RID: 11914
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node4 : Action
	{
		// Token: 0x060145EF RID: 83439 RVA: 0x00620917 File Offset: 0x0061ED17
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node4()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 0;
			this.method_p1 = 1;
		}

		// Token: 0x060145F0 RID: 83440 RVA: 0x00620934 File Offset: 0x0061ED34
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_SetCounter(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF73 RID: 57203
		private int method_p0;

		// Token: 0x0400DF74 RID: 57204
		private int method_p1;
	}
}
