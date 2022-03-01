using System;

namespace behaviac
{
	// Token: 0x020039F6 RID: 14838
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node26 : Condition
	{
		// Token: 0x06015BBA RID: 89018 RVA: 0x00690A88 File Offset: 0x0068EE88
		public Condition_bt_Monster_AI_Tuanben_KexilaEmeng_Boss_EVENT_node26()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015BBB RID: 89019 RVA: 0x00690A98 File Offset: 0x0068EE98
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4EE RID: 62702
		private int opl_p0;
	}
}
