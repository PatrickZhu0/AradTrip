using System;

namespace behaviac
{
	// Token: 0x02002E9A RID: 11930
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node26 : Condition
	{
		// Token: 0x0601460F RID: 83471 RVA: 0x00620D26 File Offset: 0x0061F126
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node26()
		{
			this.opl_p0 = 3;
		}

		// Token: 0x06014610 RID: 83472 RVA: 0x00620D38 File Offset: 0x0061F138
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 65000;
			bool flag = num < num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF8C RID: 57228
		private int opl_p0;
	}
}
