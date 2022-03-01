using System;

namespace behaviac
{
	// Token: 0x02003A98 RID: 15000
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node102 : Condition
	{
		// Token: 0x06015CF4 RID: 89332 RVA: 0x00696D3E File Offset: 0x0069513E
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_EVENT_node102()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015CF5 RID: 89333 RVA: 0x00696D50 File Offset: 0x00695150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 2;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F627 RID: 63015
		private int opl_p0;
	}
}
