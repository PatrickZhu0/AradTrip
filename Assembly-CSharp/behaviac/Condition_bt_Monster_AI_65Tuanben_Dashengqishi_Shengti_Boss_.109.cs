using System;

namespace behaviac
{
	// Token: 0x02002E8B RID: 11915
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node1 : Condition
	{
		// Token: 0x060145F1 RID: 83441 RVA: 0x0062094E File Offset: 0x0061ED4E
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_EVENT_node1()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x060145F2 RID: 83442 RVA: 0x00620960 File Offset: 0x0061ED60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DF75 RID: 57205
		private int opl_p0;
	}
}
