using System;

namespace behaviac
{
	// Token: 0x02002E9E RID: 11934
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node31 : Action
	{
		// Token: 0x06014617 RID: 83479 RVA: 0x00620E48 File Offset: 0x0061F248
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node31()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06014618 RID: 83480 RVA: 0x00620E5E File Offset: 0x0061F25E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ResetTime(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF92 RID: 57234
		private int method_p0;
	}
}
