using System;

namespace behaviac
{
	// Token: 0x02003D46 RID: 15686
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node7 : Condition
	{
		// Token: 0x06016222 RID: 90658 RVA: 0x006B0A6B File Offset: 0x006AEE6B
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node7()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06016223 RID: 90659 RVA: 0x006B0A7C File Offset: 0x006AEE7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA85 RID: 64133
		private int opl_p0;
	}
}
