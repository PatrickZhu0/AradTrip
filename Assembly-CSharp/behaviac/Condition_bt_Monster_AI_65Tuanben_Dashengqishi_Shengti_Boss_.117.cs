using System;

namespace behaviac
{
	// Token: 0x02002E9B RID: 11931
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node27 : Condition
	{
		// Token: 0x06014611 RID: 83473 RVA: 0x00620D6F File Offset: 0x0061F16F
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node27()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06014612 RID: 83474 RVA: 0x00620D80 File Offset: 0x0061F180
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 25000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF8D RID: 57229
		private int opl_p0;
	}
}
