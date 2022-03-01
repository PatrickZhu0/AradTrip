using System;

namespace behaviac
{
	// Token: 0x02002E98 RID: 11928
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node23 : Action
	{
		// Token: 0x0601460B RID: 83467 RVA: 0x00620CD2 File Offset: 0x0061F0D2
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node23()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x0601460C RID: 83468 RVA: 0x00620CE8 File Offset: 0x0061F0E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF8A RID: 57226
		private int method_p0;
	}
}
