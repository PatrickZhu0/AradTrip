using System;

namespace behaviac
{
	// Token: 0x02002E2E RID: 11822
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node2 : Condition
	{
		// Token: 0x06014539 RID: 83257 RVA: 0x0061A702 File Offset: 0x00618B02
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node2()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x0601453A RID: 83258 RVA: 0x0061A714 File Offset: 0x00618B14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DED7 RID: 57047
		private int opl_p0;
	}
}
