using System;

namespace behaviac
{
	// Token: 0x02002E87 RID: 11911
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node3 : Condition
	{
		// Token: 0x060145E9 RID: 83433 RVA: 0x0062083E File Offset: 0x0061EC3E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node3()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060145EA RID: 83434 RVA: 0x00620850 File Offset: 0x0061EC50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF6E RID: 57198
		private int opl_p0;
	}
}
