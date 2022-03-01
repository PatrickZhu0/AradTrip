using System;

namespace behaviac
{
	// Token: 0x02002D96 RID: 11670
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node44 : Condition
	{
		// Token: 0x0601440D RID: 82957 RVA: 0x00615A71 File Offset: 0x00613E71
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Boss_ACTION_node44()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x0601440E RID: 82958 RVA: 0x00615A80 File Offset: 0x00613E80
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DDD6 RID: 56790
		private int opl_p0;
	}
}
