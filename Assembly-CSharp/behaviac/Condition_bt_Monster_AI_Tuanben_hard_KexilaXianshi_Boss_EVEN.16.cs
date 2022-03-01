using System;

namespace behaviac
{
	// Token: 0x02003CE2 RID: 15586
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node102 : Condition
	{
		// Token: 0x06016165 RID: 90469 RVA: 0x006ACC72 File Offset: 0x006AB072
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node102()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06016166 RID: 90470 RVA: 0x006ACC84 File Offset: 0x006AB084
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA12 RID: 64018
		private int opl_p0;
	}
}
