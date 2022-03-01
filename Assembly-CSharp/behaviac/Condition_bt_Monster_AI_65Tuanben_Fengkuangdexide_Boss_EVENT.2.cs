using System;

namespace behaviac
{
	// Token: 0x02002EF4 RID: 12020
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node22 : Condition
	{
		// Token: 0x060146C0 RID: 83648 RVA: 0x00624B18 File Offset: 0x00622F18
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_EVENT_node22()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x060146C1 RID: 83649 RVA: 0x00624B28 File Offset: 0x00622F28
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 18000;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E036 RID: 57398
		private int opl_p0;
	}
}
