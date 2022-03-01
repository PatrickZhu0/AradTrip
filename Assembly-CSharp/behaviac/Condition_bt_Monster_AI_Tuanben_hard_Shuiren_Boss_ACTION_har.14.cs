using System;

namespace behaviac
{
	// Token: 0x02003D53 RID: 15699
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node60 : Condition
	{
		// Token: 0x0601623C RID: 90684 RVA: 0x006B0EA7 File Offset: 0x006AF2A7
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node60()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x0601623D RID: 90685 RVA: 0x006B0EB8 File Offset: 0x006AF2B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA9C RID: 64156
		private int opl_p0;
	}
}
