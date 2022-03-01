using System;

namespace behaviac
{
	// Token: 0x02003D59 RID: 15705
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node23 : Condition
	{
		// Token: 0x06016248 RID: 90696 RVA: 0x006B1096 File Offset: 0x006AF496
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node23()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06016249 RID: 90697 RVA: 0x006B10A8 File Offset: 0x006AF4A8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAA7 RID: 64167
		private int opl_p0;
	}
}
