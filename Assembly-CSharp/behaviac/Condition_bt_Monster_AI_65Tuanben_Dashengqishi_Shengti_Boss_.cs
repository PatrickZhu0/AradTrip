using System;

namespace behaviac
{
	// Token: 0x02002DCC RID: 11724
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node5 : Condition
	{
		// Token: 0x06014475 RID: 83061 RVA: 0x0061807F File Offset: 0x0061647F
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node5()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014476 RID: 83062 RVA: 0x00618090 File Offset: 0x00616490
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE36 RID: 56886
		private int opl_p0;
	}
}
