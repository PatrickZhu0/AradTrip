using System;

namespace behaviac
{
	// Token: 0x02003A8E RID: 14990
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node93 : Condition
	{
		// Token: 0x06015CE1 RID: 89313 RVA: 0x00696AD8 File Offset: 0x00694ED8
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node93()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015CE2 RID: 89314 RVA: 0x00696AE8 File Offset: 0x00694EE8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 5;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F618 RID: 63000
		private int opl_p0;
	}
}
