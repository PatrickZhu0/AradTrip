using System;

namespace behaviac
{
	// Token: 0x02003B99 RID: 15257
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node31 : Condition
	{
		// Token: 0x06015EE2 RID: 89826 RVA: 0x006A0439 File Offset: 0x0069E839
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node31()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015EE3 RID: 89827 RVA: 0x006A0448 File Offset: 0x0069E848
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 1;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F792 RID: 63378
		private int opl_p0;
	}
}
