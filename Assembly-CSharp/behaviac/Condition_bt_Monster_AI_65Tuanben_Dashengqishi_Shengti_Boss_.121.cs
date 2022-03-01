using System;

namespace behaviac
{
	// Token: 0x02002EA3 RID: 11939
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node258 : Condition
	{
		// Token: 0x06014621 RID: 83489 RVA: 0x00620F9E File Offset: 0x0061F39E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node258()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014622 RID: 83490 RVA: 0x00620FB0 File Offset: 0x0061F3B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 10000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF9C RID: 57244
		private int opl_p0;
	}
}
