using System;

namespace behaviac
{
	// Token: 0x020034F5 RID: 13557
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node23 : Action
	{
		// Token: 0x0601522D RID: 86573 RVA: 0x0065E973 File Offset: 0x0065CD73
		public Action_bt_Monster_AI_Heisedadi_Nadeer_Event_1_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521794;
		}

		// Token: 0x0601522E RID: 86574 RVA: 0x0065E994 File Offset: 0x0065CD94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EB56 RID: 60246
		private BE_Target method_p0;

		// Token: 0x0400EB57 RID: 60247
		private int method_p1;
	}
}
