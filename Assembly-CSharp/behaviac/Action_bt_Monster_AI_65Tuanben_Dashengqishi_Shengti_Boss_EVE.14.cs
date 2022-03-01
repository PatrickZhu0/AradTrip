using System;

namespace behaviac
{
	// Token: 0x02002EA1 RID: 11937
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node43 : Action
	{
		// Token: 0x0601461D RID: 83485 RVA: 0x00620EFD File Offset: 0x0061F2FD
		public Action_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node43()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 570309;
		}

		// Token: 0x0601461E RID: 83486 RVA: 0x00620F1E File Offset: 0x0061F31E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF97 RID: 57239
		private BE_Target method_p0;

		// Token: 0x0400DF98 RID: 57240
		private int method_p1;
	}
}
