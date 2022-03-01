using System;

namespace behaviac
{
	// Token: 0x02003CE6 RID: 15590
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node105 : Condition
	{
		// Token: 0x0601616D RID: 90477 RVA: 0x006ACD62 File Offset: 0x006AB162
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_EVENT_hard_node105()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x0601616E RID: 90478 RVA: 0x006ACD74 File Offset: 0x006AB174
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA16 RID: 64022
		private int opl_p0;
	}
}
