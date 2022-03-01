using System;

namespace behaviac
{
	// Token: 0x02002E9D RID: 11933
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node30 : Action
	{
		// Token: 0x06014615 RID: 83477 RVA: 0x00620E1E File Offset: 0x0061F21E
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node30()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x06014616 RID: 83478 RVA: 0x00620E34 File Offset: 0x0061F234
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StopTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF91 RID: 57233
		private int method_p0;
	}
}
