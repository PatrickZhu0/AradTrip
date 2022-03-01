using System;

namespace behaviac
{
	// Token: 0x02003B4C RID: 15180
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node7 : Condition
	{
		// Token: 0x06015E4D RID: 89677 RVA: 0x0069D67B File Offset: 0x0069BA7B
		public Condition_bt_Monster_AI_Tuanben_Shuiren_Boss_ACTION_node7()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015E4E RID: 89678 RVA: 0x0069D68C File Offset: 0x0069BA8C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F71C RID: 63260
		private int opl_p0;
	}
}
