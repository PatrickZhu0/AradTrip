using System;

namespace behaviac
{
	// Token: 0x02003B9D RID: 15261
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node37 : Condition
	{
		// Token: 0x06015EEA RID: 89834 RVA: 0x006A05A5 File Offset: 0x0069E9A5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node37()
		{
			this.opl_p0 = 2;
		}

		// Token: 0x06015EEB RID: 89835 RVA: 0x006A05B4 File Offset: 0x0069E9B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F796 RID: 63382
		private int opl_p0;
	}
}
