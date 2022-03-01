using System;

namespace behaviac
{
	// Token: 0x02003B9F RID: 15263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node5 : Condition
	{
		// Token: 0x06015EEE RID: 89838 RVA: 0x006A062B File Offset: 0x0069EA2B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaEmeng_Boss_ACTION_hard_node5()
		{
			this.opl_p0 = 1;
		}

		// Token: 0x06015EEF RID: 89839 RVA: 0x006A063C File Offset: 0x0069EA3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			int num = ((BTAgent)pAgent).Condition_GetCounter(this.opl_p0);
			int num2 = 3;
			bool flag = num >= num2;
			return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F798 RID: 63384
		private int opl_p0;
	}
}
