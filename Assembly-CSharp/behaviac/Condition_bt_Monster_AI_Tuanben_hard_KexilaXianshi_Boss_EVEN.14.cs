using System;

namespace behaviac
{
	// Token: 0x02003CDE RID: 15582
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node99 : Condition
	{
		// Token: 0x0601615D RID: 90461 RVA: 0x006ACB85 File Offset: 0x006AAF85
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node99()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x0601615E RID: 90462 RVA: 0x006ACB94 File Offset: 0x006AAF94
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA0E RID: 64014
		private int opl_p0;
	}
}
