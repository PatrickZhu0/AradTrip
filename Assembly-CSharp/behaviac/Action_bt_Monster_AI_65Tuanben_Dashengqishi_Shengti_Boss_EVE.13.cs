using System;

namespace behaviac
{
	// Token: 0x02002EA0 RID: 11936
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node42 : Action
	{
		// Token: 0x0601461B RID: 83483 RVA: 0x00620ED3 File Offset: 0x0061F2D3
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node42()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = 3;
		}

		// Token: 0x0601461C RID: 83484 RVA: 0x00620EE9 File Offset: 0x0061F2E9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_StartTimer(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF96 RID: 57238
		private int method_p0;
	}
}
