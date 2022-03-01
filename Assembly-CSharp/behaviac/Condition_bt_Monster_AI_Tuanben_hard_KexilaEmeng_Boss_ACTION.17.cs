using System;

namespace behaviac
{
	// Token: 0x02003BA2 RID: 15266
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node69 : Condition
	{
		// Token: 0x06015EF4 RID: 89844 RVA: 0x006A0766 File Offset: 0x0069EB66
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node69()
		{
			this.opl_p0 = 4;
		}

		// Token: 0x06015EF5 RID: 89845 RVA: 0x006A0778 File Offset: 0x0069EB78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F79C RID: 63388
		private int opl_p0;
	}
}
