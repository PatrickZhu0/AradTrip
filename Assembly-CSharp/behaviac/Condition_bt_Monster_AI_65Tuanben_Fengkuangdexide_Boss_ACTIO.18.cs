using System;

namespace behaviac
{
	// Token: 0x02002EC3 RID: 11971
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node52 : Condition
	{
		// Token: 0x06014660 RID: 83552 RVA: 0x006224C9 File Offset: 0x006208C9
		public Condition_bt_Monster_AI_65Tuanben_Fengkuangdexide_Boss_ACTION_node52()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06014661 RID: 83553 RVA: 0x006224D8 File Offset: 0x006208D8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetTimerById(this.opl_p0);
			int num2 = 1;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DFCF RID: 57295
		private int opl_p0;
	}
}
