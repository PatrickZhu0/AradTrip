using System;

namespace behaviac
{
	// Token: 0x02003B94 RID: 15252
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node85 : Condition
	{
		// Token: 0x06015ED8 RID: 89816 RVA: 0x006A0295 File Offset: 0x0069E695
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node85()
		{
			this.opl_p0 = 0;
		}

		// Token: 0x06015ED9 RID: 89817 RVA: 0x006A02A4 File Offset: 0x0069E6A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 0;
			bool flag = num == num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F78C RID: 63372
		private int opl_p0;
	}
}
