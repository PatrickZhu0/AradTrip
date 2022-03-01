using System;

namespace behaviac
{
	// Token: 0x02002EC0 RID: 11968
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node56 : Condition
	{
		// Token: 0x0601465A RID: 83546 RVA: 0x006223FB File Offset: 0x006207FB
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node56()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x0601465B RID: 83547 RVA: 0x0062240C File Offset: 0x0062080C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFCA RID: 57290
		private int opl_p0;
	}
}
